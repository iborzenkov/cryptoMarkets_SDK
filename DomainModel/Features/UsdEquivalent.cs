using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;

namespace DomainModel.Features
{
    public class UsdEquivalent
    {
        private const int Interval = 30 * 60 * 1000; // once in half an hour
        private readonly Market _market;

        public UsdEquivalent(Market market)
        {
            _market = market;
        }

        public double? UsdRate(Currency currency)
        {
            lock (currency)
            {
                double rate;
                if (_usdRate.TryGetValue(currency.Name, out rate))
                {
                    return rate;
                }

                if (GetThroughDirectPair(currency, out rate) || GetThroughIntermediatePair(currency, out rate))
                {
                    var timer = new Timer(Interval);
                    timer.Elapsed += Timer_Elapsed;
                    timer.Start();
                    _timers.Add(timer, currency);

                    _usdRate.Add(currency.Name, rate);
                    return rate;
                }

                return null;
            }
        }

        public double? Get(Currency currency, double quantity)
        {
            return UsdRate(currency) * quantity;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var timer = sender as Timer;
            if (timer == null)
                throw new Exception("Timer is null");

            timer.Stop();
            timer.Elapsed -= Timer_Elapsed;

            var currency = _timers[timer];
            _timers.Remove(timer);
            _usdRate.Remove(currency.Name);
        }

        private readonly Dictionary<Timer, Currency> _timers = new Dictionary<Timer, Currency>();

        private Pair GetUsdPair(Currency currency)
        {
            if (UsdCurrency == null)
                return null;

            foreach (var pairOfMarket in _market.Pairs)
            {
                if (pairOfMarket.Pair.QuoteCurrency.Equals(currency) &&
                    pairOfMarket.Pair.BaseCurrency.Equals(UsdCurrency))
                    return pairOfMarket.Pair;

                if (pairOfMarket.Pair.QuoteCurrency.Equals(UsdCurrency) &&
                    pairOfMarket.Pair.BaseCurrency.Equals(currency))
                    return pairOfMarket.Pair;
            }

            return null;
        }

        private Currency UsdCurrency => _market.Usd.Currency;

        private readonly Dictionary<string, double> _usdRate = new Dictionary<string, double>();

        private bool GetThroughDirectPair(Currency currency, out double rate)
        {
            rate = double.NaN;

            var usdPair = GetUsdPair(currency);
            if (usdPair == null)
                return false;

            var tick = _market.Model.Info.Tick(usdPair);
            rate = usdPair.QuoteCurrency.Equals(UsdCurrency) ? tick.Last : 1 / tick.Last;

            return true;
        }

        private bool GetThroughIntermediatePair(Currency currency, out double rate)
        {
            rate = double.NaN;

            Pair pair;
            Pair intermediatePair;
            if (!TryGetIntermediatePair(currency, out pair, out intermediatePair))
                return false;

            var tick = _market.Model.Info.Tick(pair);
            var price = pair.QuoteCurrency.Equals(currency) ? tick.Last : 1 / tick.Last;

            var tickIntermediate = _market.Model.Info.Tick(intermediatePair);
            var priceIntermediate = intermediatePair.BaseCurrency.Equals(_market.Usd.Currency) ? tickIntermediate.Last : 1 / tickIntermediate.Last;

            rate = priceIntermediate / (1 / price);
            return true;
        }

        private bool TryGetIntermediatePair(Currency currency, out Pair pair, out Pair intermediatePair)
        {
            pair = null;
            intermediatePair = null;

            var pairs = new List<Pair>();
            foreach (var pairOfMarket in _market.Pairs)
            {
                if (pairOfMarket.Pair.HasCurrency(currency))
                    pairs.Add(pairOfMarket.Pair);
            }

            var usdPairs = _market.Pairs.Where(p => p.Pair.HasCurrency(_market.Usd.Currency)).ToArray();
            foreach (var currencyPair in pairs)
            {
                var currency1 = currencyPair.BaseCurrency.Equals(currency)
                    ? currencyPair.QuoteCurrency
                    : currencyPair.BaseCurrency;
                var pairOfMarket = usdPairs.FirstOrDefault(p => p.Pair.HasCurrency(currency1));
                if (pairOfMarket != null)
                {
                    pair = currencyPair;
                    intermediatePair = pairOfMarket.Pair;
                    return true;
                }
            }
            return false;
        }

        public void NeedUpdate()
        {
            _timers.Keys.ForEach(t => t.Stop());
            _timers.Clear();
            _usdRate.Clear();
        }
    }
}
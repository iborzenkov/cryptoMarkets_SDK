using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using DomainModel.MarketModel.Updaters.OrderBook;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using DomainModel.MarketModel.Updaters;
using DomainModel.MarketModel.Updaters.PairTick;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class OrderBookModel : IOrderBookModel
    {
        private readonly IModel _domainModel;

        public OrderBookModel(IModel domainModel)
        {
            _domainModel = domainModel;

            OrderBookSettings = DefaultSettings.Instance.OrderBookSettings;
        }

        private IOrderBookUpdaterProvider OrderBookUpdaterProvider => _domainModel.OrderBookUpdaterProvider;
        private IPairTickUpdaterProvider PairTickUpdaterProvider => _domainModel.PairTickUpdaterProvider;

        IEnumerable<Market> IOrderBookModel.Markets => _domainModel.Markets;

        private void ResetUpdaters()
        {
            if (_updater != null)
            {
                OrderBookUpdaterProvider.ReleaseUpdater(_updater);
                _updater.Changed -= OrderBookUpdater_Changed;
                _updater = null;
            }

            if (_usdRateUpdater != null)
            {
                PairTickUpdaterProvider.ReleaseUpdater(_usdRateUpdater);
                _usdRateUpdater.Changed -= PairUsdRateUpdaterChanged;
                _usdRateUpdater = null;
            }
        }

        private void ResetUsdRate()
        {
            UsdRateChanged?.Invoke(this, null);
        }

        private readonly RefreshInterval _usdRateRefreshInterval = RefreshInterval.InMinutes(5);

        private void SetUpdaters(PairOfMarket pair)
        {
            _updater = OrderBookUpdaterProvider.OrderBookUpdater(pair);
            _updater.Changed += OrderBookUpdater_Changed;
            SetUpdaterSettings();
            _updater.Start();

            _usdPair = GetUsdPair(pair);
            if (_usdPair != null)
            {
                _usdRateUpdater = PairTickUpdaterProvider.PairTickUpdater(_usdPair, _usdRateRefreshInterval);
                _usdRateUpdater.Changed += PairUsdRateUpdaterChanged;
                _usdRateUpdater.Start();
            }
        }

        private PairOfMarket GetUsdPair(PairOfMarket pair)
        {
            var usdCurrency = pair.Market.Usd;
            if (usdCurrency == null)
                return null;

            var currency = pair.Pair.QuoteCurrency;
            foreach (var pairOfMarket in pair.Market.Pairs)
            {
                if (pairOfMarket.Pair.QuoteCurrency.Equals(currency) &&
                    pairOfMarket.Pair.BaseCurrency.Equals(usdCurrency.Currency))
                    return pairOfMarket;

                if (pairOfMarket.Pair.QuoteCurrency.Equals(usdCurrency.Currency) &&
                    pairOfMarket.Pair.BaseCurrency.Equals(currency))
                    return pairOfMarket;
            }

            return null;
        }

        void IOrderBookModel.NeedOrderBookOf(PairOfMarket pair)
        {
            ResetUpdaters();
            ResetUsdRate();

            if (pair == null)
            {
                OrderBook = null;
                OnOrderBookChanged();
                return;
            }

            SetUpdaters(pair);
        }

        private IOrderBookUpdater _updater;
        private IPairTickUpdater _usdRateUpdater;

        private OrderBookSettings _orderBookSettings;
        private PairOfMarket _usdPair;

        public OrderBookSettings OrderBookSettings
        {
            get
            {
                return _orderBookSettings;
            }
            set
            {
                _orderBookSettings = value;
                SetUpdaterSettings();

                OrderBookAdapter.Depth = _orderBookSettings.Depth;
                OrderBookAdapter.Type = _orderBookSettings.OrderBookType;
                OrderBookAdapter.Multiplier = _orderBookSettings.Multiplier;

                if (OrderBook != null)
                    OnOrderBookChanged();
            }
        }

        private void SetUpdaterSettings()
        {
            if (_updater == null)
                return;

            _updater.Depth = 100; //OrderBookSettings.Depth;
            _updater.OrderBookType = OrderBookType.Both; //OrderBookSettings.OrderBookType;
            _updater.RefreshInterval = OrderBookSettings.RefreshInterval;
        }

        private IOrderBook OrderBook { get; set; }
        private OrderBookAdapter OrderBookAdapter { get; } = new OrderBookAdapter();

        private void OrderBookUpdater_Changed(object sender, IOrderBook orderBook)
        {
            OrderBook = orderBook;
            OrderBookAdapter.SetOrderBook(OrderBook);
            OnOrderBookChanged();
        }

        private void PairUsdRateUpdaterChanged(object sender, Tick tick)
        {
            OnUsdRateChanged(tick);
        }

        public event EventHandler<IOrderBook> OrderBookChanged;
        public event EventHandler<double?> UsdRateChanged;

        public void Release()
        {
            ResetUpdaters();
        }

        private void OnOrderBookChanged()
        {
            OrderBookChanged?.Invoke(this, OrderBookAdapter);
        }

        protected virtual void OnUsdRateChanged(Tick tick)
        {
            double? price = null;

            if (tick != null)
            {
                price = tick.Last;
                if (_usdPair.Pair.QuoteCurrency.Equals(_usdPair.Market.Usd.Currency))
                    price = 1 / price;
            }

            UsdRateChanged?.Invoke(this, price);
        }
    }
}
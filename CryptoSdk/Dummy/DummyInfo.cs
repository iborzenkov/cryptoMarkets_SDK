using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Dummy
{
    public class DummyInfo : IMarketInfo
    {
        private List<PairOfMarket> _pairs;
        private List<CurrencyOfMarket> _currencies;

        public IEnumerable<PairOfMarket> Pairs(Market market)
        {
            return _pairs ?? (_pairs = new List<PairOfMarket>
            {
                new PairOfMarket(PairDummy.LtcBtc, market, 0.000001),
                new PairOfMarket(PairDummy.EthBtc, market, 0.000001),
                new PairOfMarket(PairDummy.LtcEth, market, 0.000001),
                new PairOfMarket(PairDummy.DogeBtc, market, 0.000001, false),
                new PairOfMarket(PairDummy.UsdtBtc, market, 0.000001),
                new PairOfMarket(PairDummy.UsdtLtc, market, 0.000001)
            });
        }

        public IEnumerable<CurrencyOfMarket> Currencies(Market market)
        {
            return _currencies ?? (_currencies = new List<CurrencyOfMarket>
            {
                new CurrencyOfMarket(CurrencyDummy.Btc, market, 0.01),
                new CurrencyOfMarket(CurrencyDummy.Ltc, market, 0.01),
                new CurrencyOfMarket(CurrencyDummy.Eth, market, 0.01),
                new CurrencyOfMarket(CurrencyDummy.Doge, market, 0.01, false),
                new CurrencyOfMarket(CurrencyDummy.Usdt, market, 0.01),
            });
        }

        public Tick Tick(Pair pair)
        {
            var bid = new Random().NextDouble();
            var ask = bid - 0.0001;
            var last = (bid + ask) / 2;
            return new Tick(bid, ask, last);
        }

        public OrderBook OrderBook(Pair pair, int depth = 10, OrderBookType orderBookType = OrderBookType.Both)
        {
            var result = new OrderBook(pair);

            var rnd = new Random();
            var startPrice = rnd.NextDouble();

            var asks = new List<OrderBookPart>();
            for (var i = 0; i < depth; i++)
            {
                var step = rnd.NextDouble();
                asks.Add(new OrderBookPart(startPrice + step, rnd.NextDouble()));
            }

            var bids = new List<OrderBookPart>();
            for (var i = 0; i < depth; i++)
            {
                var step = rnd.NextDouble();
                bids.Add(new OrderBookPart(startPrice - step, rnd.NextDouble()));
            }

            result.ReplaceAsk(asks);
            result.ReplaceBids(bids);

            return result;
        }

        public ICollection<Pair24HoursStatistic> Pairs24HoursStatistic()
        {
            var result = new List<Pair24HoursStatistic>
            {
                new Pair24HoursStatistic(PairDummy.LtcBtc, 0.1234, 0.0234, 1234, 4321, 0.02, 0.02345, 40, 34, DateTime.Now),
                new Pair24HoursStatistic(PairDummy.EthBtc, 10, 7, 100, 200, 7, 4, 400, 340, DateTime.Now)
            };

            return result;
        }

        public Pair24HoursStatistic Pair24HoursStatistic(Pair pair)
        {
            return new Pair24HoursStatistic(PairDummy.LtcBtc, 0.1234, 0.0234, 1234, 4321, 0.02, 0.02345, 40, 34, DateTime.Now);
        }

        public IEnumerable<MarketHistory> MarketTradeHistory(Pair pair, TimeRange timeRange)
        {
            var result = new List<MarketHistory>
            {
                new MarketHistory(pair, "id1", DateTime.Now, 12, 0.12, 34, TradePosition.Buy),
                new MarketHistory(pair, "id2", DateTime.Now, 2, 0.45, 8, TradePosition.Sell)
            };

            return result;
        }

        public IEnumerable<HistoryPrice> MarketHistoryData(Pair pair, TimeframeType timeframe, TimeRange timeRange)
        {
            return Enumerable.Empty<HistoryPrice>();
        }
    }
}
using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Extensions;
using CryptoSdk.Bittrex.DataTypes.Misc;
using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexInfo : BittrexBase, IMarketInfo
    {
        public BittrexInfo(IConnection connection) : base(connection)
        {
        }

        public Tick Tick(Pair pair)
        {
            Tick result = null;

            var query = Connection.PublicGetQuery<BittrexTickerDataType>(
                EndPoints.GetTicker, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.Ticker.ToTick();

            return result;
        }

        public IEnumerable<PairOfMarket> Pairs(Market market)
        {
            var result = new List<PairOfMarket>();

            var query = Connection.PublicGetQuery<BittrexMarketsDataType>(EndPoints.GetMarkets);
            if (query.Success)
                result.AddRange(query.Pairs.Select(marketDataType => marketDataType.ToPair(market)));

            result.Sort(Comparison);
            return result;
        }

        private static int Comparison(PairOfMarket pair1, PairOfMarket pair2)
        {
            return string.CompareOrdinal(pair1.Pair.ToString(), pair2.Pair.ToString());
        }

        public IEnumerable<CurrencyOfMarket> Currencies(Market market)
        {
            var result = new List<CurrencyOfMarket>();

            var query = Connection.PublicGetQuery<BittrexCurrenciesDataType>(EndPoints.GetCurrencies);
            if (query.Success)
                result.AddRange(query.Currencies.Select(currencyDataType => currencyDataType.ToCurrency(market)));

            return result;
        }

        public ICollection<Pair24HoursStatistic> Pairs24HoursStatistic()
        {
            var result = new List<Pair24HoursStatistic>();

            var query = Connection.PublicGetQuery<BittrexMarketSummaries>(EndPoints.GetMarketSummaries);
            if (query.Success)
                result.AddRange(query.MarketSummaries.Select(summaryDataType => summaryDataType.ToMarketSummary()));

            return result;
        }

        public Pair24HoursStatistic Pair24HoursStatistic(Pair pair)
        {
            Pair24HoursStatistic result = null;

            var query = Connection.PublicGetQuery<BittrexMarketSummaries>(
                EndPoints.GetMarketSummary, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.MarketSummaries[0].ToMarketSummary();

            return result;
        }

        public IEnumerable<MarketHistory> MarketTradeHistory(Pair pair, TimeRange timeRange)
        {
            var result = new List<MarketHistory>();

            var parameters = new Tuple<string, string>[1];
            parameters[0] = new Tuple<string, string>("market", BittrexPairs.AsString(pair));

            var query = Connection.PublicGetQuery<BittrexMarketHistoryDataType>(EndPoints.GetMarketHistory, parameters);
            if (query.Success)
                result.AddRange(
                    query.Items.Select(item => item.ToHistory(pair)));

            return result;
        }

        public IEnumerable<HistoryPrice> MarketHistoryData(Pair pair, TimeframeType timeframe, TimeRange timeRange)
        {
            return Enumerable.Empty<HistoryPrice>();
        }

        public OrderBook OrderBook(Pair pair, int depth, OrderBookType orderBookType)
        {
            OrderBook result = null;

            var parameters = new Tuple<string, string>[3];
            parameters[0] = new Tuple<string, string>("market", BittrexPairs.AsString(pair));
            parameters[1] = new Tuple<string, string>("type", orderBookType.AsString());
            parameters[2] = new Tuple<string, string>("depth", depth.ToString());

            if (orderBookType == OrderBookType.Both)
            {
                var query = Connection.PublicGetQuery<BittrexOrderBookDataType>(EndPoints.GetOrderBook, parameters);
                if (query.Success)
                    result = query.ToOrderBook(pair);
            }
            else
            {
                var query = Connection.PublicGetQuery<BittrexOrderBookOneSideDataType>(EndPoints.GetOrderBook, parameters);
                if (query.Success)
                    result = query.ToOrderBook(pair, orderBookType);
            }

            return result;
        }
    }
}
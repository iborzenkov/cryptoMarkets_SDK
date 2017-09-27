using CryptoSdk.Poloniex.Connection;
using CryptoSdk.Poloniex.DataTypes;
using CryptoSdk.Poloniex.DataTypes.Extensions;
using CryptoSdk.Poloniex.DataTypes.Misc;
using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Poloniex.Model
{
    public class PoloniexInfo : BasePoloniex, IMarketInfo
    {
        public PoloniexInfo(IConnection connection) : base(connection)
        {
        }

        public Tick Tick(Pair pair)
        {
            var parameters = new Tuple<string, string>[1];
            parameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetTicker);

            var query = Connection.PublicGetQuery<Dictionary<string, PoloniexTickerDataType>>(EndPoints.Public, parameters);
            var key = PoloniexPairs.AsString(pair);
            return query.ContainsKey(key) ? query[key].ToTick() : null;
        }

        public IEnumerable<PairOfMarket> Pairs(Market market)
        {
            var result = new List<PairOfMarket>();

            var parameters = new Tuple<string, string>[1];
            parameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetTicker);

            var query = Connection.PublicGetQuery<Dictionary<string, PoloniexTickerDataType>>(EndPoints.Public, parameters);
            foreach (var pairName in query.Keys)
            {
                result.Add(query[pairName].ToPair(pairName, market));
            }
            result.Sort(Comparison);
            return result.Where(p => p != null);
        }

        private static int Comparison(PairOfMarket pair1, PairOfMarket pair2)
        {
            return string.CompareOrdinal(pair1.Pair.ToString(), pair2.Pair.ToString());
        }

        public IEnumerable<CurrencyOfMarket> Currencies(Market market)
        {
            var result = new List<CurrencyOfMarket>();

            var parameters = new Tuple<string, string>[1];
            parameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetCurrencies);

            var query = Connection.PublicGetQuery<Dictionary<string, PoloniexCurrencyDataType>>(EndPoints.Public, parameters);

            foreach (var currencyShortName in query.Keys)
            {
                result.Add(query[currencyShortName].ToCurrency(currencyShortName, market));
            }
            return result;
        }

        public ICollection<Pair24HoursStatistic> Pairs24HoursStatistic()
        {
            var result = new List<Pair24HoursStatistic>();

            var parameters = new Tuple<string, string>[1];
            parameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetTicker);

            var query = Connection.PublicGetQuery<Dictionary<string, PoloniexTickerDataType>>(EndPoints.Public, parameters);

            foreach (var pairName in query.Keys)
            {
                result.Add(query[pairName].ToPairsStatistic(pairName));
            }
            return result;
        }

        public Pair24HoursStatistic Pair24HoursStatistic(Pair pair)
        {
            return Pairs24HoursStatistic().FirstOrDefault(s => s.Pair.Equals(pair));
        }

        public IEnumerable<MarketHistory> MarketTradeHistory(Pair pair, TimeRange timeRange)
        {
            var paramsCount = timeRange != null ? 4 : 2;
            var parameters = new Tuple<string, string>[paramsCount];
            parameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetMarketHistory);
            parameters[1] = new Tuple<string, string>("currencyPair", PoloniexPairs.AsString(pair));
            if (timeRange != null)
            {
                parameters[2] = new Tuple<string, string>("start", PoloniexTools.DateTimeToUnixTimeStamp(timeRange.Start).ToString());
                parameters[3] = new Tuple<string, string>("end", PoloniexTools.DateTimeToUnixTimeStamp(timeRange.Finish).ToString());
            }

            var query = Connection.PublicGetQuery<List<PoloniexTradeHistoryDataType>>(EndPoints.Public, parameters);

            return query.Select(item => item.ToHistory(pair));
        }

        public OrderBook OrderBook(Pair pair, int depth, OrderBookType orderBookType)
        {
            var parameters = new Tuple<string, string>[3];
            parameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetOrderBook);
            parameters[1] = new Tuple<string, string>("currencyPair", PoloniexPairs.AsString(pair));
            parameters[2] = new Tuple<string, string>("depth", depth.ToString());

            var query = Connection.PublicGetQuery<PoloniexOrderBookDataType>(EndPoints.Public, parameters);
            var result = query.ToOrderBook(pair);

            if (orderBookType == OrderBookType.Buy)
                result.ReplaceBids(null);

            if (orderBookType == OrderBookType.Sell)
                result.ReplaceAsk(null);

            return result;
        }
    }
}
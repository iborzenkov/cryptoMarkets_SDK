using System.Collections.Generic;
using System.Linq;
using CryptoSdk.Poloniex.DataTypes.Extensions;
using CryptoSdk.Bittrex.Features;
using CryptoSdk.Bittrex.Model;
using CryptoSdk.Poloniex.Connection;
using CryptoSdk.Poloniex.DataTypes;
using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;

namespace CryptoSdk.Poloniex.Model
{
    public class PoloniexInfo : BasePoloniex, IPoloniexMarketInfo
    {

        public PoloniexInfo(IConnection connection) : base(connection)
        {
        }

        Tick IMarketInfo.Tick(Pair pair)
        {
            Tick result = null;

            /*var query = Connection.PublicGetQuery<BittrexTickerDataType>(
                EndPoints.GetTicker, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.Ticker.ToTick();*/

            return result;
        }

        public IEnumerable<PairOfMarket> Pairs(Market market)
        {
            var result = new List<PairOfMarket>();

            var query = Connection.PublicGetQuery<Dictionary<string, PoloniexTickerDataType>>(EndPoints.GetTicker);
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

            var query = Connection.PublicGetQuery<Dictionary<string, PoloniexCurrencyDataType>>(EndPoints.GetCurrencies);

            foreach (var currencyShortName in query.Keys)
            {
                result.Add(query[currencyShortName].ToCurrency(currencyShortName, market));
            }
            return result;
        }

        public ICollection<PairStatistic> PairsStatistic()
        {
            var result = new List<PairStatistic>();

            var query = Connection.PublicGetQuery<Dictionary<string, PoloniexTickerDataType>>(EndPoints.GetTicker);

            foreach (var pairName in query.Keys)
            {
                result.Add(query[pairName].ToPairsStatistic(pairName));
            }
            return result;
        }

        ICollection<MarketHistory> IMarketInfo.MarketHistory(Pair pair)
        {
            var result = new List<MarketHistory>();

            /*var parameters = new Tuple<string, string>[1];
            parameters[0] = new Tuple<string, string>("market", BittrexPairs.AsString(pair));

            var query = Connection.PublicGetQuery<BittrexMarketHistoryDataType>(EndPoints.GetMarketHistory, parameters);
            if (query.Success)
                result.AddRange(
                    query.Items.Select(item => item.ToHistory(pair)));*/

            return result;
        }

        OrderBook IMarketInfo.OrderBook(Pair pair, int depth, OrderBookType orderBookType)
        {
            OrderBook result = null;

            /*var parameters = new Tuple<string, string>[3];
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
            }*/

            return result;
        }

        public ICollection<MarketSummary> MarketSummaries()
        {
            var result = new List<MarketSummary>();

            /*var query = Connection.PublicGetQuery<BittrexMarketSummaries>(EndPoints.GetMarketSummaries);
            if (query.Success)
                result.AddRange(query.MarketSummaries.Select(marketSummary => marketSummary.ToMarketSummary()));*/

            return result;
        }

        public MarketSummary MarketSummaries(Pair pair)
        {
            MarketSummary result = null;

            /*var query = Connection.PublicGetQuery<BittrexMarketSummaries>(
                EndPoints.GetMarketSummary, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.MarketSummaries[0].ToMarketSummary();*/

            return result;
        }
    }
}
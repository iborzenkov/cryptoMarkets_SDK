using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Extensions;
using CryptoSdk.Bittrex.DataTypes.Misc;
using CryptoSdk.Bittrex.Features;
using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexInfo : IBittrexMarketInfo
    {
        private readonly IConnection _connection;

        public BittrexInfo(IConnection connection)
        {
            _connection = connection;
        }

        Tick IMarketInfo.Tick(Pair pair)
        {
            Tick result = null;

            var query = _connection.PublicGetQuery<BittrexTickerDataType>(
                EndPoints.GetTicker, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.Ticker.ToTick();

            return result;
        }

        IEnumerable<PairOfMarket> IMarketInfo.Pairs(Market market)
        {
            var result = new List<PairOfMarket>();

            var query = _connection.PublicGetQuery<BittrexMarketsDataType>(EndPoints.GetMarkets);
            if (query.Success)
                result.AddRange(query.Pairs.Select(marketDataType => marketDataType.ToPair(market)));

            return result;
        }

        IEnumerable<CurrencyOfMarket> IMarketInfo.Currencies(Market market)
        {
            var result = new List<CurrencyOfMarket>();

            var query = _connection.PublicGetQuery<BittrexCurrenciesDataType>(EndPoints.GetCurrencies);
            if (query.Success)
                result.AddRange(query.Currencies.Select(currencyDataType => currencyDataType.ToCurrency(market)));

            return result;
        }

        ICollection<PairStatistic> IMarketInfo.PairsStatistic()
        {
            var summaries = (this as IBittrexMarketInfo).MarketSummaries();

            return summaries.Select(
                summary => new PairStatistic(
                    summary.Pair, summary.High, summary.Low, summary.BaseVolume, summary.Last, 
                    summary.PreviousDayPrice, summary.CountOpenedBuyOrders, summary.CountOpenedSellOrders)).ToList();
        }

        OrderBook IMarketInfo.OrderBook(Pair pair, int depth, OrderBookType orderBookType)
        {
            OrderBook result = null;

            var parameters = new Tuple<string, string>[3];
            parameters[0] = new Tuple<string, string>("market", BittrexPairs.AsString(pair));
            parameters[1] = new Tuple<string, string>("type", orderBookType.AsString());
            parameters[2] = new Tuple<string, string>("depth", depth.ToString());

            if (orderBookType == OrderBookType.Both)
            {
                var query = _connection.PublicGetQuery<BittrexOrderBookDataType>(EndPoints.GetOrderBook, parameters);
                if (query.Success)
                    result = query.ToOrderBook(pair);
            }
            else
            {
                var query = _connection.PublicGetQuery<BittrexOrderBookOneSideDataType>(EndPoints.GetOrderBook, parameters);
                if (query.Success)
                    result = query.ToOrderBook(pair, orderBookType);
            }

            return result;
        }

        ICollection<MarketSummary> IBittrexMarketInfo.MarketSummaries()
        {
            var result = new List<MarketSummary>();

            var query = _connection.PublicGetQuery<BittrexMarketSummaries>(EndPoints.GetMarketSummaries);
            if (query.Success)
                result.AddRange(query.MarketSummaries.Select(marketSummary => marketSummary.ToMarketSummary()));

            return result;
        }

        MarketSummary IBittrexMarketInfo.MarketSummaries(Pair pair)
        {
            MarketSummary result = null;

            var query = _connection.PublicGetQuery<BittrexMarketSummaries>(EndPoints.GetMarketSummary, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.MarketSummaries[0].ToMarketSummary();

            return result;
        }
    }
}
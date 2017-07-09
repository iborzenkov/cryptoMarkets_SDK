using System;
using System.Collections.Generic;
using System.Linq;
using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Extensions;
using CryptoSdk.Bittrex.DataTypes.Misc;
using CryptoSdk.Bittrex.Features;
using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexInfo : IBittrexMarketInfo
    {
        private readonly BittrexConnection _connection = new BittrexConnection();

        public BittrexInfo()
        {
            
        }

        IEnumerable<PairOfMarket> IMarketInfo.Pairs(Market market)
        {
            var result = new List<PairOfMarket>();

            var query = _connection.PublicGetQuery<BittrexMarketsDataType>(EndPoints.GetMarkets);
            if (query.Success)
                result.AddRange(query.Pairs.Select(marketDataType => marketDataType.ToPair(market)));

            return result;
        }

        public IEnumerable<CurrencyOfMarket> Currencies(Market market)
        {
            var result = new List<CurrencyOfMarket>();

            var query = _connection.PublicGetQuery<BittrexCurrenciesDataType>(EndPoints.GetCurrencies);
            if (query.Success)
                result.AddRange(query.Currencies.Select(currencyDataType => currencyDataType.ToCurrency(market)));

            return result;
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

        public OrderBook OrderBook(Pair pair, int depth = 10, OrderBookType orderBookType = OrderBookType.Both)
        {
            OrderBook result = null;

            var parameters = new Tuple<string, string>[3];
            parameters[0] = new Tuple<string, string>("market", BittrexPairs.AsString(pair));
            parameters[1] = new Tuple<string, string>("type", orderBookType.AsString());
            parameters[2] = new Tuple<string, string>("depth", depth.ToString());

            var query = _connection.PublicGetQuery<BittrexOrderBookDataType>(EndPoints.GetOrderBook, parameters);
            if (query.Success)
                result = query.ToOrderBook(pair);

            return result;
        }

        IEnumerable<MarketSummary> IBittrexMarketInfo.MarketSummaries()
        {
            var result = new List<MarketSummary>();

            var query = _connection.PublicGetQuery<BittrexMarketSummaries>(EndPoints.GetMarketSummary);
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
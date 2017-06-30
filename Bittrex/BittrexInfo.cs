using System;
using System.Collections.Generic;
using System.Linq;
using Bittrex.Connection;
using Bittrex.DataTypes;
using Bittrex.DataTypes.Extensions;
using Bittrex.DataTypes.Misc;
using Bittrex.Features;
using Model;
using Model.Features;

namespace Bittrex
{
    public class BittrexInfo : IBittrexMarketInfo
    {
        private readonly BittrexConnection _connection = new BittrexConnection();

        IEnumerable<Market> IMarketInfo.Markets()
        {
            var result = new List<Market>();

            var query = _connection.PublicGetQuery<BittrexMarketsDataType>(EndPoints.GetMarkets);
            if (query.Success)
                result.AddRange(query.Markets.Select(marketDataType => marketDataType.ToMarket()).Where(market => market != null));

            return result;
        }

        public IEnumerable<Currency> Currencies()
        {
            var result = new List<Currency>();

            var query = _connection.PublicGetQuery<BittrexCurrenciesDataType>(EndPoints.GetCurrencies);
            if (query.Success)
                result.AddRange(query.Currencies.Select(currencyDataType => currencyDataType.ToCurrency()).Where(currency => currency != null));

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
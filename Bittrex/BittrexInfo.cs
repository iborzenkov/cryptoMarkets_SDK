using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using BittrexModel.DataTypes;
using Model.Features;

namespace BittrexModel
{
    public class BittrexInfo : IBittrexMarketInfo
    {
        private readonly BittrexConnection _connection = new BittrexConnection();

        IEnumerable<Market> IMarketInfo.Markets()
        {
            var result = new List<Market>();

            var query = _connection.PublicGetQuery<BittrexMarketsDataType>(EndPoints.GetMarkets);
            if (query.Success)
                result.AddRange(query.Markets.Select(marketDataType => marketDataType.ToMarket).Where(market => market != null));

            return result;
        }

        public IEnumerable<Currency> Currencies()
        {
            var result = new List<Currency>();

            var query = _connection.PublicGetQuery<BittrexCurrenciesDataType>(EndPoints.GetCurrencies);
            if (query.Success)
                result.AddRange(query.Currencies.Select(currencyDataType => currencyDataType.ToCurrency).Where(currency => currency != null));

            return result;
        }

        Tick IMarketInfo.Tick(Pair pair)
        {
            Tick result = null;

            var query = _connection.PublicGetQuery<BittrexTickerDataType>(
                EndPoints.GetTicker, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.Ticker.ToTick;

            return result;
        }

        IEnumerable<MarketSummary> IBittrexMarketInfo.MarketSummaries()
        {
            throw new NotImplementedException();
        }

        MarketSummary IBittrexMarketInfo.MarketSummaries(Pair pair)
        {
            MarketSummary result = null;

            var query = _connection.PublicGetQuery<BittrexMarketSummaries>(
                EndPoints.GetMarketSummary, new Tuple<string, string>("market", BittrexPairs.AsString(pair)));
            if (query.Success)
                result = query.MarketSummaries[0].ToMarketSummary;

            return result;
        }
    }
}
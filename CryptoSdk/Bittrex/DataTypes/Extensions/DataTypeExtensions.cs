using System;
using System.Linq;
using CryptoSdk.Bittrex.Features;
using DomainModel.Features;

namespace CryptoSdk.Bittrex.DataTypes.Extensions
{
    public static class DataTypeExtensions
    {
        public static CurrencyOfMarket ToCurrency(this BittrexCurrencyDataType currencyDataType, Market market)
        {
            var currency = new CurrencyOfMarket(
                new Currency(currencyDataType.CurrencyName, currencyDataType.CurrencyLongName),
                market, currencyDataType.TxFee, currencyDataType.IsActive, currencyDataType.BaseAddress);

            return currency;
        }

        public static PairOfMarket ToPair(this BittrexPairDataType pairDataType, Market market)
        {
            DateTime dateTime;
            var created = DateTime.TryParse(pairDataType.Created, out dateTime) ? dateTime : (DateTime?)null;
            var pair = new PairOfMarket(
                new Pair(new Currency(pairDataType.BaseCurrency), new Currency(pairDataType.QuoteCurrency)),
                market, pairDataType.MinTradeSize, pairDataType.IsActive, created);

            return pair;
        }

        public static Tick ToTick(this TickerDataType tickerDataType)
        {
            return new Tick(tickerDataType.Bid, tickerDataType.Ask, tickerDataType.Last);
        }

        public static MarketSummary ToMarketSummary(this BittrexMarketSummary marketSummaryDataType)
        {
            Pair pair;
            if (!TryParsePair(marketSummaryDataType.MarketName, out pair))
                return null;

            var summary = new MarketSummary
            {
                BaseVolume = marketSummaryDataType.BaseVolume,
                Bid = marketSummaryDataType.Bid,
                Ask = marketSummaryDataType.Ask,
                CountOpenedBuyOrders = marketSummaryDataType.CountOpenBuyOrders,
                CountOpenedSellOrders = marketSummaryDataType.CountOpenSellOrders,
                High = marketSummaryDataType.High,
                Last = marketSummaryDataType.Last,
                Low = marketSummaryDataType.Low,
                Pair = pair,
                Volume = marketSummaryDataType.Volume
            };

            DateTime timeStamp;
            if (DateTime.TryParse(marketSummaryDataType.TimeStamp, out timeStamp))
                summary.TimeStamp = timeStamp;

            return summary;
        }

        private static bool TryParsePair(string pairString, out Pair pair)
        {
            pair = null;

            var currencies = pairString.Split('-');
            if (currencies.Length == 2)
                pair = new Pair(new Currency(currencies[0]), new Currency(currencies[1]));

            return pair != null;
        }

        public static OrderBook ToOrderBook(this BittrexOrderBookDataType orderBookDataType, Pair pair)
        {
            var result = new OrderBook(pair);

            var asks = orderBookDataType.OrderBook.Asks.Select(ask => new OrderBookPart(ask.Price, ask.Quantity));
            result.ReplaceAsk(asks);

            var bids = orderBookDataType.OrderBook.Bids.Select(bid => new OrderBookPart(bid.Price, bid.Quantity));
            result.ReplaceBids(bids);

            return result;
        }
    }
}
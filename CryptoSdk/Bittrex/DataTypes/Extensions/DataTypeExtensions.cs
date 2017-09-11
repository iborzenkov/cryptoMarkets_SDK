using CryptoSdk.Bittrex.Features;
using DomainModel;
using DomainModel.Features;
using System;
using System.Linq;

namespace CryptoSdk.Bittrex.DataTypes.Extensions
{
    public static class DataTypeExtensions
    {
        public static CurrencyOfMarket ToCurrency(this BittrexCurrencyDataType currencyDataType, Market market)
        {
            var currency = new CurrencyOfMarket(
                new Currency(currencyDataType.CurrencyName, currencyDataType.CurrencyLongName),
                market, currencyDataType.TxFee, currencyDataType.IsActive, CryptoAddress.FromString(currencyDataType.BaseAddress));

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

        public static MarketHistory ToHistory(this BittrexMarketHistoryItemDataType historyDataType, Pair pair)
        {
            DateTime timeStamp;
            if (!DateTime.TryParse(historyDataType.TimeStamp, out timeStamp))
                throw new Exception("TimeStamp is a required field");

            TradePosition orderType;

            switch (historyDataType.OrderType.ToLower())
            {
                case "buy":
                    orderType = TradePosition.Buy;
                    break;
                case "sell":
                    orderType = TradePosition.Sell;
                    break;
                default:
                    throw new Exception($"Unknown trade tag: {historyDataType.OrderType}");
            }

            var history = new MarketHistory(pair, historyDataType.Id.ToString(), timeStamp, 
                historyDataType.Quantity, historyDataType.Price, historyDataType.Total, orderType);

            return history;
        }
        
        public static Balance ToBalance(this BittrexBalanceItemDataType balanceItemDataType, Market market, Currency currency)
        {
            var balance = new Balance(
                market, currency, CryptoAddress.FromString(balanceItemDataType.CryptoAddress),
                balanceItemDataType.Available, balanceItemDataType.Balance - balanceItemDataType.Available, balanceItemDataType.Pending);

            return balance;
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
                Volume = marketSummaryDataType.Volume,
                PreviousDayPrice = marketSummaryDataType.PrevDay
            };

            DateTime timeStamp;
            if (DateTime.TryParse(marketSummaryDataType.TimeStamp, out timeStamp))
                summary.TimeStamp = timeStamp;

            return summary;
        }

        private static TradePosition PositionFromString(string positionStr)
        {
            switch (positionStr)
            {
                case "LIMIT_SELL":
                    return TradePosition.Sell;

                case "LIMIT_BUY":
                    return TradePosition.Sell;

                default:
                    throw new Exception($"{positionStr} is unknown position tag.");
            }
        }

        public static Order ToOrder(this BittrexOpenedLimitOrderItemDataType openedLimitOrder, Market market)
        {
            Pair pair;
            if (!TryParsePair(openedLimitOrder.Pair, out pair))
                return null;

            DateTime timeStamp;
            DateTime? opened = null;
            if (DateTime.TryParse(openedLimitOrder.Opened, out timeStamp))
                opened = timeStamp;
            var order = new Order(
                new OrderId(openedLimitOrder.Id), market, pair, 
                openedLimitOrder.Quantity, openedLimitOrder.Price, PositionFromString(openedLimitOrder.OrderType), opened);

            return order;
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

        public static OrderBook ToOrderBook(this BittrexOrderBookOneSideDataType orderBookDataType, Pair pair, OrderBookType orderBookType)
        {
            var result = new OrderBook(pair);

            var prices = orderBookDataType.Prices.Select(price => new OrderBookPart(price.Price, price.Quantity));
            if (orderBookType == OrderBookType.Sell)
                result.ReplaceAsk(prices);
            else
                result.ReplaceBids(prices);

            return result;
        }
    }
}
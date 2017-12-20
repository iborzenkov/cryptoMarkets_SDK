using CryptoSdk.Bittrex.DataTypes.Misc;
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
                market, currencyDataType.TxFee, currencyDataType.IsActive,
                CryptoAddress.FromString(currencyDataType.BaseAddress),
                currencyDataType.MinConfirmation);

            return currency;
        }

        public static PairOfMarket ToPair(this BittrexPairDataType pairDataType, Market market)
        {
            DateTime dateTime;
            var created = DateTime.TryParse(pairDataType.Created, out dateTime) ? dateTime : (DateTime?)null;
            var pair = new PairOfMarket(
                // rotate pair in Bittrex
                new Pair(new Currency(pairDataType.QuoteCurrency), new Currency(pairDataType.BaseCurrency)),
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
            double reserved = 0;
            if (balanceItemDataType.Balance.HasValue && balanceItemDataType.Available.HasValue)
                reserved = balanceItemDataType.Balance.Value - balanceItemDataType.Available.Value;

            var balance = new Balance(
                market, currency, CryptoAddress.FromString(balanceItemDataType.CryptoAddress),
                balanceItemDataType.Available ?? 0,
                reserved,
                balanceItemDataType.Pending ?? 0);

            return balance;
        }

        public static HistoryOrder ToHistoryOrder(this BittrexHistoryOrderItemDataType orderHistoryItemDataType, Market market)
        {
            Pair pair;
            if (!BittrexPairs.TryParsePair(orderHistoryItemDataType.Pair, out pair))
                return null;

            TradePosition orderType;
            switch (orderHistoryItemDataType.OrderType.ToLower())
            {
                case "limit_buy":
                    orderType = TradePosition.Buy;
                    break;

                case "limit_sell":
                    orderType = TradePosition.Sell;
                    break;

                default:
                    throw new Exception($"Unknown trade tag: {orderHistoryItemDataType.OrderType}");
            }

            DateTime dateTime;
            var timeStamp = DateTime.TryParse(orderHistoryItemDataType.TimeStamp, out dateTime) ? dateTime : (DateTime?)null;

            var historyOrder = new HistoryOrder(new OrderId(orderHistoryItemDataType.Id), 
                market, pair, orderHistoryItemDataType.Quantity, orderHistoryItemDataType.Limit, orderHistoryItemDataType.Commission,
                orderType, timeStamp);

            return historyOrder;
        }

        public static Tick ToTick(this TickerDataType tickerDataType)
        {
            return new Tick(tickerDataType.Bid, tickerDataType.Ask, tickerDataType.Last);
        }

        public static Pair24HoursStatistic ToMarketSummary(this BittrexMarketSummary marketSummaryDataType)
        {
            Pair pair;
            if (!BittrexPairs.TryParsePair(marketSummaryDataType.MarketName, out pair))
                return null;

            DateTime parsedTimeStamp;
            var timeStamp = DateTime.TryParse(marketSummaryDataType.TimeStamp, out parsedTimeStamp) ? parsedTimeStamp : (DateTime?)null;

            var summary = new Pair24HoursStatistic(pair,
                marketSummaryDataType.High, marketSummaryDataType.Low,
                marketSummaryDataType.BaseVolume, marketSummaryDataType.QuoteVolume,
                marketSummaryDataType.Last, marketSummaryDataType.PrevDay,
                marketSummaryDataType.CountOpenBuyOrders, marketSummaryDataType.CountOpenSellOrders,
                timeStamp);

            return summary;
        }

        private static TradePosition PositionFromString(string positionStr)
        {
            switch (positionStr)
            {
                case "LIMIT_SELL":
                    return TradePosition.Sell;

                case "LIMIT_BUY":
                    return TradePosition.Buy;

                default:
                    throw new Exception($"{positionStr} is unknown position tag.");
            }
        }

        public static Order ToOrder(this BittrexOpenedLimitOrderItemDataType openedLimitOrder, Market market)
        {
            Pair pair;
            if (!BittrexPairs.TryParsePair(openedLimitOrder.Pair, out pair))
                return null;

            DateTime timeStamp;
            DateTime? opened = null;
            if (DateTime.TryParse(openedLimitOrder.Opened, out timeStamp))
                opened = timeStamp;
            var order = new Order(
                new OrderId(openedLimitOrder.Id), market, pair,
                openedLimitOrder.Quantity, openedLimitOrder.Limit, PositionFromString(openedLimitOrder.OrderType), opened);

            return order;
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
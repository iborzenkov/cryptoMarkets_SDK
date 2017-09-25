using CryptoSdk.Bittrex.Features;
using CryptoSdk.Poloniex.DataTypes.Misc;
using DomainModel;
using DomainModel.Features;
using System;
using System.Linq;

namespace CryptoSdk.Poloniex.DataTypes.Extensions
{
    public static class DataTypeExtensions
    {
        public static CurrencyOfMarket ToCurrency(this PoloniexCurrencyDataType currencyDataType, string currencyShortName, Market market)
        {
            var currency = new CurrencyOfMarket(
                new Currency(currencyShortName, currencyDataType.CurrencyName),
                market, currencyDataType.TaxFee, !currencyDataType.IsDisabled,
                CryptoAddress.FromString(currencyDataType.DepositAddress),
                currencyDataType.MinConfirmation);

            return currency;
        }

        public static PairOfMarket ToPair(this PoloniexTickerDataType pairDataType, string pairName, Market market)
        {
            Pair pair;
            return PoloniexPairs.TryParsePair(pairName, out pair) ? new PairOfMarket(pair, market, !pairDataType.IsFrozen) : null;
        }

        public static MarketHistory ToHistory(this Bittrex.DataTypes.BittrexMarketHistoryItemDataType historyDataType, Pair pair)
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

        public static Balance ToBalance(this Bittrex.DataTypes.BittrexBalanceItemDataType balanceItemDataType, Market market, Currency currency)
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

        public static Tick ToTick(this Bittrex.DataTypes.TickerDataType tickerDataType)
        {
            return new Tick(tickerDataType.Bid, tickerDataType.Ask, tickerDataType.Last);
        }

        public static PairStatistic ToPairsStatistic(this PoloniexTickerDataType tickerDataType, string pairName)
        {
            Pair pair;
            if (!PoloniexPairs.TryParsePair(pairName, out pair))
                return null;

            var summary = new PairStatistic(pair, tickerDataType.High24Hr, tickerDataType.Low24Hr,
                tickerDataType.BaseVolume, tickerDataType.QuoteVolume, 
                tickerDataType.Last, tickerDataType.DailyChange);

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

        public static Order ToOrder(this Bittrex.DataTypes.BittrexOpenedLimitOrderItemDataType openedLimitOrder, Market market)
        {
            Pair pair;
            if (!PoloniexPairs.TryParsePair(openedLimitOrder.Pair, out pair))
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

        public static OrderBook ToOrderBook(this Bittrex.DataTypes.BittrexOrderBookDataType orderBookDataType, Pair pair)
        {
            var result = new OrderBook(pair);

            var asks = orderBookDataType.OrderBook.Asks.Select(ask => new OrderBookPart(ask.Price, ask.Quantity));
            result.ReplaceAsk(asks);

            var bids = orderBookDataType.OrderBook.Bids.Select(bid => new OrderBookPart(bid.Price, bid.Quantity));
            result.ReplaceBids(bids);

            return result;
        }

        public static OrderBook ToOrderBook(this Bittrex.DataTypes.BittrexOrderBookOneSideDataType orderBookDataType, Pair pair, OrderBookType orderBookType)
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
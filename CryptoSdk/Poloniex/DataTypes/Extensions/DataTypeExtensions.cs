using CryptoSdk.Poloniex.DataTypes.Misc;
using DomainModel;
using DomainModel.Features;
using System;
using System.Globalization;
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

        public static MarketHistory ToHistory(this PoloniexTradeHistoryDataType historyDataType, Pair pair)
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

        public static HistoryPrice ToHistory(this PoloniexHistoryDataType historyDataType, Pair pair)
        {
            var history = new HistoryPrice(PoloniexTools.UnixTimeStampToDateTime(historyDataType.TimeStamp), 
                historyDataType.Open, historyDataType.Close,
                historyDataType.High, historyDataType.Low, historyDataType.Volume, historyDataType.QuoteVolume);

            return history;
        }

        public static Balance ToBalance(this PoloniexBalanceDataType balanceItemDataType, CurrencyOfMarket currency, string cryptoAddress)
        {
            var balance = new Balance(
                currency, CryptoAddress.FromString(cryptoAddress),
                balanceItemDataType.Available ?? 0,
                0,
                balanceItemDataType.Pending ?? 0);

            return balance;
        }

        public static Tick ToTick(this PoloniexTickerDataType tickerDataType)
        {
            return new Tick(tickerDataType.Bid, tickerDataType.Ask, tickerDataType.Last);
        }

        public static Pair24HoursStatistic ToPairsStatistic(this PoloniexTickerDataType tickerDataType, string pairName)
        {
            Pair pair;
            if (!PoloniexPairs.TryParsePair(pairName, out pair))
                return null;

            var summary = new Pair24HoursStatistic(pair, tickerDataType.High24Hr, tickerDataType.Low24Hr,
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

        public static Order ToOrder(this PoloniexOpenedOrdersDataType openedOrder, Market market, Pair pair)
        {
            var order = new Order(
                new OrderId(openedOrder.Id), market, pair,
                openedOrder.Quantity, openedOrder.Price, PositionFromString(openedOrder.OrderType));

            return order;
        }

        public static HistoryOrder ToOrder(this PoloniexHistoryOrdersDataType historyOrder, Market market, Pair pair)
        {
            DateTime timeStamp;
            if (!DateTime.TryParse(historyOrder.Date, out timeStamp))
                throw new Exception("TimeStamp is a required field");

            var order = new HistoryOrder(
                new OrderId(historyOrder.Id), market, pair,
                historyOrder.Quantity, historyOrder.Price, historyOrder.Fee, 
                PositionFromString(historyOrder.OrderType), timeStamp);

            return order;
        }

        public static OrderBook ToOrderBook(this PoloniexOrderBookDataType orderBookDataType, Pair pair)
        {
            var result = new OrderBook(pair);

            var nfi = new NumberFormatInfo { NumberDecimalSeparator = "." };

            var asks = orderBookDataType.Asks.Select(ask => new OrderBookPart(double.Parse(ask[0], nfi), double.Parse(ask[1], nfi)));
            result.ReplaceAsk(asks);

            var bids = orderBookDataType.Bids.Select(bid => new OrderBookPart(double.Parse(bid[0], nfi), double.Parse(bid[1], nfi)));
            result.ReplaceBids(bids);

            return result;
        }
    }
}
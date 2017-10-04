using System;
using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel
{
    public interface IMarketInfo
    {
        IEnumerable<PairOfMarket> Pairs(Market market);

        /// <summary>
        /// Returns the list of currencies traded on the exchange
        /// </summary>
        IEnumerable<CurrencyOfMarket> Currencies(Market market);

        /// <summary>
        /// Returns the current quotation of the currency pair
        /// </summary>
        /// <param name="pair">Сurrency pair</param>
        Tick Tick(Pair pair);

        /// <summary>
        /// Returns the orderbook of the currency pair
        /// </summary>
        /// <param name="pair">Сurrency pair</param>
        /// <param name="orderBookType">Displayed part of the orderbook </param>
        /// <param name="depth">The depth of orderbook</param>
        OrderBook OrderBook(Pair pair, int depth = 10, OrderBookType orderBookType = OrderBookType.Both);

        ICollection<Pair24HoursStatistic> Pairs24HoursStatistic();

        Pair24HoursStatistic Pair24HoursStatistic(Pair pair);

        IEnumerable<MarketHistory> MarketTradeHistory(Pair pair, TimeRange timeRange);

        IEnumerable<HistoryPrice> MarketHistoryData(Pair pair, TimeframeType timeframe, TimeRange timeRange);
        IEnumerable<HistoryPrice> MarketHistoryData(Pair pair, TimeframeType timeframe, DateTime startTime);
        IEnumerable<HistoryPrice> MarketHistoryData(Pair pair, TimeframeType timeframe);
    }
}
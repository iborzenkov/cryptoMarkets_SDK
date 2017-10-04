using DomainModel.Features;
using System;

namespace DomainModel.MarketModel.Updaters.HistoryPrices
{
    public struct HistoryPriceFeature
    {
        public HistoryPriceFeature(PairOfMarket pair, TimeframeType timeframe, DateTime startTime) : this(pair, timeframe)
        {
            StartTime = startTime;
        }

        public HistoryPriceFeature(PairOfMarket pair, TimeframeType timeframe)
        {
            Pair = pair;
            Timeframe = timeframe;
            StartTime = null;
        }

        public PairOfMarket Pair { get; }
        public DateTime? StartTime { get; } 
        public TimeframeType Timeframe { get; }
    }
}
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

        public HistoryPriceFeature(PairOfMarket pair, TimeframeType timeframe, int barCount) : this(pair, timeframe)
        {
            var minutes = timeframe.ToMinutes()*barCount;
            StartTime = DateTime.Now.Subtract(new TimeSpan(0, minutes, 0));
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

        public static bool operator ==(HistoryPriceFeature c1, HistoryPriceFeature c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(HistoryPriceFeature c1, HistoryPriceFeature c2)
        {
            return !c1.Equals(c2);
        }

        public bool Equals(HistoryPriceFeature other)
        {
            return Equals(Pair, other.Pair) && StartTime.Equals(other.StartTime) && Timeframe == other.Timeframe;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is HistoryPriceFeature && Equals((HistoryPriceFeature)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Pair?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ StartTime.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Timeframe;
                return hashCode;
            }
        }
    }
}
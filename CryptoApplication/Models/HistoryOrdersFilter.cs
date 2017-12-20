using DomainModel;
using DomainModel.Features;

namespace Models
{
    public class HistoryOrdersFilter
    {
        public TradePosition? Position { get; }
        public Market Market { get; }
        public Pair Pair { get; }
        public Period? Period { get; }

        public HistoryOrdersFilter() : this(null, null, null, null)
        {
            
        }

        public HistoryOrdersFilter(Market market, Pair pair, TradePosition? position, Period? period)
        {
            Position = position;
            Market = market;
            Pair = pair;
            Period = period;
        }
    }
}
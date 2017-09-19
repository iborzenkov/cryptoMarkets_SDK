using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public class OrderBookUpdaterParameters
    {
        public int Depth { get; set; }
        public OrderBookType OrderBookType { get; set; }

        public OrderBookUpdaterParameters(int depth, OrderBookType orderBookType)
        {
            Depth = depth;
            OrderBookType = orderBookType;
        }
    }

    internal class OrderBookUpdater : Updater<IOrderBook, PairOfMarket>
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly IMarketInfo _marketInfo;

        public OrderBookUpdater(PairOfMarket pair, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = pair;
            _marketInfo = OwnerFeature.Market.Model.Info;
        }

        public int Depth => ((OrderBookUpdaterParameters)Parameters).Depth;
        public OrderBookType OrderBookType => ((OrderBookUpdaterParameters)Parameters).OrderBookType;

        protected override IOrderBook UpdateFeature()
        {
            var result = _marketInfo.OrderBook(OwnerFeature.Pair, Depth, OrderBookType);
            OnChanged(result);
            return result;
        }
    }
}
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public interface IOrderBookUpdaterProvider
    {
        IOrderBookUpdater OrderBookUpdater(PairOfMarket pair);

        void ReleaseUpdater(IOrderBookUpdater orderBookUpdater);
    }
}
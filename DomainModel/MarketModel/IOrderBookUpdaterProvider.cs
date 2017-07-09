using DomainModel.Features;

namespace DomainModel.MarketModel
{
    public interface IOrderBookUpdaterProvider
    {
        IOrderBookUpdater OrderBookUpdater(PairOfMarket pair);
    }
}
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public interface IOrderBookUpdaterProvider : IUpdaterProvider<IOrderBook, PairOfMarket>
    {
    }
}
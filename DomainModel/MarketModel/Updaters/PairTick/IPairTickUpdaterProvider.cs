using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    public interface IPairTickUpdaterProvider : IUpdaterProvider<Tick, PairOfMarket>
    {
    }
}
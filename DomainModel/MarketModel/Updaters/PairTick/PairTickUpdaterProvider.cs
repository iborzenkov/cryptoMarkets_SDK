using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    internal class PairTickUpdaterProvider : UpdaterProvider<Tick, PairOfMarket>, IPairTickUpdaterProvider
    {
        protected override Updater<Tick, PairOfMarket> MakeUpdater(PairOfMarket owner)
        {
            return new PairTickUpdater(owner);
        }
    }
}
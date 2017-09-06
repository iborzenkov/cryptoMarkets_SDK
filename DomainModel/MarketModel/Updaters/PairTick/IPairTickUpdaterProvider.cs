using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    public interface IPairTickUpdaterProvider
    {
        IPairTickUpdater PairTickUpdater(PairOfMarket pair, RefreshInterval refreshInterval);

        void ReleaseUpdater(IPairTickUpdater updater);
    }
}
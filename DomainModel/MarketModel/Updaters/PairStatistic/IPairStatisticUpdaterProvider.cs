using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    public interface IPairStatisticUpdaterProvider
    {
        IPairStatisticUpdater PairStatisticUpdater(Market market);

        void ReleaseUpdater(IPairStatisticUpdater updater);
    }
}
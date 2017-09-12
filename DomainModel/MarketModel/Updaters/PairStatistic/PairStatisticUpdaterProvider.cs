using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    internal class PairStatisticUpdaterProvider : UpdaterProvider<ICollection<Features.PairStatistic>, Market>, IPairStatisticUpdaterProvider
    {
        protected override Updater<ICollection<Features.PairStatistic>, Market> MakeUpdater(Market owner)
        {
            return new PairStatisticUpdater(owner);
        }
    }
}
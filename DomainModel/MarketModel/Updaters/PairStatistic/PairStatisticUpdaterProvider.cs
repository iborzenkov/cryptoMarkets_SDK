using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    internal class PairStatisticUpdaterProvider : UpdaterProvider<ICollection<Pair24HoursStatistic>, Market>, IPairStatisticUpdaterProvider
    {
        protected override Updater<ICollection<Pair24HoursStatistic>, Market> MakeUpdater(Market owner)
        {
            return new PairStatisticUpdater(owner);
        }
    }
}
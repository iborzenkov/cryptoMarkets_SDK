using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    public interface IPairStatisticUpdaterProvider : IUpdaterProvider<ICollection<Pair24HoursStatistic>, Market>
    {
    }
}
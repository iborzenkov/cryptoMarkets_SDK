using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    public interface IPairStatisticUpdaterProvider : IUpdaterProvider<ICollection<Features.Pair24HoursStatistic>, Market>
    {
    }
}
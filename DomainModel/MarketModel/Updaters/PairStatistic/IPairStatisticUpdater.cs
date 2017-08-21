using System;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    public interface IPairStatisticUpdater
    {
        int RefreshInterval { get; set; }

        void Start();
        void Stop();

        ICollection<Features.PairStatistic> LastPairsStatistic { get; }

        event EventHandler<IEnumerable<Features.PairStatistic>> Changed;
    }
}
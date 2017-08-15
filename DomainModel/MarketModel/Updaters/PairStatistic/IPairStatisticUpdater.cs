using System;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    public interface IPairStatisticUpdater
    {
        int RefreshInterval { get; set; }

        void Start();
        void Stop();

        event EventHandler<IEnumerable<Features.PairStatistic>> Changed;
    }
}
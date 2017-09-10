using DomainModel.Features;
using System;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    public interface IPairTickUpdater
    {
        int RefreshInterval { get; set; }
        //RefreshInterval RefreshInterval { get; }

        void Start();

        void Stop();

        Tick LastPairTick { get; }

        PairOfMarket Pair { get; }

        event Action<Tick> Changed;
    }
}
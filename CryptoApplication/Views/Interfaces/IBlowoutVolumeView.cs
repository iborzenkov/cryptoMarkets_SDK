using System;
using System.Collections.Generic;
using DomainModel.Features;
using Models;

namespace Views.Interfaces
{
    public interface IBlowoutVolumeView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);
        void SetPairs(IEnumerable<PairOfMarket> pairs);

        event Action<Market> MarketChanged;

        event Action<PairOfMarket,bool> PairChecked;

        event Action<BlowoutVolumeSettings> SettingsChanged;
        void SetSettings(BlowoutVolumeSettings settings);
    }
}
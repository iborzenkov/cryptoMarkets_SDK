using System;
using System.Collections.Generic;
using DomainModel;
using DomainModel.Features;

namespace Models.Interfaces
{
    public interface IBlowoutVolumeModel
    {
        IEnumerable<Market> Markets { get; }

        BlowoutVolumeSettings Settings { get; set; }

        void Release();

        event Action<PairOfMarket> SignalOccured;
        event Action<PairOfMarket> SignalDisappeared;

        //IEnumerable<PairOfMarket> ActivePairs { get; }

        void IncludePairToStrategy(PairOfMarket pair, TimeframeType timeframe, int barCount);
        void ExcludePairFromStrategy(PairOfMarket pair, TimeframeType timeframe, int barCount);
    }
}
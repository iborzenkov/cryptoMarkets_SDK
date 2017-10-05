using DomainModel;
using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface ICandlestickModel
    {
        IEnumerable<Market> Markets { get; }

        TimeframeType? Timeframe { get; set; }

        int BarCount{ get; set; }

        event Action<IEnumerable<HistoryPrice>> GraphChanged;

        void NeedGraphOf(PairOfMarket pair);

        void Release();
    }
}
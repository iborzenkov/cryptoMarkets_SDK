using DomainModel;
using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public interface ICandlestickView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetPairs(IEnumerable<PairOfMarket> pairs);

        void SetPrices(IEnumerable<HistoryPrice> prices);

        TimeframeType Timeframe { get; set; }

        void ClearGraph();

        event Action<Market> MarketChanged;

        event Action<PairOfMarket> PairChanged;

        event Action<TimeframeType> TimeframeChanged;
    }
}
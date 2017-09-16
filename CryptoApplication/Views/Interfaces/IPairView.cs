using DomainModel.Features;
using System;
using System.Collections.Generic;
using Models;

namespace Views.Interfaces
{
    public interface IPairView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetPairs(IEnumerable<PairOfMarket> pairs);

        void SetStatistics(IEnumerable<PairStatistic> statistics);

        void InitFilter();

        event Action<Market> MarketChanged;

        event Action<PairViewFilter> FilterChanged;
    }
}
using DomainModel.Features;
using System;
using System.Collections.Generic;
using Models;

namespace Views.Interfaces
{
    public interface IPairView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        Market Market { get; set; }

        void SetPairs(IEnumerable<PairOfMarket> pairs);

        void SetStatistics(IEnumerable<PairStatistic> statistics);

        event EventHandler<Market> MarketChanged;

        event EventHandler<PairViewFilter> FilterChanged;
        void InitFilter();
    }
}
using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IPairModel
    {
        IEnumerable<Market> Markets { get; }
        Market SelectedMarket { get; set; }

        void SetFilter(PairViewFilter filter);

        void Release();

        event EventHandler<IEnumerable<PairStatistic>> StatisticsChanged;

        event EventHandler<IEnumerable<PairOfMarket>> PairsChanged;
    }
}
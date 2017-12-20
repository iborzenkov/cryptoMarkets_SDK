using System;
using DomainModel.Features;
using System.Collections.Generic;
using DomainModel;

namespace Models.Interfaces
{
    public interface ITradingHistoryModel
    {
        IEnumerable<Market> Markets { get; }

        IEnumerable<Pair> Pairs { get; }

        HistoryOrdersFilter Filter { get; set; }

        double? GetUsdRateChanged(Currency currency);

        event Action<IEnumerable<HistoryOrder>> HistoryOrdersChanged;

        void Release();
    }
}
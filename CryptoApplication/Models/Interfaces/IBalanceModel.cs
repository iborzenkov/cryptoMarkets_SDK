using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IBalanceModel
    {
        IEnumerable<Market> Markets { get; }
        Market SelectedMarket { get; set; }

        void SetFilter(string filter);

        double? GetUsdRateChanged(Currency currency);

        void Refresh();

        event Action<IEnumerable<Balance>> BalancesChanged;
    }
}
using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public delegate double? GetUsdRateDelegate(Currency currency);

    public interface IBalanceView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        Market Market { get; set; }

        void SetBalances(IEnumerable<Balance> balances);

        void SetUsdRate(GetUsdRateDelegate getUsdRate);

        event Action<Market> MarketChanged;

        event Action<string> FilterChanged;

        event Action ClearFilter;

        event Action RefreshBalances;
    }
}
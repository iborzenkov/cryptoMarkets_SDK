using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public interface IBalanceView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        Market Market { get; set; }

        void SetBalances(IEnumerable<Balance> balances);

        event EventHandler<Market> MarketChanged;

        event EventHandler<CurrencyOfMarket> CurrencyChanged;

        event EventHandler<string> FilterChanged;

        event Action ClearFilter;

        event Action RefreshBalances;
    }
}
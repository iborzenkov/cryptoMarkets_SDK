using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public interface ICurrencyView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetCurrencies(IEnumerable<CurrencyOfMarket> currencies);

        event Action<Market> MarketChanged;

        event Action<string> FilterChanged;

        event Action<bool> ActiveOnlyChanged;

        event Action ClearFilter;
        void InitFilter();
    }
}
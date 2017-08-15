using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public interface ICurrencyView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        Market Market { get; set; }

        void SetCurrencies(IEnumerable<CurrencyOfMarket> currencies);

        event EventHandler<Market> MarketChanged;

        event EventHandler<string> FilterChanged;

        event EventHandler<bool> ActiveOnlyChanged;

        event Action ClearFilter;
        void InitFilter();
    }
}
using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface ICurrencyModel
    {
        IEnumerable<Market> Markets { get; }
        Market SelectedMarket { get; set; }

        void SetFilter(string filter, bool activeOnly);

        event EventHandler<IEnumerable<CurrencyOfMarket>> CurrenciesChanged;
    }
}
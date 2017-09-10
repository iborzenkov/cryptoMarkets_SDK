using DomainModel.Features;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class CurrencyModel : ICurrencyModel
    {
        private readonly IModel _domainModel;
        private Market _selectedMarket;

        public CurrencyModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        Market ICurrencyModel.SelectedMarket
        {
            get { return _selectedMarket; }
            set
            {
                if (_selectedMarket == value)
                    return;

                _selectedMarket = value;
                //OnCurrenciesChanged(_selectedMarket?.Currencies);
            }
        }

        IEnumerable<Market> ICurrencyModel.Markets => _domainModel.Markets;

        void ICurrencyModel.SetFilter(string filter, bool activeOnly)
        {
            ICurrencyModel model = this;
            if (model.SelectedMarket == null)
            {
                OnCurrenciesChanged(null);
                return;
            }

            var allCurrencies = model.SelectedMarket.Currencies;
            var filtered = activeOnly ? allCurrencies.Where(c => c.IsActive) : allCurrencies;
            filtered = string.IsNullOrEmpty(filter)
                ? filtered
                : filtered.Where(c =>
                    c.Currency.LongName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    c.Currency.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            OnCurrenciesChanged(filtered);
        }

        public event Action<IEnumerable<CurrencyOfMarket>> CurrenciesChanged;

        private void OnCurrenciesChanged(IEnumerable<CurrencyOfMarket> currencies)
        {
            CurrenciesChanged?.Invoke(currencies);
        }
    }
}
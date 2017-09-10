using DomainModel.Features;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class BalanceModel : IBalanceModel
    {
        private readonly IModel _domainModel;
        private Market _selectedMarket;

        public BalanceModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        public Market SelectedMarket
        {
            get { return _selectedMarket; }
            set
            {
                if (_selectedMarket == value)
                    return;

                _selectedMarket = value;
                OnBalancesChanged(_selectedMarket?.Balances);
            }
        }

        IEnumerable<Market> IBalanceModel.Markets => _domainModel.Markets;

        void IBalanceModel.SetFilter(string filter)
        {
            var model = this as IBalanceModel;
            if (model.SelectedMarket == null)
            {
                OnBalancesChanged(null);
                return;
            }

            var balances = model.SelectedMarket.Balances;
            var filtered = string.IsNullOrEmpty(filter)
                ? balances
                : balances.Where(b =>
                    b.Currency.LongName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    b.Currency.Name.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0);
            OnBalancesChanged(filtered);
        }

        void IBalanceModel.Refresh()
        {
            SelectedMarket.UsdEquivalent.NeedUpdate();

            OnBalancesChanged(_selectedMarket?.Balances);
        }

        public event Action<IEnumerable<Balance>> BalancesChanged;

        private void OnBalancesChanged(IEnumerable<Balance> balances)
        {
            BalancesChanged?.Invoke(balances);
        }

        public double? GetUsdRateChanged(Currency currency)
        {
            return SelectedMarket.UsdEquivalent.UsdRate(currency);
        }
    }
}
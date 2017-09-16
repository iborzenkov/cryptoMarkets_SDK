using System;
using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class BalancePresenter : BasePresenter<IBalanceView>
    {
        private IBalanceModel Model { get; }

        public BalancePresenter(IBalanceView view, IBalanceModel model) : base(view)
        {
            Model = model;
            Model.BalancesChanged += Model_BalancesChanged;

            View.SetMarkets(Model.Markets);
            View.SetUsdRate(Model.GetUsdRateChanged);

            View.ViewClosed += View_ViewClosed;
            View.MarketChanged += View_MarketChanged;
            View.FilterChanged += View_FilterChanged;
            View.ClearFilter += View_ClearFilter;
            View.RefreshBalances += View_RefreshBalances;
        }

        private void Release()
        {
            View.ViewClosed -= View_ViewClosed;
            View.MarketChanged -= View_MarketChanged;
            View.FilterChanged -= View_FilterChanged;
            View.ClearFilter -= View_ClearFilter;
            View.RefreshBalances -= View_RefreshBalances;

            Model.BalancesChanged -= Model_BalancesChanged;
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private void View_RefreshBalances()
        {
            Model.Refresh();
        }

        private void View_ClearFilter()
        {
            _filter = string.Empty;
            Model.SetFilter(_filter);
        }

        private void Model_BalancesChanged(IEnumerable<Balance> balances)
        {
            View.SetBalances(balances);
        }

        private void View_FilterChanged(string filter)
        {
            _filter = filter;
            Model.SetFilter(_filter);
        }

        private string _filter;

        private async void View_MarketChanged(Market market)
        {
            await MarketChangedAsync(market);
        }

        private Task MarketChangedAsync(Market market)
        {
            return Task.Run(() =>
            {
                Model.SelectedMarket = market;
                Model.SetFilter(_filter);
            });
        }

    }
}
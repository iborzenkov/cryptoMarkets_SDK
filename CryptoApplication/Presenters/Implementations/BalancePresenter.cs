using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

            View.MarketChanged += View_MarketChanged;
            View.FilterChanged += View_FilterChanged;
            View.ClearFilter += View_ClearFilter;
            View.RefreshBalances += View_RefreshBalances;

            if (Model.Markets.Any())
                View.Market = Model.Markets.First();
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

        private void Model_BalancesChanged(object sender, IEnumerable<Balance> balances)
        {
            View.SetBalances(balances);
        }

        private void View_FilterChanged(object sender, string filter)
        {
            _filter = filter;
            Model.SetFilter(_filter);
        }

        private string _filter;

        private void View_MarketChanged(object sender, Market market)
        {
            Model.SelectedMarket = market;
            Model.SetFilter(_filter);
        }
    }
}
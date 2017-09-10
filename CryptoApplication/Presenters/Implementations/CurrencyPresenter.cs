using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class CurrencyPresenter : BasePresenter<ICurrencyView>
    {
        private ICurrencyModel Model { get; }

        public CurrencyPresenter(ICurrencyView view, ICurrencyModel model) : base(view)
        {
            Model = model;
            Model.CurrenciesChanged += Model_CurrenciesChanged;

            View.SetMarkets(Model.Markets);

            View.ViewClosed += View_ViewClosed;
            View.MarketChanged += View_MarketChanged;
            View.FilterChanged += View_FilterChanged;
            View.ActiveOnlyChanged += View_ActiveOnlyChanged;
            View.ClearFilter += View_ClearFilter;
            View.InitFilter();

            if (Model.Markets.Any())
                View.Market = Model.Markets.First();
        }

        private void Release()
        {
            View.ViewClosed -= View_ViewClosed;
            View.MarketChanged -= View_MarketChanged;
            View.FilterChanged -= View_FilterChanged;
            View.ActiveOnlyChanged -= View_ActiveOnlyChanged;
            View.ClearFilter -= View_ClearFilter;

            Model.CurrenciesChanged -= Model_CurrenciesChanged;
        }

        private void View_ClearFilter()
        {
            _filter = string.Empty;
            Model.SetFilter(_filter, _activeOnly);
        }

        private void Model_CurrenciesChanged(IEnumerable<CurrencyOfMarket> currencies)
        {
            View.SetCurrencies(currencies);
        }

        private void View_ActiveOnlyChanged(bool activeOnly)
        {
            _activeOnly = activeOnly;
            Model.SetFilter(_filter, _activeOnly);
        }

        private void View_FilterChanged(string filter)
        {
            _filter = filter;
            Model.SetFilter(_filter, _activeOnly);
        }

        private bool _activeOnly;
        private string _filter;

        private void View_MarketChanged(Market market)
        {
            Model.SelectedMarket = market;
            Model.SetFilter(_filter, _activeOnly);
        }

        private void View_ViewClosed()
        {
            Release();
        }
    }
}
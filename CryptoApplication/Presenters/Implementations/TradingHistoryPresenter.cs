using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class TradingHistoryPresenter : BasePresenter<ITradingHistoryView>
    {
        private ITradingHistoryModel Model { get; }

        public TradingHistoryPresenter(ITradingHistoryView view, ITradingHistoryModel model) : base(view)
        {
            Model = model;
            Model.HistoryOrdersChanged += Model_HistoryOrdersChanged;

            View.SetMarkets(Model.Markets);
            View.SetPairs(Model.Pairs);
            View.SetUsdRate(Model.GetUsdRateChanged);
            View.SetFilter(Model.Filter);

            View.ViewClosed += View_ViewClosed;
            View.FilterChanged += View_FilterChanged;
        }

        private void Release()
        {
            View.FilterChanged -= View_FilterChanged;
            View.ViewClosed -= View_ViewClosed;

            Model.HistoryOrdersChanged -= Model_HistoryOrdersChanged;
            Model.Release();

            OnClosed();
        }

        private void Model_HistoryOrdersChanged(IEnumerable<HistoryOrder> historyOrders)
        {
            View.SetHistoryOrders(historyOrders);
        }

        private async void View_FilterChanged(HistoryOrdersFilter filter)
        {
            await FilterChangedAsync(filter);
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private Task FilterChangedAsync(HistoryOrdersFilter filter)
        {
            return Task.Run(() =>
            {
                Model.Filter = filter;
            });
        }
    }
}
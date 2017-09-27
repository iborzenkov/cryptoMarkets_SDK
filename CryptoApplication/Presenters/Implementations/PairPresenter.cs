using DomainModel.Features;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class PairPresenter : BasePresenter<IPairView>
    {
        private IPairModel Model { get; }

        public PairPresenter(IPairView view, IPairModel model) : base(view)
        {
            Model = model;
            Model.PairsChanged += Model_PairsChanged;
            Model.StatisticsChanged += Model_StatisticsChanged;

            View.SetMarkets(Model.Markets);

            View.MarketChanged += View_MarketChanged;
            View.ViewClosed += View_ViewClosed;
            View.FilterChanged += View_FilterChanged;

            View.InitFilter();
        }

        private void Release()
        {
            View.MarketChanged -= View_MarketChanged;
            View.ViewClosed -= View_ViewClosed;
            View.FilterChanged -= View_FilterChanged;

            Model.PairsChanged -= Model_PairsChanged;
            Model.StatisticsChanged -= Model_StatisticsChanged;
            Model.Release();
        }

        private void Model_StatisticsChanged(IEnumerable<Pair24HoursStatistic> pairStatistics)
        {
            View.SetStatistics(pairStatistics);
        }

        private void Model_PairsChanged(IEnumerable<PairOfMarket> pairs)
        {
            View.SetPairs(pairs);
        }

        private void View_FilterChanged(PairViewFilter filter)
        {
            _filter = filter;
            Model.SetFilter(_filter);
        }

        private PairViewFilter _filter = new PairViewFilter
        {
            DailyChange = DailyChangePairEnum.All,
            IsActiveOnly = false,
            PairToken = string.Empty
        };

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

        private void View_ViewClosed()
        {
            Release();
        }
    }
}
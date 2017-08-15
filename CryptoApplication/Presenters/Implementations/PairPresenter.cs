using DomainModel.Features;
using Models;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

            if (Model.Markets.Any())
                View.Market = Model.Markets.First();
        }

        private void Model_StatisticsChanged(object sender, IEnumerable<PairStatistic> pairStatistics)
        {
            View.SetStatistics(pairStatistics);
        }

        private void Model_PairsChanged(object sender, IEnumerable<PairOfMarket> pairs)
        {
            View.SetPairs(pairs);
        }

        private void View_FilterChanged(object sender, PairViewFilter filter)
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

        private void View_MarketChanged(object sender, Market market)
        {
            Model.SelectedMarket = market;
            Model.SetFilter(_filter);
        }

        private void View_ViewClosed(object sender, EventArgs eventArgs)
        {
            Release();
        }

        private void Release()
        {
            Model.PairsChanged -= Model_PairsChanged;
            Model.Release();
        }
    }
}
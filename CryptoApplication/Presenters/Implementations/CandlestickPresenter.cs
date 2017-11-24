using DomainModel;
using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class CandlestickPresenter : BasePresenter<ICandlestickView>
    {
        private ICandlestickModel Model { get; }

        public CandlestickPresenter(ICandlestickView view, ICandlestickModel model) : base(view)
        {
            Model = model;
            Model.GraphChanged += Model_GraphChanged;

            View.SetMarkets(Model.Markets);
            View.Timeframe = Model.Timeframe;
            View.BarCount = Model.BarCount;

            View.ViewClosed += View_ViewClosed;
            View.MarketChanged += View_MarketChanged;
            View.PairChanged += View_PairChanged;
            View.TimeframeChanged += View_TimeframeChanged;
            View.BarCountChanged += View_BarCountChanged;
        }

        private async void View_BarCountChanged(int barCount)
        {
            View.ClearGraph();
            await BarCountChangedAsync(barCount);
        }

        private async void View_TimeframeChanged(TimeframeType? timeframe)
        {
            View.ClearGraph();
            await TimeframeChangedAsync(timeframe);
        }

        private Task TimeframeChangedAsync(TimeframeType? timeframe)
        {
            Model.Timeframe = timeframe;
            return GetHistoryPricesAsync();
        }

        private Task BarCountChangedAsync(int barCount)
        {
            Model.BarCount = barCount;
            return GetHistoryPricesAsync();
        }

        private void Model_GraphChanged(IEnumerable<HistoryPrice> prices)
        {
            View.SetPrices(prices);
        }

        private void Release()
        {
            View.ViewClosed -= View_ViewClosed;
            View.MarketChanged -= View_MarketChanged;
            View.PairChanged -= View_PairChanged;
            View.TimeframeChanged -= View_TimeframeChanged;
            View.BarCountChanged -= View_BarCountChanged;

            Model.GraphChanged -= Model_GraphChanged;
            Model.Release();

            OnClosed();
        }

        private async void View_PairChanged(PairOfMarket pair)
        {
            View.ClearGraph();
            await PairChangedAsync(pair);
        }

        private PairOfMarket _pair;

        private Task PairChangedAsync(PairOfMarket pair)
        {
            _pair = pair;
            return GetHistoryPricesAsync();
        }

        private Task GetHistoryPricesAsync()
        {
            return Task.Run(() =>
            {
                Model.NeedGraphOf(_pair);
            });
        }

        private async void View_MarketChanged(Market market)
        {
            View.ClearGraph();
            await MarketChangedAsync(market);
        }

        private Task MarketChangedAsync(Market market)
        {
            return Task.Run(() =>
            {
                //Model.SelectedMarket = market;
                var pairs = market.Pairs;
                var pairOfMarkets = pairs as PairOfMarket[] ?? pairs.ToArray();
                View.SetPairs(pairOfMarkets);
                View.SetTimeframes(market.PossibleTimeframes);
            });
        }

        private void View_ViewClosed()
        {
            Release();
        }
    }
}
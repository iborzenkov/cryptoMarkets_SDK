using System;
using DomainModel;
using DomainModel.Features;
using Models;
using Models.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class BlowoutVolumePresenter : BasePresenter<IBlowoutVolumeView>
    {
        private IBlowoutVolumeModel Model { get; }

        public BlowoutVolumePresenter(IBlowoutVolumeView view, IBlowoutVolumeModel model) : base(view)
        {
            Model = model;

            View.SetMarkets(Model.Markets);
            View.SetSettings(Model.Settings);

            View.MarketChanged += View_MarketChanged;
            View.AddPairToAnalise += View_AddPairToAnalise;
            View.RemovePairFromAnalise += View_RemovePairFromAnalise;
            View.SettingsChanged += View_SettingsChanged;
            View.ViewClosed += View_ViewClosed;


            Model.SignalOccured += Model_SignalOccured;
            Model.SignalDisappeared += Model_SignalDisappeared;
        }

        private async void View_RemovePairFromAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            await ExcludePairToStrategy(pair, timeframe, barCount);
        }

        private async void View_AddPairToAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            await IncludePairToStrategy(pair, timeframe, barCount);
        }

        private void Model_SignalDisappeared(PairOfMarket pair)
        {
            View.SignalDisappeared(pair);
        }

        private void Model_SignalOccured(PairOfMarket pair)
        {
            View.SignalOccured(pair);
        }

        private void Release()
        {
            Model.SignalOccured -= Model_SignalOccured;
            Model.SignalDisappeared -= Model_SignalDisappeared;

            View.MarketChanged -= View_MarketChanged;
            View.AddPairToAnalise -= View_AddPairToAnalise;
            View.RemovePairFromAnalise -= View_RemovePairFromAnalise;
            View.SettingsChanged -= View_SettingsChanged;
            View.ViewClosed -= View_ViewClosed;

            Model.Release();

            OnClosed();
        }

        private void View_SettingsChanged(BlowoutVolumeSettings settings)
        {
            Model.Settings = settings;
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private Task IncludePairToStrategy(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            return Task.Run(() =>
            {
                Model.IncludePairToStrategy(pair, timeframe, barCount);
            });
        }

        private Task ExcludePairToStrategy(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            return Task.Run(() =>
            {
                Model.ExcludePairFromStrategy(pair, timeframe, barCount);
            });
        }

        private async void View_MarketChanged(Market market)
        {
            await MarketChangedAsync(market);
        }

        private Task MarketChangedAsync(Market market)
        {
            return Task.Run(() =>
            {
                var pairs = market.Pairs.ActiveOnly();
                var pairOfMarkets = pairs as PairOfMarket[] ?? pairs.ToArray();
                View.SetPairs(pairOfMarkets);
                View.SetTimeframes(market.PossibleTimeframes);
            });
        }
    }
}
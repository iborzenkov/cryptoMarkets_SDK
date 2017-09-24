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
            View.PairChecked += View_PairChecked;
            View.SettingsChanged += View_SettingsChanged;
            View.ViewClosed += View_ViewClosed;
        }

        private void Release()
        {
            View.MarketChanged -= View_MarketChanged;
            View.PairChecked -= View_PairChecked;
            View.SettingsChanged -= View_SettingsChanged;
            View.ViewClosed -= View_ViewClosed;

            Model.Release();
        }

        private void View_SettingsChanged(BlowoutVolumeSettings settings)
        {
            Model.Settings = settings;
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private async void View_PairChecked(PairOfMarket pair, bool isChecked)
        {
            await PairChangedAsync(pair, isChecked);
        }

        private Task PairChangedAsync(PairOfMarket pair, bool isChecked)
        {
            return Task.Run(() =>
            {
                if (isChecked)
                    Model.IncludePairToStrategy(pair);
                else
                    Model.ExcludePairFromStrategy(pair);
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
                var pairs = market.Pairs;
                var pairOfMarkets = pairs as PairOfMarket[] ?? pairs.ToArray();
                View.SetPairs(pairOfMarkets);
            });
        }
    }
}
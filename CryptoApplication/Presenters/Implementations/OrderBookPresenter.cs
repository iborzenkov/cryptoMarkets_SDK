using DomainModel.Features;
using DomainModel.MarketModel;
using Models;
using Models.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class OrderBookPresenter : BasePresenter<IOrderBookView>
    {
        private IOrderBookModel Model { get; }

        public OrderBookPresenter(IOrderBookView view, IOrderBookModel model) : base(view)
        {
            Model = model;
            Model.OrderBookChanged += Model_OrderBookChanged;
            Model.UsdRateChanged += Model_UsdRateChanged;

            View.SetMarkets(Model.Markets);
            View.SetSettings(Model.Settings);

            View.MarketChanged += View_MarketChanged;
            View.PairChanged += View_PairChanged;
            View.SettingsChanged += View_SettingsChanged;
            View.ViewClosed += View_ViewClosed;
        }

        private void Model_UsdRateChanged(double? usdRate)
        {
            View.SetUsdRate(usdRate);
        }

        private void Release()
        {
            View.MarketChanged -= View_MarketChanged;
            View.PairChanged -= View_PairChanged;
            View.SettingsChanged -= View_SettingsChanged;
            View.ViewClosed -= View_ViewClosed;

            Model.OrderBookChanged -= Model_OrderBookChanged;
            Model.Release();
        }

        private void View_SettingsChanged(OrderBookSettings settings)
        {
            Model.Settings = settings;
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private void Model_OrderBookChanged(IOrderBook orderBook)
        {
            View.SetOrderBook(orderBook);
        }

        private async void View_PairChanged(PairOfMarket pair)
        {
            View.ClearOrderBooks();
            await PairChangedAsync(pair);
        }

        private Task PairChangedAsync(PairOfMarket pair)
        {
            return Task.Run(() =>
            {
                Model.NeedOrderBookOf(pair);
            });
        }

        private async void View_MarketChanged(Market market)
        {
            View.ClearOrderBooks();
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
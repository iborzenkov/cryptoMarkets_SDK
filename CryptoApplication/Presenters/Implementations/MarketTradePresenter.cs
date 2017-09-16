using DomainModel.Features;
using Models.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class MarketTradePresenter : BasePresenter<IMarketTradeView>
    {
        private IMarketTradeModel Model { get; }

        public MarketTradePresenter(IMarketTradeView view, IMarketTradeModel model) : base(view)
        {
            Model = model;
            //Model.TradeChanged += Model_TradeChanged;

            View.SetMarkets(Model.Markets);

            View.MarketChanged += View_MarketChanged;
            View.PairChanged += View_PairChanged;
            View.ViewClosed += View_ViewClosed;
        }

        private void Release()
        {
            View.MarketChanged -= View_MarketChanged;
            View.PairChanged -= View_PairChanged;
            View.ViewClosed -= View_ViewClosed;

            //Model.TradeChanged -= Model_TradeChanged;
            //Model.Release();
        }

        private void View_ViewClosed()
        {
            Release();
        }

        /*private void Model_TradeChanged(object sender, ITrade trade)
        {
            //View.SetTrade(trade);
        }*/

        private async void View_PairChanged(PairOfMarket pair)
        {
            await PairChangedAsync(pair);
        }

        private Task PairChangedAsync(PairOfMarket pair)
        {
            return null;
            /*return Task.Run(() =>
            {
                Model.PairChanged(pair);
            });*/
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

                //Model.MarketChanged(market);
            });
        }
    }
}
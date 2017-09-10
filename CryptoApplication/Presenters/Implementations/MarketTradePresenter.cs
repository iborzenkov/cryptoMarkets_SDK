using DomainModel.Features;
using Models.Interfaces;
using System;
using System.Linq;
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

            if (Model.Markets.Any())
                View.Market = Model.Markets.First();
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

        private void View_PairChanged(PairOfMarket pair)
        {
            //Model.NeedTradeOf(View.Pair);
        }

        private void View_MarketChanged(Market market)
        {
            var selectedPair = View.Pair;

            var pairs = market.Pairs;
            var pairOfMarkets = pairs as PairOfMarket[] ?? pairs.ToArray();
            View.SetPairs(pairOfMarkets);

            if (selectedPair != null)
                View.Pair = pairOfMarkets.FirstOrDefault(pairOfMarket => pairOfMarket.Pair.Equals(selectedPair.Pair));
        }
    }
}
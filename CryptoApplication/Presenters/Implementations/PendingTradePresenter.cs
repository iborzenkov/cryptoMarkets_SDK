using DomainModel.Features;
using Models.Interfaces;
using System;
using System.Linq;
using DomainModel;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class PendingTradePresenter : BasePresenter<IPendingTradeView>
    {
        private IPendingTradeModel Model { get; }

        public PendingTradePresenter(IPendingTradeView view, IPendingTradeModel model) : base(view)
        {
            Model = model;
            //Model.TradeChanged += Model_TradeChanged;

            View.SetMarkets(Model.Markets);

            View.MarketChanged += View_MarketChanged;
            View.PairChanged += View_PairChanged;
            View.ViewClosed += View_ViewClosed;
            View.Trade += View_Trade;
            View.TradeParamsChanged += View_TradeParamsChanged;
            View.RemoveOrder += View_RemoveOrder;

            if (Model.Markets.Any())
                View.Market = Model.Markets.First();

            //View.SetOpenedOrders(Model.OpenedOrders);
        }

        private void View_RemoveOrder(OrderId id)
        {
            throw new NotImplementedException();
        }

        private void View_TradeParamsChanged(PendingTradeParams pendingTradeParams)
        {
            throw new NotImplementedException();
        }

        private void View_Trade(PendingTradeParams pendingTradeParams)
        {
            throw new NotImplementedException();
        }

        private void Release()
        {
            View.TradeParamsChanged -= View_TradeParamsChanged;
            View.Trade -= View_Trade;
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
            var available = Model.Available(View.Position == TradePosition.Buy ? pair.Pair.BaseCurrency : pair.Pair.QuoteCurrency);
            View.SetBalanceInfo(available);

            var price = Model.Price(View.Position == TradePosition.Buy ? pair.Pair.QuoteCurrency : pair.Pair.BaseCurrency);
            View.SetPriceInfo(price);
            
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

            //View.SetOpenedOrders(Model.OpenedOrders(market));
        }
    }
}
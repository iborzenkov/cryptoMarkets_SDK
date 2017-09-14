using System;
using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class PendingTradePresenter : BasePresenter<IPendingTradeView>
    {
        private IPendingTradeModel Model { get; }

        public PendingTradePresenter(IPendingTradeView view, IPendingTradeModel model) : base(view)
        {
            Model = model;
            Model.BalanceChanged += Model_BalanceChanged;
            Model.OpenedOrdersChanged += Model_OpenedOrdersChanged;
            Model.TickChanged += Model_TickChanged;
            Model.ErrorOccured += Model_ErrorOccured;
            Model.IsMayTradeChanged += Model_IsMayTradeChanged;

            View.SetMarkets(Model.Markets);
            View.Position = Model.Position;

            View.MarketChanged += View_MarketChanged;
            View.PairChanged += View_PairChanged;
            View.ViewClosed += View_ViewClosed;
            View.Trade += View_Trade;
            View.TradeParamsChanged += View_TradeParamsChanged;
            View.RemoveOrder += View_RemoveOrder;

            if (Model.Markets.Any())
                View.Market = Model.Markets.First();
        }

        private void Model_ErrorOccured(string errorMessage)
        {
            View.SetInfoMessage(errorMessage);
        }

        private void Release()
        {
            View.TradeParamsChanged -= View_TradeParamsChanged;
            View.Trade -= View_Trade;
            View.MarketChanged -= View_MarketChanged;
            View.PairChanged -= View_PairChanged;
            View.ViewClosed -= View_ViewClosed;
            View.RemoveOrder -= View_RemoveOrder;

            Model.BalanceChanged -= Model_BalanceChanged;
            Model.OpenedOrdersChanged -= Model_OpenedOrdersChanged;
            Model.TickChanged -= Model_TickChanged;
            Model.ErrorOccured -= Model_ErrorOccured;
            Model.IsMayTradeChanged -= Model_IsMayTradeChanged;

            Model.Release();
        }

        private void Model_IsMayTradeChanged(bool isMayTradeChanged)
        {
            View.SetIsMayTrade(isMayTradeChanged);
        }

        private void Model_TickChanged(Tick tick)
        {
            View.SetPriceInfo(tick.Last);
        }

        private void Model_OpenedOrdersChanged(IEnumerable<Order> openedOrders)
        {
            View.SetOpenedOrders(openedOrders);
        }

        private void Model_BalanceChanged(Balance balance)
        {
            View.SetBalanceInfo(balance.Available);
        }

        private void View_RemoveOrder(OrderId id)
        {
            Model.RemoveOrder(id);
        }

        private void View_TradeParamsChanged(PendingTradeParams pendingTradeParams)
        {
            Model.Position = pendingTradeParams.Position;
            Model.Quantity = pendingTradeParams.Quantity;
            Model.Price = pendingTradeParams.Price;
        }

        private void View_Trade()
        {
            var id = Model.Trade();

            if (id != null)
                View.SelectOpenedOrder(id);
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private void View_PairChanged(PairOfMarket pair)
        {
            Model.PairChanged(pair);
        }

        private void View_MarketChanged(Market market)
        {
            var selectedPair = View.Pair;

            var pairs = market.Pairs;
            var pairOfMarkets = pairs as PairOfMarket[] ?? pairs.ToArray();
            View.SetPairs(pairOfMarkets);

            if (selectedPair != null)
                View.Pair = pairOfMarkets.FirstOrDefault(pairOfMarket => pairOfMarket.Pair.Equals(selectedPair.Pair));

            Model.MarketChanged(market);
        }
    }
}
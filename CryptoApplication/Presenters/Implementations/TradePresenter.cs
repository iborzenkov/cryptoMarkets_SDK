using DomainModel.Features;
using Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class TradePresenter : BasePresenter<ITradeView>
    {
        private ITradeModel Model { get; }

        public TradePresenter(ITradeView view, ITradeModel model) : base(view)
        {
            Model = model;
            Model.BalanceChanged += Model_BalanceChanged;
            Model.OpenedOrdersChanged += Model_OpenedOrdersChanged;
            Model.TickChanged += Model_TickChanged;
            Model.ErrorOccured += Model_ErrorOccured;
            Model.InfoOccured += Model_InfoOccured;
            Model.IsMayTradeChanged += Model_IsMayTradeChanged;

            View.SetMarkets(Model.Markets);
            View.Position = Model.Position;
            View.PriceType = Model.PriceType;
            View.QuantityType = Model.QuantityType;
            View.SetUsdRate(Model.GetUsdRateChanged);

            View.MarketChanged += View_MarketChanged;
            View.PairChanged += View_PairChanged;
            View.ViewClosed += View_ViewClosed;
            View.Trade += View_Trade;
            View.TradeParamsChanged += View_TradeParamsChanged;
            View.RemoveOrder += View_RemoveOrder;
        }

        private void Model_ErrorOccured(string errorMessage)
        {
            View.SetErrorMessage(errorMessage);
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
            Model.InfoOccured -= Model_InfoOccured;
            Model.IsMayTradeChanged -= Model_IsMayTradeChanged;

            Model.Release();
        }

        private void Model_InfoOccured(string infoMessage)
        {
            View.SetInfoMessage(infoMessage);
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
            Model.PriceType = pendingTradeParams.PriceType;
            Model.Position = pendingTradeParams.Position;
            Model.Quantity = pendingTradeParams.Quantity;
            Model.Price = pendingTradeParams.Price;
            Model.QuantityType = pendingTradeParams.QuantityType;
        }

        private void View_Trade()
        {
            var id = Model.Trade();

            if (id != null)
            {
                View.SelectOpenedOrder(id);
            }
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private async void View_PairChanged(PairOfMarket pair)
        {
            await PairChangedAsync(pair);
        }

        private Task PairChangedAsync(PairOfMarket pair)
        {
            return Task.Run(() =>
            {
                Model.PairChanged(pair);
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

                Model.MarketChanged(market);
            });
        }
    }
}
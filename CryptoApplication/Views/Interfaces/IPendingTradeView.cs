using DomainModel;
using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public class PendingTradeParams
    {
        public TradePosition Position { get; }
        public double Quantity { get; }
        public double Price { get; }

        public PendingTradeParams(TradePosition position, double quantity, double price)
        {
            Position = position;
            Quantity = quantity;
            Price = price;
        }
    }

    public interface IPendingTradeView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetPairs(IEnumerable<PairOfMarket> pairs);

        void SetOpenedOrders(IEnumerable<Order> orders);

        TradePosition Position { set; }

        void SetIsMayTrade(bool value);

        void SetInfoMessage(string message);

        void SetErrorMessage(string errorMessage);

        void SetBalanceInfo(double availableQuantity);

        void SetPriceInfo(double currentPrice);

        void SelectOpenedOrder(OrderId id);

        event Action<Market> MarketChanged;

        event Action<PairOfMarket> PairChanged;

        event Action<PendingTradeParams> TradeParamsChanged;

        event Action Trade;

        event Action<OrderId> RemoveOrder;
    }
}
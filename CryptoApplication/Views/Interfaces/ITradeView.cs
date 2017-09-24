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
        public PriceTypeEnum PriceType { get; }
        public QuantityTypeEnum QuantityType { get; }

        public PendingTradeParams(TradePosition position, double quantity, double price, PriceTypeEnum priceType, QuantityTypeEnum quantityType)
        {
            Position = position;
            Quantity = quantity;
            Price = price;
            PriceType = priceType;
            QuantityType = quantityType;
        }
    }

    public interface ITradeView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetPairs(IEnumerable<PairOfMarket> pairs);

        void SetOpenedOrders(IEnumerable<Order> orders);

        TradePosition Position { set; }
        PriceTypeEnum PriceType { set; }
        QuantityTypeEnum QuantityType { set; }

        void SetUsdRate(GetUsdRateDelegate getUsdRate);

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
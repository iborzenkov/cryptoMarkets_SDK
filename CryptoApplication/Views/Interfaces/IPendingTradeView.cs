using DomainModel.Features;
using System;
using System.Collections.Generic;
using DomainModel;

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

        Market Market { get; set; }
        PairOfMarket Pair { get; set; }

        void SetIsMayTrade(bool value);
        void SetInfoMessage(string message);
        void SetBalanceInfo(double availableQuantity);
        void SetPriceInfo(double currentPrice);

        event Action<Market> MarketChanged;
        event Action<PairOfMarket> PairChanged;
        event Action<PendingTradeParams> TradeParamsChanged; 
        event Action<PendingTradeParams> Trade;
    }
}
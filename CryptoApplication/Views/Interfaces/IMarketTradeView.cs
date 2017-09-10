using DomainModel.Features;
using System;
using System.Collections.Generic;
using DomainModel;

namespace Views.Interfaces
{
    public class TradeParams
    {
        public TradePosition Position { get; }
        public double Quantity { get; }

        public TradeParams(TradePosition position, double quantity)
        {
            Position = position;
            Quantity = quantity;
        }
    }

    public interface IMarketTradeView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);
        void SetPairs(IEnumerable<PairOfMarket> pairs);

        Market Market { get; set; }
        PairOfMarket Pair { get; set; }

        void SetIsMayTrade(bool value);
        void SetIsMayTrade2(bool value);

        event Action<Market> MarketChanged;
        event Action<PairOfMarket> PairChanged;
        event Action<TradeParams> TradeParamsChanged; 
        event Action<TradeParams> TradeParams2Changed;
        event Action<TradeParams> Trade;
        event Action<TradeParams> Trade2;
    }
}
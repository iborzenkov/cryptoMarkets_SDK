using DomainModel.Features;
using DomainModel.MarketModel;
using Models;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public interface IOrderBookView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        Market Market { get; set; }

        void SetPairs(IEnumerable<PairOfMarket> pairs);

        void SetOrderBook(IOrderBook orderBook);

        void SetUsdRate(double? usdRate);

        void SetOrderBookSettings(OrderBookSettings settings);

        PairOfMarket Pair { get; set; }

        event Action<Market> MarketChanged;

        event Action<PairOfMarket> PairChanged;

        event Action<OrderBookSettings> OrderBookSettingsChanged;
    }
}
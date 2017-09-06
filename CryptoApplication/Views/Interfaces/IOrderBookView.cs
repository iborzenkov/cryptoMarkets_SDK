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

        //void SetSelectedMarket(Market market);
        Market Market { get; set; }

        void SetPairs(IEnumerable<PairOfMarket> pairs);

        void SetOrderBook(IOrderBook orderBook);

        void SetUsdRate(double? usdRate);

        void SetOrderBookSettings(OrderBookSettings settings);

        PairOfMarket Pair { get; set; }

        event EventHandler<Market> MarketChanged;

        event EventHandler<PairOfMarket> PairChanged;

        event EventHandler<OrderBookSettings> OrderBookSettingsChanged;
    }
}
using System;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public class OrderBookSignal : Signal<IOrderBook>
    {
        public OrderBookSignal(Func<IOrderBook, bool> condition, Action action) : base(condition, action)
        {
        }
    }
}
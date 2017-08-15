using System;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public interface IOrderBookUpdater
    {
        int RefreshInterval { get; set; }
        int Depth { get; set; }
        OrderBookType OrderBookType { get; set; }

        void Start();
        void Stop();

        void AddSignal(OrderBookSignal signal);
        void RemoveSignal(OrderBookSignal signal);

        event EventHandler<IOrderBook> Changed;
    }
}
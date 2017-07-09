using System;
using DomainModel.Features;

namespace DomainModel.MarketModel
{
    public interface IOrderBookUpdater
    {
        int RefreshInterval { get; set; }
        int Depth { get; set; }
        OrderBookType OrderBookType { get; set; }
        
        void Start();
        void Stop();

        event EventHandler<OrderBook> Changed;
    }
}
using System;
using DomainModel.Features;
using System.Collections.Generic;
using DomainModel;

namespace Models.Interfaces
{
    public interface IPendingTradeModel
    {
        IEnumerable<Market> Markets { get; }

        void MarketChanged(Market market);
        void PairChanged(PairOfMarket pair);

        void RemoveOrder(OrderId id);
        OrderId Trade();

        Tick Tick { get; set; }
        Balance Balance { get; set; }

        TradePosition Position { get; set; }
        double Quantity { get; set; }
        double Price { get; set; }

        event Action<Tick> TickChanged;
        event Action<Balance> BalanceChanged;
        event Action<IEnumerable<Order>> OpenedOrdersChanged;
        event Action<bool> IsMayTradeChanged;
        void Release();
    }
}
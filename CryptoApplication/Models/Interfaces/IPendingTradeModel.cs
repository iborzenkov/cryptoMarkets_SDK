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
        PriceTypeEnum PriceType { get; set; }
        QuantityTypeEnum QuantityType { get; set; } 

        double Quantity { get; set; }
        double Price { get; set; }

        double? GetUsdRateChanged(Currency currency);

        event Action<Tick> TickChanged;
        event Action<Balance> BalanceChanged;
        event Action<IEnumerable<Order>> OpenedOrdersChanged;
        event Action<string> ErrorOccured;
        event Action<string> InfoOccured;
        event Action<bool> IsMayTradeChanged;

        void Release();
    }
}
using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel
{
    public interface IMarketTrade
    {
        IApiKey ApiKey { get; set; }

        OrderId BuyLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage);
        OrderId SellLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage);
        bool Cancel(OrderId orderId);
        IEnumerable<Order> OpenedOrders(PairOfMarket pair);
    }
}
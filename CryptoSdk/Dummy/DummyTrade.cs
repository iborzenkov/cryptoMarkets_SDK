using System;
using DomainModel.Features;
using DomainModel.MarketModel;
using System.Collections.Generic;

namespace CryptoSdk.Dummy
{
    public class DummyTrade : IMarketTrade
    {
        public IApiKey ApiKey { get; set; }

        public OrderId BuyLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage)
        {
            errorMessage = string.Empty;
            return new OrderId("1");
        }

        public OrderId SellLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage)
        {
            errorMessage = string.Empty;
            return new OrderId("1");
        }

        public bool Cancel(Market market, OrderId orderId, out string errorMessage)
        {
            errorMessage = String.Empty;
            return true;
        }

        public IEnumerable<Order> OpenedOrders(PairOfMarket pair)
        {
            var result = new List<Order>();

            var order = new Order
            {
                Id = new OrderId("1"),
            };

            result.Add(order);

            return result;
        }
    }
}
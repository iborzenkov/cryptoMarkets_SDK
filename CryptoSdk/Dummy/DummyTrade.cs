using DomainModel.Features;
using DomainModel.MarketModel;
using System.Collections.Generic;
using DomainModel;

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
            //errorMessage = string.Empty;
            //return true;
            errorMessage = "Error occured";
            return false;
        }

        public IEnumerable<Order> OpenedOrders(Market market, Pair pair)
        {
            var result = new List<Order>
            {
                new Order(new OrderId("1"), market, pair, 123, 0.145, TradePosition.Buy),
                new Order(new OrderId("2"), market, pair, 34, 0.785, TradePosition.Sell)
            };
            
            return result;
        }

        public IEnumerable<Order> OpenedOrders(Market market)
        {
            var result = new List<Order>
            {
                new Order(new OrderId("3"), market, PairDummy.EthBtc, 123, 0.145, TradePosition.Buy),
                new Order(new OrderId("4"), market, PairDummy.UsdtBtc, 34, 0.785, TradePosition.Sell)
            };

            return result;
        }
    }
}
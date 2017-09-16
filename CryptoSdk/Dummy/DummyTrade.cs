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
    }
}
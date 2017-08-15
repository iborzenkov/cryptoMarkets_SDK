using System.Collections.Generic;
using DomainModel.Features;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexTrade : IMarketTrade
    {
        private readonly IConnection _connection;

        public BittrexTrade(IConnection connection)
        {
            _connection = connection;
        }

        public IApiKey ApiKey { get; set; }
        public OrderId BuyLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage)
        {
            throw new System.NotImplementedException();
        }

        public OrderId SellLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage)
        {
            throw new System.NotImplementedException();
        }

        public bool Cancel(OrderId orderId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Order> OpenedOrders(PairOfMarket pair)
        {
            throw new System.NotImplementedException();
        }
    }
}
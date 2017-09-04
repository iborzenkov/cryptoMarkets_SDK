using System;
using System.Collections.Generic;
using System.Linq;
using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Extensions;
using DomainModel.Features;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexTrade : BittrexPrivate, IMarketTrade
    {
        public BittrexTrade(IConnection connection) : base(connection)
        {
        }

        public OrderId BuyLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage)
        {
            var apiKeys = pair.Market.ApiKeys(ApiKeyRole.TradeLimit);

            OrderId result = null;
            errorMessage = string.Empty;

            var parameters = new List<Tuple<string, string>>
            {
                Tuple.Create("market", pair.ToString()),
                Tuple.Create("quantity", quantity.ToString(Nfi)),
                Tuple.Create("rate", rate.ToString(Nfi))
            };

            var query = Connection.PrivateGetQuery<BittrexLimitOrderDataType>(
                EndPoints.BuyLimit, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success)
            {
                result = new OrderId(query.Order.Id);
            }
            else
            {
                errorMessage = query.Message;
            }

            return result;
        }

        public OrderId SellLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage)
        {
            var apiKeys = pair.Market.ApiKeys(ApiKeyRole.TradeLimit);

            OrderId result = null;
            errorMessage = string.Empty;

            var parameters = new List<Tuple<string, string>>
            {
                Tuple.Create("market", pair.ToString()),
                Tuple.Create("quantity", quantity.ToString(Nfi)),
                Tuple.Create("rate", rate.ToString(Nfi))
            };

            var query = Connection.PrivateGetQuery<BittrexLimitOrderDataType>(
                EndPoints.SellLimit, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success)
            {
                result = new OrderId(query.Order.Id);
            }
            else
            {
                errorMessage = query.Message;
            }

            return result;
        }

        public bool Cancel(Market market, OrderId orderId, out string errorMessage)
        {
            var apiKeys = market.ApiKeys(ApiKeyRole.TradeLimit);

            var parameters = new List<Tuple<string, string>>
            {
                Tuple.Create("uuid", orderId.ToString()),
            };

            var query = Connection.PrivateGetQuery<BittrexLimitOrderDataType>(
                EndPoints.CancelOrder, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success)
            {
                errorMessage = string.Empty;
                return true;
            }

            errorMessage = query.Message;
            return false;
        }

        public IEnumerable<Order> OpenedOrders(PairOfMarket pair)
        {
            var result = new List<Order>();

            var apiKeys = pair.Market.ApiKeys(ApiKeyRole.TradeLimit);

            var parameters = new List<Tuple<string, string>>
            {
                Tuple.Create("market", pair.ToString()),
            };

            var query = Connection.PrivateGetQuery<BittrexOpenedLimitOrderDataType>(
                EndPoints.GetOpenedOrders, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success)
            {
                result.AddRange(query.Orders.Select(order => order.ToOrder()));
            }

            return result;
        }
    }
}
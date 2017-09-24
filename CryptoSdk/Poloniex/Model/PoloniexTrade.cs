using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Misc;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace CryptoSdk.Poloniex.Model
{
    public class PoloniexTrade : PoloniexPrivate, IMarketTrade
    {
        public PoloniexTrade(IConnection connection) : base(connection)
        {
        }

        public OrderId BuyLimit(PairOfMarket pair, double quantity, double rate, out string errorMessage)
        {
            var apiKeys = pair.Market.ApiKeys(ApiKeyRole.TradeLimit);

            OrderId result = null;
            errorMessage = string.Empty;

            var parameters = new List<Tuple<string, string>>
            {
                Tuple.Create("market", BittrexPairs.AsString(pair)),
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
                Tuple.Create("market", BittrexPairs.AsString(pair)),
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
    }
}
using CryptoSdk.Poloniex.Connection;
using CryptoSdk.Poloniex.DataTypes;
using CryptoSdk.Poloniex.DataTypes.Extensions;
using CryptoSdk.Poloniex.DataTypes.Misc;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Poloniex.Model
{
    public class PoloniexAccountInfo : PoloniexBase, IAccountInfo
    {
        public PoloniexAccountInfo(IConnection connection) : base(connection)
        {
        }

        public IEnumerable<Balance> Balances(Market market)
        {
            var result = new List<Balance>();

            var apiKeys = market.ApiKeys(ApiKeyRole.Trade);
            var balanceParameters = new Tuple<string, string>[1];
            balanceParameters[0] = Tuple.Create(EndPoints.CommandTag, EndPoints.GetBalances);

            var queryBalance = Connection.PrivatePostQuery<Dictionary<string, PoloniexBalanceDataType>>(
                EndPoints.Trading, apiKeys, PostParameters(apiKeys.PublicKey, balanceParameters));

            var purseParameters = new Tuple<string, string>[1];
            purseParameters[0] = Tuple.Create(EndPoints.CommandTag, EndPoints.GetPurseAddress);
            var queryPurse = Connection.PrivatePostQuery<Dictionary<string, string>>(
                EndPoints.Trading, apiKeys, PostParameters(apiKeys.PublicKey, purseParameters));

            foreach (var currencyName in queryBalance.Keys)
            {
                string purse;
                queryPurse.TryGetValue(currencyName, out purse);
                result.Add(
                    queryBalance[currencyName].ToBalance(
                        market.Currencies.First(c => c.Currency.Name == currencyName), purse));
            }

            return result;
        }

        public Balance Balance(Market market, Currency currency)
        {
            return Balances(market).FirstOrDefault(b => b.Currency.Equals(currency));
        }

        public Balance Balance(CurrencyOfMarket currency)
        {
            return Balance(currency.Market, currency.Currency);
        }

        public IEnumerable<Order> OpenedOrders(Market market, Pair pair)
        {
            // todo: test it
            var result = new List<Order>();
            var apiKeys = market.ApiKeys(ApiKeyRole.Trade);

            var parameters = new Tuple<string, string>[2];
            parameters[0] = Tuple.Create(EndPoints.CommandTag, EndPoints.GetBalances);
            parameters[1] = Tuple.Create("currencyPair", PoloniexPairs.AsString(pair));

            var query = Connection.PrivateGetQuery<List<PoloniexOpenedOrdersDataType>>(
                EndPoints.GetOpenedOrders, apiKeys, PostParameters(apiKeys.PublicKey, parameters));

            result.AddRange(query.Select(order => order.ToOrder(market, pair)));

            return result;
        }

        public IEnumerable<Order> OpenedOrders(Market market)
        {
            // todo: test it
            var result = new List<Order>();
            var apiKeys = market.ApiKeys(ApiKeyRole.Trade);

            var parameters = new Tuple<string, string>[2];
            parameters[0] = Tuple.Create(EndPoints.CommandTag, EndPoints.GetBalances);
            parameters[1] = Tuple.Create("currencyPair", "all");

            var query = Connection.PrivateGetQuery<Dictionary<string, List<PoloniexOpenedOrdersDataType>>>(
                EndPoints.GetOpenedOrders, apiKeys, PostParameters(apiKeys.PublicKey, parameters));

            foreach (var key in query.Keys)
            {
                Pair pair;
                if (!PoloniexPairs.TryParsePair(key, out pair))
                    continue;

                var orders = query[key];
                result.AddRange(orders.Select(order => order.ToOrder(market, pair)));
            }

            return result;
        }
    }
}
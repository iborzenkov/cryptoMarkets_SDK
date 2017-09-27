using CryptoSdk.Poloniex.Connection;
using CryptoSdk.Poloniex.DataTypes;
using CryptoSdk.Poloniex.DataTypes.Extensions;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Poloniex.Model
{
    public class PoloniexAccountInfo : PoloniexPrivate, IAccountInfo
    {
        public PoloniexAccountInfo(IConnection connection) : base(connection)
        {
        }

        public IEnumerable<Balance> Balances(Market market)
        {
            var apiKeys = market.ApiKeys(ApiKeyRole.Info);

            var balanceParameters = new Tuple<string, string>[1];
            balanceParameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetBalances);

            var result = new List<Balance>();
            var queryBalance = Connection.PrivateGetQuery<Dictionary<string, PoloniexBalanceDataType>>(
                EndPoints.Trading, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, balanceParameters));

            var purseParameters = new Tuple<string, string>[1];
            purseParameters[0] = new Tuple<string, string>(EndPoints.CommandTag, EndPoints.GetPurseAddress);
            var queryPurse = Connection.PrivateGetQuery<Dictionary<string, string>>(
                EndPoints.Trading, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, purseParameters));

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
            var result = new List<Order>();
            /*var apiKeys = market.ApiKeys(ApiKeyRole.Info);

            var parameters = pair == null ? null : new List<Tuple<string, string>> { Tuple.Create("market", BittrexPairs.AsString(pair)) };

            var query = Connection.PrivateGetQuery<BittrexOpenedLimitOrderDataType>(
                EndPoints.GetOpenedOrders, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success)
            {
                result.AddRange(query.Orders.Select(order => order.ToOrder(market)));
            }*/

            return result;
        }

        public IEnumerable<Order> OpenedOrders(Market market)
        {
            return OpenedOrders(market, null);
        }
    }
}
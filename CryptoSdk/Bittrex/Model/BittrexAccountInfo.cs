using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Extensions;
using CryptoSdk.Bittrex.DataTypes.Misc;
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexAccountInfo : BittrexBase, IAccountInfo
    {
        public BittrexAccountInfo(IConnection connection) : base(connection)
        {
        }

        public IEnumerable<Balance> Balances(Market market)
        {
            var apiKeys = market.ApiKeys(ApiKeyRole.Info);

            var result = new List<Balance>();
            var query = Connection.PrivateGetQuery<BittrexBalancesDataType>(
                EndPoints.GetBalances, apiKeys, GetParameters(apiKeys.PublicKey));
            if (query.Success && query.Balances != null)
            {
                result.AddRange(
                    query.Balances.Select(
                        balanceDataType =>
                            balanceDataType.ToBalance(
                                market,
                                market.Currencies.First(c => c.Currency.Name == balanceDataType.Currency).Currency)));
            }

            return result;
        }

        public Balance Balance(Market market, Currency currency)
        {
            Balance balance = null;
            var parameters = new Tuple<string, string>[1];
            parameters[0] = Tuple.Create("currency", currency.Name);

            var apiKeys = market.ApiKeys(ApiKeyRole.Info);

            var query = Connection.PrivateGetQuery<BittrexBalanceDataType>(
                EndPoints.GetBalance, apiKeys, GetParameters(apiKeys.PublicKey, parameters));
            if (query != null && query.Success && query.Balance != null)
                balance = query.Balance.ToBalance(market, currency);

            return balance;
        }

        public Balance Balance(CurrencyOfMarket currency)
        {
            return Balance(currency.Market, currency.Currency);
        }

        public IEnumerable<Order> OpenedOrders(Market market, Pair pair)
        {
            var result = new List<Order>();
            var apiKeys = market.ApiKeys(ApiKeyRole.Info);

            var parameters = pair == null ? null : new List<Tuple<string, string>> { Tuple.Create("market", BittrexPairs.AsString(pair)) };

            var query = Connection.PrivateGetQuery<BittrexOpenedOrdersDataType>(
                EndPoints.GetOpenedOrders, apiKeys, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success && query.Orders != null)
            {
                result.AddRange(query.Orders.Select(order => order.ToOrder(market)));
            }

            return result;
        }

        public IEnumerable<Order> OpenedOrders(Market market)
        {
            return OpenedOrders(market, null);
        }
    }
}
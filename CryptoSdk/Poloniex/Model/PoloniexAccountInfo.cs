using System;
using System.Collections.Generic;
using System.Linq;
using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Misc;
using CryptoSdk.Poloniex.DataTypes.Extensions;
using DomainModel.Features;
using DomainModel.MarketModel;

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

            var result = new List<Balance>();
            var query = Connection.PrivateGetQuery<BittrexBalancesDataType>(
                EndPoints.GetBalances, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey));
            if (query.Success)
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
                EndPoints.GetBalance, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success)
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

            var query = Connection.PrivateGetQuery<BittrexOpenedLimitOrderDataType>(
                EndPoints.GetOpenedOrders, apiKeys.PrivateKey, GetParameters(apiKeys.PublicKey, parameters));
            if (query.Success)
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
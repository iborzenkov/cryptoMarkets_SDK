using System;
using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.DataTypes;
using CryptoSdk.Bittrex.DataTypes.Extensions;
using DomainModel.Features;
using DomainModel.MarketModel;
using System.Collections.Generic;
using System.Linq;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexAccountInfo : BittrexPrivate, IAccountInfo
    {

        public BittrexAccountInfo(IConnection connection) : base(connection)
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
    }
}
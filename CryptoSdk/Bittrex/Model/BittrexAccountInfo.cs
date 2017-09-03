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
    public class BittrexAccountInfo : IAccountInfo
    {
        private readonly IConnection _connection;

        public BittrexAccountInfo(IConnection connection)
        {
            _connection = connection;
        }

        private Tuple<string, string>[] GetParameters(IApiKey publicKey, IReadOnlyList<Tuple<string, string>> additionalParams = null)
        {
            var nonce = DateTime.Now.Ticks;

            var commonParamsCount = 2;
            var additionalParamsCount = additionalParams == null ? 0 : additionalParams.Count;
            var parameters = new Tuple<string, string>[commonParamsCount + additionalParamsCount];
            parameters[0] = Tuple.Create("apikey", publicKey.Key);
            parameters[1] = Tuple.Create("nonce", nonce.ToString());

            if (additionalParams != null)
            {
                for (int i = 0, n = commonParamsCount; i < additionalParams.Count; i++, n++)
                {
                    parameters[n] = additionalParams[i];
                }
            }

            return parameters;
        }

        public IEnumerable<Balance> Balances(Market market)
        {
            var apiKeys = market.ApiKeys(ApiKeyRole.Info);

            var result = new List<Balance>();
            var query = _connection.PrivateGetQuery<BittrexBalancesDataType>(
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
            var parameters = new Tuple<string, string>[0];
            parameters[0] = Tuple.Create("currency", currency.Name);

            var apiKeys = market.ApiKeys(ApiKeyRole.Info);

            var query = _connection.PrivateGetQuery<BittrexBalanceDataType>(
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
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

        public IApiKey ApiKey { get; set; }

        public IEnumerable<Balance> Balances(Market market)
        {
            var result = new List<Balance>();

            var query = _connection.PublicGetQuery<BittrexBalancesDataType>(EndPoints.GetBalances);
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

            var query = _connection.PublicGetQuery<BittrexBalanceDataType>(EndPoints.GetBalance);
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
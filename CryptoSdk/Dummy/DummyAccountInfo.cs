using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace CryptoSdk.Dummy
{
    public class DummyAccountInfo : IAccountInfo
    {
        private readonly Random _rnd = new Random();

        private void GetRandomBalance(out double total, out double available, out double pending)
        {
            available = _rnd.Next(15, 50);
            pending = _rnd.Next(1, 10);
            total = available + pending;
        }

        public IEnumerable<Balance> Balances(Market market)
        {
            var balances = new List<Balance>();

            double total;
            double available;
            double pending;

            GetRandomBalance(out total, out available, out pending);
            balances.Add(new Balance(market, CurrencyDummy.Btc, CryptoAddress.FromString("address btc"), total, available, pending));

            GetRandomBalance(out total, out available, out pending);
            balances.Add(new Balance(market, CurrencyDummy.Eth, CryptoAddress.FromString("address eth"), total, available, pending));

            GetRandomBalance(out total, out available, out pending);
            balances.Add(new Balance(market, CurrencyDummy.Ltc, CryptoAddress.FromString("address ltc"), total, available, pending));

            return balances;
        }

        public Balance Balance(Market market, Currency currency)
        {
            double total;
            double available;
            double pending;

            GetRandomBalance(out total, out available, out pending);
            return new Balance(market, currency, CryptoAddress.FromString("address"), total, available, pending);
        }

        public Balance Balance(CurrencyOfMarket currency)
        {
            return Balance(currency.Market, currency.Currency);
        }
    }
}
using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace CryptoSdk.Dummy
{
    public class DummyAccount : IAccountInfo
    {
        private readonly Random _rnd = new Random();

        private void GetRandomBalance(out double reserved, out double available, out double pending)
        {
            available = _rnd.Next(15, 50);
            pending = _rnd.Next(1, 10);
            reserved = _rnd.Next(1, 5);
        }

        public IEnumerable<Balance> Balances(Market market)
        {
            var balances = new List<Balance>();

            double reserved;
            double available;
            double pending;

            GetRandomBalance(out reserved, out available, out pending);
            balances.Add(new Balance(market, CurrencyDummy.Btc, CryptoAddress.FromString("address btc"), available, reserved, pending));

            GetRandomBalance(out reserved, out available, out pending);
            balances.Add(new Balance(market, CurrencyDummy.Eth, CryptoAddress.FromString("address eth"), available, reserved, pending));

            GetRandomBalance(out reserved, out available, out pending);
            balances.Add(new Balance(market, CurrencyDummy.Ltc, CryptoAddress.FromString("address ltc"), available, reserved, pending));

            return balances;
        }

        public Balance Balance(Market market, Currency currency)
        {
            double total = 0;
            double available = 0;
            double pending = 0;

            if (!currency.Equals(CurrencyDummy.Usdt) && !currency.Equals(CurrencyDummy.Eth))
                GetRandomBalance(out total, out available, out pending);
            return new Balance(market, currency, CryptoAddress.FromString("address"), total, available, pending);
        }

        public Balance Balance(CurrencyOfMarket currency)
        {
            return Balance(currency.Market, currency.Currency);
        }
    }
}
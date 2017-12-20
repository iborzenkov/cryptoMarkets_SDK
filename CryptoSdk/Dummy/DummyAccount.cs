using DomainModel;
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

        public IEnumerable<Order> OpenedOrders(Market market, Pair pair = null)
        {
            var result = new List<Order>
            {
                new Order(new OrderId("1"), market, pair, 123, 0.145, TradePosition.Buy),
                new Order(new OrderId("2"), market, pair, 34, 0.785, TradePosition.Sell)
            };

            return result;
        }

        public IEnumerable<HistoryOrder> HistoryOrders(Market market, Pair pair = null)
        {
            var result = new List<HistoryOrder>
            {
                new HistoryOrder(new OrderId("3"), market, PairDummy.EthBtc, 123, 0.145, 0.1, TradePosition.Buy, DateTime.Now),
                new HistoryOrder(new OrderId("4"), market, PairDummy.UsdtBtc, 34, 0.785, 0.01, TradePosition.Sell, DateTime.Now)
            };

            return result;
        }
    }
}
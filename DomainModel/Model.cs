using DomainModel.Features;
using DomainModel.MarketModel.Updaters.Balance;
using DomainModel.MarketModel.Updaters.OpenedOrders;
using DomainModel.MarketModel.Updaters.OrderBook;
using DomainModel.MarketModel.Updaters.PairStatistic;
using DomainModel.MarketModel.Updaters.PairTick;
using System.Collections.Generic;
using DomainModel.MarketModel.Updaters.HistoryPrices;

namespace DomainModel
{
    public class Model : IModel
    {
        private readonly List<Market> _markets = new List<Market>();

        public void AddMarket(Market market)
        {
            _markets.Add(market);
        }

        public IEnumerable<Market> Markets => _markets;

        public IOrderBookUpdaterProvider OrderBookUpdaterProvider { get; } = new OrderBookUpdaterProvider();

        public IBalanceUpdaterProvider BalanceUpdaterProvider { get; } = new BalanceUpdaterProvider();

        public IPairStatisticUpdaterProvider PairStatisticUpdaterProvider { get; } = new PairStatisticUpdaterProvider();

        public IPairTickUpdaterProvider PairTickUpdaterProvider { get; } = new PairTickUpdaterProvider();

        public IOpenedOrdersUpdaterProvider OpenedOrdersProvider { get; } = new OpenedOrdersUpdaterProvider();

        public IHistoryPricesUpdaterProvider HistoryPricesProvider { get; } = new HistoryPricesUpdaterProvider();
    }
}
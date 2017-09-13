using DomainModel.Features;
using DomainModel.MarketModel.Updaters.Balance;
using DomainModel.MarketModel.Updaters.OrderBook;
using System.Collections.Generic;
using DomainModel.MarketModel.Updaters.OpenedOrders;
using DomainModel.MarketModel.Updaters.PairStatistic;
using DomainModel.MarketModel.Updaters.PairTick;

namespace DomainModel
{
    public interface IModel
    {
        IEnumerable<Market> Markets { get; }

        IOrderBookUpdaterProvider OrderBookUpdaterProvider { get; }

        IBalanceUpdaterProvider BalanceUpdaterProvider { get; }

        IPairStatisticUpdaterProvider PairStatisticUpdaterProvider { get; }

        IPairTickUpdaterProvider PairTickUpdaterProvider { get; }

        IOpenedOrdersUpdaterProvider OpenedOrdersProvider { get; }
    }
}
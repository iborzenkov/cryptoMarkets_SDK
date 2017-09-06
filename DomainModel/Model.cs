using DomainModel.Features;
using DomainModel.MarketModel.Updaters.Balance;
using DomainModel.MarketModel.Updaters.OrderBook;
using System.Collections.Generic;
using DomainModel.MarketModel.Updaters.PairStatistic;
using DomainModel.MarketModel.Updaters.PairTick;

namespace DomainModel
{
    public class Model : IModel
    {
        private readonly List<Market> _markets = new List<Market>();

        public void AddMarket(Market market)
        {
            _markets.Add(market);
        }

        IEnumerable<Market> IModel.Markets => _markets;

        IOrderBookUpdaterProvider IModel.OrderBookUpdaterProvider { get; } = new OrderBookUpdaterProvider();

        IBalanceUpdaterProvider IModel.BalanceUpdaterProvider { get; } = new BalanceUpdaterProvider();

        IPairStatisticUpdaterProvider IModel.PairStatisticUpdaterProvider { get; } = new PairStatisticUpdaterProvider();

        IPairTickUpdaterProvider IModel.PairTickUpdaterProvider { get; } = new PairTickUpdaterProvider();
    }
}
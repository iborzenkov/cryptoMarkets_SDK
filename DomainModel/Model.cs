using DomainModel.Features;
using System.Collections.Generic;
using DomainModel.MarketModel;

namespace DomainModel
{
    public class Model : IModel, IOrderBookUpdaterProvider
    {
        private readonly List<Market> _markets = new List<Market>();

        public Model()
        {
        }

        public void AddMarket(Market market)
        {
            _markets.Add(market);
        }

        public IEnumerable<Market> Markets => _markets;

        private readonly Dictionary<PairOfMarket,IOrderBookUpdater> _orderBookUpdaters = new Dictionary<PairOfMarket,IOrderBookUpdater>();
        public IOrderBookUpdater OrderBookUpdater(PairOfMarket pair)
        {
            IOrderBookUpdater updater;
            if (!_orderBookUpdaters.TryGetValue(pair, out updater))
                updater = new OrderBookUpdater(pair, pair.Market.Model.Info);

            return updater;
        }
    }
}
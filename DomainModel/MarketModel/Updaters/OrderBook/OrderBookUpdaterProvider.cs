using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public class OrderBookUpdaterProvider : IOrderBookUpdaterProvider
    {
        private readonly Dictionary<PairOfMarket, IOrderBookUpdater> _orderBookUpdaters = new Dictionary<PairOfMarket, IOrderBookUpdater>();
        private readonly Dictionary<IOrderBookUpdater, int> _orderBookUpdaterReferences = new Dictionary<IOrderBookUpdater, int>();

        public IOrderBookUpdater OrderBookUpdater(PairOfMarket pair)
        {
            IOrderBookUpdater updater;
            if (!_orderBookUpdaters.TryGetValue(pair, out updater))
            {
                updater = new OrderBookUpdater(pair, pair.Market.Model.Info);
                _orderBookUpdaters.Add(pair, updater);
            }

            int references;
            if (_orderBookUpdaterReferences.TryGetValue(updater, out references))
                _orderBookUpdaterReferences.Remove(updater);
            _orderBookUpdaterReferences.Add(updater, references + 1);

            return updater;
        }

        public void ReleaseUpdater(IOrderBookUpdater updater)
        {
            if (updater == null)
                return;

            int references;
            if (_orderBookUpdaterReferences.TryGetValue(updater, out references))
                _orderBookUpdaterReferences.Remove(updater);

            references--;
            if (references == 0)
                updater.Stop();
            else
                _orderBookUpdaterReferences.Add(updater, references);
        }
    }
}
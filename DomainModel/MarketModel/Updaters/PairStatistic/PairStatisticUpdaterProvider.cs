using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    public class PairStatisticUpdaterProvider : IPairStatisticUpdaterProvider
    {
        private readonly Dictionary<Market, IPairStatisticUpdater> _pairStatisticUpdaters = new Dictionary<Market, IPairStatisticUpdater>();
        private readonly Dictionary<IPairStatisticUpdater, int> _pairStatisticUpdaterReferences = new Dictionary<IPairStatisticUpdater, int>();

        public IPairStatisticUpdater PairStatisticUpdater(Market market)
        {
            IPairStatisticUpdater updater;
            if (!_pairStatisticUpdaters.TryGetValue(market, out updater))
            {
                updater = new PairStatisticUpdater(market.Model.Info);
                _pairStatisticUpdaters.Add(market, updater);
            }

            int references;
            if (_pairStatisticUpdaterReferences.TryGetValue(updater, out references))
                _pairStatisticUpdaterReferences.Remove(updater);
            _pairStatisticUpdaterReferences.Add(updater, references + 1);

            return updater;
        }

        public void ReleaseUpdater(IPairStatisticUpdater updater)
        {
            if (updater == null)
                return;

            int references;
            if (_pairStatisticUpdaterReferences.TryGetValue(updater, out references))
                _pairStatisticUpdaterReferences.Remove(updater);

            references--;
            if (references == 0)
                updater.Stop();
            else
                _pairStatisticUpdaterReferences.Add(updater, references);
        }
    }
}
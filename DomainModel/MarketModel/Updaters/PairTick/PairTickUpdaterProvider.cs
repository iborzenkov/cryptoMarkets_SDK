using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    public class PairTickUpdater2 : IPairTickUpdater
    {
        private readonly PairTickUpdater _updater;

        public PairTickUpdater2(PairTickUpdater updater, RefreshInterval refreshInterval)
        {
            _updater = updater;
            RefreshInterval = refreshInterval;
            _updater.Changed += (sender, tick) => Changed?.Invoke(sender, tick);
        }

        public RefreshInterval RefreshInterval { get; }

        public void Start()
        {
            _updater.Start();
        }

        public void Stop()
        {
            _updater.Stop();
        }

        public Tick LastPairTick => _updater.LastPairTick;

        public event EventHandler<Tick> Changed;
    }

    public class PairTickUpdaterProvider : IPairTickUpdaterProvider
    {
        /*private readonly Dictionary<PairOfMarket, PairTickUpdater> _pairTickUpdaters = new Dictionary<PairOfMarket, PairTickUpdater>();
        private readonly Dictionary<PairTickUpdater, int> _pairTickUpdaterReferences = new Dictionary<PairTickUpdater, int>();

        public IPairTickUpdater PairTickUpdater(PairOfMarket pair, RefreshInterval refreshInterval)
        {
            PairTickUpdater updater;
            if (!_pairTickUpdaters.TryGetValue(pair, out updater))
            {
                updater = new PairTickUpdater(pair);
                _pairTickUpdaters.Add(pair, updater);
            }

            int references;
            if (_pairTickUpdaterReferences.TryGetValue(updater, out references))
                _pairTickUpdaterReferences.Remove(updater);
            _pairTickUpdaterReferences.Add(updater, references + 1);

            return updater;
        }

        public void ReleaseUpdater(IPairTickUpdater updater)
        {
            if (updater == null)
                return;

            int references;
            if (_pairTickUpdaterReferences.TryGetValue(updater, out references))
                _pairTickUpdaterReferences.Remove(updater);

            references--;
            if (references == 0)
                updater.Stop();
            else
                _pairTickUpdaterReferences.Add(updater, references);
        }*/

        private readonly Dictionary<PairOfMarket, IPairTickUpdater> _pairTickUpdaters = new Dictionary<PairOfMarket, IPairTickUpdater>();
        private readonly Dictionary<IPairTickUpdater, int> _pairTickUpdaterReferences = new Dictionary<IPairTickUpdater, int>();

        public IPairTickUpdater PairTickUpdater(PairOfMarket pair, RefreshInterval refreshInterval)
        {
            IPairTickUpdater updater;
            if (!_pairTickUpdaters.TryGetValue(pair, out updater))
            {
                updater = new PairTickUpdater(pair);
                _pairTickUpdaters.Add(pair, updater);
            }

            int references;
            if (_pairTickUpdaterReferences.TryGetValue(updater, out references))
                _pairTickUpdaterReferences.Remove(updater);
            _pairTickUpdaterReferences.Add(updater, references + 1);

            return updater;
        }

        public void ReleaseUpdater(IPairTickUpdater updater)
        {
            if (updater == null)
                return;

            int references;
            if (_pairTickUpdaterReferences.TryGetValue(updater, out references))
                _pairTickUpdaterReferences.Remove(updater);

            references--;
            if (references == 0)
                updater.Stop();
            else
                _pairTickUpdaterReferences.Add(updater, references);
        }
    }
}
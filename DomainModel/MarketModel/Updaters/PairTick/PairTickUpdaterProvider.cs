using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    public class PairTickUpdater2 : IPairTickUpdater
    {
        private readonly PairTickUpdater _updater;

        public PairTickUpdater2(PairTickUpdater updater, RefreshInterval refreshInterval)
        {
            _updater = updater;
            RefreshInterval = refreshInterval;
            _updater.Changed += (sender, tick) => Changed?.Invoke(tick);
        }

        public PairOfMarket Pair => _updater.Pair;
        public RefreshInterval RefreshInterval { get; }

        int IPairTickUpdater.RefreshInterval
        {
            get { return RefreshInterval.Value; }
            set { RefreshInterval.Value = value; }
        }

        public void Start()
        {
            _updater.Start();
        }

        public void Stop()
        {
            _updater.Stop();
        }

        public Tick LastPairTick => _updater.LastPairTick;

        public event Action<Tick> Changed;
    }

    public class PairTickUpdaterProvider : IPairTickUpdaterProvider
    {
        private readonly Dictionary<PairOfMarket, PairTickUpdater> _pairTickUpdaters = new Dictionary<PairOfMarket, PairTickUpdater>();
        private readonly Dictionary<IPairTickUpdater, KeyValuePair<PairOfMarket, RefreshInterval>> _pairTickUpdaters2 =
            new Dictionary<IPairTickUpdater, KeyValuePair<PairOfMarket, RefreshInterval>>();

        public IPairTickUpdater PairTickUpdater(PairOfMarket pair, RefreshInterval refreshInterval)
        {
            PairTickUpdater updater;

            IPairTickUpdater result = null;

            var data = new KeyValuePair<PairOfMarket, RefreshInterval>(pair, refreshInterval);

            if (!_pairTickUpdaters.TryGetValue(pair, out updater))
            {
                updater = new PairTickUpdater(pair)
                {
                    RefreshInterval = refreshInterval.Value
                };
                result = new PairTickUpdater2(updater, refreshInterval);

                _pairTickUpdaters.Add(pair, updater);
                _pairTickUpdaters2.Add(result, data);
            }
            else
            {
                var updaters = _pairTickUpdaters2.Keys.ToArray();
                var values = _pairTickUpdaters2.Values.ToArray();
                for (var i = 0; i < values.Length; i++)
                {
                    if (values[i].Key == pair && values[i].Value == refreshInterval)
                    {
                        result = updaters[i];
                        break;
                    }
                }
                if (result == null)
                {
                    result = new PairTickUpdater2(updater, refreshInterval);

                    updater.RefreshInterval = Math.Min(updater.RefreshInterval, refreshInterval.Value);
                    _pairTickUpdaters2.Add(result, data);
                }
            }

            return result;
        }

        public void ReleaseUpdater(IPairTickUpdater updater)
        {
            if (updater == null)
                return;

            var releasedPair = updater.Pair;
            _pairTickUpdaters2.Remove(updater);

            int? minRefreshInterval = null;
            foreach (var pairInterval in _pairTickUpdaters2.Values)
            {
                var pair = pairInterval.Key;
                if (pair == releasedPair)
                {
                    minRefreshInterval = minRefreshInterval.HasValue 
                        ? Math.Min(minRefreshInterval.Value, pairInterval.Value.Value) 
                        : pairInterval.Value.Value;
                }
            }

            if (minRefreshInterval.HasValue)
            {
                updater.RefreshInterval = minRefreshInterval.Value;
            }
                else
            {
                updater.Stop();
                _pairTickUpdaters.Remove(releasedPair);
            }
        }

        /*private readonly Dictionary<PairOfMarket, IPairTickUpdater> _pairTickUpdaters = new Dictionary<PairOfMarket, IPairTickUpdater>();
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
        }*/
    }
}
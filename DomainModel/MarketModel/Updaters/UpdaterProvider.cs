using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.MarketModel.Updaters
{
    internal abstract class UpdaterProvider<TUpdatableFeature, TOwnerUpdatableFeature>
        : IUpdaterProvider<TUpdatableFeature, TOwnerUpdatableFeature> 
        where TOwnerUpdatableFeature : class
    {
        private readonly Dictionary<TOwnerUpdatableFeature, Updater<TUpdatableFeature, TOwnerUpdatableFeature>> _ownerToUpdaterDictionary = 
            new Dictionary<TOwnerUpdatableFeature, Updater<TUpdatableFeature, TOwnerUpdatableFeature>>();
        private readonly Dictionary<IUpdater<TUpdatableFeature, TOwnerUpdatableFeature>, KeyValuePair<TOwnerUpdatableFeature, TimeInterval>> _updatersToPairAndIntervalDictionary =
            new Dictionary<IUpdater<TUpdatableFeature, TOwnerUpdatableFeature>, KeyValuePair<TOwnerUpdatableFeature, TimeInterval>>();

        protected abstract Updater<TUpdatableFeature, TOwnerUpdatableFeature> MakeUpdater(TOwnerUpdatableFeature owner);

        public IUpdater<TUpdatableFeature, TOwnerUpdatableFeature> GetUpdater(TOwnerUpdatableFeature owner, TimeInterval refreshInterval)
        {
            Updater<TUpdatableFeature, TOwnerUpdatableFeature> updater;

            IUpdater<TUpdatableFeature, TOwnerUpdatableFeature> result = null;

            var data = new KeyValuePair<TOwnerUpdatableFeature, TimeInterval>(owner, refreshInterval);
            if (!_ownerToUpdaterDictionary.TryGetValue(owner, out updater))
            {
                updater = MakeUpdater(owner);
                updater.RefreshInterval = refreshInterval.Value;

                result = new UpdaterDecorator<TUpdatableFeature, TOwnerUpdatableFeature>(updater, refreshInterval);

                _ownerToUpdaterDictionary.Add(owner, updater);
                _updatersToPairAndIntervalDictionary.Add(result, data);
            }
            else
            {
                var updaters = _updatersToPairAndIntervalDictionary.Keys.ToArray();
                var values = _updatersToPairAndIntervalDictionary.Values.ToArray();
                for (var i = 0; i < values.Length; i++)
                {
                    if (values[i].Key == owner && values[i].Value == refreshInterval)
                    {
                        result = updaters[i];
                        break;
                    }
                }
                if (result == null)
                {
                    result = new UpdaterDecorator<TUpdatableFeature, TOwnerUpdatableFeature>(updater, refreshInterval);

                    updater.RefreshInterval = Math.Min(updater.RefreshInterval, refreshInterval.Value);
                    _updatersToPairAndIntervalDictionary.Add(result, data);
                }
            }

            return result;
        }

        public void ReleaseUpdater(IUpdater<TUpdatableFeature, TOwnerUpdatableFeature> updater)
        {
            if (updater == null)
                return;

            updater.Release();

            var releasedOwner = updater.OwnerFeature;
            _updatersToPairAndIntervalDictionary.Remove(updater);

            int? minRefreshInterval = null;
            foreach (var pairInterval in _updatersToPairAndIntervalDictionary.Values)
            {
                var pair = pairInterval.Key;
                if (pair == releasedOwner)
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
                _ownerToUpdaterDictionary.Remove(releasedOwner);
            }
        }
    }
}
using System;
using System.Threading.Tasks;

namespace DomainModel.MarketModel.Updaters
{
    internal class UpdaterDecorator<TUpdatableFeature, TOwnerFeature> : IUpdater<TUpdatableFeature, TOwnerFeature>
    {
        private readonly Updater<TUpdatableFeature, TOwnerFeature> _updater;
        private readonly TimeInterval _refreshInterval;

        public UpdaterDecorator(Updater<TUpdatableFeature, TOwnerFeature> updater, TimeInterval refreshInterval)
        {
            _updater = updater;
            _refreshInterval = refreshInterval;
            _updater.Changed += UpdaterOnChanged;
        }

        private void UpdaterOnChanged(TUpdatableFeature feature)
        {
            Changed?.Invoke(feature);
        }

        public int RefreshInterval
        {
            get { return _refreshInterval.Value; }
            set
            {
                _refreshInterval.Value = value;
                _updater.RefreshInterval = value;
            }
        }

        public void Start()
        {
            _updater.Start();
        }

        public void Stop()
        {
            _updater.Stop();
        }

        public void Release()
        {
            _updater.Changed -= UpdaterOnChanged;
        }

        public void AddSignal(Signal<TUpdatableFeature> signal)
        {
            _updater.AddSignal(signal);
        }

        public void RemoveSignal(Signal<TUpdatableFeature> signal)
        {
            _updater.RemoveSignal(signal);
        }

        public void ImmediatelyUpdateIfOlder(TimeInterval refreshInterval)
        {
            _updater.ImmediatelyUpdateIfOlder(refreshInterval);
        }

        public void UpdateNow()
        {
            _updater.UpdateNow();
        }

        public TUpdatableFeature LastValue => _updater.LastValue;

        public TOwnerFeature OwnerFeature => _updater.OwnerFeature;

        public object Parameters
        {
            get { return _updater.Parameters; }
            set { _updater.Parameters = value; }
        }

        public event Action<TUpdatableFeature> Changed;
    }
}
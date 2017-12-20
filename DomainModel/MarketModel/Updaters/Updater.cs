using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DomainModel.Misc;

namespace DomainModel.MarketModel.Updaters
{
    internal abstract class Updater<TUpdatableFeature, TOwnerFeature>
    {
        private readonly Timer _timer;
        private int _refreshInterval;
        private bool _isActive;

        protected Updater(int refreshInterval)
        {
            _timer = new Timer(TimerCallback);

            RefreshInterval = refreshInterval;
        }

        public object Parameters { get; set; }

        public TOwnerFeature OwnerFeature { get; protected set; }

        public int RefreshInterval
        {
            get { return _refreshInterval; }
            set
            {
                if (value == _refreshInterval)
                    return;

                _refreshInterval = value;
                ChangeTimer();
            }
        }

        private bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                if (value == _isActive)
                    return;

                _isActive = value;
                ChangeTimer();
            }
        }

        public TUpdatableFeature LastValue { get; private set; }

        private void TimerCallback(object state)
        {
            UpdateNowAsync();
        }

        protected abstract TUpdatableFeature UpdateFeature();

        private void ChangeTimer()
        {
            _timer.Change(_isActive ? 0 : Timeout.Infinite, RefreshInterval);
        }

        public void Start()
        {
            IsActive = true;
        }

        public void Stop()
        {
            IsActive = false;
        }

        public event Action<TUpdatableFeature> Changed;

        public void AddSignal(Signal<TUpdatableFeature> signal)
        {
            _signals.Add(signal);
        }

        public void RemoveSignal(Signal<TUpdatableFeature> signal)
        {
            _signals.Remove(signal);
        }

        private readonly List<Signal<TUpdatableFeature>> _signals = new List<Signal<TUpdatableFeature>>();

        protected void OnChanged(TUpdatableFeature feature)
        {
            LastValue = feature;
            _lastTimeStamp = DateTime.Now;

            _signals.Where(s => s.IsActive).ForEach(s => s.Check(feature));

            Changed?.Invoke(feature);
        }

        private DateTime? _lastTimeStamp;

        public void ImmediatelyUpdateIfOlder(TimeInterval refreshInterval)
        {
            if (!_lastTimeStamp.HasValue ||
                (DateTime.Now - _lastTimeStamp.Value).Milliseconds > refreshInterval.Value)
                UpdateNowAsync();
        }

        public async void UpdateNowAsync()
        {
            await UpdateFeatureAsync();
        }

        public TUpdatableFeature UpdateNow()
        {
            return UpdateFeature();
        }

        private Task UpdateFeatureAsync()
        {
            return Task.Run(() =>
            {
                UpdateFeature();
            });
        }
    }
}
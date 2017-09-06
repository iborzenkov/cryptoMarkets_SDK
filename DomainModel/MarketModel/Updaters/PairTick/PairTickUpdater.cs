using DomainModel.Features;
using System;
using System.Threading;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    public class PairTickUpdater : IPairTickUpdater
    {
        private const int DefaultRefreshInterval = 5 * 60 * 1000; // once an 5 minutes

        private readonly Timer _timer;
        private int _refreshInterval;
        private bool _isActive;
        private readonly IMarketInfo _marketInfo;
        private readonly Pair _pair;

        public Tick LastPairTick { get; private set; }

        public PairTickUpdater(PairOfMarket pair, int refreshInterval = DefaultRefreshInterval)
        {
            _marketInfo = pair.Market.Model.Info;
            _pair = pair.Pair;

            _timer = new Timer(TimerCallback);

            RefreshInterval = refreshInterval;
        }

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

        private void TimerCallback(object state)
        {
            LastPairTick = _marketInfo.Tick(_pair);
            OnChanged(LastPairTick);
        }

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

        public event EventHandler<Tick> Changed;

        private void OnChanged(Tick tick)
        {
            Changed?.Invoke(this, tick);
        }
    }
}
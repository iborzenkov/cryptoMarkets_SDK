using System;
using System.Collections.Generic;
using System.Threading;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    public class PairStatisticUpdater : IPairStatisticUpdater
    {
        private const int DefaultRefreshInterval = 1 * 60 * 60 * 1000; // once an hour

        private readonly Timer _timer;
        private int _refreshInterval;
        private bool _isActive;
        private readonly IMarketInfo _marketInfo;

        public PairStatisticUpdater(IMarketInfo marketInfo, int refreshInterval = DefaultRefreshInterval)
        {
            _marketInfo = marketInfo;

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
            var pairsStatistic = _marketInfo.PairsStatistic();
            OnChanged(pairsStatistic);
        }

        private void ChangeTimer()
        {
            _timer.Change(_isActive ? 0 : Timeout.Infinite, RefreshInterval);
        }

        void IPairStatisticUpdater.Start()
        {
            IsActive = true;
        }

        void IPairStatisticUpdater.Stop()
        {
            IsActive = false;
        }

        public event EventHandler<IEnumerable<Features.PairStatistic>> Changed;

        private void OnChanged(IEnumerable<Features.PairStatistic> pairsStatistic)
        {
            Changed?.Invoke(this, pairsStatistic);
        }
    }
}
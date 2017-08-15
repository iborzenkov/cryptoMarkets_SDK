using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DomainModel.MarketModel.Updaters.Balance
{
    public class BalanceUpdater : IBalanceUpdater
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly Timer _timer;
        private int _refreshInterval;
        private bool _isActive;
        private readonly IAccountInfo _accountInfo;
        private readonly CurrencyOfMarket _currency;

        public BalanceUpdater(CurrencyOfMarket currency, IAccountInfo accountInfo, int refreshInterval = DefaultRefreshInterval)
        {
            _currency = currency;
            _accountInfo = accountInfo;

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
            var balance = _accountInfo.Balance(_currency);
            OnChanged(balance);
        }

        private void ChangeTimer()
        {
            _timer.Change(_isActive ? 0 : Timeout.Infinite, RefreshInterval);
        }

        void IBalanceUpdater.Start()
        {
            IsActive = true;
        }

        void IBalanceUpdater.Stop()
        {
            IsActive = false;
        }

        void IBalanceUpdater.AddSignal(BalanceSignal signal)
        {
            _signals.Add(signal);
        }

        void IBalanceUpdater.RemoveSignal(BalanceSignal signal)
        {
            _signals.Remove(signal);
        }

        private readonly List<BalanceSignal> _signals = new List<BalanceSignal>();

        public event EventHandler<Features.Balance> Changed;

        private void OnChanged(Features.Balance balance)
        {
            _signals.Where(s => s.IsActive).ForEach(s => s.Check(balance));

            Changed?.Invoke(this, balance);
        }
    }
}
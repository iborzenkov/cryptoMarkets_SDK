using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public class OrderBookUpdater : IOrderBookUpdater
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly Timer _timer;
        private int _refreshInterval;
        private bool _isActive;
        private readonly IMarketInfo _marketInfo;
        private readonly PairOfMarket _pair;

        public OrderBookUpdater(PairOfMarket pair, IMarketInfo marketInfo, int refreshInterval = DefaultRefreshInterval)
        {
            _pair = pair;
            _marketInfo = marketInfo;

            _timer = new Timer(TimerCallback);
            //_timer = new Timer();
            //_timer.Elapsed += Timer_Elapsed;

            RefreshInterval = refreshInterval;
        }

        /*private void Timer_Elapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var orderBook = _marketInfo.OrderBook(_pair.Pair, Depth, OrderBookType);
            OnChanged(orderBook);
        }*/

        public int Depth { get; set; } = 50;
        public OrderBookType OrderBookType { get; set; } = OrderBookType.Both;

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
            var orderBook = _marketInfo.OrderBook(_pair.Pair, Depth, OrderBookType);
            OnChanged(orderBook);
        }

        private void ChangeTimer()
        {
            _timer.Change(_isActive ? 0 : Timeout.Infinite, RefreshInterval);
            //_timer.Enabled = IsActive;
            //_timer.Interval = RefreshInterval;
        }

        void IOrderBookUpdater.Start()
        {
            IsActive = true;
        }

        void IOrderBookUpdater.Stop()
        {
            IsActive = false;
        }

        void IOrderBookUpdater.AddSignal(OrderBookSignal signal)
        {
            _signals.Add(signal);
        }

        void IOrderBookUpdater.RemoveSignal(OrderBookSignal signal)
        {
            _signals.Remove(signal);
        }

        private readonly List<OrderBookSignal> _signals = new List<OrderBookSignal>();

        public event EventHandler<IOrderBook> Changed;

        private void OnChanged(IOrderBook orderBook)
        {
            _signals.Where(s => s.IsActive).ForEach(s => s.Check(orderBook));

            Changed?.Invoke(this, orderBook);
        }
    }
}
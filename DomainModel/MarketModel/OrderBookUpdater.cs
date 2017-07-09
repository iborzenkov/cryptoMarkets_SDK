using DomainModel.Features;
using System;
using System.Threading;

namespace DomainModel.MarketModel
{
    public class OrderBookUpdater : IOrderBookUpdater
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly Timer _timer;
        private int _refreshInterval;
        private bool _isActive;
        readonly IMarketInfo _marketInfo;
        private readonly PairOfMarket _pair;

        public OrderBookUpdater(PairOfMarket pair, IMarketInfo marketInfo, int refreshInterval = DefaultRefreshInterval)
        {
            _pair = pair;
            _marketInfo = marketInfo;

            RefreshInterval = refreshInterval;

            _timer = new Timer(TimerCallback);
        }

        public int Depth { get; set; } = 10;
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
        }

        public void Start()
        {
            IsActive = true;
        }

        public void Stop()
        {
            IsActive = false;
        }

        public event EventHandler<OrderBook> Changed;

        private void OnChanged(OrderBook orderBook)
        {
            Changed?.Invoke(this, orderBook);
        }
    }
}
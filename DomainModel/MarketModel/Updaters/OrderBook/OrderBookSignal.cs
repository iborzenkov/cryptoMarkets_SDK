using System;

namespace DomainModel.MarketModel.Updaters.OrderBook
{
    public class OrderBookSignal
    {
        private readonly Func<IOrderBook, bool> _condition;
        private readonly Action _action;

        public OrderBookSignal(Func<IOrderBook, bool> condition, Action action)
        {
            _condition = condition;
            _action = action;

            IsActive = true;
        }

        public bool IsActive { get; set; }

        public void Check(IOrderBook orderBook)
        {
            if (_condition(orderBook))
                _action.Invoke();
        }
    }
}
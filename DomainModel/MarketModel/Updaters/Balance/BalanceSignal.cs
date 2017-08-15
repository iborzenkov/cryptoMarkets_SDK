using System;

namespace DomainModel.MarketModel.Updaters.Balance
{
    public class BalanceSignal
    {
        private readonly Func<Features.Balance, bool> _condition;
        private readonly Action _action;

        public BalanceSignal(Func<Features.Balance, bool> condition, Action action)
        {
            _condition = condition;
            _action = action;

            IsActive = true;
        }

        public bool IsActive { get; set; }

        public void Check(Features.Balance balance)
        {
            if (_condition(balance))
                _action.Invoke();
        }
    }
}
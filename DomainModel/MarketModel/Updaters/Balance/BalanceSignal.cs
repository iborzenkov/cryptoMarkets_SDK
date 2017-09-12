using System;

namespace DomainModel.MarketModel.Updaters.Balance
{
    public class BalanceSignal : Signal<Features.Balance>
    {
        public BalanceSignal(Func<Features.Balance, bool> condition, Action action) : base(condition, action)
        {
        }
    }
}
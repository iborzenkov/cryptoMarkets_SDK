using System;

namespace DomainModel.MarketModel.Updaters
{
    public abstract class Signal<TFeature>
    {
        private readonly Func<TFeature, bool> _condition;
        private readonly Action _action;

        protected Signal(Func<TFeature, bool> condition, Action action)
        {
            _condition = condition;
            _action = action;

            IsActive = true;
        }

        public bool IsActive { get; set; }

        public void Check(TFeature feature)
        {
            if (_condition(feature))
                _action.Invoke();
        }
    }
}
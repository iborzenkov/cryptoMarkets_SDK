using System;

namespace DomainModel.Strategies
{
    public class StrategyDataUpdater : IStrategyDataUpdater
    {
        public bool Active { get; set; }

        protected StrategySettings Settings { get; private set; }
        public void SetSettings(StrategySettings settings)
        {
            Settings = settings;
        }

        public event Action Changed;

        protected virtual void OnChanged()
        {
            Changed?.Invoke();
        }
    }
}
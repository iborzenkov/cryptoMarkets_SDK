using System;

namespace DomainModel.Strategies
{
    public abstract class Strategy
    {
        protected IStrategyDataUpdater Updater;

        private bool _active;

        protected Strategy()
        {
            MakeUpdater();

        }

        protected abstract void MakeUpdater();

        // DataUpdater(Market market, Pair pair, int Period)
        public bool Active

        {
            get { return _active; }
            set
            {
                _active = value;
                Updater.Active = value;
            }
        }

        public event Action SignalOccured;
        public event Action SignalUpdated;
        public event Action SignalDisappear;
    }
}
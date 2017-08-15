using System;

namespace DomainModel.MarketModel.Updaters.Balance
{
    public interface IBalanceUpdater
    {
        int RefreshInterval { get; set; }

        void Start();

        void Stop();

        void AddSignal(BalanceSignal signal);
        void RemoveSignal(BalanceSignal signal);

        event EventHandler<Features.Balance> Changed;
    }
}
using System;
using System.Threading.Tasks;

namespace DomainModel.MarketModel.Updaters
{
    public interface IUpdater<TUpdatableFeature, out TOwnerFeature>
    {
        int RefreshInterval { get; set; }

        void Start();

        void Stop();

        void Release();

        void AddSignal(Signal<TUpdatableFeature> signal);

        void RemoveSignal(Signal<TUpdatableFeature> signal);

        void ImmediatelyUpdateIfOlder(TimeInterval refreshInterval);
        void UpdateNow();

        TUpdatableFeature LastValue { get; }

        TOwnerFeature OwnerFeature { get; }

        object Parameters { get; set; }

        event Action<TUpdatableFeature> Changed;
    }
}
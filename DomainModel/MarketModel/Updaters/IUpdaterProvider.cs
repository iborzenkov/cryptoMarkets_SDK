namespace DomainModel.MarketModel.Updaters
{
    public interface IUpdaterProvider<TUpdatableFeature, TOwnerFeature>
    {
        IUpdater<TUpdatableFeature, TOwnerFeature> GetUpdater(TOwnerFeature owner, RefreshInterval refreshInterval);

        void ReleaseUpdater(IUpdater<TUpdatableFeature, TOwnerFeature> updater);
    }
}
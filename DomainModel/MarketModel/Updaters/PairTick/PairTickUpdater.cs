using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.PairTick
{
    internal class PairTickUpdater : Updater<Tick, PairOfMarket>
    {
        private const int DefaultRefreshInterval = 5 * 60 * 1000; // once an 5 minutes

        private readonly IMarketInfo _marketInfo;

        public PairTickUpdater(PairOfMarket pair, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = pair;
            _marketInfo = OwnerFeature.Market.Model.Info;
        }

        protected override void OnTimer()
        {
            OnChanged(_marketInfo.Tick(OwnerFeature.Pair));
        }
    }
}
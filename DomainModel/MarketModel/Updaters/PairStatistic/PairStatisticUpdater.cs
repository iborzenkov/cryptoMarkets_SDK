using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    internal class PairStatisticUpdater : Updater<ICollection<Features.PairStatistic>, Market>
    {
        private const int DefaultRefreshInterval = 30 * 1000;

        private readonly IMarketInfo _marketInfo;

        public PairStatisticUpdater(Market market, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = market;
            _marketInfo = OwnerFeature.Model.Info;
        }

        protected override ICollection<Features.PairStatistic> UpdateFeature()
        {
            var result = _marketInfo.PairsStatistic();
            OnChanged(result);
            return result;
        }
    }
}
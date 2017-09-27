using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.PairStatistic
{
    internal class PairStatisticUpdater : Updater<ICollection<Features.Pair24HoursStatistic>, Market>
    {
        private const int DefaultRefreshInterval = 30 * 1000;

        private readonly IMarketInfo _marketInfo;

        public PairStatisticUpdater(Market market, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = market;
            _marketInfo = OwnerFeature.Model.Info;
        }

        protected override ICollection<Features.Pair24HoursStatistic> UpdateFeature()
        {
            var result = _marketInfo.Pairs24HoursStatistic();
            OnChanged(result);
            return result;
        }
    }
}
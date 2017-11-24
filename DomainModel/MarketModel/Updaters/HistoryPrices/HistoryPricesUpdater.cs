using System.Collections.Generic;
using System.Linq;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.HistoryPrices
{
    internal class HistoryPricesUpdater : Updater<ICollection<HistoryPrice>, HistoryPriceFeature>
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly IMarketInfo _marketInfo;

        public HistoryPricesUpdater(HistoryPriceFeature feature, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = feature;
            _marketInfo = OwnerFeature.Pair.Market.Model.Info;
        }

        protected override ICollection<HistoryPrice> UpdateFeature()
        {
            var result = _marketInfo.MarketHistoryData(OwnerFeature.Pair.Pair, OwnerFeature.Timeframe, OwnerFeature.StartTime);
            var prices = result as HistoryPrice[] ?? result.ToArray();

            OnChanged(prices);
            return prices;
        }
    }
}
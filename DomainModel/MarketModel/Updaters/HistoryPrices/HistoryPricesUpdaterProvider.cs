using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.HistoryPrices
{
    internal class HistoryPricesUpdaterProvider : UpdaterProvider<ICollection<HistoryPrice>, HistoryPriceFeature>, IHistoryPricesUpdaterProvider
    {
        protected override Updater<ICollection<HistoryPrice>, HistoryPriceFeature> MakeUpdater(HistoryPriceFeature owner)
        {
            return new HistoryPricesUpdater(owner);
        }
    }
}
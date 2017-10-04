using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.HistoryPrices
{
    public interface IHistoryPricesUpdaterProvider : IUpdaterProvider<ICollection<HistoryPrice>, HistoryPriceFeature>
    {
    }
}
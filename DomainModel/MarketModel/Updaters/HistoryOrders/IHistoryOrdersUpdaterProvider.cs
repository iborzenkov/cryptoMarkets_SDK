using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.HistoryOrders
{
    public interface IHistoryOrdersUpdaterProvider : IUpdaterProvider<IEnumerable<HistoryOrder>, Market>
    {
    }
}
using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.HistoryOrders
{
    internal class HistoryOrdersUpdaterProvider : UpdaterProvider<IEnumerable<HistoryOrder>, Market>, IHistoryOrdersUpdaterProvider
    {
        protected override Updater<IEnumerable<HistoryOrder>, Market> MakeUpdater(Market owner)
        {
            return new HistoryOrdersUpdater(owner);
        }
    }
}
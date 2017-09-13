using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.OpenedOrders
{
    internal class OpenedOrdersUpdaterProvider : UpdaterProvider<IEnumerable<Order>, Market>, IOpenedOrdersUpdaterProvider
    {
        protected override Updater<IEnumerable<Order>, Market> MakeUpdater(Market owner)
        {
            return new OpenedOrdersUpdater(owner);
        }
    }
}
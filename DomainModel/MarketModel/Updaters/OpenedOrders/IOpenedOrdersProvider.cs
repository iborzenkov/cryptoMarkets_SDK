using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.OpenedOrders
{
    public interface IOpenedOrdersUpdaterProvider : IUpdaterProvider<IEnumerable<Order>, Market>
    {
    }
}
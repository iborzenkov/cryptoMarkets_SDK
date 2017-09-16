using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel
{
    public interface IAccountInfo
    {
        IEnumerable<Balance> Balances(Market market);

        Balance Balance(Market market, Currency currency);

        Balance Balance(CurrencyOfMarket currency);

        IEnumerable<Order> OpenedOrders(Market market, Pair pair);

        IEnumerable<Order> OpenedOrders(Market market);
    }
}
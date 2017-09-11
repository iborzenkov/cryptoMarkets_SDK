using DomainModel.Features;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IPendingTradeModel
    {
        IEnumerable<Market> Markets { get; }
        IEnumerable<Order> OpenedOrders { get; }

        void NeedOrderBookOf(PairOfMarket pair);

        void NeedBalanceOf(CurrencyOfMarket currency);
        double Available(Currency currency);
        double Price(Currency currency);
    }
}
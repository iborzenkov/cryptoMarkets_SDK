using DomainModel.Features;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface ITradeModel
    {
        IEnumerable<Market> Markets { get; }

        void NeedOrderBookOf(PairOfMarket pair);

        void NeedBalanceOf(CurrencyOfMarket currency);
    }
}
﻿using DomainModel.Features;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IMarketTradeModel
    {
        IEnumerable<Market> Markets { get; }

        void NeedOrderBookOf(PairOfMarket pair);

        void NeedBalanceOf(CurrencyOfMarket currency);
    }
}
﻿using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IOrderBookModel
    {
        IEnumerable<Market> Markets { get; }

        void NeedOrderBookOf(PairOfMarket pair);

        OrderBookSettings OrderBookSettings { get; set; }

        void Release();

        event EventHandler<IOrderBook> OrderBookChanged;
    }
}
using DomainModel.Features;
using System;
using System.Collections.Generic;
using Models;

namespace Views.Interfaces
{
    public interface ITradingHistoryView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetPairs(IEnumerable<Pair> pairs);

        void SetHistoryOrders(IEnumerable<HistoryOrder> orders);

        void SetFilter(HistoryOrdersFilter filter);

        void SetUsdRate(GetUsdRateDelegate getUsdRate);

        event Action<HistoryOrdersFilter> FilterChanged;
    }
}
using System;
using DomainModel.Features;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.MarketModel
{
    public class OrdersToBars
    {
        TimeframeType _timeframe;

        public OrdersToBars(TimeframeType timeframe)
        {
            _timeframe = timeframe;
        }

        public IEnumerable<Bar> ToBars(IEnumerable<Order> orders)
        {
            var bars = new List<Bar>();

            var sorted = orders.ToList();
            sorted.Sort(OrderComparison);

            // todo: закончить

            return bars;
        }

        private int OrderComparison(Order order1, Order order2)
        {
            if (!order1.Opened.HasValue && order2.Opened.HasValue)
                return -1;
            if (order1.Opened.HasValue && !order2.Opened.HasValue)
                return 1;
            if (!order1.Opened.HasValue && !order2.Opened.HasValue)
                return 0;

            return order1.Opened.Value.CompareTo(order2.Opened.Value);
        }
    }
}
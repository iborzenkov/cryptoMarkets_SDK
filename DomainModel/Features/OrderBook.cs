using System;
using System.Collections.Generic;

namespace DomainModel.Features
{
    public class OrderBook
    {
        public Pair Pair { get; }

        public OrderBookSort AskSorting { get; set; } = OrderBookSort.Decrease;
        public OrderBookSort BidSorting { get; set; } = OrderBookSort.Decrease;

        private readonly List<OrderBookPart> _bids = new List<OrderBookPart>();
        private readonly List<OrderBookPart> _asks = new List<OrderBookPart>();

        public IReadOnlyCollection<OrderBookPart> Bids => _bids.AsReadOnly();

        public IReadOnlyCollection<OrderBookPart> Asks => _asks.AsReadOnly();

        public OrderBook(Pair pair)
        {
            Pair = pair;
        }

        public void ReplaceBids(IEnumerable<OrderBookPart> bids)
        {
            Replace(_bids, bids, BidSorting);
        }

        public void ReplaceAsk(IEnumerable<OrderBookPart> asks)
        {
            Replace(_asks, asks, AskSorting);
        }

        private void Replace(List<OrderBookPart> collection, IEnumerable<OrderBookPart> data, OrderBookSort sorting)
        {
            collection.Clear();
            collection.AddRange(data);

            IComparer<OrderBookPart> comparer;
            switch (sorting)
            {
                case OrderBookSort.Increase:
                    comparer = new OrderBookPartComparerIncrease();
                    break;

                case OrderBookSort.Decrease:
                    comparer = new OrderBookPartComparerDecrease();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(sorting), sorting, null);
            }
            collection.Sort(comparer);
        }
    }

    internal class OrderBookPartComparerDecrease : IComparer<OrderBookPart>
    {
        public int Compare(OrderBookPart x, OrderBookPart y)
        {
            if (x == null && y == null)
                return 0;
            if (x != null && y == null)
                return +1;
            if (x == null && y != null)
                return -1;
            return y.Price.CompareTo(x.Price);
        }
    }

    internal class OrderBookPartComparerIncrease : IComparer<OrderBookPart>
    {
        public int Compare(OrderBookPart x, OrderBookPart y)
        {
            if (x == null && y == null)
                return 0;
            if (x != null && y == null)
                return -1;
            if (x == null && y != null)
                return +1;
            return x.Price.CompareTo(y.Price);
        }
    }

    public class OrderBookPart
    {
        public double Price { get; }

        public double Quantity { get; }

        public OrderBookPart(double price, double quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"{Price} ({Quantity})";
        }
    }
}
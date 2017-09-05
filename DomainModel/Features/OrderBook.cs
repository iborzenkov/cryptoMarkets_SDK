using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace DomainModel.Features
{
    public class OrderBook : IOrderBook
    {
        public Pair Pair { get; }

        public OrderBookSort AskSorting { get; set; } = OrderBookSort.Increase;
        public OrderBookSort BidSorting { get; set; } = OrderBookSort.Increase;

        private List<OrderBookPart> InternalBids { get; } = new List<OrderBookPart>();
        private List<OrderBookPart> InternalAsks { get; } = new List<OrderBookPart>();

        IEnumerable<OrderBookPart> IOrderBook.Bids => InternalBids;
        IEnumerable<OrderBookPart> IOrderBook.Asks => InternalAsks;

        public OrderBook(Pair pair)
        {
            Pair = pair;
        }

        public void ReplaceBids(IEnumerable<OrderBookPart> bids)
        {
            Replace(InternalBids, bids, BidSorting);
        }

        public void ReplaceAsk(IEnumerable<OrderBookPart> asks)
        {
            Replace(InternalAsks, asks, AskSorting);
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
            return x.Price.CompareTo(y.Price);
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
            return y.Price.CompareTo(x.Price);
        }
    }

    public class OrderBookPart
    {
        public double Price { get; private set; }

        public double Quantity { get; }

        public double SumQuantity { get; set; }

        public OrderBookPart(double price, double quantity)
        {
            Price = price;
            Quantity = quantity;
        }

        public void Multiplier(int multiplier)
        {
            Price = Price * multiplier;
        }

        public override string ToString()
        {
            return $"{Price} ({Quantity})";
        }
    }
}
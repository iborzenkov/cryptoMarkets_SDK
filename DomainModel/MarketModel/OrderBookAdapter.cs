using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.MarketModel
{
    public class OrderBookAdapter : IOrderBook
    {
        private IOrderBook _orderBook;
        private int _depth;
        private OrderBookType _type;
        private int _multiplier;

        private IList<OrderBookPart> InternalBids { get; set; }
        private IList<OrderBookPart> InternalAsks { get; set; }

        public IEnumerable<OrderBookPart> Bids => InternalBids ?? (InternalBids = GetBids(_orderBook.Bids));
        public IEnumerable<OrderBookPart> Asks => InternalAsks ?? (InternalAsks = GetAsks(_orderBook.Asks));

        public IEnumerable<int> LargeBidsIndexes
        {
            get
            {
                var result = new List<int>();
                
                return result;
            }
        }

        public IEnumerable<int> LargeAsksIndexes
        {
            get
            {
                var result = new List<int>();
                return result;
            }
        }

        private IList<OrderBookPart> GetBids(IEnumerable<OrderBookPart> bids)
        {
            var copyBids = bids.Select(bid => new OrderBookPart(bid.Price, bid.Quantity)).ToList();
            return SumBids(MultiplierPrice(TruncateBids(FilterBids(copyBids))));
        }

        private IList<OrderBookPart> GetAsks(IEnumerable<OrderBookPart> asks)
        {
            var copyAsks = asks.Select(ask => new OrderBookPart(ask.Price, ask.Quantity)).ToList();
            return SumAsks(MultiplierPrice(TruncateAsks(FilterAsks(copyAsks))));
        }

        private IList<OrderBookPart> FilterBids(IList<OrderBookPart> bids)
        {
            if (Type == OrderBookType.Buy)
                bids.Clear();
            return bids;
        }

        private IList<OrderBookPart> SumAsks(IList<OrderBookPart> asks)
        {
            for (var i = asks.Count - 1; i >= 0; i--)
            {
                var prevSum = i < asks.Count - 1 ? asks[i + 1].SumQuantity : 0;
                asks[i].SumQuantity = prevSum + asks[i].Quantity;
            }

            return asks;
        }

        private IList<OrderBookPart> SumBids(IList<OrderBookPart> bids)
        {
            for (var i = 0; i < bids.Count; i++)
            {
                var prevSum = i > 0 ? bids[i - 1].SumQuantity : 0;
                bids[i].SumQuantity = prevSum + bids[i].Quantity;
            }

            return bids;
        }

        private IList<OrderBookPart> FilterAsks(IList<OrderBookPart> asks)
        {
            if (Type == OrderBookType.Sell)
                asks.Clear();
            return asks;
        }

        private IList<OrderBookPart> MultiplierPrice(IList<OrderBookPart> prices)
        {
            prices.ForEach(price => price.Multiplier(Multiplier));
            return prices;
        }

        private IList<OrderBookPart> TruncateBids(IList<OrderBookPart> bids)
        {
            var count = Math.Max(0, bids.Count - Depth);
            for (var i = 1; i <= count; i++)
                bids.RemoveAt(bids.Count - 1);
            return bids;
        }

        private IList<OrderBookPart> TruncateAsks(IList<OrderBookPart> asks)
        {
            var count = Math.Max(0, asks.Count - Depth);
            for (var i = 1; i <= count; i++)
                asks.RemoveAt(0);
            return asks;
        }

        public void SetOrderBook(IOrderBook orderBook)
        {
            _orderBook = orderBook;

            ClearCache();
        }

        private void ClearCache()
        {
            InternalBids = null;
            InternalAsks = null;
        }

        public int Depth
        {
            get { return _depth; }
            set
            {
                _depth = value;
                ClearCache();
            }
        }

        public OrderBookType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                ClearCache();
            }
        }

        public int Multiplier
        {
            get { return _multiplier; }
            set
            {
                _multiplier = value;
                ClearCache();
            }
        }
    }
}
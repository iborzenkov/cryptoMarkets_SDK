using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Misc;

namespace DomainModel.MarketModel
{
    public class OrderBookAdapter : IOrderBook
    {
        private IOrderBook _orderBook;
        private int _depth;
        private OrderBookType _type;
        private int _multiplier;
        private double _largeVolumeKoef = 0.25;
        private bool _highlightLargePositions = true;

        private IList<OrderBookPart> InternalBids { get; set; }
        private IList<OrderBookPart> InternalAsks { get; set; }

        public IEnumerable<OrderBookPart> Bids => InternalBids ?? (InternalBids = GetBids(_orderBook.Bids));
        public IEnumerable<OrderBookPart> Asks => InternalAsks ?? (InternalAsks = GetAsks(_orderBook.Asks));

        private IEnumerable<int> LargeIndexes(IEnumerable<OrderBookPart> parts)
        {
            var result = new List<int>();

            if (!HighlightLargePositions)
                return result;

            var orderBookParts = parts as OrderBookPart[] ?? parts.ToArray();
            if (!orderBookParts.Any())
                return result;

            return Mathematics.LargeIndexes(orderBookParts.Select(p => p.Quantity), LargeVolumeKoef);

            /*var prices = orderBookParts.Select(b => b.Quantity).ToArray();
            var firstPercentile = Mathematics.Percentile(prices, 0.5 - LargeVolumeKoef);
            var thirdPercentile = Mathematics.Percentile(prices, 0.5 + LargeVolumeKoef);
            var diff = thirdPercentile - firstPercentile;
            var minLimit = firstPercentile - 3 * diff;
            var maxLimit = thirdPercentile + 3 * diff;

            for (var i = 0; i < orderBookParts.Length; i++)
            {
                if (orderBookParts[i].Quantity <= minLimit || orderBookParts[i].Quantity >= maxLimit)
                    result.Add(i);
            }
            return result;*/
        }

        public IEnumerable<int> LargeBidsIndexes => LargeIndexes(Bids);

        public IEnumerable<int> LargeAsksIndexes => LargeIndexes(Asks);

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

        public double LargeVolumeKoef
        {
            get { return _largeVolumeKoef; }
            set
            {
                _largeVolumeKoef = value;
                ClearCache();
            }
        }

        public bool HighlightLargePositions
        {
            get { return _highlightLargePositions; }
            set
            {
                _highlightLargePositions = value;
                ClearCache();
            }
        }
    }
}
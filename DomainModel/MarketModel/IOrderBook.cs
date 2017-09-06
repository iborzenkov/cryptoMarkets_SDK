using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel
{
    public interface IOrderBook
    {
        IEnumerable<OrderBookPart> Bids { get; }
        IEnumerable<OrderBookPart> Asks { get; }

        IEnumerable<int> LargeBidsIndexes { get; }
        IEnumerable<int> LargeAsksIndexes { get; }
    }
}
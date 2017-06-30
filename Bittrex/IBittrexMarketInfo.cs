using System.Collections.Generic;
using Bittrex.Features;
using Model;
using Model.Features;

namespace Bittrex
{
    public interface IBittrexMarketInfo : IMarketInfo
    {
        IEnumerable<MarketSummary> MarketSummaries();

        MarketSummary MarketSummaries(Pair pair);
    }
}
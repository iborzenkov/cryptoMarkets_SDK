using Model;
using Model.Features;
using System.Collections.Generic;

namespace BittrexModel
{
    internal interface IBittrexMarketInfo : IMarketInfo
    {
        IEnumerable<MarketSummary> MarketSummaries();

        MarketSummary MarketSummaries(Pair pair);
    }
}
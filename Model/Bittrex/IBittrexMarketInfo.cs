using System.Collections.Generic;
using CryptoSdk.Bittrex.Features;
using CryptoSdk.Features;

namespace CryptoSdk.Bittrex
{
    public interface IBittrexMarketInfo : IMarketInfo
    {
        IEnumerable<MarketSummary> MarketSummaries();

        MarketSummary MarketSummaries(Pair pair);
    }
}
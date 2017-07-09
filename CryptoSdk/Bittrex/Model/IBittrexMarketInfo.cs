using System.Collections.Generic;
using CryptoSdk.Bittrex.Features;
using DomainModel.Features;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    public interface IBittrexMarketInfo : IMarketInfo
    {
        IEnumerable<MarketSummary> MarketSummaries();

        MarketSummary MarketSummaries(Pair pair);
    }
}
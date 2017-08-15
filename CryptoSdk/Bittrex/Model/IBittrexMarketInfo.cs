using CryptoSdk.Bittrex.Features;
using DomainModel.Features;
using DomainModel.MarketModel;
using System.Collections.Generic;

namespace CryptoSdk.Bittrex.Model
{
    public interface IBittrexMarketInfo : IMarketInfo
    {
        ICollection<MarketSummary> MarketSummaries();

        MarketSummary MarketSummaries(Pair pair);
    }
}
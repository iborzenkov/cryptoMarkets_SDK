using System.Collections.Generic;
using CryptoSdk.Bittrex.Features;
using DomainModel.Features;
using DomainModel.MarketModel;

namespace CryptoSdk.Poloniex.Model
{
    public interface IPoloniexMarketInfo : IMarketInfo
    {
        ICollection<MarketSummary> MarketSummaries();

        MarketSummary MarketSummaries(Pair pair);
    }
}
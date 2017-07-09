using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexTrade : IMarketTrade
    {
        public IApiKey ApiKey { get; set; }
    }
}
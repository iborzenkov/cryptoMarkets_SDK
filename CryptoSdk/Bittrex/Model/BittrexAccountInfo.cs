using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexAccountInfo : IAccountInfo
    {
        public IApiKey ApiKey { get; set; }
    }
}
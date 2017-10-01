using DomainModel.MarketModel;
using DomainModel.MarketModel.ApiKeys;

namespace DomainModel.Features
{
    public enum ApiKeyRole
    {
        Info,
        Trade,
        Account,
        TradeLimit,
        TradeMarket,
        Withdraw
    }

    public class ApiKey : IApiKey
    {
        public ApiKey(string apiKey)
        {
            Key = apiKey;
        }

        public string Key { get; }

        public override string ToString()
        {
            return Key;
        }
    }

    public class Authenticator
    {
        public ApiKeyRole Role { get; }
        public IApiKey PrivateKey { get; set; }
        public IApiKey PublicKey { get; set; }

        public Authenticator(ApiKeyRole role, IApiKey privateKey, IApiKey publicKey)
        {
            Role = role;
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }
    }
}
using DomainModel.MarketModel;

namespace DomainModel.Features
{
    public class ApiKey : IApiKey
    {
        public ApiKey(string apiKey)
        {
            Key = apiKey;
        }

        public string Key { get; }
    }
}
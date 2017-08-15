using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel
{
    public interface IApiKeyProvider
    {
        IReadOnlyCollection<ApiKeyPair> ApiKeys { get; }

        void SetPrivateApiKey(ApiKeyRole role, IApiKey apiKey);

        void SetPublicApiKey(ApiKeyRole role, IApiKey apiKey);
    }
}
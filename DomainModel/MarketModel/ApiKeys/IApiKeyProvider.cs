using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel.ApiKeys
{
    public interface IApiKeyProvider
    {
        IReadOnlyCollection<Authenticator> ApiKeys { get; }

        void SetPrivateApiKey(ApiKeyRole role, IApiKey apiKey);

        void SetPublicApiKey(ApiKeyRole role, IApiKey apiKey);
    }
}
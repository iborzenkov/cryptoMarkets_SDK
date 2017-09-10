using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace Views.Interfaces
{
    public interface IApiKeyView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetSelectedMarket(Market market);

        void SetApiKeyRoles(IEnumerable<ApiKeyRole> roles);

        void SetApiKeys(ApiKeyPair apiKeyPair);

        event Action<Market> MarketChanged;

        event Action<Tuple<ApiKeyRole, IApiKey>> PrivateApiKeyChanged;

        event Action<Tuple<ApiKeyRole, IApiKey>> PublicApiKeyChanged;
    }
}
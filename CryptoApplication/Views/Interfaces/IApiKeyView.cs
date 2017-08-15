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

        event EventHandler<Market> MarketChanged;

        event EventHandler<Tuple<ApiKeyRole, IApiKey>> PrivateApiKeyChanged;

        event EventHandler<Tuple<ApiKeyRole, IApiKey>> PublicApiKeyChanged;
    }
}
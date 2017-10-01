using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using DomainModel.MarketModel.ApiKeys;

namespace Views.Interfaces
{
    public interface IApiKeyView : IView
    {
        void SetMarkets(IEnumerable<Market> markets);

        void SetApiKeyRoles(IEnumerable<ApiKeyRole> roles);

        void SetApiKeys(Authenticator authenticator);

        event Action<Market> MarketChanged;

        event Action<Tuple<ApiKeyRole, IApiKey>> PrivateApiKeyChanged;

        event Action<Tuple<ApiKeyRole, IApiKey>> PublicApiKeyChanged;
    }
}
using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IApiKeyModel
    {
        IEnumerable<Market> Markets { get; }
        Market SelectedMarket { get; set; }

        event EventHandler<IEnumerable<ApiKeyRole>> ApiKeyRolesChanged;

        event EventHandler<ApiKeyPair> ApiKeysChanged;
    }
}
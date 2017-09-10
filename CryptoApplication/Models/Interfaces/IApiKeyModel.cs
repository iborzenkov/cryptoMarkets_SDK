using DomainModel.Features;
using System;
using System.Collections.Generic;

namespace Models.Interfaces
{
    public interface IApiKeyModel
    {
        IEnumerable<Market> Markets { get; }
        Market SelectedMarket { get; set; }

        event Action<IEnumerable<ApiKeyRole>> ApiKeyRolesChanged;

        event Action<ApiKeyPair> ApiKeysChanged;
    }
}
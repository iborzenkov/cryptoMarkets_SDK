using DomainModel.Features;
using DomainModel.MarketModel.ApiKeys;
using Models.Interfaces;
using System;
using System.Collections.Generic;

namespace Models.Implementations
{
    public class ApiKeyModel : IApiKeyModel
    {
        private readonly DomainModel.IModel _domainModel;
        private Market _selectedMarket;

        public ApiKeyModel(DomainModel.IModel domainModel)
        {
            _domainModel = domainModel;
        }

        IEnumerable<Market> IApiKeyModel.Markets => _domainModel.Markets;

        Market IApiKeyModel.SelectedMarket
        {
            get { return _selectedMarket; }
            set
            {
                if (_selectedMarket == value)
                    return;

                _selectedMarket = value;

                IEnumerable<ApiKeyRole> apiKeyRoles = null;
                IEnumerable<Authenticator> apiKeys = new List<Authenticator>();
                if (_selectedMarket != null)
                {
                    apiKeyRoles = _selectedMarket.SpecifiedRoles;
                    apiKeys = ((IApiKeyProvider)_selectedMarket).ApiKeys;
                }

                ApiKeyRolesChanged?.Invoke(apiKeyRoles);
                foreach (var pair in apiKeys)
                {
                    ApiKeysChanged?.Invoke(pair);
                }
            }
        }

        public event Action<IEnumerable<ApiKeyRole>> ApiKeyRolesChanged;

        public event Action<Authenticator> ApiKeysChanged;
    }
}
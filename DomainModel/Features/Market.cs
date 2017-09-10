using DomainModel.MarketModel;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Features
{
    public class Market : IApiKeyProvider
    {
        public IMarketModel Model { get; }
        private readonly IApiKeyProvider _apiKeyProvider;

        public Market(string name, IMarketModel model, IEnumerable<ApiKeyRole> apiKeyRoles, string usdCurrencyTag)
        {
            Name = name;
            Model = model;
            UsdCurrencyTag = usdCurrencyTag;
            SpecifiedRoles = apiKeyRoles.ToArray();

            _apiKeyProvider = new ApiKeyProvider(SpecifiedRoles);
            UsdEquivalent = new UsdEquivalent(this);
        }

        private IEnumerable<PairOfMarket> _pairs;
        private IEnumerable<CurrencyOfMarket> _currencies;

        public string Name { get; }
        public IEnumerable<PairOfMarket> Pairs => _pairs ?? (_pairs = Model.Info.Pairs(this));
        public IEnumerable<CurrencyOfMarket> Currencies => _currencies ?? (_currencies = Model.Info.Currencies(this));
        public IEnumerable<Balance> Balances => Model.Account.Balances(this);

        public UsdEquivalent UsdEquivalent { get; private set; }

        public override string ToString()
        {
            return Name;
        }

        public ApiKeyRole[] SpecifiedRoles;
        IReadOnlyCollection<ApiKeyPair> IApiKeyProvider.ApiKeys => _apiKeyProvider.ApiKeys;
        public CurrencyOfMarket Usd => Currencies.FirstOrDefault(c => c.Currency.Name == UsdCurrencyTag);
        private string UsdCurrencyTag { get; }

        void IApiKeyProvider.SetPrivateApiKey(ApiKeyRole role, IApiKey apiKey)
        {
            _apiKeyProvider.SetPrivateApiKey(role, apiKey);
        }

        void IApiKeyProvider.SetPublicApiKey(ApiKeyRole role, IApiKey apiKey)
        {
            _apiKeyProvider.SetPublicApiKey(role, apiKey);
        }

        public ApiKeyPair ApiKeys(ApiKeyRole role)
        {
            return _apiKeyProvider.ApiKeys.FirstOrDefault(p => p.Role == role);
        }
    }
}
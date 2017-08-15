using DomainModel.Features;
using DomainModel.MarketModel;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Views.Interfaces;

namespace Presenters.Implementations
{
    internal class ApiKeysPresenter : BasePresenter<IApiKeyView>
    {
        private IApiKeyModel Model { get; }

        public ApiKeysPresenter(IApiKeyView view, IApiKeyModel model) : base(view)
        {
            Model = model;
            Model.ApiKeyRolesChanged += Model_ApiKeyRolesChanged;
            Model.ApiKeysChanged += Model_ApiKeysChanged;

            View.SetMarkets(Model.Markets);

            View.MarketChanged += View_MarketChanged;
            View.PrivateApiKeyChanged += View_PrivateApiKeyChanged;
            View.PublicApiKeyChanged += View_PublicApiKeyChanged;

            if (Model.Markets.Any())
                View.SetSelectedMarket(Model.Markets.First());
        }

        private void View_PrivateApiKeyChanged(object sender, Tuple<ApiKeyRole, IApiKey> apiKeyInfo)
        {
            ApiKeyProvider.SetPrivateApiKey(apiKeyInfo.Item1, apiKeyInfo.Item2);
        }

        private IApiKeyProvider ApiKeyProvider => Model.SelectedMarket;

        private void View_PublicApiKeyChanged(object sender, Tuple<ApiKeyRole, IApiKey> apiKeyInfo)
        {
            ApiKeyProvider.SetPublicApiKey(apiKeyInfo.Item1, apiKeyInfo.Item2);
        }

        private void Model_ApiKeyRolesChanged(object sender, IEnumerable<ApiKeyRole> apiKeyRoles)
        {
            View.SetApiKeyRoles(apiKeyRoles);
        }

        private void Model_ApiKeysChanged(object sender, ApiKeyPair apiKeyPairs)
        {
            View.SetApiKeys(apiKeyPairs);
        }

        private void View_MarketChanged(object sender, Market market)
        {
            Model.SelectedMarket = market;
        }
    }
}
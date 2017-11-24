using DomainModel.Features;
using DomainModel.MarketModel;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel.MarketModel.ApiKeys;
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

            View.ViewClosed += View_ViewClosed;
            View.MarketChanged += View_MarketChanged;
            View.PrivateApiKeyChanged += View_PrivateApiKeyChanged;
            View.PublicApiKeyChanged += View_PublicApiKeyChanged;
        }

        private void Release()
        {
            View.ViewClosed -= View_ViewClosed;
            View.MarketChanged -= View_MarketChanged;
            View.PrivateApiKeyChanged -= View_PrivateApiKeyChanged;
            View.PublicApiKeyChanged -= View_PublicApiKeyChanged;

            Model.ApiKeyRolesChanged -= Model_ApiKeyRolesChanged;
            Model.ApiKeysChanged -= Model_ApiKeysChanged;

            OnClosed();
        }

        private void View_ViewClosed()
        {
            Release();
        }

        private void View_PrivateApiKeyChanged(Tuple<ApiKeyRole, IApiKey> apiKeyInfo)
        {
            ApiKeyProvider.SetPrivateApiKey(apiKeyInfo.Item1, apiKeyInfo.Item2);
        }

        private IApiKeyProvider ApiKeyProvider => Model.SelectedMarket;

        private void View_PublicApiKeyChanged(Tuple<ApiKeyRole, IApiKey> apiKeyInfo)
        {
            ApiKeyProvider.SetPublicApiKey(apiKeyInfo.Item1, apiKeyInfo.Item2);
        }

        private void Model_ApiKeyRolesChanged(IEnumerable<ApiKeyRole> apiKeyRoles)
        {
            View.SetApiKeyRoles(apiKeyRoles);
        }

        private void Model_ApiKeysChanged(Authenticator authenticator)
        {
            View.SetApiKeys(authenticator);
        }

        private void View_MarketChanged(Market market)
        {
            //await MarketChangedAsync(market);
            Model.SelectedMarket = market;
        }

        private Task MarketChangedAsync(Market market)
        {
            return Task.Run(() =>
            {
                Model.SelectedMarket = market;
            });

        }
    }
}
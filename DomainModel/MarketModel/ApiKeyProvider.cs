using DomainModel.Features;
using System.Collections.Generic;
using System.Linq;

namespace DomainModel.MarketModel
{
    internal class ApiKeyProvider : IApiKeyProvider
    {
        public ApiKeyProvider(IEnumerable<ApiKeyRole> specifiedRoles)
        {
            LoadApiKeys(specifiedRoles);
        }

        private void SaveApiKeys()
        {
            foreach (var pair in _apiKeys)
            {
                var settingsName = ApiKeySettingsName(pair.Role, true);
                if (pair.PrivateKey != null)
                    Settings.Instance.Write("ApiKeys", settingsName, pair.PrivateKey.Key);
                else
                    Settings.Instance.Delete("ApiKeys", settingsName);

                settingsName = ApiKeySettingsName(pair.Role, false);
                if (pair.PublicKey != null)
                    Settings.Instance.Write("ApiKeys", settingsName, pair.PublicKey.Key);
                else
                    Settings.Instance.Delete("ApiKeys", settingsName);
            }
        }

        private void LoadApiKeys(IEnumerable<ApiKeyRole> specifiedRoles)
        {
            foreach (var role in specifiedRoles)
            {
                var privateKeyValue = Settings.Instance.Read("ApiKeys", ApiKeySettingsName(role, true));
                var publicKeyValue = Settings.Instance.Read("ApiKeys", ApiKeySettingsName(role, false));

                var privateKey = string.IsNullOrEmpty(privateKeyValue) ? null : new ApiKey(privateKeyValue);
                var publicKey = string.IsNullOrEmpty(publicKeyValue) ? null : new ApiKey(publicKeyValue);

                _apiKeys.Add(new ApiKeyPair(role, privateKey, publicKey));
            }
        }

        private string ApiKeySettingsName(ApiKeyRole role, bool isPrivateKey)
        {
            var name = isPrivateKey ? "PrivateKey" : "PublicKey";
            return ApiKeyRoleCaption.Caption(role) + name;
        }

        private readonly List<ApiKeyPair> _apiKeys = new List<ApiKeyPair>();

        IReadOnlyCollection<ApiKeyPair> IApiKeyProvider.ApiKeys => _apiKeys.AsReadOnly();

        void IApiKeyProvider.SetPrivateApiKey(ApiKeyRole role, IApiKey apiKey)
        {
            var pair = _apiKeys.FirstOrDefault(k => k.Role == role);
            if (pair == null)
                _apiKeys.Add(new ApiKeyPair(role, apiKey, null));
            else
                pair.PrivateKey = apiKey;

            SaveApiKeys();
        }

        void IApiKeyProvider.SetPublicApiKey(ApiKeyRole role, IApiKey apiKey)
        {
            var pair = _apiKeys.FirstOrDefault(k => k.Role == role);
            if (pair == null)
                _apiKeys.Add(new ApiKeyPair(role, null, apiKey));
            else
                pair.PublicKey = apiKey;

            SaveApiKeys();
        }
    }
}
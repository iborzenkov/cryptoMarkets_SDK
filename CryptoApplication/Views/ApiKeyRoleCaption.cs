using DomainModel.Features;
using System;
using System.Collections.Generic;
using Views.Localization;

namespace Views
{
    public static class ApiKeyRoleCaption
    {
        private static readonly Dictionary<ApiKeyRole, Func<string>> Captions = new Dictionary<ApiKeyRole, Func<string>>
        {
            {ApiKeyRole.Info, () => Locale.Instance.Localize("InfoApiKeyRole")},
            {ApiKeyRole.Trade, () => Locale.Instance.Localize("TradeApiKeyRole")},
            {ApiKeyRole.Account, () => Locale.Instance.Localize("AccountApiKeyRole")},
            {ApiKeyRole.TradeLimit, () => Locale.Instance.Localize("TradeLimitApiKeyRole")},
            {ApiKeyRole.TradeMarket, () => Locale.Instance.Localize("TradeMarketApiKeyRole")},
            {ApiKeyRole.Withdraw, () => Locale.Instance.Localize("WithdrawApiKeyRole")},
        };

        public static string Caption(ApiKeyRole role)
        {
            Func<string> caption;
            if (Captions.TryGetValue(role, out caption))
                return caption.Invoke();
            throw new Exception($"Compliance is not set ({role})");
        }
    }
}
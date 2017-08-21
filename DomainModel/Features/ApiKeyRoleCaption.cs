using System;
using System.Collections.Generic;

namespace DomainModel.Features
{
    public static class ApiKeyRoleCaption
    {
        private static readonly Dictionary<ApiKeyRole, string> Captions = new Dictionary<ApiKeyRole, string>
        {
            {ApiKeyRole.Info, "Info"},
            {ApiKeyRole.Trade, "Trade"},
            {ApiKeyRole.TradeLimit, "TradeLimit"},
            {ApiKeyRole.TradeMarket, "TradeMarket"},
            {ApiKeyRole.Account, "Account"},
            {ApiKeyRole.Withdraw, "Withdraw"},
        };

        public static string Caption(ApiKeyRole role)
        {
            string caption;
            if (Captions.TryGetValue(role, out caption))
                return caption;
            throw new Exception($"Compliance is not set ({role})");
        }
    }
}
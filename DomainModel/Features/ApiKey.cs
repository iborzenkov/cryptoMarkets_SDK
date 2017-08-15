using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace DomainModel.Features
{
    public enum ApiKeyRole
    {
        Info,
        Trade,
        Account,
        TradeLimit,
        TradeMarket,
        Withdraw
    }

    public class ApiKey : IApiKey
    {
        public ApiKey(string apiKey)
        {
            Key = apiKey;
        }

        public string Key { get; }

        public override string ToString()
        {
            return Key;
        }
    }

    public class ApiKeyPair
    {
        public ApiKeyRole Role { get; }
        public IApiKey PrivateKey { get; set; }
        public IApiKey PublicKey { get; set; }

        public ApiKeyPair(ApiKeyRole role, IApiKey privateKey, IApiKey publicKey)
        {
            Role = role;
            PrivateKey = privateKey;
            PublicKey = publicKey;
        }
    }

    public static class ApiKeyRoleCaption
    {
        private static readonly Dictionary<ApiKeyRole, string> Captions = new Dictionary<ApiKeyRole, string>
        {
            {ApiKeyRole.Info, "Info"},
            {ApiKeyRole.Trade, "Trade"},
            {ApiKeyRole.Account, "Account"},
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
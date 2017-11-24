using System;
using CryptoSdk.Poloniex.Connection;
using CryptoSdk.Poloniex.Features;
using DomainModel.Features;
using DomainModel.MarketModel;
using System.Collections.Generic;

namespace CryptoSdk.Poloniex.Model
{
    internal static class PoloniexMessages
    {
        private static readonly Dictionary<string, string> Messages = new Dictionary<string, string>()
        {
            { "INSUFFICIENT_FUNDS", "InsufficientFunds"},
            { "QUANTITY_NOT_PROVIDED", "QuantityNotProvided"},
            { "DUST_TRADE_DISALLOWED_MIN_VALUE_50K_SAT", "DustTradeDisallowedMinValue50KSat"},
            { "UUID_INVALID", "UUIDInvalid"},
            { "ZERO_OR_NEGATIVE_NOT_ALLOWED", "ZeroOrNegativeNotAllowed"},
            { "RATE_NOT_PROVIDED", "RateNotProvided"},
        };

        internal static string AdoptMessage(string message)
        {
            string result;
            return Messages.TryGetValue(message, out result) ? result : message;
        }
    }

    public class PoloniexModel : IMarketModel
    {
        private readonly PoloniexConnection _connection = new PoloniexConnection();

        public PoloniexModel()
        {
            ServerTimeZone = TimeZoneInfo.Utc;

            Info = new PoloniexInfo(_connection, ServerTimeZone);
            Trade = new PoloniexTrade(_connection);
            Account = new PoloniexAccountInfo(_connection);

            Fee = new PoloniexFee();
        }

        public TimeZoneInfo ServerTimeZone { get; }
        public IMarketInfo Info { get; }
        public IMarketTrade Trade { get; }
        public IAccountInfo Account { get; }

        public Fee Fee { get; }

        public string AdoptMessage(string message)
        {
            return PoloniexMessages.AdoptMessage(message);
        }
    }
}
using System.Collections.Generic;
using CryptoSdk.Bittrex.Connection;
using CryptoSdk.Bittrex.Features;
using DomainModel.Features;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    internal static class BittrexMessages
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

    public class BittrexModel : IMarketModel
    {
        private readonly BittrexConnection _connection = new BittrexConnection();
        

        public BittrexModel()
        {
            Info = new BittrexInfo(_connection);
            Trade = new BittrexTrade(_connection);
            Account = new BittrexAccountInfo(_connection);

            Fee = new BittrexFee();
        }

        public IMarketInfo Info { get; }
        public IMarketTrade Trade { get; }
        public IAccountInfo Account { get; }

        public Fee Fee { get; }

        public string AdoptMessage(string message)
        {
            return BittrexMessages.AdoptMessage(message);
        }
    }
}
using System.Collections.Generic;
using CryptoSdk.Bittrex.Connection;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    internal static class BittrexMessages
    {
        private static readonly Dictionary<string, string> Messages = new Dictionary<string, string>()
        {
            { "INSUFFICIENT_FUNDS", "InsufficientFunds"},
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
        }

        public IMarketInfo Info { get; }
        public IMarketTrade Trade { get; }
        public IAccountInfo Account { get; }

        public string AdoptMessage(string message)
        {
            return BittrexMessages.AdoptMessage(message);
        }
    }
}
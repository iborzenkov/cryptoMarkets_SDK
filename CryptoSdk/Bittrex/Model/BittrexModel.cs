using CryptoSdk.Bittrex.Connection;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
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
    }
}
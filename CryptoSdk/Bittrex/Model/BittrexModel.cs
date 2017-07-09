using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Model
{
    public class BittrexModel : IMarketModel
    {
        public IMarketInfo Info { get; } = new BittrexInfo();
        public IMarketTrade Trade { get; } = new BittrexTrade();
        public IAccountInfo Account { get; } = new BittrexAccountInfo();
    }
}
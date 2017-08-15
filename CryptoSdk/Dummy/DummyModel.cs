using DomainModel.MarketModel;

namespace CryptoSdk.Dummy
{
    public class DummyModel : IMarketModel
    {
        public DummyModel()
        {
            Info = new DummyInfo();
            Trade = new DummyTrade();
            Account = new DummyAccountInfo();
        }

        public IMarketInfo Info { get; }
        public IMarketTrade Trade { get; }
        public IAccountInfo Account { get; }
    }
}
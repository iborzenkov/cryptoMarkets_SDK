using DomainModel.MarketModel;

namespace CryptoSdk.Dummy
{
    public class DummyModel : IMarketModel
    {
        public DummyModel()
        {
            Info = new DummyInfo();
            Trade = new DummyTrade();
            Account = new DummyAccount();
        }

        public IMarketInfo Info { get; }
        public IMarketTrade Trade { get; }
        public IAccountInfo Account { get; }

        public string AdoptMessage(string message)
        {
            return message;
        }
    }
}
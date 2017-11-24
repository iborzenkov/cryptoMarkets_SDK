using System;
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
            ServerTimeZone = TimeZoneInfo.Local;
        }

        public TimeZoneInfo ServerTimeZone { get; }

        public IMarketInfo Info { get; }
        public IMarketTrade Trade { get; }
        public IAccountInfo Account { get; }

        public string AdoptMessage(string message)
        {
            return message;
        }
    }
}
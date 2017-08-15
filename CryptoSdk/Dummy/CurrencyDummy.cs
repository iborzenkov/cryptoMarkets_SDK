using DomainModel.Features;

namespace CryptoSdk.Dummy
{
    public class CurrencyDummy
    {
        public static readonly Currency Btc = new Currency("BTC", "Bitcoin");
        public static readonly Currency Ltc = new Currency("LTC", "Litecoin");
        public static readonly Currency Eth = new Currency("ETH", "Etherium");
        public static readonly Currency Doge = new Currency("DOGE", "Dogecoin");
    }
}
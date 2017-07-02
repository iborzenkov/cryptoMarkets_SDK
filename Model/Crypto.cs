using CryptoSdk.Bittrex;

namespace CryptoSdk
{
    public class Crypto
    {
        private static IBittrexMarketInfo _bittrex;

        public static IBittrexMarketInfo Bittrex => _bittrex ?? (_bittrex = new BittrexInfo());
    }
}
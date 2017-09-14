using DomainModel.Features;

namespace CryptoSdk.Dummy
{
    public class PairDummy
    {
        public static readonly Pair LtcBtc = new Pair(CurrencyDummy.Ltc, CurrencyDummy.Btc);
        public static readonly Pair EthBtc = new Pair(CurrencyDummy.Eth, CurrencyDummy.Btc);
        public static readonly Pair LtcEth = new Pair(CurrencyDummy.Ltc, CurrencyDummy.Eth);
        public static readonly Pair DogeBtc = new Pair(CurrencyDummy.Doge, CurrencyDummy.Btc);
        public static readonly Pair UsdtBtc = new Pair(CurrencyDummy.Usdt, CurrencyDummy.Btc);
        public static readonly Pair UsdtLtc = new Pair(CurrencyDummy.Usdt, CurrencyDummy.Ltc);
    }
}
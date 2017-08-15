using DomainModel.Features;

namespace CryptoSdk.Dummy
{
    public class PairDummy
    {
        public static readonly Pair BtcLtc = new Pair(CurrencyDummy.Btc, CurrencyDummy.Ltc);
        public static readonly Pair BtcEth = new Pair(CurrencyDummy.Btc, CurrencyDummy.Eth);
        public static readonly Pair EthLtc = new Pair(CurrencyDummy.Eth, CurrencyDummy.Ltc);
        public static readonly Pair BtcDoge = new Pair(CurrencyDummy.Btc, CurrencyDummy.Doge);
    }
}
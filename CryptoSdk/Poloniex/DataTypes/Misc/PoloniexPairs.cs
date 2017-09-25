using DomainModel.Features;
using System;

namespace CryptoSdk.Poloniex.DataTypes.Misc
{
    internal class PoloniexPairs
    {
        public static string AsString(Pair pair)
        {
            return $"{pair.QuoteCurrency.Name}_{pair.BaseCurrency.Name}";
        }

        public static string AsString(PairOfMarket pair)
        {
            return AsString(pair.Pair);
        }

        public static bool TryParsePair(string pairString, out Pair pair)
        {
            pair = null;

            var currencies = pairString.Split('_');
            if (currencies.Length == 2)
                // rotate pair in Poloniex
                pair = new Pair(new Currency(currencies[1]), new Currency(currencies[0]));

            return pair != null;
        }
    }
}
﻿using DomainModel.Features;

namespace CryptoSdk.Bittrex.DataTypes.Misc
{
    internal class BittrexPairs
    {
        public static string AsString(Pair pair)
        {
            return $"{pair.QuoteCurrency.Name}-{pair.BaseCurrency.Name}";
        }

        public static string AsString(PairOfMarket pair)
        {
            return AsString(pair.Pair);
        }

        public static bool TryParsePair(string pairString, out Pair pair)
        {
            pair = null;

            var currencies = pairString.Split('-');
            if (currencies.Length == 2)
                // rotate pair in Bittrex
                pair = new Pair(new Currency(currencies[1]), new Currency(currencies[0]));

            return pair != null;
        }
    }
}
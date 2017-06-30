using System;

namespace Model.Features
{
    public class Pair : IEquatable<Pair>
    {
        public Pair(Currency baseCurrency, Currency quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
        }

        /// <summary>
        /// Base currency of pair.
        /// </summary>
        /// <remarks>
        /// BTC/LTC. BTC is a base currency.
        /// </remarks>
        public Currency BaseCurrency { get; set; }

        /// <summary>
        /// Quote currency of pair.
        /// </summary>
        /// <remarks>
        /// BTC/LTC. LTC is a quote currency.
        /// </remarks>
        public Currency QuoteCurrency { get; set; }

        public static bool TryParse(string pairCaption, out Pair pair)
        {
            pair = null;

            // todo: TryParse
            /*if (string.Equals(shortName, InternalShortName(CurrencyEnum.BTC), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.BTC);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.DOGE), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.DOGE);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.LTC), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.LTC);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.USD), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.USD);
                */
            return pair != null;
        }

        public bool Equals(Pair other)
        {
            return other != null && BaseCurrency.Equals(other.BaseCurrency) && QuoteCurrency.Equals(other.QuoteCurrency);
        }

        public override string ToString()
        {
            return $"{BaseCurrency.Name}-{QuoteCurrency.Name}";
        }
    }
}
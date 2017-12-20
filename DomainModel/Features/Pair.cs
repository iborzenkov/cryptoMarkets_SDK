using System;
using System.Collections.Generic;

namespace DomainModel.Features
{
    public class Pair : IEquatable<Pair>
    {
        public Pair(Currency baseCurrency, Currency quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;

            Buy = new Buy(this);
            Sell = new Sell(this);
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

        public bool Equals(Pair other)
        {
            return other != null && BaseCurrency.Equals(other.BaseCurrency) && QuoteCurrency.Equals(other.QuoteCurrency);
        }

        public override string ToString()
        {
            return $"{BaseCurrency.Name}-{QuoteCurrency.Name}";
        }

        public bool HasCurrency(Currency currency)
        {
            return BaseCurrency.Equals(currency) || QuoteCurrency.Equals(currency);
        }

        public Buy Buy { get; }
        public Sell Sell { get; }
    }
}
using System;

namespace Model.Features
{
    public class Currency
    {
        public CurrencyEnum Enum;

        public Currency(CurrencyEnum currencyEnum)
        {
            Enum = currencyEnum;
        }

        public static bool TryParse(string shortName, out Currency currency)
        {
            currency = null;

            if (string.Equals(shortName, InternalShortName(CurrencyEnum.BTC), StringComparison.OrdinalIgnoreCase))
                currency = new Currency(CurrencyEnum.BTC);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.DOGE), StringComparison.OrdinalIgnoreCase))
                currency = new Currency(CurrencyEnum.DOGE);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.LTC), StringComparison.OrdinalIgnoreCase))
                currency = new Currency(CurrencyEnum.LTC);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.USD), StringComparison.OrdinalIgnoreCase))
                currency = new Currency(CurrencyEnum.USD);

            return currency != null;
        }

        public string Name => InternalName(Enum);
        public string ShortName => InternalShortName(Enum);

        public override string ToString()
        {
            return ShortName;
        }

        private static string InternalName(CurrencyEnum currencyEnum)
        {
            switch (currencyEnum)
            {
                case CurrencyEnum.BTC:
                    return "Bitcoin";

                case CurrencyEnum.LTC:
                    return "Litecoin";

                case CurrencyEnum.USD:
                    return "Dollars";

                case CurrencyEnum.DOGE:
                    return "Doge";

                default:
                    throw new ArgumentOutOfRangeException(nameof(currencyEnum), currencyEnum, null);
            }
        }

        private static string InternalShortName(CurrencyEnum currencyEnum)
        {
            switch (currencyEnum)
            {
                case CurrencyEnum.BTC:
                    return "BTC";

                case CurrencyEnum.LTC:
                    return "LTC";

                case CurrencyEnum.USD:
                    return "USD";

                case CurrencyEnum.DOGE:
                    return "Doge";

                default:
                    throw new ArgumentOutOfRangeException(nameof(currencyEnum), currencyEnum, null);
            }
        }
    }
}
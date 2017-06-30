namespace Model.Features
{
    public class Pair
    {
        public Pair(Currency baseCurrency, Currency quoteCurrency)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;
        }

        public Currency BaseCurrency { get; set; }
        public Currency QuoteCurrency { get; set; }

        public static bool TryParse(string pairCaption, out Pair pair)
        {
            pair = null;

            foreach (var currency in CurrencyEnum)
            {
                
            }
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.BTC), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.BTC);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.DOGE), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.DOGE);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.LTC), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.LTC);
            if (string.Equals(shortName, InternalShortName(CurrencyEnum.USD), StringComparison.OrdinalIgnoreCase))
                pair = new Pair(CurrencyEnum.USD);

            return pair != null;
        }

        public override string ToString()
        {
            return $"{BaseCurrency.ShortName}-{QuoteCurrency.ShortName}";
        }
    }
}
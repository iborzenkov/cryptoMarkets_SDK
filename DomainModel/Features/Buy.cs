namespace DomainModel.Features
{
    public class Buy
    {
        private Pair Pair { get; }

        public Buy(Pair pair)
        {
            Pair = pair;
        }

        public Currency SoldingCurrency => Pair.QuoteCurrency;
        public Currency PurchasingCurrency => Pair.BaseCurrency;
        public Currency PricedCurrency => Pair.QuoteCurrency;
        public Currency QuantitiedCurrency => Pair.BaseCurrency;
    }
}
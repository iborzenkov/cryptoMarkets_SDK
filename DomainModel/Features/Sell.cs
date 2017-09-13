namespace DomainModel.Features
{
    public class Sell
    {
        private Pair Pair { get; }

        public Sell(Pair pair)
        {
            Pair = pair;
        }

        public Currency SoldingCurrency => Pair.BaseCurrency;
        public Currency PurchasingCurrency => Pair.QuoteCurrency;
        public Currency PricedCurrency => Pair.BaseCurrency;
        public Currency QuantitiedCurrency => Pair.QuoteCurrency;
    }
}
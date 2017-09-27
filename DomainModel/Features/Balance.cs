namespace DomainModel.Features
{
    public class Balance
    {
        public Balance(Market market, Currency currency, CryptoAddress address, double available, double reserved, double pending)
        {
            Market = market;
            Currency = currency;
            Address = address;
            Reserved = reserved;
            Available = available;
            Pending = pending;
        }

        public Balance(CurrencyOfMarket currency, CryptoAddress address, double available, double reserved, double pending) 
            : this(currency.Market, currency.Currency, address, available, reserved, pending)
        {
        }

        public Currency Currency { get; }

        public Market Market { get; }

        public CryptoAddress Address { get; }

        public double Available { get; }

        public double Reserved { get; }

        public double Pending { get; }

        public double Total => Available + Reserved + Pending;
    }
}
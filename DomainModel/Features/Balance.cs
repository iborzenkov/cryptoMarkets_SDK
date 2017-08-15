namespace DomainModel.Features
{
    public class Balance
    {
        public Balance(Market market, Currency currency, CryptoAddress address, double total, double available, double pending)
        {
            Market = market;
            Currency = currency;
            Address = address;
            Total = total;
            Available = available;
            Pending = pending;
        }

        public Currency Currency { get; }

        public Market Market { get; }

        public CryptoAddress Address { get; }

        public double Total { get; }

        public double Available { get; }

        public double Pending { get; }
    }
}
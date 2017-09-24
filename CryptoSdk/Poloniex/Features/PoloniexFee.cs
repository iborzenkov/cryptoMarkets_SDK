using DomainModel.Features;

namespace CryptoSdk.Poloniex.Features
{
    public class PoloniexFee : Fee
    {
        public override double Value(Order order)
        {
            return 0.25;
        }
    }
}
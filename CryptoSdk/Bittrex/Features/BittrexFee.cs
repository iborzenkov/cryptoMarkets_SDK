using DomainModel.Features;

namespace CryptoSdk.Bittrex.Features
{
    public class BittrexFee : Fee
    {
        public override double Value(Order order)
        {
            return 0.25;
        }
    }
}
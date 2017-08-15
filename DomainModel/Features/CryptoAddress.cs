namespace DomainModel.Features
{
    public class CryptoAddress
    {
        internal string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }

        public static CryptoAddress FromString(string value)
        {
            return new CryptoAddress { Address = value };
        }
    }
}
using System.Globalization;

namespace CryptoSdk.Bittrex.Model
{
    public abstract class BaseBittrex
    {
        protected readonly IConnection Connection;

        protected NumberFormatInfo Nfi { get; } = new NumberFormatInfo { NumberDecimalSeparator = "." };

        protected BaseBittrex(IConnection connection)
        {
            Connection = connection;
        }
    }
}
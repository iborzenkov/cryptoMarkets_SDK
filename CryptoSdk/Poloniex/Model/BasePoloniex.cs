using System.Globalization;

namespace CryptoSdk.Poloniex.Model
{
    public abstract class BasePoloniex
    {
        protected readonly IConnection Connection;

        protected NumberFormatInfo Nfi { get; } = new NumberFormatInfo { NumberDecimalSeparator = "." };

        protected BasePoloniex(IConnection connection)
        {
            Connection = connection;
        }
    }
}
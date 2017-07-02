namespace CryptoSdk.Bittrex.Connection
{
    public class BittrexConnection : CryptoSdk.Connection
    {
        protected override string MainUri { get; } = EndPoints.Main;
    }
}
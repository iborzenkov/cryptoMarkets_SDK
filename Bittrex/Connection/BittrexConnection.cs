namespace Bittrex.Connection
{
    public class BittrexConnection : Model.Connection
    {
        protected override string MainUri { get; } = EndPoints.Main;
    }
}
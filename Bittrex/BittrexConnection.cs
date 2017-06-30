using Model;

namespace BittrexModel
{
    public class BittrexConnection : Connection
    {
        protected override string MainUri { get; } = EndPoints.Main;
    }
}
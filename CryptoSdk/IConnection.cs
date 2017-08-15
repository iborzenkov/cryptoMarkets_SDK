using System;

namespace CryptoSdk
{
    public interface IConnection
    {
        T PublicGetQuery<T>(string endPoint, params Tuple<string, string>[] parameters);
    }
}
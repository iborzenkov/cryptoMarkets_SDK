using DomainModel.Features;
using System;

namespace CryptoSdk
{
    public interface IConnection
    {
        T PublicGetQuery<T>(string endPoint);

        T PublicGetQuery<T>(string endPoint, Tuple<string, string> parameter);

        T PublicGetQuery<T>(string endPoint, Tuple<string, string>[] parameters);

        T PrivateGetQuery<T>(string endPoint, Authenticator keys, Tuple<string, string>[] parameters);

        T PrivatePostQuery<T>(string endPoint, Authenticator keys, Tuple<string, string>[] parameters);
    }
}
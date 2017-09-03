using System;
using DomainModel.MarketModel;

namespace CryptoSdk
{
    public interface IConnection
    {
        T PublicGetQuery<T>(string endPoint);
        T PublicGetQuery<T>(string endPoint, Tuple<string, string> getParameter);
        T PublicGetQuery<T>(string endPoint, Tuple<string, string>[] getParameters);
        T PublicGetQuery<T>(string endPoint, Tuple<string, string>[] getParameters, Tuple<string, string>[] headers);
        T PrivateGetQuery<T>(string endPoint, IApiKey secretKey, Tuple<string, string>[] getParameters);
    }
}
using System;
using DomainModel.MarketModel;

namespace CryptoSdk.Bittrex.Connection
{
    public class BittrexConnection : CryptoSdk.Connection
    {
        protected override string MainUri { get; } = EndPoints.Main;

        public override T PrivateGetQuery<T>(string endPoint, IApiKey secretKey, Tuple<string, string>[] getParameters)
        {
            var uri = $"{MainUri}{endPoint}";
            var sign = HashHmac($"{uri}{CodeGetParams(getParameters)}", secretKey.Key);

            var headers = new Tuple<string, string>("apisign", sign);

            return CallGetRequestWithJsonResponse<T>(uri, getParameters, headers);
        }
    }
}
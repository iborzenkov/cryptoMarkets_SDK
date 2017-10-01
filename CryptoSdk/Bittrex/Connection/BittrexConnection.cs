using DomainModel.Features;
using System;

namespace CryptoSdk.Bittrex.Connection
{
    public class BittrexConnection : CryptoSdk.Connection
    {
        protected override string MainUri { get; } = EndPoints.Main;

        public override T PrivateGetQuery<T>(string endPoint, Authenticator keys, Tuple<string, string>[] parameters)
        {
            var uri = $"{MainUri}{endPoint}";
            var sign = HashHmac($"{uri}{CodeGetParams(parameters)}", keys.PrivateKey.Key);

            var headers = new Tuple<string, string>("apisign", sign);

            return CallGetRequestWithJsonResponse<T>(uri, parameters, headers);
        }

        public override T PrivatePostQuery<T>(string endPoint, Authenticator keys, Tuple<string, string>[] parameters)
        {
            throw new NotSupportedException("Bittrex don't supported POST private requests");
        }
    }
}
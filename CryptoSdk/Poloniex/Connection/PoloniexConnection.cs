using DomainModel.Features;
using System;

namespace CryptoSdk.Poloniex.Connection
{
    public class PoloniexConnection : CryptoSdk.Connection
    {
        protected override string MainUri { get; } = EndPoints.Main;

        public override T PrivateGetQuery<T>(string endPoint, Authenticator keys, Tuple<string, string>[] parameters)
        {
            throw new NotSupportedException("Poloniex don't supported GET private requests");
        }

        public override T PrivatePostQuery<T>(string endPoint, Authenticator keys, Tuple<string, string>[] parameters)
        {
            var uri = $"{MainUri}{endPoint}";
            var sign = HashHmac(CodePostParams(parameters), keys.PrivateKey.Key);

            var headers = new[]
            {
                new Tuple<string, string>("Key", keys.PublicKey.Key),
                new Tuple<string, string>("Sign", sign),
            };

            return CallPostRequestWithJsonResponse<T>(uri, parameters, headers);
        }
    }
}
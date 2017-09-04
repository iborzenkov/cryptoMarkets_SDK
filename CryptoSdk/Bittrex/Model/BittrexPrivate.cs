using DomainModel.MarketModel;
using System;
using System.Collections.Generic;

namespace CryptoSdk.Bittrex.Model
{
    public abstract class BittrexPrivate : BaseBittrex
    {
        protected BittrexPrivate(IConnection connection) : base(connection)
        {
        }

        protected Tuple<string, string>[] GetParameters(IApiKey publicKey, IReadOnlyList<Tuple<string, string>> additionalParams = null)
        {
            var nonce = DateTime.Now.Ticks;

            var commonParamsCount = 2;
            var additionalParamsCount = additionalParams == null ? 0 : additionalParams.Count;
            var parameters = new Tuple<string, string>[commonParamsCount + additionalParamsCount];
            parameters[0] = Tuple.Create("apikey", publicKey.Key);
            parameters[1] = Tuple.Create("nonce", nonce.ToString());

            if (additionalParams != null)
            {
                for (int i = 0, n = commonParamsCount; i < additionalParams.Count; i++, n++)
                {
                    parameters[n] = additionalParams[i];
                }
            }

            return parameters;
        }
    }
}
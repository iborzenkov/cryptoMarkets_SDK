using System;
using DomainModel;

namespace CryptoSdk.Poloniex.DataTypes.Misc
{
    internal static class BittrexOrderBookTypeEnum
    {
        public static string AsString(this OrderBookType orderBookType)
        {
            switch (orderBookType)
            {
                case OrderBookType.Buy:
                    return "buy";

                case OrderBookType.Sell:
                    return "sell";

                case OrderBookType.Both:
                    return "both";

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderBookType), orderBookType, null);
            }
        }
    }
}
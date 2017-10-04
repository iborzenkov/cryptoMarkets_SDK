using System;
using DomainModel;

namespace CryptoSdk.Poloniex
{
    internal class PoloniexTools
    {
        internal static readonly DateTime DateTimeUnixEpochStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        internal static DateTime UnixTimeStampToDateTime(ulong unixTimeStamp)
        {
            return DateTimeUnixEpochStart.AddSeconds(unixTimeStamp);
        }

        internal static ulong DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            if (dateTime == DateTime.MinValue)
                dateTime = DateTimeUnixEpochStart;
            return (ulong)Math.Floor(dateTime.Subtract(DateTimeUnixEpochStart).TotalSeconds);
        }

        public static int TimeFrameToSeconds(TimeframeType timeframe)
        {
            switch (timeframe)
            {
                case TimeframeType.M5:
                    return 300;
                case TimeframeType.M15:
                    return 900;
                case TimeframeType.M30:
                    return 1800;
                case TimeframeType.H2:
                    return 7200;
                case TimeframeType.H4:
                    return 14400;
                case TimeframeType.D1:
                    return 86400;
                default:
                    throw new ArgumentOutOfRangeException(nameof(timeframe), timeframe, null);
            }
        }
    }
}
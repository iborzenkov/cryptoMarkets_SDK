using System;

namespace CryptoSdk
{
    internal class MarketTimeCorrector
    {
        private readonly TimeZoneInfo _serverTimeZone;

        public MarketTimeCorrector(TimeZoneInfo serverTimeZone)
        {
            _serverTimeZone = serverTimeZone;
        }

        public DateTime ToMarketTime(DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), _serverTimeZone);
        }
    }
}
using DomainModel;

namespace Models
{
    public class BlowoutVolumeSettings
    {
        public TimeframeType Timeframe { get; set; }
        public bool AutoTrade { get; set; }
        public bool SendEmailNotifications { get; set; }
        public int BalancePercentPerOneTrade { get; set; }
        public string EMail { get; set; }
        public int BarCount { get; set; }
    }
}
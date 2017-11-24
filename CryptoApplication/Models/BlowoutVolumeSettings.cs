namespace Models
{
    public class BlowoutVolumeSettings
    {
        public bool AutoTrade { get; set; }
        public bool SendEmailNotifications { get; set; }
        public int BalancePercentPerOneTrade { get; set; }
        public string EMail { get; set; }
        public double LargeVolumeKoef { get; set; }
        public bool IsShowHistoricSignals { get; set; }
    }
}
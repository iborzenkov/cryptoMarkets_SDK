namespace DomainModel.MarketModel.Updaters
{
    public class RefreshInterval
    {
        public static RefreshInterval InMilliseconds(int milliseconds)
        {
            return new RefreshInterval { Value = milliseconds };
        }

        public static RefreshInterval InSeconds(int seconds)
        {
            return InMilliseconds(seconds * 1000);
        }

        public static RefreshInterval InMinutes(int minutes)
        {
            return InSeconds(minutes * 60);
        }

        public static RefreshInterval InHours(int hours)
        {
            return InMinutes(hours * 60);
        }

        public static RefreshInterval InDays(int days)
        {
            return InHours(days * 24);
        }

        public int Value { get; set; }
    }
}
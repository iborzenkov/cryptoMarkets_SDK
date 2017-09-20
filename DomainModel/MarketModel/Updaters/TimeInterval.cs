namespace DomainModel.MarketModel.Updaters
{
    public class TimeInterval
    {
        public static TimeInterval InMilliseconds(int milliseconds)
        {
            return new TimeInterval { Value = milliseconds };
        }

        public static TimeInterval InSeconds(int seconds)
        {
            return InMilliseconds(seconds * 1000);
        }

        public static TimeInterval InMinutes(int minutes)
        {
            return InSeconds(minutes * 60);
        }

        public static TimeInterval InHours(int hours)
        {
            return InMinutes(hours * 60);
        }

        public static TimeInterval InDays(int days)
        {
            return InHours(days * 24);
        }

        public int Value { get; set; }

        public static TimeInterval Never => InDays(365);
    }
}
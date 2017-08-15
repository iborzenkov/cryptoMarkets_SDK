namespace Models
{
    public enum DailyChangePairEnum
    {
        PositiveOnly,
        NegativeOnly,
        All
    }

    public class PairViewFilter
    {
        public string PairToken { get; set; }
        public bool IsActiveOnly { get; set; }
        public DailyChangePairEnum DailyChange { get; set; }
    }
}
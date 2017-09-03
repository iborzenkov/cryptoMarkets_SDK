using DomainModel.Features;

namespace DomainModel.Strategies.Volume
{
    public class VolumeStrategySettings
    {
        public VolumeStrategySettings(Market market, Pair pair, int periodMinute, int growingBarCount, int growingPercentage)
        {
            Market = market;
            Pair = pair;
            PeriodMinute = periodMinute;
            GrowingBarCount = growingBarCount;
            GrowingPercentage = growingPercentage;
        }

        public Market Market { get; }
        public Pair Pair { get; }
        public int PeriodMinute { get; }
        public int GrowingBarCount { get; }
        public int GrowingPercentage { get; }

        public static string MarketCaption = "Market";
        public static string PairCaption = "Pair";
        public static string PeriodCaption = "Period";
        private static string BarCountCaption = "BarCount";
        private static string GrowingPercentageCaption = "GrowingPercentage";

        public StrategySettings ToSettings()
        {
            var result = new StrategySettings();

            result.Add(MarketCaption, Market);
            result.Add(PairCaption, Pair);
            result.Add(PeriodCaption, PeriodMinute);
            result.Add(BarCountCaption, GrowingBarCount);
            result.Add(GrowingPercentageCaption, GrowingPercentage);

            return result;
        }

        public static VolumeStrategySettings FromSettings(StrategySettings settings)
        {
            return new VolumeStrategySettings(
                (Market)settings.Get(MarketCaption),
                (Pair)settings.Get(PairCaption),
                (int)settings.Get(PeriodCaption),
                (int)settings.Get(BarCountCaption),
                (int)settings.Get(GrowingPercentageCaption)
            );
        }
    }
}
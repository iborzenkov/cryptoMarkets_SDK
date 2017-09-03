using DomainModel.Features;

namespace DomainModel.Strategies.Volume
{
    public class VolumeStrategyDataUpdater : StrategyDataUpdater
    {
        private Market Market => (Market)Settings.Get(VolumeStrategySettings.MarketCaption);
        private Pair Pair => (Pair)Settings.Get(VolumeStrategySettings.PairCaption);
        private int Period => (int)Settings.Get(VolumeStrategySettings.PeriodCaption);
    }
}
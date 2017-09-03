namespace DomainModel.Strategies.Volume
{
    public class VolumeStrategy : Strategy
    {
        private VolumeStrategySettings _settings;

        public VolumeStrategy(StrategySettings settings)
        {
            _settings = VolumeStrategySettings.FromSettings(settings);

            Updater.SetSettings(settings);
        }

        protected override void MakeUpdater()
        {
            Updater = new VolumeStrategyDataUpdater();
        }
    }
}
namespace DomainModel.Strategies.Volume
{
    /// <summary>
    /// Проверить все пары с положительной динамикой больше порогового значения.
    /// Есть ли у них за последнее время необычные выбросы в объемах.
    /// Если есть, то покупать через лимитный ордер.
    /// </summary>
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
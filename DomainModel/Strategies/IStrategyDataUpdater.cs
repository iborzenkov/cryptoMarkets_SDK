using DomainModel.Features;

namespace DomainModel.Strategies
{
    public interface IStrategyDataUpdater
    {
        bool Active { get; set; }
        void SetSettings(StrategySettings settings);
    }
}
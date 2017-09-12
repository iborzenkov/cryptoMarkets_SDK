using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.Balance
{
    public interface IBalanceUpdaterProvider : IUpdaterProvider<Features.Balance, CurrencyOfMarket>
    {
    }
}
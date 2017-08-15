using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.Balance
{
    public interface IBalanceUpdaterProvider
    {
        IBalanceUpdater BalanceUpdater(CurrencyOfMarket currency);

        void ReleaseUpdater(IBalanceUpdater balanceUpdater);
    }
}
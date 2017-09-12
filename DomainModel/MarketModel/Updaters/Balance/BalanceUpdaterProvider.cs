using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.Balance
{
    internal class BalanceUpdaterProvider : UpdaterProvider<Features.Balance, CurrencyOfMarket>, IBalanceUpdaterProvider
    {
        protected override Updater<Features.Balance, CurrencyOfMarket> MakeUpdater(CurrencyOfMarket owner)
        {
            return new BalanceUpdater(owner);
        }
    }
}
using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.Balance
{
    public class BalanceUpdaterProvider : IBalanceUpdaterProvider
    {
        private readonly Dictionary<CurrencyOfMarket, IBalanceUpdater> _balanceUpdaters = new Dictionary<CurrencyOfMarket, IBalanceUpdater>();
        private readonly Dictionary<IBalanceUpdater, int> _balanceUpdaterReferences = new Dictionary<IBalanceUpdater, int>();

        public IBalanceUpdater BalanceUpdater(CurrencyOfMarket currency)
        {
            IBalanceUpdater updater;
            if (!_balanceUpdaters.TryGetValue(currency, out updater))
            {
                updater = new BalanceUpdater(currency, currency.Market.Model.Account);
                _balanceUpdaters.Add(currency, updater);
            }

            int references;
            if (_balanceUpdaterReferences.TryGetValue(updater, out references))
                _balanceUpdaterReferences.Remove(updater);
            _balanceUpdaterReferences.Add(updater, references + 1);

            return updater;
        }

        public void ReleaseUpdater(IBalanceUpdater updater)
        {
            if (updater == null)
                return;

            int references;
            if (_balanceUpdaterReferences.TryGetValue(updater, out references))
                _balanceUpdaterReferences.Remove(updater);

            references--;
            if (references == 0)
                updater.Stop();
            else
                _balanceUpdaterReferences.Add(updater, references);
        }
    }
}
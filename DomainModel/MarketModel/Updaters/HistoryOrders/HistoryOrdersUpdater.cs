using System.Collections.Generic;
using System.Linq;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.HistoryOrders
{
    internal class HistoryOrdersUpdater : Updater<IEnumerable<HistoryOrder>, Market>
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly IAccountInfo _accountInfo;

        public HistoryOrdersUpdater(Market market, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = market;
            _accountInfo = OwnerFeature.Model.Account;
        }

        protected override IEnumerable<HistoryOrder> UpdateFeature()
        {
            var result = _accountInfo.HistoryOrders(OwnerFeature);
            var orders = result as HistoryOrder[] ?? result.ToArray();

            OnChanged(orders);
            return orders;
        }
    }
}
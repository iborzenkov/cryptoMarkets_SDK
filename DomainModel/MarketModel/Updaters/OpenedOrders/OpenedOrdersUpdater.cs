using DomainModel.Features;
using System.Collections.Generic;

namespace DomainModel.MarketModel.Updaters.OpenedOrders
{
    internal class OpenedOrdersUpdater : Updater<IEnumerable<Order>, Market>
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly IAccountInfo _accountInfo;

        public OpenedOrdersUpdater(Market market, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = market;
            _accountInfo = OwnerFeature.Model.Account;
        }

        protected override void UpdateFeature()
        {
            OnChanged(_accountInfo.OpenedOrders(OwnerFeature));
        }
    }
}
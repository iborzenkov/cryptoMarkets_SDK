using DomainModel.Features;
using System.Collections.Generic;
using System.Linq;

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

        protected override IEnumerable<Order> UpdateFeature()
        {
            var result = _accountInfo.OpenedOrders(OwnerFeature);
            var orders = result as Order[] ?? result.ToArray();

            OnChanged(orders);
            return orders;
        }
    }
}
using System.Collections.Generic;
using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.OpenedOrders
{
    internal class OpenedOrdersUpdater : Updater<IEnumerable<Order>, Market>
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly IMarketTrade _marketTrade;

        public OpenedOrdersUpdater(Market market, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = market;
            _marketTrade = OwnerFeature.Model.Trade;
        }

        protected override void UpdateFeature()
        {
            OnChanged(_marketTrade.OpenedOrders(OwnerFeature));
        }
    }
}
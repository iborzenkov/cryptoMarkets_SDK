﻿using DomainModel.Features;

namespace DomainModel.MarketModel.Updaters.Balance
{
    internal class BalanceUpdater : Updater<Features.Balance, CurrencyOfMarket>
    {
        private const int DefaultRefreshInterval = 1000;

        private readonly IAccountInfo _accountInfo;

        public BalanceUpdater(CurrencyOfMarket currency, int refreshInterval = DefaultRefreshInterval) : base(refreshInterval)
        {
            OwnerFeature = currency;
            _accountInfo = OwnerFeature.Market.Model.Account;
        }

        protected override void UpdateFeature()
        {
            OnChanged(_accountInfo.Balance(OwnerFeature));
        }
    }
}
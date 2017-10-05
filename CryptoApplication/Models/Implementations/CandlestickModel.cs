using DomainModel.Features;
using DomainModel.MarketModel.Updaters;
using DomainModel.MarketModel.Updaters.HistoryPrices;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using DomainModel;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class CandlestickModel : ICandlestickModel
    {
        private readonly IModel _domainModel;

        public CandlestickModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        public int BarCount { get; set; } = 100;
        public event Action<IEnumerable<HistoryPrice>> GraphChanged;

        public void NeedGraphOf(PairOfMarket pair)
        {
            ResetUpdaters();

            if (pair == null)
            {
                //OrderBook = null;
                //OnOrderBookChanged();
                return;
            }

            SetUpdaters(pair);
        }

        public IEnumerable<Market> Markets => _domainModel.Markets;
        public TimeframeType? Timeframe { get; set; } = TimeframeType.M5;

        public void Release()
        {
            ResetUpdaters();
        }

        private IUpdater<ICollection<HistoryPrice>, HistoryPriceFeature> _updater;

        private IHistoryPricesUpdaterProvider HistoryPricesUpdaterProvider => _domainModel.HistoryPricesProvider;

        private readonly TimeInterval _refreshInterval = TimeInterval.InSeconds(DefaultInterval);
        private static int DefaultInterval = 60;

        private bool IsMayRunUpdater => Timeframe.HasValue;

        private void SetUpdaters(PairOfMarket pair)
        {
            if (!IsMayRunUpdater)
                return;

            _updater = HistoryPricesUpdaterProvider.GetUpdater(
                new HistoryPriceFeature(pair, Timeframe.Value, BarCount), 
                _refreshInterval);
            _updater.Changed += HistoryPriceUpdater_Changed;
            //SetUpdaterSettings();
            _updater.Start();
        }

        private void HistoryPriceUpdater_Changed(ICollection<HistoryPrice> prices)
        {
            OnGraphChanged(prices);
        }

        private void ResetUpdaters()
        {
            if (_updater != null)
            {
                HistoryPricesUpdaterProvider.ReleaseUpdater(_updater);
                _updater.Changed -= HistoryPriceUpdater_Changed;
                _updater = null;
            }
        }

        protected virtual void OnGraphChanged(IEnumerable<HistoryPrice> prices)
        {
            GraphChanged?.Invoke(prices);
        }
    }
}
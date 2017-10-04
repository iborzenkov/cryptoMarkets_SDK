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

        /*public Market SelectedMarket
        {
            get { return _selectedMarket; }
            set
            {
                if (_selectedMarket == value)
                    return;

                _selectedMarket = value;
            }
        }*/

        public event Action<IEnumerable<HistoryPrice>> GraphChanged;

        public TimeframeType Timeframe { get; set; } = TimeframeType.M5;

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

        public void Release()
        {
            ResetUpdaters();
        }

        private IUpdater<ICollection<HistoryPrice>, HistoryPriceFeature> _updater;

        private IHistoryPricesUpdaterProvider HistoryPricesUpdaterProvider => _domainModel.HistoryPricesProvider;

        private readonly TimeInterval _refreshInterval = TimeInterval.InSeconds(DefaultInterval);
        private static int DefaultInterval = 60;

        private void SetUpdaters(PairOfMarket pair)
        {
            _updater = HistoryPricesUpdaterProvider.GetUpdater(new HistoryPriceFeature(pair, Timeframe), _refreshInterval);
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
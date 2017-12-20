using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel.Updaters;
using DomainModel.MarketModel.Updaters.HistoryPrices;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DomainModel.Misc;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class BlowoutVolumeModel : IBlowoutVolumeModel
    {
        private readonly IModel _domainModel;

        public BlowoutVolumeModel(IModel domainModel)
        {
            _domainModel = domainModel;

            Settings = Default.Instance.BlowoutVolumeSettings;
        }

        private IHistoryPricesUpdaterProvider HistoryPricesProvider => _domainModel.HistoryPricesProvider;

        public IEnumerable<Market> Markets => _domainModel.Markets;

        private void ResetUpdaters()
        {
            foreach (var updater in _updaters)
            {
                HistoryPricesProvider.ReleaseUpdater(updater);
                updater.Changed -= Updater_Changed;
            }
            _updaters.Clear();
        }

        /*private void SetUpdaters(PairOfMarket pair)
        {
            _updater = HistoryPricesProvider.GetUpdater(pair, _refreshInterval);
            _updater.Changed += OrderBookUpdater_Changed;
            SetUpdaterSettings();
            _updater.Start();
        }*/

        private readonly TimeInterval _refreshInterval = TimeInterval.InMilliseconds(DefaultInterval);
        private static int DefaultInterval = 1000;

        private BlowoutVolumeSettings _settings;

        public BlowoutVolumeSettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value;
                SetUpdaterSettings();

                /*OrderBookAdapter.Depth = _settings.Depth;
                OrderBookAdapter.Type = _settings.OrderBookType;
                OrderBookAdapter.Multiplier = _settings.Multiplier;
                OrderBookAdapter.HighlightLargePositions = _settings.HighlightLargePositions;
                OrderBookAdapter.LargeVolumeKoef = _settings.LargeVolumeKoef;

                if (OrderBook != null)
                    OnOrderBookChanged();*/
            }
        }

        private void SetUpdaterSettings()
        {
            /*if (_updater == null)
                return;

            _updater.Parameters = new OrderBookUpdaterParameters(100, OrderBookType.Both);
            //_updater.RefreshInterval = OrderBookSettings.RefreshInterval;*/
        }

        public void Release()
        {
            ResetUpdaters();
        }

        private readonly Dictionary<DateTime, PairOfMarket> _pairTimeStamps = new Dictionary<DateTime, PairOfMarket>();

        private readonly List<PairOfMarket> _pairs = new List<PairOfMarket>();

        private readonly List<IUpdater<ICollection<HistoryPrice>, HistoryPriceFeature>> _updaters =
            new List<IUpdater<ICollection<HistoryPrice>, HistoryPriceFeature>>();

        private HistoryPriceFeature MakeFeature(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            return new HistoryPriceFeature(pair, timeframe, barCount);
        }

        public void IncludePairToStrategy(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            _pairs.Add(pair);
            var updater = HistoryPricesProvider.GetUpdater(MakeFeature(pair, timeframe, barCount), _refreshInterval);
            updater.Changed += Updater_Changed;
            updater.Start();
            _updaters.Add(updater);
        }

        private readonly List<PairOfMarket> _signalPairs = new List<PairOfMarket>();

        private void Updater_Changed(object sender, ICollection<HistoryPrice> historyPrices)
        {
            var updater = sender as IUpdater<ICollection<HistoryPrice>, HistoryPriceFeature>;
            Debug.Assert(updater != null);

            var pair = updater.OwnerFeature.Pair;
            var indexes = Mathematics.LargeIndexes(historyPrices.Select(p => p.Volume), Settings.LargeVolumeKoef);
            if (indexes.Any())
            {
                _signalPairs.Add(pair);
                OnSignalOccured(pair);
            }
            else
            {
                if (_signalPairs.Contains(pair))
                {
                    _signalPairs.Remove(pair);
                    OnSignalDisappeared(pair);
                }
            }
        }

        public event Action<PairOfMarket> SignalOccured;
        public event Action<PairOfMarket> SignalDisappeared;

        //public IEnumerable<PairOfMarket> ActivePairs => _pairs;

        public void ExcludePairFromStrategy(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            var updater = _updaters.FirstOrDefault(u => u.OwnerFeature == MakeFeature(pair, timeframe, barCount));
            if (updater == null)
                return;

            _pairs.Remove(pair);
            updater.Changed -= Updater_Changed;
            HistoryPricesProvider.ReleaseUpdater(updater);
            _updaters.Remove(updater);
        }

        private void OnSignalOccured(PairOfMarket pair)
        {
            SignalOccured?.Invoke(pair);
        }

        private void OnSignalDisappeared(PairOfMarket pair)
        {
            SignalDisappeared?.Invoke(pair);
        }
    }
}
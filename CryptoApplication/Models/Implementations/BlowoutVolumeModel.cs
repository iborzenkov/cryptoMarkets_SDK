using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using DomainModel.MarketModel.Updaters;
using DomainModel.MarketModel.Updaters.OrderBook;
using Models.Interfaces;
using System.Collections.Generic;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class BlowoutVolumeModel : IBlowoutVolumeModel
    {
        private readonly IModel _domainModel;

        public BlowoutVolumeModel(IModel domainModel)
        {
            _domainModel = domainModel;

            Settings = DefaultSettings.Instance.BlowoutVolumeSettings;
        }

        private IOrderBookUpdaterProvider OrderBookUpdaterProvider => _domainModel.OrderBookUpdaterProvider;

        public IEnumerable<Market> Markets => _domainModel.Markets;

        private void ResetUpdaters()
        {
            if (_updater != null)
            {
                OrderBookUpdaterProvider.ReleaseUpdater(_updater);
                //_updater.Changed -= OrderBookUpdater_Changed;
                _updater = null;
            }
        }

        /*private void SetUpdaters(PairOfMarket pair)
        {
            _updater = OrderBookUpdaterProvider.GetUpdater(pair, _refreshInterval);
            _updater.Changed += OrderBookUpdater_Changed;
            SetUpdaterSettings();
            _updater.Start();
        }*/

        private readonly TimeInterval _refreshInterval = TimeInterval.InMilliseconds(DefaultInterval);
        private static int DefaultInterval = 1000;

        private IUpdater<IOrderBook, PairOfMarket> _updater;

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
            if (_updater == null)
                return;

            _updater.Parameters = new OrderBookUpdaterParameters(100, OrderBookType.Both);
            //_updater.RefreshInterval = OrderBookSettings.RefreshInterval;
        }

        public void Release()
        {
            ResetUpdaters();
        }

        private readonly List<PairOfMarket> _pairs = new List<PairOfMarket>();

        public void IncludePairToStrategy(PairOfMarket pair)
        {
            _pairs.Add(pair);
        }

        public void ExcludePairFromStrategy(PairOfMarket pair)
        {
            _pairs.Remove(pair);
        }
    }
}
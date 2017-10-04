using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using DomainModel.MarketModel.Updaters.OrderBook;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using DomainModel.MarketModel.Updaters;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class OrderBookModel : IOrderBookModel
    {
        private readonly IModel _domainModel;

        public OrderBookModel(IModel domainModel)
        {
            _domainModel = domainModel;

            Settings = DefaultSettings.Instance.OrderBookSettings;
        }

        private IOrderBookUpdaterProvider OrderBookUpdaterProvider => _domainModel.OrderBookUpdaterProvider;

        public IEnumerable<Market> Markets => _domainModel.Markets;

        private void ResetUpdaters()
        {
            if (_updater != null)
            {
                OrderBookUpdaterProvider.ReleaseUpdater(_updater);
                _updater.Changed -= OrderBookUpdater_Changed;
                _updater = null;
            }
        }

        private void ResetUsdRate()
        {
            UsdRateChanged?.Invoke(null);
        }

        private PairOfMarket Pair { get; set; }

        private void SetUpdaters(PairOfMarket pair)
        {
            Pair = pair;

            _updater = OrderBookUpdaterProvider.GetUpdater(pair, _refreshInterval);
            _updater.Changed += OrderBookUpdater_Changed;
            SetUpdaterSettings();
            _updater.Start();
        }

        private readonly TimeInterval _refreshInterval = TimeInterval.InMilliseconds(DefaultInterval);
        private static int DefaultInterval = 1000;

        public void NeedOrderBookOf(PairOfMarket pair)
        {
            ResetUpdaters();
            ResetUsdRate();

            if (pair == null)
            {
                OrderBook = null;
                //OnOrderBookChanged();
                return;
            }

            SetUpdaters(pair);
        }

        private IUpdater<IOrderBook,PairOfMarket> _updater;

        private OrderBookSettings _settings;

        public OrderBookSettings Settings
        {
            get
            {
                return _settings;
            }
            set
            {
                _settings = value;
                SetUpdaterSettings();

                OrderBookAdapter.Depth = _settings.Depth;
                OrderBookAdapter.Type = _settings.OrderBookType;
                OrderBookAdapter.Multiplier = _settings.Multiplier;
                OrderBookAdapter.HighlightLargePositions = _settings.HighlightLargePositions;
                OrderBookAdapter.LargeVolumeKoef = _settings.LargeVolumeKoef;

                if (OrderBook != null)
                    OnOrderBookChanged();
            }
        }

        private void SetUpdaterSettings()
        {
            if (_updater == null)
                return;

            _updater.Parameters = new OrderBookUpdaterParameters(100, OrderBookType.Both);
            _updater.RefreshInterval = Settings.RefreshInterval;
        }

        private IOrderBook OrderBook { get; set; }
        private OrderBookAdapter OrderBookAdapter { get; } = new OrderBookAdapter();

        private void OrderBookUpdater_Changed(IOrderBook orderBook)
        {
            OrderBook = orderBook;
            OrderBookAdapter.SetOrderBook(OrderBook);
            OnOrderBookChanged();
        }

        public event Action<IOrderBook> OrderBookChanged;

        public event Action<double?> UsdRateChanged;

        public void Release()
        {
            ResetUpdaters();
        }

        private void OnOrderBookChanged()
        {
            OrderBookChanged?.Invoke(OrderBookAdapter);

            if (Pair != null)
                UsdRateChanged?.Invoke(Pair.Market.UsdEquivalent.UsdRate(Pair.Pair.BaseCurrency));
        }
    }
}
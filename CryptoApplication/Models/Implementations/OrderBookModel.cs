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

            OrderBookSettings = DefaultSettings.Instance.OrderBookSettings;
        }

        private IOrderBookUpdaterProvider OrderBookUpdaterProvider => _domainModel.OrderBookUpdaterProvider;

        IEnumerable<Market> IOrderBookModel.Markets => _domainModel.Markets;

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

        private PairOfMarket _pair;

        private void SetUpdaters(PairOfMarket pair)
        {
            _pair = pair;

            _updater = OrderBookUpdaterProvider.GetUpdater(pair, _refreshInterval);
            _updater.Changed += OrderBookUpdater_Changed;
            SetUpdaterSettings();
            _updater.Start();
        }

        private readonly TimeInterval _refreshInterval = TimeInterval.InMilliseconds(DefaultInterval);
        private static int DefaultInterval = 1000;

        void IOrderBookModel.NeedOrderBookOf(PairOfMarket pair)
        {
            ResetUpdaters();
            ResetUsdRate();

            if (pair == null)
            {
                OrderBook = null;
                OnOrderBookChanged();
                return;
            }

            SetUpdaters(pair);
        }

        private IUpdater<IOrderBook,PairOfMarket> _updater;

        private OrderBookSettings _orderBookSettings;

        public OrderBookSettings OrderBookSettings
        {
            get
            {
                return _orderBookSettings;
            }
            set
            {
                _orderBookSettings = value;
                SetUpdaterSettings();

                OrderBookAdapter.Depth = _orderBookSettings.Depth;
                OrderBookAdapter.Type = _orderBookSettings.OrderBookType;
                OrderBookAdapter.Multiplier = _orderBookSettings.Multiplier;
                OrderBookAdapter.HighlightLargePositions = _orderBookSettings.HighlightLargePositions;
                OrderBookAdapter.LargeVolumeKoef = _orderBookSettings.LargeVolumeKoef;

                if (OrderBook != null)
                    OnOrderBookChanged();
            }
        }

        private void SetUpdaterSettings()
        {
            if (_updater == null)
                return;

            _updater.Parameters = new OrderBookUpdaterParameters(100, OrderBookType.Both);
            _updater.RefreshInterval = OrderBookSettings.RefreshInterval;
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

            UsdRateChanged?.Invoke(_pair.Market.UsdEquivalent.UsdRate(_pair.Pair.QuoteCurrency));
        }
    }
}
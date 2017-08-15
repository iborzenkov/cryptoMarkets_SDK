using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using DomainModel.MarketModel.Updaters.OrderBook;
using Models.Interfaces;
using System;
using System.Collections.Generic;
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

        void IOrderBookModel.NeedOrderBookOf(PairOfMarket pair)
        {
            if (pair == null)
            {
                OrderBook = null;
                OnOrderBookChanged();
                return;
            }

            if (_updater != null)
            {
                OrderBookUpdaterProvider.ReleaseUpdater(_updater);
                _updater.Changed -= OrderBookUpdater_Changed;
            }

            _updater = OrderBookUpdaterProvider.OrderBookUpdater(pair);
            _updater.Changed += OrderBookUpdater_Changed;
            SetUpdaterSettings();

            _updater.Start();
        }

        private IOrderBookUpdater _updater;
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

                if (OrderBook != null)
                    OnOrderBookChanged();
            }
        }

        private void SetUpdaterSettings()
        {
            if (_updater == null)
                return;

            _updater.Depth = 100; //OrderBookSettings.Depth;
            _updater.OrderBookType = OrderBookType.Both; //OrderBookSettings.OrderBookType;
            _updater.RefreshInterval = OrderBookSettings.RefreshInterval;
        }

        private IOrderBook OrderBook { get; set; }
        private OrderBookAdapter OrderBookAdapter { get; } = new OrderBookAdapter();

        private void OrderBookUpdater_Changed(object sender, IOrderBook orderBook)
        {
            OrderBook = orderBook;
            OrderBookAdapter.SetOrderBook(OrderBook);
            OnOrderBookChanged();
        }

        public event EventHandler<IOrderBook> OrderBookChanged;

        public void Release()
        {
            OrderBookUpdaterProvider.ReleaseUpdater(_updater);
        }

        private void OnOrderBookChanged()
        {
            OrderBookChanged?.Invoke(this, OrderBookAdapter);
        }
    }
}
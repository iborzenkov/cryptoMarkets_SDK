using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel.Updaters;
using DomainModel.MarketModel.Updaters.Balance;
using DomainModel.MarketModel.Updaters.PairTick;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.MarketModel.Updaters.OpenedOrders;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class PendingTradeModel : IPendingTradeModel
    {
        private readonly IModel _domainModel;

        private TradePosition _position = TradePosition.Buy;

        public PendingTradeModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        IEnumerable<Market> IPendingTradeModel.Markets => _domainModel.Markets;

        public Market Market { get; set; }
        public PairOfMarket Pair { get; set; }

        public TradePosition Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (_position == value)
                    return;

                _position = value;

                InitBalanceUpdater();
                InitMayTrade();
            }
        }

        private void InitMayTrade()
        {
            var balance = _balanceUpdater.LastValue;
            if (balance == null)
            {
                OnIsMayTradeChanged(true);
                return;
            }

            if (balance.Available <= 0)
            {
                OnIsMayTradeChanged(false);
                return;
            }

            OnIsMayTradeChanged(double.IsNaN(Quantity) || balance.Available > Quantity);
        }

        public double Quantity { get; set; }
        public double Price { get; set; }

        private IPairTickUpdaterProvider PairTickUpdaterProvider => _domainModel.PairTickUpdaterProvider;
        private IBalanceUpdaterProvider BalanceUpdaterProvider => _domainModel.BalanceUpdaterProvider;
        private IOpenedOrdersUpdaterProvider OpenedOrdersUpdaterProvider => _domainModel.OpenedOrdersProvider;

        private IUpdater<IEnumerable<Order>, Market> _openedOrdersUpdater;
        private IUpdater<Tick, PairOfMarket> _pairTickUpdater;
        private IUpdater<Balance, CurrencyOfMarket> _balanceUpdater;

        private readonly TimeInterval _tickRefreshInterval = TimeInterval.InSeconds(10);
        private readonly TimeInterval _balanceRefreshInterval = TimeInterval.InSeconds(30);
        private readonly TimeInterval _openedOrdersRefreshInterval = TimeInterval.InSeconds(5);

        void IPendingTradeModel.MarketChanged(Market market)
        {
            Market = market;

            ReleasePairTickUpdater();
            ReleaseBalanceUpdater();
            ReleaseOpenedOrdersUpdater();

            if (market == null)
            {
                Balance = null;
                OnBalanceChanged();

                Tick = null;
                OnTickChanged();

                OpenedOrders = new List<Order>();
                OnOpenedOrdersChanged();

                return;
            }

            InitOpenedOrdersUpdater();
        }

        void IPendingTradeModel.PairChanged(PairOfMarket pair)
        {
            Pair = pair;
            ReleasePairTickUpdater();

            InitTickUpdater();
            InitBalanceUpdater();

            InitMayTrade();
        }

        void IPendingTradeModel.RemoveOrder(OrderId id)
        {
            string errorMessage;
            Market.Model.Trade.Cancel(Market, id, out errorMessage);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                OnErrorOccured(errorMessage);
            }
        }

        OrderId IPendingTradeModel.Trade()
        {
            string errorMessage;
            var id = Position == TradePosition.Buy
                ? Market.Model.Trade.BuyLimit(Pair, Quantity, Price, out errorMessage)
                : Market.Model.Trade.SellLimit(Pair, Quantity, Price, out errorMessage);

            if (id != null)
            {
                _openedOrdersUpdater.UpdateNow(); 
            }
            else
            {
                OnErrorOccured(errorMessage);
            }

            return id;
        }

        private void InitOpenedOrdersUpdater()
        {
            _openedOrdersUpdater = OpenedOrdersUpdaterProvider.GetUpdater(Market, _openedOrdersRefreshInterval);
            _openedOrdersUpdater.Changed += OpenedOrdersUpdater_Changed;

            _openedOrdersUpdater.ImmediatelyUpdateIfOlder(_openedOrdersRefreshInterval);
            if (_openedOrdersUpdater.LastValue != null)
                SetOpenedOrders(_openedOrdersUpdater.LastValue);

            _openedOrdersUpdater.Start();
        }

        private void InitBalanceUpdater()
        {
            var currency = Position == TradePosition.Buy ? Pair.Pair.QuoteCurrency : Pair.Pair.BaseCurrency;
            var currencyOfMarket = Pair.Market.Currencies.FirstOrDefault(c => c.Currency.Equals(currency));

            _balanceUpdater = BalanceUpdaterProvider.GetUpdater(currencyOfMarket, _balanceRefreshInterval);
            _balanceUpdater.Changed += BalanceUpdater_Changed;

            _balanceUpdater.ImmediatelyUpdateIfOlder(_balanceRefreshInterval);
            if (_balanceUpdater.LastValue != null)
                SetBalance(_balanceUpdater.LastValue);

            _balanceUpdater.Start();
        }

        private void InitTickUpdater()
        {
            _pairTickUpdater = PairTickUpdaterProvider.GetUpdater(Pair, _tickRefreshInterval);
            _pairTickUpdater.Changed += PairTickUpdater_Changed;

            _pairTickUpdater.ImmediatelyUpdateIfOlder(_tickRefreshInterval);
            if (_pairTickUpdater.LastValue != null)
                SetTick(_pairTickUpdater.LastValue);

            _pairTickUpdater.Start();
        }

        public Tick Tick { get; set; }
        public Balance Balance { get; set; }
        public IEnumerable<Order> OpenedOrders { get; set; }

        private void SetOpenedOrders(IEnumerable<Order> openedOrders)
        {
            OpenedOrders = openedOrders;
            OnOpenedOrdersChanged();
        }

        private void SetTick(Tick tick)
        {
            Tick = tick;
            OnTickChanged();
        }

        private void SetBalance(Balance balance)
        {
            Balance = balance;
            OnBalanceChanged();
        }

        private void OnOpenedOrdersChanged()
        {
            OpenedOrdersChanged?.Invoke(OpenedOrders);
        }

        private void OnTickChanged()
        {
            TickChanged?.Invoke(Tick);
        }

        private void OnBalanceChanged()
        {
            BalanceChanged?.Invoke(Balance);
        }

        public event Action<Tick> TickChanged;
        public event Action<Balance> BalanceChanged;
        public event Action<IEnumerable<Order>> OpenedOrdersChanged;
        public event Action<string> ErrorOccured;
        public event Action<bool> IsMayTradeChanged;

        void IPendingTradeModel.Release()
        {
            ReleasePairTickUpdater();
            ReleaseBalanceUpdater();
            ReleaseOpenedOrdersUpdater();
        }

        private void PairTickUpdater_Changed(Tick tick)
        {
            SetTick(tick);
        }

        private void BalanceUpdater_Changed(Balance balance)
        {
            SetBalance(balance);
        }

        private void OpenedOrdersUpdater_Changed(IEnumerable<Order> openedOrders)
        {
            SetOpenedOrders(openedOrders);
        }

        private void ReleaseOpenedOrdersUpdater()
        {
            if (_openedOrdersUpdater != null)
            {
                OpenedOrdersUpdaterProvider.ReleaseUpdater(_openedOrdersUpdater);
                _openedOrdersUpdater.Changed -= OpenedOrdersUpdater_Changed;
            }
        }

        private void ReleaseBalanceUpdater()
        {
            if (_balanceUpdater != null)
            {
                BalanceUpdaterProvider.ReleaseUpdater(_balanceUpdater);
                _balanceUpdater.Changed -= BalanceUpdater_Changed;
            }
        }

        private void ReleasePairTickUpdater()
        {
            if (_pairTickUpdater != null)
            {
                PairTickUpdaterProvider.ReleaseUpdater(_pairTickUpdater);
                _pairTickUpdater.Changed -= PairTickUpdater_Changed;
            }
        }

        private void OnErrorOccured(string errorMessage)
        {
            ErrorOccured?.Invoke(errorMessage);
        }

        private void OnIsMayTradeChanged(bool isMayTrade)
        {
            IsMayTradeChanged?.Invoke(isMayTrade);
        }
    }
}
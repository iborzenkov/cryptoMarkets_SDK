using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel.Updaters;
using DomainModel.MarketModel.Updaters.Balance;
using DomainModel.MarketModel.Updaters.OpenedOrders;
using DomainModel.MarketModel.Updaters.PairTick;
using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using IModel = DomainModel.IModel;

namespace Models.Implementations
{
    public class TradeModel : ITradeModel
    {
        private readonly IModel _domainModel;

        private TradePosition _position = TradePosition.Buy;

        public TradeModel(IModel domainModel)
        {
            _domainModel = domainModel;
        }

        IEnumerable<Market> ITradeModel.Markets => _domainModel.Markets;

        public Market Market { get; set; }
        public PairOfMarket Pair { get; set; }
        public PriceTypeEnum PriceType { get; set; } = PriceTypeEnum.Limit;
        public QuantityTypeEnum QuantityType { get; set; } = QuantityTypeEnum.Quantity;
        public double Quantity { get; set; }
        public double Price { get; set; }

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

                ReleaseBalanceUpdater();
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

        private IPairTickUpdaterProvider PairTickUpdaterProvider => _domainModel.PairTickUpdaterProvider;
        private IBalanceUpdaterProvider BalanceUpdaterProvider => _domainModel.BalanceUpdaterProvider;
        private IOpenedOrdersUpdaterProvider OpenedOrdersUpdaterProvider => _domainModel.OpenedOrdersProvider;

        private IUpdater<IEnumerable<Order>, Market> _openedOrdersUpdater;
        private IUpdater<Tick, PairOfMarket> _pairTickUpdater;
        private IUpdater<Balance, CurrencyOfMarket> _balanceUpdater;

        private readonly TimeInterval _tickRefreshInterval = TimeInterval.InSeconds(10);
        private readonly TimeInterval _balanceRefreshInterval = TimeInterval.InSeconds(30);
        private readonly TimeInterval _openedOrdersRefreshInterval = TimeInterval.InSeconds(5);

        public void MarketChanged(Market market)
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

        public void PairChanged(PairOfMarket pair)
        {
            Pair = pair;

            ReleasePairTickUpdater();
            ReleaseBalanceUpdater();

            if (pair != null)
            {
                InitTickUpdater();
                InitBalanceUpdater();

                InitMayTrade();
            }
        }

        public void RemoveOrder(OrderId id)
        {
            string errorMessage;
            Market.Model.Trade.Cancel(Market, id, out errorMessage);

            if (string.IsNullOrEmpty(errorMessage))
            {
                _balanceUpdater.UpdateNowAsync();
                _openedOrdersUpdater.UpdateNowAsync();

                OnInfoMessage(InfoMessages.SuccessfullCancelLimitOrder);
            }
            else
            {
                OnErrorOccured(errorMessage);
            }
        }

        public OrderId Trade()
        {
            try
            {
                var quantity = GetQuantity();
                var price = GetPrice();

                string errorMessage;
                var id = Position == TradePosition.Buy
                    ? Market.Model.Trade.BuyLimit(Pair, quantity, price, out errorMessage)
                    : Market.Model.Trade.SellLimit(Pair, quantity, price, out errorMessage);

                if (id != null)
                {
                    _balanceUpdater.UpdateNowAsync();
                    _openedOrdersUpdater.UpdateNowAsync();

                    OnInfoMessage(InfoMessages.SuccessfullTrade);
                }
                else
                {
                    OnErrorOccured(Market.Model.AdoptMessage(errorMessage));
                }

                return id;
            }
            catch (UnknownUsdRateException e)
            {
                OnErrorOccured($"{Market.Model.AdoptMessage("UnknownUsdRateFor")} {e.Currency.Name}");
                return null;
            }
        }

        private double GetQuantity()
        {
            if (QuantityType == QuantityTypeEnum.Quantity)
                return Quantity;

            var spending = Quantity;
            if (QuantityType == QuantityTypeEnum.AllAvailable)
            {
                var currency = Market.Currencies.FirstOrDefault(c => c.Currency.Equals(Pair.Pair.BaseCurrency));
                var balanceUpdater = BalanceUpdaterProvider.GetUpdater(currency, TimeInterval.Never);
                spending = balanceUpdater.UpdateNow().Available;
                BalanceUpdaterProvider.ReleaseUpdater(balanceUpdater);
                if (Position == TradePosition.Sell)
                    return spending;
            }

            var pricePerUnit = Price;
            if (PriceType == PriceTypeEnum.Market)
            {
                var tick = _pairTickUpdater.UpdateNow();
                pricePerUnit = tick.Last;
            }

            if (QuantityType == QuantityTypeEnum.UsdSpending)
            {
                var currency = Pair.Pair.QuoteCurrency;
                var usdRate = GetUsdRateChanged(currency);
                if (!usdRate.HasValue)
                {
                    throw new UnknownUsdRateException(currency);
                }
                spending = Quantity / usdRate.Value;
            }

            return spending / pricePerUnit;
        }

        private double GetPrice()
        {
            if (PriceType != PriceTypeEnum.Market)
                return Price;

            const int marketKoef = 2;
            var lastPrice = _pairTickUpdater.LastValue ?? _pairTickUpdater.UpdateNow();
            return Position == TradePosition.Buy ? lastPrice.Last * marketKoef : lastPrice.Last / marketKoef;
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
            //if (_pairTickUpdater.LastValue != null)
            //  SetTick(_pairTickUpdater.LastValue);

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

        public double? GetUsdRateChanged(Currency currency)
        {
            return Market.UsdEquivalent.UsdRate(currency);
        }

        public event Action<Tick> TickChanged;

        public event Action<Balance> BalanceChanged;

        public event Action<IEnumerable<Order>> OpenedOrdersChanged;

        public event Action<string> ErrorOccured;

        public event Action<string> InfoOccured;

        public event Action<bool> IsMayTradeChanged;

        public void Release()
        {
            ReleasePairTickUpdater();
            ReleaseBalanceUpdater();
            ReleaseOpenedOrdersUpdater();
        }

        private void PairTickUpdater_Changed(object sender, Tick tick)
        {
            SetTick(tick);
        }

        private void BalanceUpdater_Changed(object sender, Balance balance)
        {
            SetBalance(balance);
        }

        private void OpenedOrdersUpdater_Changed(object sender, IEnumerable<Order> openedOrders)
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

        private void OnInfoMessage(string infoMessage)
        {
            InfoOccured?.Invoke(infoMessage);
        }

        private void OnIsMayTradeChanged(bool isMayTrade)
        {
            IsMayTradeChanged?.Invoke(isMayTrade);
        }
    }
}
﻿using CryptoSdk.Misc;
using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel.Updaters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;
using Timer = System.Timers.Timer;

namespace Views.Implementations
{
    public partial class TradeForm : Form, ITradeView
    {
        // todo: Показать часть стакана возле определенного уровня
        private readonly TimeInterval _infoTimerInterval = TimeInterval.InSeconds(10);

        public TradeForm()
        {
            InitializeComponent();

            _infoTimer = new Timer(_infoTimerInterval.Value);
            _infoTimer.Elapsed += InfoTimer_Elapsed;

            SetCurrencyLabels();

            Locale.Instance.RegisterView(this);
        }

        public void SetMarkets(IEnumerable<Market> markets)
        {
            marketComboBox.BeginInvoke(new Action(() =>
            {
                marketComboBox.BeginUpdate();
                try
                {
                    var marketsArray = markets as Market[] ?? markets.ToArray();

                    marketComboBox.Items.Clear();
                    marketComboBox.Items.AddRange(marketsArray.ToArray<object>());

                    if (marketsArray.Any())
                        Market = marketsArray.First();
                }
                finally
                {
                    marketComboBox.EndUpdate();
                }
            }));
        }

        public void SetPairs(IEnumerable<PairOfMarket> pairs)
        {
            pairComboBox.BeginInvoke(new Action(() =>
            {
                pairComboBox.BeginUpdate();
                try
                {
                    var pairsArray = pairs as PairOfMarket[] ?? pairs.ToArray();

                    var selectedPair = Pair;

                    ClearPairs();
                    pairComboBox.Items.AddRange(pairsArray.ToArray<object>());

                    if (selectedPair != null)
                        Pair = pairsArray.FirstOrDefault(pairOfMarket => pairOfMarket.Pair.Equals(selectedPair.Pair));
                }
                finally
                {
                    pairComboBox.EndUpdate();
                }
            }));
        }

        private void ClearPairs()
        {
            pairComboBox.Items.Clear();
            OnPairChanged();
        }

        public void SetOpenedOrders(IEnumerable<Order> orders)
        {
            openedOrdersListView.BeginInvoke(new Action(() =>
            {
                openedOrdersListView.BeginUpdate();
                try
                {
                    var oldSelectedOrderId = GetSelectedOrder();
                    openedOrdersListView.Items.Clear();
                    if (orders == null)
                        return;

                    FillOpenedOrders(orders);
                    SelectOrderIfPossible(_selectedOrderId ?? oldSelectedOrderId);
                }
                finally
                {
                    openedOrdersListView.EndUpdate();
                }
            }));
        }

        private void FillOpenedOrders(IEnumerable<Order> orders)
        {
            foreach (var order in orders)
            {
                var item = new ListViewItem(new[]
                {
                            order.Market.Name,
                            order.Pair.ToString(),
                            TradePositionAsString(order.Position),
                            order.Price.ToString("F8", CultureInfo.CurrentCulture),
                            order.Quantity.ToString("F8", CultureInfo.CurrentCulture),
                            GetOpenedDate(order.Opened),
                        });
                item.Tag = order;
                openedOrdersListView.Items.Add(item);
            }
        }

        private string GetOpenedDate(DateTime? opened)
        {
            return opened?.ToString() ?? string.Empty;
        }

        private OrderId GetSelectedOrder()
        {
            return openedOrdersListView.SelectedItems.Count > 0 ? (openedOrdersListView.SelectedItems[0].Tag as Order)?.Id : null;
        }

        private void SelectOrderIfPossible(OrderId selectedOrderId)
        {
            if (selectedOrderId == null)
                return;

            for (var i = 0; i < openedOrdersListView.Items.Count; i++)
            {
                var order = openedOrdersListView.Items[i].Tag as Order;
                if (order == null)
                    continue;

                if (order.Id.Equals(selectedOrderId))
                {
                    //openedOrdersListView.FocusedItem = openedOrdersListView.Items[i];
                    openedOrdersListView.SelectedIndices.Clear();
                    openedOrdersListView.SelectedIndices.Add(i);
                    break;
                }
            }

            _selectedOrderId = null;
        }

        private string TradePositionAsString(TradePosition position)
        {
            return Locale.Instance.Localize(position == TradePosition.Buy ? "Buy" : "Sell");
        }

        private Market Market
        {
            get { return marketComboBox.SelectedItem as Market; }
            set
            {
                if (Market == value)
                    return;

                marketComboBox.SelectedItem = value;
                OnMarketChanged();
            }
        }

        private PairOfMarket Pair
        {
            get
            {
                return pairComboBox.SelectedItem as PairOfMarket;
            }
            set
            {
                if (Pair == value)
                    return;

                pairComboBox.SelectedItem = value;
                OnPairChanged();
            }
        }

        private void SetCurrencyLabels()
        {
            iWantToGroupBox.Enabled = Pair != null;
            baseCurrencyLabel.Text = Pair != null
                ? Position == TradePosition.Buy
                    ? Pair.Pair.QuoteCurrency.Name
                    : Pair.Pair.BaseCurrency.Name
                : string.Empty;
            quoteCurrencyLabel.Text = Pair != null
                ? Position == TradePosition.Buy
                    ? Pair.Pair.BaseCurrency.Name
                    : Pair.Pair.QuoteCurrency.Name
                : string.Empty;
        }

        private OrderId SelectedOrderId => (openedOrdersListView.FocusedItem?.Tag as Order)?.Id;

        public TradePosition Position
        {
            private get
            {
                return buyLimitRadioButton.Checked ? TradePosition.Buy : TradePosition.Sell;
            }
            set
            {
                if (value == TradePosition.Buy)
                    buyLimitRadioButton.Checked = true;
                else
                    sellLimitRadioButton.Checked = true;

                OnTradeParamsChanged();
            }
        }

        public void SetIsMayTrade(bool value)
        {
            tradeButton.Enabled = value;
        }

        public void SetInfoMessage(string message)
        {
            var localized = Locale.Instance.Localize(message);
            if (string.IsNullOrEmpty(localized))
                localized = message;
            ShowInfoMessage(localized);
        }

        public void SetErrorMessage(string message)
        {
            var localized = Locale.Instance.Localize(message);
            if (string.IsNullOrEmpty(localized))
                localized = message;
            ShowInfoMessage(localized);
        }

        public void SetBalanceInfo(double availableQuantity)
        {
            statusStrip.BeginInvoke(new Action(() =>
            {
                var currency = Position == TradePosition.Buy ? Pair.Pair.QuoteCurrency : Pair.Pair.BaseCurrency;
                var usdEquivalent = UsdEquivalent(currency, availableQuantity);
                var usdText = string.Empty;
                if (usdEquivalent.HasValue)
                    usdText = $" (~{Math.Round(usdEquivalent.Value)} USD)";
                availableQuantityLabel.Text = $"{availableQuantity.ToString("F8", CultureInfo.CurrentCulture)} {currency}{usdText}";
            }));
        }

        public void SetPriceInfo(double currentPrice)
        {
            statusStrip.BeginInvoke(new Action(() =>
            {
                var forOne = Locale.Instance.Localize("ForOne");
                priceValueLabel.Text = 
                    $"{currentPrice.ToString("F8", CultureInfo.CurrentCulture)} {Pair.Pair.QuoteCurrency} {forOne} {Pair.Pair.BaseCurrency}";
            }));

            priceTextBox.BeginInvoke(new Action(() =>
            {
                if (string.IsNullOrEmpty(priceTextBox.Text))
                    priceTextBox.Text = $"{currentPrice.ToString("F8", CultureInfo.CurrentCulture)}";
            }));
        }

        public QuantityTypeEnum QuantityType
        {
            get
            {
                if (exactlyRadioButton.Checked)
                    return QuantityTypeEnum.Quantity;
                if (spendingRadioButton.Checked)
                    return QuantityTypeEnum.Spending;
                if (spendingUsdRadioButton.Checked)
                    return QuantityTypeEnum.UsdSpending;
                return QuantityTypeEnum.AllAvailable;
            }
            set
            {
                switch (value)
                {
                    case QuantityTypeEnum.AllAvailable:
                    {
                        allAvailableRadioButton.Checked = true;
                        break;
                    }
                    case QuantityTypeEnum.Quantity:
                    {
                        exactlyRadioButton.Checked = true;
                        break;
                    }
                    case QuantityTypeEnum.Spending:
                    {
                        spendingRadioButton.Checked = true;
                        break;
                    }
                    case QuantityTypeEnum.UsdSpending:
                    {
                        spendingUsdRadioButton.Checked = true;
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                quantityTextBox.Enabled = QuantityType == QuantityTypeEnum.Quantity;
                quoteCurrencyLabel.Enabled = quantityTextBox.Enabled;

                spendingQuantityTextBox.Enabled = QuantityType == QuantityTypeEnum.Spending;
                baseCurrencyLabel.Enabled = spendingQuantityTextBox.Enabled;

                spendingUsdQuantityTextBox.Enabled = QuantityType == QuantityTypeEnum.UsdSpending;
                usdCurrencyLabel.Enabled = spendingUsdQuantityTextBox.Enabled;

                OnTradeParamsChanged();
            }
        }
         
        public PriceTypeEnum PriceType
        {
            get { return limitOrderRadioButton.Checked ? PriceTypeEnum.Limit : PriceTypeEnum.Market; }
            set
            {
                if (value == PriceTypeEnum.Limit)
                    limitOrderRadioButton.Checked = true;
                else
                    marketPriceRadioButton.Checked = true;

                priceTextBox.Enabled = value == PriceTypeEnum.Limit;

                OnTradeParamsChanged();
            }
        }

        private OrderId _selectedOrderId { get; set; }

        public void SelectOpenedOrder(OrderId id)
        {
            _selectedOrderId = id;
        }

        public event Action<Market> MarketChanged;

        public event Action<PairOfMarket> PairChanged;

        public event Action ViewClosed;

        public event Action<PendingTradeParams> TradeParamsChanged;

        public event Action Trade;

        public event Action<OrderId> RemoveOrder;

        private void OnPairChanged()
        {
            SetCurrencyLabels();
            priceTextBox.Clear();
            PairChanged?.Invoke(Pair);
        }

        private void TradeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _infoTimer.Elapsed -= InfoTimer_Elapsed;
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private double Quantity
        {
            get
            {
                double quantity;
                if (QuantityType == QuantityTypeEnum.Quantity)
                    return quantityTextBox.Text.TryParseToDouble(out quantity) ? quantity : double.NaN;
                if (QuantityType == QuantityTypeEnum.Spending)
                    return spendingQuantityTextBox.Text.TryParseToDouble(out quantity) ? quantity : double.NaN;
                if (QuantityType == QuantityTypeEnum.UsdSpending)
                    return spendingUsdQuantityTextBox.Text.TryParseToDouble(out quantity) ? quantity : double.NaN;
                return double.NaN;
            }
        }

        private double Price
        {
            get
            {
                double price;
                return priceTextBox.Text.TryParseToDouble(out price) ? price : double.NaN;
            }
        }

        private PendingTradeParams TradeParams => new PendingTradeParams(Position, Quantity, Price, PriceType, QuantityType);

        private void quantityTextBox_TextChanged(object sender, EventArgs e)
        {
            OnTradeParamsChanged();
        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {
            OnTradeParamsChanged();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            Position = buyLimitRadioButton.Checked ? TradePosition.Buy : TradePosition.Sell;
        }

        private void OnTradeParamsChanged()
        {
            if (TradeParams != null)
                TradeParamsChanged?.Invoke(TradeParams);
        }

        private void tradeButton_Click(object sender, EventArgs e)
        {
            Trade?.Invoke();
        }

        private void infoMessageStatusLabel_Click(object sender, EventArgs e)
        {
            HideInfoMessage();
        }

        private readonly Timer _infoTimer;

        private void InfoTimer_Elapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            HideInfoMessage();
        }

        private void ShowInfoMessage(string message)
        {
            HideInfoMessage();

            statusStrip.BeginInvoke(new Action(() =>
            {
                infoMessageStatusLabel.Text = message;
                _infoTimer.Start();

                availableLabel.Visible = false;
                availableQuantityLabel.Visible = false;
                priceStatusLabel.Visible = false;
                priceValueLabel.Visible = false;
            }));
        }

        private void HideInfoMessage()
        {
            statusStrip.BeginInvoke(new Action(() =>
            {
                infoMessageStatusLabel.Text = string.Empty;
                _infoTimer.Stop();

                availableLabel.Visible = true;
                availableQuantityLabel.Visible = true;
                priceStatusLabel.Visible = true;
                priceValueLabel.Visible = true;
            }));
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var orderId = SelectedOrderId;
            if (orderId == null)
            {
                ShowInfoMessage(Locale.Instance.Localize("SelectRemovingOrder"));
                return;
            }
            RemoveOrder?.Invoke(SelectedOrderId);
        }

        private void pairComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnPairChanged();
        }

        public void SetUsdRate(GetUsdRateDelegate getUsdRate)
        {
            _getUsdRate = getUsdRate;
        }

        private GetUsdRateDelegate _getUsdRate;

        private double? UsdEquivalent(Currency currency, double quantity)
        {
            return _getUsdRate.Invoke(currency) * quantity;
        }

        private void marketComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnMarketChanged();
        }

        private void limitOrderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            PriceType = limitOrderRadioButton.Checked ? PriceTypeEnum.Limit : PriceTypeEnum.Market;
        }

        private void exactlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (exactlyRadioButton.Checked)
                QuantityType = QuantityTypeEnum.Quantity;
        }

        private void spendingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (spendingRadioButton.Checked)
                QuantityType = QuantityTypeEnum.Spending;
        }

        private void spendingUsdRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (spendingUsdRadioButton.Checked)
                QuantityType = QuantityTypeEnum.UsdSpending;
        }

        private void allAvailableRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (allAvailableRadioButton.Checked)
                QuantityType = QuantityTypeEnum.AllAvailable;
        }

        private void spendingQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            OnTradeParamsChanged();
        }

        private void spendingUsdQuantityTextBox_TextChanged(object sender, EventArgs e)
        {
            OnTradeParamsChanged();
        }

        private void OnMarketChanged()
        {
            MarketChanged?.Invoke(Market);
        }
    }
}
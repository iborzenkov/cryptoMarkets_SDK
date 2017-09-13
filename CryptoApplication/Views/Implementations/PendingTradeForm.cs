using CryptoSdk.Misc;
using DomainModel;
using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using DomainModel.MarketModel.Updaters;
using Views.Interfaces;
using Views.Localization;
using Timer = System.Timers.Timer;

namespace Views.Implementations
{
    public partial class PendingTradeForm : Form, IPendingTradeView
    {
        private readonly TimeInterval _infoTimerInterval = TimeInterval.InSeconds(10);

        public PendingTradeForm()
        {
            InitializeComponent();

            _infoTimer = new Timer(_infoTimerInterval.Value);
            _infoTimer.Elapsed += InfoTimer_Elapsed;

            SetCurrencyLabels();

            Locale.Instance.RegisterView(this);
        }

        void IPendingTradeView.SetMarkets(IEnumerable<Market> markets)
        {
            marketComboBox.BeginUpdate();
            try
            {
                marketComboBox.Items.Clear();
                marketComboBox.Items.AddRange(markets.ToArray<object>());
            }
            finally
            {
                marketComboBox.EndUpdate();
            }
        }

        void IPendingTradeView.SetPairs(IEnumerable<PairOfMarket> pairs)
        {
            pairComboBox.BeginUpdate();
            try
            {
                pairComboBox.Items.Clear();
                pairComboBox.Items.AddRange(pairs.ToArray<object>());
            }
            finally
            {
                pairComboBox.EndUpdate();
            }
        }

        void IPendingTradeView.SetOpenedOrders(IEnumerable<Order> orders)
        {
            openedOrdersListView.BeginInvoke(new Action(() =>
            {
                openedOrdersListView.BeginUpdate();
                try
                {
                    openedOrdersListView.Items.Clear();
                    if (orders == null)
                        return;

                    foreach (var order in orders)
                    {
                        var item = new ListViewItem(new[]
                        {
                            order.Market.Name,
                            order.Pair.ToString(),
                            TradePositionAsString(order.Position),
                            order.Price.ToString(CultureInfo.CurrentCulture),
                            order.Quantity.ToString(CultureInfo.CurrentCulture),
                        });
                        item.Tag = order;
                        openedOrdersListView.Items.Add(item);
                    }
                }
                finally
                {
                    openedOrdersListView.EndUpdate();
                }
            }));
        }

        private string TradePositionAsString(TradePosition position)
        {
            return Locale.Instance.Localize(position == TradePosition.Buy ? "Buy" : "Sell");
        }

        public Market Market
        {
            get { return marketComboBox.SelectedItem as Market; }
            set
            {
                marketComboBox.SelectedItem = value;
                MarketChanged?.Invoke(Market);
            }
        }

        public PairOfMarket Pair
        {
            get
            {
                /*PairOfMarket result;
                if (pairComboBox.InvokeRequired)
                {
                    pairComboBox.Invoke(new Action(() => { result = pairComboBox.SelectedItem as PairOfMarket; }));
                }
                else
                {
                    result = pairComboBox.SelectedItem as PairOfMarket;
                }

                return result;*/

                return pairComboBox.SelectedItem as PairOfMarket;
            }
            set
            {
                if (pairComboBox.SelectedItem == value)
                    return;

                pairComboBox.SelectedItem = value;

                SetCurrencyLabels();

                OnPairChanged(Pair);
            }
        }

        private void SetCurrencyLabels()
        {
            iWantToGroupBox.Enabled = Pair != null;
            baseCurrencyLabel.Text = Pair != null ? Pair.Pair.BaseCurrency.Name : string.Empty;
            quoteCurrencyLabel.Text = Pair != null ? Pair.Pair.QuoteCurrency.Name : string.Empty;
        }

        private OrderId SelectedOrderId => openedOrdersListView.FocusedItem.Tag as OrderId;

        public TradePosition Position
        {
            get
            {
                return buyLimitRadioButton.Checked ? TradePosition.Buy : TradePosition.Sell;
            }
            set
            {
                if (Position == value)
                    return;
                if (value == TradePosition.Buy)
                    buyLimitRadioButton.Checked = true;
                else
                    sellLimitRadioButton.Checked = true;
            }
        }

        void IPendingTradeView.SetIsMayTrade(bool value)
        {
            tradeButton.Enabled = value;
        }

        void IPendingTradeView.SetInfoMessage(string message)
        {
            ShowInfoMessage(message);
        }

        void IPendingTradeView.SetBalanceInfo(double availableQuantity)
        {
            statusStrip.BeginInvoke(new Action(() =>
            {
                //var currency = Position == TradePosition.Buy ? Pair.Pair.QuoteCurrency.Name : Pair.Pair.BaseCurrency.Name;
                var currency = Position == TradePosition.Buy ? Pair.Buy.QuantitiedCurrency : Pair.Sell.QuantitiedCurrency;
                availableQuantityLabel.Text = $"{availableQuantity.ToString(CultureInfo.CurrentCulture)} {currency}";
            }));
        }

        void IPendingTradeView.SetPriceInfo(double currentPrice)
        {
            statusStrip.BeginInvoke(new Action(() =>
            {
                //var currency = Position == TradePosition.Buy ? Pair.Pair.BaseCurrency.Name : Pair.Pair.QuoteCurrency.Name;
                var currency = Position == TradePosition.Buy ? Pair.Buy.PricedCurrency : Pair.Sell.PricedCurrency;
                priceValueLabel.Text = $"{currentPrice.ToString(CultureInfo.CurrentCulture)} {currency}";
            }));
        }

        public void SelectOpenedOrder(OrderId id)
        {
            for (var i = 0; i < openedOrdersListView.Items.Count; i++)
            {
                if (((Order) openedOrdersListView.Items[i].Tag).Id.Equals(id))
                {
                    openedOrdersListView.FocusedItem = openedOrdersListView.Items[i];
                    break;
                }
            }
        }

        public event Action<Market> MarketChanged;

        public event Action<PairOfMarket> PairChanged;

        public event Action ViewClosed;

        public event Action<PendingTradeParams> TradeParamsChanged;

        public event Action Trade;

        public event Action<OrderId> RemoveOrder;

        private void OnPairChanged(PairOfMarket pair)
        {
            PairChanged?.Invoke(pair);
        }

        private void marketComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketChanged?.Invoke(Market);
        }

        private void pairComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrencyLabels();
            OnPairChanged(Pair);
        }

        private void TradeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _infoTimer.Elapsed -= InfoTimer_Elapsed;
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        public double Quantity
        {
            get
            {
                double quantity;
                return quantityTextBox.Text.TryParseToDouble(out quantity) ? quantity : double.NaN;
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

        public PendingTradeParams TradeParams => new PendingTradeParams(Position, Quantity, Price);

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
            OnTradeParamsChanged();
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
            RemoveOrder?.Invoke(SelectedOrderId);
        }
    }
}
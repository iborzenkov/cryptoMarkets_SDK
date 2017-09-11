using CryptoSdk.Misc;
using DomainModel;
using DomainModel.Features;
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
    public partial class PendingTradeForm : Form, IPendingTradeView
    {
        private const int InfoTimerInterval = 10 * 1000; // 10 seconds

        public PendingTradeForm()
        {
            InitializeComponent();

            _infoTimer = new Timer(InfoTimerInterval);
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
            set { marketComboBox.SelectedItem = value; }
        }

        public PairOfMarket Pair
        {
            get
            {
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

        public TradePosition Position => buyLimitRadioButton.Checked ? TradePosition.Buy : TradePosition.Sell;

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
            var pair = TradePosition == TradePosition.Buy ? Pair.Pair.QuoteCurrency.Name: Pair.Pair.BaseCurrency.Name;
            availableQuantityLabel.Text = $"{availableQuantity.ToString(CultureInfo.CurrentCulture)} {pair}";
        }

        void IPendingTradeView.SetPriceInfo(double currentPrice)
        {
            var pair = TradePosition == TradePosition.Buy ? Pair.Pair.BaseCurrency.Name : Pair.Pair.QuoteCurrency.Name;
            priceValueLabel.Text = $"{currentPrice.ToString(CultureInfo.CurrentCulture)} {pair}";
        }

        public event Action<Market> MarketChanged;

        public event Action<PairOfMarket> PairChanged;

        public event Action ViewClosed;

        public event Action<PendingTradeParams> TradeParamsChanged;

        public event Action<PendingTradeParams> Trade;
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

        private double Quantity
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

        public PendingTradeParams TradeParams => !double.IsNaN(Quantity) && !double.IsNaN(Price)
            ? new PendingTradeParams(TradePosition, Quantity, Price)
            : null;

        private TradePosition TradePosition => buyLimitRadioButton.Checked ? TradePosition.Buy : TradePosition.Sell;

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
            Trade?.Invoke(TradeParams);
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
            infoMessageStatusLabel.Text = message;
            _infoTimer.Start();

            availableLabel.Visible = false;
            availableQuantityLabel.Visible = false;
            priceStatusLabel.Visible = false;
            priceValueLabel.Visible = false;
        }

        private void HideInfoMessage()
        {
            infoMessageStatusLabel.Text = string.Empty;
            _infoTimer.Stop();

            availableLabel.Visible = true;
            availableQuantityLabel.Visible = true;
            priceStatusLabel.Visible = true;
            priceValueLabel.Visible = true;
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveOrder?.Invoke(SelectedOrderId);
        }
    }
}
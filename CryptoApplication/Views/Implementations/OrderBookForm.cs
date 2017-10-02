using DomainModel;
using DomainModel.Features;
using DomainModel.MarketModel;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class OrderBookForm : Form, IOrderBookView
    {
        private IOrderBookPartView OrderBookPartView { get; }

        public OrderBookForm()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);

            // todo: to do localization
            foreach (var item in Enum.GetValues(typeof(OrderBookType)))
                typeComboBox.Items.Add(item);

            var orderbookControl = new OrderBookControl
            {
                Dock = DockStyle.Fill
            };
            OrderBookPartView = orderbookControl;
            orderBookPartPanel.Controls.Add(orderbookControl);
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

        public void SetOrderBook(IOrderBook orderBook)
        {
            OrderBookPartView.SetOrderBook(orderBook);
        }

        public void SetUsdRate(double? usdRate)
        {
            OrderBookPartView.SetUsdRate(usdRate);
        }

        public void SetSettings(OrderBookSettings settings)
        {
            var changed = false;

            if (Depth != settings.Depth)
            {
                depthNumericUpDown.Value = settings.Depth;
                changed = true;
            }

            if (HighlightLargePositions != settings.HighlightLargePositions)
            {
                largePositionCheckBox.Checked = settings.HighlightLargePositions;
                changed = true;
            }

            if (Math.Abs(LargeVolumeKoef - settings.LargeVolumeKoef) > 0.00001)
            {
                largeVolumeKoefTrackBar.Value = (int)Math.Round(settings.LargeVolumeKoef * 100);
                changed = true;
            }

            if (RefreshInterval != settings.RefreshInterval)
            {
                intervalTextBox.Text = settings.RefreshInterval.ToString();
                changed = true;
            }

            if (Multiplier != settings.Multiplier)
            {
                multiplierComboBox.SelectedIndex = (int)Math.Log10(settings.Multiplier);
                changed = true;
            }

            if (typeComboBox.SelectedItem == null || Type != settings.OrderBookType)
            {
                typeComboBox.SelectedItem = settings.OrderBookType;
                changed = true;
            }

            if (changed)
                OnOrderBookSettingsChanged();
        }

        public void ClearOrderBooks()
        {
            OrderBookPartView.ClearOrderBookParts();
        }

        private int Depth => (int)depthNumericUpDown.Value;

        private int RefreshInterval => int.Parse(intervalTextBox.Text);

        private int Multiplier => (int)Math.Pow(10, multiplierComboBox.SelectedIndex);

        private double LargeVolumeKoef => largeVolumeKoefTrackBar.Value / 100.0;

        private bool HighlightLargePositions => largePositionCheckBox.Checked;

        private OrderBookType Type => (OrderBookType)typeComboBox.SelectedItem;

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

        public PairOfMarket Pair
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

        private void pairComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnPairChanged();
        }

        private void OrderBookForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void depthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            OnOrderBookSettingsChanged();
        }

        private void intervalTextBox_TextChanged(object sender, EventArgs e)
        {
            OnOrderBookSettingsChanged();
        }

        private void typeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOrderBookSettingsChanged();
        }

        private void OnPairChanged()
        {
            PairChanged?.Invoke(Pair);
        }

        private void OnOrderBookSettingsChanged()
        {
            SettingsChanged?.Invoke(
                new OrderBookSettings
                {
                    Depth = Depth,
                    OrderBookType = Type,
                    RefreshInterval = RefreshInterval,
                    Multiplier = Multiplier,
                    HighlightLargePositions = HighlightLargePositions,
                    LargeVolumeKoef = LargeVolumeKoef,
                });
        }

        public event Action<PairOfMarket> PairChanged;

        public event Action<Market> MarketChanged;

        public event Action<OrderBookSettings> SettingsChanged;

        public event Action ViewClosed;

        private void multiplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnOrderBookSettingsChanged();
        }

        private void largeVolumeKoefTrackBar_Scroll(object sender, EventArgs e)
        {
            OnOrderBookSettingsChanged();
        }

        private void largePositionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OnOrderBookSettingsChanged();
        }

        private void marketComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnMarketChanged();
        }

        private void OnMarketChanged()
        {
            MarketChanged?.Invoke(Market);
        }
    }
}
using DomainModel;
using DomainModel.Features;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class BlowoutVolumeForm : Form, IBlowoutVolumeView
    {
        public BlowoutVolumeForm()
        {
            InitializeComponent();

            foreach (var item in Enum.GetValues(typeof(TimeframeType)))
                timeframeComboBox.Items.Add(item);

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

        private PairOfMarket Pair => pairListView.FocusedItem.Tag as PairOfMarket;

        private TimeframeType Timeframe => (TimeframeType)timeframeComboBox.SelectedItem;
        private int BarCount => (int)barCountUpDown.Value;
        private bool AutoTrade => autoTradeCheckBox.Checked;
        private bool SendEmailNotifications => sendEmailCheckBox.Checked;
        private int BalancePercentPerOneTrade => (int)balancePercentPerOneTradeUpDown.Value;
        private string EMail => eMailTextBox.Text;

        public void SetPairs(IEnumerable<PairOfMarket> pairs)
        {
            pairListView.BeginInvoke(new Action(() =>
            {
                pairListView.BeginUpdate();
                try
                {
                    pairListView.Items.Clear();
                    if (pairs == null)
                        return;

                    foreach (var pair in pairs)
                    {
                        var item = new ListViewItem(new[]
                        {
                            pair.Pair.ToString(),
                            AvailableBars(pair),
                        });
                        item.Checked = pair.IsActive;
                        item.Tag = pair;
                        pairListView.Items.Add(item);
                    }
                }
                finally
                {
                    pairListView.EndUpdate();
                }
            }));
        }

        private string AvailableBars(PairOfMarket pair)
        {
            int bars;
            if (!_availableBars.TryGetValue(pair, out bars))
                bars = 0;
            return bars.ToString();
        }

        private Dictionary<PairOfMarket, int> _availableBars = new Dictionary<PairOfMarket, int>();

        public void SetAvailableBars(Dictionary<PairOfMarket, int> availableBars)
        {
            _availableBars = availableBars;
            UpdateAvailableBars();
        }

        private void UpdateAvailableBars()
        {
            pairListView.BeginInvoke(new Action(() =>
            {
                pairListView.BeginUpdate();
                try
                {
                    for (var i = 0; i < pairListView.Items.Count; i++)
                    {
                        var pair = pairListView.Items[i].Tag as PairOfMarket;
                        pairListView.Items[i].SubItems[1].Text = AvailableBars(pair);
                    }
                }
                finally
                {
                    pairListView.EndUpdate();
                }
            }));
        }

        public event Action<Market> MarketChanged;

        public event Action<PairOfMarket, bool> PairChecked;

        public event Action<BlowoutVolumeSettings> SettingsChanged;

        public void SetSettings(BlowoutVolumeSettings settings)
        {
            var changed = false;

            if (Timeframe != settings.Timeframe)
            {
                timeframeComboBox.SelectedItem = settings.Timeframe;
                changed = true;
            }

            if (AutoTrade != settings.AutoTrade)
            {
                autoTradeCheckBox.Checked = settings.AutoTrade;
                changed = true;
            }

            if (BalancePercentPerOneTrade != settings.BalancePercentPerOneTrade)
            {
                balancePercentPerOneTradeUpDown.Value = settings.BalancePercentPerOneTrade;
                changed = true;
            }

            if (SendEmailNotifications != settings.SendEmailNotifications)
            {
                sendEmailCheckBox.Checked = settings.SendEmailNotifications;
                changed = true;
            }

            if (EMail != settings.EMail)
            {
                eMailTextBox.Text = settings.EMail;
                changed = true;
            }

            if (BarCount != settings.BarCount)
            {
                barCountUpDown.Value = settings.BarCount;
                changed = true;
            }

            if (changed)
                OnSettingsChanged();
        }

        public event Action ViewClosed;

        protected virtual void OnSettingsChanged()
        {
            SettingsChanged?.Invoke(Settings);
        }

        public BlowoutVolumeSettings Settings { get; } = new BlowoutVolumeSettings();

        protected virtual void OnPairChecked(PairOfMarket pair, bool isChecked)
        {
            PairChecked?.Invoke(pair, isChecked);
        }

        private void pairListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OnPairChecked(e.Item.Tag as PairOfMarket, e.Item.Checked);
        }

        private void marketComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnMarketChanged();
        }

        private void OnMarketChanged()
        {
            MarketChanged?.Invoke(Market);
        }

        private void BlowoutVolumeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }
    }
}
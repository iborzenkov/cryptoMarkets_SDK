using DomainModel;
using DomainModel.Features;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private PairOfMarket Pair => pairListView.FocusedItem?.Tag as PairOfMarket;

        public void SetTimeframes(TimeframeType[] timeframes)
        {
            timeframeComboBox.BeginInvoke(new Action(() =>
            {
                timeframeComboBox.BeginUpdate();
                try
                {
                    var selectedTimeframe = timeframeComboBox.SelectedItem != null ? Timeframe : (TimeframeType?)null;

                    ClearTimeframes();
                    foreach (var timeframe in timeframes)
                    {
                        timeframeComboBox.Items.Add(timeframe);
                    }

                    Timeframe = selectedTimeframe != null && timeframeComboBox.Items.Contains(selectedTimeframe.Value) 
                        ? selectedTimeframe.Value
                        : timeframes.FirstOrDefault();
                }
                finally
                {
                    timeframeComboBox.EndUpdate();
                }
            }));
        }

        public event Action<PairOfMarket, TimeframeType, int> AddPairToAnalise;
        public event Action<PairOfMarket, TimeframeType, int> RemovePairFromAnalise;

        public void PairWasAddedToAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            throw new NotImplementedException();
        }

        public void PairWasRemovedFromAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            throw new NotImplementedException();
        }

        public void SaveAnalisePairs()
        {
            throw new NotImplementedException();
        }

        public void LoadAnalisePairs()
        {
            throw new NotImplementedException();
        }

        public void SignalOccured(PairOfMarket pair)
        {
            throw new NotImplementedException();
        }

        public void SignalDisappeared(PairOfMarket pair)
        {
            throw new NotImplementedException();
        }

        private void ClearTimeframes()
        {
            timeframeComboBox.Items.Clear();
            TimeframeChanged();
        }

        public TimeframeType? Timeframe
        {
            get
            {
                return (TimeframeType?)timeframeComboBox.SelectedItem;
            }
            set
            {
                if (timeframeComboBox.SelectedItem != null && Timeframe == value)
                    return;

                timeframeComboBox.SelectedItem = value;
                TimeframeChanged();
            }
        }

        private void TimeframeChanged()
        {
            UpdateAddPairToAnalize();
        }

        private void UpdateAddPairToAnalize()
        {
            addPairButton.Enabled = Pair != null && Timeframe.HasValue && BarCount > 0;
        }

        private int BarCount => (int)barCountUpDown.Value;
        private double LargeVolumeKoef => largeVolumeKoefTrackBar.Value / 100.0;
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
                        });
                        item.Checked = ActivePairs.Contains(pair);
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

        private IList<PairOfMarket> ActivePairs { get; } = new List<PairOfMarket>();

        public event Action<Market> MarketChanged;

        public event Action<BlowoutVolumeSettings> SettingsChanged;

        public void SetSettings(BlowoutVolumeSettings settings)
        {
            var changed = false;

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

            if (Math.Abs(LargeVolumeKoef - settings.LargeVolumeKoef) > 0.00001)
            {
                largeVolumeKoefTrackBar.Value = (int)Math.Round(settings.LargeVolumeKoef * 100);
                changed = true;
            }

            if (changed)
                OnSettingsChanged();
        }

        public event Action ViewClosed;

        private void OnSettingsChanged()
        {
            SettingsChanged?.Invoke(Settings);
        }

        public BlowoutVolumeSettings Settings { get; } = new BlowoutVolumeSettings();

        private void OnMarketChanged()
        {
            MarketChanged?.Invoke(Market);
        }

        private void BlowoutVolumeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void largeVolumeKoefTrackBar_Scroll(object sender, EventArgs e)
        {
            OnSettingsChanged();
        }

        private void OnAddPairToAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            AddPairToAnalise?.Invoke(pair, timeframe, barCount);
        }

        private void OnRemovePairFromAnalise(PairOfMarket pair, TimeframeType timeframe, int barCount)
        {
            RemovePairFromAnalise?.Invoke(pair, timeframe, barCount);
        }

        private void addPairButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(Timeframe.HasValue);

            OnAddPairToAnalise(Pair, Timeframe.Value, BarCount);
        }

        private void marketComboBox_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            OnMarketChanged();
        }

        private void barCountUpDown_ValueChanged(object sender, EventArgs e)
        {
            UpdateAddPairToAnalize();
        }

        private void pairListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAddPairToAnalize();
        }

        private void removePairButton_Click(object sender, EventArgs e)
        {
            Debug.Assert(Timeframe.HasValue);

            OnRemovePairFromAnalise(Pair, Timeframe.Value, BarCount);
        }
    }
}
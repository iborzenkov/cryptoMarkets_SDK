using DomainModel;
using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class CandlestickForm : Form, ICandlestickView
    {
        public CandlestickForm()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);
        }

        private void OnPairChanged()
        {
            PairChanged?.Invoke(Pair);
        }

        private void OnTimeframeChanged()
        {
            TimeframeChanged?.Invoke(Timeframe);
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

        public TimeframeType? Timeframe
        {
            get
            {
                return (TimeframeType?) timeframeComboBox.SelectedItem;
            }
            set
            {
                if (timeframeComboBox.SelectedItem != null && Timeframe == value)
                    return;

                timeframeComboBox.SelectedItem = value.Value;
                OnTimeframeChanged();
            }
        }

        public int BarCount
        {
            //get { return (int)barCountComboBox.SelectedItem; }
            get { return int.Parse(barCountComboBox.Text); }
            set
            {
                if (barCountComboBox.SelectedItem != null && BarCount == value)
                    return;

                //barCountComboBox.SelectedItem = value;
                barCountComboBox.Text = value.ToString();
                OnBarCountChanged();
            }
        }

        public event Action<PairOfMarket> PairChanged;

        public void ClearGraph()
        {
            chart.Series[0].Points.Clear();
        }

        public event Action<Market> MarketChanged;

        public event Action<TimeframeType?> TimeframeChanged;

        public event Action<int> BarCountChanged;

        public void SetTimeframes(TimeframeType[] timeframes)
        {
            timeframeComboBox.BeginInvoke(new Action(() =>
            {
                timeframeComboBox.BeginUpdate();
                try
                {
                    var selectedTimeframe = Timeframe;

                    ClearTimeframes();
                    foreach (var timeframe in timeframes)
                    {
                        timeframeComboBox.Items.Add(timeframe);
                    }

                    Timeframe = selectedTimeframe ?? timeframes.FirstOrDefault();
                }
                finally
                {
                    timeframeComboBox.EndUpdate();
                }
            }));
        }

        private void ClearTimeframes()
        {
            timeframeComboBox.Items.Clear();
            OnTimeframeChanged();
        }

        public event Action ViewClosed;

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

        public void SetPrices(IEnumerable<HistoryPrice> historyPrices)
        {
            chart.BeginInvoke(new Action(() =>
            {
                chart.BeginInit();
                try
                {
                    ClearGraph();
                    var prices = historyPrices as HistoryPrice[] ?? historyPrices.ToArray();
                    foreach (var price in prices)
                    {
                        chart.Series[0].Points.Add(new DataPoint(price.TimeStamp.ToOADate(),
                            new[] { price.High, price.Low, price.Open, price.Close }));
                    }
                    chart.Series[0].BorderColor = Color.Black;
                    chart.Series[0].CustomProperties = "PriceDownColor=Green, PriceUpColor=Red";
                    chart.Series[0].XValueType = ChartValueType.Date;
                    chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                    chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
                    chart.DataManipulator.IsStartFromFirst = true;
                    //chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                    //chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                    //chart.ChartAreas[0].CursorX.IsUserEnabled = true;
                    //chart.ChartAreas[0].CursorY.IsUserEnabled = true;
                    chart.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
                    chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
                    //chart.ChartAreas[0].AxisY.Minimum = prices.Min(price => price.Low);
                    //chart.ChartAreas[0].AxisY.Maximum = prices.Min(price => price.High);
                }
                finally
                {
                    chart.EndInit();
                }
            }));
        }

        private void ClearPairs()
        {
            pairComboBox.Items.Clear();
            OnPairChanged();
        }

        private void CandlestickForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void marketComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnMarketChanged();
        }

        private void OnMarketChanged()
        {
            MarketChanged?.Invoke(Market);
        }

        private void pairComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnPairChanged();
        }

        private void periodComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnTimeframeChanged();
        }

        private void barCountComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnBarCountChanged();
        }

        protected virtual void OnBarCountChanged()
        {
            BarCountChanged?.Invoke(BarCount);
        }

        private void barCountComboBox_Leave(object sender, EventArgs e)
        {
            OnBarCountChanged();
        }

        private void barCountComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                OnBarCountChanged();
        }
    }
}
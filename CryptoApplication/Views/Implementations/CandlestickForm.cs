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

            // todo: to do localization
            foreach (var item in Enum.GetValues(typeof(TimeframeType)))
                timeframeComboBox.Items.Add(item);

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

        public TimeframeType Timeframe
        {
            get { return (TimeframeType)timeframeComboBox.SelectedItem; }
            set
            {
                if (timeframeComboBox.SelectedItem != null && Timeframe == value)
                    return;

                timeframeComboBox.SelectedItem = value;
                OnTimeframeChanged();
            }
        }

        public event Action<PairOfMarket> PairChanged;

        public void ClearGraph()
        {
            chart.Series[0].Points.Clear();
        }

        public event Action<Market> MarketChanged;

        public event Action<TimeframeType> TimeframeChanged;

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

        public void SetPrices(IEnumerable<HistoryPrice> prices)
        {
            chart.BeginInvoke(new Action(() =>
            {
                chart.BeginInit();
                try
                {
                    ClearGraph();
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
    }
}
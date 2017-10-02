using DomainModel.Features;
using System;
using System.Windows.Forms;
using DomainModel;
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

        private void OnPeriodChanged(TimeframeType timeframe)
        {
            TimeframeChanged?.Invoke(timeframe);
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

        public event Action<PairOfMarket> PairChanged;

        public event Action<Market> MarketChanged;

        public event Action<TimeframeType> TimeframeChanged;

        public event Action ViewClosed;

        private void CandlestickForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void periodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //OnPeriodChanged(Pair);
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
    }
}
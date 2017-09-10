using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class BalanceForm : Form, IBalanceView
    {
        public BalanceForm()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);
        }

        private void marketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketChanged?.Invoke(Market);
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Clear();
            ClearFilter?.Invoke();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(Filter);
        }

        private void BalanceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        public string Filter => filterTextBox.Text;

        public Market Market
        {
            get { return marketListBox.SelectedItem as Market; }
            set { marketListBox.SelectedItem = value; }
        }

        #region IBalanceView

        void IBalanceView.SetMarkets(IEnumerable<Market> markets)
        {
            marketListBox.BeginUpdate();
            try
            {
                marketListBox.Items.Clear();
                marketListBox.Items.AddRange(markets.ToArray<object>());
            }
            finally
            {
                marketListBox.EndUpdate();
            }
        }

        void IBalanceView.SetBalances(IEnumerable<Balance> balances)
        {
            balanceListView.BeginUpdate();
            try
            {
                balanceListView.Items.Clear();
                if (balances == null)
                    return;

                var balancesArray = balances as Balance[] ?? balances.ToArray();

                FillListView(balancesArray);
                SetTotalUsdEquivalent(balancesArray);
            }
            finally
            {
                balanceListView.EndUpdate();
            }
        }

        private void FillListView(IEnumerable<Balance> balancesArray)
        {
            foreach (var balance in balancesArray)
            {
                var item = new ListViewItem(new[]
                {
                    balance.Currency.LongName,
                    balance.Currency.Name,
                    balance.Available.ToString(CultureInfo.InvariantCulture),
                    balance.Reserved.ToString(CultureInfo.InvariantCulture),
                    balance.Pending.ToString(CultureInfo.InvariantCulture),
                    GetUsdEquivalent(balance.Currency, balance.Total),
                }) {Tag = balance};
                balanceListView.Items.Add(item);
            }
        }

        private void SetTotalUsdEquivalent(IEnumerable<Balance> balances)
        {
            double total = 0;
            foreach (var balance in balances)
            {
                var usdEquivalent = UsdEquivalent(balance.Currency, balance.Total);
                total = usdEquivalent.HasValue ? total + usdEquivalent.Value : total;
            }
            totalUsdEquivalentLabel.Text = $"{Locale.Instance.Localize("Total")}: ${(int)Math.Round(total)}";
        }

        private double? UsdEquivalent(Currency currency, double quantity)
        {
            return _getUsdRate.Invoke(currency) * quantity;
        }

        private string GetUsdEquivalent(Currency currency, double quantity)
        {
            var usdEquivalent = UsdEquivalent(currency, quantity);
            return usdEquivalent.HasValue
                ? ((int)Math.Round(usdEquivalent.Value)).ToString(CultureInfo.CurrentCulture) 
                : string.Empty;
        }

        private GetUsdRateDelegate _getUsdRate;

        void IBalanceView.SetUsdRate(GetUsdRateDelegate getUsdRate)
        {
            _getUsdRate = getUsdRate;
        }

        public event Action<Market> MarketChanged;

        public event Action<string> FilterChanged;

        public event Action ClearFilter;

        public event Action RefreshBalances;

        public event Action ViewClosed;

        #endregion IBalanceView

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshBalances?.Invoke();
        }
    }
}
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
            MarketChanged?.Invoke(this, Market);
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Clear();
            ClearFilter?.Invoke();
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, Filter);
        }

        private void BalanceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke(this, EventArgs.Empty);
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

                foreach (var balance in balances)
                {
                    var item = new ListViewItem(new[]
                    {
                        balance.Currency.LongName,
                        balance.Currency.Name,
                        balance.Available.ToString(CultureInfo.InvariantCulture),
                        balance.Pending.ToString(CultureInfo.InvariantCulture),
                    });
                    item.Tag = balance;
                    balanceListView.Items.Add(item);
                }
            }
            finally
            {
                balanceListView.EndUpdate();
            }
        }

        public event EventHandler<Market> MarketChanged;

        public event EventHandler<CurrencyOfMarket> CurrencyChanged;

        public event EventHandler<string> FilterChanged;

        public event Action ClearFilter;

        public event Action RefreshBalances;

        public event EventHandler ViewClosed;

        #endregion IBalanceView

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshBalances?.Invoke();
        }
    }
}
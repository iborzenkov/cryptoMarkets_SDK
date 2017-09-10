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
    public partial class CurrencyForm : Form, ICurrencyView, ILocalizableView
    {
        public CurrencyForm()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);
        }

        void ICurrencyView.SetMarkets(IEnumerable<Market> markets)
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

        void ICurrencyView.SetCurrencies(IEnumerable<CurrencyOfMarket> currencies)
        {
            currencyListView.BeginUpdate();
            try
            {
                currencyListView.Items.Clear();
                if (currencies == null)
                    return;

                foreach (var currency in currencies)
                {
                    var item = new ListViewItem(new[]
                    {
                        currency.Currency.LongName,
                        currency.Currency.Name,
                        IsActive(currency.IsActive),
                        currency.TxFee.ToString(CultureInfo.InvariantCulture),
                        currency.BaseAddress?.ToString() ?? string.Empty,
                    });
                    item.Checked = currency.IsActive;
                    item.Tag = currency;
                    currencyListView.Items.Add(item);
                }
            }
            finally
            {
                currencyListView.EndUpdate();
            }
        }

        void ILocalizableView.ApplyLocale()
        {
            for (var i = 0; i < currencyListView.Items.Count; i++)
            {
                var item = currencyListView.Items[i];
                var currency = item.Tag as CurrencyOfMarket;
                item.SubItems[2].Text = currency != null ? IsActive(currency.IsActive) : string.Empty;
            }
        }

        private string IsActive(bool isActive)
        {
            var key = isActive ? "Yes" : "No";
            return Locale.Instance.Localize(key);
        }

        public event Action<Market> MarketChanged;

        public event Action<string> FilterChanged;

        public event Action<bool> ActiveOnlyChanged;

        public event Action ClearFilter;

        void ICurrencyView.InitFilter()
        {
            FilterChanged?.Invoke(Filter);
            ActiveOnlyChanged?.Invoke(activeOnlyCheckBox.Checked);
        }

        public event Action ViewClosed;

        private void marketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketChanged?.Invoke(Market);
        }

        public Market Market
        {
            get { return marketListBox.SelectedItem as Market; }
            set { marketListBox.SelectedItem = value; }
        }

        public CurrencyOfMarket Currency
        {
            get
            {
                if (currencyListView.SelectedItems.Count > 0)
                    return currencyListView.SelectedItems[0].Tag as CurrencyOfMarket;
                return null;
            }
        }

        public string Filter => filterTextBox.Text;

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(Filter);
        }

        private void CurrencyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void activeOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ActiveOnlyChanged?.Invoke(activeOnlyCheckBox.Checked);
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Clear();
            ClearFilter?.Invoke();
        }
    }
}
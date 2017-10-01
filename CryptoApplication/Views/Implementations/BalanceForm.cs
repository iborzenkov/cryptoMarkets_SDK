using DomainModel.Features;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class BalanceForm : Form, IBalanceView
    {
        // todo: Изменение баланса
        readonly ListViewFreezer _freezer;

        public BalanceForm()
        {
            InitializeComponent();

            _freezer = new ListViewFreezer(balanceListView);

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

        private string Filter => filterTextBox.Text;

        private Market Market
        {
            get { return marketListBox.SelectedItem as Market; }
            set { marketListBox.SelectedItem = value; }
        }

        #region IBalanceView

        public void SetMarkets(IEnumerable<Market> markets)
        {
            marketListBox.BeginInvoke(new Action(() =>
            {
                marketListBox.BeginUpdate();
                try
                {
                    var marketsArray = markets as Market[] ?? markets.ToArray();

                    marketListBox.Items.Clear();
                    marketListBox.Items.AddRange(marketsArray.ToArray<object>());

                    if (marketsArray.Any())
                        Market = marketsArray.First();
                }
                finally
                {
                    marketListBox.EndUpdate();
                }
            }));
        }

        public void SetBalances(IEnumerable<Balance> balances)
        {
            balanceListView.BeginInvoke(new Action(() =>
            {
                balanceListView.BeginUpdate();
                try
                {
                    balanceListView.Items.Clear();
                    SetTotalUsdEquivalent(Enumerable.Empty<Balance>());

                    if (balances == null)
                        return;

                    var notNullBalances = balances.Where(b => b.Total > 0);
                    var balancesArray = notNullBalances as Balance[] ?? notNullBalances.ToArray();

                    FillListView(balancesArray);
                    SetTotalUsdEquivalent(balancesArray);

                    _freezer.UnfreezeListView();
                }
                finally
                {
                    balanceListView.EndUpdate();
                }
            }));
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
                })
                { Tag = balance };
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

        public void SetUsdRate(GetUsdRateDelegate getUsdRate)
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
            _freezer.FreezeListView();

            RefreshBalances?.Invoke();
        }
    }
}
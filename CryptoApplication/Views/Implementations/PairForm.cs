using DomainModel.Features;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class PairForm : Form, IPairView, ILocalizableView
    {
        Guid _id;
        public PairForm()
        {
            InitializeComponent();
            _id = Guid.NewGuid();
            Locale.Instance.RegisterView(this);
        }

        void IPairView.SetMarkets(IEnumerable<Market> markets)
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

        void IPairView.SetPairs(IEnumerable<PairOfMarket> pairs)
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
                        PairStatistic statistic = null;
                        if (_statistics != null)
                            statistic = _statistics.FirstOrDefault(s => s.Pair.Equals(pair.Pair));

                        var item = new ListViewItem(new[]
                        {
                            pair.Pair.ToString(),
                            IsActive(pair.IsActive),
                            DailyChange(statistic)
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

        private string IsActive(bool isActive)
        {
            var key = isActive ? "Yes" : "No";
            return Locale.Instance.Localize(key);
        }

        void ILocalizableView.ApplyLocale()
        {
            for (var i = 0; i < pairListView.Items.Count; i++)
            {
                var item = pairListView.Items[i];
                var pair = item.Tag as PairOfMarket;
                item.SubItems[1].Text = pair != null ? IsActive(pair.IsActive) : string.Empty;
            }
        }

        private string DailyChange(PairStatistic statistic)
        {
            return statistic == null
                ? string.Empty
                : $"{Math.Round(statistic.DailyChangeOfLastPrice(), 2).ToString(CultureInfo.InvariantCulture)}%";
        }

        private IEnumerable<PairStatistic> _statistics;

        public void SetStatistics(IEnumerable<PairStatistic> statistics)
        {
            _statistics = statistics;
            // todo: метод вызывается для первой формы из двух закрытых, видимо, что-то не уничтожается корректно
            pairListView.BeginInvoke(new Action(() =>
            {
                pairListView.BeginUpdate();
                try
                {
                    if (statistics == null)
                        return;

                    var pairStatistics = _statistics as PairStatistic[] ?? _statistics.ToArray();
                    for (var i = 0; i < pairListView.Items.Count; i++)
                    {
                        var pair = pairListView.Items[i].Tag as PairOfMarket;
                        if (pair == null)
                            continue;

                        var statistic = pairStatistics.FirstOrDefault(s => s.Pair.Equals(pair.Pair));
                        pairListView.Items[i].SubItems[2].Text = DailyChange(statistic);
                    }
                }
                finally
                {
                    pairListView.EndUpdate();
                }
            }));
        }

        public event EventHandler<Market> MarketChanged;

        public event EventHandler<PairViewFilter> FilterChanged;

        void IPairView.InitFilter()
        {
            FilterChanged?.Invoke(this, Filter);
        }

        public event EventHandler ViewClosed;

        private void marketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketChanged?.Invoke(this, Market);
        }

        public Market Market
        {
            get { return marketListBox.SelectedItem as Market; }
            set { marketListBox.SelectedItem = value; }
        }

        public PairOfMarket Pair
        {
            get
            {
                if (pairListView.SelectedItems.Count > 0)
                    return pairListView.SelectedItems[0].Tag as PairOfMarket;
                return null;
            }
        }

        public PairViewFilter Filter
        {
            get
            {
                var dailyChange = DailyChangePairEnum.All;
                if (positiveDailyChangeRadioButton.Checked)
                    dailyChange = DailyChangePairEnum.PositiveOnly;
                if (negativeDailyChangeRadioButton.Checked)
                    dailyChange = DailyChangePairEnum.NegativeOnly;

                var filter = new PairViewFilter
                {
                    PairToken = filterTextBox.Text,
                    IsActiveOnly = activeOnlyCheckBox.Checked,
                    DailyChange = dailyChange,
                };
                return filter;
            }
        }

        private void filterTextBox_TextChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, Filter);
        }

        private void PairForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke(this, EventArgs.Empty);
        }

        private void activeOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, Filter);
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Clear();
            FilterChanged?.Invoke(this, Filter);
        }

        private void positiveDailyChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, Filter);
        }

        private void negativeDailyChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, Filter);
        }

        private void allDailyChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FilterChanged?.Invoke(this, Filter);
        }

        private void pairListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var column = e.Column;

            bool mode = _sorting.TryGetValue(column, out mode) ? !mode : true;

            pairListView.ListViewItemSorter = new ListViewItemComparer(column, mode);
            pairListView.Sort();

            if (_sorting.ContainsKey(column))
                _sorting.Remove(column);
            _sorting.Add(column, mode);
        }

        private readonly Dictionary<int, bool> _sorting = new Dictionary<int, bool>();
    }

    internal class ListViewItemComparer : IComparer
    {
        private readonly int _column;
        private readonly bool _mode;

        public ListViewItemComparer(int column, bool mode)
        {
            _column = column;
            _mode = mode;
        }

        public int Compare(object x, object y)
        {
            // todo: сделать "человеческую" сортировку
            // todo: растиражировать её на другие формы
            var value1 = ((ListViewItem)x).SubItems[_column].Text;
            var value2 = ((ListViewItem)y).SubItems[_column].Text;

            if (!_mode)
            {
                var tmp = value1;
                value1 = value2;
                value2 = tmp;
            }

            return string.Compare(value1, value2, StringComparison.Ordinal);
        }
    }
}
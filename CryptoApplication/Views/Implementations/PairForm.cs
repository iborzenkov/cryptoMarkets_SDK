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
        public PairForm()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);
        }

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
                        PairStatistic statistic = null;
                        if (_statistics != null)
                            statistic = _statistics.FirstOrDefault(s => s.Pair.Equals(pair.Pair));

                        var item = new ListViewItem(new[]
                        {
                            pair.Pair.ToString(),
                            IsActive(pair.IsActive),
                            DailyChange(statistic),
                            DailyVolume(statistic)
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

        private string DailyVolume(PairStatistic statistic)
        {
            return statistic == null
                ? string.Empty
                : $"{statistic.BaseVolume.ToString(CultureInfo.InvariantCulture)}";
        }

        private string IsActive(bool isActive)
        {
            var key = isActive ? "Yes" : "No";
            return Locale.Instance.Localize(key);
        }

        public void ApplyLocale()
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
            pairListView.BeginInvoke(new Action(() =>
            {
                _statistics = statistics;

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
                        pairListView.Items[i].SubItems[3].Text = DailyVolume(statistic);
                    }
                }
                finally
                {
                    pairListView.EndUpdate();
                }
            }));
        }

        public event Action<Market> MarketChanged;

        public event Action<PairViewFilter> FilterChanged;

        public void InitFilter()
        {
            ChangedFilter();
        }

        public event Action ViewClosed;

        private void marketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketChanged?.Invoke(Market);
        }

        private Market Market
        {
            get { return marketListBox.SelectedItem as Market; }
            set { marketListBox.SelectedItem = value; }
        }

        private PairOfMarket Pair
        {
            get
            {
                if (pairListView.SelectedItems.Count > 0)
                    return pairListView.SelectedItems[0].Tag as PairOfMarket;
                return null;
            }
        }

        private PairViewFilter Filter
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
            ChangedFilter();
        }

        private void PairForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void activeOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ChangedFilter();
        }

        private void clearFilterButton_Click(object sender, EventArgs e)
        {
            filterTextBox.Clear();
            ChangedFilter();
        }

        private void positiveDailyChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangedFilter();
        }

        private void negativeDailyChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangedFilter();
        }

        private void allDailyChangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangedFilter();
        }

        private void ChangedFilter()
        {
            FilterChanged?.Invoke(Filter);
        }

        private void pairListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var column = e.Column;

            bool mode = _sorting.TryGetValue(column, out mode) ? !mode : true;

            pairListView.ListViewItemSorter = new ListViewItemComparer(column, mode, _statistics);
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
        private readonly IEnumerable<PairStatistic> _statistics;

        public ListViewItemComparer(int column, bool mode, IEnumerable<PairStatistic> statistics)
        {
            _column = column;
            _mode = mode;
            _statistics = statistics;
        }

        private int CompareStrings(string x, string y)
        {
            var value1 = x;
            var value2 = y;

            if (!_mode)
            {
                var tmp = value1;
                value1 = value2;
                value2 = tmp;
            }

            return string.Compare(value1, value2, StringComparison.Ordinal);
        }

        private int CompareNumbers(double x, double y)
        {
            var value1 = x;
            var value2 = y;

            if (!_mode)
            {
                var tmp = value1;
                value1 = value2;
                value2 = tmp;
            }

            return value1.CompareTo(value2);
        }

        private PairStatistic Statistic(object obj)
        {
            var pair = ((ListViewItem)obj).Tag as PairOfMarket;
            return _statistics.FirstOrDefault(s => s.Pair.Equals(pair.Pair));
        }

        public int Compare(object x, object y)
        {
            switch (_column)
            {
                case 2:
                    return CompareNumbers(Statistic(x).DailyChangeOfLastPrice(), Statistic(y).DailyChangeOfLastPrice());

                case 3:
                    return CompareNumbers(Statistic(x).BaseVolume, Statistic(y).BaseVolume);
            }

            return CompareStrings(
                ((ListViewItem)x).SubItems[_column].Text,
                ((ListViewItem)y).SubItems[_column].Text);
        }
    }
}
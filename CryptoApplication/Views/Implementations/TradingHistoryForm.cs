using DomainModel;
using DomainModel.Features;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class TradingHistoryForm : Form, ITradingHistoryView
    {
        private class NullItem
        {
            public override string ToString()
            {
                return Locale.Instance.Localize("All");
            }
        }

        public TradingHistoryForm()
        {
            InitializeComponent();

            // todo: to do localization
            var allItem = new NullItem();
            periodComboBox.Items.Clear();
            periodComboBox.Items.Add(allItem);
            foreach (var item in Enum.GetValues(typeof(Period)))
                periodComboBox.Items.Add(item);
            periodComboBox.SelectedItem = allItem;

            // todo: to do localization
            allItem = new NullItem();
            orderTypeComboBox.Items.Clear();
            orderTypeComboBox.Items.Add(allItem);
            foreach (var item in Enum.GetValues(typeof(TradePosition)))
                orderTypeComboBox.Items.Add(item);
            orderTypeComboBox.SelectedItem = allItem;

            Locale.Instance.RegisterView(this);
        }

        public void SetMarkets(IEnumerable<Market> markets)
        {
            marketComboBox.BeginInvoke(new Action(() =>
            {
                marketComboBox.BeginUpdate();
                try
                {
                    var allItem = new NullItem();

                    marketComboBox.Items.Clear();
                    marketComboBox.Items.Add(allItem);
                    marketComboBox.Items.AddRange(markets.ToArray<object>());

                    marketComboBox.SelectedItem = allItem;
                }
                finally
                {
                    marketComboBox.EndUpdate();
                }
            }));
        }

        public void SetPairs(IEnumerable<Pair> pairs)
        {
            pairComboBox.BeginInvoke(new Action(() =>
            {
                pairComboBox.BeginUpdate();
                try
                {
                    var allItem = new NullItem();

                    pairComboBox.Items.Clear();
                    pairComboBox.Items.Add(allItem);
                    pairComboBox.Items.AddRange(pairs.ToArray<object>());

                    pairComboBox.SelectedItem = allItem;
                }
                finally
                {
                    pairComboBox.EndUpdate();
                }
            }));
        }

        public void SetHistoryOrders(IEnumerable<HistoryOrder> orders)
        {
            historyOrdersListView.BeginInvoke(new Action(() =>
            {
                historyOrdersListView.BeginUpdate();
                try
                {
                    var oldSelectedOrderId = GetSelectedOrder();
                    historyOrdersListView.Items.Clear();
                    if (orders == null)
                        return;

                    FillHistoryOrders(orders);
                    SelectOrderIfPossible(oldSelectedOrderId);
                }
                finally
                {
                    historyOrdersListView.EndUpdate();
                }
            }));

            statusStrip.BeginInvoke(new Action(() =>
            {
                totalLabel.Text = $"{Locale.Instance.Localize("Total")}: {orders.Count()}"; 
            }));
        }

        private void FillHistoryOrders(IEnumerable<HistoryOrder> orders)
        {
            foreach (var order in orders)
            {
                var item = new ListViewItem(new[]
                {
                    order.Market.Name,
                    order.Pair.ToString(),
                    TradePositionAsString(order.Position),
                    order.Price.ToString("F8", CultureInfo.CurrentCulture),
                    order.Quantity.ToString("F8", CultureInfo.CurrentCulture),
                    order.Fee.ToString("F8", CultureInfo.CurrentCulture),
                    GetOrderDate(order.Time),
                });
                item.Tag = order;
                historyOrdersListView.Items.Add(item);
            }
        }

        private string GetOrderDate(DateTime? opened)
        {
            return opened?.ToString() ?? string.Empty;
        }

        private OrderId GetSelectedOrder()
        {
            return historyOrdersListView.SelectedItems.Count > 0 ? (historyOrdersListView.SelectedItems[0].Tag as HistoryOrder)?.Id : null;
        }

        private void SelectOrderIfPossible(OrderId selectedOrderId)
        {
            if (selectedOrderId == null)
                return;

            for (var i = 0; i < historyOrdersListView.Items.Count; i++)
            {
                var order = historyOrdersListView.Items[i].Tag as HistoryOrder;
                if (order == null)
                    continue;

                if (order.Id.Equals(selectedOrderId))
                {
                    historyOrdersListView.SelectedIndices.Clear();
                    historyOrdersListView.SelectedIndices.Add(i);
                    break;
                }
            }
        }

        private static string TradePositionAsString(TradePosition position)
        {
            return Locale.Instance.Localize(position == DomainModel.TradePosition.Buy ? "Buy" : "Sell");
        }

        private Market Market => marketComboBox.SelectedItem as Market;

        private Pair Pair => pairComboBox.SelectedItem as Pair;

        private TradePosition? TradePosition => orderTypeComboBox.SelectedItem as TradePosition?;

        private Period? Period => periodComboBox.SelectedItem as Period?;

        private HistoryOrdersFilter Filter => new HistoryOrdersFilter(Market, Pair, TradePosition, Period);

        public event Action ViewClosed;

        public event Action<HistoryOrdersFilter> FilterChanged;

        private void TradingHistoryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void OnFilterChanged()
        {
            FilterChanged?.Invoke(Filter);
        }

        private void pairComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        public void SetUsdRate(GetUsdRateDelegate getUsdRate)
        {
            _getUsdRate = getUsdRate;
        }

        private GetUsdRateDelegate _getUsdRate;

        public void SetFilter(HistoryOrdersFilter filter)
        {
            var changed = false;

            if (Market != filter.Market)
            {
                marketComboBox.SelectedItem = filter.Market;
                changed = true;
            }

            if (Pair != filter.Pair)
            {
                pairComboBox.SelectedItem = filter.Pair;
                changed = true;
            }

            if (orderTypeComboBox.SelectedItem == null || TradePosition != filter.Position)
            {
                orderTypeComboBox.SelectedItem = filter.Position;
                changed = true;
            }

            if (periodComboBox.SelectedItem == null || Period != filter.Period)
            {
                periodComboBox.SelectedItem = filter.Period;
                changed = true;
            }

            if (changed)
                OnFilterChanged();
        }

        private double? UsdEquivalent(Currency currency, double quantity)
        {
            return _getUsdRate.Invoke(currency) * quantity;
        }

        private void marketComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        private void periodComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnFilterChanged();
        }

        private void orderTypeComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            OnFilterChanged();
        }
    }
}
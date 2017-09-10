using DomainModel.Features;
using DomainModel.MarketModel;
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
    public partial class OrderBookControl : UserControl, IOrderBookPartView
    {
        public OrderBookControl()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);
        }

        private void OrderBookControl_Resize(object sender, EventArgs e)
        {
            askListView.Height = Height / 2;
        }

        private void askListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            SyncronizeColumnWidth(askListView, bidListView);
        }

        private void SyncronizeColumnWidth(ListView changedListView, ListView syncronizedListView)
        {
            for (var i = 0; i < changedListView.Columns.Count; i++)
                syncronizedListView.Columns[i].Width = changedListView.Columns[i].Width;
        }

        private void bidListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            SyncronizeColumnWidth(bidListView, askListView);
        }

        private readonly object _askLock = new object();
        private readonly object _bidLock = new object();

        private void SetOrderBookClear(IOrderBook orderBook)
        {
            askListView.BeginInvoke(new Action(() =>
            {
                askListView.BeginUpdate();
                try
                {
                    var selectedPrice = GetSelectedPrice(askListView);
                    askListView.Items.Clear();

                    if (orderBook == null)
                        return;

                    lock (_askLock)
                    {
                        FillListView(orderBook.Asks, askListView);
                        HighlightLargePositions(orderBook.LargeAsksIndexes, askListView, Color.IndianRed);
                        FocusLastItem(askListView);
                        SelectPriceIfPossible(selectedPrice, askListView);
                    }
                }
                finally
                {
                    askListView.EndUpdate();
                }
            }));

            bidListView.BeginInvoke(new Action(() =>
            {
                bidListView.BeginUpdate();
                try
                {
                    var selectedPrice = GetSelectedPrice(bidListView);
                    bidListView.Items.Clear();

                    if (orderBook == null)
                        return;

                    lock (_bidLock)
                    {
                        FillListView(orderBook.Bids, bidListView);
                        HighlightLargePositions(orderBook.LargeBidsIndexes, bidListView, Color.ForestGreen);
                        FocusFirstItem(bidListView);
                        SelectPriceIfPossible(selectedPrice, bidListView);
                    }
                }
                finally
                {
                    bidListView.EndUpdate();
                }
            }));
        }

        private void FocusLastItem(ListView listView)
        {
            SetFocusedItem(listView, true);
        }

        private void FocusFirstItem(ListView listView)
        {
            SetFocusedItem(listView, false);
        }

        private void SetFocusedItem(ListView listView, bool isLastItemFocused)
        {
            if (listView.Items.Count > 0)
            {
                var item = isLastItemFocused ? listView.Items[listView.Items.Count - 1] : listView.Items[0];
                listView.FocusedItem = item;
                item.EnsureVisible();
            }
        }

        private void HighlightLargePositions(IEnumerable<int> indexes, ListView listView, Color color)
        {
            foreach (var index in indexes)
            {
                listView.Items[index].BackColor = color;
            }
        }

        private void FillListView(IEnumerable<OrderBookPart> parts, ListView listView)
        {
            foreach (var part in parts)
            {
                var item = new ListViewItem { Text = part.Price.ToString(CultureInfo.CurrentCulture) };
                item.SubItems.Add(part.Quantity.ToString(CultureInfo.CurrentCulture));
                item.SubItems.Add(part.SumQuantity.ToString(CultureInfo.CurrentCulture));
                item.SubItems.Add(GetUsdEquivalent(part.Quantity));
                listView.Items.Add(item);
            }
        }

        private string GetSelectedPrice(ListView listView)
        {
            var selectedPrice = string.Empty;
            if (listView.SelectedItems.Count > 0)
                selectedPrice = listView.SelectedItems[0].Text;
            return selectedPrice;
        }

        private void SelectPriceIfPossible(string selectedPrice, ListView listView)
        {
            if (!string.IsNullOrEmpty(selectedPrice))
            {
                for (var i = 0; i < listView.Items.Count; i++)
                {
                    if (listView.Items[i].Text == selectedPrice)
                    {
                        listView.SelectedIndices.Add(i);
                        break;
                    }
                }
            }
        }

        private string GetUsdEquivalent(double quantity)
        {
            return _usdRate.HasValue ? Math.Round(quantity * _usdRate.Value).ToString(CultureInfo.CurrentCulture) : string.Empty;
        }

        private void SetOrderBookByItem(IOrderBook orderBook)
        {
            askListView.BeginInvoke(new Action(() =>
            {
                askListView.BeginUpdate();
                if (orderBook == null)
                    askListView.Items.Clear();
                else
                {
                    var asks = orderBook.Asks.ToList();
                    var diff = asks.Count - askListView.Items.Count;
                    if (diff < 0)
                    {
                        for (var i = 0; i < Math.Abs(diff); i++)
                            askListView.Items.RemoveAt(0);
                    }
                    else if (diff > 0)
                    {
                        /*for (var i = 0; i < Math.Abs(diff); i++)
                        {
                            var item = new ListViewItem {Text = ask.Price.ToString(CultureInfo.CurrentCulture)};
                            item.SubItems.Add(ask.Quantity.ToString(CultureInfo.CurrentCulture));
                            askListView.Items.Add(item);
                        }*/
                    }
                    else
                    {
                        for (var i = 0; i < asks.Count; i++)
                        {
                            var ask = asks[asks.Count - i - 1];
                            askListView.Items[i].Text = ask.Price.ToString(CultureInfo.CurrentCulture);
                            askListView.Items[i].SubItems[0].Text = ask.Quantity.ToString(CultureInfo.CurrentCulture);
                        }
                    }

                    if (askListView.Items.Count > 0)
                    {
                        askListView.FocusedItem = askListView.Items[askListView.Items.Count - 1];
                        askListView.Items[askListView.Items.Count - 1].EnsureVisible();
                    }
                }

                askListView.EndUpdate();
            }));

            bidListView.BeginInvoke(new Action(() =>
            {
                bidListView.BeginUpdate();
                if (orderBook == null)
                    bidListView.Items.Clear();
                else
                {
                    var bids = orderBook.Bids.ToList();
                    var diff = bids.Count - bidListView.Items.Count;
                    if (diff < 0)
                    {
                        for (var i = 0; i < Math.Abs(diff); i++)
                            bidListView.Items.RemoveAt(diff);
                    }
                    else if (diff > 0)
                    {
                        for (var i = 0; i < bidListView.Items.Count; i++)
                        {
                            var bid = bids[i];
                            bidListView.Items[i].Text = bid.Price.ToString(CultureInfo.CurrentCulture);
                            bidListView.Items[i].SubItems[0].Text = bid.Quantity.ToString(CultureInfo.CurrentCulture);
                        }
                        var count = bidListView.Items.Count;
                        for (var i = 0; i < Math.Abs(diff); i++)
                        {
                            var bid = bids[i + count];
                            var item = new ListViewItem { Text = bid.Price.ToString(CultureInfo.CurrentCulture) };
                            item.SubItems.Add(bid.Quantity.ToString(CultureInfo.CurrentCulture));
                            bidListView.Items.Add(item);
                        }
                    }
                    else
                    {
                        for (var i = 0; i < bids.Count; i++)
                        {
                            var bid = bids[i];
                            var newText = bid.Price.ToString(CultureInfo.CurrentCulture);
                            if (newText != bidListView.Items[i].Text)
                                bidListView.Items[i].Text = bid.Price.ToString(CultureInfo.CurrentCulture);

                            newText = bid.Quantity.ToString(CultureInfo.CurrentCulture);
                            if (newText != bidListView.Items[i].SubItems[0].Text)
                                bidListView.Items[i].SubItems[0].Text = bid.Quantity.ToString(CultureInfo.CurrentCulture);
                        }
                    }

                    if (bidListView.Items.Count > 0)
                    {
                        bidListView.FocusedItem = bidListView.Items[0];
                        bidListView.Items[0].EnsureVisible();
                    }
                }

                bidListView.EndUpdate();
            }));
        }

        void IOrderBookPartView.SetOrderBook(IOrderBook orderBook)
        {
            SetOrderBookClear(orderBook);
            //SetOrderBookByItem(orderBook);
        }

        private double? _usdRate;

        void IOrderBookPartView.SetUsdRate(double? usdRate)
        {
            _usdRate = usdRate;
        }

        public void Close()
        {
            Locale.Instance.UnRegisterView(this);
        }
    }
}
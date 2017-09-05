using DomainModel.MarketModel;
using System;
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
                askListView.Items.Clear();

                if (orderBook != null)
                {
                    lock (_askLock)
                    {
                        foreach (var ask in orderBook.Asks)
                        {
                            var item = new ListViewItem { Text = ask.Price.ToString(CultureInfo.CurrentCulture) };
                            item.SubItems.Add(ask.Quantity.ToString(CultureInfo.CurrentCulture));
                            item.SubItems.Add(ask.SumQuantity.ToString(CultureInfo.CurrentCulture));
                            askListView.Items.Add(item);
                        }

                        if (askListView.Items.Count > 0)
                        {
                            askListView.FocusedItem = askListView.Items[askListView.Items.Count - 1];
                            askListView.Items[askListView.Items.Count - 1].EnsureVisible();
                        }
                    }
                }

                askListView.EndUpdate();
            }));

            bidListView.BeginInvoke(new Action(() =>
            {
                bidListView.BeginUpdate();
                bidListView.Items.Clear();

                if (orderBook != null)
                {
                    lock (_bidLock)
                    {
                        foreach (var bid in orderBook.Bids)
                        {
                            var item = new ListViewItem { Text = bid.Price.ToString(CultureInfo.CurrentCulture) };
                            item.SubItems.Add(bid.Quantity.ToString(CultureInfo.CurrentCulture));
                            item.SubItems.Add(bid.SumQuantity.ToString(CultureInfo.CurrentCulture));
                            bidListView.Items.Add(item);
                        }

                        if (bidListView.Items.Count > 0)
                        {
                            bidListView.FocusedItem = bidListView.Items[0];
                            bidListView.Items[0].EnsureVisible();
                        }
                    }
                }

                bidListView.EndUpdate();
            }));
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

        public void Close()
        {
            Locale.Instance.UnRegisterView(this);
        }
    }
}
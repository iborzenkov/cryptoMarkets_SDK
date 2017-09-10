using System;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);
        }

        public new void Show()
        {
            Application.Run(this);
        }

        public event Action ViewClosed;

        private void orderbooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowOrderBook();
        }

        Form IMainView.MdiParentForm => this;

        private void OnShowOrderBook()
        {
            ShowOrderBook?.Invoke();
        }

        private void OnExit()
        {
            Locale.Instance.UnRegisterView(this);

            Exit?.Invoke();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnExit();
        }

        private void OnViewClosed()
        {
            ViewClosed?.Invoke();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnViewClosed();
        }

        private void currenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowCurrencies();
        }

        protected virtual void OnShowCurrencies()
        {
            ShowCurrencies?.Invoke();
        }

        protected virtual void OnShowPairs()
        {
            ShowPairs?.Invoke();
        }

        public event Action ShowOrderBook;

        public event Action ShowCurrencies;

        public event Action ShowPairs;

        public event Action ShowApiKeys;

        public event Action ShowBalances;

        public event Action ShowMarketTrade;

        public event Action ShowPendingTrade;

        public event Action Exit;

        private void balancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowBalances?.Invoke();
        }

        private void apiKeysToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowApiKeys?.Invoke();
        }

        private void tradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMarketTrade?.Invoke();
        }

        private void pairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OnShowPairs();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.Instance.SetPackage("us");
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Locale.Instance.SetPackage("ru");
        }

        private void pendingTradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPendingTrade?.Invoke();
        }
    }
}
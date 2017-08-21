using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Views.Interfaces;
using Views.Localization;

namespace Views.Implementations
{
    public partial class ApiKeyForm : Form, IApiKeyView, ILocalizableView
    {
        public ApiKeyForm()
        {
            InitializeComponent();

            Locale.Instance.RegisterView(this);
        }

        private const string PublicControlName = "publicTextBox";
        private const string PrivateControlName = "privateTextBox";

        void IApiKeyView.SetMarkets(IEnumerable<Market> markets)
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

        readonly List<Label> _privateKeyLabels = new List<Label>();
        readonly List<Label> _publicKeyLabels = new List<Label>();
        readonly List<GroupBox> _panels = new List<GroupBox>();

        private string PrivateKeyText => Locale.Instance.Localize("PrivateKey");
        private string PublicKeyText => Locale.Instance.Localize("PublicKey");

        void IApiKeyView.SetApiKeyRoles(IEnumerable<ApiKeyRole> roles)
        {
            _privateKeyLabels.Clear();
            _publicKeyLabels.Clear();
            _panels.Clear();

            var top = 30;
            foreach (var role in roles)
            {
                var topControls = 28;
                var groupBox = new GroupBox
                {
                    Text = ApiKeyRoleCaption.Caption(role),
                    Parent = apiKeysGroupBox,
                    Location = new Point(14, top),
                    Size = new Size(267, topControls + 60),
                    Tag = role,
                };
                var privateKeyLabel = new Label
                {
                    Text = PrivateKeyText,
                    Location = new Point(3, topControls + 3),
                    Parent = groupBox,
                    AutoSize = true,
                };
                _privateKeyLabels.Add(privateKeyLabel);
                var privateTextBox = new TextBox
                {
                    Location = new Point(70, topControls),
                    Size = new Size(191, 20),
                    Parent = groupBox,
                    Tag = role,
                    Name = PrivateControlName,
                };
                privateTextBox.TextChanged += PrivateTextBox_TextChanged;
                var publicKeyLabel = new Label
                {
                    Text = PublicKeyText,
                    Location = new Point(3, topControls + 29),
                    Parent = groupBox,
                    AutoSize = true,
                };
                _publicKeyLabels.Add(publicKeyLabel);
                var publicTextBox = new TextBox
                {
                    Location = new Point(70, topControls + 26),
                    Size = new Size(191, 20),
                    Parent = groupBox,
                    Tag = role,
                    Name = PublicControlName,
                };
                publicTextBox.TextChanged += PublicTextBox_TextChanged;

                top = top + 100;

                _panels.Add(groupBox);
            }
        }

        void IApiKeyView.SetApiKeys(ApiKeyPair apiKeyPair)
        {
            foreach (var control in apiKeysGroupBox.Controls.OfType<Control>())
            {
                if (!(control.Tag is ApiKeyRole))
                    continue;

                if ((ApiKeyRole)control.Tag == apiKeyPair.Role)
                {
                    if (apiKeyPair.PublicKey != null)
                    {
                        var publicControl = control.Controls.Find(PublicControlName, false)[0];
                        publicControl.Text = apiKeyPair.PublicKey.Key;
                    }

                    if (apiKeyPair.PrivateKey != null)
                    {
                        var privateControl = control.Controls.Find(PrivateControlName, false)[0];
                        privateControl.Text = apiKeyPair.PrivateKey.Key;
                    }
                }
            }
        }

        void IApiKeyView.SetSelectedMarket(Market market)
        {
            Market = market;
        }

        private bool ApiKeyFromControls(object control, out IApiKey apiKey, out ApiKeyRole role)
        {
            apiKey = null;
            role = ApiKeyRole.Account;

            var textBox = control as TextBox;
            if (textBox == null)
                return false;

            var value = textBox.Text;
            if (!(textBox.Tag is ApiKeyRole))
                throw new Exception("textBox.Tag is not ApiKeyRole");

            apiKey = string.IsNullOrEmpty(value) ? null : new ApiKey(value);
            role = (ApiKeyRole)textBox.Tag;
            return true;
        }

        private void PublicTextBox_TextChanged(object sender, EventArgs eventArgs)
        {
            IApiKey apiKey;
            ApiKeyRole role;
            if (ApiKeyFromControls(sender, out apiKey, out role))
                PublicApiKeyChanged?.Invoke(this, new Tuple<ApiKeyRole, IApiKey>(role, apiKey));
        }

        private void PrivateTextBox_TextChanged(object sender, EventArgs eventArgs)
        {
            IApiKey apiKey;
            ApiKeyRole role;
            if (ApiKeyFromControls(sender, out apiKey, out role))
                PrivateApiKeyChanged?.Invoke(this, new Tuple<ApiKeyRole, IApiKey>(role, apiKey));
        }

        public event EventHandler<Market> MarketChanged;

        public event EventHandler ViewClosed;

        public event EventHandler<Tuple<ApiKeyRole, IApiKey>> PrivateApiKeyChanged;

        public event EventHandler<Tuple<ApiKeyRole, IApiKey>> PublicApiKeyChanged;

        private void ApiKeyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke(this, EventArgs.Empty);
        }

        private void marketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketChanged?.Invoke(this, Market);
        }

        public Market Market
        {
            get { return marketListBox.SelectedItem as Market; }
            set { marketListBox.SelectedItem = value; }
        }

        void ILocalizableView.ApplyLocale()
        {
            _privateKeyLabels.ForEach(l => l.Text = PrivateKeyText);
            _publicKeyLabels.ForEach(l => l.Text = PublicKeyText);
            _panels.ForEach(p => p.Text = ApiKeyRoleCaption.Caption((ApiKeyRole)p.Tag));
        }
    }
}
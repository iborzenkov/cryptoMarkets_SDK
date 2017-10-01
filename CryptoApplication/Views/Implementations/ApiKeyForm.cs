using DomainModel.Features;
using DomainModel.MarketModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DomainModel.MarketModel.ApiKeys;
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

        private readonly List<Label> _privateKeyLabels = new List<Label>();
        private readonly List<Label> _publicKeyLabels = new List<Label>();
        private readonly List<GroupBox> _panels = new List<GroupBox>();

        private string PrivateKeyText => Locale.Instance.Localize("PrivateKey");
        private string PublicKeyText => Locale.Instance.Localize("PublicKey");

        public void SetApiKeyRoles(IEnumerable<ApiKeyRole> roles)
        {
            _privateKeyLabels.Clear();
            _publicKeyLabels.Clear();
            _panels.Clear();
            apiKeysGroupBox.Controls.Clear();

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

        public void SetApiKeys(Authenticator authenticator)
        {
            foreach (var control in apiKeysGroupBox.Controls.OfType<Control>())
            {
                if (!(control.Tag is ApiKeyRole))
                    continue;

                if ((ApiKeyRole)control.Tag == authenticator.Role)
                {
                    if (authenticator.PublicKey != null)
                    {
                        var publicControl = control.Controls.Find(PublicControlName, false)[0];
                        publicControl.Text = authenticator.PublicKey.Key;
                    }

                    if (authenticator.PrivateKey != null)
                    {
                        var privateControl = control.Controls.Find(PrivateControlName, false)[0];
                        privateControl.Text = authenticator.PrivateKey.Key;
                    }
                }
            }
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
                PublicApiKeyChanged?.Invoke(new Tuple<ApiKeyRole, IApiKey>(role, apiKey));
        }

        private void PrivateTextBox_TextChanged(object sender, EventArgs eventArgs)
        {
            IApiKey apiKey;
            ApiKeyRole role;
            if (ApiKeyFromControls(sender, out apiKey, out role))
                PrivateApiKeyChanged?.Invoke(new Tuple<ApiKeyRole, IApiKey>(role, apiKey));
        }

        public event Action<Market> MarketChanged;

        public event Action ViewClosed;

        public event Action<Tuple<ApiKeyRole, IApiKey>> PrivateApiKeyChanged;

        public event Action<Tuple<ApiKeyRole, IApiKey>> PublicApiKeyChanged;

        private void ApiKeyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Locale.Instance.UnRegisterView(this);

            ViewClosed?.Invoke();
        }

        private void marketListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarketChanged?.Invoke(Market);
        }

        private Market Market
        {
            get { return marketListBox.SelectedItem as Market; }
            set { marketListBox.SelectedItem = value; }
        }

        public void ApplyLocale()
        {
            _privateKeyLabels.ForEach(l => l.Text = PrivateKeyText);
            _publicKeyLabels.ForEach(l => l.Text = PublicKeyText);
            _panels.ForEach(p => p.Text = ApiKeyRoleCaption.Caption((ApiKeyRole)p.Tag));
        }
    }
}
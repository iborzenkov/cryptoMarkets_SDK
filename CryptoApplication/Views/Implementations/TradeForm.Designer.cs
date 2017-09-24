using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "TradeForm")]
    partial class TradeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topPanel = new System.Windows.Forms.Panel();
            this.myOrdersGroupBox = new System.Windows.Forms.GroupBox();
            this.ordersContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openedOrdersListView = new System.Windows.Forms.ListView();
            this.marketColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orderTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openedDateColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.marketLabel = new System.Windows.Forms.Label();
            this.iWantToGroupBox = new System.Windows.Forms.GroupBox();
            this.priceGroupBox = new System.Windows.Forms.GroupBox();
            this.limitOrderRadioButton = new System.Windows.Forms.RadioButton();
            this.marketPriceRadioButton = new System.Windows.Forms.RadioButton();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.quantityGroupBox = new System.Windows.Forms.GroupBox();
            this.spendingUsdQuantityTextBox = new System.Windows.Forms.TextBox();
            this.usdCurrencyLabel = new System.Windows.Forms.Label();
            this.spendingUsdRadioButton = new System.Windows.Forms.RadioButton();
            this.spendingQuantityTextBox = new System.Windows.Forms.TextBox();
            this.quoteCurrencyLabel = new System.Windows.Forms.Label();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.baseCurrencyLabel = new System.Windows.Forms.Label();
            this.allAvailableRadioButton = new System.Windows.Forms.RadioButton();
            this.spendingRadioButton = new System.Windows.Forms.RadioButton();
            this.exactlyRadioButton = new System.Windows.Forms.RadioButton();
            this.tradeButton = new System.Windows.Forms.Button();
            this.buyLimitRadioButton = new System.Windows.Forms.RadioButton();
            this.sellLimitRadioButton = new System.Windows.Forms.RadioButton();
            this.marketComboBox = new System.Windows.Forms.ComboBox();
            this.pairLabel = new System.Windows.Forms.Label();
            this.pairComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.infoMessageStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.availableLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.availableQuantityLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.priceStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.priceValueLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel.SuspendLayout();
            this.myOrdersGroupBox.SuspendLayout();
            this.ordersContextMenuStrip.SuspendLayout();
            this.iWantToGroupBox.SuspendLayout();
            this.priceGroupBox.SuspendLayout();
            this.quantityGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.myOrdersGroupBox);
            this.topPanel.Controls.Add(this.marketLabel);
            this.topPanel.Controls.Add(this.iWantToGroupBox);
            this.topPanel.Controls.Add(this.marketComboBox);
            this.topPanel.Controls.Add(this.pairLabel);
            this.topPanel.Controls.Add(this.pairComboBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(553, 337);
            this.topPanel.TabIndex = 2;
            // 
            // myOrdersGroupBox
            // 
            this.myOrdersGroupBox.ContextMenuStrip = this.ordersContextMenuStrip;
            this.myOrdersGroupBox.Controls.Add(this.openedOrdersListView);
            this.myOrdersGroupBox.Location = new System.Drawing.Point(15, 170);
            this.myOrdersGroupBox.Name = "myOrdersGroupBox";
            this.myOrdersGroupBox.Size = new System.Drawing.Size(525, 142);
            this.myOrdersGroupBox.TabIndex = 3;
            this.myOrdersGroupBox.TabStop = false;
            this.myOrdersGroupBox.Text = "My opened limit orders";
            // 
            // ordersContextMenuStrip
            // 
            this.ordersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeOrderToolStripMenuItem});
            this.ordersContextMenuStrip.Name = "ordersContextMenuStrip";
            this.ordersContextMenuStrip.Size = new System.Drawing.Size(118, 26);
            // 
            // removeOrderToolStripMenuItem
            // 
            this.removeOrderToolStripMenuItem.Name = "removeOrderToolStripMenuItem";
            this.removeOrderToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeOrderToolStripMenuItem.Text = "Remove";
            this.removeOrderToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // openedOrdersListView
            // 
            this.openedOrdersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.marketColumnHeader,
            this.pairColumnHeader,
            this.orderTypeColumnHeader,
            this.priceColumnHeader,
            this.quantityColumnHeader,
            this.openedDateColumnHeader});
            this.openedOrdersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openedOrdersListView.FullRowSelect = true;
            this.openedOrdersListView.GridLines = true;
            this.openedOrdersListView.Location = new System.Drawing.Point(3, 16);
            this.openedOrdersListView.MultiSelect = false;
            this.openedOrdersListView.Name = "openedOrdersListView";
            this.openedOrdersListView.Size = new System.Drawing.Size(519, 123);
            this.openedOrdersListView.TabIndex = 8;
            this.openedOrdersListView.UseCompatibleStateImageBehavior = false;
            this.openedOrdersListView.View = System.Windows.Forms.View.Details;
            // 
            // marketColumnHeader
            // 
            this.marketColumnHeader.Text = "Market";
            this.marketColumnHeader.Width = 80;
            // 
            // pairColumnHeader
            // 
            this.pairColumnHeader.Text = "Pair";
            // 
            // orderTypeColumnHeader
            // 
            this.orderTypeColumnHeader.Text = "Type";
            this.orderTypeColumnHeader.Width = 90;
            // 
            // priceColumnHeader
            // 
            this.priceColumnHeader.Text = "Price";
            this.priceColumnHeader.Width = 70;
            // 
            // quantityColumnHeader
            // 
            this.quantityColumnHeader.Text = "Quantity";
            this.quantityColumnHeader.Width = 75;
            // 
            // openedDateColumnHeader
            // 
            this.openedDateColumnHeader.Text = "Opened Date";
            this.openedDateColumnHeader.Width = 120;
            // 
            // marketLabel
            // 
            this.marketLabel.AutoSize = true;
            this.marketLabel.Location = new System.Drawing.Point(12, 15);
            this.marketLabel.Name = "marketLabel";
            this.marketLabel.Size = new System.Drawing.Size(40, 13);
            this.marketLabel.TabIndex = 3;
            this.marketLabel.Text = "Market";
            // 
            // iWantToGroupBox
            // 
            this.iWantToGroupBox.Controls.Add(this.priceGroupBox);
            this.iWantToGroupBox.Controls.Add(this.quantityGroupBox);
            this.iWantToGroupBox.Controls.Add(this.tradeButton);
            this.iWantToGroupBox.Controls.Add(this.buyLimitRadioButton);
            this.iWantToGroupBox.Controls.Add(this.sellLimitRadioButton);
            this.iWantToGroupBox.Location = new System.Drawing.Point(15, 39);
            this.iWantToGroupBox.Name = "iWantToGroupBox";
            this.iWantToGroupBox.Size = new System.Drawing.Size(522, 125);
            this.iWantToGroupBox.TabIndex = 2;
            this.iWantToGroupBox.TabStop = false;
            this.iWantToGroupBox.Text = "Operation";
            // 
            // priceGroupBox
            // 
            this.priceGroupBox.Controls.Add(this.limitOrderRadioButton);
            this.priceGroupBox.Controls.Add(this.marketPriceRadioButton);
            this.priceGroupBox.Controls.Add(this.priceTextBox);
            this.priceGroupBox.Location = new System.Drawing.Point(72, 16);
            this.priceGroupBox.Name = "priceGroupBox";
            this.priceGroupBox.Size = new System.Drawing.Size(112, 103);
            this.priceGroupBox.TabIndex = 27;
            this.priceGroupBox.TabStop = false;
            this.priceGroupBox.Text = "Price";
            // 
            // limitOrderRadioButton
            // 
            this.limitOrderRadioButton.AutoSize = true;
            this.limitOrderRadioButton.Checked = true;
            this.limitOrderRadioButton.Location = new System.Drawing.Point(9, 23);
            this.limitOrderRadioButton.Name = "limitOrderRadioButton";
            this.limitOrderRadioButton.Size = new System.Drawing.Size(69, 17);
            this.limitOrderRadioButton.TabIndex = 28;
            this.limitOrderRadioButton.TabStop = true;
            this.limitOrderRadioButton.Text = "limit order";
            this.limitOrderRadioButton.UseVisualStyleBackColor = true;
            this.limitOrderRadioButton.CheckedChanged += new System.EventHandler(this.limitOrderRadioButton_CheckedChanged);
            // 
            // marketPriceRadioButton
            // 
            this.marketPriceRadioButton.AutoSize = true;
            this.marketPriceRadioButton.Location = new System.Drawing.Point(9, 68);
            this.marketPriceRadioButton.Name = "marketPriceRadioButton";
            this.marketPriceRadioButton.Size = new System.Drawing.Size(83, 17);
            this.marketPriceRadioButton.TabIndex = 27;
            this.marketPriceRadioButton.Text = "market price";
            this.marketPriceRadioButton.UseVisualStyleBackColor = true;
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(29, 42);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(71, 20);
            this.priceTextBox.TabIndex = 4;
            this.priceTextBox.Text = "0.0000001";
            this.priceTextBox.TextChanged += new System.EventHandler(this.priceTextBox_TextChanged);
            // 
            // quantityGroupBox
            // 
            this.quantityGroupBox.Controls.Add(this.spendingUsdQuantityTextBox);
            this.quantityGroupBox.Controls.Add(this.usdCurrencyLabel);
            this.quantityGroupBox.Controls.Add(this.spendingUsdRadioButton);
            this.quantityGroupBox.Controls.Add(this.spendingQuantityTextBox);
            this.quantityGroupBox.Controls.Add(this.quoteCurrencyLabel);
            this.quantityGroupBox.Controls.Add(this.quantityTextBox);
            this.quantityGroupBox.Controls.Add(this.baseCurrencyLabel);
            this.quantityGroupBox.Controls.Add(this.allAvailableRadioButton);
            this.quantityGroupBox.Controls.Add(this.spendingRadioButton);
            this.quantityGroupBox.Controls.Add(this.exactlyRadioButton);
            this.quantityGroupBox.Location = new System.Drawing.Point(190, 16);
            this.quantityGroupBox.Name = "quantityGroupBox";
            this.quantityGroupBox.Size = new System.Drawing.Size(248, 103);
            this.quantityGroupBox.TabIndex = 25;
            this.quantityGroupBox.TabStop = false;
            this.quantityGroupBox.Text = "Quantity";
            // 
            // spendingUsdQuantityTextBox
            // 
            this.spendingUsdQuantityTextBox.Location = new System.Drawing.Point(129, 59);
            this.spendingUsdQuantityTextBox.Name = "spendingUsdQuantityTextBox";
            this.spendingUsdQuantityTextBox.Size = new System.Drawing.Size(71, 20);
            this.spendingUsdQuantityTextBox.TabIndex = 33;
            this.spendingUsdQuantityTextBox.TextChanged += new System.EventHandler(this.spendingUsdQuantityTextBox_TextChanged);
            // 
            // usdCurrencyLabel
            // 
            this.usdCurrencyLabel.AutoSize = true;
            this.usdCurrencyLabel.Location = new System.Drawing.Point(206, 63);
            this.usdCurrencyLabel.Name = "usdCurrencyLabel";
            this.usdCurrencyLabel.Size = new System.Drawing.Size(30, 13);
            this.usdCurrencyLabel.TabIndex = 31;
            this.usdCurrencyLabel.Text = "USD";
            // 
            // spendingUsdRadioButton
            // 
            this.spendingUsdRadioButton.AutoSize = true;
            this.spendingUsdRadioButton.Location = new System.Drawing.Point(6, 61);
            this.spendingUsdRadioButton.Name = "spendingUsdRadioButton";
            this.spendingUsdRadioButton.Size = new System.Drawing.Size(94, 17);
            this.spendingUsdRadioButton.TabIndex = 32;
            this.spendingUsdRadioButton.Text = "spending USD";
            this.spendingUsdRadioButton.UseVisualStyleBackColor = true;
            this.spendingUsdRadioButton.CheckedChanged += new System.EventHandler(this.spendingUsdRadioButton_CheckedChanged);
            // 
            // spendingQuantityTextBox
            // 
            this.spendingQuantityTextBox.Location = new System.Drawing.Point(129, 38);
            this.spendingQuantityTextBox.Name = "spendingQuantityTextBox";
            this.spendingQuantityTextBox.Size = new System.Drawing.Size(71, 20);
            this.spendingQuantityTextBox.TabIndex = 30;
            this.spendingQuantityTextBox.TextChanged += new System.EventHandler(this.spendingQuantityTextBox_TextChanged);
            // 
            // quoteCurrencyLabel
            // 
            this.quoteCurrencyLabel.AutoSize = true;
            this.quoteCurrencyLabel.Location = new System.Drawing.Point(206, 21);
            this.quoteCurrencyLabel.Name = "quoteCurrencyLabel";
            this.quoteCurrencyLabel.Size = new System.Drawing.Size(28, 13);
            this.quoteCurrencyLabel.TabIndex = 29;
            this.quoteCurrencyLabel.Text = "BTC";
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(129, 17);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(71, 20);
            this.quantityTextBox.TabIndex = 28;
            this.quantityTextBox.TextChanged += new System.EventHandler(this.quantityTextBox_TextChanged);
            // 
            // baseCurrencyLabel
            // 
            this.baseCurrencyLabel.AutoSize = true;
            this.baseCurrencyLabel.Location = new System.Drawing.Point(206, 42);
            this.baseCurrencyLabel.Name = "baseCurrencyLabel";
            this.baseCurrencyLabel.Size = new System.Drawing.Size(29, 13);
            this.baseCurrencyLabel.TabIndex = 8;
            this.baseCurrencyLabel.Text = "ETH";
            // 
            // allAvailableRadioButton
            // 
            this.allAvailableRadioButton.AutoSize = true;
            this.allAvailableRadioButton.Location = new System.Drawing.Point(6, 82);
            this.allAvailableRadioButton.Name = "allAvailableRadioButton";
            this.allAvailableRadioButton.Size = new System.Drawing.Size(80, 17);
            this.allAvailableRadioButton.TabIndex = 27;
            this.allAvailableRadioButton.Text = "all available";
            this.allAvailableRadioButton.UseVisualStyleBackColor = true;
            this.allAvailableRadioButton.CheckedChanged += new System.EventHandler(this.allAvailableRadioButton_CheckedChanged);
            // 
            // spendingRadioButton
            // 
            this.spendingRadioButton.AutoSize = true;
            this.spendingRadioButton.Location = new System.Drawing.Point(6, 40);
            this.spendingRadioButton.Name = "spendingRadioButton";
            this.spendingRadioButton.Size = new System.Drawing.Size(68, 17);
            this.spendingRadioButton.TabIndex = 26;
            this.spendingRadioButton.Text = "spending";
            this.spendingRadioButton.UseVisualStyleBackColor = true;
            this.spendingRadioButton.CheckedChanged += new System.EventHandler(this.spendingRadioButton_CheckedChanged);
            // 
            // exactlyRadioButton
            // 
            this.exactlyRadioButton.AutoSize = true;
            this.exactlyRadioButton.Checked = true;
            this.exactlyRadioButton.Location = new System.Drawing.Point(6, 19);
            this.exactlyRadioButton.Name = "exactlyRadioButton";
            this.exactlyRadioButton.Size = new System.Drawing.Size(58, 17);
            this.exactlyRadioButton.TabIndex = 25;
            this.exactlyRadioButton.TabStop = true;
            this.exactlyRadioButton.Text = "exactly";
            this.exactlyRadioButton.UseVisualStyleBackColor = true;
            this.exactlyRadioButton.CheckedChanged += new System.EventHandler(this.exactlyRadioButton_CheckedChanged);
            // 
            // tradeButton
            // 
            this.tradeButton.Location = new System.Drawing.Point(451, 48);
            this.tradeButton.Name = "tradeButton";
            this.tradeButton.Size = new System.Drawing.Size(57, 44);
            this.tradeButton.TabIndex = 7;
            this.tradeButton.Text = "Place";
            this.tradeButton.UseVisualStyleBackColor = true;
            this.tradeButton.Click += new System.EventHandler(this.tradeButton_Click);
            // 
            // buyLimitRadioButton
            // 
            this.buyLimitRadioButton.AutoSize = true;
            this.buyLimitRadioButton.Checked = true;
            this.buyLimitRadioButton.Location = new System.Drawing.Point(6, 23);
            this.buyLimitRadioButton.Name = "buyLimitRadioButton";
            this.buyLimitRadioButton.Size = new System.Drawing.Size(43, 17);
            this.buyLimitRadioButton.TabIndex = 2;
            this.buyLimitRadioButton.TabStop = true;
            this.buyLimitRadioButton.Text = "Buy";
            this.buyLimitRadioButton.UseVisualStyleBackColor = true;
            this.buyLimitRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // sellLimitRadioButton
            // 
            this.sellLimitRadioButton.AutoSize = true;
            this.sellLimitRadioButton.Location = new System.Drawing.Point(6, 46);
            this.sellLimitRadioButton.Name = "sellLimitRadioButton";
            this.sellLimitRadioButton.Size = new System.Drawing.Size(42, 17);
            this.sellLimitRadioButton.TabIndex = 3;
            this.sellLimitRadioButton.Text = "Sell";
            this.sellLimitRadioButton.UseVisualStyleBackColor = true;
            // 
            // marketComboBox
            // 
            this.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marketComboBox.FormattingEnabled = true;
            this.marketComboBox.Location = new System.Drawing.Point(58, 12);
            this.marketComboBox.Name = "marketComboBox";
            this.marketComboBox.Size = new System.Drawing.Size(81, 21);
            this.marketComboBox.TabIndex = 0;
            this.marketComboBox.SelectionChangeCommitted += new System.EventHandler(this.marketComboBox_SelectionChangeCommitted);
            // 
            // pairLabel
            // 
            this.pairLabel.AutoSize = true;
            this.pairLabel.Location = new System.Drawing.Point(153, 15);
            this.pairLabel.Name = "pairLabel";
            this.pairLabel.Size = new System.Drawing.Size(25, 13);
            this.pairLabel.TabIndex = 1;
            this.pairLabel.Text = "Pair";
            // 
            // pairComboBox
            // 
            this.pairComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.pairComboBox.FormattingEnabled = true;
            this.pairComboBox.Location = new System.Drawing.Point(196, 12);
            this.pairComboBox.Name = "pairComboBox";
            this.pairComboBox.Size = new System.Drawing.Size(91, 21);
            this.pairComboBox.TabIndex = 1;
            this.pairComboBox.SelectionChangeCommitted += new System.EventHandler(this.pairComboBox_SelectionChangeCommitted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoMessageStatusLabel,
            this.availableLabel,
            this.availableQuantityLabel,
            this.priceStatusLabel,
            this.priceValueLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 315);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(553, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // infoMessageStatusLabel
            // 
            this.infoMessageStatusLabel.Name = "infoMessageStatusLabel";
            this.infoMessageStatusLabel.Size = new System.Drawing.Size(0, 17);
            this.infoMessageStatusLabel.Click += new System.EventHandler(this.infoMessageStatusLabel_Click);
            // 
            // availableLabel
            // 
            this.availableLabel.Name = "availableLabel";
            this.availableLabel.Size = new System.Drawing.Size(58, 17);
            this.availableLabel.Text = "Available:";
            // 
            // availableQuantityLabel
            // 
            this.availableQuantityLabel.Name = "availableQuantityLabel";
            this.availableQuantityLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // priceStatusLabel
            // 
            this.priceStatusLabel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.priceStatusLabel.Name = "priceStatusLabel";
            this.priceStatusLabel.Size = new System.Drawing.Size(36, 17);
            this.priceStatusLabel.Text = "Price:";
            // 
            // priceValueLabel
            // 
            this.priceValueLabel.Name = "priceValueLabel";
            this.priceValueLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // PendingTradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 337);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.topPanel);
            this.Name = "PendingTradeForm";
            this.Text = "Pending Trade";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TradeForm_FormClosed);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.myOrdersGroupBox.ResumeLayout(false);
            this.ordersContextMenuStrip.ResumeLayout(false);
            this.iWantToGroupBox.ResumeLayout(false);
            this.iWantToGroupBox.PerformLayout();
            this.priceGroupBox.ResumeLayout(false);
            this.priceGroupBox.PerformLayout();
            this.quantityGroupBox.ResumeLayout(false);
            this.quantityGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.Label marketLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label pairLabel;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox iWantToGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton sellLimitRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton buyLimitRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.Button tradeButton;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox myOrdersGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripStatusLabel availableLabel;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripStatusLabel priceStatusLabel;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader marketColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader pairColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader orderTypeColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader priceColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader quantityColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader openedDateColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem removeOrderToolStripMenuItem;

        [LocalizableClass]
        private System.Windows.Forms.RadioButton limitOrderRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton marketPriceRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton allAvailableRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton exactlyRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox priceGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox quantityGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton spendingUsdRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton spendingRadioButton;

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.ComboBox pairComboBox;
        private System.Windows.Forms.Label baseCurrencyLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.ContextMenuStrip ordersContextMenuStrip;
        private System.Windows.Forms.ListView openedOrdersListView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel availableQuantityLabel;
        private System.Windows.Forms.ToolStripStatusLabel priceValueLabel;
        private System.Windows.Forms.ToolStripStatusLabel infoMessageStatusLabel;
        private System.Windows.Forms.TextBox spendingQuantityTextBox;
        private System.Windows.Forms.Label quoteCurrencyLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.TextBox spendingUsdQuantityTextBox;
        private System.Windows.Forms.Label usdCurrencyLabel;
    }
}
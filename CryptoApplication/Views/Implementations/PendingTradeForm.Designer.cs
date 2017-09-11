using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "PendingTradeForm")]
    partial class PendingTradeForm
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
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openedOrdersListView = new System.Windows.Forms.ListView();
            this.marketColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orderTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.marketLabel = new System.Windows.Forms.Label();
            this.iWantToGroupBox = new System.Windows.Forms.GroupBox();
            this.allAvailableCheckBox = new System.Windows.Forms.CheckBox();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.quoteCurrencyLabel = new System.Windows.Forms.Label();
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.tradeButton = new System.Windows.Forms.Button();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.baseCurrencyLabel = new System.Windows.Forms.Label();
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
            this.topPanel.Size = new System.Drawing.Size(426, 337);
            this.topPanel.TabIndex = 2;
            // 
            // myOrdersGroupBox
            // 
            this.myOrdersGroupBox.ContextMenuStrip = this.ordersContextMenuStrip;
            this.myOrdersGroupBox.Controls.Add(this.openedOrdersListView);
            this.myOrdersGroupBox.Location = new System.Drawing.Point(15, 138);
            this.myOrdersGroupBox.Name = "myOrdersGroupBox";
            this.myOrdersGroupBox.Size = new System.Drawing.Size(399, 174);
            this.myOrdersGroupBox.TabIndex = 4;
            this.myOrdersGroupBox.TabStop = false;
            this.myOrdersGroupBox.Text = "My Orders";
            // 
            // ordersContextMenuStrip
            // 
            this.ordersContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeToolStripMenuItem});
            this.ordersContextMenuStrip.Name = "ordersContextMenuStrip";
            this.ordersContextMenuStrip.Size = new System.Drawing.Size(118, 26);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // openedOrdersListView
            // 
            this.openedOrdersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.marketColumnHeader,
            this.pairColumnHeader,
            this.orderTypeColumnHeader,
            this.priceColumnHeader,
            this.quantityColumnHeader});
            this.openedOrdersListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openedOrdersListView.FullRowSelect = true;
            this.openedOrdersListView.GridLines = true;
            this.openedOrdersListView.Location = new System.Drawing.Point(3, 16);
            this.openedOrdersListView.MultiSelect = false;
            this.openedOrdersListView.Name = "openedOrdersListView";
            this.openedOrdersListView.Size = new System.Drawing.Size(393, 155);
            this.openedOrdersListView.TabIndex = 7;
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
            this.iWantToGroupBox.Controls.Add(this.allAvailableCheckBox);
            this.iWantToGroupBox.Controls.Add(this.quantityLabel);
            this.iWantToGroupBox.Controls.Add(this.priceLabel);
            this.iWantToGroupBox.Controls.Add(this.quoteCurrencyLabel);
            this.iWantToGroupBox.Controls.Add(this.priceTextBox);
            this.iWantToGroupBox.Controls.Add(this.tradeButton);
            this.iWantToGroupBox.Controls.Add(this.quantityTextBox);
            this.iWantToGroupBox.Controls.Add(this.baseCurrencyLabel);
            this.iWantToGroupBox.Controls.Add(this.buyLimitRadioButton);
            this.iWantToGroupBox.Controls.Add(this.sellLimitRadioButton);
            this.iWantToGroupBox.Location = new System.Drawing.Point(15, 39);
            this.iWantToGroupBox.Name = "iWantToGroupBox";
            this.iWantToGroupBox.Size = new System.Drawing.Size(358, 93);
            this.iWantToGroupBox.TabIndex = 3;
            this.iWantToGroupBox.TabStop = false;
            this.iWantToGroupBox.Text = "I want to";
            // 
            // allAvailableCheckBox
            // 
            this.allAvailableCheckBox.AutoSize = true;
            this.allAvailableCheckBox.Location = new System.Drawing.Point(162, 70);
            this.allAvailableCheckBox.Name = "allAvailableCheckBox";
            this.allAvailableCheckBox.Size = new System.Drawing.Size(81, 17);
            this.allAvailableCheckBox.TabIndex = 20;
            this.allAvailableCheckBox.Text = "all available";
            this.allAvailableCheckBox.UseVisualStyleBackColor = true;
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Location = new System.Drawing.Point(94, 48);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(46, 13);
            this.quantityLabel.TabIndex = 19;
            this.quantityLabel.Text = "Quantity";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(94, 25);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(31, 13);
            this.priceLabel.TabIndex = 18;
            this.priceLabel.Text = "Price";
            // 
            // quoteCurrencyLabel
            // 
            this.quoteCurrencyLabel.AutoSize = true;
            this.quoteCurrencyLabel.Location = new System.Drawing.Point(236, 48);
            this.quoteCurrencyLabel.Name = "quoteCurrencyLabel";
            this.quoteCurrencyLabel.Size = new System.Drawing.Size(28, 13);
            this.quoteCurrencyLabel.TabIndex = 17;
            this.quoteCurrencyLabel.Text = "BTC";
            // 
            // priceTextBox
            // 
            this.priceTextBox.Location = new System.Drawing.Point(162, 22);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(71, 20);
            this.priceTextBox.TabIndex = 16;
            this.priceTextBox.TextChanged += new System.EventHandler(this.priceTextBox_TextChanged);
            // 
            // tradeButton
            // 
            this.tradeButton.Location = new System.Drawing.Point(284, 38);
            this.tradeButton.Name = "tradeButton";
            this.tradeButton.Size = new System.Drawing.Size(57, 23);
            this.tradeButton.TabIndex = 6;
            this.tradeButton.Text = "Place";
            this.tradeButton.UseVisualStyleBackColor = true;
            this.tradeButton.Click += new System.EventHandler(this.tradeButton_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(162, 45);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(71, 20);
            this.quantityTextBox.TabIndex = 7;
            this.quantityTextBox.TextChanged += new System.EventHandler(this.quantityTextBox_TextChanged);
            // 
            // baseCurrencyLabel
            // 
            this.baseCurrencyLabel.AutoSize = true;
            this.baseCurrencyLabel.Location = new System.Drawing.Point(236, 25);
            this.baseCurrencyLabel.Name = "baseCurrencyLabel";
            this.baseCurrencyLabel.Size = new System.Drawing.Size(29, 13);
            this.baseCurrencyLabel.TabIndex = 8;
            this.baseCurrencyLabel.Text = "ETH";
            // 
            // buyLimitRadioButton
            // 
            this.buyLimitRadioButton.AutoSize = true;
            this.buyLimitRadioButton.Checked = true;
            this.buyLimitRadioButton.Location = new System.Drawing.Point(21, 23);
            this.buyLimitRadioButton.Name = "buyLimitRadioButton";
            this.buyLimitRadioButton.Size = new System.Drawing.Size(67, 17);
            this.buyLimitRadioButton.TabIndex = 10;
            this.buyLimitRadioButton.TabStop = true;
            this.buyLimitRadioButton.Text = "Buy Limit";
            this.buyLimitRadioButton.UseVisualStyleBackColor = true;
            this.buyLimitRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // sellLimitRadioButton
            // 
            this.sellLimitRadioButton.AutoSize = true;
            this.sellLimitRadioButton.Location = new System.Drawing.Point(21, 46);
            this.sellLimitRadioButton.Name = "sellLimitRadioButton";
            this.sellLimitRadioButton.Size = new System.Drawing.Size(66, 17);
            this.sellLimitRadioButton.TabIndex = 11;
            this.sellLimitRadioButton.TabStop = true;
            this.sellLimitRadioButton.Text = "Sell Limit";
            this.sellLimitRadioButton.UseVisualStyleBackColor = true;
            this.sellLimitRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // marketComboBox
            // 
            this.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marketComboBox.FormattingEnabled = true;
            this.marketComboBox.Location = new System.Drawing.Point(58, 12);
            this.marketComboBox.Name = "marketComboBox";
            this.marketComboBox.Size = new System.Drawing.Size(81, 21);
            this.marketComboBox.TabIndex = 0;
            this.marketComboBox.SelectedIndexChanged += new System.EventHandler(this.marketComboBox_SelectedIndexChanged);
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
            this.pairComboBox.SelectedIndexChanged += new System.EventHandler(this.pairComboBox_SelectedIndexChanged);
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
            this.statusStrip.Size = new System.Drawing.Size(426, 22);
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
            this.availableQuantityLabel.Size = new System.Drawing.Size(105, 17);
            this.availableQuantityLabel.Text = "0.00123456789 BTC";
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
            this.priceValueLabel.Size = new System.Drawing.Size(77, 17);
            this.priceValueLabel.Text = "1.123456 ETH";
            // 
            // PendingTradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 337);
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
        private System.Windows.Forms.Label quantityLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label priceLabel;
        [LocalizableClass]
        private System.Windows.Forms.CheckBox allAvailableCheckBox;
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

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.ComboBox pairComboBox;
        private System.Windows.Forms.Label baseCurrencyLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label quoteCurrencyLabel;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.ContextMenuStrip ordersContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ListView openedOrdersListView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel availableQuantityLabel;
        private System.Windows.Forms.ToolStripStatusLabel priceValueLabel;
        private System.Windows.Forms.ToolStripStatusLabel infoMessageStatusLabel;
    }
}
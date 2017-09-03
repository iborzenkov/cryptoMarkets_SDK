using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "MarketTradeForm")]
    partial class MarketTradeForm
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
            this.topPanel = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.availableLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.AvailableQuantityLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.priceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.priceValueLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.iWantToSpendForGroupBox = new System.Windows.Forms.GroupBox();
            this.allAvailableCheckBox = new System.Windows.Forms.CheckBox();
            this.quoteCurrencyLabel2 = new System.Windows.Forms.Label();
            this.quantityTextBox2 = new System.Windows.Forms.TextBox();
            this.sellRadioButton2 = new System.Windows.Forms.RadioButton();
            this.tradeButton2 = new System.Windows.Forms.Button();
            this.buyRadioButton2 = new System.Windows.Forms.RadioButton();
            this.baseCurrencyLabel2 = new System.Windows.Forms.Label();
            this.marketLabel = new System.Windows.Forms.Label();
            this.iWantToGroupBox = new System.Windows.Forms.GroupBox();
            this.tradeButton = new System.Windows.Forms.Button();
            this.quantityTextBox = new System.Windows.Forms.TextBox();
            this.baseCurrencyLabel = new System.Windows.Forms.Label();
            this.buyRadioButton = new System.Windows.Forms.RadioButton();
            this.sellRadioButton = new System.Windows.Forms.RadioButton();
            this.marketComboBox = new System.Windows.Forms.ComboBox();
            this.pairLabel = new System.Windows.Forms.Label();
            this.pairComboBox = new System.Windows.Forms.ComboBox();
            this.topPanel.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.iWantToSpendForGroupBox.SuspendLayout();
            this.iWantToGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.statusStrip);
            this.topPanel.Controls.Add(this.iWantToSpendForGroupBox);
            this.topPanel.Controls.Add(this.marketLabel);
            this.topPanel.Controls.Add(this.iWantToGroupBox);
            this.topPanel.Controls.Add(this.marketComboBox);
            this.topPanel.Controls.Add(this.pairLabel);
            this.topPanel.Controls.Add(this.pairComboBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(362, 233);
            this.topPanel.TabIndex = 2;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.availableLabel,
            this.AvailableQuantityLabel,
            this.priceLabel,
            this.priceValueLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 211);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(362, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // availableLabel
            // 
            this.availableLabel.Name = "availableLabel";
            this.availableLabel.Size = new System.Drawing.Size(58, 17);
            this.availableLabel.Text = "Available:";
            // 
            // AvailableQuantityLabel
            // 
            this.AvailableQuantityLabel.Name = "AvailableQuantityLabel";
            this.AvailableQuantityLabel.Size = new System.Drawing.Size(105, 17);
            this.AvailableQuantityLabel.Text = "0.00123456789 BTC";
            // 
            // priceLabel
            // 
            this.priceLabel.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(36, 17);
            this.priceLabel.Text = "Price:";
            // 
            // priceValueLabel
            // 
            this.priceValueLabel.Name = "priceValueLabel";
            this.priceValueLabel.Size = new System.Drawing.Size(77, 17);
            this.priceValueLabel.Text = "1.123456 ETH";
            // 
            // iWantToSpendForGroupBox
            // 
            this.iWantToSpendForGroupBox.Controls.Add(this.allAvailableCheckBox);
            this.iWantToSpendForGroupBox.Controls.Add(this.quoteCurrencyLabel2);
            this.iWantToSpendForGroupBox.Controls.Add(this.quantityTextBox2);
            this.iWantToSpendForGroupBox.Controls.Add(this.sellRadioButton2);
            this.iWantToSpendForGroupBox.Controls.Add(this.tradeButton2);
            this.iWantToSpendForGroupBox.Controls.Add(this.buyRadioButton2);
            this.iWantToSpendForGroupBox.Controls.Add(this.baseCurrencyLabel2);
            this.iWantToSpendForGroupBox.Location = new System.Drawing.Point(16, 124);
            this.iWantToSpendForGroupBox.Name = "iWantToSpendForGroupBox";
            this.iWantToSpendForGroupBox.Size = new System.Drawing.Size(334, 80);
            this.iWantToSpendForGroupBox.TabIndex = 4;
            this.iWantToSpendForGroupBox.TabStop = false;
            this.iWantToSpendForGroupBox.Text = "I want to spend for...";
            // 
            // allAvailableCheckBox
            // 
            this.allAvailableCheckBox.AutoSize = true;
            this.allAvailableCheckBox.Location = new System.Drawing.Point(123, 57);
            this.allAvailableCheckBox.Name = "allAvailableCheckBox";
            this.allAvailableCheckBox.Size = new System.Drawing.Size(81, 17);
            this.allAvailableCheckBox.TabIndex = 19;
            this.allAvailableCheckBox.Text = "all available";
            this.allAvailableCheckBox.UseVisualStyleBackColor = true;
            // 
            // quoteCurrencyLabel2
            // 
            this.quoteCurrencyLabel2.AutoSize = true;
            this.quoteCurrencyLabel2.Location = new System.Drawing.Point(217, 40);
            this.quoteCurrencyLabel2.Name = "quoteCurrencyLabel2";
            this.quoteCurrencyLabel2.Size = new System.Drawing.Size(29, 13);
            this.quoteCurrencyLabel2.TabIndex = 18;
            this.quoteCurrencyLabel2.Text = "ETH";
            // 
            // quantityTextBox2
            // 
            this.quantityTextBox2.Location = new System.Drawing.Point(123, 37);
            this.quantityTextBox2.Name = "quantityTextBox2";
            this.quantityTextBox2.Size = new System.Drawing.Size(81, 20);
            this.quantityTextBox2.TabIndex = 13;
            this.quantityTextBox2.TextChanged += new System.EventHandler(this.quantityTextBox2_TextChanged);
            // 
            // sellRadioButton2
            // 
            this.sellRadioButton2.AutoSize = true;
            this.sellRadioButton2.Location = new System.Drawing.Point(21, 50);
            this.sellRadioButton2.Name = "sellRadioButton2";
            this.sellRadioButton2.Size = new System.Drawing.Size(54, 17);
            this.sellRadioButton2.TabIndex = 17;
            this.sellRadioButton2.TabStop = true;
            this.sellRadioButton2.Text = "selling";
            this.sellRadioButton2.UseVisualStyleBackColor = true;
            this.sellRadioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // tradeButton2
            // 
            this.tradeButton2.Location = new System.Drawing.Point(265, 37);
            this.tradeButton2.Name = "tradeButton2";
            this.tradeButton2.Size = new System.Drawing.Size(57, 23);
            this.tradeButton2.TabIndex = 12;
            this.tradeButton2.Text = "Trade";
            this.tradeButton2.UseVisualStyleBackColor = true;
            this.tradeButton2.Click += new System.EventHandler(this.tradeButton2_Click);
            // 
            // buyRadioButton2
            // 
            this.buyRadioButton2.AutoSize = true;
            this.buyRadioButton2.Checked = true;
            this.buyRadioButton2.Location = new System.Drawing.Point(21, 27);
            this.buyRadioButton2.Name = "buyRadioButton2";
            this.buyRadioButton2.Size = new System.Drawing.Size(56, 17);
            this.buyRadioButton2.TabIndex = 16;
            this.buyRadioButton2.TabStop = true;
            this.buyRadioButton2.Text = "buying";
            this.buyRadioButton2.UseVisualStyleBackColor = true;
            this.buyRadioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // baseCurrencyLabel2
            // 
            this.baseCurrencyLabel2.AutoSize = true;
            this.baseCurrencyLabel2.Location = new System.Drawing.Point(89, 40);
            this.baseCurrencyLabel2.Name = "baseCurrencyLabel2";
            this.baseCurrencyLabel2.Size = new System.Drawing.Size(28, 13);
            this.baseCurrencyLabel2.TabIndex = 14;
            this.baseCurrencyLabel2.Text = "BTC";
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
            this.iWantToGroupBox.Controls.Add(this.tradeButton);
            this.iWantToGroupBox.Controls.Add(this.quantityTextBox);
            this.iWantToGroupBox.Controls.Add(this.baseCurrencyLabel);
            this.iWantToGroupBox.Controls.Add(this.buyRadioButton);
            this.iWantToGroupBox.Controls.Add(this.sellRadioButton);
            this.iWantToGroupBox.Location = new System.Drawing.Point(15, 39);
            this.iWantToGroupBox.Name = "iWantToGroupBox";
            this.iWantToGroupBox.Size = new System.Drawing.Size(334, 79);
            this.iWantToGroupBox.TabIndex = 3;
            this.iWantToGroupBox.TabStop = false;
            this.iWantToGroupBox.Text = "I want to";
            // 
            // tradeButton
            // 
            this.tradeButton.Location = new System.Drawing.Point(265, 28);
            this.tradeButton.Name = "tradeButton";
            this.tradeButton.Size = new System.Drawing.Size(57, 23);
            this.tradeButton.TabIndex = 6;
            this.tradeButton.Text = "Trade";
            this.tradeButton.UseVisualStyleBackColor = true;
            this.tradeButton.Click += new System.EventHandler(this.tradeButton_Click);
            // 
            // quantityTextBox
            // 
            this.quantityTextBox.Location = new System.Drawing.Point(92, 30);
            this.quantityTextBox.Name = "quantityTextBox";
            this.quantityTextBox.Size = new System.Drawing.Size(112, 20);
            this.quantityTextBox.TabIndex = 7;
            this.quantityTextBox.TextChanged += new System.EventHandler(this.quantityTextBox_TextChanged);
            // 
            // baseCurrencyLabel
            // 
            this.baseCurrencyLabel.AutoSize = true;
            this.baseCurrencyLabel.Location = new System.Drawing.Point(216, 33);
            this.baseCurrencyLabel.Name = "baseCurrencyLabel";
            this.baseCurrencyLabel.Size = new System.Drawing.Size(29, 13);
            this.baseCurrencyLabel.TabIndex = 8;
            this.baseCurrencyLabel.Text = "ETH";
            // 
            // buyRadioButton
            // 
            this.buyRadioButton.AutoSize = true;
            this.buyRadioButton.Checked = true;
            this.buyRadioButton.Location = new System.Drawing.Point(21, 23);
            this.buyRadioButton.Name = "buyRadioButton";
            this.buyRadioButton.Size = new System.Drawing.Size(42, 17);
            this.buyRadioButton.TabIndex = 10;
            this.buyRadioButton.TabStop = true;
            this.buyRadioButton.Text = "buy";
            this.buyRadioButton.UseVisualStyleBackColor = true;
            this.buyRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // sellRadioButton
            // 
            this.sellRadioButton.AutoSize = true;
            this.sellRadioButton.Location = new System.Drawing.Point(21, 46);
            this.sellRadioButton.Name = "sellRadioButton";
            this.sellRadioButton.Size = new System.Drawing.Size(40, 17);
            this.sellRadioButton.TabIndex = 11;
            this.sellRadioButton.TabStop = true;
            this.sellRadioButton.Text = "sell";
            this.sellRadioButton.UseVisualStyleBackColor = true;
            this.sellRadioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
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
            // MarketTradeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 233);
            this.Controls.Add(this.topPanel);
            this.Name = "MarketTradeForm";
            this.Text = "Trade";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TradeForm_FormClosed);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.iWantToSpendForGroupBox.ResumeLayout(false);
            this.iWantToSpendForGroupBox.PerformLayout();
            this.iWantToGroupBox.ResumeLayout(false);
            this.iWantToGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.Label marketLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label pairLabel;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox iWantToGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton sellRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton buyRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.Button tradeButton;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox iWantToSpendForGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton sellRadioButton2;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton buyRadioButton2;
        [LocalizableClass]
        private System.Windows.Forms.CheckBox allAvailableCheckBox;
        [LocalizableClass]
        private System.Windows.Forms.Button tradeButton2;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripStatusLabel availableLabel;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripStatusLabel priceLabel;

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.ComboBox pairComboBox;
        private System.Windows.Forms.Label baseCurrencyLabel;
        private System.Windows.Forms.TextBox quantityTextBox;
        private System.Windows.Forms.Label quoteCurrencyLabel2;
        private System.Windows.Forms.Label baseCurrencyLabel2;
        private System.Windows.Forms.TextBox quantityTextBox2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel AvailableQuantityLabel;
        private System.Windows.Forms.ToolStripStatusLabel priceValueLabel;
    }
}
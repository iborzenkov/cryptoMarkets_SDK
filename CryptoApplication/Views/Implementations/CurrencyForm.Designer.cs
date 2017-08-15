using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "CurrencyForm")]
    partial class CurrencyForm
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
            this.marketListBox = new System.Windows.Forms.ListBox();
            this.marketsGroupBox = new System.Windows.Forms.GroupBox();
            this.currencyPanel = new System.Windows.Forms.Panel();
            this.currencyListView = new System.Windows.Forms.ListView();
            this.currencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shortNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.activeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.taxFeeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.baseAddressColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.minConfirmationColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.clearFilterButton = new System.Windows.Forms.Button();
            this.activeOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.marketsGroupBox.SuspendLayout();
            this.currencyPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // marketListBox
            // 
            this.marketListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketListBox.FormattingEnabled = true;
            this.marketListBox.Location = new System.Drawing.Point(3, 16);
            this.marketListBox.Name = "marketListBox";
            this.marketListBox.Size = new System.Drawing.Size(194, 261);
            this.marketListBox.TabIndex = 0;
            this.marketListBox.SelectedIndexChanged += new System.EventHandler(this.marketListBox_SelectedIndexChanged);
            // 
            // marketsGroupBox
            // 
            this.marketsGroupBox.Controls.Add(this.marketListBox);
            this.marketsGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.marketsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.marketsGroupBox.Name = "marketsGroupBox";
            this.marketsGroupBox.Size = new System.Drawing.Size(200, 280);
            this.marketsGroupBox.TabIndex = 1;
            this.marketsGroupBox.TabStop = false;
            this.marketsGroupBox.Text = "Markets";
            // 
            // currencyPanel
            // 
            this.currencyPanel.Controls.Add(this.currencyListView);
            this.currencyPanel.Controls.Add(this.panel1);
            this.currencyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currencyPanel.Location = new System.Drawing.Point(200, 0);
            this.currencyPanel.Name = "currencyPanel";
            this.currencyPanel.Size = new System.Drawing.Size(486, 280);
            this.currencyPanel.TabIndex = 3;
            // 
            // currencyListView
            // 
            this.currencyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.currencyColumnHeader,
            this.shortNameColumnHeader,
            this.activeColumnHeader,
            this.taxFeeColumnHeader,
            this.baseAddressColumnHeader,
            this.minConfirmationColumnHeader});
            this.currencyListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.currencyListView.FullRowSelect = true;
            this.currencyListView.GridLines = true;
            this.currencyListView.Location = new System.Drawing.Point(0, 45);
            this.currencyListView.MultiSelect = false;
            this.currencyListView.Name = "currencyListView";
            this.currencyListView.Size = new System.Drawing.Size(486, 235);
            this.currencyListView.TabIndex = 1;
            this.currencyListView.UseCompatibleStateImageBehavior = false;
            this.currencyListView.View = System.Windows.Forms.View.Details;
            // 
            // currencyColumnHeader
            // 
            this.currencyColumnHeader.Text = "Currency";
            this.currencyColumnHeader.Width = 80;
            // 
            // shortNameColumnHeader
            // 
            this.shortNameColumnHeader.Text = "Short Name";
            this.shortNameColumnHeader.Width = 80;
            // 
            // activeColumnHeader
            // 
            this.activeColumnHeader.Text = "Active?";
            // 
            // taxFeeColumnHeader
            // 
            this.taxFeeColumnHeader.Text = "Tax Fee";
            this.taxFeeColumnHeader.Width = 63;
            // 
            // baseAddressColumnHeader
            // 
            this.baseAddressColumnHeader.Text = "Base Address";
            this.baseAddressColumnHeader.Width = 120;
            // 
            // minConfirmationColumnHeader
            // 
            this.minConfirmationColumnHeader.Text = "Min Confirmation Count";
            this.minConfirmationColumnHeader.Width = 66;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.clearFilterButton);
            this.panel1.Controls.Add(this.activeOnlyCheckBox);
            this.panel1.Controls.Add(this.filterTextBox);
            this.panel1.Controls.Add(this.filterLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(486, 45);
            this.panel1.TabIndex = 4;
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.Image = global::Views.Properties.Resources.Delete;
            this.clearFilterButton.Location = new System.Drawing.Point(175, 11);
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(29, 22);
            this.clearFilterButton.TabIndex = 4;
            this.clearFilterButton.UseVisualStyleBackColor = true;
            this.clearFilterButton.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // activeOnlyCheckBox
            // 
            this.activeOnlyCheckBox.AutoSize = true;
            this.activeOnlyCheckBox.Location = new System.Drawing.Point(228, 14);
            this.activeOnlyCheckBox.Name = "activeOnlyCheckBox";
            this.activeOnlyCheckBox.Size = new System.Drawing.Size(80, 17);
            this.activeOnlyCheckBox.TabIndex = 3;
            this.activeOnlyCheckBox.Text = "Active Only";
            this.activeOnlyCheckBox.UseVisualStyleBackColor = true;
            this.activeOnlyCheckBox.CheckedChanged += new System.EventHandler(this.activeOnlyCheckBox_CheckedChanged);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(63, 12);
            this.filterTextBox.Name = "filterTextBox";
            this.filterTextBox.Size = new System.Drawing.Size(112, 20);
            this.filterTextBox.TabIndex = 2;
            this.filterTextBox.TextChanged += new System.EventHandler(this.filterTextBox_TextChanged);
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(13, 15);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(29, 13);
            this.filterLabel.TabIndex = 2;
            this.filterLabel.Text = "Filter";
            // 
            // CurrencyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 280);
            this.Controls.Add(this.currencyPanel);
            this.Controls.Add(this.marketsGroupBox);
            this.Name = "CurrencyForm";
            this.Text = "Currencies";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CurrencyForm_FormClosed);
            this.marketsGroupBox.ResumeLayout(false);
            this.currencyPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox marketListBox;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox marketsGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.Label filterLabel;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader currencyColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader taxFeeColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader baseAddressColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader minConfirmationColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader activeColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader shortNameColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.CheckBox activeOnlyCheckBox;

        private System.Windows.Forms.ListView currencyListView;
        private System.Windows.Forms.Panel currencyPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button clearFilterButton;
    }
}
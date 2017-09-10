using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "BalanceForm")]
    partial class BalanceForm
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
            this.marketsGroupBox = new System.Windows.Forms.GroupBox();
            this.marketListBox = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.refreshButton = new System.Windows.Forms.Button();
            this.clearFilterButton = new System.Windows.Forms.Button();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.balanceListView = new System.Windows.Forms.ListView();
            this.currencyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shortNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.availableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pendingColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sumUsdEquivalentcolumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.totalUsdEquivalentLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.reservedColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.marketsGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // marketsGroupBox
            // 
            this.marketsGroupBox.Controls.Add(this.marketListBox);
            this.marketsGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.marketsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.marketsGroupBox.Name = "marketsGroupBox";
            this.marketsGroupBox.Size = new System.Drawing.Size(200, 224);
            this.marketsGroupBox.TabIndex = 2;
            this.marketsGroupBox.TabStop = false;
            this.marketsGroupBox.Text = "Markets";
            // 
            // marketListBox
            // 
            this.marketListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketListBox.FormattingEnabled = true;
            this.marketListBox.Location = new System.Drawing.Point(3, 16);
            this.marketListBox.Name = "marketListBox";
            this.marketListBox.Size = new System.Drawing.Size(194, 205);
            this.marketListBox.TabIndex = 0;
            this.marketListBox.SelectedIndexChanged += new System.EventHandler(this.marketListBox_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.refreshButton);
            this.panel1.Controls.Add(this.clearFilterButton);
            this.panel1.Controls.Add(this.filterTextBox);
            this.panel1.Controls.Add(this.filterLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(455, 45);
            this.panel1.TabIndex = 5;
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(233, 11);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.Image = global::Views.Properties.Resources.Delete;
            this.clearFilterButton.Location = new System.Drawing.Point(177, 11);
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(29, 22);
            this.clearFilterButton.TabIndex = 4;
            this.clearFilterButton.UseVisualStyleBackColor = true;
            this.clearFilterButton.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(65, 12);
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
            // balanceListView
            // 
            this.balanceListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.currencyColumnHeader,
            this.shortNameColumnHeader,
            this.availableColumnHeader,
            this.reservedColumnHeader,
            this.pendingColumnHeader,
            this.sumUsdEquivalentcolumnHeader});
            this.balanceListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balanceListView.FullRowSelect = true;
            this.balanceListView.GridLines = true;
            this.balanceListView.Location = new System.Drawing.Point(200, 45);
            this.balanceListView.MultiSelect = false;
            this.balanceListView.Name = "balanceListView";
            this.balanceListView.Size = new System.Drawing.Size(455, 179);
            this.balanceListView.TabIndex = 6;
            this.balanceListView.UseCompatibleStateImageBehavior = false;
            this.balanceListView.View = System.Windows.Forms.View.Details;
            // 
            // currencyColumnHeader
            // 
            this.currencyColumnHeader.Text = "Currency";
            this.currencyColumnHeader.Width = 90;
            // 
            // shortNameColumnHeader
            // 
            this.shortNameColumnHeader.Text = "Short Name";
            this.shortNameColumnHeader.Width = 70;
            // 
            // availableColumnHeader
            // 
            this.availableColumnHeader.Text = "Available";
            this.availableColumnHeader.Width = 70;
            // 
            // pendingColumnHeader
            // 
            this.pendingColumnHeader.Text = "Pending";
            this.pendingColumnHeader.Width = 80;
            // 
            // sumUsdEquivalentcolumnHeader
            // 
            this.sumUsdEquivalentcolumnHeader.Text = "Usd Equivalent";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalUsdEquivalentLabel});
            this.statusStrip.Location = new System.Drawing.Point(200, 202);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(455, 22);
            this.statusStrip.TabIndex = 7;
            // 
            // totalUsdEquivalentLabel
            // 
            this.totalUsdEquivalentLabel.Name = "totalUsdEquivalentLabel";
            this.totalUsdEquivalentLabel.Size = new System.Drawing.Size(63, 17);
            this.totalUsdEquivalentLabel.Text = "Total: $134";
            // 
            // reservedColumnHeader
            // 
            this.reservedColumnHeader.Text = "Reserved";
            // 
            // BalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 224);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.balanceListView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.marketsGroupBox);
            this.Name = "BalanceForm";
            this.Text = "Balance";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BalanceForm_FormClosed);
            this.marketsGroupBox.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.GroupBox marketsGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.Label filterLabel;
        [LocalizableClass]
        private System.Windows.Forms.Button refreshButton;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader currencyColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader shortNameColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader availableColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader pendingColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader sumUsdEquivalentcolumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader reservedColumnHeader;

        private System.Windows.Forms.ListBox marketListBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button clearFilterButton;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.ListView balanceListView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel totalUsdEquivalentLabel;
    }
}
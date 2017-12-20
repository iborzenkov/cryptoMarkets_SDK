using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "TradingHistoryForm")]
    partial class TradingHistoryForm
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
            this.orderTypeLabel = new System.Windows.Forms.Label();
            this.orderTypeComboBox = new System.Windows.Forms.ComboBox();
            this.periodLabel = new System.Windows.Forms.Label();
            this.periodComboBox = new System.Windows.Forms.ComboBox();
            this.HistoryOrdersGroupBox = new System.Windows.Forms.GroupBox();
            this.historyOrdersListView = new System.Windows.Forms.ListView();
            this.marketColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.orderTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.feeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.marketLabel = new System.Windows.Forms.Label();
            this.marketComboBox = new System.Windows.Forms.ComboBox();
            this.pairLabel = new System.Windows.Forms.Label();
            this.pairComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.totalLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.topPanel.SuspendLayout();
            this.HistoryOrdersGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.orderTypeLabel);
            this.topPanel.Controls.Add(this.orderTypeComboBox);
            this.topPanel.Controls.Add(this.periodLabel);
            this.topPanel.Controls.Add(this.periodComboBox);
            this.topPanel.Controls.Add(this.HistoryOrdersGroupBox);
            this.topPanel.Controls.Add(this.marketLabel);
            this.topPanel.Controls.Add(this.marketComboBox);
            this.topPanel.Controls.Add(this.pairLabel);
            this.topPanel.Controls.Add(this.pairComboBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(597, 350);
            this.topPanel.TabIndex = 2;
            // 
            // orderTypeLabel
            // 
            this.orderTypeLabel.AutoSize = true;
            this.orderTypeLabel.Location = new System.Drawing.Point(481, 15);
            this.orderTypeLabel.Name = "orderTypeLabel";
            this.orderTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.orderTypeLabel.TabIndex = 6;
            this.orderTypeLabel.Text = "Type";
            // 
            // orderTypeComboBox
            // 
            this.orderTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.orderTypeComboBox.FormattingEnabled = true;
            this.orderTypeComboBox.Location = new System.Drawing.Point(518, 12);
            this.orderTypeComboBox.Name = "orderTypeComboBox";
            this.orderTypeComboBox.Size = new System.Drawing.Size(68, 21);
            this.orderTypeComboBox.TabIndex = 7;
            this.orderTypeComboBox.SelectionChangeCommitted += new System.EventHandler(this.orderTypeComboBox_SelectionChangeCommitted);
            // 
            // periodLabel
            // 
            this.periodLabel.AutoSize = true;
            this.periodLabel.Location = new System.Drawing.Point(307, 15);
            this.periodLabel.Name = "periodLabel";
            this.periodLabel.Size = new System.Drawing.Size(37, 13);
            this.periodLabel.TabIndex = 4;
            this.periodLabel.Text = "Period";
            // 
            // periodComboBox
            // 
            this.periodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.periodComboBox.FormattingEnabled = true;
            this.periodComboBox.Location = new System.Drawing.Point(363, 12);
            this.periodComboBox.Name = "periodComboBox";
            this.periodComboBox.Size = new System.Drawing.Size(91, 21);
            this.periodComboBox.TabIndex = 5;
            this.periodComboBox.SelectionChangeCommitted += new System.EventHandler(this.periodComboBox_SelectionChangeCommitted);
            // 
            // HistoryOrdersGroupBox
            // 
            this.HistoryOrdersGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryOrdersGroupBox.Controls.Add(this.historyOrdersListView);
            this.HistoryOrdersGroupBox.Location = new System.Drawing.Point(15, 39);
            this.HistoryOrdersGroupBox.Name = "HistoryOrdersGroupBox";
            this.HistoryOrdersGroupBox.Size = new System.Drawing.Size(569, 286);
            this.HistoryOrdersGroupBox.TabIndex = 3;
            this.HistoryOrdersGroupBox.TabStop = false;
            this.HistoryOrdersGroupBox.Text = "History orders";
            // 
            // historyOrdersListView
            // 
            this.historyOrdersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.historyOrdersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.marketColumnHeader,
            this.pairColumnHeader,
            this.orderTypeColumnHeader,
            this.priceColumnHeader,
            this.quantityColumnHeader,
            this.feeColumnHeader,
            this.timeColumnHeader});
            this.historyOrdersListView.FullRowSelect = true;
            this.historyOrdersListView.GridLines = true;
            this.historyOrdersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.historyOrdersListView.Location = new System.Drawing.Point(3, 16);
            this.historyOrdersListView.MultiSelect = false;
            this.historyOrdersListView.Name = "historyOrdersListView";
            this.historyOrdersListView.Size = new System.Drawing.Size(563, 267);
            this.historyOrdersListView.TabIndex = 8;
            this.historyOrdersListView.UseCompatibleStateImageBehavior = false;
            this.historyOrdersListView.View = System.Windows.Forms.View.Details;
            // 
            // marketColumnHeader
            // 
            this.marketColumnHeader.Text = "Market";
            this.marketColumnHeader.Width = 80;
            // 
            // pairColumnHeader
            // 
            this.pairColumnHeader.Text = "Pair";
            this.pairColumnHeader.Width = 70;
            // 
            // orderTypeColumnHeader
            // 
            this.orderTypeColumnHeader.Text = "Type";
            this.orderTypeColumnHeader.Width = 55;
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
            // feeColumnHeader
            // 
            this.feeColumnHeader.Text = "Fee";
            this.feeColumnHeader.Width = 75;
            // 
            // timeColumnHeader
            // 
            this.timeColumnHeader.Text = "Time";
            this.timeColumnHeader.Width = 120;
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
            this.totalLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 328);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(597, 22);
            this.statusStrip.TabIndex = 6;
            this.statusStrip.Text = "statusStrip1";
            // 
            // totalLabel
            // 
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(36, 17);
            this.totalLabel.Text = "Total:";
            // 
            // TradingHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 350);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.topPanel);
            this.Name = "TradingHistoryForm";
            this.Text = "Pending Trade";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TradingHistoryForm_FormClosed);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.HistoryOrdersGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox HistoryOrdersGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripStatusLabel totalLabel;
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
        private System.Windows.Forms.ColumnHeader timeColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader feeColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.Label periodLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label orderTypeLabel;

        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.ComboBox pairComboBox;
        private System.Windows.Forms.ListView historyOrdersListView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ComboBox periodComboBox;
        private System.Windows.Forms.ComboBox orderTypeComboBox;
    }
}
using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    partial class OrderBookControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.askListView = new System.Windows.Forms.ListView();
            this.askPriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.askQuantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter = new System.Windows.Forms.Splitter();
            this.bidListView = new System.Windows.Forms.ListView();
            this.bidPriceColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bidQuantityColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // askListView
            // 
            this.askListView.BackColor = System.Drawing.Color.Salmon;
            this.askListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.askPriceColumnHeader,
            this.askQuantityColumnHeader});
            this.askListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.askListView.FullRowSelect = true;
            this.askListView.GridLines = true;
            this.askListView.Location = new System.Drawing.Point(0, 0);
            this.askListView.Name = "askListView";
            this.askListView.Size = new System.Drawing.Size(219, 147);
            this.askListView.TabIndex = 3;
            this.askListView.UseCompatibleStateImageBehavior = false;
            this.askListView.View = System.Windows.Forms.View.Details;
            this.askListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.askListView_ColumnWidthChanging);
            // 
            // askPriceColumnHeader
            // 
            this.askPriceColumnHeader.Text = "Ask";
            this.askPriceColumnHeader.Width = 90;
            // 
            // askQuantityColumnHeader
            // 
            this.askQuantityColumnHeader.Text = "Quantity";
            this.askQuantityColumnHeader.Width = 90;
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter.Location = new System.Drawing.Point(0, 147);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(219, 3);
            this.splitter.TabIndex = 5;
            this.splitter.TabStop = false;
            // 
            // bidListView
            // 
            this.bidListView.BackColor = System.Drawing.Color.LimeGreen;
            this.bidListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bidPriceColumnHeader,
            this.bidQuantityColumnHeader});
            this.bidListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bidListView.FullRowSelect = true;
            this.bidListView.GridLines = true;
            this.bidListView.Location = new System.Drawing.Point(0, 150);
            this.bidListView.Name = "bidListView";
            this.bidListView.Size = new System.Drawing.Size(219, 146);
            this.bidListView.TabIndex = 6;
            this.bidListView.UseCompatibleStateImageBehavior = false;
            this.bidListView.View = System.Windows.Forms.View.Details;
            this.bidListView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.bidListView_ColumnWidthChanging);
            // 
            // bidPriceColumnHeader
            // 
            this.bidPriceColumnHeader.Text = "Bid";
            this.bidPriceColumnHeader.Width = 90;
            // 
            // bidQuantityColumnHeader
            // 
            this.bidQuantityColumnHeader.Text = "Quantity";
            this.bidQuantityColumnHeader.Width = 90;
            // 
            // OrderBookControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bidListView);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.askListView);
            this.Name = "OrderBookControl";
            this.Size = new System.Drawing.Size(219, 296);
            this.Resize += new System.EventHandler(this.OrderBookControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader askPriceColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader askQuantityColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader bidPriceColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader bidQuantityColumnHeader;

        private System.Windows.Forms.ListView askListView;
        private System.Windows.Forms.Splitter splitter;
        private System.Windows.Forms.ListView bidListView;
    }
}

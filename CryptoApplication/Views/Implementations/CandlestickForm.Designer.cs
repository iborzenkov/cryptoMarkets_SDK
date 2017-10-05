using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "CandlestickForm")]
    partial class CandlestickForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.topPanel = new System.Windows.Forms.Panel();
            this.barCountComboBox = new System.Windows.Forms.ComboBox();
            this.barCountLabel = new System.Windows.Forms.Label();
            this.timeframeComboBox = new System.Windows.Forms.ComboBox();
            this.timeframeLabel = new System.Windows.Forms.Label();
            this.marketLabel = new System.Windows.Forms.Label();
            this.marketComboBox = new System.Windows.Forms.ComboBox();
            this.pairLabel = new System.Windows.Forms.Label();
            this.pairComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.topPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea7.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea7);
            this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend7.Name = "Legend1";
            this.chart.Legends.Add(legend7);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series7.IsVisibleInLegend = false;
            series7.Legend = "Legend1";
            series7.Name = "priceSeries";
            series7.YValuesPerPoint = 4;
            this.chart.Series.Add(series7);
            this.chart.Size = new System.Drawing.Size(549, 481);
            this.chart.TabIndex = 0;
            this.chart.Text = "chart1";
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.barCountComboBox);
            this.topPanel.Controls.Add(this.barCountLabel);
            this.topPanel.Controls.Add(this.timeframeComboBox);
            this.topPanel.Controls.Add(this.timeframeLabel);
            this.topPanel.Controls.Add(this.marketLabel);
            this.topPanel.Controls.Add(this.marketComboBox);
            this.topPanel.Controls.Add(this.pairLabel);
            this.topPanel.Controls.Add(this.pairComboBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(549, 49);
            this.topPanel.TabIndex = 2;
            // 
            // barCountComboBox
            // 
            this.barCountComboBox.FormattingEnabled = true;
            this.barCountComboBox.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "150",
            "200"});
            this.barCountComboBox.Location = new System.Drawing.Point(493, 12);
            this.barCountComboBox.Name = "barCountComboBox";
            this.barCountComboBox.Size = new System.Drawing.Size(44, 21);
            this.barCountComboBox.TabIndex = 13;
            this.barCountComboBox.SelectionChangeCommitted += new System.EventHandler(this.barCountComboBox_SelectionChangeCommitted);
            this.barCountComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.barCountComboBox_KeyPress);
            this.barCountComboBox.Leave += new System.EventHandler(this.barCountComboBox_Leave);
            // 
            // barCountLabel
            // 
            this.barCountLabel.AutoSize = true;
            this.barCountLabel.Location = new System.Drawing.Point(434, 16);
            this.barCountLabel.Name = "barCountLabel";
            this.barCountLabel.Size = new System.Drawing.Size(53, 13);
            this.barCountLabel.TabIndex = 12;
            this.barCountLabel.Text = "Bar count";
            // 
            // timeframeComboBox
            // 
            this.timeframeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeframeComboBox.FormattingEnabled = true;
            this.timeframeComboBox.Location = new System.Drawing.Point(366, 12);
            this.timeframeComboBox.Name = "timeframeComboBox";
            this.timeframeComboBox.Size = new System.Drawing.Size(48, 21);
            this.timeframeComboBox.TabIndex = 11;
            this.timeframeComboBox.SelectionChangeCommitted += new System.EventHandler(this.periodComboBox_SelectionChangeCommitted);
            // 
            // timeframeLabel
            // 
            this.timeframeLabel.AutoSize = true;
            this.timeframeLabel.Location = new System.Drawing.Point(304, 16);
            this.timeframeLabel.Name = "timeframeLabel";
            this.timeframeLabel.Size = new System.Drawing.Size(56, 13);
            this.timeframeLabel.TabIndex = 10;
            this.timeframeLabel.Text = "Timeframe";
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
            this.pairComboBox.Location = new System.Drawing.Point(194, 12);
            this.pairComboBox.Name = "pairComboBox";
            this.pairComboBox.Size = new System.Drawing.Size(81, 21);
            this.pairComboBox.TabIndex = 1;
            this.pairComboBox.SelectionChangeCommitted += new System.EventHandler(this.pairComboBox_SelectionChangeCommitted);
            // 
            // CandlestickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 481);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.chart);
            this.Name = "CandlestickForm";
            this.Text = "CandlestickForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CandlestickForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.Label timeframeLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label marketLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label pairLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label barCountLabel;

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox timeframeComboBox;
        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.ComboBox pairComboBox;
        private System.Windows.Forms.ComboBox barCountComboBox;
    }
}
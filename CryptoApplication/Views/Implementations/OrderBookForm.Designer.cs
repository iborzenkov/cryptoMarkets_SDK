using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "OrderBookForm")]
    partial class OrderBookForm
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
            this.pairComboBox = new System.Windows.Forms.ComboBox();
            this.topPanel = new System.Windows.Forms.Panel();
            this.largeVolumeKoefTrackBar = new System.Windows.Forms.TrackBar();
            this.largePositionCheckBox = new System.Windows.Forms.CheckBox();
            this.multiplierComboBox = new System.Windows.Forms.ComboBox();
            this.multiplierLabel = new System.Windows.Forms.Label();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.intervalTextBox = new System.Windows.Forms.TextBox();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.depthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.depthLabel = new System.Windows.Forms.Label();
            this.marketLabel = new System.Windows.Forms.Label();
            this.marketComboBox = new System.Windows.Forms.ComboBox();
            this.pairLabel = new System.Windows.Forms.Label();
            this.orderBookPartPanel = new System.Windows.Forms.Panel();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.largeVolumeKoefTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumericUpDown)).BeginInit();
            this.SuspendLayout();
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
            // topPanel
            // 
            this.topPanel.Controls.Add(this.largeVolumeKoefTrackBar);
            this.topPanel.Controls.Add(this.largePositionCheckBox);
            this.topPanel.Controls.Add(this.multiplierComboBox);
            this.topPanel.Controls.Add(this.multiplierLabel);
            this.topPanel.Controls.Add(this.typeComboBox);
            this.topPanel.Controls.Add(this.typeLabel);
            this.topPanel.Controls.Add(this.intervalTextBox);
            this.topPanel.Controls.Add(this.intervalLabel);
            this.topPanel.Controls.Add(this.depthNumericUpDown);
            this.topPanel.Controls.Add(this.depthLabel);
            this.topPanel.Controls.Add(this.marketLabel);
            this.topPanel.Controls.Add(this.marketComboBox);
            this.topPanel.Controls.Add(this.pairLabel);
            this.topPanel.Controls.Add(this.pairComboBox);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(393, 97);
            this.topPanel.TabIndex = 1;
            // 
            // largeVolumeKoefTrackBar
            // 
            this.largeVolumeKoefTrackBar.Location = new System.Drawing.Point(152, 65);
            this.largeVolumeKoefTrackBar.Maximum = 49;
            this.largeVolumeKoefTrackBar.Minimum = 1;
            this.largeVolumeKoefTrackBar.Name = "largeVolumeKoefTrackBar";
            this.largeVolumeKoefTrackBar.Size = new System.Drawing.Size(104, 45);
            this.largeVolumeKoefTrackBar.TabIndex = 16;
            this.largeVolumeKoefTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.largeVolumeKoefTrackBar.Value = 25;
            this.largeVolumeKoefTrackBar.Scroll += new System.EventHandler(this.largeVolumeKoefTrackBar_Scroll);
            // 
            // largePositionCheckBox
            // 
            this.largePositionCheckBox.AutoSize = true;
            this.largePositionCheckBox.Location = new System.Drawing.Point(15, 68);
            this.largePositionCheckBox.Name = "largePositionCheckBox";
            this.largePositionCheckBox.Size = new System.Drawing.Size(137, 17);
            this.largePositionCheckBox.TabIndex = 15;
            this.largePositionCheckBox.Text = "Highlight large positions";
            this.largePositionCheckBox.UseVisualStyleBackColor = true;
            this.largePositionCheckBox.CheckedChanged += new System.EventHandler(this.largePositionCheckBox_CheckedChanged);
            // 
            // multiplierComboBox
            // 
            this.multiplierComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.multiplierComboBox.FormattingEnabled = true;
            this.multiplierComboBox.Items.AddRange(new object[] {
            "x1",
            "x10",
            "x100",
            "x1000",
            "x10000",
            "x100000",
            "x1000000"});
            this.multiplierComboBox.Location = new System.Drawing.Point(194, 38);
            this.multiplierComboBox.Name = "multiplierComboBox";
            this.multiplierComboBox.Size = new System.Drawing.Size(64, 21);
            this.multiplierComboBox.TabIndex = 14;
            this.multiplierComboBox.SelectionChangeCommitted += new System.EventHandler(this.multiplierComboBox_SelectionChangeCommitted);
            // 
            // multiplierLabel
            // 
            this.multiplierLabel.AutoSize = true;
            this.multiplierLabel.Location = new System.Drawing.Point(121, 42);
            this.multiplierLabel.Name = "multiplierLabel";
            this.multiplierLabel.Size = new System.Drawing.Size(48, 13);
            this.multiplierLabel.TabIndex = 12;
            this.multiplierLabel.Text = "Multiplier";
            // 
            // typeComboBox
            // 
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(317, 37);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(64, 21);
            this.typeComboBox.TabIndex = 11;
            this.typeComboBox.SelectionChangeCommitted += new System.EventHandler(this.typeComboBox_SelectionChangeCommitted);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Location = new System.Drawing.Point(271, 41);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(31, 13);
            this.typeLabel.TabIndex = 10;
            this.typeLabel.Text = "Type";
            // 
            // intervalTextBox
            // 
            this.intervalTextBox.Location = new System.Drawing.Point(341, 66);
            this.intervalTextBox.Name = "intervalTextBox";
            this.intervalTextBox.Size = new System.Drawing.Size(40, 20);
            this.intervalTextBox.TabIndex = 9;
            this.intervalTextBox.Text = "1000";
            this.intervalTextBox.TextChanged += new System.EventHandler(this.intervalTextBox_TextChanged);
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(262, 69);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(61, 13);
            this.intervalLabel.TabIndex = 7;
            this.intervalLabel.Text = "Interval, ms";
            // 
            // depthNumericUpDown
            // 
            this.depthNumericUpDown.Location = new System.Drawing.Point(58, 38);
            this.depthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.depthNumericUpDown.Name = "depthNumericUpDown";
            this.depthNumericUpDown.Size = new System.Drawing.Size(49, 20);
            this.depthNumericUpDown.TabIndex = 6;
            this.depthNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.depthNumericUpDown.ValueChanged += new System.EventHandler(this.depthNumericUpDown_ValueChanged);
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.Location = new System.Drawing.Point(12, 42);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(36, 13);
            this.depthLabel.TabIndex = 4;
            this.depthLabel.Text = "Depth";
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
            // orderBookPartPanel
            // 
            this.orderBookPartPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderBookPartPanel.Location = new System.Drawing.Point(0, 97);
            this.orderBookPartPanel.Name = "orderBookPartPanel";
            this.orderBookPartPanel.Size = new System.Drawing.Size(393, 319);
            this.orderBookPartPanel.TabIndex = 2;
            // 
            // OrderBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 416);
            this.Controls.Add(this.orderBookPartPanel);
            this.Controls.Add(this.topPanel);
            this.Name = "OrderBookForm";
            this.Text = "Order Book";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OrderBookForm_FormClosed);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.largeVolumeKoefTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.Label pairLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label marketLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label depthLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label intervalLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label typeLabel;
        [LocalizableClass]
        private System.Windows.Forms.Label multiplierLabel;
        [LocalizableClass]
        private System.Windows.Forms.CheckBox largePositionCheckBox;

        private System.Windows.Forms.ComboBox pairComboBox;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.NumericUpDown depthNumericUpDown;
        private System.Windows.Forms.TextBox intervalTextBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Panel orderBookPartPanel;
        private System.Windows.Forms.ComboBox multiplierComboBox;
        private System.Windows.Forms.TrackBar largeVolumeKoefTrackBar;
    }
}
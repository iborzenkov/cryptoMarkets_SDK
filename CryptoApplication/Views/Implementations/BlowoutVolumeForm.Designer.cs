using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "BlowoutVolumeForm")]
    partial class BlowoutVolumeForm
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
            this.marketComboBox = new System.Windows.Forms.ComboBox();
            this.marketLabel = new System.Windows.Forms.Label();
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pairListView = new System.Windows.Forms.ListView();
            this.pairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.barsAvailableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timeframeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.barCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.largeVolumeKoefTrackBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.autoTradeCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.balancePercentPerOneTradeUpDown = new System.Windows.Forms.NumericUpDown();
            this.sendEmailCheckBox = new System.Windows.Forms.CheckBox();
            this.eMailTextBox = new System.Windows.Forms.TextBox();
            this.settingsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barCountUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeVolumeKoefTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balancePercentPerOneTradeUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // marketComboBox
            // 
            this.marketComboBox.FormattingEnabled = true;
            this.marketComboBox.Location = new System.Drawing.Point(42, 19);
            this.marketComboBox.Name = "marketComboBox";
            this.marketComboBox.Size = new System.Drawing.Size(127, 21);
            this.marketComboBox.TabIndex = 0;
            this.marketComboBox.SelectedIndexChanged += new System.EventHandler(this.marketComboBox_SelectedIndexChanged);
            // 
            // marketLabel
            // 
            this.marketLabel.AutoSize = true;
            this.marketLabel.Location = new System.Drawing.Point(3, 22);
            this.marketLabel.Name = "marketLabel";
            this.marketLabel.Size = new System.Drawing.Size(40, 13);
            this.marketLabel.TabIndex = 1;
            this.marketLabel.Text = "Market";
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Controls.Add(this.eMailTextBox);
            this.settingsGroupBox.Controls.Add(this.sendEmailCheckBox);
            this.settingsGroupBox.Controls.Add(this.balancePercentPerOneTradeUpDown);
            this.settingsGroupBox.Controls.Add(this.label9);
            this.settingsGroupBox.Controls.Add(this.autoTradeCheckBox);
            this.settingsGroupBox.Controls.Add(this.barCountUpDown);
            this.settingsGroupBox.Controls.Add(this.timeframeComboBox);
            this.settingsGroupBox.Controls.Add(this.label2);
            this.settingsGroupBox.Controls.Add(this.label1);
            this.settingsGroupBox.Location = new System.Drawing.Point(193, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(397, 86);
            this.settingsGroupBox.TabIndex = 2;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bar Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pairListView);
            this.groupBox1.Controls.Add(this.marketComboBox);
            this.groupBox1.Controls.Add(this.marketLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 358);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Market Pairs";
            // 
            // pairListView
            // 
            this.pairListView.CheckBoxes = true;
            this.pairListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pairColumnHeader,
            this.barsAvailableColumnHeader});
            this.pairListView.Location = new System.Drawing.Point(0, 48);
            this.pairListView.Name = "pairListView";
            this.pairListView.Size = new System.Drawing.Size(169, 304);
            this.pairListView.TabIndex = 0;
            this.pairListView.UseCompatibleStateImageBehavior = false;
            this.pairListView.View = System.Windows.Forms.View.Details;
            this.pairListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.pairListView_ItemChecked);
            // 
            // pairColumnHeader
            // 
            this.pairColumnHeader.Text = "Pair";
            this.pairColumnHeader.Width = 70;
            // 
            // barsAvailableColumnHeader
            // 
            this.barsAvailableColumnHeader.Text = "Bars Available";
            this.barsAvailableColumnHeader.Width = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.largeVolumeKoefTrackBar);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(288, 104);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 266);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Timeframe";
            // 
            // timeframeComboBox
            // 
            this.timeframeComboBox.FormattingEnabled = true;
            this.timeframeComboBox.Location = new System.Drawing.Point(67, 19);
            this.timeframeComboBox.Name = "timeframeComboBox";
            this.timeframeComboBox.Size = new System.Drawing.Size(65, 21);
            this.timeframeComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Volumes";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 35);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(44, 225);
            this.listBox1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Limit volume:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "1.25";
            // 
            // barCountUpDown
            // 
            this.barCountUpDown.Location = new System.Drawing.Point(67, 46);
            this.barCountUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.barCountUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.barCountUpDown.Name = "barCountUpDown";
            this.barCountUpDown.Size = new System.Drawing.Size(65, 20);
            this.barCountUpDown.TabIndex = 7;
            this.barCountUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // largeVolumeKoefTrackBar
            // 
            this.largeVolumeKoefTrackBar.Location = new System.Drawing.Point(71, 35);
            this.largeVolumeKoefTrackBar.Maximum = 49;
            this.largeVolumeKoefTrackBar.Minimum = 1;
            this.largeVolumeKoefTrackBar.Name = "largeVolumeKoefTrackBar";
            this.largeVolumeKoefTrackBar.Size = new System.Drawing.Size(104, 45);
            this.largeVolumeKoefTrackBar.TabIndex = 17;
            this.largeVolumeKoefTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.largeVolumeKoefTrackBar.Value = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "1. Есть необходимое число баров для анализа";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(123, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "2. Есть критический объем";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "3. Есть открытая сделка по паре";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listView2);
            this.groupBox2.Location = new System.Drawing.Point(193, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(89, 266);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pairs";
            // 
            // listView2
            // 
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView2.Location = new System.Drawing.Point(4, 19);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(85, 235);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Pair";
            this.columnHeader1.Width = 70;
            // 
            // autoTradeCheckBox
            // 
            this.autoTradeCheckBox.AutoSize = true;
            this.autoTradeCheckBox.Location = new System.Drawing.Point(151, 21);
            this.autoTradeCheckBox.Name = "autoTradeCheckBox";
            this.autoTradeCheckBox.Size = new System.Drawing.Size(72, 17);
            this.autoTradeCheckBox.TabIndex = 8;
            this.autoTradeCheckBox.Text = "Autotrade";
            this.autoTradeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(267, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "% of the balance";
            // 
            // balancePercentPerOneTradeUpDown
            // 
            this.balancePercentPerOneTradeUpDown.Location = new System.Drawing.Point(221, 18);
            this.balancePercentPerOneTradeUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.balancePercentPerOneTradeUpDown.Name = "balancePercentPerOneTradeUpDown";
            this.balancePercentPerOneTradeUpDown.Size = new System.Drawing.Size(44, 20);
            this.balancePercentPerOneTradeUpDown.TabIndex = 10;
            this.balancePercentPerOneTradeUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // sendEmailCheckBox
            // 
            this.sendEmailCheckBox.AutoSize = true;
            this.sendEmailCheckBox.Location = new System.Drawing.Point(151, 44);
            this.sendEmailCheckBox.Name = "sendEmailCheckBox";
            this.sendEmailCheckBox.Size = new System.Drawing.Size(142, 17);
            this.sendEmailCheckBox.TabIndex = 11;
            this.sendEmailCheckBox.Text = "send notification to email";
            this.sendEmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // eMailTextBox
            // 
            this.eMailTextBox.Location = new System.Drawing.Point(297, 42);
            this.eMailTextBox.Name = "eMailTextBox";
            this.eMailTextBox.Size = new System.Drawing.Size(94, 20);
            this.eMailTextBox.TabIndex = 12;
            // 
            // BlowoutVolumeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.settingsGroupBox);
            this.Name = "BlowoutVolumeForm";
            this.Text = "BlowoutVolumeForm";
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barCountUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeVolumeKoefTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.balancePercentPerOneTradeUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.Label marketLabel;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox settingsGroupBox;

        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView pairListView;
        private System.Windows.Forms.ColumnHeader pairColumnHeader;
        private System.Windows.Forms.ColumnHeader barsAvailableColumnHeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox timeframeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown barCountUpDown;
        private System.Windows.Forms.NumericUpDown balancePercentPerOneTradeUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox autoTradeCheckBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar largeVolumeKoefTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TextBox eMailTextBox;
        private System.Windows.Forms.CheckBox sendEmailCheckBox;
    }
}
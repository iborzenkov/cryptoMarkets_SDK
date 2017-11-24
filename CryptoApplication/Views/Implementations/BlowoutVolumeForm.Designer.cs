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
            this.settingsGroupBox = new System.Windows.Forms.GroupBox();
            this.largeVolumeKoefLabel = new System.Windows.Forms.Label();
            this.historicSignalsCheckBox = new System.Windows.Forms.CheckBox();
            this.eMailTextBox = new System.Windows.Forms.TextBox();
            this.sendEmailCheckBox = new System.Windows.Forms.CheckBox();
            this.balancePercentPerOneTradeUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.largeVolumeKoefTrackBar = new System.Windows.Forms.TrackBar();
            this.autoTradeCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pairListView = new System.Windows.Forms.ListView();
            this.pairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.marketComboBox = new System.Windows.Forms.ComboBox();
            this.marketLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.barCountUpDown = new System.Windows.Forms.NumericUpDown();
            this.timeframeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addPairButton = new System.Windows.Forms.Button();
            this.analizingGroupBox = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.signalPairListView = new System.Windows.Forms.ListView();
            this.analizingPairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.analizingTimeframePairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.analizingBarCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.removePairButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.signalDetailsGroupBox = new System.Windows.Forms.GroupBox();
            this.timeSignalLabel = new System.Windows.Forms.Label();
            this.signalMarketLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.signalLimitVolumeLabel = new System.Windows.Forms.Label();
            this.signalVolumesListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.settingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balancePercentPerOneTradeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeVolumeKoefTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barCountUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.analizingGroupBox.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.signalDetailsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsGroupBox
            // 
            this.settingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsGroupBox.Controls.Add(this.largeVolumeKoefLabel);
            this.settingsGroupBox.Controls.Add(this.historicSignalsCheckBox);
            this.settingsGroupBox.Controls.Add(this.eMailTextBox);
            this.settingsGroupBox.Controls.Add(this.sendEmailCheckBox);
            this.settingsGroupBox.Controls.Add(this.balancePercentPerOneTradeUpDown);
            this.settingsGroupBox.Controls.Add(this.label9);
            this.settingsGroupBox.Controls.Add(this.largeVolumeKoefTrackBar);
            this.settingsGroupBox.Controls.Add(this.autoTradeCheckBox);
            this.settingsGroupBox.Location = new System.Drawing.Point(385, 12);
            this.settingsGroupBox.Name = "settingsGroupBox";
            this.settingsGroupBox.Size = new System.Drawing.Size(342, 117);
            this.settingsGroupBox.TabIndex = 2;
            this.settingsGroupBox.TabStop = false;
            this.settingsGroupBox.Text = "Settings";
            // 
            // largeVolumeKoefLabel
            // 
            this.largeVolumeKoefLabel.AutoSize = true;
            this.largeVolumeKoefLabel.Location = new System.Drawing.Point(6, 99);
            this.largeVolumeKoefLabel.Name = "largeVolumeKoefLabel";
            this.largeVolumeKoefLabel.Size = new System.Drawing.Size(100, 13);
            this.largeVolumeKoefLabel.TabIndex = 18;
            this.largeVolumeKoefLabel.Text = "Large Volume Koef:";
            // 
            // historicSignalsCheckBox
            // 
            this.historicSignalsCheckBox.AutoSize = true;
            this.historicSignalsCheckBox.Location = new System.Drawing.Point(8, 72);
            this.historicSignalsCheckBox.Name = "historicSignalsCheckBox";
            this.historicSignalsCheckBox.Size = new System.Drawing.Size(131, 17);
            this.historicSignalsCheckBox.TabIndex = 13;
            this.historicSignalsCheckBox.Text = "Show History Siagnals";
            this.historicSignalsCheckBox.UseVisualStyleBackColor = true;
            // 
            // eMailTextBox
            // 
            this.eMailTextBox.Location = new System.Drawing.Point(154, 47);
            this.eMailTextBox.Name = "eMailTextBox";
            this.eMailTextBox.Size = new System.Drawing.Size(94, 20);
            this.eMailTextBox.TabIndex = 12;
            // 
            // sendEmailCheckBox
            // 
            this.sendEmailCheckBox.AutoSize = true;
            this.sendEmailCheckBox.Location = new System.Drawing.Point(8, 49);
            this.sendEmailCheckBox.Name = "sendEmailCheckBox";
            this.sendEmailCheckBox.Size = new System.Drawing.Size(142, 17);
            this.sendEmailCheckBox.TabIndex = 11;
            this.sendEmailCheckBox.Text = "send notification to email";
            this.sendEmailCheckBox.UseVisualStyleBackColor = true;
            // 
            // balancePercentPerOneTradeUpDown
            // 
            this.balancePercentPerOneTradeUpDown.Location = new System.Drawing.Point(78, 21);
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
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "% of the balance";
            // 
            // largeVolumeKoefTrackBar
            // 
            this.largeVolumeKoefTrackBar.Location = new System.Drawing.Point(112, 95);
            this.largeVolumeKoefTrackBar.Maximum = 49;
            this.largeVolumeKoefTrackBar.Minimum = 1;
            this.largeVolumeKoefTrackBar.Name = "largeVolumeKoefTrackBar";
            this.largeVolumeKoefTrackBar.Size = new System.Drawing.Size(217, 45);
            this.largeVolumeKoefTrackBar.TabIndex = 17;
            this.largeVolumeKoefTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.largeVolumeKoefTrackBar.Value = 25;
            this.largeVolumeKoefTrackBar.Scroll += new System.EventHandler(this.largeVolumeKoefTrackBar_Scroll);
            // 
            // autoTradeCheckBox
            // 
            this.autoTradeCheckBox.AutoSize = true;
            this.autoTradeCheckBox.Location = new System.Drawing.Point(8, 24);
            this.autoTradeCheckBox.Name = "autoTradeCheckBox";
            this.autoTradeCheckBox.Size = new System.Drawing.Size(72, 17);
            this.autoTradeCheckBox.TabIndex = 8;
            this.autoTradeCheckBox.Text = "Autotrade";
            this.autoTradeCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 364);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All Market Pairs";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pairListView);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 49);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(145, 215);
            this.panel4.TabIndex = 5;
            // 
            // pairListView
            // 
            this.pairListView.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.pairListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pairColumnHeader});
            this.pairListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pairListView.FullRowSelect = true;
            this.pairListView.Location = new System.Drawing.Point(0, 0);
            this.pairListView.Name = "pairListView";
            this.pairListView.Size = new System.Drawing.Size(145, 215);
            this.pairListView.TabIndex = 0;
            this.pairListView.UseCompatibleStateImageBehavior = false;
            this.pairListView.View = System.Windows.Forms.View.Details;
            this.pairListView.SelectedIndexChanged += new System.EventHandler(this.pairListView_SelectedIndexChanged);
            // 
            // pairColumnHeader
            // 
            this.pairColumnHeader.Text = "Pair";
            this.pairColumnHeader.Width = 120;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.marketComboBox);
            this.panel3.Controls.Add(this.marketLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 33);
            this.panel3.TabIndex = 4;
            // 
            // marketComboBox
            // 
            this.marketComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.marketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.marketComboBox.FormattingEnabled = true;
            this.marketComboBox.Location = new System.Drawing.Point(45, 6);
            this.marketComboBox.Name = "marketComboBox";
            this.marketComboBox.Size = new System.Drawing.Size(97, 21);
            this.marketComboBox.TabIndex = 2;
            this.marketComboBox.SelectionChangeCommitted += new System.EventHandler(this.marketComboBox_SelectionChangeCommitted_1);
            // 
            // marketLabel
            // 
            this.marketLabel.AutoSize = true;
            this.marketLabel.Location = new System.Drawing.Point(3, 9);
            this.marketLabel.Name = "marketLabel";
            this.marketLabel.Size = new System.Drawing.Size(40, 13);
            this.marketLabel.TabIndex = 3;
            this.marketLabel.Text = "Market";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.barCountUpDown);
            this.panel2.Controls.Add(this.timeframeComboBox);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(145, 64);
            this.panel2.TabIndex = 3;
            // 
            // barCountUpDown
            // 
            this.barCountUpDown.Location = new System.Drawing.Point(70, 33);
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
            this.barCountUpDown.TabIndex = 11;
            this.barCountUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.barCountUpDown.ValueChanged += new System.EventHandler(this.barCountUpDown_ValueChanged);
            // 
            // timeframeComboBox
            // 
            this.timeframeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.timeframeComboBox.FormattingEnabled = true;
            this.timeframeComboBox.Location = new System.Drawing.Point(70, 6);
            this.timeframeComboBox.Name = "timeframeComboBox";
            this.timeframeComboBox.Size = new System.Drawing.Size(65, 21);
            this.timeframeComboBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Timeframe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Bar Count";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addPairButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(145, 33);
            this.panel1.TabIndex = 2;
            // 
            // addPairButton
            // 
            this.addPairButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addPairButton.Location = new System.Drawing.Point(3, 3);
            this.addPairButton.Name = "addPairButton";
            this.addPairButton.Size = new System.Drawing.Size(139, 23);
            this.addPairButton.TabIndex = 0;
            this.addPairButton.Text = "Add Pair To Analise";
            this.addPairButton.UseVisualStyleBackColor = true;
            this.addPairButton.Click += new System.EventHandler(this.addPairButton_Click);
            // 
            // analizingGroupBox
            // 
            this.analizingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.analizingGroupBox.Controls.Add(this.panel6);
            this.analizingGroupBox.Controls.Add(this.panel5);
            this.analizingGroupBox.Location = new System.Drawing.Point(163, 28);
            this.analizingGroupBox.Name = "analizingGroupBox";
            this.analizingGroupBox.Size = new System.Drawing.Size(219, 348);
            this.analizingGroupBox.TabIndex = 6;
            this.analizingGroupBox.TabStop = false;
            this.analizingGroupBox.Text = "Analizing Pairs";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.signalPairListView);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 16);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(213, 265);
            this.panel6.TabIndex = 4;
            // 
            // signalPairListView
            // 
            this.signalPairListView.CheckBoxes = true;
            this.signalPairListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.analizingPairColumnHeader,
            this.analizingTimeframePairColumnHeader,
            this.analizingBarCountColumnHeader});
            this.signalPairListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalPairListView.Location = new System.Drawing.Point(0, 0);
            this.signalPairListView.Name = "signalPairListView";
            this.signalPairListView.Size = new System.Drawing.Size(213, 265);
            this.signalPairListView.TabIndex = 0;
            this.signalPairListView.UseCompatibleStateImageBehavior = false;
            this.signalPairListView.View = System.Windows.Forms.View.Details;
            // 
            // analizingPairColumnHeader
            // 
            this.analizingPairColumnHeader.Text = "Pair";
            this.analizingPairColumnHeader.Width = 70;
            // 
            // analizingTimeframePairColumnHeader
            // 
            this.analizingTimeframePairColumnHeader.Text = "Timeframe";
            // 
            // analizingBarCountColumnHeader
            // 
            this.analizingBarCountColumnHeader.Text = "Bar Count";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.button2);
            this.panel5.Controls.Add(this.button1);
            this.panel5.Controls.Add(this.removePairButton);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 281);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(213, 64);
            this.panel5.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(110, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Load";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // removePairButton
            // 
            this.removePairButton.Location = new System.Drawing.Point(23, 8);
            this.removePairButton.Name = "removePairButton";
            this.removePairButton.Size = new System.Drawing.Size(163, 23);
            this.removePairButton.TabIndex = 0;
            this.removePairButton.Text = "Remove Pair From Analise";
            this.removePairButton.UseVisualStyleBackColor = true;
            this.removePairButton.Click += new System.EventHandler(this.removePairButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.signalDetailsGroupBox);
            this.groupBox4.Controls.Add(this.listView1);
            this.groupBox4.Location = new System.Drawing.Point(385, 135);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 241);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Signals";
            // 
            // signalDetailsGroupBox
            // 
            this.signalDetailsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signalDetailsGroupBox.Controls.Add(this.timeSignalLabel);
            this.signalDetailsGroupBox.Controls.Add(this.signalMarketLabel);
            this.signalDetailsGroupBox.Controls.Add(this.label8);
            this.signalDetailsGroupBox.Controls.Add(this.label7);
            this.signalDetailsGroupBox.Controls.Add(this.label6);
            this.signalDetailsGroupBox.Controls.Add(this.label5);
            this.signalDetailsGroupBox.Controls.Add(this.signalLimitVolumeLabel);
            this.signalDetailsGroupBox.Controls.Add(this.signalVolumesListBox);
            this.signalDetailsGroupBox.Controls.Add(this.label3);
            this.signalDetailsGroupBox.Location = new System.Drawing.Point(95, 19);
            this.signalDetailsGroupBox.Name = "signalDetailsGroupBox";
            this.signalDetailsGroupBox.Size = new System.Drawing.Size(241, 210);
            this.signalDetailsGroupBox.TabIndex = 6;
            this.signalDetailsGroupBox.TabStop = false;
            this.signalDetailsGroupBox.Text = "Details";
            // 
            // timeSignalLabel
            // 
            this.timeSignalLabel.AutoSize = true;
            this.timeSignalLabel.Location = new System.Drawing.Point(68, 92);
            this.timeSignalLabel.Name = "timeSignalLabel";
            this.timeSignalLabel.Size = new System.Drawing.Size(33, 13);
            this.timeSignalLabel.TabIndex = 22;
            this.timeSignalLabel.Text = "Time:";
            // 
            // signalMarketLabel
            // 
            this.signalMarketLabel.AutoSize = true;
            this.signalMarketLabel.Location = new System.Drawing.Point(68, 67);
            this.signalMarketLabel.Name = "signalMarketLabel";
            this.signalMarketLabel.Size = new System.Drawing.Size(43, 13);
            this.signalMarketLabel.TabIndex = 21;
            this.signalMarketLabel.Text = "Market:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(175, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "3. Есть открытая сделка по паре";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "2. Есть критический объем";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "1. Есть необходимое число баров для анализа";
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
            // signalLimitVolumeLabel
            // 
            this.signalLimitVolumeLabel.AutoSize = true;
            this.signalLimitVolumeLabel.Location = new System.Drawing.Point(68, 19);
            this.signalLimitVolumeLabel.Name = "signalLimitVolumeLabel";
            this.signalLimitVolumeLabel.Size = new System.Drawing.Size(68, 13);
            this.signalLimitVolumeLabel.TabIndex = 8;
            this.signalLimitVolumeLabel.Text = "Limit volume:";
            // 
            // signalVolumesListBox
            // 
            this.signalVolumesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.signalVolumesListBox.FormattingEnabled = true;
            this.signalVolumesListBox.Location = new System.Drawing.Point(9, 35);
            this.signalVolumesListBox.Name = "signalVolumesListBox";
            this.signalVolumesListBox.Size = new System.Drawing.Size(44, 160);
            this.signalVolumesListBox.TabIndex = 7;
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
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.listView1.Location = new System.Drawing.Point(4, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(85, 210);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pair";
            this.columnHeader2.Width = 70;
            // 
            // BlowoutVolumeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 382);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.analizingGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.settingsGroupBox);
            this.Name = "BlowoutVolumeForm";
            this.Text = "BlowoutVolumeForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BlowoutVolumeForm_FormClosed);
            this.settingsGroupBox.ResumeLayout(false);
            this.settingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.balancePercentPerOneTradeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.largeVolumeKoefTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barCountUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.analizingGroupBox.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.signalDetailsGroupBox.ResumeLayout(false);
            this.signalDetailsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        [LocalizableClass]
        private System.Windows.Forms.GroupBox settingsGroupBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView pairListView;
        private System.Windows.Forms.ColumnHeader pairColumnHeader;
        private System.Windows.Forms.NumericUpDown balancePercentPerOneTradeUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox autoTradeCheckBox;
        private System.Windows.Forms.GroupBox analizingGroupBox;
        private System.Windows.Forms.ListView signalPairListView;
        private System.Windows.Forms.ColumnHeader analizingPairColumnHeader;
        private System.Windows.Forms.TextBox eMailTextBox;
        private System.Windows.Forms.CheckBox sendEmailCheckBox;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox marketComboBox;
        private System.Windows.Forms.Label marketLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown barCountUpDown;
        private System.Windows.Forms.ComboBox timeframeComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addPairButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox signalDetailsGroupBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar largeVolumeKoefTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label signalLimitVolumeLabel;
        private System.Windows.Forms.ListBox signalVolumesListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader analizingTimeframePairColumnHeader;
        private System.Windows.Forms.ColumnHeader analizingBarCountColumnHeader;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button removePairButton;
        private System.Windows.Forms.CheckBox historicSignalsCheckBox;
        private System.Windows.Forms.Label timeSignalLabel;
        private System.Windows.Forms.Label signalMarketLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label largeVolumeKoefLabel;
    }
}
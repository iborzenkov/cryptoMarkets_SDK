using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "PairForm")]
    partial class PairForm
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
            this.pairPanel = new System.Windows.Forms.Panel();
            this.pairListView = new System.Windows.Forms.ListView();
            this.pairColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.activeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dailyChangeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.minTradeSizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filterPanel = new System.Windows.Forms.Panel();
            this.allDailyChangeRadioButton = new System.Windows.Forms.RadioButton();
            this.negativeDailyChangeRadioButton = new System.Windows.Forms.RadioButton();
            this.positiveDailyChangeRadioButton = new System.Windows.Forms.RadioButton();
            this.clearFilterButton = new System.Windows.Forms.Button();
            this.activeOnlyCheckBox = new System.Windows.Forms.CheckBox();
            this.filterTextBox = new System.Windows.Forms.TextBox();
            this.filterLabel = new System.Windows.Forms.Label();
            this.marketsGroupBox.SuspendLayout();
            this.pairPanel.SuspendLayout();
            this.filterPanel.SuspendLayout();
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
            // pairPanel
            // 
            this.pairPanel.Controls.Add(this.pairListView);
            this.pairPanel.Controls.Add(this.filterPanel);
            this.pairPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pairPanel.Location = new System.Drawing.Point(200, 0);
            this.pairPanel.Name = "pairPanel";
            this.pairPanel.Size = new System.Drawing.Size(376, 280);
            this.pairPanel.TabIndex = 3;
            // 
            // pairListView
            // 
            this.pairListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pairColumnHeader,
            this.activeColumnHeader,
            this.dailyChangeColumnHeader,
            this.minTradeSizeColumnHeader});
            this.pairListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pairListView.FullRowSelect = true;
            this.pairListView.GridLines = true;
            this.pairListView.Location = new System.Drawing.Point(0, 63);
            this.pairListView.MultiSelect = false;
            this.pairListView.Name = "pairListView";
            this.pairListView.Size = new System.Drawing.Size(376, 217);
            this.pairListView.TabIndex = 1;
            this.pairListView.UseCompatibleStateImageBehavior = false;
            this.pairListView.View = System.Windows.Forms.View.Details;
            this.pairListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.pairListView_ColumnClick);
            // 
            // pairColumnHeader
            // 
            this.pairColumnHeader.Text = "Pair";
            this.pairColumnHeader.Width = 90;
            // 
            // activeColumnHeader
            // 
            this.activeColumnHeader.Text = "Active?";
            // 
            // dailyChangeColumnHeader
            // 
            this.dailyChangeColumnHeader.Text = "Daily Change";
            this.dailyChangeColumnHeader.Width = 95;
            // 
            // minTradeSizeColumnHeader
            // 
            this.minTradeSizeColumnHeader.Text = "Min Trade Size";
            this.minTradeSizeColumnHeader.Width = 90;
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.allDailyChangeRadioButton);
            this.filterPanel.Controls.Add(this.negativeDailyChangeRadioButton);
            this.filterPanel.Controls.Add(this.positiveDailyChangeRadioButton);
            this.filterPanel.Controls.Add(this.clearFilterButton);
            this.filterPanel.Controls.Add(this.activeOnlyCheckBox);
            this.filterPanel.Controls.Add(this.filterTextBox);
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.filterPanel.Location = new System.Drawing.Point(0, 0);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(376, 63);
            this.filterPanel.TabIndex = 4;
            // 
            // allDailyChangeRadioButton
            // 
            this.allDailyChangeRadioButton.AutoSize = true;
            this.allDailyChangeRadioButton.Checked = true;
            this.allDailyChangeRadioButton.Location = new System.Drawing.Point(204, 43);
            this.allDailyChangeRadioButton.Name = "allDailyChangeRadioButton";
            this.allDailyChangeRadioButton.Size = new System.Drawing.Size(36, 17);
            this.allDailyChangeRadioButton.TabIndex = 7;
            this.allDailyChangeRadioButton.TabStop = true;
            this.allDailyChangeRadioButton.Text = "All";
            this.allDailyChangeRadioButton.UseVisualStyleBackColor = true;
            this.allDailyChangeRadioButton.CheckedChanged += new System.EventHandler(this.allDailyChangeRadioButton_CheckedChanged);
            // 
            // negativeDailyChangeRadioButton
            // 
            this.negativeDailyChangeRadioButton.AutoSize = true;
            this.negativeDailyChangeRadioButton.Location = new System.Drawing.Point(204, 25);
            this.negativeDailyChangeRadioButton.Name = "negativeDailyChangeRadioButton";
            this.negativeDailyChangeRadioButton.Size = new System.Drawing.Size(134, 17);
            this.negativeDailyChangeRadioButton.TabIndex = 6;
            this.negativeDailyChangeRadioButton.Text = "Negative Daily Change";
            this.negativeDailyChangeRadioButton.UseVisualStyleBackColor = true;
            this.negativeDailyChangeRadioButton.CheckedChanged += new System.EventHandler(this.negativeDailyChangeRadioButton_CheckedChanged);
            // 
            // positiveDailyChangeRadioButton
            // 
            this.positiveDailyChangeRadioButton.AutoSize = true;
            this.positiveDailyChangeRadioButton.Location = new System.Drawing.Point(204, 6);
            this.positiveDailyChangeRadioButton.Name = "positiveDailyChangeRadioButton";
            this.positiveDailyChangeRadioButton.Size = new System.Drawing.Size(128, 17);
            this.positiveDailyChangeRadioButton.TabIndex = 5;
            this.positiveDailyChangeRadioButton.Text = "Positive Daily Change";
            this.positiveDailyChangeRadioButton.UseVisualStyleBackColor = true;
            this.positiveDailyChangeRadioButton.CheckedChanged += new System.EventHandler(this.positiveDailyChangeRadioButton_CheckedChanged);
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.Image = global::Views.Properties.Resources.Delete;
            this.clearFilterButton.Location = new System.Drawing.Point(170, 11);
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(29, 22);
            this.clearFilterButton.TabIndex = 4;
            this.clearFilterButton.UseVisualStyleBackColor = true;
            this.clearFilterButton.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // activeOnlyCheckBox
            // 
            this.activeOnlyCheckBox.AutoSize = true;
            this.activeOnlyCheckBox.Location = new System.Drawing.Point(48, 38);
            this.activeOnlyCheckBox.Name = "activeOnlyCheckBox";
            this.activeOnlyCheckBox.Size = new System.Drawing.Size(80, 17);
            this.activeOnlyCheckBox.TabIndex = 3;
            this.activeOnlyCheckBox.Text = "Active Only";
            this.activeOnlyCheckBox.UseVisualStyleBackColor = true;
            this.activeOnlyCheckBox.CheckedChanged += new System.EventHandler(this.activeOnlyCheckBox_CheckedChanged);
            // 
            // filterTextBox
            // 
            this.filterTextBox.Location = new System.Drawing.Point(58, 12);
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
            // PairForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 280);
            this.Controls.Add(this.pairPanel);
            this.Controls.Add(this.marketsGroupBox);
            this.Name = "PairForm";
            this.Text = "Pairs";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PairForm_FormClosed);
            this.marketsGroupBox.ResumeLayout(false);
            this.pairPanel.ResumeLayout(false);
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.GroupBox marketsGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.Label filterLabel;
        [LocalizableClass]
        private System.Windows.Forms.CheckBox activeOnlyCheckBox;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton positiveDailyChangeRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton allDailyChangeRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.RadioButton negativeDailyChangeRadioButton;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader pairColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader dailyChangeColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader minTradeSizeColumnHeader;
        [LocalizableClass]
        private System.Windows.Forms.ColumnHeader activeColumnHeader;

        private System.Windows.Forms.ListBox marketListBox;
        private System.Windows.Forms.Panel pairPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.ListView pairListView;
        private System.Windows.Forms.TextBox filterTextBox;
        private System.Windows.Forms.Button clearFilterButton;
    }
}
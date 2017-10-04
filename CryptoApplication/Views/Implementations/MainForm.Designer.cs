using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "MainForm")]
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orderbooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balancesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strategiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blowoutVolumeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apiKeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.russianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candlestickGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.tradingToolStripMenuItem,
            this.strategiesToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(876, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currenciesToolStripMenuItem,
            this.pairsToolStripMenuItem,
            this.orderbooksToolStripMenuItem,
            this.balancesToolStripMenuItem,
            this.candlestickGraphToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "Information";
            // 
            // currenciesToolStripMenuItem
            // 
            this.currenciesToolStripMenuItem.Name = "currenciesToolStripMenuItem";
            this.currenciesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.currenciesToolStripMenuItem.Text = "Currencies...";
            this.currenciesToolStripMenuItem.Click += new System.EventHandler(this.currenciesToolStripMenuItem_Click);
            // 
            // pairsToolStripMenuItem
            // 
            this.pairsToolStripMenuItem.Name = "pairsToolStripMenuItem";
            this.pairsToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.pairsToolStripMenuItem.Text = "Pairs...";
            this.pairsToolStripMenuItem.Click += new System.EventHandler(this.pairsToolStripMenuItem_Click);
            // 
            // orderbooksToolStripMenuItem
            // 
            this.orderbooksToolStripMenuItem.Name = "orderbooksToolStripMenuItem";
            this.orderbooksToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.orderbooksToolStripMenuItem.Text = "Orderbooks...";
            this.orderbooksToolStripMenuItem.Click += new System.EventHandler(this.orderbooksToolStripMenuItem_Click);
            // 
            // balancesToolStripMenuItem
            // 
            this.balancesToolStripMenuItem.Name = "balancesToolStripMenuItem";
            this.balancesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.balancesToolStripMenuItem.Text = "Balances...";
            this.balancesToolStripMenuItem.Click += new System.EventHandler(this.balancesToolStripMenuItem_Click);
            // 
            // tradingToolStripMenuItem
            // 
            this.tradingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tradeToolStripMenuItem});
            this.tradingToolStripMenuItem.Name = "tradingToolStripMenuItem";
            this.tradingToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.tradingToolStripMenuItem.Text = "Trading";
            // 
            // tradeToolStripMenuItem
            // 
            this.tradeToolStripMenuItem.Name = "tradeToolStripMenuItem";
            this.tradeToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.tradeToolStripMenuItem.Text = "Trade...";
            this.tradeToolStripMenuItem.Click += new System.EventHandler(this.tradeToolStripMenuItem_Click);
            // 
            // strategiesToolStripMenuItem
            // 
            this.strategiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blowoutVolumeToolStripMenuItem});
            this.strategiesToolStripMenuItem.Name = "strategiesToolStripMenuItem";
            this.strategiesToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.strategiesToolStripMenuItem.Text = "Strategies";
            // 
            // blowoutVolumeToolStripMenuItem
            // 
            this.blowoutVolumeToolStripMenuItem.Name = "blowoutVolumeToolStripMenuItem";
            this.blowoutVolumeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.blowoutVolumeToolStripMenuItem.Text = "Blowout Volume...";
            this.blowoutVolumeToolStripMenuItem.Click += new System.EventHandler(this.blowoutVolumeToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.apiKeysToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // apiKeysToolStripMenuItem
            // 
            this.apiKeysToolStripMenuItem.Name = "apiKeysToolStripMenuItem";
            this.apiKeysToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.apiKeysToolStripMenuItem.Text = "API Keys...";
            this.apiKeysToolStripMenuItem.Click += new System.EventHandler(this.apiKeysToolStripMenuItem1_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.russianToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            this.languageToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.languageToolStripMenuItem.Text = "Language";
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // russianToolStripMenuItem
            // 
            this.russianToolStripMenuItem.Name = "russianToolStripMenuItem";
            this.russianToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.russianToolStripMenuItem.Text = "Russian";
            this.russianToolStripMenuItem.Click += new System.EventHandler(this.russianToolStripMenuItem_Click);
            // 
            // candlestickGraphToolStripMenuItem
            // 
            this.candlestickGraphToolStripMenuItem.Name = "candlestickGraphToolStripMenuItem";
            this.candlestickGraphToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.candlestickGraphToolStripMenuItem.Text = "Candlestick Graph...";
            this.candlestickGraphToolStripMenuItem.Click += new System.EventHandler(this.candlestickGraphToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 532);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem orderbooksToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem currenciesToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem balancesToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem apiKeysToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem tradingToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem pairsToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem russianToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem strategiesToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem tradeToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem blowoutVolumeToolStripMenuItem;
        [LocalizableClass]
        private System.Windows.Forms.ToolStripMenuItem candlestickGraphToolStripMenuItem;
    }
}


using Genesis.Localization.Mappings;

namespace Views.Implementations
{
    [LocalizableClass("Text", "ApiKeyForm")]
    partial class ApiKeyForm
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
            this.apiKeysGroupBox = new System.Windows.Forms.GroupBox();
            this.marketsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // marketsGroupBox
            // 
            this.marketsGroupBox.Controls.Add(this.marketListBox);
            this.marketsGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.marketsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.marketsGroupBox.Name = "marketsGroupBox";
            this.marketsGroupBox.Size = new System.Drawing.Size(200, 345);
            this.marketsGroupBox.TabIndex = 1;
            this.marketsGroupBox.TabStop = false;
            this.marketsGroupBox.Text = "Markets";
            // 
            // marketListBox
            // 
            this.marketListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marketListBox.FormattingEnabled = true;
            this.marketListBox.Location = new System.Drawing.Point(3, 16);
            this.marketListBox.Name = "marketListBox";
            this.marketListBox.Size = new System.Drawing.Size(194, 326);
            this.marketListBox.TabIndex = 0;
            this.marketListBox.SelectedIndexChanged += new System.EventHandler(this.marketListBox_SelectedIndexChanged);
            // 
            // apiKeysGroupBox
            // 
            this.apiKeysGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apiKeysGroupBox.Location = new System.Drawing.Point(200, 0);
            this.apiKeysGroupBox.Name = "apiKeysGroupBox";
            this.apiKeysGroupBox.Size = new System.Drawing.Size(293, 345);
            this.apiKeysGroupBox.TabIndex = 4;
            this.apiKeysGroupBox.TabStop = false;
            this.apiKeysGroupBox.Text = "API keys";
            // 
            // ApiKeyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 345);
            this.Controls.Add(this.apiKeysGroupBox);
            this.Controls.Add(this.marketsGroupBox);
            this.Name = "ApiKeyForm";
            this.Text = "API Keys";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ApiKeyForm_FormClosed);
            this.marketsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        [LocalizableClass]
        private System.Windows.Forms.GroupBox marketsGroupBox;
        [LocalizableClass]
        private System.Windows.Forms.GroupBox apiKeysGroupBox;

        private System.Windows.Forms.ListBox marketListBox;
    }
}
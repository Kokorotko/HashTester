namespace HashTester
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonHashSimpleText = new System.Windows.Forms.Button();
            this.textHashSimple = new System.Windows.Forms.TextBox();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.buttonFileInput = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.labelCredits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(12, 67);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(133, 23);
            this.buttonHashSimpleText.TabIndex = 0;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // textHashSimple
            // 
            this.textHashSimple.Location = new System.Drawing.Point(13, 94);
            this.textHashSimple.Multiline = true;
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(400, 59);
            this.textHashSimple.TabIndex = 1;
            this.textHashSimple.Text = "Hello This is Test";
            // 
            // hashSelector
            // 
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512",
            "RipeMD-160",
            "CRC32"});
            this.hashSelector.Location = new System.Drawing.Point(292, 67);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(121, 21);
            this.hashSelector.TabIndex = 4;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // buttonFileInput
            // 
            this.buttonFileInput.Location = new System.Drawing.Point(151, 67);
            this.buttonFileInput.Name = "buttonFileInput";
            this.buttonFileInput.Size = new System.Drawing.Size(135, 23);
            this.buttonFileInput.TabIndex = 5;
            this.buttonFileInput.Text = "Hash .txt file";
            this.buttonFileInput.UseVisualStyleBackColor = true;
            this.buttonFileInput.Click += new System.EventHandler(this.TXTInput_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.Location = new System.Drawing.Point(13, 159);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(400, 108);
            this.listBoxLog.TabIndex = 10;
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(12, 273);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(130, 23);
            this.buttonClearListBox.TabIndex = 11;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(147, 273);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(130, 23);
            this.buttonSaveLog.TabIndex = 15;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(283, 273);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(130, 23);
            this.buttonClipboard.TabIndex = 16;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // labelCredits
            // 
            this.labelCredits.AutoSize = true;
            this.labelCredits.Location = new System.Drawing.Point(16, 299);
            this.labelCredits.Name = "labelCredits";
            this.labelCredits.Size = new System.Drawing.Size(115, 26);
            this.labelCredits.TabIndex = 17;
            this.labelCredits.Text = "Made by: Kamil Franek\r\nCurrent Version: x.xx.x";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(420, 340);
            this.Controls.Add(this.labelCredits);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonFileInput);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Name = "Form1";
            this.Text = "HashTester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHashSimpleText;
        private System.Windows.Forms.TextBox textHashSimple;
        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.Button buttonFileInput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.Label labelCredits;
    }
}


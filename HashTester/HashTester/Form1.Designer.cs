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
            this.TXTInput = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hashingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradualHashingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeSaltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includePepperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradualHashingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileChecksumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hashCollisionDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordJailbreakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeOriginalStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeNumberOfHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeHashingAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(16, 64);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(75, 23);
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
            this.textHashSimple.Size = new System.Drawing.Size(775, 59);
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
            this.hashSelector.Location = new System.Drawing.Point(178, 67);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(121, 21);
            this.hashSelector.TabIndex = 4;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // TXTInput
            // 
            this.TXTInput.Location = new System.Drawing.Point(97, 65);
            this.TXTInput.Name = "TXTInput";
            this.TXTInput.Size = new System.Drawing.Size(75, 23);
            this.TXTInput.TabIndex = 5;
            this.TXTInput.Text = "TXTInput";
            this.TXTInput.UseVisualStyleBackColor = true;
            this.TXTInput.Click += new System.EventHandler(this.TXTInput_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 159);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(600, 251);
            this.listBox1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(600, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hashingToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.languagesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hashingToolStripMenuItem
            // 
            this.hashingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gradualHashingToolStripMenuItem,
            this.gradualHashingToolStripMenuItem1,
            this.fileChecksumToolStripMenuItem,
            this.hashCollisionDetectionToolStripMenuItem,
            this.passwordJailbreakToolStripMenuItem});
            this.hashingToolStripMenuItem.Name = "hashingToolStripMenuItem";
            this.hashingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.hashingToolStripMenuItem.Text = "Hashing";
            // 
            // gradualHashingToolStripMenuItem
            // 
            this.gradualHashingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeSaltToolStripMenuItem,
            this.includePepperToolStripMenuItem});
            this.gradualHashingToolStripMenuItem.Name = "gradualHashingToolStripMenuItem";
            this.gradualHashingToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.gradualHashingToolStripMenuItem.Text = "Salt and Pepper";
            // 
            // includeSaltToolStripMenuItem
            // 
            this.includeSaltToolStripMenuItem.Name = "includeSaltToolStripMenuItem";
            this.includeSaltToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.includeSaltToolStripMenuItem.Text = "Include salt";
            this.includeSaltToolStripMenuItem.Click += new System.EventHandler(this.includeSaltToolStripMenuItem_Click);
            // 
            // includePepperToolStripMenuItem
            // 
            this.includePepperToolStripMenuItem.Name = "includePepperToolStripMenuItem";
            this.includePepperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.includePepperToolStripMenuItem.Text = "Include pepper";
            this.includePepperToolStripMenuItem.Click += new System.EventHandler(this.includePepperToolStripMenuItem_Click);
            // 
            // gradualHashingToolStripMenuItem1
            // 
            this.gradualHashingToolStripMenuItem1.Name = "gradualHashingToolStripMenuItem1";
            this.gradualHashingToolStripMenuItem1.Size = new System.Drawing.Size(204, 22);
            this.gradualHashingToolStripMenuItem1.Text = "Gradual Hashing";
            this.gradualHashingToolStripMenuItem1.Click += new System.EventHandler(this.gradualHashingToolStripMenuItem1_Click);
            // 
            // fileChecksumToolStripMenuItem
            // 
            this.fileChecksumToolStripMenuItem.Name = "fileChecksumToolStripMenuItem";
            this.fileChecksumToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.fileChecksumToolStripMenuItem.Text = "File Checksum";
            // 
            // hashCollisionDetectionToolStripMenuItem
            // 
            this.hashCollisionDetectionToolStripMenuItem.Name = "hashCollisionDetectionToolStripMenuItem";
            this.hashCollisionDetectionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.hashCollisionDetectionToolStripMenuItem.Text = "Hash Collision Detection";
            // 
            // passwordJailbreakToolStripMenuItem
            // 
            this.passwordJailbreakToolStripMenuItem.Name = "passwordJailbreakToolStripMenuItem";
            this.passwordJailbreakToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.passwordJailbreakToolStripMenuItem.Text = "Password Jailbreak";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.outputToolStripMenuItem,
            this.outputStyleToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // outputToolStripMenuItem
            // 
            this.outputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageBoxToolStripMenuItem,
            this.listBoxToolStripMenuItem,
            this.txtFileToolStripMenuItem});
            this.outputToolStripMenuItem.Name = "outputToolStripMenuItem";
            this.outputToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outputToolStripMenuItem.Text = "Output Type";
            // 
            // messageBoxToolStripMenuItem
            // 
            this.messageBoxToolStripMenuItem.Name = "messageBoxToolStripMenuItem";
            this.messageBoxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.messageBoxToolStripMenuItem.Text = "MessageBox";
            this.messageBoxToolStripMenuItem.Click += new System.EventHandler(this.messageBoxToolStripMenuItem_Click);
            // 
            // listBoxToolStripMenuItem
            // 
            this.listBoxToolStripMenuItem.Name = "listBoxToolStripMenuItem";
            this.listBoxToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listBoxToolStripMenuItem.Text = "ListBox";
            this.listBoxToolStripMenuItem.Click += new System.EventHandler(this.listBoxToolStripMenuItem_Click);
            // 
            // txtFileToolStripMenuItem
            // 
            this.txtFileToolStripMenuItem.Name = "txtFileToolStripMenuItem";
            this.txtFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.txtFileToolStripMenuItem.Text = "TxtFile";
            this.txtFileToolStripMenuItem.Click += new System.EventHandler(this.txtFileToolStripMenuItem_Click);
            // 
            // outputStyleToolStripMenuItem
            // 
            this.outputStyleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeOriginalStringToolStripMenuItem,
            this.includeNumberOfHashToolStripMenuItem,
            this.includeHashingAlgorithmToolStripMenuItem});
            this.outputStyleToolStripMenuItem.Name = "outputStyleToolStripMenuItem";
            this.outputStyleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outputStyleToolStripMenuItem.Text = "Output Style";
            // 
            // includeOriginalStringToolStripMenuItem
            // 
            this.includeOriginalStringToolStripMenuItem.Name = "includeOriginalStringToolStripMenuItem";
            this.includeOriginalStringToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.includeOriginalStringToolStripMenuItem.Text = "Include original string";
            this.includeOriginalStringToolStripMenuItem.Click += new System.EventHandler(this.includeOriginalStringToolStripMenuItem_Click);
            // 
            // includeNumberOfHashToolStripMenuItem
            // 
            this.includeNumberOfHashToolStripMenuItem.Name = "includeNumberOfHashToolStripMenuItem";
            this.includeNumberOfHashToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.includeNumberOfHashToolStripMenuItem.Text = "Include number of hash";
            this.includeNumberOfHashToolStripMenuItem.Click += new System.EventHandler(this.includeNumberOfHashToolStripMenuItem_Click);
            // 
            // includeHashingAlgorithmToolStripMenuItem
            // 
            this.includeHashingAlgorithmToolStripMenuItem.Name = "includeHashingAlgorithmToolStripMenuItem";
            this.includeHashingAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.includeHashingAlgorithmToolStripMenuItem.Text = "Include hashing algorithm";
            this.includeHashingAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.includeHashingAlgorithmToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languagesToolStripMenuItem.Text = "Languages";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.TXTInput);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHashSimpleText;
        private System.Windows.Forms.TextBox textHashSimple;
        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.Button TXTInput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hashingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradualHashingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputStyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listBoxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem txtFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeOriginalStringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeNumberOfHashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeHashingAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeSaltToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includePepperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradualHashingToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileChecksumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hashCollisionDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordJailbreakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
    }
}


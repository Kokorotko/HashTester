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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hashingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saltAndPepperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeSaltToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includePepperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradualHashingToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileChecksumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saltPepperTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.multipleHashingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findingCollisionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordBruteForceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UIUpdateFrequencyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.threadsAndCPUSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputTypeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputStyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeOriginalStringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeNumberOfHashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeHashingAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeSaltAndPepperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(16, 67);
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
            this.textHashSimple.Size = new System.Drawing.Size(389, 59);
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
            // buttonFileInput
            // 
            this.buttonFileInput.Location = new System.Drawing.Point(97, 65);
            this.buttonFileInput.Name = "buttonFileInput";
            this.buttonFileInput.Size = new System.Drawing.Size(75, 23);
            this.buttonFileInput.TabIndex = 5;
            this.buttonFileInput.Text = "TXTInput";
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
            this.listBoxLog.Size = new System.Drawing.Size(389, 251);
            this.listBoxLog.TabIndex = 10;
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(13, 415);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(99, 23);
            this.buttonClearListBox.TabIndex = 11;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hashingToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.languagesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(420, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hashingToolStripMenuItem
            // 
            this.hashingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saltAndPepperToolStripMenuItem,
            this.gradualHashingToolStripMenuItem1,
            this.fileChecksumToolStripMenuItem,
            this.saltPepperTesterToolStripMenuItem,
            this.multipleHashingToolStripMenuItem,
            this.findingCollisionsToolStripMenuItem,
            this.passwordBruteForceToolStripMenuItem});
            this.hashingToolStripMenuItem.Name = "hashingToolStripMenuItem";
            this.hashingToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.hashingToolStripMenuItem.Text = "Hashing";
            // 
            // saltAndPepperToolStripMenuItem
            // 
            this.saltAndPepperToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeSaltToolStripMenuItem,
            this.includePepperToolStripMenuItem});
            this.saltAndPepperToolStripMenuItem.Name = "saltAndPepperToolStripMenuItem";
            this.saltAndPepperToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saltAndPepperToolStripMenuItem.Text = "Salt and Pepper";
            // 
            // includeSaltToolStripMenuItem
            // 
            this.includeSaltToolStripMenuItem.Name = "includeSaltToolStripMenuItem";
            this.includeSaltToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.includeSaltToolStripMenuItem.Text = "Use Salt";
            this.includeSaltToolStripMenuItem.Click += new System.EventHandler(this.includeSaltToolStripMenuItem_Click);
            // 
            // includePepperToolStripMenuItem
            // 
            this.includePepperToolStripMenuItem.Name = "includePepperToolStripMenuItem";
            this.includePepperToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.includePepperToolStripMenuItem.Text = "Use Pepper";
            this.includePepperToolStripMenuItem.Click += new System.EventHandler(this.includePepperToolStripMenuItem_Click);
            // 
            // gradualHashingToolStripMenuItem1
            // 
            this.gradualHashingToolStripMenuItem1.Name = "gradualHashingToolStripMenuItem1";
            this.gradualHashingToolStripMenuItem1.Size = new System.Drawing.Size(187, 22);
            this.gradualHashingToolStripMenuItem1.Text = "Gradual Hashing";
            this.gradualHashingToolStripMenuItem1.Click += new System.EventHandler(this.gradualHashingToolStripMenuItem1_Click);
            // 
            // fileChecksumToolStripMenuItem
            // 
            this.fileChecksumToolStripMenuItem.Name = "fileChecksumToolStripMenuItem";
            this.fileChecksumToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.fileChecksumToolStripMenuItem.Text = "File Checksum";
            this.fileChecksumToolStripMenuItem.Click += new System.EventHandler(this.fileChecksumToolStripMenuItem_Click);
            // 
            // saltPepperTesterToolStripMenuItem
            // 
            this.saltPepperTesterToolStripMenuItem.Name = "saltPepperTesterToolStripMenuItem";
            this.saltPepperTesterToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saltPepperTesterToolStripMenuItem.Text = "Salt/Pepper Tester";
            this.saltPepperTesterToolStripMenuItem.Click += new System.EventHandler(this.saltPepperTesterToolStripMenuItem_Click);
            // 
            // multipleHashingToolStripMenuItem
            // 
            this.multipleHashingToolStripMenuItem.Name = "multipleHashingToolStripMenuItem";
            this.multipleHashingToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.multipleHashingToolStripMenuItem.Text = "Multiple Hashing";
            this.multipleHashingToolStripMenuItem.Click += new System.EventHandler(this.multipleHashingToolStripMenuItem_Click);
            // 
            // findingCollisionsToolStripMenuItem
            // 
            this.findingCollisionsToolStripMenuItem.Name = "findingCollisionsToolStripMenuItem";
            this.findingCollisionsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.findingCollisionsToolStripMenuItem.Text = "Finding Collisions";
            this.findingCollisionsToolStripMenuItem.Click += new System.EventHandler(this.findingCollisionsToolStripMenuItem_Click);
            // 
            // passwordBruteForceToolStripMenuItem
            // 
            this.passwordBruteForceToolStripMenuItem.Name = "passwordBruteForceToolStripMenuItem";
            this.passwordBruteForceToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.passwordBruteForceToolStripMenuItem.Text = "Password Brute Force";
            this.passwordBruteForceToolStripMenuItem.Click += new System.EventHandler(this.passwordJailbreakToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.outputTypeStripMenuItem,
            this.outputStyleToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualModeToolStripMenuItem,
            this.UIUpdateFrequencyToolStripMenuItem,
            this.threadsAndCPUSettingsToolStripMenuItem,
            this.resetAllSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // visualModeToolStripMenuItem
            // 
            this.visualModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.lightToolStripMenuItem,
            this.darkToolStripMenuItem});
            this.visualModeToolStripMenuItem.Name = "visualModeToolStripMenuItem";
            this.visualModeToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.visualModeToolStripMenuItem.Text = "VisualMode";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.Checked = true;
            this.systemToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.systemToolStripMenuItem.Text = "System";
            this.systemToolStripMenuItem.Click += new System.EventHandler(this.systemToolStripMenuItem_Click);
            // 
            // lightToolStripMenuItem
            // 
            this.lightToolStripMenuItem.Name = "lightToolStripMenuItem";
            this.lightToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.lightToolStripMenuItem.Text = "Light";
            this.lightToolStripMenuItem.Click += new System.EventHandler(this.lightToolStripMenuItem_Click);
            // 
            // darkToolStripMenuItem
            // 
            this.darkToolStripMenuItem.Name = "darkToolStripMenuItem";
            this.darkToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.darkToolStripMenuItem.Text = "Dark";
            this.darkToolStripMenuItem.Click += new System.EventHandler(this.darkToolStripMenuItem_Click);
            // 
            // UIUpdateFrequencyToolStripMenuItem
            // 
            this.UIUpdateFrequencyToolStripMenuItem.Name = "UIUpdateFrequencyToolStripMenuItem";
            this.UIUpdateFrequencyToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.UIUpdateFrequencyToolStripMenuItem.Text = "UI Update Frequency";
            this.UIUpdateFrequencyToolStripMenuItem.Click += new System.EventHandler(this.UIUpdateFrequencyToolStripMenuItem_Click);
            // 
            // threadsAndCPUSettingsToolStripMenuItem
            // 
            this.threadsAndCPUSettingsToolStripMenuItem.Name = "threadsAndCPUSettingsToolStripMenuItem";
            this.threadsAndCPUSettingsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.threadsAndCPUSettingsToolStripMenuItem.Text = "Threads and CPU settings";
            this.threadsAndCPUSettingsToolStripMenuItem.Click += new System.EventHandler(this.threadsAndCPUSettingsToolStripMenuItem_Click);
            // 
            // resetAllSettingsToolStripMenuItem
            // 
            this.resetAllSettingsToolStripMenuItem.Name = "resetAllSettingsToolStripMenuItem";
            this.resetAllSettingsToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.resetAllSettingsToolStripMenuItem.Text = "Reset All Settings";
            this.resetAllSettingsToolStripMenuItem.Click += new System.EventHandler(this.resetAllSettingsToolStripMenuItem_Click);
            // 
            // outputTypeStripMenuItem
            // 
            this.outputTypeStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messageBoxToolStripMenuItem,
            this.listBoxToolStripMenuItem,
            this.txtFileToolStripMenuItem});
            this.outputTypeStripMenuItem.Name = "outputTypeStripMenuItem";
            this.outputTypeStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.outputTypeStripMenuItem.Text = "Output Type";
            // 
            // messageBoxToolStripMenuItem
            // 
            this.messageBoxToolStripMenuItem.Name = "messageBoxToolStripMenuItem";
            this.messageBoxToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.messageBoxToolStripMenuItem.Text = "MessageBox";
            this.messageBoxToolStripMenuItem.Click += new System.EventHandler(this.messageBoxToolStripMenuItem_Click);
            // 
            // listBoxToolStripMenuItem
            // 
            this.listBoxToolStripMenuItem.Name = "listBoxToolStripMenuItem";
            this.listBoxToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.listBoxToolStripMenuItem.Text = "ListBox";
            this.listBoxToolStripMenuItem.Click += new System.EventHandler(this.listBoxToolStripMenuItem_Click);
            // 
            // txtFileToolStripMenuItem
            // 
            this.txtFileToolStripMenuItem.Name = "txtFileToolStripMenuItem";
            this.txtFileToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.txtFileToolStripMenuItem.Text = "TxtFile";
            this.txtFileToolStripMenuItem.Click += new System.EventHandler(this.txtFileToolStripMenuItem_Click);
            // 
            // outputStyleToolStripMenuItem
            // 
            this.outputStyleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.includeOriginalStringToolStripMenuItem,
            this.includeNumberOfHashToolStripMenuItem,
            this.includeHashingAlgorithmToolStripMenuItem,
            this.includeSaltAndPepperToolStripMenuItem,
            this.includeAllToolStripMenuItem});
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
            // includeSaltAndPepperToolStripMenuItem
            // 
            this.includeSaltAndPepperToolStripMenuItem.Name = "includeSaltAndPepperToolStripMenuItem";
            this.includeSaltAndPepperToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.includeSaltAndPepperToolStripMenuItem.Text = "Include salt and pepper";
            this.includeSaltAndPepperToolStripMenuItem.Click += new System.EventHandler(this.includeSaltAndPepperToolStripMenuItem_Click);
            // 
            // includeAllToolStripMenuItem
            // 
            this.includeAllToolStripMenuItem.Name = "includeAllToolStripMenuItem";
            this.includeAllToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.includeAllToolStripMenuItem.Text = "Include all";
            this.includeAllToolStripMenuItem.Click += new System.EventHandler(this.includeAllToolStripMenuItem_Click);
            // 
            // languagesToolStripMenuItem
            // 
            this.languagesToolStripMenuItem.Name = "languagesToolStripMenuItem";
            this.languagesToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.languagesToolStripMenuItem.Text = "Languages";
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(118, 416);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(114, 23);
            this.buttonSaveLog.TabIndex = 15;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(238, 416);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(164, 23);
            this.buttonClipboard.TabIndex = 16;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(420, 450);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonFileInput);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "HashTester";
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
        private System.Windows.Forms.Button buttonFileInput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem hashingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saltAndPepperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outputTypeStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem languagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeSaltAndPepperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem multipleHashingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findingCollisionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetAllSettingsToolStripMenuItem;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.ToolStripMenuItem UIUpdateFrequencyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem threadsAndCPUSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeAllToolStripMenuItem;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.ToolStripMenuItem passwordBruteForceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileChecksumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saltPepperTesterToolStripMenuItem;
    }
}


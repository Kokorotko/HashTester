namespace HashTester
{
    partial class FormGradual
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
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.buttonHashGradualHashing = new System.Windows.Forms.Button();
            this.textBoxHash = new System.Windows.Forms.TextBox();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.labelQualityName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 94);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(400, 316);
            this.listBoxLog.TabIndex = 6;
            // 
            // buttonHashGradualHashing
            // 
            this.buttonHashGradualHashing.Location = new System.Drawing.Point(12, 12);
            this.buttonHashGradualHashing.Name = "buttonHashGradualHashing";
            this.buttonHashGradualHashing.Size = new System.Drawing.Size(200, 23);
            this.buttonHashGradualHashing.TabIndex = 5;
            this.buttonHashGradualHashing.Text = "Gradual Hashing";
            this.buttonHashGradualHashing.UseVisualStyleBackColor = true;
            this.buttonHashGradualHashing.Click += new System.EventHandler(this.buttonHashGradualHashing_Click);
            // 
            // textBoxHash
            // 
            this.textBoxHash.Location = new System.Drawing.Point(12, 42);
            this.textBoxHash.Name = "textBoxHash";
            this.textBoxHash.Size = new System.Drawing.Size(400, 20);
            this.textBoxHash.TabIndex = 7;
            // 
            // hashSelector
            // 
            this.hashSelector.AllowDrop = true;
            this.hashSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512",
            "RipeMD-160",
            "CRC32"});
            this.hashSelector.Location = new System.Drawing.Point(291, 14);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(121, 21);
            this.hashSelector.TabIndex = 8;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(10, 418);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(130, 23);
            this.buttonClearListBox.TabIndex = 9;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(146, 418);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(130, 23);
            this.buttonSaveLog.TabIndex = 10;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(282, 418);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(130, 23);
            this.buttonClipboard.TabIndex = 11;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // labelQualityName
            // 
            this.labelQualityName.AutoSize = true;
            this.labelQualityName.Location = new System.Drawing.Point(12, 69);
            this.labelQualityName.Name = "labelQualityName";
            this.labelQualityName.Size = new System.Drawing.Size(128, 13);
            this.labelQualityName.TabIndex = 12;
            this.labelQualityName.Text = "*will NOT use salt/pepper";
            // 
            // FormGradual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 450);
            this.Controls.Add(this.labelQualityName);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.textBoxHash);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonHashGradualHashing);
            this.Name = "FormGradual";
            this.Text = "Gradual_Hashing";
            this.Load += new System.EventHandler(this.FormGradual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonHashGradualHashing;
        private System.Windows.Forms.TextBox textBoxHash;
        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.Label labelQualityName;
    }
}
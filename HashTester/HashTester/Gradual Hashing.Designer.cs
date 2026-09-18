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
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.labelQualityName = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.checkBoxShowInfo = new System.Windows.Forms.CheckBox();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxLog, 3);
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 16;
            this.listBoxLog.Location = new System.Drawing.Point(10, 187);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(1144, 287);
            this.listBoxLog.TabIndex = 6;
            // 
            // buttonHashGradualHashing
            // 
            this.buttonHashGradualHashing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHashGradualHashing.Location = new System.Drawing.Point(10, 10);
            this.buttonHashGradualHashing.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHashGradualHashing.Name = "buttonHashGradualHashing";
            this.buttonHashGradualHashing.Size = new System.Drawing.Size(375, 51);
            this.buttonHashGradualHashing.TabIndex = 5;
            this.buttonHashGradualHashing.Text = "Gradual Hashing";
            this.buttonHashGradualHashing.UseVisualStyleBackColor = true;
            this.buttonHashGradualHashing.Click += new System.EventHandler(this.buttonHashGradualHashing_Click);
            // 
            // textBoxHash
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxHash, 3);
            this.textBoxHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHash.Location = new System.Drawing.Point(10, 69);
            this.textBoxHash.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHash.Name = "textBoxHash";
            this.textBoxHash.Size = new System.Drawing.Size(1144, 45);
            this.textBoxHash.TabIndex = 7;
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearListBox.Location = new System.Drawing.Point(10, 482);
            this.buttonClearListBox.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(375, 111);
            this.buttonClearListBox.TabIndex = 9;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveLog.Location = new System.Drawing.Point(393, 482);
            this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(375, 111);
            this.buttonSaveLog.TabIndex = 10;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // labelQualityName
            // 
            this.labelQualityName.AutoSize = true;
            this.labelQualityName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelQualityName.Location = new System.Drawing.Point(10, 124);
            this.labelQualityName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQualityName.Name = "labelQualityName";
            this.labelQualityName.Size = new System.Drawing.Size(375, 59);
            this.labelQualityName.TabIndex = 12;
            this.labelQualityName.Text = "*will NOT use salt/pepper";
            this.labelQualityName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.buttonHashGradualHashing, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonClearListBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveLog, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonClipboard, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelQualityName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxShowInfo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.hashSelector, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLog, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxHash, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(350, 500);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1164, 603);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClipboard.Location = new System.Drawing.Point(776, 482);
            this.buttonClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(378, 111);
            this.buttonClipboard.TabIndex = 11;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // checkBoxShowInfo
            // 
            this.checkBoxShowInfo.AutoSize = true;
            this.checkBoxShowInfo.Checked = true;
            this.checkBoxShowInfo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowInfo.Location = new System.Drawing.Point(775, 127);
            this.checkBoxShowInfo.Name = "checkBoxShowInfo";
            this.checkBoxShowInfo.Size = new System.Drawing.Size(380, 53);
            this.checkBoxShowInfo.TabIndex = 13;
            this.checkBoxShowInfo.Text = "Show Info";
            this.checkBoxShowInfo.UseVisualStyleBackColor = true;
            // 
            // hashSelector
            // 
            this.hashSelector.AllowDrop = true;
            this.hashSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.hashSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashSelector.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512",
            "RipeMD-160",
            "CRC32"});
            this.hashSelector.Location = new System.Drawing.Point(776, 10);
            this.hashSelector.Margin = new System.Windows.Forms.Padding(4);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(378, 46);
            this.hashSelector.TabIndex = 8;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // FormGradual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(500, 650);
            this.Name = "FormGradual";
            this.Text = "Gradual_Hashing";
            this.Load += new System.EventHandler(this.FormGradual_Load);
            this.SizeChanged += new System.EventHandler(this.FormGradual_SizeChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonHashGradualHashing;
        private System.Windows.Forms.TextBox textBoxHash;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Label labelQualityName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.CheckBox checkBoxShowInfo;
        private System.Windows.Forms.ComboBox hashSelector;
    }
}
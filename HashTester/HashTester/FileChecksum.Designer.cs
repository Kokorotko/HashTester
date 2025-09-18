namespace HashTester
{
    partial class FileChecksum
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
            this.textBoxHash = new System.Windows.Forms.TextBox();
            this.buttonChecksum = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.groupBoxChecksum = new System.Windows.Forms.GroupBox();
            this.checkBoxCRC32 = new System.Windows.Forms.CheckBox();
            this.checkBoxRIPEMD160 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA512 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA256 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA1 = new System.Windows.Forms.CheckBox();
            this.checkBoxMD5 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonCopyMD5 = new System.Windows.Forms.Button();
            this.labelCRC32 = new System.Windows.Forms.Label();
            this.labelRipeMD160 = new System.Windows.Forms.Label();
            this.labelSHA512 = new System.Windows.Forms.Label();
            this.labelSHA256 = new System.Windows.Forms.Label();
            this.labelSHA1 = new System.Windows.Forms.Label();
            this.labelMD5 = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBoxChecksum.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxHash
            // 
            this.textBoxHash.Location = new System.Drawing.Point(16, 15);
            this.textBoxHash.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHash.Name = "textBoxHash";
            this.textBoxHash.Size = new System.Drawing.Size(693, 22);
            this.textBoxHash.TabIndex = 0;
            // 
            // buttonChecksum
            // 
            this.buttonChecksum.Location = new System.Drawing.Point(457, 47);
            this.buttonChecksum.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChecksum.Name = "buttonChecksum";
            this.buttonChecksum.Size = new System.Drawing.Size(253, 28);
            this.buttonChecksum.TabIndex = 1;
            this.buttonChecksum.Text = "Checksum check";
            this.buttonChecksum.UseVisualStyleBackColor = true;
            this.buttonChecksum.Click += new System.EventHandler(this.buttonChecksum_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(16, 47);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(253, 28);
            this.buttonFile.TabIndex = 2;
            this.buttonFile.Text = "Select File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // groupBoxChecksum
            // 
            this.groupBoxChecksum.Controls.Add(this.checkBoxCRC32);
            this.groupBoxChecksum.Controls.Add(this.checkBoxRIPEMD160);
            this.groupBoxChecksum.Controls.Add(this.checkBoxSHA512);
            this.groupBoxChecksum.Controls.Add(this.checkBoxSHA256);
            this.groupBoxChecksum.Controls.Add(this.checkBoxSHA1);
            this.groupBoxChecksum.Controls.Add(this.checkBoxMD5);
            this.groupBoxChecksum.Controls.Add(this.button5);
            this.groupBoxChecksum.Controls.Add(this.button4);
            this.groupBoxChecksum.Controls.Add(this.button3);
            this.groupBoxChecksum.Controls.Add(this.button2);
            this.groupBoxChecksum.Controls.Add(this.button1);
            this.groupBoxChecksum.Controls.Add(this.buttonCopyMD5);
            this.groupBoxChecksum.Controls.Add(this.labelCRC32);
            this.groupBoxChecksum.Controls.Add(this.labelRipeMD160);
            this.groupBoxChecksum.Controls.Add(this.labelSHA512);
            this.groupBoxChecksum.Controls.Add(this.labelSHA256);
            this.groupBoxChecksum.Controls.Add(this.labelSHA1);
            this.groupBoxChecksum.Controls.Add(this.labelMD5);
            this.groupBoxChecksum.Location = new System.Drawing.Point(17, 128);
            this.groupBoxChecksum.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxChecksum.Name = "groupBoxChecksum";
            this.groupBoxChecksum.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxChecksum.Size = new System.Drawing.Size(701, 327);
            this.groupBoxChecksum.TabIndex = 3;
            this.groupBoxChecksum.TabStop = false;
            this.groupBoxChecksum.Text = "Checksum";
            // 
            // checkBoxCRC32
            // 
            this.checkBoxCRC32.AutoSize = true;
            this.checkBoxCRC32.Location = new System.Drawing.Point(8, 299);
            this.checkBoxCRC32.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCRC32.Name = "checkBoxCRC32";
            this.checkBoxCRC32.Size = new System.Drawing.Size(18, 17);
            this.checkBoxCRC32.TabIndex = 18;
            this.checkBoxCRC32.UseVisualStyleBackColor = true;
            // 
            // checkBoxRIPEMD160
            // 
            this.checkBoxRIPEMD160.AutoSize = true;
            this.checkBoxRIPEMD160.Location = new System.Drawing.Point(8, 268);
            this.checkBoxRIPEMD160.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRIPEMD160.Name = "checkBoxRIPEMD160";
            this.checkBoxRIPEMD160.Size = new System.Drawing.Size(18, 17);
            this.checkBoxRIPEMD160.TabIndex = 17;
            this.checkBoxRIPEMD160.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA512
            // 
            this.checkBoxSHA512.AutoSize = true;
            this.checkBoxSHA512.Location = new System.Drawing.Point(8, 170);
            this.checkBoxSHA512.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSHA512.Name = "checkBoxSHA512";
            this.checkBoxSHA512.Size = new System.Drawing.Size(18, 17);
            this.checkBoxSHA512.TabIndex = 16;
            this.checkBoxSHA512.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA256
            // 
            this.checkBoxSHA256.AutoSize = true;
            this.checkBoxSHA256.Location = new System.Drawing.Point(8, 103);
            this.checkBoxSHA256.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSHA256.Name = "checkBoxSHA256";
            this.checkBoxSHA256.Size = new System.Drawing.Size(18, 17);
            this.checkBoxSHA256.TabIndex = 15;
            this.checkBoxSHA256.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA1
            // 
            this.checkBoxSHA1.AutoSize = true;
            this.checkBoxSHA1.Location = new System.Drawing.Point(8, 69);
            this.checkBoxSHA1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSHA1.Name = "checkBoxSHA1";
            this.checkBoxSHA1.Size = new System.Drawing.Size(18, 17);
            this.checkBoxSHA1.TabIndex = 14;
            this.checkBoxSHA1.UseVisualStyleBackColor = true;
            // 
            // checkBoxMD5
            // 
            this.checkBoxMD5.AutoSize = true;
            this.checkBoxMD5.Location = new System.Drawing.Point(8, 34);
            this.checkBoxMD5.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMD5.Name = "checkBoxMD5";
            this.checkBoxMD5.Size = new System.Drawing.Size(18, 17);
            this.checkBoxMD5.TabIndex = 13;
            this.checkBoxMD5.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(485, 293);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(208, 28);
            this.button5.TabIndex = 12;
            this.button5.Text = "Copy CRC32";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(485, 262);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(208, 28);
            this.button4.TabIndex = 11;
            this.button4.Text = "Copy RipeMD-160";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(485, 158);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(208, 28);
            this.button3.TabIndex = 10;
            this.button3.Text = "Copy SHA512";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(485, 92);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(208, 28);
            this.button2.TabIndex = 9;
            this.button2.Text = "Copy SHA256";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 57);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Copy SHA1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCopyMD5
            // 
            this.buttonCopyMD5.Location = new System.Drawing.Point(485, 22);
            this.buttonCopyMD5.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCopyMD5.Name = "buttonCopyMD5";
            this.buttonCopyMD5.Size = new System.Drawing.Size(208, 28);
            this.buttonCopyMD5.TabIndex = 7;
            this.buttonCopyMD5.Text = "Copy MD5";
            this.buttonCopyMD5.UseVisualStyleBackColor = true;
            this.buttonCopyMD5.Click += new System.EventHandler(this.buttonCopyMD5_Click);
            // 
            // labelCRC32
            // 
            this.labelCRC32.AutoSize = true;
            this.labelCRC32.Location = new System.Drawing.Point(36, 299);
            this.labelCRC32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCRC32.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelCRC32.Name = "labelCRC32";
            this.labelCRC32.Size = new System.Drawing.Size(55, 16);
            this.labelCRC32.TabIndex = 5;
            this.labelCRC32.Text = "CRC32: ";
            // 
            // labelRipeMD160
            // 
            this.labelRipeMD160.AutoSize = true;
            this.labelRipeMD160.Location = new System.Drawing.Point(36, 268);
            this.labelRipeMD160.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRipeMD160.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelRipeMD160.Name = "labelRipeMD160";
            this.labelRipeMD160.Size = new System.Drawing.Size(88, 16);
            this.labelRipeMD160.TabIndex = 4;
            this.labelRipeMD160.Text = "RipeMD-160: ";
            // 
            // labelSHA512
            // 
            this.labelSHA512.AutoSize = true;
            this.labelSHA512.Location = new System.Drawing.Point(36, 170);
            this.labelSHA512.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSHA512.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelSHA512.Name = "labelSHA512";
            this.labelSHA512.Size = new System.Drawing.Size(62, 16);
            this.labelSHA512.TabIndex = 3;
            this.labelSHA512.Text = "SHA512: ";
            // 
            // labelSHA256
            // 
            this.labelSHA256.AutoSize = true;
            this.labelSHA256.Location = new System.Drawing.Point(36, 105);
            this.labelSHA256.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSHA256.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelSHA256.Name = "labelSHA256";
            this.labelSHA256.Size = new System.Drawing.Size(62, 16);
            this.labelSHA256.TabIndex = 2;
            this.labelSHA256.Text = "SHA256: ";
            // 
            // labelSHA1
            // 
            this.labelSHA1.AutoSize = true;
            this.labelSHA1.Location = new System.Drawing.Point(36, 69);
            this.labelSHA1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSHA1.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelSHA1.Name = "labelSHA1";
            this.labelSHA1.Size = new System.Drawing.Size(48, 16);
            this.labelSHA1.TabIndex = 1;
            this.labelSHA1.Text = "SHA1: ";
            // 
            // labelMD5
            // 
            this.labelMD5.AutoSize = true;
            this.labelMD5.Location = new System.Drawing.Point(36, 34);
            this.labelMD5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMD5.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelMD5.Name = "labelMD5";
            this.labelMD5.Size = new System.Drawing.Size(41, 16);
            this.labelMD5.TabIndex = 0;
            this.labelMD5.Text = "MD5: ";
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Location = new System.Drawing.Point(21, 79);
            this.labelLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocation.MaximumSize = new System.Drawing.Size(700, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(85, 32);
            this.labelLocation.TabIndex = 4;
            this.labelLocation.Text = "File location: \r\n\r\n";
            this.labelLocation.TextChanged += new System.EventHandler(this.labelLocation_TextChanged);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(457, 603);
            this.buttonClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(262, 28);
            this.buttonClipboard.TabIndex = 20;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(221, 603);
            this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(228, 28);
            this.buttonSaveLog.TabIndex = 19;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(16, 603);
            this.buttonClearListBox.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(197, 28);
            this.buttonClearListBox.TabIndex = 18;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.ItemHeight = 16;
            this.listBoxLog.Location = new System.Drawing.Point(17, 463);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(701, 132);
            this.listBoxLog.TabIndex = 17;
            // 
            // FileChecksum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 648);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.groupBoxChecksum);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.buttonChecksum);
            this.Controls.Add(this.textBoxHash);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileChecksum";
            this.Text = "File Checksum";
            this.Load += new System.EventHandler(this.File_checksum_Load);
            this.groupBoxChecksum.ResumeLayout(false);
            this.groupBoxChecksum.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHash;
        private System.Windows.Forms.Button buttonChecksum;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.GroupBox groupBoxChecksum;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonCopyMD5;
        private System.Windows.Forms.Label labelCRC32;
        private System.Windows.Forms.Label labelRipeMD160;
        private System.Windows.Forms.Label labelSHA512;
        private System.Windows.Forms.Label labelSHA256;
        private System.Windows.Forms.Label labelSHA1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.CheckBox checkBoxCRC32;
        private System.Windows.Forms.CheckBox checkBoxRIPEMD160;
        private System.Windows.Forms.CheckBox checkBoxSHA512;
        private System.Windows.Forms.CheckBox checkBoxSHA256;
        private System.Windows.Forms.CheckBox checkBoxSHA1;
        private System.Windows.Forms.CheckBox checkBoxMD5;
        private System.Windows.Forms.Label labelMD5;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.ListBox listBoxLog;
    }
}
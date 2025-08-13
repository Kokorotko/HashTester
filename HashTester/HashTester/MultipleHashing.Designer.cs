namespace HashTester
{
    partial class MultipleHashing
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
            this.buttonTXTInput = new System.Windows.Forms.Button();
            this.buttonHashSimpleText = new System.Windows.Forms.Button();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.textHashSimple = new System.Windows.Forms.TextBox();
            this.checkBoxMD5 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA1 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA256 = new System.Windows.Forms.CheckBox();
            this.checkBoxSHA512 = new System.Windows.Forms.CheckBox();
            this.checkBoxRipeMD160 = new System.Windows.Forms.CheckBox();
            this.checkBoxCRC32 = new System.Windows.Forms.CheckBox();
            this.buttonGoBack = new System.Windows.Forms.Button();
            this.checkBoxShowAlgorithm = new System.Windows.Forms.CheckBox();
            this.labelInfo = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTXTInput
            // 
            this.buttonTXTInput.Location = new System.Drawing.Point(92, 78);
            this.buttonTXTInput.Name = "buttonTXTInput";
            this.buttonTXTInput.Size = new System.Drawing.Size(75, 23);
            this.buttonTXTInput.TabIndex = 7;
            this.buttonTXTInput.Text = "TXTInput";
            this.buttonTXTInput.UseVisualStyleBackColor = true;
            this.buttonTXTInput.Click += new System.EventHandler(this.TXTInput_Click);
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(11, 78);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(75, 23);
            this.buttonHashSimpleText.TabIndex = 6;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(208, 308);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(190, 23);
            this.buttonClearListBox.TabIndex = 14;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.Location = new System.Drawing.Point(208, 77);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(600, 225);
            this.listBoxLog.TabIndex = 13;
            // 
            // textHashSimple
            // 
            this.textHashSimple.Location = new System.Drawing.Point(11, 12);
            this.textHashSimple.Multiline = true;
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(797, 59);
            this.textHashSimple.TabIndex = 12;
            this.textHashSimple.Text = "test\r\ntest2";
            // 
            // checkBoxMD5
            // 
            this.checkBoxMD5.AutoSize = true;
            this.checkBoxMD5.Location = new System.Drawing.Point(12, 108);
            this.checkBoxMD5.Name = "checkBoxMD5";
            this.checkBoxMD5.Size = new System.Drawing.Size(49, 17);
            this.checkBoxMD5.TabIndex = 15;
            this.checkBoxMD5.Text = "MD5";
            this.checkBoxMD5.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA1
            // 
            this.checkBoxSHA1.AutoSize = true;
            this.checkBoxSHA1.Location = new System.Drawing.Point(11, 131);
            this.checkBoxSHA1.Name = "checkBoxSHA1";
            this.checkBoxSHA1.Size = new System.Drawing.Size(54, 17);
            this.checkBoxSHA1.TabIndex = 16;
            this.checkBoxSHA1.Text = "SHA1";
            this.checkBoxSHA1.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA256
            // 
            this.checkBoxSHA256.AutoSize = true;
            this.checkBoxSHA256.Location = new System.Drawing.Point(11, 154);
            this.checkBoxSHA256.Name = "checkBoxSHA256";
            this.checkBoxSHA256.Size = new System.Drawing.Size(66, 17);
            this.checkBoxSHA256.TabIndex = 17;
            this.checkBoxSHA256.Text = "SHA256";
            this.checkBoxSHA256.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA512
            // 
            this.checkBoxSHA512.AutoSize = true;
            this.checkBoxSHA512.Location = new System.Drawing.Point(11, 177);
            this.checkBoxSHA512.Name = "checkBoxSHA512";
            this.checkBoxSHA512.Size = new System.Drawing.Size(66, 17);
            this.checkBoxSHA512.TabIndex = 18;
            this.checkBoxSHA512.Text = "SHA512";
            this.checkBoxSHA512.UseVisualStyleBackColor = true;
            // 
            // checkBoxRipeMD160
            // 
            this.checkBoxRipeMD160.AutoSize = true;
            this.checkBoxRipeMD160.Location = new System.Drawing.Point(11, 200);
            this.checkBoxRipeMD160.Name = "checkBoxRipeMD160";
            this.checkBoxRipeMD160.Size = new System.Drawing.Size(86, 17);
            this.checkBoxRipeMD160.TabIndex = 19;
            this.checkBoxRipeMD160.Text = "RipeMD-160";
            this.checkBoxRipeMD160.UseVisualStyleBackColor = true;
            // 
            // checkBoxCRC32
            // 
            this.checkBoxCRC32.AutoSize = true;
            this.checkBoxCRC32.Location = new System.Drawing.Point(11, 223);
            this.checkBoxCRC32.Name = "checkBoxCRC32";
            this.checkBoxCRC32.Size = new System.Drawing.Size(60, 17);
            this.checkBoxCRC32.TabIndex = 20;
            this.checkBoxCRC32.Text = "CRC32";
            this.checkBoxCRC32.UseVisualStyleBackColor = true;
            // 
            // buttonGoBack
            // 
            this.buttonGoBack.Location = new System.Drawing.Point(11, 308);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(191, 23);
            this.buttonGoBack.TabIndex = 21;
            this.buttonGoBack.Text = "Go Back";
            this.buttonGoBack.UseVisualStyleBackColor = true;
            this.buttonGoBack.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxShowAlgorithm
            // 
            this.checkBoxShowAlgorithm.AutoSize = true;
            this.checkBoxShowAlgorithm.Checked = true;
            this.checkBoxShowAlgorithm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowAlgorithm.Location = new System.Drawing.Point(12, 246);
            this.checkBoxShowAlgorithm.Name = "checkBoxShowAlgorithm";
            this.checkBoxShowAlgorithm.Size = new System.Drawing.Size(103, 17);
            this.checkBoxShowAlgorithm.TabIndex = 22;
            this.checkBoxShowAlgorithm.Text = "Show Algorithm*";
            this.checkBoxShowAlgorithm.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(9, 266);
            this.labelInfo.MaximumSize = new System.Drawing.Size(200, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(179, 26);
            this.labelInfo.TabIndex = 23;
            this.labelInfo.Text = "*will overwrite the \"Include hashing algorithm\" in the output style settings";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(413, 308);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(190, 23);
            this.buttonSaveLog.TabIndex = 24;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(618, 308);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(190, 23);
            this.buttonClipboard.TabIndex = 25;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // MultipleHashing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 344);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.checkBoxShowAlgorithm);
            this.Controls.Add(this.buttonGoBack);
            this.Controls.Add(this.checkBoxCRC32);
            this.Controls.Add(this.checkBoxRipeMD160);
            this.Controls.Add(this.checkBoxSHA512);
            this.Controls.Add(this.checkBoxSHA256);
            this.Controls.Add(this.checkBoxSHA1);
            this.Controls.Add(this.checkBoxMD5);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.buttonTXTInput);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Name = "MultipleHashing";
            this.Text = "MultipleHashing";
            this.Load += new System.EventHandler(this.MultipleHashing_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonTXTInput;
        private System.Windows.Forms.Button buttonHashSimpleText;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.TextBox textHashSimple;
        private System.Windows.Forms.CheckBox checkBoxMD5;
        private System.Windows.Forms.CheckBox checkBoxSHA1;
        private System.Windows.Forms.CheckBox checkBoxSHA256;
        private System.Windows.Forms.CheckBox checkBoxSHA512;
        private System.Windows.Forms.CheckBox checkBoxRipeMD160;
        private System.Windows.Forms.CheckBox checkBoxCRC32;
        private System.Windows.Forms.Button buttonGoBack;
        private System.Windows.Forms.CheckBox checkBoxShowAlgorithm;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonClipboard;
    }
}
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTXTInput
            // 
            this.buttonTXTInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonTXTInput.Location = new System.Drawing.Point(94, 149);
            this.buttonTXTInput.Name = "buttonTXTInput";
            this.buttonTXTInput.Size = new System.Drawing.Size(85, 30);
            this.buttonTXTInput.TabIndex = 7;
            this.buttonTXTInput.Text = "TXTInput";
            this.buttonTXTInput.UseVisualStyleBackColor = true;
            this.buttonTXTInput.Click += new System.EventHandler(this.TXTInput_Click);
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHashSimpleText.Location = new System.Drawing.Point(3, 149);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(85, 30);
            this.buttonHashSimpleText.TabIndex = 6;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClearListBox.Location = new System.Drawing.Point(185, 473);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(177, 74);
            this.buttonClearListBox.TabIndex = 14;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // listBoxLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxLog, 3);
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.Location = new System.Drawing.Point(185, 149);
            this.listBoxLog.Name = "listBoxLog";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxLog, 9);
            this.listBoxLog.Size = new System.Drawing.Size(546, 318);
            this.listBoxLog.TabIndex = 13;
            // 
            // textHashSimple
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textHashSimple, 5);
            this.textHashSimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHashSimple.Location = new System.Drawing.Point(3, 3);
            this.textHashSimple.Multiline = true;
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(728, 140);
            this.textHashSimple.TabIndex = 12;
            this.textHashSimple.Text = "test\r\ntest2";
            // 
            // checkBoxMD5
            // 
            this.checkBoxMD5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxMD5, 2);
            this.checkBoxMD5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxMD5.Location = new System.Drawing.Point(3, 185);
            this.checkBoxMD5.Name = "checkBoxMD5";
            this.checkBoxMD5.Size = new System.Drawing.Size(176, 30);
            this.checkBoxMD5.TabIndex = 15;
            this.checkBoxMD5.Text = "MD5";
            this.checkBoxMD5.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA1
            // 
            this.checkBoxSHA1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxSHA1, 2);
            this.checkBoxSHA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSHA1.Location = new System.Drawing.Point(3, 221);
            this.checkBoxSHA1.Name = "checkBoxSHA1";
            this.checkBoxSHA1.Size = new System.Drawing.Size(176, 30);
            this.checkBoxSHA1.TabIndex = 16;
            this.checkBoxSHA1.Text = "SHA1";
            this.checkBoxSHA1.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA256
            // 
            this.checkBoxSHA256.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxSHA256, 2);
            this.checkBoxSHA256.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSHA256.Location = new System.Drawing.Point(3, 257);
            this.checkBoxSHA256.Name = "checkBoxSHA256";
            this.checkBoxSHA256.Size = new System.Drawing.Size(176, 30);
            this.checkBoxSHA256.TabIndex = 17;
            this.checkBoxSHA256.Text = "SHA256";
            this.checkBoxSHA256.UseVisualStyleBackColor = true;
            // 
            // checkBoxSHA512
            // 
            this.checkBoxSHA512.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxSHA512, 2);
            this.checkBoxSHA512.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSHA512.Location = new System.Drawing.Point(3, 293);
            this.checkBoxSHA512.Name = "checkBoxSHA512";
            this.checkBoxSHA512.Size = new System.Drawing.Size(176, 30);
            this.checkBoxSHA512.TabIndex = 18;
            this.checkBoxSHA512.Text = "SHA512";
            this.checkBoxSHA512.UseVisualStyleBackColor = true;
            // 
            // checkBoxRipeMD160
            // 
            this.checkBoxRipeMD160.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxRipeMD160, 2);
            this.checkBoxRipeMD160.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxRipeMD160.Location = new System.Drawing.Point(3, 329);
            this.checkBoxRipeMD160.Name = "checkBoxRipeMD160";
            this.checkBoxRipeMD160.Size = new System.Drawing.Size(176, 30);
            this.checkBoxRipeMD160.TabIndex = 19;
            this.checkBoxRipeMD160.Text = "RipeMD-160";
            this.checkBoxRipeMD160.UseVisualStyleBackColor = true;
            // 
            // checkBoxCRC32
            // 
            this.checkBoxCRC32.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxCRC32, 2);
            this.checkBoxCRC32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCRC32.Location = new System.Drawing.Point(3, 365);
            this.checkBoxCRC32.Name = "checkBoxCRC32";
            this.checkBoxCRC32.Size = new System.Drawing.Size(176, 30);
            this.checkBoxCRC32.TabIndex = 20;
            this.checkBoxCRC32.Text = "CRC32";
            this.checkBoxCRC32.UseVisualStyleBackColor = true;
            // 
            // buttonGoBack
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonGoBack, 2);
            this.buttonGoBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonGoBack.Location = new System.Drawing.Point(3, 473);
            this.buttonGoBack.Name = "buttonGoBack";
            this.buttonGoBack.Size = new System.Drawing.Size(176, 74);
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
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxShowAlgorithm, 2);
            this.checkBoxShowAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxShowAlgorithm.Location = new System.Drawing.Point(3, 401);
            this.checkBoxShowAlgorithm.Name = "checkBoxShowAlgorithm";
            this.checkBoxShowAlgorithm.Size = new System.Drawing.Size(176, 30);
            this.checkBoxShowAlgorithm.TabIndex = 22;
            this.checkBoxShowAlgorithm.Text = "Show Algorithm*";
            this.checkBoxShowAlgorithm.UseVisualStyleBackColor = true;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelInfo, 2);
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Location = new System.Drawing.Point(3, 434);
            this.labelInfo.MaximumSize = new System.Drawing.Size(200, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(176, 36);
            this.labelInfo.TabIndex = 23;
            this.labelInfo.Text = "*will overwrite the \"Include hashing algorithm\" in the output style settings";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSaveLog.Location = new System.Drawing.Point(368, 473);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(177, 74);
            this.buttonSaveLog.TabIndex = 24;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClipboard.Location = new System.Drawing.Point(551, 473);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(180, 74);
            this.buttonClipboard.TabIndex = 25;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxCRC32, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelInfo, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxRipeMD160, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxShowAlgorithm, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.textHashSimple, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxSHA512, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonHashSimpleText, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxSHA256, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonTXTInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxSHA1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLog, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxMD5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonGoBack, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.buttonClearListBox, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveLog, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.buttonClipboard, 4, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(734, 550);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // MultipleHashing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(750, 589);
            this.Name = "MultipleHashing";
            this.Text = "MultipleHashing";
            this.Load += new System.EventHandler(this.MultipleHashing_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
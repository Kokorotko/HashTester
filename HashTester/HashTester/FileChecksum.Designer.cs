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
            this.tableLPMain = new System.Windows.Forms.TableLayoutPanel();
            this.labelMD5Output = new System.Windows.Forms.Label();
            this.labelSHA1Output = new System.Windows.Forms.Label();
            this.labelSHA256Output = new System.Windows.Forms.Label();
            this.labelSHA512Output = new System.Windows.Forms.Label();
            this.labelRipeMDOutput = new System.Windows.Forms.Label();
            this.labelCRC32Output = new System.Windows.Forms.Label();
            this.labelHash = new System.Windows.Forms.Label();
            this.buttonRunChecksum = new System.Windows.Forms.Button();
            this.labelCheckSum = new System.Windows.Forms.Label();
            this.labelFileLocation = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxMultiThread = new System.Windows.Forms.CheckBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLPMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxHash
            // 
            this.textBoxHash.AllowDrop = true;
            this.tableLPMain.SetColumnSpan(this.textBoxHash, 4);
            this.textBoxHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHash.Location = new System.Drawing.Point(4, 113);
            this.textBoxHash.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHash.Name = "textBoxHash";
            this.textBoxHash.Size = new System.Drawing.Size(1095, 30);
            this.textBoxHash.TabIndex = 0;
            this.textBoxHash.TextChanged += new System.EventHandler(this.textBoxHash_TextChanged);
            // 
            // buttonChecksum
            // 
            this.buttonChecksum.AllowDrop = true;
            this.buttonChecksum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonChecksum.Location = new System.Drawing.Point(941, 162);
            this.buttonChecksum.Margin = new System.Windows.Forms.Padding(4);
            this.buttonChecksum.Name = "buttonChecksum";
            this.buttonChecksum.Size = new System.Drawing.Size(158, 48);
            this.buttonChecksum.TabIndex = 1;
            this.buttonChecksum.Text = "Check file with hash";
            this.buttonChecksum.UseVisualStyleBackColor = true;
            this.buttonChecksum.Click += new System.EventHandler(this.buttonChecksum_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.AllowDrop = true;
            this.tableLPMain.SetColumnSpan(this.buttonFile, 2);
            this.buttonFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonFile.Location = new System.Drawing.Point(4, 33);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(157, 55);
            this.buttonFile.TabIndex = 2;
            this.buttonFile.Text = "Select File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // checkBoxCRC32
            // 
            this.checkBoxCRC32.AllowDrop = true;
            this.checkBoxCRC32.AutoSize = true;
            this.checkBoxCRC32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCRC32.Location = new System.Drawing.Point(4, 401);
            this.checkBoxCRC32.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxCRC32.Name = "checkBoxCRC32";
            this.checkBoxCRC32.Size = new System.Drawing.Size(26, 23);
            this.checkBoxCRC32.TabIndex = 18;
            this.checkBoxCRC32.UseVisualStyleBackColor = true;
            this.checkBoxCRC32.CheckedChanged += new System.EventHandler(this.checkBoxCRC32_CheckedChanged);
            // 
            // checkBoxRIPEMD160
            // 
            this.checkBoxRIPEMD160.AllowDrop = true;
            this.checkBoxRIPEMD160.AutoSize = true;
            this.checkBoxRIPEMD160.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxRIPEMD160.Location = new System.Drawing.Point(4, 370);
            this.checkBoxRIPEMD160.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRIPEMD160.Name = "checkBoxRIPEMD160";
            this.checkBoxRIPEMD160.Size = new System.Drawing.Size(26, 23);
            this.checkBoxRIPEMD160.TabIndex = 17;
            this.checkBoxRIPEMD160.UseVisualStyleBackColor = true;
            this.checkBoxRIPEMD160.CheckedChanged += new System.EventHandler(this.checkBoxRIPEMD160_CheckedChanged);
            // 
            // checkBoxSHA512
            // 
            this.checkBoxSHA512.AllowDrop = true;
            this.checkBoxSHA512.AutoSize = true;
            this.checkBoxSHA512.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSHA512.Location = new System.Drawing.Point(4, 339);
            this.checkBoxSHA512.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSHA512.Name = "checkBoxSHA512";
            this.checkBoxSHA512.Size = new System.Drawing.Size(26, 23);
            this.checkBoxSHA512.TabIndex = 16;
            this.checkBoxSHA512.UseVisualStyleBackColor = true;
            this.checkBoxSHA512.CheckedChanged += new System.EventHandler(this.checkBoxSHA512_CheckedChanged);
            // 
            // checkBoxSHA256
            // 
            this.checkBoxSHA256.AllowDrop = true;
            this.checkBoxSHA256.AutoSize = true;
            this.checkBoxSHA256.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSHA256.Location = new System.Drawing.Point(4, 308);
            this.checkBoxSHA256.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSHA256.Name = "checkBoxSHA256";
            this.checkBoxSHA256.Size = new System.Drawing.Size(26, 23);
            this.checkBoxSHA256.TabIndex = 15;
            this.checkBoxSHA256.UseVisualStyleBackColor = true;
            this.checkBoxSHA256.CheckedChanged += new System.EventHandler(this.checkBoxSHA256_CheckedChanged);
            // 
            // checkBoxSHA1
            // 
            this.checkBoxSHA1.AllowDrop = true;
            this.checkBoxSHA1.AutoSize = true;
            this.checkBoxSHA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSHA1.Location = new System.Drawing.Point(4, 277);
            this.checkBoxSHA1.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxSHA1.Name = "checkBoxSHA1";
            this.checkBoxSHA1.Size = new System.Drawing.Size(26, 23);
            this.checkBoxSHA1.TabIndex = 14;
            this.checkBoxSHA1.UseVisualStyleBackColor = true;
            this.checkBoxSHA1.CheckedChanged += new System.EventHandler(this.checkBoxSHA1_CheckedChanged);
            // 
            // checkBoxMD5
            // 
            this.checkBoxMD5.AllowDrop = true;
            this.checkBoxMD5.AutoSize = true;
            this.checkBoxMD5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxMD5.Location = new System.Drawing.Point(4, 246);
            this.checkBoxMD5.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxMD5.Name = "checkBoxMD5";
            this.checkBoxMD5.Size = new System.Drawing.Size(26, 23);
            this.checkBoxMD5.TabIndex = 13;
            this.checkBoxMD5.UseVisualStyleBackColor = true;
            this.checkBoxMD5.CheckedChanged += new System.EventHandler(this.checkBoxMD5_CheckedChanged);
            // 
            // button5
            // 
            this.button5.AllowDrop = true;
            this.button5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button5.Location = new System.Drawing.Point(941, 401);
            this.button5.Margin = new System.Windows.Forms.Padding(4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(158, 23);
            this.button5.TabIndex = 12;
            this.button5.Text = "Copy CRC32";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.AllowDrop = true;
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(941, 370);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(158, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Copy RipeMD-160";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.AllowDrop = true;
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(941, 339);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(158, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Copy SHA512";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.AllowDrop = true;
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(941, 308);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Copy SHA256";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.AllowDrop = true;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(941, 277);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Copy SHA1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCopyMD5
            // 
            this.buttonCopyMD5.AllowDrop = true;
            this.buttonCopyMD5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCopyMD5.Location = new System.Drawing.Point(941, 246);
            this.buttonCopyMD5.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCopyMD5.Name = "buttonCopyMD5";
            this.buttonCopyMD5.Size = new System.Drawing.Size(158, 23);
            this.buttonCopyMD5.TabIndex = 7;
            this.buttonCopyMD5.Text = "Copy MD5";
            this.buttonCopyMD5.UseVisualStyleBackColor = true;
            this.buttonCopyMD5.Click += new System.EventHandler(this.buttonCopyMD5_Click);
            // 
            // labelCRC32
            // 
            this.labelCRC32.AllowDrop = true;
            this.labelCRC32.AutoSize = true;
            this.labelCRC32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCRC32.Location = new System.Drawing.Point(38, 397);
            this.labelCRC32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCRC32.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelCRC32.Name = "labelCRC32";
            this.labelCRC32.Size = new System.Drawing.Size(123, 31);
            this.labelCRC32.TabIndex = 5;
            this.labelCRC32.Text = "CRC32: ";
            this.labelCRC32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCRC32.Click += new System.EventHandler(this.labelCRC32_Click);
            // 
            // labelRipeMD160
            // 
            this.labelRipeMD160.AllowDrop = true;
            this.labelRipeMD160.AutoSize = true;
            this.labelRipeMD160.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRipeMD160.Location = new System.Drawing.Point(38, 366);
            this.labelRipeMD160.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRipeMD160.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelRipeMD160.Name = "labelRipeMD160";
            this.labelRipeMD160.Size = new System.Drawing.Size(123, 31);
            this.labelRipeMD160.TabIndex = 4;
            this.labelRipeMD160.Text = "RipeMD-160: ";
            this.labelRipeMD160.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelRipeMD160.Click += new System.EventHandler(this.labelRipeMD160_Click);
            // 
            // labelSHA512
            // 
            this.labelSHA512.AllowDrop = true;
            this.labelSHA512.AutoSize = true;
            this.labelSHA512.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSHA512.Location = new System.Drawing.Point(38, 335);
            this.labelSHA512.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSHA512.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelSHA512.Name = "labelSHA512";
            this.labelSHA512.Size = new System.Drawing.Size(123, 31);
            this.labelSHA512.TabIndex = 3;
            this.labelSHA512.Text = "SHA512: ";
            this.labelSHA512.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSHA512.Click += new System.EventHandler(this.labelSHA512_Click);
            // 
            // labelSHA256
            // 
            this.labelSHA256.AllowDrop = true;
            this.labelSHA256.AutoSize = true;
            this.labelSHA256.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSHA256.Location = new System.Drawing.Point(38, 304);
            this.labelSHA256.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSHA256.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelSHA256.Name = "labelSHA256";
            this.labelSHA256.Size = new System.Drawing.Size(123, 31);
            this.labelSHA256.TabIndex = 2;
            this.labelSHA256.Text = "SHA256: ";
            this.labelSHA256.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSHA256.Click += new System.EventHandler(this.labelSHA256_Click);
            // 
            // labelSHA1
            // 
            this.labelSHA1.AllowDrop = true;
            this.labelSHA1.AutoSize = true;
            this.labelSHA1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSHA1.Location = new System.Drawing.Point(38, 273);
            this.labelSHA1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSHA1.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelSHA1.Name = "labelSHA1";
            this.labelSHA1.Size = new System.Drawing.Size(123, 31);
            this.labelSHA1.TabIndex = 1;
            this.labelSHA1.Text = "SHA1: ";
            this.labelSHA1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSHA1.Click += new System.EventHandler(this.labelSHA1_Click);
            // 
            // labelMD5
            // 
            this.labelMD5.AllowDrop = true;
            this.labelMD5.AutoSize = true;
            this.labelMD5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMD5.Location = new System.Drawing.Point(38, 242);
            this.labelMD5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMD5.MaximumSize = new System.Drawing.Size(433, 0);
            this.labelMD5.Name = "labelMD5";
            this.labelMD5.Size = new System.Drawing.Size(123, 31);
            this.labelMD5.TabIndex = 0;
            this.labelMD5.Text = "MD5: ";
            this.labelMD5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMD5.Click += new System.EventHandler(this.labelMD5_Click);
            // 
            // labelLocation
            // 
            this.labelLocation.AllowDrop = true;
            this.labelLocation.AutoSize = true;
            this.tableLPMain.SetColumnSpan(this.labelLocation, 2);
            this.labelLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLocation.Location = new System.Drawing.Point(4, 0);
            this.labelLocation.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLocation.MaximumSize = new System.Drawing.Size(700, 0);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(157, 29);
            this.labelLocation.TabIndex = 4;
            this.labelLocation.Text = "File location: \r\n\r\n";
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelLocation.TextChanged += new System.EventHandler(this.labelLocation_TextChanged);
            this.labelLocation.Click += new System.EventHandler(this.labelLocation_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.AllowDrop = true;
            this.buttonClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClipboard.Location = new System.Drawing.Point(0, 0);
            this.buttonClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(1103, 531);
            this.buttonClipboard.TabIndex = 20;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.AllowDrop = true;
            this.buttonSaveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveLog.Location = new System.Drawing.Point(0, 0);
            this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(1103, 531);
            this.buttonSaveLog.TabIndex = 19;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.AllowDrop = true;
            this.buttonClearListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearListBox.Location = new System.Drawing.Point(0, 0);
            this.buttonClearListBox.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(1103, 531);
            this.buttonClearListBox.TabIndex = 18;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // tableLPMain
            // 
            this.tableLPMain.AllowDrop = true;
            this.tableLPMain.ColumnCount = 4;
            this.tableLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.08376F));
            this.tableLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.88155F));
            this.tableLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.02857F));
            this.tableLPMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.00612F));
            this.tableLPMain.Controls.Add(this.checkBoxCRC32, 0, 11);
            this.tableLPMain.Controls.Add(this.button2, 3, 8);
            this.tableLPMain.Controls.Add(this.checkBoxRIPEMD160, 0, 10);
            this.tableLPMain.Controls.Add(this.checkBoxSHA512, 0, 9);
            this.tableLPMain.Controls.Add(this.checkBoxSHA256, 0, 8);
            this.tableLPMain.Controls.Add(this.labelCRC32, 1, 11);
            this.tableLPMain.Controls.Add(this.checkBoxSHA1, 0, 7);
            this.tableLPMain.Controls.Add(this.labelRipeMD160, 1, 10);
            this.tableLPMain.Controls.Add(this.checkBoxMD5, 0, 6);
            this.tableLPMain.Controls.Add(this.labelSHA1, 1, 7);
            this.tableLPMain.Controls.Add(this.labelSHA512, 1, 9);
            this.tableLPMain.Controls.Add(this.labelSHA256, 1, 8);
            this.tableLPMain.Controls.Add(this.labelMD5Output, 2, 6);
            this.tableLPMain.Controls.Add(this.labelSHA1Output, 2, 7);
            this.tableLPMain.Controls.Add(this.labelSHA256Output, 2, 8);
            this.tableLPMain.Controls.Add(this.labelSHA512Output, 2, 9);
            this.tableLPMain.Controls.Add(this.labelRipeMDOutput, 2, 10);
            this.tableLPMain.Controls.Add(this.labelCRC32Output, 2, 11);
            this.tableLPMain.Controls.Add(this.labelHash, 0, 2);
            this.tableLPMain.Controls.Add(this.textBoxHash, 0, 3);
            this.tableLPMain.Controls.Add(this.buttonRunChecksum, 0, 4);
            this.tableLPMain.Controls.Add(this.labelMD5, 1, 6);
            this.tableLPMain.Controls.Add(this.buttonCopyMD5, 3, 6);
            this.tableLPMain.Controls.Add(this.button1, 3, 7);
            this.tableLPMain.Controls.Add(this.button3, 3, 9);
            this.tableLPMain.Controls.Add(this.button4, 3, 10);
            this.tableLPMain.Controls.Add(this.button5, 3, 11);
            this.tableLPMain.Controls.Add(this.buttonChecksum, 3, 4);
            this.tableLPMain.Controls.Add(this.labelCheckSum, 0, 5);
            this.tableLPMain.Controls.Add(this.labelLocation, 0, 0);
            this.tableLPMain.Controls.Add(this.buttonFile, 0, 1);
            this.tableLPMain.Controls.Add(this.labelFileLocation, 2, 0);
            this.tableLPMain.Controls.Add(this.button6, 0, 12);
            this.tableLPMain.Controls.Add(this.label1, 1, 13);
            this.tableLPMain.Controls.Add(this.checkBoxMultiThread, 0, 13);
            this.tableLPMain.Controls.Add(this.buttonCancel, 3, 12);
            this.tableLPMain.Controls.Add(this.progressBar, 0, 14);
            this.tableLPMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLPMain.Location = new System.Drawing.Point(0, 0);
            this.tableLPMain.Margin = new System.Windows.Forms.Padding(10, 30, 10, 20);
            this.tableLPMain.Name = "tableLPMain";
            this.tableLPMain.RowCount = 15;
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.552968F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.00158F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.224303F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.314655F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.56855F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.373841F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929137F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929137F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929137F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929137F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929137F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.929137F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.470183F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.905414F));
            this.tableLPMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.013674F));
            this.tableLPMain.Size = new System.Drawing.Size(1103, 531);
            this.tableLPMain.TabIndex = 21;
            this.tableLPMain.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLPMain_Paint);
            // 
            // labelMD5Output
            // 
            this.labelMD5Output.AllowDrop = true;
            this.labelMD5Output.AutoSize = true;
            this.labelMD5Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMD5Output.Location = new System.Drawing.Point(168, 242);
            this.labelMD5Output.Name = "labelMD5Output";
            this.labelMD5Output.Size = new System.Drawing.Size(766, 31);
            this.labelMD5Output.TabIndex = 23;
            this.labelMD5Output.Text = "label1";
            this.labelMD5Output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelMD5Output.Click += new System.EventHandler(this.labelMD5Output_Click);
            // 
            // labelSHA1Output
            // 
            this.labelSHA1Output.AllowDrop = true;
            this.labelSHA1Output.AutoSize = true;
            this.labelSHA1Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSHA1Output.Location = new System.Drawing.Point(168, 273);
            this.labelSHA1Output.Name = "labelSHA1Output";
            this.labelSHA1Output.Size = new System.Drawing.Size(766, 31);
            this.labelSHA1Output.TabIndex = 24;
            this.labelSHA1Output.Text = "label1";
            this.labelSHA1Output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSHA1Output.Click += new System.EventHandler(this.labelSHA1Output_Click);
            // 
            // labelSHA256Output
            // 
            this.labelSHA256Output.AllowDrop = true;
            this.labelSHA256Output.AutoSize = true;
            this.labelSHA256Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSHA256Output.Location = new System.Drawing.Point(168, 304);
            this.labelSHA256Output.Name = "labelSHA256Output";
            this.labelSHA256Output.Size = new System.Drawing.Size(766, 31);
            this.labelSHA256Output.TabIndex = 25;
            this.labelSHA256Output.Text = "label1";
            this.labelSHA256Output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSHA256Output.Click += new System.EventHandler(this.labelSHA256Output_Click);
            // 
            // labelSHA512Output
            // 
            this.labelSHA512Output.AllowDrop = true;
            this.labelSHA512Output.AutoSize = true;
            this.labelSHA512Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSHA512Output.Location = new System.Drawing.Point(168, 335);
            this.labelSHA512Output.Name = "labelSHA512Output";
            this.labelSHA512Output.Size = new System.Drawing.Size(766, 31);
            this.labelSHA512Output.TabIndex = 26;
            this.labelSHA512Output.Text = "label1";
            this.labelSHA512Output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelSHA512Output.Click += new System.EventHandler(this.labelSHA512Output_Click);
            // 
            // labelRipeMDOutput
            // 
            this.labelRipeMDOutput.AllowDrop = true;
            this.labelRipeMDOutput.AutoSize = true;
            this.labelRipeMDOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRipeMDOutput.Location = new System.Drawing.Point(168, 366);
            this.labelRipeMDOutput.Name = "labelRipeMDOutput";
            this.labelRipeMDOutput.Size = new System.Drawing.Size(766, 31);
            this.labelRipeMDOutput.TabIndex = 27;
            this.labelRipeMDOutput.Text = "label1";
            this.labelRipeMDOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelRipeMDOutput.Click += new System.EventHandler(this.labelRipeMDOutput_Click);
            // 
            // labelCRC32Output
            // 
            this.labelCRC32Output.AllowDrop = true;
            this.labelCRC32Output.AutoSize = true;
            this.labelCRC32Output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCRC32Output.Location = new System.Drawing.Point(168, 397);
            this.labelCRC32Output.Name = "labelCRC32Output";
            this.labelCRC32Output.Size = new System.Drawing.Size(766, 31);
            this.labelCRC32Output.TabIndex = 28;
            this.labelCRC32Output.Text = "label1";
            this.labelCRC32Output.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelCRC32Output.Click += new System.EventHandler(this.labelCRC32Output_Click);
            // 
            // labelHash
            // 
            this.labelHash.AllowDrop = true;
            this.labelHash.AutoSize = true;
            this.tableLPMain.SetColumnSpan(this.labelHash, 2);
            this.labelHash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHash.Location = new System.Drawing.Point(3, 92);
            this.labelHash.Name = "labelHash";
            this.labelHash.Size = new System.Drawing.Size(159, 17);
            this.labelHash.TabIndex = 1;
            this.labelHash.Text = "Hash input:";
            this.labelHash.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelHash.Click += new System.EventHandler(this.labelHash_Click);
            // 
            // buttonRunChecksum
            // 
            this.buttonRunChecksum.AllowDrop = true;
            this.tableLPMain.SetColumnSpan(this.buttonRunChecksum, 2);
            this.buttonRunChecksum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRunChecksum.Location = new System.Drawing.Point(3, 161);
            this.buttonRunChecksum.Name = "buttonRunChecksum";
            this.buttonRunChecksum.Size = new System.Drawing.Size(159, 50);
            this.buttonRunChecksum.TabIndex = 22;
            this.buttonRunChecksum.Text = "Run Checksum";
            this.buttonRunChecksum.UseVisualStyleBackColor = true;
            this.buttonRunChecksum.Click += new System.EventHandler(this.buttonRunChecksum_Click);
            // 
            // labelCheckSum
            // 
            this.labelCheckSum.AllowDrop = true;
            this.labelCheckSum.AutoSize = true;
            this.tableLPMain.SetColumnSpan(this.labelCheckSum, 4);
            this.labelCheckSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCheckSum.Location = new System.Drawing.Point(3, 214);
            this.labelCheckSum.Name = "labelCheckSum";
            this.labelCheckSum.Size = new System.Drawing.Size(1097, 28);
            this.labelCheckSum.TabIndex = 29;
            this.labelCheckSum.Text = "Checksum:";
            this.labelCheckSum.Click += new System.EventHandler(this.labelCheckSum_Click);
            // 
            // labelFileLocation
            // 
            this.labelFileLocation.AutoSize = true;
            this.tableLPMain.SetColumnSpan(this.labelFileLocation, 2);
            this.labelFileLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFileLocation.Location = new System.Drawing.Point(168, 0);
            this.labelFileLocation.Name = "labelFileLocation";
            this.tableLPMain.SetRowSpan(this.labelFileLocation, 2);
            this.labelFileLocation.Size = new System.Drawing.Size(932, 92);
            this.labelFileLocation.TabIndex = 30;
            this.labelFileLocation.Text = "Label";
            this.labelFileLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button6
            // 
            this.tableLPMain.SetColumnSpan(this.button6, 2);
            this.button6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button6.Location = new System.Drawing.Point(3, 431);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 33);
            this.button6.TabIndex = 31;
            this.button6.Text = "Check All";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // progressBar
            // 
            this.tableLPMain.SetColumnSpan(this.progressBar, 4);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 496);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1097, 32);
            this.progressBar.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(37, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 26);
            this.label1.TabIndex = 33;
            this.label1.Text = "Use multi-threading";
            // 
            // checkBoxMultiThread
            // 
            this.checkBoxMultiThread.AutoSize = true;
            this.checkBoxMultiThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxMultiThread.Location = new System.Drawing.Point(3, 470);
            this.checkBoxMultiThread.Name = "checkBoxMultiThread";
            this.checkBoxMultiThread.Size = new System.Drawing.Size(28, 20);
            this.checkBoxMultiThread.TabIndex = 34;
            this.checkBoxMultiThread.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(940, 431);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(160, 33);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Cancel operation";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // FileChecksum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 531);
            this.Controls.Add(this.tableLPMain);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonClearListBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FileChecksum";
            this.Text = "File Checksum";
            this.Load += new System.EventHandler(this.File_checksum_Load);
            this.tableLPMain.ResumeLayout(false);
            this.tableLPMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxHash;
        private System.Windows.Forms.Button buttonChecksum;
        private System.Windows.Forms.Button buttonFile;
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
        private System.Windows.Forms.TableLayoutPanel tableLPMain;
        private System.Windows.Forms.Button buttonRunChecksum;
        private System.Windows.Forms.Label labelHash;
        private System.Windows.Forms.Label labelMD5Output;
        private System.Windows.Forms.Label labelSHA1Output;
        private System.Windows.Forms.Label labelSHA256Output;
        private System.Windows.Forms.Label labelSHA512Output;
        private System.Windows.Forms.Label labelRipeMDOutput;
        private System.Windows.Forms.Label labelCRC32Output;
        private System.Windows.Forms.Label labelCheckSum;
        private System.Windows.Forms.Label labelFileLocation;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxMultiThread;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
namespace HashTester
{
    partial class HashingCollisionForm
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
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.buttonGenerateCollision = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.labelMaxAttempts = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonAbort = new System.Windows.Forms.Button();
            this.labelLenght = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.labelAttempts = new System.Windows.Forms.Label();
            this.labelCurrentSpeed = new System.Windows.Forms.Label();
            this.labelAverageSpeed = new System.Windows.Forms.Label();
            this.checkBoxUseHex = new System.Windows.Forms.CheckBox();
            this.checkBoxPerformanceMode = new System.Windows.Forms.CheckBox();
            this.buttonCheckCollision = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.groupBoxUI = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCumulativeChanceToFind = new System.Windows.Forms.Label();
            this.labelChanceToFind = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBoxUI.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hashSelector
            // 
            this.hashSelector.AllowDrop = true;
            this.tableLayoutPanel1.SetColumnSpan(this.hashSelector, 2);
            this.hashSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.hashSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "CRC32",
            "RipeMD-160",
            "MD5",
            "SHA1"});
            this.hashSelector.Location = new System.Drawing.Point(4, 117);
            this.hashSelector.Margin = new System.Windows.Forms.Padding(4);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(120, 24);
            this.hashSelector.TabIndex = 9;
            // 
            // buttonGenerateCollision
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonGenerateCollision, 4);
            this.buttonGenerateCollision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerateCollision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonGenerateCollision.Location = new System.Drawing.Point(4, 4);
            this.buttonGenerateCollision.Margin = new System.Windows.Forms.Padding(4);
            this.buttonGenerateCollision.Name = "buttonGenerateCollision";
            this.buttonGenerateCollision.Size = new System.Drawing.Size(248, 77);
            this.buttonGenerateCollision.TabIndex = 10;
            this.buttonGenerateCollision.Text = "Generate a Collision";
            this.buttonGenerateCollision.UseVisualStyleBackColor = true;
            this.buttonGenerateCollision.Click += new System.EventHandler(this.buttonGenerateCollision_Click);
            // 
            // listBoxLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxLog, 8);
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 17;
            this.listBoxLog.Location = new System.Drawing.Point(4, 259);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxLog.Name = "listBoxLog";
            this.tableLayoutPanel1.SetRowSpan(this.listBoxLog, 3);
            this.listBoxLog.Size = new System.Drawing.Size(504, 219);
            this.listBoxLog.TabIndex = 12;
            // 
            // buttonClearListBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonClearListBox, 3);
            this.buttonClearListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClearListBox.Location = new System.Drawing.Point(4, 486);
            this.buttonClearListBox.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(184, 80);
            this.buttonClearListBox.TabIndex = 13;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonReturn
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonReturn, 3);
            this.buttonReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonReturn.Location = new System.Drawing.Point(580, 486);
            this.buttonReturn.Margin = new System.Windows.Forms.Padding(4);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(191, 80);
            this.buttonReturn.TabIndex = 14;
            this.buttonReturn.Text = "Go Back";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // numericUpDown1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.numericUpDown1, 6);
            this.numericUpDown1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown1.Location = new System.Drawing.Point(4, 202);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(376, 22);
            this.numericUpDown1.TabIndex = 15;
            // 
            // labelMaxAttempts
            // 
            this.labelMaxAttempts.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelMaxAttempts, 6);
            this.labelMaxAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMaxAttempts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMaxAttempts.Location = new System.Drawing.Point(4, 170);
            this.labelMaxAttempts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxAttempts.Name = "labelMaxAttempts";
            this.labelMaxAttempts.Size = new System.Drawing.Size(376, 28);
            this.labelMaxAttempts.TabIndex = 16;
            this.labelMaxAttempts.Text = "Maximum Attempts";
            this.labelMaxAttempts.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimer.Location = new System.Drawing.Point(4, 0);
            this.labelTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(367, 23);
            this.labelTimer.TabIndex = 17;
            this.labelTimer.Text = "Timer: ";
            this.labelTimer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonAbort
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonAbort, 4);
            this.buttonAbort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonAbort.Location = new System.Drawing.Point(516, 4);
            this.buttonAbort.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(255, 77);
            this.buttonAbort.TabIndex = 18;
            this.buttonAbort.Text = "Cancel The Process";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelLenght
            // 
            this.labelLenght.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelLenght, 4);
            this.labelLenght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelLenght.Location = new System.Drawing.Point(132, 85);
            this.labelLenght.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLenght.Name = "labelLenght";
            this.labelLenght.Size = new System.Drawing.Size(248, 28);
            this.labelLenght.TabIndex = 20;
            this.labelLenght.Text = "Lenght";
            this.labelLenght.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numericUpDown2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.numericUpDown2, 4);
            this.numericUpDown2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown2.Location = new System.Drawing.Point(132, 117);
            this.numericUpDown2.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(248, 22);
            this.numericUpDown2.TabIndex = 19;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // labelAttempts
            // 
            this.labelAttempts.AutoSize = true;
            this.labelAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAttempts.Location = new System.Drawing.Point(4, 23);
            this.labelAttempts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAttempts.Name = "labelAttempts";
            this.labelAttempts.Size = new System.Drawing.Size(367, 23);
            this.labelAttempts.TabIndex = 21;
            this.labelAttempts.Text = "Number of attempts: ";
            this.labelAttempts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCurrentSpeed
            // 
            this.labelCurrentSpeed.AutoSize = true;
            this.labelCurrentSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrentSpeed.Location = new System.Drawing.Point(4, 46);
            this.labelCurrentSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurrentSpeed.Name = "labelCurrentSpeed";
            this.labelCurrentSpeed.Size = new System.Drawing.Size(367, 23);
            this.labelCurrentSpeed.TabIndex = 22;
            this.labelCurrentSpeed.Text = "Hashes per sec:";
            this.labelCurrentSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelAverageSpeed
            // 
            this.labelAverageSpeed.AutoSize = true;
            this.labelAverageSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAverageSpeed.Location = new System.Drawing.Point(4, 69);
            this.labelAverageSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAverageSpeed.Name = "labelAverageSpeed";
            this.labelAverageSpeed.Size = new System.Drawing.Size(367, 23);
            this.labelAverageSpeed.TabIndex = 24;
            this.labelAverageSpeed.Text = "Average speed: ";
            this.labelAverageSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxUseHex
            // 
            this.checkBoxUseHex.AutoSize = true;
            this.checkBoxUseHex.Checked = true;
            this.checkBoxUseHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxUseHex, 4);
            this.checkBoxUseHex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUseHex.Location = new System.Drawing.Point(516, 259);
            this.checkBoxUseHex.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUseHex.Name = "checkBoxUseHex";
            this.checkBoxUseHex.Size = new System.Drawing.Size(255, 20);
            this.checkBoxUseHex.TabIndex = 26;
            this.checkBoxUseHex.Text = "Use HEX to display text";
            this.checkBoxUseHex.UseVisualStyleBackColor = true;
            // 
            // checkBoxPerformanceMode
            // 
            this.checkBoxPerformanceMode.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.checkBoxPerformanceMode, 4);
            this.checkBoxPerformanceMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxPerformanceMode.Location = new System.Drawing.Point(516, 287);
            this.checkBoxPerformanceMode.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxPerformanceMode.Name = "checkBoxPerformanceMode";
            this.checkBoxPerformanceMode.Size = new System.Drawing.Size(255, 20);
            this.checkBoxPerformanceMode.TabIndex = 27;
            this.checkBoxPerformanceMode.Text = "PerformanceMode";
            this.checkBoxPerformanceMode.UseVisualStyleBackColor = true;
            // 
            // buttonCheckCollision
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCheckCollision, 4);
            this.buttonCheckCollision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCheckCollision.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCheckCollision.Location = new System.Drawing.Point(260, 4);
            this.buttonCheckCollision.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCheckCollision.Name = "buttonCheckCollision";
            this.buttonCheckCollision.Size = new System.Drawing.Size(248, 77);
            this.buttonCheckCollision.TabIndex = 28;
            this.buttonCheckCollision.Text = "Check a collision";
            this.buttonCheckCollision.UseVisualStyleBackColor = true;
            this.buttonCheckCollision.Click += new System.EventHandler(this.buttonCheckCollision_Click);
            // 
            // buttonSaveLog
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonSaveLog, 3);
            this.buttonSaveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSaveLog.Location = new System.Drawing.Point(196, 486);
            this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(184, 80);
            this.buttonSaveLog.TabIndex = 29;
            this.buttonSaveLog.Text = "Save Log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClipboard
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonClipboard, 3);
            this.buttonClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClipboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonClipboard.Location = new System.Drawing.Point(388, 486);
            this.buttonClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(184, 80);
            this.buttonClipboard.TabIndex = 30;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // groupBoxUI
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBoxUI, 6);
            this.groupBoxUI.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUI.Location = new System.Drawing.Point(388, 89);
            this.groupBoxUI.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxUI.Name = "groupBoxUI";
            this.groupBoxUI.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.SetRowSpan(this.groupBoxUI, 4);
            this.groupBoxUI.Size = new System.Drawing.Size(383, 162);
            this.groupBoxUI.TabIndex = 31;
            this.groupBoxUI.TabStop = false;
            this.groupBoxUI.Text = "UI";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labelCumulativeChanceToFind, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.labelTimer, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelChanceToFind, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.labelAttempts, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelAverageSpeed, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.labelCurrentSpeed, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(375, 139);
            this.tableLayoutPanel2.TabIndex = 33;
            // 
            // labelCumulativeChanceToFind
            // 
            this.labelCumulativeChanceToFind.AutoSize = true;
            this.labelCumulativeChanceToFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCumulativeChanceToFind.Location = new System.Drawing.Point(4, 115);
            this.labelCumulativeChanceToFind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCumulativeChanceToFind.Name = "labelCumulativeChanceToFind";
            this.labelCumulativeChanceToFind.Size = new System.Drawing.Size(367, 24);
            this.labelCumulativeChanceToFind.TabIndex = 26;
            this.labelCumulativeChanceToFind.Text = "Cumulative chance to find:";
            this.labelCumulativeChanceToFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelChanceToFind
            // 
            this.labelChanceToFind.AutoSize = true;
            this.labelChanceToFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelChanceToFind.Location = new System.Drawing.Point(4, 92);
            this.labelChanceToFind.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelChanceToFind.Name = "labelChanceToFind";
            this.labelChanceToFind.Size = new System.Drawing.Size(367, 23);
            this.labelChanceToFind.TabIndex = 25;
            this.labelChanceToFind.Text = "Chance to find in the next 10k attempts:";
            this.labelChanceToFind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 12;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333542F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.331042F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333543F));
            this.tableLayoutPanel1.Controls.Add(this.buttonGenerateCollision, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxPerformanceMode, 8, 6);
            this.tableLayoutPanel1.Controls.Add(this.groupBoxUI, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBoxUseHex, 8, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonCheckCollision, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLog, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelMaxAttempts, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonClipboard, 6, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonAbort, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelLenght, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonSaveLog, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonClearListBox, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.buttonReturn, 9, 8);
            this.tableLayoutPanel1.Controls.Add(this.hashSelector, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(775, 570);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // HashingCollisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 570);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(790, 607);
            this.Name = "HashingCollisionForm";
            this.Text = "HashingCollisionForm";
            this.Load += new System.EventHandler(this.HashingCollisionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBoxUI.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.Button buttonGenerateCollision;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label labelMaxAttempts;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button buttonAbort;
        private System.Windows.Forms.Label labelLenght;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label labelAttempts;
        private System.Windows.Forms.Label labelCurrentSpeed;
        private System.Windows.Forms.Label labelAverageSpeed;
        private System.Windows.Forms.CheckBox checkBoxUseHex;
        private System.Windows.Forms.CheckBox checkBoxPerformanceMode;
        private System.Windows.Forms.Button buttonCheckCollision;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.GroupBox groupBoxUI;
        private System.Windows.Forms.Label labelChanceToFind;
        private System.Windows.Forms.Label labelCumulativeChanceToFind;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
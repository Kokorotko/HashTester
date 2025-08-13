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
            this.checkBoxListBoxLog = new System.Windows.Forms.CheckBox();
            this.labelAverageSpeed = new System.Windows.Forms.Label();
            this.checkBoxUseHex = new System.Windows.Forms.CheckBox();
            this.checkBoxPerformanceMode = new System.Windows.Forms.CheckBox();
            this.buttonCheckCollision = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.groupBoxUI = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.groupBoxUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // hashSelector
            // 
            this.hashSelector.AllowDrop = true;
            this.hashSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "CRC32",
            "RipeMD-160",
            "MD5",
            "SHA1"});
            this.hashSelector.Location = new System.Drawing.Point(14, 56);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(120, 21);
            this.hashSelector.TabIndex = 9;
            // 
            // buttonGenerateCollision
            // 
            this.buttonGenerateCollision.Location = new System.Drawing.Point(14, 12);
            this.buttonGenerateCollision.Name = "buttonGenerateCollision";
            this.buttonGenerateCollision.Size = new System.Drawing.Size(180, 23);
            this.buttonGenerateCollision.TabIndex = 10;
            this.buttonGenerateCollision.Text = "Generate a Collision";
            this.buttonGenerateCollision.UseVisualStyleBackColor = true;
            this.buttonGenerateCollision.Click += new System.EventHandler(this.buttonGenerateCollision_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 134);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(400, 121);
            this.listBoxLog.TabIndex = 12;
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(12, 260);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(130, 23);
            this.buttonClearListBox.TabIndex = 13;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(418, 260);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(130, 23);
            this.buttonReturn.TabIndex = 14;
            this.buttonReturn.Text = "Go Back";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(14, 103);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(246, 20);
            this.numericUpDown1.TabIndex = 15;
            // 
            // labelMaxAttempts
            // 
            this.labelMaxAttempts.AutoSize = true;
            this.labelMaxAttempts.Location = new System.Drawing.Point(9, 84);
            this.labelMaxAttempts.Name = "labelMaxAttempts";
            this.labelMaxAttempts.Size = new System.Drawing.Size(95, 13);
            this.labelMaxAttempts.TabIndex = 16;
            this.labelMaxAttempts.Text = "Maximum Attempts";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(15, 16);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(39, 13);
            this.labelTimer.TabIndex = 17;
            this.labelTimer.Text = "Timer: ";
            // 
            // buttonAbort
            // 
            this.buttonAbort.Location = new System.Drawing.Point(386, 11);
            this.buttonAbort.Name = "buttonAbort";
            this.buttonAbort.Size = new System.Drawing.Size(166, 23);
            this.buttonAbort.TabIndex = 18;
            this.buttonAbort.Text = "Cancel The Process";
            this.buttonAbort.UseVisualStyleBackColor = true;
            this.buttonAbort.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelLenght
            // 
            this.labelLenght.AutoSize = true;
            this.labelLenght.Location = new System.Drawing.Point(137, 37);
            this.labelLenght.Name = "labelLenght";
            this.labelLenght.Size = new System.Drawing.Size(128, 13);
            this.labelLenght.TabIndex = 20;
            this.labelLenght.Text = "Lenght of the random text";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(140, 57);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
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
            this.labelAttempts.Location = new System.Drawing.Point(15, 29);
            this.labelAttempts.Name = "labelAttempts";
            this.labelAttempts.Size = new System.Drawing.Size(105, 13);
            this.labelAttempts.TabIndex = 21;
            this.labelAttempts.Text = "Number of attempts: ";
            // 
            // labelCurrentSpeed
            // 
            this.labelCurrentSpeed.AutoSize = true;
            this.labelCurrentSpeed.Location = new System.Drawing.Point(16, 43);
            this.labelCurrentSpeed.Name = "labelCurrentSpeed";
            this.labelCurrentSpeed.Size = new System.Drawing.Size(84, 13);
            this.labelCurrentSpeed.TabIndex = 22;
            this.labelCurrentSpeed.Text = "Hashes per sec:";
            // 
            // checkBoxListBoxLog
            // 
            this.checkBoxListBoxLog.AutoSize = true;
            this.checkBoxListBoxLog.Checked = true;
            this.checkBoxListBoxLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxListBoxLog.Location = new System.Drawing.Point(418, 134);
            this.checkBoxListBoxLog.Name = "checkBoxListBoxLog";
            this.checkBoxListBoxLog.Size = new System.Drawing.Size(114, 17);
            this.checkBoxListBoxLog.TabIndex = 23;
            this.checkBoxListBoxLog.Text = "Show log in listBox";
            this.checkBoxListBoxLog.UseVisualStyleBackColor = true;
            // 
            // labelAverageSpeed
            // 
            this.labelAverageSpeed.AutoSize = true;
            this.labelAverageSpeed.Location = new System.Drawing.Point(15, 56);
            this.labelAverageSpeed.Name = "labelAverageSpeed";
            this.labelAverageSpeed.Size = new System.Drawing.Size(85, 13);
            this.labelAverageSpeed.TabIndex = 24;
            this.labelAverageSpeed.Text = "Average speed: ";
            // 
            // checkBoxUseHex
            // 
            this.checkBoxUseHex.AutoSize = true;
            this.checkBoxUseHex.Checked = true;
            this.checkBoxUseHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseHex.Location = new System.Drawing.Point(418, 157);
            this.checkBoxUseHex.Name = "checkBoxUseHex";
            this.checkBoxUseHex.Size = new System.Drawing.Size(137, 17);
            this.checkBoxUseHex.TabIndex = 26;
            this.checkBoxUseHex.Text = "Use HEX to display text";
            this.checkBoxUseHex.UseVisualStyleBackColor = true;
            // 
            // checkBoxPerformanceMode
            // 
            this.checkBoxPerformanceMode.AutoSize = true;
            this.checkBoxPerformanceMode.Location = new System.Drawing.Point(418, 180);
            this.checkBoxPerformanceMode.Name = "checkBoxPerformanceMode";
            this.checkBoxPerformanceMode.Size = new System.Drawing.Size(113, 17);
            this.checkBoxPerformanceMode.TabIndex = 27;
            this.checkBoxPerformanceMode.Text = "PerformanceMode";
            this.checkBoxPerformanceMode.UseVisualStyleBackColor = true;
            // 
            // buttonCheckCollision
            // 
            this.buttonCheckCollision.Location = new System.Drawing.Point(200, 11);
            this.buttonCheckCollision.Name = "buttonCheckCollision";
            this.buttonCheckCollision.Size = new System.Drawing.Size(180, 23);
            this.buttonCheckCollision.TabIndex = 28;
            this.buttonCheckCollision.Text = "Check a collision";
            this.buttonCheckCollision.UseVisualStyleBackColor = true;
            this.buttonCheckCollision.Click += new System.EventHandler(this.buttonCheckCollision_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(148, 260);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(130, 23);
            this.buttonSaveLog.TabIndex = 29;
            this.buttonSaveLog.Text = "Save Log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(282, 260);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(130, 23);
            this.buttonClipboard.TabIndex = 30;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // groupBoxUI
            // 
            this.groupBoxUI.Controls.Add(this.labelTimer);
            this.groupBoxUI.Controls.Add(this.labelAttempts);
            this.groupBoxUI.Controls.Add(this.labelCurrentSpeed);
            this.groupBoxUI.Controls.Add(this.labelAverageSpeed);
            this.groupBoxUI.Location = new System.Drawing.Point(266, 41);
            this.groupBoxUI.Name = "groupBoxUI";
            this.groupBoxUI.Size = new System.Drawing.Size(277, 82);
            this.groupBoxUI.TabIndex = 31;
            this.groupBoxUI.TabStop = false;
            this.groupBoxUI.Text = "UI";
            // 
            // HashingCollisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 295);
            this.Controls.Add(this.groupBoxUI);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonCheckCollision);
            this.Controls.Add(this.checkBoxPerformanceMode);
            this.Controls.Add(this.checkBoxUseHex);
            this.Controls.Add(this.checkBoxListBoxLog);
            this.Controls.Add(this.labelLenght);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.buttonAbort);
            this.Controls.Add(this.labelMaxAttempts);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonGenerateCollision);
            this.Controls.Add(this.hashSelector);
            this.Name = "HashingCollisionForm";
            this.Text = "HashingCollisionForm";
            this.Load += new System.EventHandler(this.HashingCollisionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.groupBoxUI.ResumeLayout(false);
            this.groupBoxUI.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.CheckBox checkBoxListBoxLog;
        private System.Windows.Forms.Label labelAverageSpeed;
        private System.Windows.Forms.CheckBox checkBoxUseHex;
        private System.Windows.Forms.CheckBox checkBoxPerformanceMode;
        private System.Windows.Forms.Button buttonCheckCollision;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.GroupBox groupBoxUI;
    }
}
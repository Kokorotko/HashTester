namespace HashTester
{
    partial class PasswordForm
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
            this.buttonCheckPassword = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.buttonChangePath = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCrackCalculate = new System.Windows.Forms.Button();
            this.checkBoxCrack04 = new System.Windows.Forms.CheckBox();
            this.checkBoxCrack03 = new System.Windows.Forms.CheckBox();
            this.checkBoxCrack02 = new System.Windows.Forms.CheckBox();
            this.checkBoxCrack01 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCrackSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCrackLenght = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDownStopTimer = new System.Windows.Forms.NumericUpDown();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBoxPerformanceMode = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.buttonBruteForceAttack = new System.Windows.Forms.Button();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.buttonPreHash = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBoxListBoxLog = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.textBoxBruteForceInput = new System.Windows.Forms.TextBox();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.labelHashes = new System.Windows.Forms.Label();
            this.labelAttempts = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCheckPassword
            // 
            this.buttonCheckPassword.Location = new System.Drawing.Point(6, 19);
            this.buttonCheckPassword.Name = "buttonCheckPassword";
            this.buttonCheckPassword.Size = new System.Drawing.Size(199, 23);
            this.buttonCheckPassword.TabIndex = 0;
            this.buttonCheckPassword.Text = "Check password";
            this.buttonCheckPassword.UseVisualStyleBackColor = true;
            this.buttonCheckPassword.Click += new System.EventHandler(this.buttonCheckPassword_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 49);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 72);
            this.textBox1.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 128);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(130, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "rockyou.txt full version";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 151);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(140, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "rockyou.txt short version";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 174);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(163, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "rockyou.txt very short version";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(5, 197);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(77, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Custom .txt";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // buttonChangePath
            // 
            this.buttonChangePath.Location = new System.Drawing.Point(5, 220);
            this.buttonChangePath.Name = "buttonChangePath";
            this.buttonChangePath.Size = new System.Drawing.Size(200, 23);
            this.buttonChangePath.TabIndex = 6;
            this.buttonChangePath.Text = "Change path to password folder";
            this.buttonChangePath.UseVisualStyleBackColor = true;
            this.buttonChangePath.Click += new System.EventHandler(this.buttonChangePath_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonCheckPassword);
            this.groupBox1.Controls.Add(this.buttonChangePath);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 253);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password Leak Test";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCrackCalculate);
            this.groupBox2.Controls.Add(this.checkBoxCrack04);
            this.groupBox2.Controls.Add(this.checkBoxCrack03);
            this.groupBox2.Controls.Add(this.checkBoxCrack02);
            this.groupBox2.Controls.Add(this.checkBoxCrack01);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxCrackSpeed);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBoxCrackLenght);
            this.groupBox2.Location = new System.Drawing.Point(235, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(131, 252);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "How long to crack";
            // 
            // buttonCrackCalculate
            // 
            this.buttonCrackCalculate.Location = new System.Drawing.Point(6, 219);
            this.buttonCrackCalculate.Name = "buttonCrackCalculate";
            this.buttonCrackCalculate.Size = new System.Drawing.Size(75, 23);
            this.buttonCrackCalculate.TabIndex = 8;
            this.buttonCrackCalculate.Text = "Calculate";
            this.buttonCrackCalculate.UseVisualStyleBackColor = true;
            this.buttonCrackCalculate.Click += new System.EventHandler(this.buttonCrackCalculate_Click);
            // 
            // checkBoxCrack04
            // 
            this.checkBoxCrack04.AutoSize = true;
            this.checkBoxCrack04.Checked = true;
            this.checkBoxCrack04.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrack04.Location = new System.Drawing.Point(6, 196);
            this.checkBoxCrack04.Name = "checkBoxCrack04";
            this.checkBoxCrack04.Size = new System.Drawing.Size(123, 17);
            this.checkBoxCrack04.TabIndex = 7;
            this.checkBoxCrack04.Text = "Speciální znaky (33)";
            this.checkBoxCrack04.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrack03
            // 
            this.checkBoxCrack03.AutoSize = true;
            this.checkBoxCrack03.Checked = true;
            this.checkBoxCrack03.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrack03.Location = new System.Drawing.Point(6, 173);
            this.checkBoxCrack03.Name = "checkBoxCrack03";
            this.checkBoxCrack03.Size = new System.Drawing.Size(79, 17);
            this.checkBoxCrack03.TabIndex = 6;
            this.checkBoxCrack03.Text = "Číslice (10)";
            this.checkBoxCrack03.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrack02
            // 
            this.checkBoxCrack02.AutoSize = true;
            this.checkBoxCrack02.Checked = true;
            this.checkBoxCrack02.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrack02.Location = new System.Drawing.Point(6, 150);
            this.checkBoxCrack02.Name = "checkBoxCrack02";
            this.checkBoxCrack02.Size = new System.Drawing.Size(118, 17);
            this.checkBoxCrack02.TabIndex = 5;
            this.checkBoxCrack02.Text = "Velká písmena (26)";
            this.checkBoxCrack02.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrack01
            // 
            this.checkBoxCrack01.AutoSize = true;
            this.checkBoxCrack01.Checked = true;
            this.checkBoxCrack01.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrack01.Location = new System.Drawing.Point(6, 127);
            this.checkBoxCrack01.Name = "checkBoxCrack01";
            this.checkBoxCrack01.Size = new System.Drawing.Size(114, 17);
            this.checkBoxCrack01.TabIndex = 4;
            this.checkBoxCrack01.Text = "Malá písmena (26)";
            this.checkBoxCrack01.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Počet pokusů /s";
            // 
            // textBoxCrackSpeed
            // 
            this.textBoxCrackSpeed.Location = new System.Drawing.Point(6, 100);
            this.textBoxCrackSpeed.Name = "textBoxCrackSpeed";
            this.textBoxCrackSpeed.Size = new System.Drawing.Size(100, 20);
            this.textBoxCrackSpeed.TabIndex = 2;
            this.textBoxCrackSpeed.Text = "20000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Počet znaků/ heslo";
            // 
            // textBoxCrackLenght
            // 
            this.textBoxCrackLenght.Location = new System.Drawing.Point(6, 34);
            this.textBoxCrackLenght.Name = "textBoxCrackLenght";
            this.textBoxCrackLenght.Size = new System.Drawing.Size(100, 20);
            this.textBoxCrackLenght.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.numericUpDownStopTimer);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBoxPerformanceMode);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.buttonBruteForceAttack);
            this.groupBox3.Controls.Add(this.checkBox4);
            this.groupBox3.Controls.Add(this.buttonPreHash);
            this.groupBox3.Controls.Add(this.checkBox5);
            this.groupBox3.Controls.Add(this.checkBoxListBoxLog);
            this.groupBox3.Controls.Add(this.checkBox6);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.radioButton6);
            this.groupBox3.Controls.Add(this.numericUpDown2);
            this.groupBox3.Controls.Add(this.radioButton5);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Controls.Add(this.hashSelector);
            this.groupBox3.Controls.Add(this.textBoxBruteForceInput);
            this.groupBox3.Location = new System.Drawing.Point(372, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 252);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "BruteForce Attack";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(182, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Stop Timer (in seconds)";
            // 
            // numericUpDownStopTimer
            // 
            this.numericUpDownStopTimer.Location = new System.Drawing.Point(185, 100);
            this.numericUpDownStopTimer.Maximum = new decimal(new int[] {
            172800,
            0,
            0,
            0});
            this.numericUpDownStopTimer.Name = "numericUpDownStopTimer";
            this.numericUpDownStopTimer.Size = new System.Drawing.Size(224, 20);
            this.numericUpDownStopTimer.TabIndex = 35;
            this.numericUpDownStopTimer.ThousandsSeparator = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(5, 150);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(137, 17);
            this.checkBox2.TabIndex = 33;
            this.checkBox2.Text = "Use HEX to display text";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBoxPerformanceMode
            // 
            this.checkBoxPerformanceMode.AutoSize = true;
            this.checkBoxPerformanceMode.Location = new System.Drawing.Point(6, 173);
            this.checkBoxPerformanceMode.Name = "checkBoxPerformanceMode";
            this.checkBoxPerformanceMode.Size = new System.Drawing.Size(113, 17);
            this.checkBoxPerformanceMode.TabIndex = 34;
            this.checkBoxPerformanceMode.Text = "PerformanceMode";
            this.checkBoxPerformanceMode.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(289, 198);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(123, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Speciální znaky (33)";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // buttonBruteForceAttack
            // 
            this.buttonBruteForceAttack.Location = new System.Drawing.Point(7, 219);
            this.buttonBruteForceAttack.Name = "buttonBruteForceAttack";
            this.buttonBruteForceAttack.Size = new System.Drawing.Size(121, 23);
            this.buttonBruteForceAttack.TabIndex = 11;
            this.buttonBruteForceAttack.Text = "Brute Force Attack";
            this.buttonBruteForceAttack.UseVisualStyleBackColor = true;
            this.buttonBruteForceAttack.Click += new System.EventHandler(this.buttonBruteForceAttack_Click);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(289, 175);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(79, 17);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "Číslice (10)";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // buttonPreHash
            // 
            this.buttonPreHash.Location = new System.Drawing.Point(286, 219);
            this.buttonPreHash.Name = "buttonPreHash";
            this.buttonPreHash.Size = new System.Drawing.Size(121, 23);
            this.buttonPreHash.TabIndex = 10;
            this.buttonPreHash.Text = "Generate a Pre-hash";
            this.buttonPreHash.UseVisualStyleBackColor = true;
            this.buttonPreHash.Click += new System.EventHandler(this.buttonPreHash_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Checked = true;
            this.checkBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox5.Location = new System.Drawing.Point(289, 152);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(118, 17);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "Velká písmena (26)";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBoxListBoxLog
            // 
            this.checkBoxListBoxLog.AutoSize = true;
            this.checkBoxListBoxLog.Location = new System.Drawing.Point(6, 129);
            this.checkBoxListBoxLog.Name = "checkBoxListBoxLog";
            this.checkBoxListBoxLog.Size = new System.Drawing.Size(114, 17);
            this.checkBoxListBoxLog.TabIndex = 32;
            this.checkBoxListBoxLog.Text = "Show log in listBox";
            this.checkBoxListBoxLog.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Location = new System.Drawing.Point(289, 129);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(114, 17);
            this.checkBox6.TabIndex = 9;
            this.checkBox6.Text = "Malá písmena (26)";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 196);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(191, 17);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Text = "Use pre-hashed (Dictionary Attack)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(131, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Lenght";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(6, 59);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(62, 17);
            this.radioButton6.TabIndex = 8;
            this.radioButton6.Text = "Hashed";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(134, 101);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown2.TabIndex = 30;
            this.numericUpDown2.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Checked = true;
            this.radioButton5.Location = new System.Drawing.Point(5, 41);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(62, 17);
            this.radioButton5.TabIndex = 7;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Regular";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Maximum Attempts";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(286, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Algorithm";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(7, 101);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.ThousandsSeparator = true;
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
            this.hashSelector.Location = new System.Drawing.Point(289, 59);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(114, 21);
            this.hashSelector.TabIndex = 5;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // textBoxBruteForceInput
            // 
            this.textBoxBruteForceInput.Location = new System.Drawing.Point(7, 20);
            this.textBoxBruteForceInput.Name = "textBoxBruteForceInput";
            this.textBoxBruteForceInput.Size = new System.Drawing.Size(396, 20);
            this.textBoxBruteForceInput.TabIndex = 0;
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(15, 308);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(98, 13);
            this.labelSpeed.TabIndex = 28;
            this.labelSpeed.Text = "Average speed /s: ";
            // 
            // labelHashes
            // 
            this.labelHashes.AutoSize = true;
            this.labelHashes.Location = new System.Drawing.Point(16, 295);
            this.labelHashes.Name = "labelHashes";
            this.labelHashes.Size = new System.Drawing.Size(59, 13);
            this.labelHashes.TabIndex = 27;
            this.labelHashes.Text = "Hashes /s:";
            // 
            // labelAttempts
            // 
            this.labelAttempts.AutoSize = true;
            this.labelAttempts.Location = new System.Drawing.Point(15, 281);
            this.labelAttempts.Name = "labelAttempts";
            this.labelAttempts.Size = new System.Drawing.Size(105, 13);
            this.labelAttempts.TabIndex = 26;
            this.labelAttempts.Text = "Number of attempts: ";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(15, 268);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(39, 13);
            this.labelTimer.TabIndex = 25;
            this.labelTimer.Text = "Timer: ";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(17, 324);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 23);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Abort The Process";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 354);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(760, 23);
            this.progressBar1.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(369, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Progress Bar";
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 385);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelSpeed);
            this.Controls.Add(this.labelHashes);
            this.Controls.Add(this.labelAttempts);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PasswordForm";
            this.Text = "PasswordForm";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCheckPassword;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button buttonChangePath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCrackCalculate;
        private System.Windows.Forms.CheckBox checkBoxCrack04;
        private System.Windows.Forms.CheckBox checkBoxCrack03;
        private System.Windows.Forms.CheckBox checkBoxCrack02;
        private System.Windows.Forms.CheckBox checkBoxCrack01;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCrackSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCrackLenght;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBoxBruteForceInput;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonBruteForceAttack;
        private System.Windows.Forms.Button buttonPreHash;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBoxPerformanceMode;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBoxListBoxLog;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDownStopTimer;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.Label labelHashes;
        private System.Windows.Forms.Label labelAttempts;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label10;
    }
}
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
            this.buttonDictionaryAttack = new System.Windows.Forms.Button();
            this.textBoxDictionary = new System.Windows.Forms.TextBox();
            this.radioButtonRockYouFull = new System.Windows.Forms.RadioButton();
            this.radioButtonRockYouShort = new System.Windows.Forms.RadioButton();
            this.radioButtonRockYouFullShortShort = new System.Windows.Forms.RadioButton();
            this.radioButtonRockyouCustom = new System.Windows.Forms.RadioButton();
            this.groupBoxDictionary = new System.Windows.Forms.GroupBox();
            this.checkBoxShowLog = new System.Windows.Forms.CheckBox();
            this.groupBoxTimeToCrack = new System.Windows.Forms.GroupBox();
            this.buttonCrackCalculate = new System.Windows.Forms.Button();
            this.checkBoxCrackSpecial = new System.Windows.Forms.CheckBox();
            this.checkBoxCrackDigit = new System.Windows.Forms.CheckBox();
            this.checkBoxCrackUpper = new System.Windows.Forms.CheckBox();
            this.checkBoxCrackLower = new System.Windows.Forms.CheckBox();
            this.labelCrackSpeed = new System.Windows.Forms.Label();
            this.textBoxCrackSpeed = new System.Windows.Forms.TextBox();
            this.labelCrackLenght = new System.Windows.Forms.Label();
            this.textBoxCrackLenght = new System.Windows.Forms.TextBox();
            this.groupBoxBruteForce = new System.Windows.Forms.GroupBox();
            this.checkBoxUnknownLenghtBruteForce = new System.Windows.Forms.CheckBox();
            this.checkBoxHexOutputBruteForce = new System.Windows.Forms.CheckBox();
            this.labelStopTimer = new System.Windows.Forms.Label();
            this.numericUpDownStopTimer = new System.Windows.Forms.NumericUpDown();
            this.checkBoxPerformanceMode = new System.Windows.Forms.CheckBox();
            this.checkBoxSpecialChars = new System.Windows.Forms.CheckBox();
            this.buttonBruteForceAttack = new System.Windows.Forms.Button();
            this.checkBoxDigits = new System.Windows.Forms.CheckBox();
            this.checkBoxUpperCase = new System.Windows.Forms.CheckBox();
            this.checkBoxLowerCase = new System.Windows.Forms.CheckBox();
            this.labelLenght = new System.Windows.Forms.Label();
            this.radioButtonBruteForceHashed = new System.Windows.Forms.RadioButton();
            this.numericUpDownLenght = new System.Windows.Forms.NumericUpDown();
            this.radioButtonRegularBruteForce = new System.Windows.Forms.RadioButton();
            this.labelMaxAttempts = new System.Windows.Forms.Label();
            this.numericUpDownMaxAttempts = new System.Windows.Forms.NumericUpDown();
            this.textBoxBruteForce = new System.Windows.Forms.TextBox();
            this.buttonRainbowTableAttack = new System.Windows.Forms.Button();
            this.buttonGenerateRainbowTable = new System.Windows.Forms.Button();
            this.labelStatSpeed = new System.Windows.Forms.Label();
            this.labelStatCurrentSpeed = new System.Windows.Forms.Label();
            this.labelStatAttempts = new System.Windows.Forms.Label();
            this.labelStatTimer = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgressBar = new System.Windows.Forms.Label();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.buttonLogClear = new System.Windows.Forms.Button();
            this.buttonLogSave = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.groupBoxRainbowTable = new System.Windows.Forms.GroupBox();
            this.radioButtonHashedRainbowTable = new System.Windows.Forms.RadioButton();
            this.textBoxRainbowTable = new System.Windows.Forms.TextBox();
            this.radioButtonRegularRainbowTable = new System.Windows.Forms.RadioButton();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.groupBoxUI = new System.Windows.Forms.GroupBox();
            this.radioButtonRegularDictionary = new System.Windows.Forms.RadioButton();
            this.radioButtonHashedDictionary = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.groupBoxDictionary.SuspendLayout();
            this.groupBoxTimeToCrack.SuspendLayout();
            this.groupBoxBruteForce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxAttempts)).BeginInit();
            this.groupBoxRainbowTable.SuspendLayout();
            this.groupBoxUI.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDictionaryAttack
            // 
            this.buttonDictionaryAttack.Location = new System.Drawing.Point(6, 220);
            this.buttonDictionaryAttack.Name = "buttonDictionaryAttack";
            this.buttonDictionaryAttack.Size = new System.Drawing.Size(199, 23);
            this.buttonDictionaryAttack.TabIndex = 0;
            this.buttonDictionaryAttack.Text = "Dictionary attack";
            this.buttonDictionaryAttack.UseVisualStyleBackColor = true;
            this.buttonDictionaryAttack.Click += new System.EventHandler(this.buttonCheckPassword_Click);
            // 
            // textBoxDictionary
            // 
            this.textBoxDictionary.Location = new System.Drawing.Point(2, 43);
            this.textBoxDictionary.Multiline = true;
            this.textBoxDictionary.Name = "textBoxDictionary";
            this.textBoxDictionary.Size = new System.Drawing.Size(208, 77);
            this.textBoxDictionary.TabIndex = 1;
            this.textBoxDictionary.Text = "budakkecik";
            // 
            // radioButtonRockYouFull
            // 
            this.radioButtonRockYouFull.AutoSize = true;
            this.radioButtonRockYouFull.Location = new System.Drawing.Point(7, 128);
            this.radioButtonRockYouFull.Name = "radioButtonRockYouFull";
            this.radioButtonRockYouFull.Size = new System.Drawing.Size(130, 17);
            this.radioButtonRockYouFull.TabIndex = 2;
            this.radioButtonRockYouFull.Text = "rockyou.txt full version";
            this.radioButtonRockYouFull.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockYouShort
            // 
            this.radioButtonRockYouShort.AutoSize = true;
            this.radioButtonRockYouShort.Location = new System.Drawing.Point(7, 151);
            this.radioButtonRockYouShort.Name = "radioButtonRockYouShort";
            this.radioButtonRockYouShort.Size = new System.Drawing.Size(140, 17);
            this.radioButtonRockYouShort.TabIndex = 3;
            this.radioButtonRockYouShort.Text = "rockyou.txt short version";
            this.radioButtonRockYouShort.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockYouFullShortShort
            // 
            this.radioButtonRockYouFullShortShort.AutoSize = true;
            this.radioButtonRockYouFullShortShort.Location = new System.Drawing.Point(7, 174);
            this.radioButtonRockYouFullShortShort.Name = "radioButtonRockYouFullShortShort";
            this.radioButtonRockYouFullShortShort.Size = new System.Drawing.Size(163, 17);
            this.radioButtonRockYouFullShortShort.TabIndex = 4;
            this.radioButtonRockYouFullShortShort.Text = "rockyou.txt very short version";
            this.radioButtonRockYouFullShortShort.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockyouCustom
            // 
            this.radioButtonRockyouCustom.AutoSize = true;
            this.radioButtonRockyouCustom.Location = new System.Drawing.Point(6, 197);
            this.radioButtonRockyouCustom.Name = "radioButtonRockyouCustom";
            this.radioButtonRockyouCustom.Size = new System.Drawing.Size(77, 17);
            this.radioButtonRockyouCustom.TabIndex = 5;
            this.radioButtonRockyouCustom.Text = "Custom .txt";
            this.radioButtonRockyouCustom.UseVisualStyleBackColor = true;
            // 
            // groupBoxDictionary
            // 
            this.groupBoxDictionary.Controls.Add(this.panel1);
            this.groupBoxDictionary.Controls.Add(this.buttonDictionaryAttack);
            this.groupBoxDictionary.Controls.Add(this.textBoxDictionary);
            this.groupBoxDictionary.Controls.Add(this.radioButtonRockyouCustom);
            this.groupBoxDictionary.Controls.Add(this.radioButtonRockYouFull);
            this.groupBoxDictionary.Controls.Add(this.radioButtonRockYouFullShortShort);
            this.groupBoxDictionary.Controls.Add(this.radioButtonRockYouShort);
            this.groupBoxDictionary.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDictionary.Name = "groupBoxDictionary";
            this.groupBoxDictionary.Size = new System.Drawing.Size(216, 253);
            this.groupBoxDictionary.TabIndex = 7;
            this.groupBoxDictionary.TabStop = false;
            this.groupBoxDictionary.Text = "Dictionary Attack";
            // 
            // checkBoxShowLog
            // 
            this.checkBoxShowLog.AutoSize = true;
            this.checkBoxShowLog.Checked = true;
            this.checkBoxShowLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowLog.Location = new System.Drawing.Point(711, 314);
            this.checkBoxShowLog.Name = "checkBoxShowLog";
            this.checkBoxShowLog.Size = new System.Drawing.Size(114, 17);
            this.checkBoxShowLog.TabIndex = 39;
            this.checkBoxShowLog.Text = "Show log in listBox";
            this.checkBoxShowLog.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimeToCrack
            // 
            this.groupBoxTimeToCrack.Controls.Add(this.buttonCrackCalculate);
            this.groupBoxTimeToCrack.Controls.Add(this.checkBoxCrackSpecial);
            this.groupBoxTimeToCrack.Controls.Add(this.checkBoxCrackDigit);
            this.groupBoxTimeToCrack.Controls.Add(this.checkBoxCrackUpper);
            this.groupBoxTimeToCrack.Controls.Add(this.checkBoxCrackLower);
            this.groupBoxTimeToCrack.Controls.Add(this.labelCrackSpeed);
            this.groupBoxTimeToCrack.Controls.Add(this.textBoxCrackSpeed);
            this.groupBoxTimeToCrack.Controls.Add(this.labelCrackLenght);
            this.groupBoxTimeToCrack.Controls.Add(this.textBoxCrackLenght);
            this.groupBoxTimeToCrack.Location = new System.Drawing.Point(235, 13);
            this.groupBoxTimeToCrack.Name = "groupBoxTimeToCrack";
            this.groupBoxTimeToCrack.Size = new System.Drawing.Size(153, 252);
            this.groupBoxTimeToCrack.TabIndex = 8;
            this.groupBoxTimeToCrack.TabStop = false;
            this.groupBoxTimeToCrack.Text = "Time to crack calculator";
            // 
            // buttonCrackCalculate
            // 
            this.buttonCrackCalculate.Location = new System.Drawing.Point(6, 219);
            this.buttonCrackCalculate.Name = "buttonCrackCalculate";
            this.buttonCrackCalculate.Size = new System.Drawing.Size(141, 23);
            this.buttonCrackCalculate.TabIndex = 8;
            this.buttonCrackCalculate.Text = "Calculate";
            this.buttonCrackCalculate.UseVisualStyleBackColor = true;
            this.buttonCrackCalculate.Click += new System.EventHandler(this.buttonCrackCalculate_Click);
            // 
            // checkBoxCrackSpecial
            // 
            this.checkBoxCrackSpecial.AutoSize = true;
            this.checkBoxCrackSpecial.Checked = true;
            this.checkBoxCrackSpecial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackSpecial.Location = new System.Drawing.Point(6, 171);
            this.checkBoxCrackSpecial.Name = "checkBoxCrackSpecial";
            this.checkBoxCrackSpecial.Size = new System.Drawing.Size(123, 17);
            this.checkBoxCrackSpecial.TabIndex = 7;
            this.checkBoxCrackSpecial.Text = "Speciální znaky (33)";
            this.checkBoxCrackSpecial.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrackDigit
            // 
            this.checkBoxCrackDigit.AutoSize = true;
            this.checkBoxCrackDigit.Checked = true;
            this.checkBoxCrackDigit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackDigit.Location = new System.Drawing.Point(6, 148);
            this.checkBoxCrackDigit.Name = "checkBoxCrackDigit";
            this.checkBoxCrackDigit.Size = new System.Drawing.Size(79, 17);
            this.checkBoxCrackDigit.TabIndex = 6;
            this.checkBoxCrackDigit.Text = "Číslice (10)";
            this.checkBoxCrackDigit.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrackUpper
            // 
            this.checkBoxCrackUpper.AutoSize = true;
            this.checkBoxCrackUpper.Checked = true;
            this.checkBoxCrackUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackUpper.Location = new System.Drawing.Point(6, 125);
            this.checkBoxCrackUpper.Name = "checkBoxCrackUpper";
            this.checkBoxCrackUpper.Size = new System.Drawing.Size(118, 17);
            this.checkBoxCrackUpper.TabIndex = 5;
            this.checkBoxCrackUpper.Text = "Velká písmena (26)";
            this.checkBoxCrackUpper.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrackLower
            // 
            this.checkBoxCrackLower.AutoSize = true;
            this.checkBoxCrackLower.Checked = true;
            this.checkBoxCrackLower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackLower.Location = new System.Drawing.Point(6, 102);
            this.checkBoxCrackLower.Name = "checkBoxCrackLower";
            this.checkBoxCrackLower.Size = new System.Drawing.Size(114, 17);
            this.checkBoxCrackLower.TabIndex = 4;
            this.checkBoxCrackLower.Text = "Malá písmena (26)";
            this.checkBoxCrackLower.UseVisualStyleBackColor = true;
            // 
            // labelCrackSpeed
            // 
            this.labelCrackSpeed.AutoSize = true;
            this.labelCrackSpeed.Location = new System.Drawing.Point(6, 59);
            this.labelCrackSpeed.Name = "labelCrackSpeed";
            this.labelCrackSpeed.Size = new System.Drawing.Size(86, 13);
            this.labelCrackSpeed.TabIndex = 3;
            this.labelCrackSpeed.Text = "Počet pokusů /s";
            // 
            // textBoxCrackSpeed
            // 
            this.textBoxCrackSpeed.Location = new System.Drawing.Point(6, 75);
            this.textBoxCrackSpeed.Name = "textBoxCrackSpeed";
            this.textBoxCrackSpeed.Size = new System.Drawing.Size(141, 20);
            this.textBoxCrackSpeed.TabIndex = 2;
            this.textBoxCrackSpeed.Text = "2000000000";
            // 
            // labelCrackLenght
            // 
            this.labelCrackLenght.AutoSize = true;
            this.labelCrackLenght.Location = new System.Drawing.Point(6, 18);
            this.labelCrackLenght.Name = "labelCrackLenght";
            this.labelCrackLenght.Size = new System.Drawing.Size(100, 13);
            this.labelCrackLenght.TabIndex = 1;
            this.labelCrackLenght.Text = "Počet znaků/ heslo";
            // 
            // textBoxCrackLenght
            // 
            this.textBoxCrackLenght.Location = new System.Drawing.Point(6, 34);
            this.textBoxCrackLenght.Name = "textBoxCrackLenght";
            this.textBoxCrackLenght.Size = new System.Drawing.Size(141, 20);
            this.textBoxCrackLenght.TabIndex = 0;
            // 
            // groupBoxBruteForce
            // 
            this.groupBoxBruteForce.Controls.Add(this.checkBoxUnknownLenghtBruteForce);
            this.groupBoxBruteForce.Controls.Add(this.checkBoxHexOutputBruteForce);
            this.groupBoxBruteForce.Controls.Add(this.labelStopTimer);
            this.groupBoxBruteForce.Controls.Add(this.numericUpDownStopTimer);
            this.groupBoxBruteForce.Controls.Add(this.checkBoxSpecialChars);
            this.groupBoxBruteForce.Controls.Add(this.buttonBruteForceAttack);
            this.groupBoxBruteForce.Controls.Add(this.checkBoxDigits);
            this.groupBoxBruteForce.Controls.Add(this.checkBoxUpperCase);
            this.groupBoxBruteForce.Controls.Add(this.checkBoxLowerCase);
            this.groupBoxBruteForce.Controls.Add(this.labelLenght);
            this.groupBoxBruteForce.Controls.Add(this.radioButtonBruteForceHashed);
            this.groupBoxBruteForce.Controls.Add(this.numericUpDownLenght);
            this.groupBoxBruteForce.Controls.Add(this.radioButtonRegularBruteForce);
            this.groupBoxBruteForce.Controls.Add(this.labelMaxAttempts);
            this.groupBoxBruteForce.Controls.Add(this.numericUpDownMaxAttempts);
            this.groupBoxBruteForce.Controls.Add(this.textBoxBruteForce);
            this.groupBoxBruteForce.Location = new System.Drawing.Point(590, 12);
            this.groupBoxBruteForce.Name = "groupBoxBruteForce";
            this.groupBoxBruteForce.Size = new System.Drawing.Size(301, 252);
            this.groupBoxBruteForce.TabIndex = 9;
            this.groupBoxBruteForce.TabStop = false;
            this.groupBoxBruteForce.Text = "Brute force attack";
            // 
            // checkBoxUnknownLenghtBruteForce
            // 
            this.checkBoxUnknownLenghtBruteForce.AutoSize = true;
            this.checkBoxUnknownLenghtBruteForce.Location = new System.Drawing.Point(7, 128);
            this.checkBoxUnknownLenghtBruteForce.Name = "checkBoxUnknownLenghtBruteForce";
            this.checkBoxUnknownLenghtBruteForce.Size = new System.Drawing.Size(108, 17);
            this.checkBoxUnknownLenghtBruteForce.TabIndex = 42;
            this.checkBoxUnknownLenghtBruteForce.Text = "Unknown Lenght";
            this.checkBoxUnknownLenghtBruteForce.UseVisualStyleBackColor = true;
            // 
            // checkBoxHexOutputBruteForce
            // 
            this.checkBoxHexOutputBruteForce.AutoSize = true;
            this.checkBoxHexOutputBruteForce.Checked = true;
            this.checkBoxHexOutputBruteForce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHexOutputBruteForce.Location = new System.Drawing.Point(7, 151);
            this.checkBoxHexOutputBruteForce.Name = "checkBoxHexOutputBruteForce";
            this.checkBoxHexOutputBruteForce.Size = new System.Drawing.Size(147, 17);
            this.checkBoxHexOutputBruteForce.TabIndex = 37;
            this.checkBoxHexOutputBruteForce.Text = "Display password as HEX";
            this.checkBoxHexOutputBruteForce.UseVisualStyleBackColor = true;
            // 
            // labelStopTimer
            // 
            this.labelStopTimer.AutoSize = true;
            this.labelStopTimer.Location = new System.Drawing.Point(197, 43);
            this.labelStopTimer.Name = "labelStopTimer";
            this.labelStopTimer.Size = new System.Drawing.Size(84, 13);
            this.labelStopTimer.TabIndex = 36;
            this.labelStopTimer.Text = "Stop Timer (sec)";
            // 
            // numericUpDownStopTimer
            // 
            this.numericUpDownStopTimer.Location = new System.Drawing.Point(134, 60);
            this.numericUpDownStopTimer.Maximum = new decimal(new int[] {
            172800,
            0,
            0,
            0});
            this.numericUpDownStopTimer.Name = "numericUpDownStopTimer";
            this.numericUpDownStopTimer.Size = new System.Drawing.Size(147, 20);
            this.numericUpDownStopTimer.TabIndex = 35;
            this.numericUpDownStopTimer.ThousandsSeparator = true;
            // 
            // checkBoxPerformanceMode
            // 
            this.checkBoxPerformanceMode.AutoSize = true;
            this.checkBoxPerformanceMode.Location = new System.Drawing.Point(710, 337);
            this.checkBoxPerformanceMode.Name = "checkBoxPerformanceMode";
            this.checkBoxPerformanceMode.Size = new System.Drawing.Size(113, 17);
            this.checkBoxPerformanceMode.TabIndex = 34;
            this.checkBoxPerformanceMode.Text = "PerformanceMode";
            this.checkBoxPerformanceMode.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpecialChars
            // 
            this.checkBoxSpecialChars.AutoSize = true;
            this.checkBoxSpecialChars.Checked = true;
            this.checkBoxSpecialChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSpecialChars.Location = new System.Drawing.Point(167, 194);
            this.checkBoxSpecialChars.Name = "checkBoxSpecialChars";
            this.checkBoxSpecialChars.Size = new System.Drawing.Size(123, 17);
            this.checkBoxSpecialChars.TabIndex = 12;
            this.checkBoxSpecialChars.Text = "Speciální znaky (33)";
            this.checkBoxSpecialChars.UseVisualStyleBackColor = true;
            // 
            // buttonBruteForceAttack
            // 
            this.buttonBruteForceAttack.Location = new System.Drawing.Point(5, 219);
            this.buttonBruteForceAttack.Name = "buttonBruteForceAttack";
            this.buttonBruteForceAttack.Size = new System.Drawing.Size(285, 23);
            this.buttonBruteForceAttack.TabIndex = 11;
            this.buttonBruteForceAttack.Text = "Brute Force Attack";
            this.buttonBruteForceAttack.UseVisualStyleBackColor = true;
            this.buttonBruteForceAttack.Click += new System.EventHandler(this.buttonBruteForceAttack_Click);
            // 
            // checkBoxDigits
            // 
            this.checkBoxDigits.AutoSize = true;
            this.checkBoxDigits.Checked = true;
            this.checkBoxDigits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDigits.Location = new System.Drawing.Point(167, 171);
            this.checkBoxDigits.Name = "checkBoxDigits";
            this.checkBoxDigits.Size = new System.Drawing.Size(79, 17);
            this.checkBoxDigits.TabIndex = 11;
            this.checkBoxDigits.Text = "Číslice (10)";
            this.checkBoxDigits.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpperCase
            // 
            this.checkBoxUpperCase.AutoSize = true;
            this.checkBoxUpperCase.Checked = true;
            this.checkBoxUpperCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpperCase.Location = new System.Drawing.Point(167, 148);
            this.checkBoxUpperCase.Name = "checkBoxUpperCase";
            this.checkBoxUpperCase.Size = new System.Drawing.Size(118, 17);
            this.checkBoxUpperCase.TabIndex = 10;
            this.checkBoxUpperCase.Text = "Velká písmena (26)";
            this.checkBoxUpperCase.UseVisualStyleBackColor = true;
            // 
            // checkBoxLowerCase
            // 
            this.checkBoxLowerCase.AutoSize = true;
            this.checkBoxLowerCase.Checked = true;
            this.checkBoxLowerCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLowerCase.Location = new System.Drawing.Point(167, 125);
            this.checkBoxLowerCase.Name = "checkBoxLowerCase";
            this.checkBoxLowerCase.Size = new System.Drawing.Size(114, 17);
            this.checkBoxLowerCase.TabIndex = 9;
            this.checkBoxLowerCase.Text = "Malá písmena (26)";
            this.checkBoxLowerCase.UseVisualStyleBackColor = true;
            // 
            // labelLenght
            // 
            this.labelLenght.AutoSize = true;
            this.labelLenght.Location = new System.Drawing.Point(6, 83);
            this.labelLenght.Name = "labelLenght";
            this.labelLenght.Size = new System.Drawing.Size(40, 13);
            this.labelLenght.TabIndex = 31;
            this.labelLenght.Text = "Lenght";
            // 
            // radioButtonBruteForceHashed
            // 
            this.radioButtonBruteForceHashed.AutoSize = true;
            this.radioButtonBruteForceHashed.Location = new System.Drawing.Point(10, 59);
            this.radioButtonBruteForceHashed.Name = "radioButtonBruteForceHashed";
            this.radioButtonBruteForceHashed.Size = new System.Drawing.Size(62, 17);
            this.radioButtonBruteForceHashed.TabIndex = 8;
            this.radioButtonBruteForceHashed.Text = "Hashed";
            this.radioButtonBruteForceHashed.UseVisualStyleBackColor = true;
            this.radioButtonBruteForceHashed.EnabledChanged += new System.EventHandler(this.radioButton6_EnabledChanged);
            // 
            // numericUpDownLenght
            // 
            this.numericUpDownLenght.Location = new System.Drawing.Point(7, 101);
            this.numericUpDownLenght.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownLenght.Name = "numericUpDownLenght";
            this.numericUpDownLenght.Size = new System.Drawing.Size(107, 20);
            this.numericUpDownLenght.TabIndex = 30;
            this.numericUpDownLenght.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // radioButtonRegularBruteForce
            // 
            this.radioButtonRegularBruteForce.AutoSize = true;
            this.radioButtonRegularBruteForce.Checked = true;
            this.radioButtonRegularBruteForce.Location = new System.Drawing.Point(9, 41);
            this.radioButtonRegularBruteForce.Name = "radioButtonRegularBruteForce";
            this.radioButtonRegularBruteForce.Size = new System.Drawing.Size(62, 17);
            this.radioButtonRegularBruteForce.TabIndex = 7;
            this.radioButtonRegularBruteForce.TabStop = true;
            this.radioButtonRegularBruteForce.Text = "Regular";
            this.radioButtonRegularBruteForce.UseVisualStyleBackColor = true;
            this.radioButtonRegularBruteForce.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // labelMaxAttempts
            // 
            this.labelMaxAttempts.AutoSize = true;
            this.labelMaxAttempts.Location = new System.Drawing.Point(190, 82);
            this.labelMaxAttempts.Name = "labelMaxAttempts";
            this.labelMaxAttempts.Size = new System.Drawing.Size(95, 13);
            this.labelMaxAttempts.TabIndex = 29;
            this.labelMaxAttempts.Text = "Maximum Attempts";
            // 
            // numericUpDownMaxAttempts
            // 
            this.numericUpDownMaxAttempts.Location = new System.Drawing.Point(134, 98);
            this.numericUpDownMaxAttempts.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericUpDownMaxAttempts.Name = "numericUpDownMaxAttempts";
            this.numericUpDownMaxAttempts.Size = new System.Drawing.Size(147, 20);
            this.numericUpDownMaxAttempts.TabIndex = 28;
            this.numericUpDownMaxAttempts.ThousandsSeparator = true;
            // 
            // textBoxBruteForce
            // 
            this.textBoxBruteForce.Location = new System.Drawing.Point(7, 20);
            this.textBoxBruteForce.Name = "textBoxBruteForce";
            this.textBoxBruteForce.Size = new System.Drawing.Size(274, 20);
            this.textBoxBruteForce.TabIndex = 0;
            this.textBoxBruteForce.Text = "budakkecik";
            this.textBoxBruteForce.TextChanged += new System.EventHandler(this.textBoxBruteForceInput_TextChanged);
            // 
            // buttonRainbowTableAttack
            // 
            this.buttonRainbowTableAttack.Location = new System.Drawing.Point(7, 216);
            this.buttonRainbowTableAttack.Name = "buttonRainbowTableAttack";
            this.buttonRainbowTableAttack.Size = new System.Drawing.Size(178, 23);
            this.buttonRainbowTableAttack.TabIndex = 38;
            this.buttonRainbowTableAttack.Text = "Rainbow Table Attack";
            this.buttonRainbowTableAttack.UseVisualStyleBackColor = true;
            this.buttonRainbowTableAttack.Click += new System.EventHandler(this.buttonRainbowTableAttack_Click);
            // 
            // buttonGenerateRainbowTable
            // 
            this.buttonGenerateRainbowTable.Location = new System.Drawing.Point(8, 189);
            this.buttonGenerateRainbowTable.Name = "buttonGenerateRainbowTable";
            this.buttonGenerateRainbowTable.Size = new System.Drawing.Size(176, 23);
            this.buttonGenerateRainbowTable.TabIndex = 10;
            this.buttonGenerateRainbowTable.Text = "Generate Rainbow Table";
            this.buttonGenerateRainbowTable.UseVisualStyleBackColor = true;
            this.buttonGenerateRainbowTable.Click += new System.EventHandler(this.buttonPreHash_Click);
            // 
            // labelStatSpeed
            // 
            this.labelStatSpeed.AutoSize = true;
            this.labelStatSpeed.Location = new System.Drawing.Point(5, 54);
            this.labelStatSpeed.Name = "labelStatSpeed";
            this.labelStatSpeed.Size = new System.Drawing.Size(98, 13);
            this.labelStatSpeed.TabIndex = 28;
            this.labelStatSpeed.Text = "Average speed /s: ";
            // 
            // labelStatCurrentSpeed
            // 
            this.labelStatCurrentSpeed.AutoSize = true;
            this.labelStatCurrentSpeed.Location = new System.Drawing.Point(6, 41);
            this.labelStatCurrentSpeed.Name = "labelStatCurrentSpeed";
            this.labelStatCurrentSpeed.Size = new System.Drawing.Size(92, 13);
            this.labelStatCurrentSpeed.TabIndex = 27;
            this.labelStatCurrentSpeed.Text = "Current speed /s: ";
            // 
            // labelStatAttempts
            // 
            this.labelStatAttempts.AutoSize = true;
            this.labelStatAttempts.Location = new System.Drawing.Point(5, 27);
            this.labelStatAttempts.Name = "labelStatAttempts";
            this.labelStatAttempts.Size = new System.Drawing.Size(105, 13);
            this.labelStatAttempts.TabIndex = 26;
            this.labelStatAttempts.Text = "Number of attempts: ";
            // 
            // labelStatTimer
            // 
            this.labelStatTimer.AutoSize = true;
            this.labelStatTimer.Location = new System.Drawing.Point(5, 14);
            this.labelStatTimer.Name = "labelStatTimer";
            this.labelStatTimer.Size = new System.Drawing.Size(39, 13);
            this.labelStatTimer.TabIndex = 25;
            this.labelStatTimer.Text = "Timer: ";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(711, 358);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(180, 23);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Abort The Process";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Location = new System.Drawing.Point(14, 387);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(879, 23);
            this.progressBar1.TabIndex = 36;
            // 
            // labelProgressBar
            // 
            this.labelProgressBar.AutoSize = true;
            this.labelProgressBar.Location = new System.Drawing.Point(393, 371);
            this.labelProgressBar.Name = "labelProgressBar";
            this.labelProgressBar.Size = new System.Drawing.Size(67, 13);
            this.labelProgressBar.TabIndex = 37;
            this.labelProgressBar.Text = "Progress Bar";
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(14, 416);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(878, 95);
            this.listBoxLog.TabIndex = 38;
            // 
            // buttonLogClear
            // 
            this.buttonLogClear.Location = new System.Drawing.Point(14, 517);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(286, 23);
            this.buttonLogClear.TabIndex = 39;
            this.buttonLogClear.Text = "Clear Log";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            this.buttonLogClear.Click += new System.EventHandler(this.buttonLogClear_Click);
            // 
            // buttonLogSave
            // 
            this.buttonLogSave.Location = new System.Drawing.Point(306, 517);
            this.buttonLogSave.Name = "buttonLogSave";
            this.buttonLogSave.Size = new System.Drawing.Size(286, 23);
            this.buttonLogSave.TabIndex = 40;
            this.buttonLogSave.Text = "Save Log";
            this.buttonLogSave.UseVisualStyleBackColor = true;
            this.buttonLogSave.Click += new System.EventHandler(this.buttonLogSave_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(606, 517);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(286, 23);
            this.buttonClipboard.TabIndex = 41;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // groupBoxRainbowTable
            // 
            this.groupBoxRainbowTable.Controls.Add(this.radioButtonHashedRainbowTable);
            this.groupBoxRainbowTable.Controls.Add(this.textBoxRainbowTable);
            this.groupBoxRainbowTable.Controls.Add(this.radioButtonRegularRainbowTable);
            this.groupBoxRainbowTable.Controls.Add(this.buttonGenerateRainbowTable);
            this.groupBoxRainbowTable.Controls.Add(this.buttonRainbowTableAttack);
            this.groupBoxRainbowTable.Location = new System.Drawing.Point(394, 13);
            this.groupBoxRainbowTable.Name = "groupBoxRainbowTable";
            this.groupBoxRainbowTable.Size = new System.Drawing.Size(191, 252);
            this.groupBoxRainbowTable.TabIndex = 42;
            this.groupBoxRainbowTable.TabStop = false;
            this.groupBoxRainbowTable.Text = "Rainbow table attack";
            // 
            // radioButtonHashedRainbowTable
            // 
            this.radioButtonHashedRainbowTable.AutoSize = true;
            this.radioButtonHashedRainbowTable.Location = new System.Drawing.Point(7, 65);
            this.radioButtonHashedRainbowTable.Name = "radioButtonHashedRainbowTable";
            this.radioButtonHashedRainbowTable.Size = new System.Drawing.Size(62, 17);
            this.radioButtonHashedRainbowTable.TabIndex = 45;
            this.radioButtonHashedRainbowTable.Text = "Hashed";
            this.radioButtonHashedRainbowTable.UseVisualStyleBackColor = true;
            // 
            // textBoxRainbowTable
            // 
            this.textBoxRainbowTable.Location = new System.Drawing.Point(6, 21);
            this.textBoxRainbowTable.Name = "textBoxRainbowTable";
            this.textBoxRainbowTable.Size = new System.Drawing.Size(178, 20);
            this.textBoxRainbowTable.TabIndex = 44;
            this.textBoxRainbowTable.Text = "budakkecik";
            // 
            // radioButtonRegularRainbowTable
            // 
            this.radioButtonRegularRainbowTable.AutoSize = true;
            this.radioButtonRegularRainbowTable.Checked = true;
            this.radioButtonRegularRainbowTable.Location = new System.Drawing.Point(6, 47);
            this.radioButtonRegularRainbowTable.Name = "radioButtonRegularRainbowTable";
            this.radioButtonRegularRainbowTable.Size = new System.Drawing.Size(62, 17);
            this.radioButtonRegularRainbowTable.TabIndex = 44;
            this.radioButtonRegularRainbowTable.TabStop = true;
            this.radioButtonRegularRainbowTable.Text = "Regular";
            this.radioButtonRegularRainbowTable.UseVisualStyleBackColor = true;
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
            this.hashSelector.Location = new System.Drawing.Point(711, 287);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(179, 21);
            this.hashSelector.TabIndex = 44;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelectorRainbowTable_SelectedIndexChanged);
            // 
            // groupBoxUI
            // 
            this.groupBoxUI.Controls.Add(this.labelStatCurrentSpeed);
            this.groupBoxUI.Controls.Add(this.labelStatTimer);
            this.groupBoxUI.Controls.Add(this.labelStatAttempts);
            this.groupBoxUI.Controls.Add(this.labelStatSpeed);
            this.groupBoxUI.Location = new System.Drawing.Point(12, 287);
            this.groupBoxUI.Name = "groupBoxUI";
            this.groupBoxUI.Size = new System.Drawing.Size(216, 72);
            this.groupBoxUI.TabIndex = 43;
            this.groupBoxUI.TabStop = false;
            this.groupBoxUI.Text = "UI";
            // 
            // radioButtonRegularDictionary
            // 
            this.radioButtonRegularDictionary.AutoSize = true;
            this.radioButtonRegularDictionary.Checked = true;
            this.radioButtonRegularDictionary.Location = new System.Drawing.Point(7, 0);
            this.radioButtonRegularDictionary.Name = "radioButtonRegularDictionary";
            this.radioButtonRegularDictionary.Size = new System.Drawing.Size(62, 17);
            this.radioButtonRegularDictionary.TabIndex = 46;
            this.radioButtonRegularDictionary.Text = "Regular";
            this.radioButtonRegularDictionary.UseVisualStyleBackColor = true;
            // 
            // radioButtonHashedDictionary
            // 
            this.radioButtonHashedDictionary.AutoSize = true;
            this.radioButtonHashedDictionary.Location = new System.Drawing.Point(141, 0);
            this.radioButtonHashedDictionary.Name = "radioButtonHashedDictionary";
            this.radioButtonHashedDictionary.Size = new System.Drawing.Size(62, 17);
            this.radioButtonHashedDictionary.TabIndex = 47;
            this.radioButtonHashedDictionary.Text = "Hashed";
            this.radioButtonHashedDictionary.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonRegularDictionary);
            this.panel1.Controls.Add(this.radioButtonHashedDictionary);
            this.panel1.Location = new System.Drawing.Point(2, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(208, 19);
            this.panel1.TabIndex = 44;
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.labelAlgorithm.Location = new System.Drawing.Point(707, 268);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(50, 13);
            this.labelAlgorithm.TabIndex = 48;
            this.labelAlgorithm.Text = "Algorithm";
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 548);
            this.Controls.Add(this.labelAlgorithm);
            this.Controls.Add(this.checkBoxShowLog);
            this.Controls.Add(this.groupBoxUI);
            this.Controls.Add(this.groupBoxRainbowTable);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.checkBoxPerformanceMode);
            this.Controls.Add(this.buttonLogSave);
            this.Controls.Add(this.buttonLogClear);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.labelProgressBar);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.groupBoxBruteForce);
            this.Controls.Add(this.groupBoxTimeToCrack);
            this.Controls.Add(this.groupBoxDictionary);
            this.Name = "PasswordForm";
            this.Text = "PasswordForm";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.groupBoxDictionary.ResumeLayout(false);
            this.groupBoxDictionary.PerformLayout();
            this.groupBoxTimeToCrack.ResumeLayout(false);
            this.groupBoxTimeToCrack.PerformLayout();
            this.groupBoxBruteForce.ResumeLayout(false);
            this.groupBoxBruteForce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenght)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxAttempts)).EndInit();
            this.groupBoxRainbowTable.ResumeLayout(false);
            this.groupBoxRainbowTable.PerformLayout();
            this.groupBoxUI.ResumeLayout(false);
            this.groupBoxUI.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDictionaryAttack;
        private System.Windows.Forms.TextBox textBoxDictionary;
        private System.Windows.Forms.RadioButton radioButtonRockYouFull;
        private System.Windows.Forms.RadioButton radioButtonRockYouShort;
        private System.Windows.Forms.RadioButton radioButtonRockYouFullShortShort;
        private System.Windows.Forms.RadioButton radioButtonRockyouCustom;
        private System.Windows.Forms.GroupBox groupBoxDictionary;
        private System.Windows.Forms.GroupBox groupBoxTimeToCrack;
        private System.Windows.Forms.Button buttonCrackCalculate;
        private System.Windows.Forms.CheckBox checkBoxCrackSpecial;
        private System.Windows.Forms.CheckBox checkBoxCrackDigit;
        private System.Windows.Forms.CheckBox checkBoxCrackUpper;
        private System.Windows.Forms.CheckBox checkBoxCrackLower;
        private System.Windows.Forms.Label labelCrackSpeed;
        private System.Windows.Forms.TextBox textBoxCrackSpeed;
        private System.Windows.Forms.Label labelCrackLenght;
        private System.Windows.Forms.TextBox textBoxCrackLenght;
        private System.Windows.Forms.GroupBox groupBoxBruteForce;
        private System.Windows.Forms.TextBox textBoxBruteForce;
        private System.Windows.Forms.RadioButton radioButtonBruteForceHashed;
        private System.Windows.Forms.RadioButton radioButtonRegularBruteForce;
        private System.Windows.Forms.Button buttonBruteForceAttack;
        private System.Windows.Forms.Button buttonGenerateRainbowTable;
        private System.Windows.Forms.CheckBox checkBoxPerformanceMode;
        private System.Windows.Forms.CheckBox checkBoxSpecialChars;
        private System.Windows.Forms.CheckBox checkBoxDigits;
        private System.Windows.Forms.CheckBox checkBoxUpperCase;
        private System.Windows.Forms.CheckBox checkBoxLowerCase;
        private System.Windows.Forms.Label labelLenght;
        private System.Windows.Forms.NumericUpDown numericUpDownLenght;
        private System.Windows.Forms.Label labelMaxAttempts;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxAttempts;
        private System.Windows.Forms.Label labelStopTimer;
        private System.Windows.Forms.NumericUpDown numericUpDownStopTimer;
        private System.Windows.Forms.Label labelStatSpeed;
        private System.Windows.Forms.Label labelStatCurrentSpeed;
        private System.Windows.Forms.Label labelStatAttempts;
        private System.Windows.Forms.Label labelStatTimer;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgressBar;
        private System.Windows.Forms.CheckBox checkBoxHexOutputBruteForce;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button buttonRainbowTableAttack;
        private System.Windows.Forms.CheckBox checkBoxShowLog;
        private System.Windows.Forms.Button buttonLogClear;
        private System.Windows.Forms.Button buttonLogSave;
        private System.Windows.Forms.CheckBox checkBoxUnknownLenghtBruteForce;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.GroupBox groupBoxRainbowTable;
        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.RadioButton radioButtonHashedRainbowTable;
        private System.Windows.Forms.TextBox textBoxRainbowTable;
        private System.Windows.Forms.RadioButton radioButtonRegularRainbowTable;
        private System.Windows.Forms.GroupBox groupBoxUI;
        private System.Windows.Forms.RadioButton radioButtonHashedDictionary;
        private System.Windows.Forms.RadioButton radioButtonRegularDictionary;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelAlgorithm;
    }
}
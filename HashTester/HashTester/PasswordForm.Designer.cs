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
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonRegularDictionary = new System.Windows.Forms.RadioButton();
            this.radioButtonHashedDictionary = new System.Windows.Forms.RadioButton();
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
            this.checkBoxPerformanceMode = new System.Windows.Forms.CheckBox();
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
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.groupBoxDictionary.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxTimeToCrack.SuspendLayout();
            this.groupBoxBruteForce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenght)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxAttempts)).BeginInit();
            this.groupBoxRainbowTable.SuspendLayout();
            this.groupBoxUI.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDictionaryAttack
            // 
            this.buttonDictionaryAttack.Location = new System.Drawing.Point(8, 271);
            this.buttonDictionaryAttack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDictionaryAttack.Name = "buttonDictionaryAttack";
            this.buttonDictionaryAttack.Size = new System.Drawing.Size(265, 28);
            this.buttonDictionaryAttack.TabIndex = 0;
            this.buttonDictionaryAttack.Text = "Dictionary attack";
            this.buttonDictionaryAttack.UseVisualStyleBackColor = true;
            this.buttonDictionaryAttack.Click += new System.EventHandler(this.buttonCheckPassword_Click);
            // 
            // textBoxDictionary
            // 
            this.textBoxDictionary.Location = new System.Drawing.Point(3, 53);
            this.textBoxDictionary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDictionary.Multiline = true;
            this.textBoxDictionary.Name = "textBoxDictionary";
            this.textBoxDictionary.Size = new System.Drawing.Size(276, 94);
            this.textBoxDictionary.TabIndex = 1;
            this.textBoxDictionary.Text = "budakkecik";
            // 
            // radioButtonRockYouFull
            // 
            this.radioButtonRockYouFull.AutoSize = true;
            this.radioButtonRockYouFull.Location = new System.Drawing.Point(9, 158);
            this.radioButtonRockYouFull.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRockYouFull.Name = "radioButtonRockYouFull";
            this.radioButtonRockYouFull.Size = new System.Drawing.Size(157, 20);
            this.radioButtonRockYouFull.TabIndex = 2;
            this.radioButtonRockYouFull.Text = "rockyou.txt full version";
            this.radioButtonRockYouFull.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockYouShort
            // 
            this.radioButtonRockYouShort.AutoSize = true;
            this.radioButtonRockYouShort.Location = new System.Drawing.Point(9, 186);
            this.radioButtonRockYouShort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRockYouShort.Name = "radioButtonRockYouShort";
            this.radioButtonRockYouShort.Size = new System.Drawing.Size(170, 20);
            this.radioButtonRockYouShort.TabIndex = 3;
            this.radioButtonRockYouShort.Text = "rockyou.txt short version";
            this.radioButtonRockYouShort.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockYouFullShortShort
            // 
            this.radioButtonRockYouFullShortShort.AutoSize = true;
            this.radioButtonRockYouFullShortShort.Location = new System.Drawing.Point(9, 214);
            this.radioButtonRockYouFullShortShort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRockYouFullShortShort.Name = "radioButtonRockYouFullShortShort";
            this.radioButtonRockYouFullShortShort.Size = new System.Drawing.Size(199, 20);
            this.radioButtonRockYouFullShortShort.TabIndex = 4;
            this.radioButtonRockYouFullShortShort.Text = "rockyou.txt very short version";
            this.radioButtonRockYouFullShortShort.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockyouCustom
            // 
            this.radioButtonRockyouCustom.AutoSize = true;
            this.radioButtonRockyouCustom.Location = new System.Drawing.Point(8, 242);
            this.radioButtonRockyouCustom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRockyouCustom.Name = "radioButtonRockyouCustom";
            this.radioButtonRockyouCustom.Size = new System.Drawing.Size(91, 20);
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
            this.groupBoxDictionary.Location = new System.Drawing.Point(16, 15);
            this.groupBoxDictionary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDictionary.Name = "groupBoxDictionary";
            this.groupBoxDictionary.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDictionary.Size = new System.Drawing.Size(288, 311);
            this.groupBoxDictionary.TabIndex = 7;
            this.groupBoxDictionary.TabStop = false;
            this.groupBoxDictionary.Text = "Dictionary Attack";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonRegularDictionary);
            this.panel1.Controls.Add(this.radioButtonHashedDictionary);
            this.panel1.Location = new System.Drawing.Point(3, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(277, 23);
            this.panel1.TabIndex = 44;
            // 
            // radioButtonRegularDictionary
            // 
            this.radioButtonRegularDictionary.AutoSize = true;
            this.radioButtonRegularDictionary.Checked = true;
            this.radioButtonRegularDictionary.Location = new System.Drawing.Point(9, 0);
            this.radioButtonRegularDictionary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRegularDictionary.Name = "radioButtonRegularDictionary";
            this.radioButtonRegularDictionary.Size = new System.Drawing.Size(76, 20);
            this.radioButtonRegularDictionary.TabIndex = 46;
            this.radioButtonRegularDictionary.TabStop = true;
            this.radioButtonRegularDictionary.Text = "Regular";
            this.radioButtonRegularDictionary.UseVisualStyleBackColor = true;
            // 
            // radioButtonHashedDictionary
            // 
            this.radioButtonHashedDictionary.AutoSize = true;
            this.radioButtonHashedDictionary.Location = new System.Drawing.Point(188, 0);
            this.radioButtonHashedDictionary.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonHashedDictionary.Name = "radioButtonHashedDictionary";
            this.radioButtonHashedDictionary.Size = new System.Drawing.Size(76, 20);
            this.radioButtonHashedDictionary.TabIndex = 47;
            this.radioButtonHashedDictionary.Text = "Hashed";
            this.radioButtonHashedDictionary.UseVisualStyleBackColor = true;
            // 
            // checkBoxShowLog
            // 
            this.checkBoxShowLog.AutoSize = true;
            this.checkBoxShowLog.Checked = true;
            this.checkBoxShowLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowLog.Location = new System.Drawing.Point(948, 386);
            this.checkBoxShowLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxShowLog.Name = "checkBoxShowLog";
            this.checkBoxShowLog.Size = new System.Drawing.Size(139, 20);
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
            this.groupBoxTimeToCrack.Location = new System.Drawing.Point(313, 16);
            this.groupBoxTimeToCrack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTimeToCrack.Name = "groupBoxTimeToCrack";
            this.groupBoxTimeToCrack.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxTimeToCrack.Size = new System.Drawing.Size(204, 310);
            this.groupBoxTimeToCrack.TabIndex = 8;
            this.groupBoxTimeToCrack.TabStop = false;
            this.groupBoxTimeToCrack.Text = "Brute force attack estimator";
            // 
            // buttonCrackCalculate
            // 
            this.buttonCrackCalculate.Location = new System.Drawing.Point(8, 270);
            this.buttonCrackCalculate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCrackCalculate.Name = "buttonCrackCalculate";
            this.buttonCrackCalculate.Size = new System.Drawing.Size(188, 28);
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
            this.checkBoxCrackSpecial.Location = new System.Drawing.Point(8, 210);
            this.checkBoxCrackSpecial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCrackSpecial.Name = "checkBoxCrackSpecial";
            this.checkBoxCrackSpecial.Size = new System.Drawing.Size(148, 20);
            this.checkBoxCrackSpecial.TabIndex = 7;
            this.checkBoxCrackSpecial.Text = "Speciální znaky (33)";
            this.checkBoxCrackSpecial.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrackDigit
            // 
            this.checkBoxCrackDigit.AutoSize = true;
            this.checkBoxCrackDigit.Checked = true;
            this.checkBoxCrackDigit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackDigit.Location = new System.Drawing.Point(8, 182);
            this.checkBoxCrackDigit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCrackDigit.Name = "checkBoxCrackDigit";
            this.checkBoxCrackDigit.Size = new System.Drawing.Size(94, 20);
            this.checkBoxCrackDigit.TabIndex = 6;
            this.checkBoxCrackDigit.Text = "Číslice (10)";
            this.checkBoxCrackDigit.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrackUpper
            // 
            this.checkBoxCrackUpper.AutoSize = true;
            this.checkBoxCrackUpper.Checked = true;
            this.checkBoxCrackUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackUpper.Location = new System.Drawing.Point(8, 154);
            this.checkBoxCrackUpper.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCrackUpper.Name = "checkBoxCrackUpper";
            this.checkBoxCrackUpper.Size = new System.Drawing.Size(144, 20);
            this.checkBoxCrackUpper.TabIndex = 5;
            this.checkBoxCrackUpper.Text = "Velká písmena (26)";
            this.checkBoxCrackUpper.UseVisualStyleBackColor = true;
            // 
            // checkBoxCrackLower
            // 
            this.checkBoxCrackLower.AutoSize = true;
            this.checkBoxCrackLower.Checked = true;
            this.checkBoxCrackLower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackLower.Location = new System.Drawing.Point(8, 126);
            this.checkBoxCrackLower.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxCrackLower.Name = "checkBoxCrackLower";
            this.checkBoxCrackLower.Size = new System.Drawing.Size(139, 20);
            this.checkBoxCrackLower.TabIndex = 4;
            this.checkBoxCrackLower.Text = "Malá písmena (26)";
            this.checkBoxCrackLower.UseVisualStyleBackColor = true;
            // 
            // labelCrackSpeed
            // 
            this.labelCrackSpeed.AutoSize = true;
            this.labelCrackSpeed.Location = new System.Drawing.Point(8, 73);
            this.labelCrackSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCrackSpeed.Name = "labelCrackSpeed";
            this.labelCrackSpeed.Size = new System.Drawing.Size(103, 16);
            this.labelCrackSpeed.TabIndex = 3;
            this.labelCrackSpeed.Text = "Počet pokusů /s";
            // 
            // textBoxCrackSpeed
            // 
            this.textBoxCrackSpeed.Location = new System.Drawing.Point(8, 92);
            this.textBoxCrackSpeed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCrackSpeed.Name = "textBoxCrackSpeed";
            this.textBoxCrackSpeed.Size = new System.Drawing.Size(187, 22);
            this.textBoxCrackSpeed.TabIndex = 2;
            this.textBoxCrackSpeed.Text = "2000000000";
            // 
            // labelCrackLenght
            // 
            this.labelCrackLenght.AutoSize = true;
            this.labelCrackLenght.Location = new System.Drawing.Point(8, 22);
            this.labelCrackLenght.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCrackLenght.Name = "labelCrackLenght";
            this.labelCrackLenght.Size = new System.Drawing.Size(120, 16);
            this.labelCrackLenght.TabIndex = 1;
            this.labelCrackLenght.Text = "Počet znaků/ heslo";
            // 
            // textBoxCrackLenght
            // 
            this.textBoxCrackLenght.Location = new System.Drawing.Point(8, 42);
            this.textBoxCrackLenght.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCrackLenght.Name = "textBoxCrackLenght";
            this.textBoxCrackLenght.Size = new System.Drawing.Size(187, 22);
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
            this.groupBoxBruteForce.Location = new System.Drawing.Point(787, 15);
            this.groupBoxBruteForce.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBruteForce.Name = "groupBoxBruteForce";
            this.groupBoxBruteForce.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxBruteForce.Size = new System.Drawing.Size(401, 310);
            this.groupBoxBruteForce.TabIndex = 9;
            this.groupBoxBruteForce.TabStop = false;
            this.groupBoxBruteForce.Text = "Brute force attack";
            // 
            // checkBoxUnknownLenghtBruteForce
            // 
            this.checkBoxUnknownLenghtBruteForce.AutoSize = true;
            this.checkBoxUnknownLenghtBruteForce.Location = new System.Drawing.Point(9, 158);
            this.checkBoxUnknownLenghtBruteForce.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxUnknownLenghtBruteForce.Name = "checkBoxUnknownLenghtBruteForce";
            this.checkBoxUnknownLenghtBruteForce.Size = new System.Drawing.Size(127, 20);
            this.checkBoxUnknownLenghtBruteForce.TabIndex = 42;
            this.checkBoxUnknownLenghtBruteForce.Text = "Unknown Lenght";
            this.checkBoxUnknownLenghtBruteForce.UseVisualStyleBackColor = true;
            // 
            // checkBoxHexOutputBruteForce
            // 
            this.checkBoxHexOutputBruteForce.AutoSize = true;
            this.checkBoxHexOutputBruteForce.Checked = true;
            this.checkBoxHexOutputBruteForce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHexOutputBruteForce.Location = new System.Drawing.Point(9, 186);
            this.checkBoxHexOutputBruteForce.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxHexOutputBruteForce.Name = "checkBoxHexOutputBruteForce";
            this.checkBoxHexOutputBruteForce.Size = new System.Drawing.Size(185, 20);
            this.checkBoxHexOutputBruteForce.TabIndex = 37;
            this.checkBoxHexOutputBruteForce.Text = "Display password as HEX";
            this.checkBoxHexOutputBruteForce.UseVisualStyleBackColor = true;
            // 
            // labelStopTimer
            // 
            this.labelStopTimer.AutoSize = true;
            this.labelStopTimer.Location = new System.Drawing.Point(263, 53);
            this.labelStopTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStopTimer.Name = "labelStopTimer";
            this.labelStopTimer.Size = new System.Drawing.Size(106, 16);
            this.labelStopTimer.TabIndex = 36;
            this.labelStopTimer.Text = "Stop Timer (sec)";
            // 
            // numericUpDownStopTimer
            // 
            this.numericUpDownStopTimer.Location = new System.Drawing.Point(179, 74);
            this.numericUpDownStopTimer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownStopTimer.Maximum = new decimal(new int[] {
            172800,
            0,
            0,
            0});
            this.numericUpDownStopTimer.Name = "numericUpDownStopTimer";
            this.numericUpDownStopTimer.Size = new System.Drawing.Size(196, 22);
            this.numericUpDownStopTimer.TabIndex = 35;
            this.numericUpDownStopTimer.ThousandsSeparator = true;
            // 
            // checkBoxSpecialChars
            // 
            this.checkBoxSpecialChars.AutoSize = true;
            this.checkBoxSpecialChars.Checked = true;
            this.checkBoxSpecialChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSpecialChars.Location = new System.Drawing.Point(223, 239);
            this.checkBoxSpecialChars.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxSpecialChars.Name = "checkBoxSpecialChars";
            this.checkBoxSpecialChars.Size = new System.Drawing.Size(148, 20);
            this.checkBoxSpecialChars.TabIndex = 12;
            this.checkBoxSpecialChars.Text = "Speciální znaky (33)";
            this.checkBoxSpecialChars.UseVisualStyleBackColor = true;
            // 
            // buttonBruteForceAttack
            // 
            this.buttonBruteForceAttack.Location = new System.Drawing.Point(7, 270);
            this.buttonBruteForceAttack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonBruteForceAttack.Name = "buttonBruteForceAttack";
            this.buttonBruteForceAttack.Size = new System.Drawing.Size(380, 28);
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
            this.checkBoxDigits.Location = new System.Drawing.Point(223, 210);
            this.checkBoxDigits.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxDigits.Name = "checkBoxDigits";
            this.checkBoxDigits.Size = new System.Drawing.Size(94, 20);
            this.checkBoxDigits.TabIndex = 11;
            this.checkBoxDigits.Text = "Číslice (10)";
            this.checkBoxDigits.UseVisualStyleBackColor = true;
            // 
            // checkBoxUpperCase
            // 
            this.checkBoxUpperCase.AutoSize = true;
            this.checkBoxUpperCase.Checked = true;
            this.checkBoxUpperCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpperCase.Location = new System.Drawing.Point(223, 182);
            this.checkBoxUpperCase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxUpperCase.Name = "checkBoxUpperCase";
            this.checkBoxUpperCase.Size = new System.Drawing.Size(144, 20);
            this.checkBoxUpperCase.TabIndex = 10;
            this.checkBoxUpperCase.Text = "Velká písmena (26)";
            this.checkBoxUpperCase.UseVisualStyleBackColor = true;
            // 
            // checkBoxLowerCase
            // 
            this.checkBoxLowerCase.AutoSize = true;
            this.checkBoxLowerCase.Checked = true;
            this.checkBoxLowerCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLowerCase.Location = new System.Drawing.Point(223, 154);
            this.checkBoxLowerCase.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxLowerCase.Name = "checkBoxLowerCase";
            this.checkBoxLowerCase.Size = new System.Drawing.Size(139, 20);
            this.checkBoxLowerCase.TabIndex = 9;
            this.checkBoxLowerCase.Text = "Malá písmena (26)";
            this.checkBoxLowerCase.UseVisualStyleBackColor = true;
            // 
            // labelLenght
            // 
            this.labelLenght.AutoSize = true;
            this.labelLenght.Location = new System.Drawing.Point(8, 102);
            this.labelLenght.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLenght.Name = "labelLenght";
            this.labelLenght.Size = new System.Drawing.Size(47, 16);
            this.labelLenght.TabIndex = 31;
            this.labelLenght.Text = "Lenght";
            // 
            // radioButtonBruteForceHashed
            // 
            this.radioButtonBruteForceHashed.AutoSize = true;
            this.radioButtonBruteForceHashed.Location = new System.Drawing.Point(13, 73);
            this.radioButtonBruteForceHashed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonBruteForceHashed.Name = "radioButtonBruteForceHashed";
            this.radioButtonBruteForceHashed.Size = new System.Drawing.Size(76, 20);
            this.radioButtonBruteForceHashed.TabIndex = 8;
            this.radioButtonBruteForceHashed.Text = "Hashed";
            this.radioButtonBruteForceHashed.UseVisualStyleBackColor = true;
            this.radioButtonBruteForceHashed.EnabledChanged += new System.EventHandler(this.radioButton6_EnabledChanged);
            // 
            // numericUpDownLenght
            // 
            this.numericUpDownLenght.Location = new System.Drawing.Point(9, 124);
            this.numericUpDownLenght.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownLenght.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownLenght.Name = "numericUpDownLenght";
            this.numericUpDownLenght.Size = new System.Drawing.Size(143, 22);
            this.numericUpDownLenght.TabIndex = 30;
            this.numericUpDownLenght.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLenght.ValueChanged += new System.EventHandler(this.numericUpDownLenght_ValueChanged);
            // 
            // radioButtonRegularBruteForce
            // 
            this.radioButtonRegularBruteForce.AutoSize = true;
            this.radioButtonRegularBruteForce.Checked = true;
            this.radioButtonRegularBruteForce.Location = new System.Drawing.Point(12, 50);
            this.radioButtonRegularBruteForce.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRegularBruteForce.Name = "radioButtonRegularBruteForce";
            this.radioButtonRegularBruteForce.Size = new System.Drawing.Size(76, 20);
            this.radioButtonRegularBruteForce.TabIndex = 7;
            this.radioButtonRegularBruteForce.TabStop = true;
            this.radioButtonRegularBruteForce.Text = "Regular";
            this.radioButtonRegularBruteForce.UseVisualStyleBackColor = true;
            this.radioButtonRegularBruteForce.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // labelMaxAttempts
            // 
            this.labelMaxAttempts.AutoSize = true;
            this.labelMaxAttempts.Location = new System.Drawing.Point(253, 101);
            this.labelMaxAttempts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMaxAttempts.Name = "labelMaxAttempts";
            this.labelMaxAttempts.Size = new System.Drawing.Size(119, 16);
            this.labelMaxAttempts.TabIndex = 29;
            this.labelMaxAttempts.Text = "Maximum Attempts";
            // 
            // numericUpDownMaxAttempts
            // 
            this.numericUpDownMaxAttempts.Location = new System.Drawing.Point(179, 121);
            this.numericUpDownMaxAttempts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDownMaxAttempts.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericUpDownMaxAttempts.Name = "numericUpDownMaxAttempts";
            this.numericUpDownMaxAttempts.Size = new System.Drawing.Size(196, 22);
            this.numericUpDownMaxAttempts.TabIndex = 28;
            this.numericUpDownMaxAttempts.ThousandsSeparator = true;
            // 
            // textBoxBruteForce
            // 
            this.textBoxBruteForce.Location = new System.Drawing.Point(9, 25);
            this.textBoxBruteForce.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxBruteForce.Name = "textBoxBruteForce";
            this.textBoxBruteForce.Size = new System.Drawing.Size(364, 22);
            this.textBoxBruteForce.TabIndex = 0;
            this.textBoxBruteForce.Text = "budakkecik";
            this.textBoxBruteForce.TextChanged += new System.EventHandler(this.textBoxBruteForceInput_TextChanged);
            // 
            // checkBoxPerformanceMode
            // 
            this.checkBoxPerformanceMode.AutoSize = true;
            this.checkBoxPerformanceMode.Location = new System.Drawing.Point(947, 415);
            this.checkBoxPerformanceMode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxPerformanceMode.Name = "checkBoxPerformanceMode";
            this.checkBoxPerformanceMode.Size = new System.Drawing.Size(141, 20);
            this.checkBoxPerformanceMode.TabIndex = 34;
            this.checkBoxPerformanceMode.Text = "PerformanceMode";
            this.checkBoxPerformanceMode.UseVisualStyleBackColor = true;
            // 
            // buttonRainbowTableAttack
            // 
            this.buttonRainbowTableAttack.Location = new System.Drawing.Point(9, 266);
            this.buttonRainbowTableAttack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRainbowTableAttack.Name = "buttonRainbowTableAttack";
            this.buttonRainbowTableAttack.Size = new System.Drawing.Size(237, 28);
            this.buttonRainbowTableAttack.TabIndex = 38;
            this.buttonRainbowTableAttack.Text = "Rainbow Table Attack";
            this.buttonRainbowTableAttack.UseVisualStyleBackColor = true;
            this.buttonRainbowTableAttack.Click += new System.EventHandler(this.buttonRainbowTableAttack_Click);
            // 
            // buttonGenerateRainbowTable
            // 
            this.buttonGenerateRainbowTable.Location = new System.Drawing.Point(11, 233);
            this.buttonGenerateRainbowTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonGenerateRainbowTable.Name = "buttonGenerateRainbowTable";
            this.buttonGenerateRainbowTable.Size = new System.Drawing.Size(235, 28);
            this.buttonGenerateRainbowTable.TabIndex = 10;
            this.buttonGenerateRainbowTable.Text = "Generate Rainbow Table";
            this.buttonGenerateRainbowTable.UseVisualStyleBackColor = true;
            this.buttonGenerateRainbowTable.Click += new System.EventHandler(this.buttonPreHash_Click);
            // 
            // labelStatSpeed
            // 
            this.labelStatSpeed.AutoSize = true;
            this.labelStatSpeed.Location = new System.Drawing.Point(7, 66);
            this.labelStatSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatSpeed.Name = "labelStatSpeed";
            this.labelStatSpeed.Size = new System.Drawing.Size(121, 16);
            this.labelStatSpeed.TabIndex = 28;
            this.labelStatSpeed.Text = "Average speed /s: ";
            // 
            // labelStatCurrentSpeed
            // 
            this.labelStatCurrentSpeed.AutoSize = true;
            this.labelStatCurrentSpeed.Location = new System.Drawing.Point(8, 50);
            this.labelStatCurrentSpeed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatCurrentSpeed.Name = "labelStatCurrentSpeed";
            this.labelStatCurrentSpeed.Size = new System.Drawing.Size(111, 16);
            this.labelStatCurrentSpeed.TabIndex = 27;
            this.labelStatCurrentSpeed.Text = "Current speed /s: ";
            // 
            // labelStatAttempts
            // 
            this.labelStatAttempts.AutoSize = true;
            this.labelStatAttempts.Location = new System.Drawing.Point(7, 33);
            this.labelStatAttempts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatAttempts.Name = "labelStatAttempts";
            this.labelStatAttempts.Size = new System.Drawing.Size(129, 16);
            this.labelStatAttempts.TabIndex = 26;
            this.labelStatAttempts.Text = "Number of attempts: ";
            // 
            // labelStatTimer
            // 
            this.labelStatTimer.AutoSize = true;
            this.labelStatTimer.Location = new System.Drawing.Point(7, 17);
            this.labelStatTimer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatTimer.Name = "labelStatTimer";
            this.labelStatTimer.Size = new System.Drawing.Size(48, 16);
            this.labelStatTimer.TabIndex = 25;
            this.labelStatTimer.Text = "Timer: ";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(948, 441);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(240, 28);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Abort The Process";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Location = new System.Drawing.Point(19, 476);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1172, 28);
            this.progressBar1.TabIndex = 36;
            // 
            // labelProgressBar
            // 
            this.labelProgressBar.AutoSize = true;
            this.labelProgressBar.Location = new System.Drawing.Point(524, 457);
            this.labelProgressBar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelProgressBar.Name = "labelProgressBar";
            this.labelProgressBar.Size = new System.Drawing.Size(86, 16);
            this.labelProgressBar.TabIndex = 37;
            this.labelProgressBar.Text = "Progress Bar";
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 16;
            this.listBoxLog.Location = new System.Drawing.Point(19, 512);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(1169, 116);
            this.listBoxLog.TabIndex = 38;
            // 
            // buttonLogClear
            // 
            this.buttonLogClear.Location = new System.Drawing.Point(19, 636);
            this.buttonLogClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(381, 28);
            this.buttonLogClear.TabIndex = 39;
            this.buttonLogClear.Text = "Clear Log";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            this.buttonLogClear.Click += new System.EventHandler(this.buttonLogClear_Click);
            // 
            // buttonLogSave
            // 
            this.buttonLogSave.Location = new System.Drawing.Point(408, 636);
            this.buttonLogSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogSave.Name = "buttonLogSave";
            this.buttonLogSave.Size = new System.Drawing.Size(381, 28);
            this.buttonLogSave.TabIndex = 40;
            this.buttonLogSave.Text = "Save Log";
            this.buttonLogSave.UseVisualStyleBackColor = true;
            this.buttonLogSave.Click += new System.EventHandler(this.buttonLogSave_Click);
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(808, 636);
            this.buttonClipboard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(381, 28);
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
            this.groupBoxRainbowTable.Location = new System.Drawing.Point(525, 16);
            this.groupBoxRainbowTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRainbowTable.Name = "groupBoxRainbowTable";
            this.groupBoxRainbowTable.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRainbowTable.Size = new System.Drawing.Size(255, 310);
            this.groupBoxRainbowTable.TabIndex = 42;
            this.groupBoxRainbowTable.TabStop = false;
            this.groupBoxRainbowTable.Text = "Rainbow table attack";
            // 
            // radioButtonHashedRainbowTable
            // 
            this.radioButtonHashedRainbowTable.AutoSize = true;
            this.radioButtonHashedRainbowTable.Location = new System.Drawing.Point(9, 80);
            this.radioButtonHashedRainbowTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonHashedRainbowTable.Name = "radioButtonHashedRainbowTable";
            this.radioButtonHashedRainbowTable.Size = new System.Drawing.Size(76, 20);
            this.radioButtonHashedRainbowTable.TabIndex = 45;
            this.radioButtonHashedRainbowTable.Text = "Hashed";
            this.radioButtonHashedRainbowTable.UseVisualStyleBackColor = true;
            // 
            // textBoxRainbowTable
            // 
            this.textBoxRainbowTable.Location = new System.Drawing.Point(8, 26);
            this.textBoxRainbowTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxRainbowTable.Name = "textBoxRainbowTable";
            this.textBoxRainbowTable.Size = new System.Drawing.Size(236, 22);
            this.textBoxRainbowTable.TabIndex = 44;
            this.textBoxRainbowTable.Text = "budakkecik";
            // 
            // radioButtonRegularRainbowTable
            // 
            this.radioButtonRegularRainbowTable.AutoSize = true;
            this.radioButtonRegularRainbowTable.Checked = true;
            this.radioButtonRegularRainbowTable.Location = new System.Drawing.Point(8, 58);
            this.radioButtonRegularRainbowTable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonRegularRainbowTable.Name = "radioButtonRegularRainbowTable";
            this.radioButtonRegularRainbowTable.Size = new System.Drawing.Size(76, 20);
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
            this.hashSelector.Location = new System.Drawing.Point(948, 353);
            this.hashSelector.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(237, 24);
            this.hashSelector.TabIndex = 44;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelectorRainbowTable_SelectedIndexChanged);
            // 
            // groupBoxUI
            // 
            this.groupBoxUI.Controls.Add(this.labelStatCurrentSpeed);
            this.groupBoxUI.Controls.Add(this.labelStatTimer);
            this.groupBoxUI.Controls.Add(this.labelStatAttempts);
            this.groupBoxUI.Controls.Add(this.labelStatSpeed);
            this.groupBoxUI.Location = new System.Drawing.Point(16, 353);
            this.groupBoxUI.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxUI.Name = "groupBoxUI";
            this.groupBoxUI.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxUI.Size = new System.Drawing.Size(288, 89);
            this.groupBoxUI.TabIndex = 43;
            this.groupBoxUI.TabStop = false;
            this.groupBoxUI.Text = "UI";
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.labelAlgorithm.Location = new System.Drawing.Point(943, 330);
            this.labelAlgorithm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(63, 16);
            this.labelAlgorithm.TabIndex = 48;
            this.labelAlgorithm.Text = "Algorithm";
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 674);
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
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PasswordForm";
            this.Text = "PasswordForm";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.groupBoxDictionary.ResumeLayout(false);
            this.groupBoxDictionary.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
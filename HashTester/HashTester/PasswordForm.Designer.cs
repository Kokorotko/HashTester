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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonHashedDictionary = new System.Windows.Forms.RadioButton();
            this.radioButtonRegularDictionary = new System.Windows.Forms.RadioButton();
            this.groupBoxTimeToCrack = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCrackCalculate = new System.Windows.Forms.Button();
            this.labelCrackLenght = new System.Windows.Forms.Label();
            this.checkBoxCrackSpecial = new System.Windows.Forms.CheckBox();
            this.textBoxCrackLenght = new System.Windows.Forms.TextBox();
            this.checkBoxCrackDigit = new System.Windows.Forms.CheckBox();
            this.labelCrackSpeed = new System.Windows.Forms.Label();
            this.checkBoxCrackUpper = new System.Windows.Forms.CheckBox();
            this.textBoxCrackSpeed = new System.Windows.Forms.TextBox();
            this.checkBoxCrackLower = new System.Windows.Forms.CheckBox();
            this.groupBoxBruteForce = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonBruteForceAttack = new System.Windows.Forms.Button();
            this.checkBoxSpecialChars = new System.Windows.Forms.CheckBox();
            this.checkBoxHexOutputBruteForce = new System.Windows.Forms.CheckBox();
            this.checkBoxUnknownLenghtBruteForce = new System.Windows.Forms.CheckBox();
            this.checkBoxDigits = new System.Windows.Forms.CheckBox();
            this.textBoxBruteForce = new System.Windows.Forms.TextBox();
            this.checkBoxUpperCase = new System.Windows.Forms.CheckBox();
            this.radioButtonRegularBruteForce = new System.Windows.Forms.RadioButton();
            this.checkBoxLowerCase = new System.Windows.Forms.CheckBox();
            this.numericUpDownStopTimer = new System.Windows.Forms.NumericUpDown();
            this.labelStopTimer = new System.Windows.Forms.Label();
            this.radioButtonBruteForceHashed = new System.Windows.Forms.RadioButton();
            this.labelMaxAttempts = new System.Windows.Forms.Label();
            this.numericUpDownMaxAttempts = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownLenght = new System.Windows.Forms.NumericUpDown();
            this.labelLenght = new System.Windows.Forms.Label();
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
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonHashedRainbowTable = new System.Windows.Forms.RadioButton();
            this.radioButtonRegularRainbowTable = new System.Windows.Forms.RadioButton();
            this.textBoxRainbowTable = new System.Windows.Forms.TextBox();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.groupBoxUI = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxDictionary.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxTimeToCrack.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBoxBruteForce.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenght)).BeginInit();
            this.groupBoxRainbowTable.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBoxUI.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDictionaryAttack
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonDictionaryAttack, 2);
            this.buttonDictionaryAttack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDictionaryAttack.Location = new System.Drawing.Point(3, 248);
            this.buttonDictionaryAttack.Name = "buttonDictionaryAttack";
            this.buttonDictionaryAttack.Size = new System.Drawing.Size(243, 54);
            this.buttonDictionaryAttack.TabIndex = 0;
            this.buttonDictionaryAttack.Text = "Dictionary attack";
            this.buttonDictionaryAttack.UseVisualStyleBackColor = true;
            this.buttonDictionaryAttack.Click += new System.EventHandler(this.buttonCheckPassword_Click);
            // 
            // textBoxDictionary
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxDictionary, 2);
            this.textBoxDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDictionary.Location = new System.Drawing.Point(3, 30);
            this.textBoxDictionary.Multiline = true;
            this.textBoxDictionary.Name = "textBoxDictionary";
            this.textBoxDictionary.Size = new System.Drawing.Size(243, 104);
            this.textBoxDictionary.TabIndex = 1;
            this.textBoxDictionary.Text = "budakkecik";
            // 
            // radioButtonRockYouFull
            // 
            this.radioButtonRockYouFull.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButtonRockYouFull, 2);
            this.radioButtonRockYouFull.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonRockYouFull.Location = new System.Drawing.Point(3, 140);
            this.radioButtonRockYouFull.Name = "radioButtonRockYouFull";
            this.radioButtonRockYouFull.Size = new System.Drawing.Size(243, 21);
            this.radioButtonRockYouFull.TabIndex = 2;
            this.radioButtonRockYouFull.Text = "rockyou.txt full version";
            this.radioButtonRockYouFull.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockYouShort
            // 
            this.radioButtonRockYouShort.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButtonRockYouShort, 2);
            this.radioButtonRockYouShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonRockYouShort.Location = new System.Drawing.Point(3, 167);
            this.radioButtonRockYouShort.Name = "radioButtonRockYouShort";
            this.radioButtonRockYouShort.Size = new System.Drawing.Size(243, 21);
            this.radioButtonRockYouShort.TabIndex = 3;
            this.radioButtonRockYouShort.Text = "rockyou.txt short version";
            this.radioButtonRockYouShort.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockYouFullShortShort
            // 
            this.radioButtonRockYouFullShortShort.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButtonRockYouFullShortShort, 2);
            this.radioButtonRockYouFullShortShort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonRockYouFullShortShort.Location = new System.Drawing.Point(3, 194);
            this.radioButtonRockYouFullShortShort.Name = "radioButtonRockYouFullShortShort";
            this.radioButtonRockYouFullShortShort.Size = new System.Drawing.Size(243, 21);
            this.radioButtonRockYouFullShortShort.TabIndex = 4;
            this.radioButtonRockYouFullShortShort.Text = "rockyou.txt very short version";
            this.radioButtonRockYouFullShortShort.UseVisualStyleBackColor = true;
            // 
            // radioButtonRockyouCustom
            // 
            this.radioButtonRockyouCustom.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButtonRockyouCustom, 2);
            this.radioButtonRockyouCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonRockyouCustom.Location = new System.Drawing.Point(3, 221);
            this.radioButtonRockyouCustom.Name = "radioButtonRockyouCustom";
            this.radioButtonRockyouCustom.Size = new System.Drawing.Size(243, 21);
            this.radioButtonRockyouCustom.TabIndex = 5;
            this.radioButtonRockyouCustom.Text = "Custom .txt";
            this.radioButtonRockyouCustom.UseVisualStyleBackColor = true;
            // 
            // groupBoxDictionary
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.groupBoxDictionary, 3);
            this.groupBoxDictionary.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDictionary.Location = new System.Drawing.Point(3, 3);
            this.groupBoxDictionary.Name = "groupBoxDictionary";
            this.groupBoxDictionary.Size = new System.Drawing.Size(255, 324);
            this.groupBoxDictionary.TabIndex = 7;
            this.groupBoxDictionary.TabStop = false;
            this.groupBoxDictionary.Text = "Dictionary Attack";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonHashedDictionary, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonDictionaryAttack, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonRegularDictionary, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonRockyouCustom, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxDictionary, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonRockYouFullShortShort, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonRockYouFull, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonRockYouShort, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.36364F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 305);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // radioButtonHashedDictionary
            // 
            this.radioButtonHashedDictionary.AutoSize = true;
            this.radioButtonHashedDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonHashedDictionary.Location = new System.Drawing.Point(127, 3);
            this.radioButtonHashedDictionary.Name = "radioButtonHashedDictionary";
            this.radioButtonHashedDictionary.Size = new System.Drawing.Size(119, 21);
            this.radioButtonHashedDictionary.TabIndex = 47;
            this.radioButtonHashedDictionary.Text = "Hashed";
            this.radioButtonHashedDictionary.UseVisualStyleBackColor = true;
            // 
            // radioButtonRegularDictionary
            // 
            this.radioButtonRegularDictionary.AutoSize = true;
            this.radioButtonRegularDictionary.Checked = true;
            this.radioButtonRegularDictionary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonRegularDictionary.Location = new System.Drawing.Point(3, 3);
            this.radioButtonRegularDictionary.Name = "radioButtonRegularDictionary";
            this.radioButtonRegularDictionary.Size = new System.Drawing.Size(118, 21);
            this.radioButtonRegularDictionary.TabIndex = 46;
            this.radioButtonRegularDictionary.TabStop = true;
            this.radioButtonRegularDictionary.Text = "Regular";
            this.radioButtonRegularDictionary.UseVisualStyleBackColor = true;
            // 
            // groupBoxTimeToCrack
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.groupBoxTimeToCrack, 3);
            this.groupBoxTimeToCrack.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxTimeToCrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTimeToCrack.Location = new System.Drawing.Point(264, 3);
            this.groupBoxTimeToCrack.Name = "groupBoxTimeToCrack";
            this.groupBoxTimeToCrack.Size = new System.Drawing.Size(255, 324);
            this.groupBoxTimeToCrack.TabIndex = 8;
            this.groupBoxTimeToCrack.TabStop = false;
            this.groupBoxTimeToCrack.Text = "Brute force attack estimator";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.buttonCrackCalculate, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.labelCrackLenght, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxCrackSpecial, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBoxCrackLenght, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxCrackDigit, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.labelCrackSpeed, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxCrackUpper, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.textBoxCrackSpeed, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.checkBoxCrackLower, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(249, 305);
            this.tableLayoutPanel2.TabIndex = 49;
            // 
            // buttonCrackCalculate
            // 
            this.buttonCrackCalculate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCrackCalculate.Location = new System.Drawing.Point(3, 253);
            this.buttonCrackCalculate.Name = "buttonCrackCalculate";
            this.buttonCrackCalculate.Size = new System.Drawing.Size(243, 49);
            this.buttonCrackCalculate.TabIndex = 8;
            this.buttonCrackCalculate.Text = "Calculate";
            this.buttonCrackCalculate.UseVisualStyleBackColor = true;
            this.buttonCrackCalculate.Click += new System.EventHandler(this.buttonCrackCalculate_Click);
            // 
            // labelCrackLenght
            // 
            this.labelCrackLenght.AutoSize = true;
            this.labelCrackLenght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCrackLenght.Location = new System.Drawing.Point(3, 0);
            this.labelCrackLenght.Name = "labelCrackLenght";
            this.labelCrackLenght.Size = new System.Drawing.Size(243, 25);
            this.labelCrackLenght.TabIndex = 1;
            this.labelCrackLenght.Text = "Počet znaků/ heslo";
            this.labelCrackLenght.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // checkBoxCrackSpecial
            // 
            this.checkBoxCrackSpecial.AutoSize = true;
            this.checkBoxCrackSpecial.Checked = true;
            this.checkBoxCrackSpecial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackSpecial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCrackSpecial.Location = new System.Drawing.Point(3, 228);
            this.checkBoxCrackSpecial.Name = "checkBoxCrackSpecial";
            this.checkBoxCrackSpecial.Size = new System.Drawing.Size(243, 19);
            this.checkBoxCrackSpecial.TabIndex = 7;
            this.checkBoxCrackSpecial.Text = "Speciální znaky (33)";
            this.checkBoxCrackSpecial.UseVisualStyleBackColor = true;
            // 
            // textBoxCrackLenght
            // 
            this.textBoxCrackLenght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCrackLenght.Location = new System.Drawing.Point(3, 28);
            this.textBoxCrackLenght.Name = "textBoxCrackLenght";
            this.textBoxCrackLenght.Size = new System.Drawing.Size(243, 20);
            this.textBoxCrackLenght.TabIndex = 0;
            // 
            // checkBoxCrackDigit
            // 
            this.checkBoxCrackDigit.AutoSize = true;
            this.checkBoxCrackDigit.Checked = true;
            this.checkBoxCrackDigit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackDigit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCrackDigit.Location = new System.Drawing.Point(3, 203);
            this.checkBoxCrackDigit.Name = "checkBoxCrackDigit";
            this.checkBoxCrackDigit.Size = new System.Drawing.Size(243, 19);
            this.checkBoxCrackDigit.TabIndex = 6;
            this.checkBoxCrackDigit.Text = "Číslice (10)";
            this.checkBoxCrackDigit.UseVisualStyleBackColor = true;
            // 
            // labelCrackSpeed
            // 
            this.labelCrackSpeed.AutoSize = true;
            this.labelCrackSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCrackSpeed.Location = new System.Drawing.Point(3, 75);
            this.labelCrackSpeed.Name = "labelCrackSpeed";
            this.labelCrackSpeed.Size = new System.Drawing.Size(243, 25);
            this.labelCrackSpeed.TabIndex = 3;
            this.labelCrackSpeed.Text = "Počet pokusů /s";
            this.labelCrackSpeed.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // checkBoxCrackUpper
            // 
            this.checkBoxCrackUpper.AutoSize = true;
            this.checkBoxCrackUpper.Checked = true;
            this.checkBoxCrackUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCrackUpper.Location = new System.Drawing.Point(3, 178);
            this.checkBoxCrackUpper.Name = "checkBoxCrackUpper";
            this.checkBoxCrackUpper.Size = new System.Drawing.Size(243, 19);
            this.checkBoxCrackUpper.TabIndex = 5;
            this.checkBoxCrackUpper.Text = "Velká písmena (26)";
            this.checkBoxCrackUpper.UseVisualStyleBackColor = true;
            // 
            // textBoxCrackSpeed
            // 
            this.textBoxCrackSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxCrackSpeed.Location = new System.Drawing.Point(3, 103);
            this.textBoxCrackSpeed.Name = "textBoxCrackSpeed";
            this.textBoxCrackSpeed.Size = new System.Drawing.Size(243, 20);
            this.textBoxCrackSpeed.TabIndex = 2;
            this.textBoxCrackSpeed.Text = "2000000000";
            // 
            // checkBoxCrackLower
            // 
            this.checkBoxCrackLower.AutoSize = true;
            this.checkBoxCrackLower.Checked = true;
            this.checkBoxCrackLower.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCrackLower.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxCrackLower.Location = new System.Drawing.Point(3, 153);
            this.checkBoxCrackLower.Name = "checkBoxCrackLower";
            this.checkBoxCrackLower.Size = new System.Drawing.Size(243, 19);
            this.checkBoxCrackLower.TabIndex = 4;
            this.checkBoxCrackLower.Text = "Malá písmena (26)";
            this.checkBoxCrackLower.UseVisualStyleBackColor = true;
            // 
            // groupBoxBruteForce
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.groupBoxBruteForce, 3);
            this.groupBoxBruteForce.Controls.Add(this.tableLayoutPanel4);
            this.groupBoxBruteForce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBruteForce.Location = new System.Drawing.Point(786, 3);
            this.groupBoxBruteForce.Name = "groupBoxBruteForce";
            this.groupBoxBruteForce.Size = new System.Drawing.Size(265, 324);
            this.groupBoxBruteForce.TabIndex = 9;
            this.groupBoxBruteForce.TabStop = false;
            this.groupBoxBruteForce.Text = "Brute force attack";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.buttonBruteForceAttack, 0, 9);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxSpecialChars, 1, 8);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxHexOutputBruteForce, 0, 6);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxUnknownLenghtBruteForce, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxDigits, 1, 7);
            this.tableLayoutPanel4.Controls.Add(this.textBoxBruteForce, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxUpperCase, 1, 6);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonRegularBruteForce, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.checkBoxLowerCase, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDownStopTimer, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelStopTimer, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.radioButtonBruteForceHashed, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.labelMaxAttempts, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDownMaxAttempts, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.numericUpDownLenght, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.labelLenght, 0, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 10;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.689466F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38509F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38509F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692544F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38509F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(259, 305);
            this.tableLayoutPanel4.TabIndex = 49;
            // 
            // buttonBruteForceAttack
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.buttonBruteForceAttack, 2);
            this.buttonBruteForceAttack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBruteForceAttack.Location = new System.Drawing.Point(3, 256);
            this.buttonBruteForceAttack.Name = "buttonBruteForceAttack";
            this.buttonBruteForceAttack.Size = new System.Drawing.Size(253, 46);
            this.buttonBruteForceAttack.TabIndex = 11;
            this.buttonBruteForceAttack.Text = "Brute Force Attack";
            this.buttonBruteForceAttack.UseVisualStyleBackColor = true;
            this.buttonBruteForceAttack.Click += new System.EventHandler(this.buttonBruteForceAttack_Click);
            // 
            // checkBoxSpecialChars
            // 
            this.checkBoxSpecialChars.AutoSize = true;
            this.checkBoxSpecialChars.Checked = true;
            this.checkBoxSpecialChars.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSpecialChars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxSpecialChars.Location = new System.Drawing.Point(132, 233);
            this.checkBoxSpecialChars.Name = "checkBoxSpecialChars";
            this.checkBoxSpecialChars.Size = new System.Drawing.Size(124, 17);
            this.checkBoxSpecialChars.TabIndex = 12;
            this.checkBoxSpecialChars.Text = "Speciální znaky (33)";
            this.checkBoxSpecialChars.UseVisualStyleBackColor = true;
            // 
            // checkBoxHexOutputBruteForce
            // 
            this.checkBoxHexOutputBruteForce.AutoSize = true;
            this.checkBoxHexOutputBruteForce.Checked = true;
            this.checkBoxHexOutputBruteForce.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxHexOutputBruteForce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxHexOutputBruteForce.Location = new System.Drawing.Point(3, 187);
            this.checkBoxHexOutputBruteForce.Name = "checkBoxHexOutputBruteForce";
            this.tableLayoutPanel4.SetRowSpan(this.checkBoxHexOutputBruteForce, 2);
            this.checkBoxHexOutputBruteForce.Size = new System.Drawing.Size(123, 40);
            this.checkBoxHexOutputBruteForce.TabIndex = 37;
            this.checkBoxHexOutputBruteForce.Text = "Display password as HEX";
            this.checkBoxHexOutputBruteForce.UseVisualStyleBackColor = true;
            // 
            // checkBoxUnknownLenghtBruteForce
            // 
            this.checkBoxUnknownLenghtBruteForce.AutoSize = true;
            this.checkBoxUnknownLenghtBruteForce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUnknownLenghtBruteForce.Location = new System.Drawing.Point(3, 164);
            this.checkBoxUnknownLenghtBruteForce.Name = "checkBoxUnknownLenghtBruteForce";
            this.checkBoxUnknownLenghtBruteForce.Size = new System.Drawing.Size(123, 17);
            this.checkBoxUnknownLenghtBruteForce.TabIndex = 42;
            this.checkBoxUnknownLenghtBruteForce.Text = "Unknown Lenght";
            this.checkBoxUnknownLenghtBruteForce.UseVisualStyleBackColor = true;
            // 
            // checkBoxDigits
            // 
            this.checkBoxDigits.AutoSize = true;
            this.checkBoxDigits.Checked = true;
            this.checkBoxDigits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxDigits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxDigits.Location = new System.Drawing.Point(132, 210);
            this.checkBoxDigits.Name = "checkBoxDigits";
            this.checkBoxDigits.Size = new System.Drawing.Size(124, 17);
            this.checkBoxDigits.TabIndex = 11;
            this.checkBoxDigits.Text = "Číslice (10)";
            this.checkBoxDigits.UseVisualStyleBackColor = true;
            // 
            // textBoxBruteForce
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.textBoxBruteForce, 2);
            this.textBoxBruteForce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBruteForce.Location = new System.Drawing.Point(3, 3);
            this.textBoxBruteForce.Name = "textBoxBruteForce";
            this.textBoxBruteForce.Size = new System.Drawing.Size(253, 20);
            this.textBoxBruteForce.TabIndex = 0;
            this.textBoxBruteForce.Text = "budakkecik";
            this.textBoxBruteForce.TextChanged += new System.EventHandler(this.textBoxBruteForceInput_TextChanged);
            // 
            // checkBoxUpperCase
            // 
            this.checkBoxUpperCase.AutoSize = true;
            this.checkBoxUpperCase.Checked = true;
            this.checkBoxUpperCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUpperCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUpperCase.Location = new System.Drawing.Point(132, 187);
            this.checkBoxUpperCase.Name = "checkBoxUpperCase";
            this.checkBoxUpperCase.Size = new System.Drawing.Size(124, 17);
            this.checkBoxUpperCase.TabIndex = 10;
            this.checkBoxUpperCase.Text = "Velká písmena (26)";
            this.checkBoxUpperCase.UseVisualStyleBackColor = true;
            // 
            // radioButtonRegularBruteForce
            // 
            this.radioButtonRegularBruteForce.AutoSize = true;
            this.radioButtonRegularBruteForce.Checked = true;
            this.radioButtonRegularBruteForce.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonRegularBruteForce.Location = new System.Drawing.Point(3, 26);
            this.radioButtonRegularBruteForce.Name = "radioButtonRegularBruteForce";
            this.radioButtonRegularBruteForce.Size = new System.Drawing.Size(123, 17);
            this.radioButtonRegularBruteForce.TabIndex = 7;
            this.radioButtonRegularBruteForce.TabStop = true;
            this.radioButtonRegularBruteForce.Text = "Regular";
            this.radioButtonRegularBruteForce.UseVisualStyleBackColor = true;
            this.radioButtonRegularBruteForce.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // checkBoxLowerCase
            // 
            this.checkBoxLowerCase.AutoSize = true;
            this.checkBoxLowerCase.Checked = true;
            this.checkBoxLowerCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLowerCase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxLowerCase.Location = new System.Drawing.Point(132, 164);
            this.checkBoxLowerCase.Name = "checkBoxLowerCase";
            this.checkBoxLowerCase.Size = new System.Drawing.Size(124, 17);
            this.checkBoxLowerCase.TabIndex = 9;
            this.checkBoxLowerCase.Text = "Malá písmena (26)";
            this.checkBoxLowerCase.UseVisualStyleBackColor = true;
            // 
            // numericUpDownStopTimer
            // 
            this.numericUpDownStopTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownStopTimer.Location = new System.Drawing.Point(132, 49);
            this.numericUpDownStopTimer.Maximum = new decimal(new int[] {
            172800,
            0,
            0,
            0});
            this.numericUpDownStopTimer.Name = "numericUpDownStopTimer";
            this.numericUpDownStopTimer.Size = new System.Drawing.Size(124, 20);
            this.numericUpDownStopTimer.TabIndex = 35;
            this.numericUpDownStopTimer.ThousandsSeparator = true;
            // 
            // labelStopTimer
            // 
            this.labelStopTimer.AutoSize = true;
            this.labelStopTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStopTimer.Location = new System.Drawing.Point(132, 23);
            this.labelStopTimer.Name = "labelStopTimer";
            this.labelStopTimer.Size = new System.Drawing.Size(124, 23);
            this.labelStopTimer.TabIndex = 36;
            this.labelStopTimer.Text = "Stop Timer (sec)";
            this.labelStopTimer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioButtonBruteForceHashed
            // 
            this.radioButtonBruteForceHashed.AutoSize = true;
            this.radioButtonBruteForceHashed.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButtonBruteForceHashed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonBruteForceHashed.Location = new System.Drawing.Point(3, 49);
            this.radioButtonBruteForceHashed.Name = "radioButtonBruteForceHashed";
            this.radioButtonBruteForceHashed.Size = new System.Drawing.Size(123, 40);
            this.radioButtonBruteForceHashed.TabIndex = 8;
            this.radioButtonBruteForceHashed.Text = "Hashed";
            this.radioButtonBruteForceHashed.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButtonBruteForceHashed.UseVisualStyleBackColor = true;
            this.radioButtonBruteForceHashed.EnabledChanged += new System.EventHandler(this.radioButton6_EnabledChanged);
            // 
            // labelMaxAttempts
            // 
            this.labelMaxAttempts.AutoSize = true;
            this.labelMaxAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMaxAttempts.Location = new System.Drawing.Point(132, 92);
            this.labelMaxAttempts.Name = "labelMaxAttempts";
            this.labelMaxAttempts.Size = new System.Drawing.Size(124, 23);
            this.labelMaxAttempts.TabIndex = 29;
            this.labelMaxAttempts.Text = "Maximum Attempts";
            this.labelMaxAttempts.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numericUpDownMaxAttempts
            // 
            this.numericUpDownMaxAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownMaxAttempts.Location = new System.Drawing.Point(132, 118);
            this.numericUpDownMaxAttempts.Maximum = new decimal(new int[] {
            1215752191,
            23,
            0,
            0});
            this.numericUpDownMaxAttempts.Name = "numericUpDownMaxAttempts";
            this.numericUpDownMaxAttempts.Size = new System.Drawing.Size(124, 20);
            this.numericUpDownMaxAttempts.TabIndex = 28;
            this.numericUpDownMaxAttempts.ThousandsSeparator = true;
            // 
            // numericUpDownLenght
            // 
            this.numericUpDownLenght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDownLenght.Location = new System.Drawing.Point(3, 118);
            this.numericUpDownLenght.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownLenght.Name = "numericUpDownLenght";
            this.numericUpDownLenght.Size = new System.Drawing.Size(123, 20);
            this.numericUpDownLenght.TabIndex = 30;
            this.numericUpDownLenght.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLenght.ValueChanged += new System.EventHandler(this.numericUpDownLenght_ValueChanged);
            // 
            // labelLenght
            // 
            this.labelLenght.AutoSize = true;
            this.labelLenght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLenght.Location = new System.Drawing.Point(3, 92);
            this.labelLenght.Name = "labelLenght";
            this.labelLenght.Size = new System.Drawing.Size(123, 23);
            this.labelLenght.TabIndex = 31;
            this.labelLenght.Text = "Lenght";
            this.labelLenght.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // checkBoxPerformanceMode
            // 
            this.checkBoxPerformanceMode.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.checkBoxPerformanceMode, 3);
            this.checkBoxPerformanceMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxPerformanceMode.Location = new System.Drawing.Point(786, 381);
            this.checkBoxPerformanceMode.Name = "checkBoxPerformanceMode";
            this.checkBoxPerformanceMode.Size = new System.Drawing.Size(265, 18);
            this.checkBoxPerformanceMode.TabIndex = 34;
            this.checkBoxPerformanceMode.Text = "PerformanceMode";
            this.checkBoxPerformanceMode.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.checkBoxPerformanceMode.UseVisualStyleBackColor = true;
            // 
            // buttonRainbowTableAttack
            // 
            this.buttonRainbowTableAttack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRainbowTableAttack.Location = new System.Drawing.Point(3, 263);
            this.buttonRainbowTableAttack.Name = "buttonRainbowTableAttack";
            this.buttonRainbowTableAttack.Size = new System.Drawing.Size(243, 39);
            this.buttonRainbowTableAttack.TabIndex = 38;
            this.buttonRainbowTableAttack.Text = "Rainbow Table Attack";
            this.buttonRainbowTableAttack.UseVisualStyleBackColor = true;
            this.buttonRainbowTableAttack.Click += new System.EventHandler(this.buttonRainbowTableAttack_Click);
            // 
            // buttonGenerateRainbowTable
            // 
            this.buttonGenerateRainbowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerateRainbowTable.Location = new System.Drawing.Point(3, 222);
            this.buttonGenerateRainbowTable.Name = "buttonGenerateRainbowTable";
            this.buttonGenerateRainbowTable.Size = new System.Drawing.Size(243, 35);
            this.buttonGenerateRainbowTable.TabIndex = 10;
            this.buttonGenerateRainbowTable.Text = "Generate Rainbow Table";
            this.buttonGenerateRainbowTable.UseVisualStyleBackColor = true;
            this.buttonGenerateRainbowTable.Click += new System.EventHandler(this.buttonPreHash_Click);
            // 
            // labelStatSpeed
            // 
            this.labelStatSpeed.AutoSize = true;
            this.labelStatSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatSpeed.Location = new System.Drawing.Point(3, 69);
            this.labelStatSpeed.Name = "labelStatSpeed";
            this.labelStatSpeed.Size = new System.Drawing.Size(765, 24);
            this.labelStatSpeed.TabIndex = 28;
            this.labelStatSpeed.Text = "Average speed /s: ";
            // 
            // labelStatCurrentSpeed
            // 
            this.labelStatCurrentSpeed.AutoSize = true;
            this.labelStatCurrentSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatCurrentSpeed.Location = new System.Drawing.Point(3, 46);
            this.labelStatCurrentSpeed.Name = "labelStatCurrentSpeed";
            this.labelStatCurrentSpeed.Size = new System.Drawing.Size(765, 23);
            this.labelStatCurrentSpeed.TabIndex = 27;
            this.labelStatCurrentSpeed.Text = "Current speed /s: ";
            // 
            // labelStatAttempts
            // 
            this.labelStatAttempts.AutoSize = true;
            this.labelStatAttempts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatAttempts.Location = new System.Drawing.Point(3, 23);
            this.labelStatAttempts.Name = "labelStatAttempts";
            this.labelStatAttempts.Size = new System.Drawing.Size(765, 23);
            this.labelStatAttempts.TabIndex = 26;
            this.labelStatAttempts.Text = "Number of attempts: ";
            // 
            // labelStatTimer
            // 
            this.labelStatTimer.AutoSize = true;
            this.labelStatTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelStatTimer.Location = new System.Drawing.Point(3, 0);
            this.labelStatTimer.Name = "labelStatTimer";
            this.labelStatTimer.Size = new System.Drawing.Size(765, 23);
            this.labelStatTimer.TabIndex = 25;
            this.labelStatTimer.Text = "Timer: ";
            this.labelStatTimer.Click += new System.EventHandler(this.labelStatTimer_Click);
            // 
            // buttonCancel
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.buttonCancel, 3);
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(786, 405);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(265, 40);
            this.buttonCancel.TabIndex = 35;
            this.buttonCancel.Text = "Abort The Process";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // progressBar1
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.progressBar1, 12);
            this.progressBar1.Cursor = System.Windows.Forms.Cursors.Default;
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar1.Location = new System.Drawing.Point(3, 475);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1048, 19);
            this.progressBar1.TabIndex = 36;
            // 
            // labelProgressBar
            // 
            this.labelProgressBar.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.labelProgressBar, 12);
            this.labelProgressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProgressBar.Location = new System.Drawing.Point(3, 448);
            this.labelProgressBar.Name = "labelProgressBar";
            this.labelProgressBar.Size = new System.Drawing.Size(1048, 24);
            this.labelProgressBar.TabIndex = 37;
            this.labelProgressBar.Text = "Progress Bar";
            this.labelProgressBar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // listBoxLog
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.listBoxLog, 12);
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 500);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(1048, 64);
            this.listBoxLog.TabIndex = 38;
            // 
            // buttonLogClear
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.buttonLogClear, 4);
            this.buttonLogClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogClear.Location = new System.Drawing.Point(3, 570);
            this.buttonLogClear.Name = "buttonLogClear";
            this.buttonLogClear.Size = new System.Drawing.Size(342, 29);
            this.buttonLogClear.TabIndex = 39;
            this.buttonLogClear.Text = "Clear Log";
            this.buttonLogClear.UseVisualStyleBackColor = true;
            this.buttonLogClear.Click += new System.EventHandler(this.buttonLogClear_Click);
            // 
            // buttonLogSave
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.buttonLogSave, 4);
            this.buttonLogSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogSave.Location = new System.Drawing.Point(351, 570);
            this.buttonLogSave.Name = "buttonLogSave";
            this.buttonLogSave.Size = new System.Drawing.Size(342, 29);
            this.buttonLogSave.TabIndex = 40;
            this.buttonLogSave.Text = "Save Log";
            this.buttonLogSave.UseVisualStyleBackColor = true;
            this.buttonLogSave.Click += new System.EventHandler(this.buttonLogSave_Click);
            // 
            // buttonClipboard
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.buttonClipboard, 4);
            this.buttonClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClipboard.Location = new System.Drawing.Point(699, 570);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(352, 29);
            this.buttonClipboard.TabIndex = 41;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // groupBoxRainbowTable
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.groupBoxRainbowTable, 3);
            this.groupBoxRainbowTable.Controls.Add(this.tableLayoutPanel3);
            this.groupBoxRainbowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxRainbowTable.Location = new System.Drawing.Point(525, 3);
            this.groupBoxRainbowTable.Name = "groupBoxRainbowTable";
            this.groupBoxRainbowTable.Size = new System.Drawing.Size(255, 324);
            this.groupBoxRainbowTable.TabIndex = 42;
            this.groupBoxRainbowTable.TabStop = false;
            this.groupBoxRainbowTable.Text = "Rainbow table attack";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.radioButtonHashedRainbowTable, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonGenerateRainbowTable, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.radioButtonRegularRainbowTable, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.textBoxRainbowTable, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonRainbowTableAttack, 0, 5);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.6612F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.11475F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.11475F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.78688F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.6612F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.6612F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(249, 305);
            this.tableLayoutPanel3.TabIndex = 49;
            // 
            // radioButtonHashedRainbowTable
            // 
            this.radioButtonHashedRainbowTable.AutoSize = true;
            this.radioButtonHashedRainbowTable.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButtonHashedRainbowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonHashedRainbowTable.Location = new System.Drawing.Point(3, 83);
            this.radioButtonHashedRainbowTable.Name = "radioButtonHashedRainbowTable";
            this.radioButtonHashedRainbowTable.Size = new System.Drawing.Size(243, 33);
            this.radioButtonHashedRainbowTable.TabIndex = 45;
            this.radioButtonHashedRainbowTable.Text = "Hashed";
            this.radioButtonHashedRainbowTable.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.radioButtonHashedRainbowTable.UseVisualStyleBackColor = true;
            // 
            // radioButtonRegularRainbowTable
            // 
            this.radioButtonRegularRainbowTable.AutoSize = true;
            this.radioButtonRegularRainbowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonRegularRainbowTable.Location = new System.Drawing.Point(3, 44);
            this.radioButtonRegularRainbowTable.Name = "radioButtonRegularRainbowTable";
            this.radioButtonRegularRainbowTable.Size = new System.Drawing.Size(243, 33);
            this.radioButtonRegularRainbowTable.TabIndex = 44;
            this.radioButtonRegularRainbowTable.Text = "Regular";
            this.radioButtonRegularRainbowTable.UseVisualStyleBackColor = true;
            // 
            // textBoxRainbowTable
            // 
            this.textBoxRainbowTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxRainbowTable.Location = new System.Drawing.Point(3, 3);
            this.textBoxRainbowTable.Name = "textBoxRainbowTable";
            this.textBoxRainbowTable.Size = new System.Drawing.Size(243, 20);
            this.textBoxRainbowTable.TabIndex = 44;
            this.textBoxRainbowTable.Text = "budakkecik";
            // 
            // hashSelector
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.hashSelector, 3);
            this.hashSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512",
            "RipeMD-160",
            "CRC32"});
            this.hashSelector.Location = new System.Drawing.Point(786, 357);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(265, 21);
            this.hashSelector.TabIndex = 44;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelectorRainbowTable_SelectedIndexChanged);
            // 
            // groupBoxUI
            // 
            this.tableLayoutPanel5.SetColumnSpan(this.groupBoxUI, 9);
            this.groupBoxUI.Controls.Add(this.tableLayoutPanel6);
            this.groupBoxUI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxUI.Location = new System.Drawing.Point(3, 333);
            this.groupBoxUI.Name = "groupBoxUI";
            this.tableLayoutPanel5.SetRowSpan(this.groupBoxUI, 4);
            this.groupBoxUI.Size = new System.Drawing.Size(777, 112);
            this.groupBoxUI.TabIndex = 43;
            this.groupBoxUI.TabStop = false;
            this.groupBoxUI.Text = "UI";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.labelStatSpeed, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.labelStatCurrentSpeed, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.labelStatTimer, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.labelStatAttempts, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(771, 93);
            this.tableLayoutPanel6.TabIndex = 50;
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.labelAlgorithm, 3);
            this.labelAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAlgorithm.Location = new System.Drawing.Point(786, 330);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(265, 24);
            this.labelAlgorithm.TabIndex = 48;
            this.labelAlgorithm.Text = "Algorithm";
            this.labelAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 12;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333332F));
            this.tableLayoutPanel5.Controls.Add(this.groupBoxDictionary, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.progressBar1, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.listBoxLog, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.checkBoxPerformanceMode, 9, 3);
            this.tableLayoutPanel5.Controls.Add(this.buttonCancel, 9, 4);
            this.tableLayoutPanel5.Controls.Add(this.groupBoxUI, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.groupBoxTimeToCrack, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBoxRainbowTable, 6, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBoxBruteForce, 9, 0);
            this.tableLayoutPanel5.Controls.Add(this.hashSelector, 9, 2);
            this.tableLayoutPanel5.Controls.Add(this.buttonClipboard, 8, 8);
            this.tableLayoutPanel5.Controls.Add(this.buttonLogSave, 4, 8);
            this.tableLayoutPanel5.Controls.Add(this.buttonLogClear, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.labelAlgorithm, 9, 1);
            this.tableLayoutPanel5.Controls.Add(this.labelProgressBar, 0, 5);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.MinimumSize = new System.Drawing.Size(1054, 602);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 9;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.97738F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.09973F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.09973F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.09973F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.804245F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.099728F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.304717F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.70637F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.808357F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(1054, 602);
            this.tableLayoutPanel5.TabIndex = 49;
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 602);
            this.Controls.Add(this.tableLayoutPanel5);
            this.MinimumSize = new System.Drawing.Size(1070, 641);
            this.Name = "PasswordForm";
            this.Text = "PasswordForm";
            this.Load += new System.EventHandler(this.PasswordForm_Load);
            this.groupBoxDictionary.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxTimeToCrack.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBoxBruteForce.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStopTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxAttempts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLenght)).EndInit();
            this.groupBoxRainbowTable.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBoxUI.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label labelAlgorithm;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
    }
}
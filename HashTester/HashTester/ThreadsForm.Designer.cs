namespace HashTester
{
    partial class ThreadsForm
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
            this.labelPercentages = new System.Windows.Forms.Label();
            this.radioButtonPercentZero = new System.Windows.Forms.RadioButton();
            this.labelThreads = new System.Windows.Forms.Label();
            this.textBoxPercent = new System.Windows.Forms.TextBox();
            this.radioButtonPercent4 = new System.Windows.Forms.RadioButton();
            this.radioButtonThread4 = new System.Windows.Forms.RadioButton();
            this.labelFrom0to100 = new System.Windows.Forms.Label();
            this.labelPreference = new System.Windows.Forms.Label();
            this.radioButtonPercent3 = new System.Windows.Forms.RadioButton();
            this.radioButtonThread3 = new System.Windows.Forms.RadioButton();
            this.radioButtonPercentHunred = new System.Windows.Forms.RadioButton();
            this.radioButtonPercent2 = new System.Windows.Forms.RadioButton();
            this.radioButtonThread2 = new System.Windows.Forms.RadioButton();
            this.labelCalculations = new System.Windows.Forms.Label();
            this.radioButtonThread1 = new System.Windows.Forms.RadioButton();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.textBoxThread = new System.Windows.Forms.TextBox();
            this.labelMaxThreads = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelHowMany = new System.Windows.Forms.Label();
            this.labelZeroPercent = new System.Windows.Forms.Label();
            this.radioButtonThreadMax = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelCPUDescription = new System.Windows.Forms.Label();
            this.labelCPUMaxSpeed = new System.Windows.Forms.Label();
            this.labelCPUThread = new System.Windows.Forms.Label();
            this.labelCPUCores = new System.Windows.Forms.Label();
            this.labelCPUManufacturer = new System.Windows.Forms.Label();
            this.labelCPUName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPercentages
            // 
            this.labelPercentages.AutoSize = true;
            this.labelPercentages.Location = new System.Drawing.Point(208, 34);
            this.labelPercentages.Name = "labelPercentages";
            this.labelPercentages.Size = new System.Drawing.Size(138, 13);
            this.labelPercentages.TabIndex = 42;
            this.labelPercentages.Text = "Percentage of threads used";
            // 
            // radioButtonPercentZero
            // 
            this.radioButtonPercentZero.AutoSize = true;
            this.radioButtonPercentZero.Location = new System.Drawing.Point(209, 181);
            this.radioButtonPercentZero.Name = "radioButtonPercentZero";
            this.radioButtonPercentZero.Size = new System.Drawing.Size(39, 17);
            this.radioButtonPercentZero.TabIndex = 41;
            this.radioButtonPercentZero.TabStop = true;
            this.radioButtonPercentZero.Text = "0%";
            this.radioButtonPercentZero.UseVisualStyleBackColor = true;
            this.radioButtonPercentZero.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.labelThreads.Location = new System.Drawing.Point(15, 34);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(94, 13);
            this.labelThreads.TabIndex = 37;
            this.labelThreads.Text = "Number of threads";
            // 
            // textBoxPercent
            // 
            this.textBoxPercent.Location = new System.Drawing.Point(209, 50);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.Size = new System.Drawing.Size(180, 20);
            this.textBoxPercent.TabIndex = 23;
            this.textBoxPercent.TextChanged += new System.EventHandler(this.textBoxPercent_TextChanged);
            // 
            // radioButtonPercent4
            // 
            this.radioButtonPercent4.AutoSize = true;
            this.radioButtonPercent4.Location = new System.Drawing.Point(209, 158);
            this.radioButtonPercent4.Name = "radioButtonPercent4";
            this.radioButtonPercent4.Size = new System.Drawing.Size(45, 17);
            this.radioButtonPercent4.TabIndex = 40;
            this.radioButtonPercent4.TabStop = true;
            this.radioButtonPercent4.Text = "25%";
            this.radioButtonPercent4.UseVisualStyleBackColor = true;
            this.radioButtonPercent4.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonThread4
            // 
            this.radioButtonThread4.AutoSize = true;
            this.radioButtonThread4.Location = new System.Drawing.Point(18, 159);
            this.radioButtonThread4.Name = "radioButtonThread4";
            this.radioButtonThread4.Size = new System.Drawing.Size(69, 17);
            this.radioButtonThread4.TabIndex = 35;
            this.radioButtonThread4.Text = "8 threads";
            this.radioButtonThread4.UseVisualStyleBackColor = true;
            this.radioButtonThread4.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // labelFrom0to100
            // 
            this.labelFrom0to100.AutoSize = true;
            this.labelFrom0to100.Location = new System.Drawing.Point(208, 73);
            this.labelFrom0to100.Name = "labelFrom0to100";
            this.labelFrom0to100.Size = new System.Drawing.Size(88, 13);
            this.labelFrom0to100.TabIndex = 29;
            this.labelFrom0to100.Text = "From 0% to 100%";
            // 
            // labelPreference
            // 
            this.labelPreference.AutoSize = true;
            this.labelPreference.Location = new System.Drawing.Point(12, 215);
            this.labelPreference.Name = "labelPreference";
            this.labelPreference.Size = new System.Drawing.Size(260, 13);
            this.labelPreference.TabIndex = 33;
            this.labelPreference.Text = "*Know that percentages are prefered by the computer";
            // 
            // radioButtonPercent3
            // 
            this.radioButtonPercent3.AutoSize = true;
            this.radioButtonPercent3.Location = new System.Drawing.Point(209, 135);
            this.radioButtonPercent3.Name = "radioButtonPercent3";
            this.radioButtonPercent3.Size = new System.Drawing.Size(45, 17);
            this.radioButtonPercent3.TabIndex = 39;
            this.radioButtonPercent3.Text = "50%";
            this.radioButtonPercent3.UseVisualStyleBackColor = true;
            this.radioButtonPercent3.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonThread3
            // 
            this.radioButtonThread3.AutoSize = true;
            this.radioButtonThread3.Location = new System.Drawing.Point(18, 136);
            this.radioButtonThread3.Name = "radioButtonThread3";
            this.radioButtonThread3.Size = new System.Drawing.Size(69, 17);
            this.radioButtonThread3.TabIndex = 34;
            this.radioButtonThread3.Text = "4 threads";
            this.radioButtonThread3.UseVisualStyleBackColor = true;
            this.radioButtonThread3.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonPercentHunred
            // 
            this.radioButtonPercentHunred.AutoSize = true;
            this.radioButtonPercentHunred.Location = new System.Drawing.Point(209, 89);
            this.radioButtonPercentHunred.Name = "radioButtonPercentHunred";
            this.radioButtonPercentHunred.Size = new System.Drawing.Size(51, 17);
            this.radioButtonPercentHunred.TabIndex = 36;
            this.radioButtonPercentHunred.TabStop = true;
            this.radioButtonPercentHunred.Text = "100%";
            this.radioButtonPercentHunred.UseVisualStyleBackColor = true;
            this.radioButtonPercentHunred.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonPercent2
            // 
            this.radioButtonPercent2.AutoSize = true;
            this.radioButtonPercent2.Location = new System.Drawing.Point(209, 112);
            this.radioButtonPercent2.Name = "radioButtonPercent2";
            this.radioButtonPercent2.Size = new System.Drawing.Size(45, 17);
            this.radioButtonPercent2.TabIndex = 38;
            this.radioButtonPercent2.TabStop = true;
            this.radioButtonPercent2.Text = "75%";
            this.radioButtonPercent2.UseVisualStyleBackColor = true;
            this.radioButtonPercent2.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonThread2
            // 
            this.radioButtonThread2.AutoSize = true;
            this.radioButtonThread2.Location = new System.Drawing.Point(18, 113);
            this.radioButtonThread2.Name = "radioButtonThread2";
            this.radioButtonThread2.Size = new System.Drawing.Size(69, 17);
            this.radioButtonThread2.TabIndex = 32;
            this.radioButtonThread2.Text = "2 threads";
            this.radioButtonThread2.UseVisualStyleBackColor = true;
            this.radioButtonThread2.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // labelCalculations
            // 
            this.labelCalculations.AutoSize = true;
            this.labelCalculations.Location = new System.Drawing.Point(12, 229);
            this.labelCalculations.Name = "labelCalculations";
            this.labelCalculations.Size = new System.Drawing.Size(236, 13);
            this.labelCalculations.TabIndex = 27;
            this.labelCalculations.Text = "*Lower thread count can slow down calculations";
            // 
            // radioButtonThread1
            // 
            this.radioButtonThread1.AutoSize = true;
            this.radioButtonThread1.Location = new System.Drawing.Point(18, 90);
            this.radioButtonThread1.Name = "radioButtonThread1";
            this.radioButtonThread1.Size = new System.Drawing.Size(87, 17);
            this.radioButtonThread1.TabIndex = 30;
            this.radioButtonThread1.Text = "Single thread";
            this.radioButtonThread1.UseVisualStyleBackColor = true;
            this.radioButtonThread1.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(150, 245);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(129, 23);
            this.buttonDefault.TabIndex = 26;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // textBoxThread
            // 
            this.textBoxThread.Location = new System.Drawing.Point(15, 50);
            this.textBoxThread.Name = "textBoxThread";
            this.textBoxThread.Size = new System.Drawing.Size(180, 20);
            this.textBoxThread.TabIndex = 22;
            this.textBoxThread.TextChanged += new System.EventHandler(this.textBoxThread_TextChanged);
            // 
            // labelMaxThreads
            // 
            this.labelMaxThreads.AutoSize = true;
            this.labelMaxThreads.Location = new System.Drawing.Point(15, 73);
            this.labelMaxThreads.Name = "labelMaxThreads";
            this.labelMaxThreads.Size = new System.Drawing.Size(164, 13);
            this.labelMaxThreads.TabIndex = 28;
            this.labelMaxThreads.Text = "From 1 to max. number of threads";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(285, 245);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 23);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(15, 245);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(129, 23);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelHowMany
            // 
            this.labelHowMany.AutoSize = true;
            this.labelHowMany.Location = new System.Drawing.Point(82, 9);
            this.labelHowMany.Name = "labelHowMany";
            this.labelHowMany.Size = new System.Drawing.Size(264, 13);
            this.labelHowMany.TabIndex = 21;
            this.labelHowMany.Text = "How many threads do you want to use in the program?";
            // 
            // labelZeroPercent
            // 
            this.labelZeroPercent.AutoSize = true;
            this.labelZeroPercent.Location = new System.Drawing.Point(12, 202);
            this.labelZeroPercent.Name = "labelZeroPercent";
            this.labelZeroPercent.Size = new System.Drawing.Size(250, 13);
            this.labelZeroPercent.TabIndex = 43;
            this.labelZeroPercent.Text = "*0% means only one thread may be used at all times";
            // 
            // radioButtonThreadMax
            // 
            this.radioButtonThreadMax.AutoSize = true;
            this.radioButtonThreadMax.Location = new System.Drawing.Point(18, 182);
            this.radioButtonThreadMax.Name = "radioButtonThreadMax";
            this.radioButtonThreadMax.Size = new System.Drawing.Size(157, 17);
            this.radioButtonThreadMax.TabIndex = 44;
            this.radioButtonThreadMax.Text = "Maximum number of threads";
            this.radioButtonThreadMax.UseVisualStyleBackColor = true;
            this.radioButtonThreadMax.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelCPUDescription);
            this.groupBox1.Controls.Add(this.labelCPUMaxSpeed);
            this.groupBox1.Controls.Add(this.labelCPUThread);
            this.groupBox1.Controls.Add(this.labelCPUCores);
            this.groupBox1.Controls.Add(this.labelCPUManufacturer);
            this.groupBox1.Controls.Add(this.labelCPUName);
            this.groupBox1.Location = new System.Drawing.Point(18, 274);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 117);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU Info";
            // 
            // labelCPUDescription
            // 
            this.labelCPUDescription.AutoSize = true;
            this.labelCPUDescription.Location = new System.Drawing.Point(6, 81);
            this.labelCPUDescription.Name = "labelCPUDescription";
            this.labelCPUDescription.Size = new System.Drawing.Size(89, 13);
            this.labelCPUDescription.TabIndex = 5;
            this.labelCPUDescription.Text = "CPU description: ";
            // 
            // labelCPUMaxSpeed
            // 
            this.labelCPUMaxSpeed.AutoSize = true;
            this.labelCPUMaxSpeed.Location = new System.Drawing.Point(6, 68);
            this.labelCPUMaxSpeed.Name = "labelCPUMaxSpeed";
            this.labelCPUMaxSpeed.Size = new System.Drawing.Size(94, 13);
            this.labelCPUMaxSpeed.TabIndex = 4;
            this.labelCPUMaxSpeed.Text = "Max clock speed: ";
            // 
            // labelCPUThread
            // 
            this.labelCPUThread.AutoSize = true;
            this.labelCPUThread.Location = new System.Drawing.Point(6, 55);
            this.labelCPUThread.Name = "labelCPUThread";
            this.labelCPUThread.Size = new System.Drawing.Size(100, 13);
            this.labelCPUThread.TabIndex = 3;
            this.labelCPUThread.Text = "Number of threads: ";
            // 
            // labelCPUCores
            // 
            this.labelCPUCores.AutoSize = true;
            this.labelCPUCores.Location = new System.Drawing.Point(6, 42);
            this.labelCPUCores.Name = "labelCPUCores";
            this.labelCPUCores.Size = new System.Drawing.Size(91, 13);
            this.labelCPUCores.TabIndex = 2;
            this.labelCPUCores.Text = "Number of cores: ";
            // 
            // labelCPUManufacturer
            // 
            this.labelCPUManufacturer.AutoSize = true;
            this.labelCPUManufacturer.Location = new System.Drawing.Point(6, 29);
            this.labelCPUManufacturer.Name = "labelCPUManufacturer";
            this.labelCPUManufacturer.Size = new System.Drawing.Size(76, 13);
            this.labelCPUManufacturer.TabIndex = 1;
            this.labelCPUManufacturer.Text = "Manufacturer: ";
            // 
            // labelCPUName
            // 
            this.labelCPUName.AutoSize = true;
            this.labelCPUName.Location = new System.Drawing.Point(6, 16);
            this.labelCPUName.Name = "labelCPUName";
            this.labelCPUName.Size = new System.Drawing.Size(38, 13);
            this.labelCPUName.TabIndex = 0;
            this.labelCPUName.Text = "Name:";
            // 
            // ThreadsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 407);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonThreadMax);
            this.Controls.Add(this.labelZeroPercent);
            this.Controls.Add(this.labelPercentages);
            this.Controls.Add(this.radioButtonPercentZero);
            this.Controls.Add(this.labelThreads);
            this.Controls.Add(this.textBoxPercent);
            this.Controls.Add(this.radioButtonPercent4);
            this.Controls.Add(this.radioButtonThread4);
            this.Controls.Add(this.labelFrom0to100);
            this.Controls.Add(this.labelPreference);
            this.Controls.Add(this.radioButtonPercent3);
            this.Controls.Add(this.radioButtonThread3);
            this.Controls.Add(this.radioButtonPercentHunred);
            this.Controls.Add(this.radioButtonPercent2);
            this.Controls.Add(this.radioButtonThread2);
            this.Controls.Add(this.labelCalculations);
            this.Controls.Add(this.radioButtonThread1);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.textBoxThread);
            this.Controls.Add(this.labelMaxThreads);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelHowMany);
            this.Name = "ThreadsForm";
            this.Text = "ThreadsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreadsForm_FormClosing);
            this.Load += new System.EventHandler(this.ThreadsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelPercentages;
        private System.Windows.Forms.RadioButton radioButtonPercentZero;
        private System.Windows.Forms.Label labelThreads;
        private System.Windows.Forms.TextBox textBoxPercent;
        private System.Windows.Forms.RadioButton radioButtonPercent4;
        private System.Windows.Forms.RadioButton radioButtonThread4;
        private System.Windows.Forms.Label labelFrom0to100;
        private System.Windows.Forms.Label labelPreference;
        private System.Windows.Forms.RadioButton radioButtonPercent3;
        private System.Windows.Forms.RadioButton radioButtonThread3;
        private System.Windows.Forms.RadioButton radioButtonPercentHunred;
        private System.Windows.Forms.RadioButton radioButtonPercent2;
        private System.Windows.Forms.RadioButton radioButtonThread2;
        private System.Windows.Forms.Label labelCalculations;
        private System.Windows.Forms.RadioButton radioButtonThread1;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.TextBox textBoxThread;
        private System.Windows.Forms.Label labelMaxThreads;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelHowMany;
        private System.Windows.Forms.Label labelZeroPercent;
        private System.Windows.Forms.RadioButton radioButtonThreadMax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCPUName;
        private System.Windows.Forms.Label labelCPUManufacturer;
        private System.Windows.Forms.Label labelCPUCores;
        private System.Windows.Forms.Label labelCPUMaxSpeed;
        private System.Windows.Forms.Label labelCPUThread;
        private System.Windows.Forms.Label labelCPUDescription;
    }
}
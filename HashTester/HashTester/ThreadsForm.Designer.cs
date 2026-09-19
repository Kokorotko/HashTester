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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCPUDescription = new System.Windows.Forms.Label();
            this.labelCPUName = new System.Windows.Forms.Label();
            this.labelCPUMaxSpeed = new System.Windows.Forms.Label();
            this.labelCPUManufacturer = new System.Windows.Forms.Label();
            this.labelCPUThread = new System.Windows.Forms.Label();
            this.labelCPUCores = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPercentages
            // 
            this.labelPercentages.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelPercentages, 3);
            this.labelPercentages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPercentages.Location = new System.Drawing.Point(303, 22);
            this.labelPercentages.Name = "labelPercentages";
            this.labelPercentages.Size = new System.Drawing.Size(294, 22);
            this.labelPercentages.TabIndex = 42;
            this.labelPercentages.Text = "Percentage of threads used";
            this.labelPercentages.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioButtonPercentZero
            // 
            this.radioButtonPercentZero.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonPercentZero, 3);
            this.radioButtonPercentZero.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonPercentZero.Location = new System.Drawing.Point(303, 179);
            this.radioButtonPercentZero.Name = "radioButtonPercentZero";
            this.radioButtonPercentZero.Size = new System.Drawing.Size(294, 16);
            this.radioButtonPercentZero.TabIndex = 41;
            this.radioButtonPercentZero.TabStop = true;
            this.radioButtonPercentZero.Text = "0%";
            this.radioButtonPercentZero.UseVisualStyleBackColor = true;
            this.radioButtonPercentZero.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelThreads, 3);
            this.labelThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelThreads.Location = new System.Drawing.Point(3, 22);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(294, 22);
            this.labelThreads.TabIndex = 37;
            this.labelThreads.Text = "Number of threads";
            this.labelThreads.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // textBoxPercent
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxPercent, 3);
            this.textBoxPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPercent.Location = new System.Drawing.Point(303, 47);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.Size = new System.Drawing.Size(294, 20);
            this.textBoxPercent.TabIndex = 23;
            this.textBoxPercent.TextChanged += new System.EventHandler(this.textBoxPercent_TextChanged);
            // 
            // radioButtonPercent4
            // 
            this.radioButtonPercent4.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonPercent4, 3);
            this.radioButtonPercent4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonPercent4.Location = new System.Drawing.Point(303, 157);
            this.radioButtonPercent4.Name = "radioButtonPercent4";
            this.radioButtonPercent4.Size = new System.Drawing.Size(294, 16);
            this.radioButtonPercent4.TabIndex = 40;
            this.radioButtonPercent4.TabStop = true;
            this.radioButtonPercent4.Text = "25%";
            this.radioButtonPercent4.UseVisualStyleBackColor = true;
            this.radioButtonPercent4.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonThread4
            // 
            this.radioButtonThread4.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonThread4, 3);
            this.radioButtonThread4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonThread4.Location = new System.Drawing.Point(3, 157);
            this.radioButtonThread4.Name = "radioButtonThread4";
            this.radioButtonThread4.Size = new System.Drawing.Size(294, 16);
            this.radioButtonThread4.TabIndex = 35;
            this.radioButtonThread4.Text = "8 threads";
            this.radioButtonThread4.UseVisualStyleBackColor = true;
            this.radioButtonThread4.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // labelFrom0to100
            // 
            this.labelFrom0to100.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelFrom0to100, 3);
            this.labelFrom0to100.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFrom0to100.Location = new System.Drawing.Point(303, 66);
            this.labelFrom0to100.Name = "labelFrom0to100";
            this.labelFrom0to100.Size = new System.Drawing.Size(294, 22);
            this.labelFrom0to100.TabIndex = 29;
            this.labelFrom0to100.Text = "From 0% to 100%";
            // 
            // labelPreference
            // 
            this.labelPreference.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelPreference, 6);
            this.labelPreference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPreference.Location = new System.Drawing.Point(3, 220);
            this.labelPreference.Name = "labelPreference";
            this.labelPreference.Size = new System.Drawing.Size(594, 22);
            this.labelPreference.TabIndex = 33;
            this.labelPreference.Text = "*Know that percentages are prefered by the computer";
            this.labelPreference.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioButtonPercent3
            // 
            this.radioButtonPercent3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonPercent3, 3);
            this.radioButtonPercent3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonPercent3.Location = new System.Drawing.Point(303, 135);
            this.radioButtonPercent3.Name = "radioButtonPercent3";
            this.radioButtonPercent3.Size = new System.Drawing.Size(294, 16);
            this.radioButtonPercent3.TabIndex = 39;
            this.radioButtonPercent3.Text = "50%";
            this.radioButtonPercent3.UseVisualStyleBackColor = true;
            this.radioButtonPercent3.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonThread3
            // 
            this.radioButtonThread3.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonThread3, 3);
            this.radioButtonThread3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonThread3.Location = new System.Drawing.Point(3, 135);
            this.radioButtonThread3.Name = "radioButtonThread3";
            this.radioButtonThread3.Size = new System.Drawing.Size(294, 16);
            this.radioButtonThread3.TabIndex = 34;
            this.radioButtonThread3.Text = "4 threads";
            this.radioButtonThread3.UseVisualStyleBackColor = true;
            this.radioButtonThread3.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonPercentHunred
            // 
            this.radioButtonPercentHunred.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonPercentHunred, 3);
            this.radioButtonPercentHunred.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonPercentHunred.Location = new System.Drawing.Point(303, 91);
            this.radioButtonPercentHunred.Name = "radioButtonPercentHunred";
            this.radioButtonPercentHunred.Size = new System.Drawing.Size(294, 16);
            this.radioButtonPercentHunred.TabIndex = 36;
            this.radioButtonPercentHunred.TabStop = true;
            this.radioButtonPercentHunred.Text = "100%";
            this.radioButtonPercentHunred.UseVisualStyleBackColor = true;
            this.radioButtonPercentHunred.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonPercent2
            // 
            this.radioButtonPercent2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonPercent2, 3);
            this.radioButtonPercent2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonPercent2.Location = new System.Drawing.Point(303, 113);
            this.radioButtonPercent2.Name = "radioButtonPercent2";
            this.radioButtonPercent2.Size = new System.Drawing.Size(294, 16);
            this.radioButtonPercent2.TabIndex = 38;
            this.radioButtonPercent2.TabStop = true;
            this.radioButtonPercent2.Text = "75%";
            this.radioButtonPercent2.UseVisualStyleBackColor = true;
            this.radioButtonPercent2.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // radioButtonThread2
            // 
            this.radioButtonThread2.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonThread2, 3);
            this.radioButtonThread2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonThread2.Location = new System.Drawing.Point(3, 113);
            this.radioButtonThread2.Name = "radioButtonThread2";
            this.radioButtonThread2.Size = new System.Drawing.Size(294, 16);
            this.radioButtonThread2.TabIndex = 32;
            this.radioButtonThread2.Text = "2 threads";
            this.radioButtonThread2.UseVisualStyleBackColor = true;
            this.radioButtonThread2.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // labelCalculations
            // 
            this.labelCalculations.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelCalculations, 6);
            this.labelCalculations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCalculations.Location = new System.Drawing.Point(3, 242);
            this.labelCalculations.Name = "labelCalculations";
            this.labelCalculations.Size = new System.Drawing.Size(594, 22);
            this.labelCalculations.TabIndex = 27;
            this.labelCalculations.Text = "*Lower thread count can slow down calculations";
            this.labelCalculations.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioButtonThread1
            // 
            this.radioButtonThread1.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonThread1, 3);
            this.radioButtonThread1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonThread1.Location = new System.Drawing.Point(3, 91);
            this.radioButtonThread1.Name = "radioButtonThread1";
            this.radioButtonThread1.Size = new System.Drawing.Size(294, 16);
            this.radioButtonThread1.TabIndex = 30;
            this.radioButtonThread1.Text = "Single thread";
            this.radioButtonThread1.UseVisualStyleBackColor = true;
            this.radioButtonThread1.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // buttonDefault
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.buttonDefault, 2);
            this.buttonDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonDefault.Location = new System.Drawing.Point(203, 267);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(194, 41);
            this.buttonDefault.TabIndex = 26;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.buttonDefault_Click);
            // 
            // textBoxThread
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxThread, 3);
            this.textBoxThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxThread.Location = new System.Drawing.Point(3, 47);
            this.textBoxThread.Name = "textBoxThread";
            this.textBoxThread.Size = new System.Drawing.Size(294, 20);
            this.textBoxThread.TabIndex = 22;
            this.textBoxThread.TextChanged += new System.EventHandler(this.textBoxThread_TextChanged);
            // 
            // labelMaxThreads
            // 
            this.labelMaxThreads.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelMaxThreads, 3);
            this.labelMaxThreads.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelMaxThreads.Location = new System.Drawing.Point(3, 66);
            this.labelMaxThreads.Name = "labelMaxThreads";
            this.labelMaxThreads.Size = new System.Drawing.Size(294, 22);
            this.labelMaxThreads.TabIndex = 28;
            this.labelMaxThreads.Text = "From 1 to max. number of threads";
            // 
            // buttonCancel
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonCancel.Location = new System.Drawing.Point(403, 267);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(194, 41);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.buttonSave, 2);
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonSave.Location = new System.Drawing.Point(3, 267);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(194, 41);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelHowMany
            // 
            this.labelHowMany.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelHowMany, 6);
            this.labelHowMany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelHowMany.Location = new System.Drawing.Point(3, 0);
            this.labelHowMany.Name = "labelHowMany";
            this.labelHowMany.Size = new System.Drawing.Size(594, 22);
            this.labelHowMany.TabIndex = 21;
            this.labelHowMany.Text = "How many threads do you want to use in the program?";
            this.labelHowMany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelZeroPercent
            // 
            this.labelZeroPercent.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.labelZeroPercent, 6);
            this.labelZeroPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelZeroPercent.Location = new System.Drawing.Point(3, 198);
            this.labelZeroPercent.Name = "labelZeroPercent";
            this.labelZeroPercent.Size = new System.Drawing.Size(594, 22);
            this.labelZeroPercent.TabIndex = 43;
            this.labelZeroPercent.Text = "*0% means only one thread may be used at all times";
            this.labelZeroPercent.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioButtonThreadMax
            // 
            this.radioButtonThreadMax.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.radioButtonThreadMax, 3);
            this.radioButtonThreadMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonThreadMax.Location = new System.Drawing.Point(3, 179);
            this.radioButtonThreadMax.Name = "radioButtonThreadMax";
            this.radioButtonThreadMax.Size = new System.Drawing.Size(294, 16);
            this.radioButtonThreadMax.TabIndex = 44;
            this.radioButtonThreadMax.Text = "Maximum number of threads";
            this.radioButtonThreadMax.UseVisualStyleBackColor = true;
            this.radioButtonThreadMax.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 6);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 314);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(594, 186);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CPU Info";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.labelCPUDescription, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelCPUName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelCPUMaxSpeed, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelCPUManufacturer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCPUThread, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelCPUCores, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 167);
            this.tableLayoutPanel1.TabIndex = 46;
            // 
            // labelCPUDescription
            // 
            this.labelCPUDescription.AutoSize = true;
            this.labelCPUDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCPUDescription.Location = new System.Drawing.Point(3, 135);
            this.labelCPUDescription.Name = "labelCPUDescription";
            this.labelCPUDescription.Size = new System.Drawing.Size(582, 32);
            this.labelCPUDescription.TabIndex = 5;
            this.labelCPUDescription.Text = "CPU description: ";
            this.labelCPUDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCPUName
            // 
            this.labelCPUName.AutoSize = true;
            this.labelCPUName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCPUName.Location = new System.Drawing.Point(3, 0);
            this.labelCPUName.Name = "labelCPUName";
            this.labelCPUName.Size = new System.Drawing.Size(582, 27);
            this.labelCPUName.TabIndex = 0;
            this.labelCPUName.Text = "Name:";
            this.labelCPUName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCPUMaxSpeed
            // 
            this.labelCPUMaxSpeed.AutoSize = true;
            this.labelCPUMaxSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCPUMaxSpeed.Location = new System.Drawing.Point(3, 108);
            this.labelCPUMaxSpeed.Name = "labelCPUMaxSpeed";
            this.labelCPUMaxSpeed.Size = new System.Drawing.Size(582, 27);
            this.labelCPUMaxSpeed.TabIndex = 4;
            this.labelCPUMaxSpeed.Text = "Max clock speed: ";
            this.labelCPUMaxSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCPUManufacturer
            // 
            this.labelCPUManufacturer.AutoSize = true;
            this.labelCPUManufacturer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCPUManufacturer.Location = new System.Drawing.Point(3, 27);
            this.labelCPUManufacturer.Name = "labelCPUManufacturer";
            this.labelCPUManufacturer.Size = new System.Drawing.Size(582, 27);
            this.labelCPUManufacturer.TabIndex = 1;
            this.labelCPUManufacturer.Text = "Manufacturer: ";
            this.labelCPUManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCPUThread
            // 
            this.labelCPUThread.AutoSize = true;
            this.labelCPUThread.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCPUThread.Location = new System.Drawing.Point(3, 81);
            this.labelCPUThread.Name = "labelCPUThread";
            this.labelCPUThread.Size = new System.Drawing.Size(582, 27);
            this.labelCPUThread.TabIndex = 3;
            this.labelCPUThread.Text = "Number of threads: ";
            this.labelCPUThread.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCPUCores
            // 
            this.labelCPUCores.AutoSize = true;
            this.labelCPUCores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCPUCores.Location = new System.Drawing.Point(3, 54);
            this.labelCPUCores.Name = "labelCPUCores";
            this.labelCPUCores.Size = new System.Drawing.Size(582, 27);
            this.labelCPUCores.TabIndex = 2;
            this.labelCPUCores.Text = "Number of cores: ";
            this.labelCPUCores.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 13);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonPercentZero, 3, 8);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonThreadMax, 0, 8);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonPercent4, 3, 7);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPercent, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonPercent3, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.labelFrom0to100, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonPercent2, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonPercentHunred, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonSave, 0, 12);
            this.tableLayoutPanel2.Controls.Add(this.labelPercentages, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelZeroPercent, 0, 9);
            this.tableLayoutPanel2.Controls.Add(this.buttonDefault, 2, 12);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonThread4, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.labelThreads, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonCancel, 4, 12);
            this.tableLayoutPanel2.Controls.Add(this.labelCalculations, 0, 11);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonThread3, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.labelPreference, 0, 10);
            this.tableLayoutPanel2.Controls.Add(this.labelHowMany, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxThread, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonThread2, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.labelMaxThreads, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonThread1, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 14;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524887F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524886F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.524887F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.502261F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 36.19909F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(600, 503);
            this.tableLayoutPanel2.TabIndex = 46;
            // 
            // ThreadsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 503);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MinimumSize = new System.Drawing.Size(616, 542);
            this.Name = "ThreadsForm";
            this.Text = "ThreadsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThreadsForm_FormClosing);
            this.Load += new System.EventHandler(this.ThreadsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
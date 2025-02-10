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
            this.label7 = new System.Windows.Forms.Label();
            this.radioButtonPercent5 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPercent = new System.Windows.Forms.TextBox();
            this.radioButtonPercent4 = new System.Windows.Forms.RadioButton();
            this.radioButtonThread4 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonPercent3 = new System.Windows.Forms.RadioButton();
            this.radioButtonThread3 = new System.Windows.Forms.RadioButton();
            this.radioButtonPercent1 = new System.Windows.Forms.RadioButton();
            this.radioButtonPercent2 = new System.Windows.Forms.RadioButton();
            this.radioButtonThread2 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonThread1 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.textBoxThread = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioButtonThread5 = new System.Windows.Forms.RadioButton();
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(208, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 13);
            this.label7.TabIndex = 42;
            this.label7.Text = "Percentage of threads used";
            // 
            // radioButtonPercent5
            // 
            this.radioButtonPercent5.AutoSize = true;
            this.radioButtonPercent5.Location = new System.Drawing.Point(209, 181);
            this.radioButtonPercent5.Name = "radioButtonPercent5";
            this.radioButtonPercent5.Size = new System.Drawing.Size(39, 17);
            this.radioButtonPercent5.TabIndex = 41;
            this.radioButtonPercent5.TabStop = true;
            this.radioButtonPercent5.Text = "0%";
            this.radioButtonPercent5.UseVisualStyleBackColor = true;
            this.radioButtonPercent5.Click += new System.EventHandler(this.RadioButtonPressed);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "Number of threads";
            // 
            // textBoxPercent
            // 
            this.textBoxPercent.Location = new System.Drawing.Point(209, 50);
            this.textBoxPercent.Name = "textBoxPercent";
            this.textBoxPercent.Size = new System.Drawing.Size(187, 20);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(208, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "From 0% to 100%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(260, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "*Know that percentages are prefered by the computer";
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
            // radioButtonPercent1
            // 
            this.radioButtonPercent1.AutoSize = true;
            this.radioButtonPercent1.Location = new System.Drawing.Point(209, 89);
            this.radioButtonPercent1.Name = "radioButtonPercent1";
            this.radioButtonPercent1.Size = new System.Drawing.Size(51, 17);
            this.radioButtonPercent1.TabIndex = 36;
            this.radioButtonPercent1.TabStop = true;
            this.radioButtonPercent1.Text = "100%";
            this.radioButtonPercent1.UseVisualStyleBackColor = true;
            this.radioButtonPercent1.Click += new System.EventHandler(this.RadioButtonPressed);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "*Lower thread count can slow down calculations";
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(150, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 26;
            this.button3.Text = "Default";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // textBoxThread
            // 
            this.textBoxThread.Location = new System.Drawing.Point(15, 50);
            this.textBoxThread.Name = "textBoxThread";
            this.textBoxThread.Size = new System.Drawing.Size(162, 20);
            this.textBoxThread.TabIndex = 22;
            this.textBoxThread.TextChanged += new System.EventHandler(this.textBoxThread_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "From 1 to max. number of threads";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(285, 245);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 245);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "How many threads do you want to use in the program?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(250, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "*0% means only one thread may be used at all times";
            // 
            // radioButtonThread5
            // 
            this.radioButtonThread5.AutoSize = true;
            this.radioButtonThread5.Location = new System.Drawing.Point(18, 182);
            this.radioButtonThread5.Name = "radioButtonThread5";
            this.radioButtonThread5.Size = new System.Drawing.Size(157, 17);
            this.radioButtonThread5.TabIndex = 44;
            this.radioButtonThread5.Text = "Maximum number of threads";
            this.radioButtonThread5.UseVisualStyleBackColor = true;
            this.radioButtonThread5.Click += new System.EventHandler(this.RadioButtonPressed);
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
            this.groupBox1.Size = new System.Drawing.Size(367, 117);
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
            this.ClientSize = new System.Drawing.Size(419, 407);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonThread5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radioButtonPercent5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxPercent);
            this.Controls.Add(this.radioButtonPercent4);
            this.Controls.Add(this.radioButtonThread4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonPercent3);
            this.Controls.Add(this.radioButtonThread3);
            this.Controls.Add(this.radioButtonPercent1);
            this.Controls.Add(this.radioButtonPercent2);
            this.Controls.Add(this.radioButtonThread2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radioButtonThread1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBoxThread);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "ThreadsForm";
            this.Text = "ThreadsForm";
            this.Load += new System.EventHandler(this.ThreadsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButtonPercent5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPercent;
        private System.Windows.Forms.RadioButton radioButtonPercent4;
        private System.Windows.Forms.RadioButton radioButtonThread4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonPercent3;
        private System.Windows.Forms.RadioButton radioButtonThread3;
        private System.Windows.Forms.RadioButton radioButtonPercent1;
        private System.Windows.Forms.RadioButton radioButtonPercent2;
        private System.Windows.Forms.RadioButton radioButtonThread2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonThread1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBoxThread;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButtonThread5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCPUName;
        private System.Windows.Forms.Label labelCPUManufacturer;
        private System.Windows.Forms.Label labelCPUCores;
        private System.Windows.Forms.Label labelCPUMaxSpeed;
        private System.Windows.Forms.Label labelCPUThread;
        private System.Windows.Forms.Label labelCPUDescription;
    }
}
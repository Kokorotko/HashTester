namespace HashTester
{
    partial class UIUpdateFrequency
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
            this.labelQuestion = new System.Windows.Forms.Label();
            this.textBoxMiliseconds = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDefault = new System.Windows.Forms.Button();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.labelRangeT = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelRangeFPS = new System.Windows.Forms.Label();
            this.textBoxFPS = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.labelFPS = new System.Windows.Forms.Label();
            this.labelTimeToUpdate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Location = new System.Drawing.Point(26, 9);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(384, 13);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "How many times a second do you want to update the UI (for specific operations)";
            // 
            // textBoxMiliseconds
            // 
            this.textBoxMiliseconds.Location = new System.Drawing.Point(210, 54);
            this.textBoxMiliseconds.Name = "textBoxMiliseconds";
            this.textBoxMiliseconds.Size = new System.Drawing.Size(187, 20);
            this.textBoxMiliseconds.TabIndex = 2;
            this.textBoxMiliseconds.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(16, 235);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(129, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(286, 235);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(129, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonDefault
            // 
            this.buttonDefault.Location = new System.Drawing.Point(151, 235);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(129, 23);
            this.buttonDefault.TabIndex = 5;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelInfo2
            // 
            this.labelInfo2.AutoSize = true;
            this.labelInfo2.Location = new System.Drawing.Point(16, 219);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(239, 13);
            this.labelInfo2.TabIndex = 6;
            this.labelInfo2.Text = "*Higher frequency can cause performance issues";
            this.labelInfo2.Click += new System.EventHandler(this.labelInfo2_Click);
            // 
            // labelRangeT
            // 
            this.labelRangeT.AutoSize = true;
            this.labelRangeT.Location = new System.Drawing.Point(209, 77);
            this.labelRangeT.Name = "labelRangeT";
            this.labelRangeT.Size = new System.Drawing.Size(170, 13);
            this.labelRangeT.TabIndex = 10;
            this.labelRangeT.Text = "Please set numbers from 8 to 1000";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(210, 185);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(85, 17);
            this.radioButton6.TabIndex = 19;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "50ms (20fps)";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(210, 162);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(91, 17);
            this.radioButton7.TabIndex = 18;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "100ms (10fps)";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(210, 139);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(88, 17);
            this.radioButton8.TabIndex = 17;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "250ms (4 fps)";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(210, 116);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(85, 17);
            this.radioButton9.TabIndex = 16;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "500ms (2fps)";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(210, 93);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(91, 17);
            this.radioButton10.TabIndex = 15;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "1000ms (1fps)";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Location = new System.Drawing.Point(16, 206);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(255, 13);
            this.labelInfo.TabIndex = 13;
            this.labelInfo.Text = "*Know that miliseconds are prefered by the computer";
            // 
            // labelRangeFPS
            // 
            this.labelRangeFPS.AutoSize = true;
            this.labelRangeFPS.Location = new System.Drawing.Point(16, 77);
            this.labelRangeFPS.Name = "labelRangeFPS";
            this.labelRangeFPS.Size = new System.Drawing.Size(164, 13);
            this.labelRangeFPS.TabIndex = 9;
            this.labelRangeFPS.Text = "Please set numbers from 1 to 125";
            // 
            // textBoxFPS
            // 
            this.textBoxFPS.Location = new System.Drawing.Point(16, 54);
            this.textBoxFPS.Name = "textBoxFPS";
            this.textBoxFPS.Size = new System.Drawing.Size(187, 20);
            this.textBoxFPS.TabIndex = 1;
            this.textBoxFPS.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(19, 94);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(54, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.Text = "12 fps";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(19, 117);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.Text = "24 fps";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(19, 140);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(54, 17);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "30 fps";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(19, 163);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(54, 17);
            this.radioButton4.TabIndex = 13;
            this.radioButton4.Text = "60 fps";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(19, 186);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(60, 17);
            this.radioButton5.TabIndex = 14;
            this.radioButton5.Text = "125 fps";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Location = new System.Drawing.Point(16, 38);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(162, 13);
            this.labelFPS.TabIndex = 15;
            this.labelFPS.Text = "Target Frames per Second (FPS)";
            // 
            // labelTimeToUpdate
            // 
            this.labelTimeToUpdate.AutoSize = true;
            this.labelTimeToUpdate.Location = new System.Drawing.Point(209, 38);
            this.labelTimeToUpdate.Name = "labelTimeToUpdate";
            this.labelTimeToUpdate.Size = new System.Drawing.Size(99, 13);
            this.labelTimeToUpdate.TabIndex = 20;
            this.labelTimeToUpdate.Text = "Every x miliseconds";
            // 
            // UIUpdateFrequency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 265);
            this.Controls.Add(this.labelTimeToUpdate);
            this.Controls.Add(this.radioButton6);
            this.Controls.Add(this.labelFPS);
            this.Controls.Add(this.textBoxMiliseconds);
            this.Controls.Add(this.radioButton7);
            this.Controls.Add(this.radioButton5);
            this.Controls.Add(this.labelRangeT);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.radioButton8);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton10);
            this.Controls.Add(this.radioButton9);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.labelInfo2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.buttonDefault);
            this.Controls.Add(this.textBoxFPS);
            this.Controls.Add(this.labelRangeFPS);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelQuestion);
            this.Name = "UIUpdateFrequency";
            this.Text = "UIUpdateFrequency";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIUpdateFrequency_FormClosing);
            this.Load += new System.EventHandler(this.UIUpdateFrequency_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.TextBox textBoxMiliseconds;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDefault;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.Label labelRangeT;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelRangeFPS;
        private System.Windows.Forms.TextBox textBoxFPS;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.Label labelTimeToUpdate;
    }
}
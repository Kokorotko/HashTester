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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelQuestion, 6);
            this.labelQuestion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelQuestion.Location = new System.Drawing.Point(4, 0);
            this.labelQuestion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(617, 28);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "How many times a second do you want to update the UI (for specific operations)";
            this.labelQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMiliseconds
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxMiliseconds, 3);
            this.textBoxMiliseconds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMiliseconds.Location = new System.Drawing.Point(316, 60);
            this.textBoxMiliseconds.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMiliseconds.Name = "textBoxMiliseconds";
            this.textBoxMiliseconds.Size = new System.Drawing.Size(305, 22);
            this.textBoxMiliseconds.TabIndex = 2;
            this.textBoxMiliseconds.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonSave
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonSave, 2);
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(4, 341);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(200, 27);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonCancel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonCancel, 2);
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonCancel.Location = new System.Drawing.Point(420, 341);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(201, 27);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonDefault
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonDefault, 2);
            this.buttonDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDefault.Location = new System.Drawing.Point(212, 341);
            this.buttonDefault.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDefault.Name = "buttonDefault";
            this.buttonDefault.Size = new System.Drawing.Size(200, 27);
            this.buttonDefault.TabIndex = 5;
            this.buttonDefault.Text = "Default";
            this.buttonDefault.UseVisualStyleBackColor = true;
            this.buttonDefault.Click += new System.EventHandler(this.button3_Click);
            // 
            // labelInfo2
            // 
            this.labelInfo2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelInfo2, 6);
            this.labelInfo2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo2.Location = new System.Drawing.Point(4, 309);
            this.labelInfo2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(617, 28);
            this.labelInfo2.TabIndex = 6;
            this.labelInfo2.Text = "*Higher frequency can cause performance issues";
            this.labelInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRangeT
            // 
            this.labelRangeT.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelRangeT, 3);
            this.labelRangeT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRangeT.Location = new System.Drawing.Point(316, 113);
            this.labelRangeT.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRangeT.Name = "labelRangeT";
            this.labelRangeT.Size = new System.Drawing.Size(305, 28);
            this.labelRangeT.TabIndex = 10;
            this.labelRangeT.Text = "Please set numbers from 8 to 1000";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton6, 3);
            this.radioButton6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton6.Location = new System.Drawing.Point(316, 257);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(305, 20);
            this.radioButton6.TabIndex = 19;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "50ms (20fps)";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton7, 3);
            this.radioButton7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton7.Location = new System.Drawing.Point(316, 229);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(305, 20);
            this.radioButton7.TabIndex = 18;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "100ms (10fps)";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton8, 3);
            this.radioButton8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton8.Location = new System.Drawing.Point(316, 201);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(305, 20);
            this.radioButton8.TabIndex = 17;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "250ms (4 fps)";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton9, 3);
            this.radioButton9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton9.Location = new System.Drawing.Point(316, 173);
            this.radioButton9.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(305, 20);
            this.radioButton9.TabIndex = 16;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "500ms (2fps)";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton10, 3);
            this.radioButton10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton10.Location = new System.Drawing.Point(316, 145);
            this.radioButton10.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(305, 20);
            this.radioButton10.TabIndex = 15;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "1000ms (1fps)";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelInfo, 6);
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelInfo.Location = new System.Drawing.Point(4, 281);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(617, 28);
            this.labelInfo.TabIndex = 13;
            this.labelInfo.Text = "*Know that miliseconds are prefered by the computer";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelRangeFPS
            // 
            this.labelRangeFPS.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelRangeFPS, 3);
            this.labelRangeFPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRangeFPS.Location = new System.Drawing.Point(4, 113);
            this.labelRangeFPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRangeFPS.Name = "labelRangeFPS";
            this.labelRangeFPS.Size = new System.Drawing.Size(304, 28);
            this.labelRangeFPS.TabIndex = 9;
            this.labelRangeFPS.Text = "Please set numbers from 1 to 125";
            // 
            // textBoxFPS
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxFPS, 3);
            this.textBoxFPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxFPS.Location = new System.Drawing.Point(4, 60);
            this.textBoxFPS.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFPS.Name = "textBoxFPS";
            this.textBoxFPS.Size = new System.Drawing.Size(304, 22);
            this.textBoxFPS.TabIndex = 1;
            this.textBoxFPS.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton1, 3);
            this.radioButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton1.Location = new System.Drawing.Point(4, 145);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(304, 20);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.Text = "12 fps";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton2, 3);
            this.radioButton2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton2.Location = new System.Drawing.Point(4, 173);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(304, 20);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.Text = "24 fps";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton3, 3);
            this.radioButton3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton3.Location = new System.Drawing.Point(4, 201);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(304, 20);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "30 fps";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton4, 3);
            this.radioButton4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton4.Location = new System.Drawing.Point(4, 229);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(304, 20);
            this.radioButton4.TabIndex = 13;
            this.radioButton4.Text = "60 fps";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.radioButton5, 3);
            this.radioButton5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButton5.Location = new System.Drawing.Point(4, 257);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(304, 20);
            this.radioButton5.TabIndex = 14;
            this.radioButton5.Text = "125 fps";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.selectedRadioButtonChanged);
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelFPS, 3);
            this.labelFPS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFPS.Location = new System.Drawing.Point(4, 28);
            this.labelFPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(304, 28);
            this.labelFPS.TabIndex = 15;
            this.labelFPS.Text = "Target Frames per Second (FPS)";
            this.labelFPS.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelTimeToUpdate
            // 
            this.labelTimeToUpdate.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTimeToUpdate, 3);
            this.labelTimeToUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTimeToUpdate.Location = new System.Drawing.Point(316, 28);
            this.labelTimeToUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTimeToUpdate.Name = "labelTimeToUpdate";
            this.labelTimeToUpdate.Size = new System.Drawing.Size(305, 28);
            this.labelTimeToUpdate.TabIndex = 20;
            this.labelTimeToUpdate.Text = "Every x miliseconds";
            this.labelTimeToUpdate.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.labelQuestion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radioButton6, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelTimeToUpdate, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButton7, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.textBoxMiliseconds, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.radioButton8, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelRangeT, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioButton9, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.radioButton10, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelFPS, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBoxFPS, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelRangeFPS, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.radioButton1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.radioButton5, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelInfo, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.radioButton2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.radioButton3, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.buttonCancel, 4, 11);
            this.tableLayoutPanel1.Controls.Add(this.buttonDefault, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.labelInfo2, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.radioButton4, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.buttonSave, 0, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 372);
            this.tableLayoutPanel1.TabIndex = 21;
            // 
            // UIUpdateFrequency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 372);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(641, 409);
            this.Name = "UIUpdateFrequency";
            this.Text = "UIUpdateFrequency";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UIUpdateFrequency_FormClosing);
            this.Load += new System.EventHandler(this.UIUpdateFrequency_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
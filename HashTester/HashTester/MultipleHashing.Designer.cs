namespace HashTester
{
    partial class MultipleHashing
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
            this.TXTInput = new System.Windows.Forms.Button();
            this.buttonHashSimpleText = new System.Windows.Forms.Button();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textHashSimple = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxShowAlgorithm = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // TXTInput
            // 
            this.TXTInput.Location = new System.Drawing.Point(92, 78);
            this.TXTInput.Name = "TXTInput";
            this.TXTInput.Size = new System.Drawing.Size(75, 23);
            this.TXTInput.TabIndex = 7;
            this.TXTInput.Text = "TXTInput";
            this.TXTInput.UseVisualStyleBackColor = true;
            this.TXTInput.Click += new System.EventHandler(this.TXTInput_Click);
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(11, 78);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(75, 23);
            this.buttonHashSimpleText.TabIndex = 6;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(208, 415);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(579, 23);
            this.buttonClearListBox.TabIndex = 14;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(208, 77);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(579, 329);
            this.listBox1.TabIndex = 13;
            // 
            // textHashSimple
            // 
            this.textHashSimple.Location = new System.Drawing.Point(11, 12);
            this.textHashSimple.Multiline = true;
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(775, 59);
            this.textHashSimple.TabIndex = 12;
            this.textHashSimple.Text = "test\r\ntest";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 108);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(49, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "MD5";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(11, 131);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 17);
            this.checkBox2.TabIndex = 16;
            this.checkBox2.Text = "SHA1";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(11, 154);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 17;
            this.checkBox3.Text = "SHA256";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(11, 177);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 17);
            this.checkBox4.TabIndex = 18;
            this.checkBox4.Text = "SHA512";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(11, 200);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(86, 17);
            this.checkBox5.TabIndex = 19;
            this.checkBox5.Text = "RipeMD-160";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Location = new System.Drawing.Point(11, 223);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(60, 17);
            this.checkBox6.TabIndex = 20;
            this.checkBox6.Text = "CRC32";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Go Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxShowAlgorithm
            // 
            this.checkBoxShowAlgorithm.AutoSize = true;
            this.checkBoxShowAlgorithm.Checked = true;
            this.checkBoxShowAlgorithm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxShowAlgorithm.Location = new System.Drawing.Point(12, 246);
            this.checkBoxShowAlgorithm.Name = "checkBoxShowAlgorithm";
            this.checkBoxShowAlgorithm.Size = new System.Drawing.Size(99, 17);
            this.checkBoxShowAlgorithm.TabIndex = 22;
            this.checkBoxShowAlgorithm.Text = "Show Algorithm";
            this.checkBoxShowAlgorithm.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 39);
            this.label1.TabIndex = 23;
            this.label1.Text = "*will overwrite the \r\n\"Include hashing algorithm\" \r\nin the output style settings";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MultipleHashing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxShowAlgorithm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.TXTInput);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Name = "MultipleHashing";
            this.Text = "MultipleHashing";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button TXTInput;
        private System.Windows.Forms.Button buttonHashSimpleText;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textHashSimple;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBoxShowAlgorithm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
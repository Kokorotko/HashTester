namespace HashTester
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonHashSimpleText = new System.Windows.Forms.Button();
            this.textHashSimple = new System.Windows.Forms.TextBox();
            this.buttonFormGradual = new System.Windows.Forms.Button();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.TXTInput = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.OutputOption = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.settingsForm = new System.Windows.Forms.Button();
            this.OutputOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(16, 64);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(75, 23);
            this.buttonHashSimpleText.TabIndex = 0;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // textHashSimple
            // 
            this.textHashSimple.Location = new System.Drawing.Point(16, 94);
            this.textHashSimple.Multiline = true;
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(775, 59);
            this.textHashSimple.TabIndex = 1;
            this.textHashSimple.Text = "Hello This is Test";
            // 
            // buttonFormGradual
            // 
            this.buttonFormGradual.Location = new System.Drawing.Point(16, 12);
            this.buttonFormGradual.Name = "buttonFormGradual";
            this.buttonFormGradual.Size = new System.Drawing.Size(102, 23);
            this.buttonFormGradual.TabIndex = 3;
            this.buttonFormGradual.Text = "Gradual Hashing";
            this.buttonFormGradual.UseVisualStyleBackColor = true;
            this.buttonFormGradual.Click += new System.EventHandler(this.buttonFormGradual_Click);
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
            this.hashSelector.Location = new System.Drawing.Point(470, 64);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(121, 21);
            this.hashSelector.TabIndex = 4;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // TXTInput
            // 
            this.TXTInput.Location = new System.Drawing.Point(97, 65);
            this.TXTInput.Name = "TXTInput";
            this.TXTInput.Size = new System.Drawing.Size(75, 23);
            this.TXTInput.TabIndex = 5;
            this.TXTInput.Text = "TXTInput";
            this.TXTInput.UseVisualStyleBackColor = true;
            this.TXTInput.Click += new System.EventHandler(this.TXTInput_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "MessageBox";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.Text = "ListBox";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(58, 17);
            this.radioButton3.TabIndex = 8;
            this.radioButton3.Text = ".txt File";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // OutputOption
            // 
            this.OutputOption.Controls.Add(this.checkBox3);
            this.OutputOption.Controls.Add(this.checkBox2);
            this.OutputOption.Controls.Add(this.checkBox1);
            this.OutputOption.Controls.Add(this.label1);
            this.OutputOption.Controls.Add(this.radioButton1);
            this.OutputOption.Controls.Add(this.radioButton3);
            this.OutputOption.Controls.Add(this.radioButton2);
            this.OutputOption.Location = new System.Drawing.Point(632, 159);
            this.OutputOption.Name = "OutputOption";
            this.OutputOption.Size = new System.Drawing.Size(156, 172);
            this.OutputOption.TabIndex = 9;
            this.OutputOption.TabStop = false;
            this.OutputOption.Text = "Output";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 148);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(135, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "Output with Hash Algo.";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 125);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(102, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Number Hashes";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 102);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(148, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Output with Original String";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "----------------------------";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 159);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(600, 251);
            this.listBox1.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(600, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Clear Listbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // settingsForm
            // 
            this.settingsForm.Location = new System.Drawing.Point(711, 12);
            this.settingsForm.Name = "settingsForm";
            this.settingsForm.Size = new System.Drawing.Size(75, 23);
            this.settingsForm.TabIndex = 12;
            this.settingsForm.Text = "Settings";
            this.settingsForm.UseVisualStyleBackColor = true;
            this.settingsForm.Click += new System.EventHandler(this.settingsForm_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.settingsForm);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.OutputOption);
            this.Controls.Add(this.TXTInput);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.buttonFormGradual);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OutputOption.ResumeLayout(false);
            this.OutputOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHashSimpleText;
        private System.Windows.Forms.TextBox textHashSimple;
        private System.Windows.Forms.Button buttonFormGradual;
        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.Button TXTInput;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox OutputOption;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button settingsForm;
    }
}


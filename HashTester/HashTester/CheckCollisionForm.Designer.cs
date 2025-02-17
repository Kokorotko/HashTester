namespace HashTester
{
    partial class CheckCollisionForm
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
            this.radioButtonString = new System.Windows.Forms.RadioButton();
            this.radioButtonHex = new System.Windows.Forms.RadioButton();
            this.radioButtonBinary = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelText = new System.Windows.Forms.Label();
            this.labelText2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButtonString
            // 
            this.radioButtonString.AutoSize = true;
            this.radioButtonString.Checked = true;
            this.radioButtonString.Location = new System.Drawing.Point(6, 19);
            this.radioButtonString.Name = "radioButtonString";
            this.radioButtonString.Size = new System.Drawing.Size(66, 17);
            this.radioButtonString.TabIndex = 0;
            this.radioButtonString.TabStop = true;
            this.radioButtonString.Text = "STRING";
            this.radioButtonString.UseVisualStyleBackColor = true;
            // 
            // radioButtonHex
            // 
            this.radioButtonHex.AutoSize = true;
            this.radioButtonHex.Location = new System.Drawing.Point(6, 42);
            this.radioButtonHex.Name = "radioButtonHex";
            this.radioButtonHex.Size = new System.Drawing.Size(47, 17);
            this.radioButtonHex.TabIndex = 1;
            this.radioButtonHex.Text = "HEX";
            this.radioButtonHex.UseVisualStyleBackColor = true;
            // 
            // radioButtonBinary
            // 
            this.radioButtonBinary.AutoSize = true;
            this.radioButtonBinary.Location = new System.Drawing.Point(6, 65);
            this.radioButtonBinary.Name = "radioButtonBinary";
            this.radioButtonBinary.Size = new System.Drawing.Size(65, 17);
            this.radioButtonBinary.TabIndex = 2;
            this.radioButtonBinary.Text = "BINARY";
            this.radioButtonBinary.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonString);
            this.groupBox1.Controls.Add(this.radioButtonBinary);
            this.groupBox1.Controls.Add(this.radioButtonHex);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Format";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(114, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Location = new System.Drawing.Point(114, 14);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(40, 13);
            this.labelText.TabIndex = 5;
            this.labelText.Text = "Text01";
            // 
            // labelText2
            // 
            this.labelText2.AutoSize = true;
            this.labelText2.Location = new System.Drawing.Point(114, 65);
            this.labelText2.Name = "labelText2";
            this.labelText2.Size = new System.Drawing.Size(40, 13);
            this.labelText2.TabIndex = 7;
            this.labelText2.Text = "Text02";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(114, 81);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 6;
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(12, 118);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(327, 23);
            this.buttonCheck.TabIndex = 8;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.button1_Click);
            // 
            // hashSelector
            // 
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "CRC32",
            "MD5",
            "RipeMD-160",
            "SHA1",
            "SHA256",
            "SHA512"});
            this.hashSelector.Location = new System.Drawing.Point(222, 29);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(121, 21);
            this.hashSelector.TabIndex = 9;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.labelAlgorithm.Location = new System.Drawing.Point(219, 14);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(50, 13);
            this.labelAlgorithm.TabIndex = 10;
            this.labelAlgorithm.Text = "Algorithm";
            // 
            // CheckCollisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 152);
            this.Controls.Add(this.labelAlgorithm);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.labelText2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.labelText);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckCollisionForm";
            this.Text = "CheckCollisionForm";
            this.Load += new System.EventHandler(this.CheckCollisionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonString;
        private System.Windows.Forms.RadioButton radioButtonHex;
        private System.Windows.Forms.RadioButton radioButtonBinary;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.Label labelText2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonCheck;
        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.Label labelAlgorithm;
    }
}
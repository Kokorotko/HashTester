namespace HashTester
{
    partial class SaltAndPepperQuestion
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
            this.groupBoxSalt = new System.Windows.Forms.GroupBox();
            this.radioButtonSaltGen = new System.Windows.Forms.RadioButton();
            this.radioButtonSaltOwn = new System.Windows.Forms.RadioButton();
            this.textBoxSaltLenght = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSalt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxPepper = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPepper = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPepperLenght = new System.Windows.Forms.TextBox();
            this.radioButtonPepperOwn = new System.Windows.Forms.RadioButton();
            this.radioButtonPepperGen = new System.Windows.Forms.RadioButton();
            this.textBoxGenerate = new System.Windows.Forms.Button();
            this.textBoxHashID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBoxSalt.SuspendLayout();
            this.groupBoxPepper.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSalt
            // 
            this.groupBoxSalt.Controls.Add(this.label2);
            this.groupBoxSalt.Controls.Add(this.textBoxSalt);
            this.groupBoxSalt.Controls.Add(this.label1);
            this.groupBoxSalt.Controls.Add(this.textBoxSaltLenght);
            this.groupBoxSalt.Controls.Add(this.radioButtonSaltOwn);
            this.groupBoxSalt.Controls.Add(this.radioButtonSaltGen);
            this.groupBoxSalt.Location = new System.Drawing.Point(13, 13);
            this.groupBoxSalt.Name = "groupBoxSalt";
            this.groupBoxSalt.Size = new System.Drawing.Size(120, 150);
            this.groupBoxSalt.TabIndex = 0;
            this.groupBoxSalt.TabStop = false;
            this.groupBoxSalt.Text = "Salt";
            // 
            // radioButtonSaltGen
            // 
            this.radioButtonSaltGen.AutoSize = true;
            this.radioButtonSaltGen.Checked = true;
            this.radioButtonSaltGen.Location = new System.Drawing.Point(7, 20);
            this.radioButtonSaltGen.Name = "radioButtonSaltGen";
            this.radioButtonSaltGen.Size = new System.Drawing.Size(90, 17);
            this.radioButtonSaltGen.TabIndex = 0;
            this.radioButtonSaltGen.TabStop = true;
            this.radioButtonSaltGen.Text = "Generate Salt";
            this.radioButtonSaltGen.UseVisualStyleBackColor = true;
            this.radioButtonSaltGen.CheckedChanged += new System.EventHandler(this.radioButtonSaltGen_CheckedChanged);
            // 
            // radioButtonSaltOwn
            // 
            this.radioButtonSaltOwn.AutoSize = true;
            this.radioButtonSaltOwn.Location = new System.Drawing.Point(6, 83);
            this.radioButtonSaltOwn.Name = "radioButtonSaltOwn";
            this.radioButtonSaltOwn.Size = new System.Drawing.Size(104, 17);
            this.radioButtonSaltOwn.TabIndex = 1;
            this.radioButtonSaltOwn.Text = "Include own Salt";
            this.radioButtonSaltOwn.UseVisualStyleBackColor = true;
            this.radioButtonSaltOwn.CheckedChanged += new System.EventHandler(this.radioButtonSaltOwn_CheckedChanged);
            // 
            // textBoxSaltLenght
            // 
            this.textBoxSaltLenght.Location = new System.Drawing.Point(6, 57);
            this.textBoxSaltLenght.Name = "textBoxSaltLenght";
            this.textBoxSaltLenght.Size = new System.Drawing.Size(100, 20);
            this.textBoxSaltLenght.TabIndex = 2;
            this.textBoxSaltLenght.Text = "6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lenght of Salt";
            // 
            // textBoxSalt
            // 
            this.textBoxSalt.Location = new System.Drawing.Point(6, 119);
            this.textBoxSalt.Name = "textBoxSalt";
            this.textBoxSalt.Size = new System.Drawing.Size(100, 20);
            this.textBoxSalt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Own salt";
            // 
            // groupBoxPepper
            // 
            this.groupBoxPepper.Controls.Add(this.label3);
            this.groupBoxPepper.Controls.Add(this.textBoxPepper);
            this.groupBoxPepper.Controls.Add(this.label4);
            this.groupBoxPepper.Controls.Add(this.textBoxPepperLenght);
            this.groupBoxPepper.Controls.Add(this.radioButtonPepperOwn);
            this.groupBoxPepper.Controls.Add(this.radioButtonPepperGen);
            this.groupBoxPepper.Location = new System.Drawing.Point(139, 13);
            this.groupBoxPepper.Name = "groupBoxPepper";
            this.groupBoxPepper.Size = new System.Drawing.Size(117, 150);
            this.groupBoxPepper.TabIndex = 6;
            this.groupBoxPepper.TabStop = false;
            this.groupBoxPepper.Text = "Pepper";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Own pepper";
            // 
            // textBoxPepper
            // 
            this.textBoxPepper.Location = new System.Drawing.Point(6, 119);
            this.textBoxPepper.Name = "textBoxPepper";
            this.textBoxPepper.Size = new System.Drawing.Size(100, 20);
            this.textBoxPepper.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Lenght of pepper";
            // 
            // textBoxPepperLenght
            // 
            this.textBoxPepperLenght.Location = new System.Drawing.Point(6, 57);
            this.textBoxPepperLenght.Name = "textBoxPepperLenght";
            this.textBoxPepperLenght.Size = new System.Drawing.Size(100, 20);
            this.textBoxPepperLenght.TabIndex = 2;
            this.textBoxPepperLenght.Text = "1";
            // 
            // radioButtonPepperOwn
            // 
            this.radioButtonPepperOwn.AutoSize = true;
            this.radioButtonPepperOwn.Location = new System.Drawing.Point(6, 83);
            this.radioButtonPepperOwn.Name = "radioButtonPepperOwn";
            this.radioButtonPepperOwn.Size = new System.Drawing.Size(104, 17);
            this.radioButtonPepperOwn.TabIndex = 1;
            this.radioButtonPepperOwn.Text = "Include own Salt";
            this.radioButtonPepperOwn.UseVisualStyleBackColor = true;
            this.radioButtonPepperOwn.CheckedChanged += new System.EventHandler(this.radioButtonPepperOwn_CheckedChanged);
            // 
            // radioButtonPepperGen
            // 
            this.radioButtonPepperGen.AutoSize = true;
            this.radioButtonPepperGen.Checked = true;
            this.radioButtonPepperGen.Location = new System.Drawing.Point(7, 20);
            this.radioButtonPepperGen.Name = "radioButtonPepperGen";
            this.radioButtonPepperGen.Size = new System.Drawing.Size(105, 17);
            this.radioButtonPepperGen.TabIndex = 0;
            this.radioButtonPepperGen.TabStop = true;
            this.radioButtonPepperGen.Text = "Generate pepper";
            this.radioButtonPepperGen.UseVisualStyleBackColor = true;
            this.radioButtonPepperGen.CheckedChanged += new System.EventHandler(this.radioButtonPepperGen_CheckedChanged);
            // 
            // textBoxGenerate
            // 
            this.textBoxGenerate.Location = new System.Drawing.Point(13, 213);
            this.textBoxGenerate.Name = "textBoxGenerate";
            this.textBoxGenerate.Size = new System.Drawing.Size(243, 23);
            this.textBoxGenerate.TabIndex = 7;
            this.textBoxGenerate.Text = "Generate";
            this.textBoxGenerate.UseVisualStyleBackColor = true;
            this.textBoxGenerate.Click += new System.EventHandler(this.textBoxGenerate_Click);
            // 
            // textBoxHashID
            // 
            this.textBoxHashID.Location = new System.Drawing.Point(22, 187);
            this.textBoxHashID.Name = "textBoxHashID";
            this.textBoxHashID.Size = new System.Drawing.Size(223, 20);
            this.textBoxHashID.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(109, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "ID of hash";
            // 
            // SaltAndPepperQuestion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 246);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxHashID);
            this.Controls.Add(this.textBoxGenerate);
            this.Controls.Add(this.groupBoxPepper);
            this.Controls.Add(this.groupBoxSalt);
            this.Name = "SaltAndPepperQuestion";
            this.Text = "SaltAndPepperQuestion";
            this.Load += new System.EventHandler(this.SaltAndPepperQuestion_Load);
            this.groupBoxSalt.ResumeLayout(false);
            this.groupBoxSalt.PerformLayout();
            this.groupBoxPepper.ResumeLayout(false);
            this.groupBoxPepper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSalt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSalt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSaltLenght;
        private System.Windows.Forms.RadioButton radioButtonSaltOwn;
        private System.Windows.Forms.RadioButton radioButtonSaltGen;
        private System.Windows.Forms.GroupBox groupBoxPepper;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPepper;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPepperLenght;
        private System.Windows.Forms.RadioButton radioButtonPepperOwn;
        private System.Windows.Forms.RadioButton radioButtonPepperGen;
        private System.Windows.Forms.Button textBoxGenerate;
        private System.Windows.Forms.TextBox textBoxHashID;
        private System.Windows.Forms.Label label5;
    }
}
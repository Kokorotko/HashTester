namespace HashTester
{
    partial class SaltAndPepperSetup
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
            this.labelOwnSalt = new System.Windows.Forms.Label();
            this.textBoxSalt = new System.Windows.Forms.TextBox();
            this.labelLenghtSalt = new System.Windows.Forms.Label();
            this.textBoxSaltLenght = new System.Windows.Forms.TextBox();
            this.radioButtonSaltOwn = new System.Windows.Forms.RadioButton();
            this.radioButtonSaltGen = new System.Windows.Forms.RadioButton();
            this.groupBoxPepper = new System.Windows.Forms.GroupBox();
            this.labelOwnPepper = new System.Windows.Forms.Label();
            this.textBoxPepper = new System.Windows.Forms.TextBox();
            this.labelLenghtPepper = new System.Windows.Forms.Label();
            this.textBoxPepperLenght = new System.Windows.Forms.TextBox();
            this.radioButtonPepperOwn = new System.Windows.Forms.RadioButton();
            this.radioButtonPepperGen = new System.Windows.Forms.RadioButton();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxHashID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.groupBoxSalt.SuspendLayout();
            this.groupBoxPepper.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSalt
            // 
            this.groupBoxSalt.Controls.Add(this.labelOwnSalt);
            this.groupBoxSalt.Controls.Add(this.textBoxSalt);
            this.groupBoxSalt.Controls.Add(this.labelLenghtSalt);
            this.groupBoxSalt.Controls.Add(this.textBoxSaltLenght);
            this.groupBoxSalt.Controls.Add(this.radioButtonSaltOwn);
            this.groupBoxSalt.Controls.Add(this.radioButtonSaltGen);
            this.groupBoxSalt.Enabled = false;
            this.groupBoxSalt.Location = new System.Drawing.Point(13, 13);
            this.groupBoxSalt.Name = "groupBoxSalt";
            this.groupBoxSalt.Size = new System.Drawing.Size(120, 150);
            this.groupBoxSalt.TabIndex = 0;
            this.groupBoxSalt.TabStop = false;
            this.groupBoxSalt.Text = "Salt";
            // 
            // labelOwnSalt
            // 
            this.labelOwnSalt.AutoSize = true;
            this.labelOwnSalt.Location = new System.Drawing.Point(6, 103);
            this.labelOwnSalt.Name = "labelOwnSalt";
            this.labelOwnSalt.Size = new System.Drawing.Size(48, 13);
            this.labelOwnSalt.TabIndex = 5;
            this.labelOwnSalt.Text = "Own salt";
            // 
            // textBoxSalt
            // 
            this.textBoxSalt.Location = new System.Drawing.Point(6, 119);
            this.textBoxSalt.Name = "textBoxSalt";
            this.textBoxSalt.Size = new System.Drawing.Size(100, 20);
            this.textBoxSalt.TabIndex = 4;
            // 
            // labelLenghtSalt
            // 
            this.labelLenghtSalt.AutoSize = true;
            this.labelLenghtSalt.Location = new System.Drawing.Point(6, 41);
            this.labelLenghtSalt.Name = "labelLenghtSalt";
            this.labelLenghtSalt.Size = new System.Drawing.Size(73, 13);
            this.labelLenghtSalt.TabIndex = 3;
            this.labelLenghtSalt.Text = "Lenght of Salt";
            // 
            // textBoxSaltLenght
            // 
            this.textBoxSaltLenght.Location = new System.Drawing.Point(6, 57);
            this.textBoxSaltLenght.Name = "textBoxSaltLenght";
            this.textBoxSaltLenght.Size = new System.Drawing.Size(100, 20);
            this.textBoxSaltLenght.TabIndex = 2;
            this.textBoxSaltLenght.Text = "6";
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
            // groupBoxPepper
            // 
            this.groupBoxPepper.Controls.Add(this.labelOwnPepper);
            this.groupBoxPepper.Controls.Add(this.textBoxPepper);
            this.groupBoxPepper.Controls.Add(this.labelLenghtPepper);
            this.groupBoxPepper.Controls.Add(this.textBoxPepperLenght);
            this.groupBoxPepper.Controls.Add(this.radioButtonPepperOwn);
            this.groupBoxPepper.Controls.Add(this.radioButtonPepperGen);
            this.groupBoxPepper.Enabled = false;
            this.groupBoxPepper.Location = new System.Drawing.Point(139, 13);
            this.groupBoxPepper.Name = "groupBoxPepper";
            this.groupBoxPepper.Size = new System.Drawing.Size(117, 150);
            this.groupBoxPepper.TabIndex = 6;
            this.groupBoxPepper.TabStop = false;
            this.groupBoxPepper.Text = "Pepper";
            // 
            // labelOwnPepper
            // 
            this.labelOwnPepper.AutoSize = true;
            this.labelOwnPepper.Location = new System.Drawing.Point(6, 103);
            this.labelOwnPepper.Name = "labelOwnPepper";
            this.labelOwnPepper.Size = new System.Drawing.Size(65, 13);
            this.labelOwnPepper.TabIndex = 5;
            this.labelOwnPepper.Text = "Own pepper";
            // 
            // textBoxPepper
            // 
            this.textBoxPepper.Location = new System.Drawing.Point(6, 119);
            this.textBoxPepper.Name = "textBoxPepper";
            this.textBoxPepper.Size = new System.Drawing.Size(100, 20);
            this.textBoxPepper.TabIndex = 4;
            // 
            // labelLenghtPepper
            // 
            this.labelLenghtPepper.AutoSize = true;
            this.labelLenghtPepper.Location = new System.Drawing.Point(6, 41);
            this.labelLenghtPepper.Name = "labelLenghtPepper";
            this.labelLenghtPepper.Size = new System.Drawing.Size(88, 13);
            this.labelLenghtPepper.TabIndex = 3;
            this.labelLenghtPepper.Text = "Lenght of pepper";
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
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(13, 213);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(243, 23);
            this.buttonGenerate.TabIndex = 7;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.textBoxGenerate_Click);
            // 
            // textBoxHashID
            // 
            this.textBoxHashID.Location = new System.Drawing.Point(13, 187);
            this.textBoxHashID.Name = "textBoxHashID";
            this.textBoxHashID.Size = new System.Drawing.Size(243, 20);
            this.textBoxHashID.TabIndex = 8;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(109, 171);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(56, 13);
            this.labelID.TabIndex = 9;
            this.labelID.Text = "ID of hash";
            // 
            // SaltAndPepperSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 246);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.textBoxHashID);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.groupBoxPepper);
            this.Controls.Add(this.groupBoxSalt);
            this.Name = "SaltAndPepperSetup";
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
        private System.Windows.Forms.Label labelOwnSalt;
        private System.Windows.Forms.TextBox textBoxSalt;
        private System.Windows.Forms.Label labelLenghtSalt;
        private System.Windows.Forms.TextBox textBoxSaltLenght;
        private System.Windows.Forms.RadioButton radioButtonSaltOwn;
        private System.Windows.Forms.RadioButton radioButtonSaltGen;
        private System.Windows.Forms.GroupBox groupBoxPepper;
        private System.Windows.Forms.Label labelOwnPepper;
        private System.Windows.Forms.TextBox textBoxPepper;
        private System.Windows.Forms.Label labelLenghtPepper;
        private System.Windows.Forms.TextBox textBoxPepperLenght;
        private System.Windows.Forms.RadioButton radioButtonPepperOwn;
        private System.Windows.Forms.RadioButton radioButtonPepperGen;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxHashID;
        private System.Windows.Forms.Label labelID;
    }
}
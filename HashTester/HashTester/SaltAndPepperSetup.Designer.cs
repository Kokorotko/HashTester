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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radioButtonSaltGen = new System.Windows.Forms.RadioButton();
            this.textBoxSalt = new System.Windows.Forms.TextBox();
            this.labelLenghtSalt = new System.Windows.Forms.Label();
            this.radioButtonSaltOwn = new System.Windows.Forms.RadioButton();
            this.textBoxSaltLenght = new System.Windows.Forms.TextBox();
            this.groupBoxPepper = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPepper = new System.Windows.Forms.TextBox();
            this.radioButtonPepperGen = new System.Windows.Forms.RadioButton();
            this.radioButtonPepperOwn = new System.Windows.Forms.RadioButton();
            this.textBoxPepperLenght = new System.Windows.Forms.TextBox();
            this.labelLenghtPepper = new System.Windows.Forms.Label();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.textBoxHashID = new System.Windows.Forms.TextBox();
            this.labelID = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxSalt.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxPepper.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSalt
            // 
            this.groupBoxSalt.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxSalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSalt.Enabled = false;
            this.groupBoxSalt.Location = new System.Drawing.Point(3, 3);
            this.groupBoxSalt.Name = "groupBoxSalt";
            this.groupBoxSalt.Size = new System.Drawing.Size(161, 192);
            this.groupBoxSalt.TabIndex = 0;
            this.groupBoxSalt.TabStop = false;
            this.groupBoxSalt.Text = "Salt";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSaltGen, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSalt, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelLenghtSalt, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radioButtonSaltOwn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBoxSaltLenght, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(155, 173);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // radioButtonSaltGen
            // 
            this.radioButtonSaltGen.AutoSize = true;
            this.radioButtonSaltGen.Checked = true;
            this.radioButtonSaltGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonSaltGen.Location = new System.Drawing.Point(3, 3);
            this.radioButtonSaltGen.Name = "radioButtonSaltGen";
            this.radioButtonSaltGen.Size = new System.Drawing.Size(149, 32);
            this.radioButtonSaltGen.TabIndex = 0;
            this.radioButtonSaltGen.TabStop = true;
            this.radioButtonSaltGen.Text = "Generate Salt";
            this.radioButtonSaltGen.UseVisualStyleBackColor = true;
            this.radioButtonSaltGen.CheckedChanged += new System.EventHandler(this.radioButtonSaltGen_CheckedChanged);
            // 
            // textBoxSalt
            // 
            this.textBoxSalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSalt.Location = new System.Drawing.Point(3, 136);
            this.textBoxSalt.Name = "textBoxSalt";
            this.textBoxSalt.Size = new System.Drawing.Size(149, 20);
            this.textBoxSalt.TabIndex = 4;
            // 
            // labelLenghtSalt
            // 
            this.labelLenghtSalt.AutoSize = true;
            this.labelLenghtSalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLenghtSalt.Location = new System.Drawing.Point(3, 38);
            this.labelLenghtSalt.Name = "labelLenghtSalt";
            this.labelLenghtSalt.Size = new System.Drawing.Size(149, 19);
            this.labelLenghtSalt.TabIndex = 3;
            this.labelLenghtSalt.Text = "Lenght of Salt";
            this.labelLenghtSalt.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioButtonSaltOwn
            // 
            this.radioButtonSaltOwn.AutoSize = true;
            this.radioButtonSaltOwn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonSaltOwn.Location = new System.Drawing.Point(3, 98);
            this.radioButtonSaltOwn.Name = "radioButtonSaltOwn";
            this.radioButtonSaltOwn.Size = new System.Drawing.Size(149, 32);
            this.radioButtonSaltOwn.TabIndex = 1;
            this.radioButtonSaltOwn.Text = "Include own Salt";
            this.radioButtonSaltOwn.UseVisualStyleBackColor = true;
            this.radioButtonSaltOwn.CheckedChanged += new System.EventHandler(this.radioButtonSaltOwn_CheckedChanged);
            // 
            // textBoxSaltLenght
            // 
            this.textBoxSaltLenght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxSaltLenght.Location = new System.Drawing.Point(3, 60);
            this.textBoxSaltLenght.Name = "textBoxSaltLenght";
            this.textBoxSaltLenght.Size = new System.Drawing.Size(149, 20);
            this.textBoxSaltLenght.TabIndex = 2;
            this.textBoxSaltLenght.Text = "6";
            // 
            // groupBoxPepper
            // 
            this.groupBoxPepper.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxPepper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxPepper.Enabled = false;
            this.groupBoxPepper.Location = new System.Drawing.Point(170, 3);
            this.groupBoxPepper.Name = "groupBoxPepper";
            this.groupBoxPepper.Size = new System.Drawing.Size(162, 192);
            this.groupBoxPepper.TabIndex = 6;
            this.groupBoxPepper.TabStop = false;
            this.groupBoxPepper.Text = "Pepper";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxPepper, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonPepperGen, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.radioButtonPepperOwn, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxPepperLenght, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.labelLenghtPepper, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.22222F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(156, 173);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // textBoxPepper
            // 
            this.textBoxPepper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPepper.Location = new System.Drawing.Point(3, 136);
            this.textBoxPepper.Name = "textBoxPepper";
            this.textBoxPepper.Size = new System.Drawing.Size(150, 20);
            this.textBoxPepper.TabIndex = 4;
            // 
            // radioButtonPepperGen
            // 
            this.radioButtonPepperGen.AutoSize = true;
            this.radioButtonPepperGen.Checked = true;
            this.radioButtonPepperGen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonPepperGen.Location = new System.Drawing.Point(3, 3);
            this.radioButtonPepperGen.Name = "radioButtonPepperGen";
            this.radioButtonPepperGen.Size = new System.Drawing.Size(150, 32);
            this.radioButtonPepperGen.TabIndex = 0;
            this.radioButtonPepperGen.TabStop = true;
            this.radioButtonPepperGen.Text = "Generate pepper";
            this.radioButtonPepperGen.UseVisualStyleBackColor = true;
            this.radioButtonPepperGen.CheckedChanged += new System.EventHandler(this.radioButtonPepperGen_CheckedChanged);
            // 
            // radioButtonPepperOwn
            // 
            this.radioButtonPepperOwn.AutoSize = true;
            this.radioButtonPepperOwn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioButtonPepperOwn.Location = new System.Drawing.Point(3, 98);
            this.radioButtonPepperOwn.Name = "radioButtonPepperOwn";
            this.radioButtonPepperOwn.Size = new System.Drawing.Size(150, 32);
            this.radioButtonPepperOwn.TabIndex = 1;
            this.radioButtonPepperOwn.Text = "Include own Pepper";
            this.radioButtonPepperOwn.UseVisualStyleBackColor = true;
            this.radioButtonPepperOwn.CheckedChanged += new System.EventHandler(this.radioButtonPepperOwn_CheckedChanged);
            // 
            // textBoxPepperLenght
            // 
            this.textBoxPepperLenght.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPepperLenght.Location = new System.Drawing.Point(3, 60);
            this.textBoxPepperLenght.Name = "textBoxPepperLenght";
            this.textBoxPepperLenght.Size = new System.Drawing.Size(150, 20);
            this.textBoxPepperLenght.TabIndex = 2;
            this.textBoxPepperLenght.Text = "1";
            // 
            // labelLenghtPepper
            // 
            this.labelLenghtPepper.AutoSize = true;
            this.labelLenghtPepper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLenghtPepper.Location = new System.Drawing.Point(3, 38);
            this.labelLenghtPepper.Name = "labelLenghtPepper";
            this.labelLenghtPepper.Size = new System.Drawing.Size(150, 19);
            this.labelLenghtPepper.TabIndex = 3;
            this.labelLenghtPepper.Text = "Lenght of pepper";
            this.labelLenghtPepper.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // buttonGenerate
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.buttonGenerate, 2);
            this.buttonGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonGenerate.Location = new System.Drawing.Point(3, 259);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(329, 35);
            this.buttonGenerate.TabIndex = 7;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.textBoxGenerate_Click);
            // 
            // textBoxHashID
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.textBoxHashID, 2);
            this.textBoxHashID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHashID.Location = new System.Drawing.Point(3, 220);
            this.textBoxHashID.Name = "textBoxHashID";
            this.textBoxHashID.Size = new System.Drawing.Size(329, 20);
            this.textBoxHashID.TabIndex = 8;
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.labelID, 2);
            this.labelID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelID.Location = new System.Drawing.Point(3, 198);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(329, 19);
            this.labelID.TabIndex = 9;
            this.labelID.Text = "ID of hash";
            this.labelID.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBoxSalt, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonGenerate, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.textBoxHashID, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.labelID, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxPepper, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(335, 297);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // SaltAndPepperSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 297);
            this.Controls.Add(this.tableLayoutPanel3);
            this.MinimumSize = new System.Drawing.Size(351, 336);
            this.Name = "SaltAndPepperSetup";
            this.Text = "SaltAndPepperQuestion";
            this.Load += new System.EventHandler(this.SaltAndPepperQuestion_Load);
            this.groupBoxSalt.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxPepper.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSalt;
        private System.Windows.Forms.TextBox textBoxSalt;
        private System.Windows.Forms.Label labelLenghtSalt;
        private System.Windows.Forms.TextBox textBoxSaltLenght;
        private System.Windows.Forms.RadioButton radioButtonSaltOwn;
        private System.Windows.Forms.RadioButton radioButtonSaltGen;
        private System.Windows.Forms.GroupBox groupBoxPepper;
        private System.Windows.Forms.TextBox textBoxPepper;
        private System.Windows.Forms.Label labelLenghtPepper;
        private System.Windows.Forms.TextBox textBoxPepperLenght;
        private System.Windows.Forms.RadioButton radioButtonPepperOwn;
        private System.Windows.Forms.RadioButton radioButtonPepperGen;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.TextBox textBoxHashID;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}
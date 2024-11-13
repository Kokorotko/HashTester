namespace HashTester
{
    partial class FormSettings
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonVisualMode0 = new System.Windows.Forms.RadioButton();
            this.radioButtonVisualMode1 = new System.Windows.Forms.RadioButton();
            this.radioButtonVisualMode2 = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(713, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(632, 415);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(551, 415);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonVisualMode2);
            this.groupBox1.Controls.Add(this.radioButtonVisualMode1);
            this.groupBox1.Controls.Add(this.radioButtonVisualMode0);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(77, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VisualMode";
            // 
            // radioButtonVisualMode0
            // 
            this.radioButtonVisualMode0.AutoSize = true;
            this.radioButtonVisualMode0.Location = new System.Drawing.Point(7, 20);
            this.radioButtonVisualMode0.Name = "radioButtonVisualMode0";
            this.radioButtonVisualMode0.Size = new System.Drawing.Size(59, 17);
            this.radioButtonVisualMode0.TabIndex = 0;
            this.radioButtonVisualMode0.TabStop = true;
            this.radioButtonVisualMode0.Text = "System";
            this.radioButtonVisualMode0.UseVisualStyleBackColor = true;
            // 
            // radioButtonVisualMode1
            // 
            this.radioButtonVisualMode1.AutoSize = true;
            this.radioButtonVisualMode1.Location = new System.Drawing.Point(7, 43);
            this.radioButtonVisualMode1.Name = "radioButtonVisualMode1";
            this.radioButtonVisualMode1.Size = new System.Drawing.Size(48, 17);
            this.radioButtonVisualMode1.TabIndex = 1;
            this.radioButtonVisualMode1.TabStop = true;
            this.radioButtonVisualMode1.Text = "Light";
            this.radioButtonVisualMode1.UseVisualStyleBackColor = true;
            // 
            // radioButtonVisualMode2
            // 
            this.radioButtonVisualMode2.AutoSize = true;
            this.radioButtonVisualMode2.Location = new System.Drawing.Point(7, 66);
            this.radioButtonVisualMode2.Name = "radioButtonVisualMode2";
            this.radioButtonVisualMode2.Size = new System.Drawing.Size(48, 17);
            this.radioButtonVisualMode2.TabIndex = 2;
            this.radioButtonVisualMode2.TabStop = true;
            this.radioButtonVisualMode2.Text = "Dark";
            this.radioButtonVisualMode2.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormSettings";
            this.Text = "FormSettings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.RadioButton radioButtonVisualMode2;
        public System.Windows.Forms.RadioButton radioButtonVisualMode1;
        public System.Windows.Forms.RadioButton radioButtonVisualMode0;
    }
}
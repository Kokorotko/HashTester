namespace HashTester
{
    partial class FormResetSettingsConfirmation
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
            this.buttonYES = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNO = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonYES
            // 
            this.buttonYES.Location = new System.Drawing.Point(238, 44);
            this.buttonYES.Name = "buttonYES";
            this.buttonYES.Size = new System.Drawing.Size(75, 23);
            this.buttonYES.TabIndex = 0;
            this.buttonYES.Text = "YES";
            this.buttonYES.UseVisualStyleBackColor = true;
            this.buttonYES.Click += new System.EventHandler(this.buttonYES_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Are you sure you want to reset all settings?";
            // 
            // buttonNO
            // 
            this.buttonNO.Location = new System.Drawing.Point(16, 44);
            this.buttonNO.Name = "buttonNO";
            this.buttonNO.Size = new System.Drawing.Size(75, 23);
            this.buttonNO.TabIndex = 2;
            this.buttonNO.Text = "NO";
            this.buttonNO.UseVisualStyleBackColor = true;
            this.buttonNO.Click += new System.EventHandler(this.buttonNO_Click);
            // 
            // FormResetSettingsConfirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 79);
            this.Controls.Add(this.buttonNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonYES);
            this.Name = "FormResetSettingsConfirmation";
            this.Text = "FormResetSettingsConfirmation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonYES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNO;
    }
}
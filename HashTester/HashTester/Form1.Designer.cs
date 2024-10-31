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
            this.languageButton = new System.Windows.Forms.Button();
            this.buttonHashGradualHashing = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(13, 13);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(75, 23);
            this.buttonHashSimpleText.TabIndex = 0;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // textHashSimple
            // 
            this.textHashSimple.Location = new System.Drawing.Point(13, 43);
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(775, 20);
            this.textHashSimple.TabIndex = 1;
            this.textHashSimple.Text = "Hello This is Test";
            // 
            // languageButton
            // 
            this.languageButton.Location = new System.Drawing.Point(713, 12);
            this.languageButton.Name = "languageButton";
            this.languageButton.Size = new System.Drawing.Size(75, 23);
            this.languageButton.TabIndex = 2;
            this.languageButton.Text = "CZ/EN";
            this.languageButton.UseVisualStyleBackColor = true;
            // 
            // buttonHashGradualHashing
            // 
            this.buttonHashGradualHashing.Location = new System.Drawing.Point(94, 12);
            this.buttonHashGradualHashing.Name = "buttonHashGradualHashing";
            this.buttonHashGradualHashing.Size = new System.Drawing.Size(102, 23);
            this.buttonHashGradualHashing.TabIndex = 3;
            this.buttonHashGradualHashing.Text = "Gradual Hashing";
            this.buttonHashGradualHashing.UseVisualStyleBackColor = true;
            this.buttonHashGradualHashing.Click += new System.EventHandler(this.buttonHashGradualHashing_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(547, 368);
            this.listBox1.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonHashGradualHashing);
            this.Controls.Add(this.languageButton);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHashSimpleText;
        private System.Windows.Forms.TextBox textHashSimple;
        private System.Windows.Forms.Button languageButton;
        private System.Windows.Forms.Button buttonHashGradualHashing;
        private System.Windows.Forms.ListBox listBox1;
    }
}


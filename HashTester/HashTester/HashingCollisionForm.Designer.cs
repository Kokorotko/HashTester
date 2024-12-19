namespace HashTester
{
    partial class HashingCollisionForm
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
            this.hashSelector = new System.Windows.Forms.ComboBox();
            this.buttonGenerateCollision = new System.Windows.Forms.Button();
            this.buttonTakeCollisionFromTXT = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTimer = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // hashSelector
            // 
            this.hashSelector.AllowDrop = true;
            this.hashSelector.Cursor = System.Windows.Forms.Cursors.Default;
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512",
            "RipeMD-160",
            "CRC32"});
            this.hashSelector.Location = new System.Drawing.Point(12, 41);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(121, 21);
            this.hashSelector.TabIndex = 9;
            // 
            // buttonGenerateCollision
            // 
            this.buttonGenerateCollision.Location = new System.Drawing.Point(12, 12);
            this.buttonGenerateCollision.Name = "buttonGenerateCollision";
            this.buttonGenerateCollision.Size = new System.Drawing.Size(121, 23);
            this.buttonGenerateCollision.TabIndex = 10;
            this.buttonGenerateCollision.Text = "Generate a Collision";
            this.buttonGenerateCollision.UseVisualStyleBackColor = true;
            this.buttonGenerateCollision.Click += new System.EventHandler(this.buttonGenerateCollision_Click);
            // 
            // buttonTakeCollisionFromTXT
            // 
            this.buttonTakeCollisionFromTXT.Location = new System.Drawing.Point(139, 12);
            this.buttonTakeCollisionFromTXT.Name = "buttonTakeCollisionFromTXT";
            this.buttonTakeCollisionFromTXT.Size = new System.Drawing.Size(153, 23);
            this.buttonTakeCollisionFromTXT.TabIndex = 11;
            this.buttonTakeCollisionFromTXT.Text = "Take a collision from txt file";
            this.buttonTakeCollisionFromTXT.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 121);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(776, 290);
            this.listBox1.TabIndex = 12;
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(12, 417);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(776, 23);
            this.buttonClearListBox.TabIndex = 13;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.Location = new System.Drawing.Point(635, 12);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(153, 23);
            this.buttonReturn.TabIndex = 14;
            this.buttonReturn.Text = "Go Back";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(12, 84);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Maximum Attempts";
            // 
            // labelTimer
            // 
            this.labelTimer.AutoSize = true;
            this.labelTimer.Location = new System.Drawing.Point(298, 17);
            this.labelTimer.Name = "labelTimer";
            this.labelTimer.Size = new System.Drawing.Size(39, 13);
            this.labelTimer.TabIndex = 17;
            this.labelTimer.Text = "Timer: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(635, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "Cancel The Process";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // HashingCollisionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTimer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonTakeCollisionFromTXT);
            this.Controls.Add(this.buttonGenerateCollision);
            this.Controls.Add(this.hashSelector);
            this.Name = "HashingCollisionForm";
            this.Text = "HashingCollisionForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.Button buttonGenerateCollision;
        private System.Windows.Forms.Button buttonTakeCollisionFromTXT;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTimer;
        private System.Windows.Forms.Button button1;
    }
}
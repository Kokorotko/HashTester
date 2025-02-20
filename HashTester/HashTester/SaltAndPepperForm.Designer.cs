namespace HashTester
{
    partial class SaltAndPepperForm
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
            this.textHashSimple = new System.Windows.Forms.TextBox();
            this.buttonHashSimpleText = new System.Windows.Forms.Button();
            this.checkBoxUseSalt = new System.Windows.Forms.CheckBox();
            this.checkBoxUsePepper = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxTester = new System.Windows.Forms.GroupBox();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonShowRegistrered = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.checkBoxUseLog = new System.Windows.Forms.CheckBox();
            this.groupBoxShowInfo = new System.Windows.Forms.GroupBox();
            this.buttonDeleteAllHashID = new System.Windows.Forms.Button();
            this.buttonShowAllID = new System.Windows.Forms.Button();
            this.buttonInfoID = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHashID = new System.Windows.Forms.TextBox();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.groupBoxTester.SuspendLayout();
            this.groupBoxShowInfo.SuspendLayout();
            this.SuspendLayout();
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
            this.hashSelector.Location = new System.Drawing.Point(204, 82);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(121, 21);
            this.hashSelector.TabIndex = 7;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // textHashSimple
            // 
            this.textHashSimple.Location = new System.Drawing.Point(12, 41);
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(313, 20);
            this.textHashSimple.TabIndex = 6;
            this.textHashSimple.Text = "Hello This is Test";
            // 
            // buttonHashSimpleText
            // 
            this.buttonHashSimpleText.Location = new System.Drawing.Point(12, 12);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(313, 23);
            this.buttonHashSimpleText.TabIndex = 5;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // checkBoxUseSalt
            // 
            this.checkBoxUseSalt.AutoSize = true;
            this.checkBoxUseSalt.Location = new System.Drawing.Point(12, 67);
            this.checkBoxUseSalt.Name = "checkBoxUseSalt";
            this.checkBoxUseSalt.Size = new System.Drawing.Size(68, 17);
            this.checkBoxUseSalt.TabIndex = 8;
            this.checkBoxUseSalt.Text = "Use salt*";
            this.checkBoxUseSalt.UseVisualStyleBackColor = true;
            // 
            // checkBoxUsePepper
            // 
            this.checkBoxUsePepper.AutoSize = true;
            this.checkBoxUsePepper.Location = new System.Drawing.Point(12, 88);
            this.checkBoxUsePepper.Name = "checkBoxUsePepper";
            this.checkBoxUsePepper.Size = new System.Drawing.Size(85, 17);
            this.checkBoxUsePepper.TabIndex = 9;
            this.checkBoxUsePepper.Text = "Use pepper*";
            this.checkBoxUsePepper.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "*has priority over settings";
            // 
            // groupBoxTester
            // 
            this.groupBoxTester.Controls.Add(this.buttonRemoveAll);
            this.groupBoxTester.Controls.Add(this.buttonShowRegistrered);
            this.groupBoxTester.Controls.Add(this.buttonRemove);
            this.groupBoxTester.Controls.Add(this.buttonLogin);
            this.groupBoxTester.Controls.Add(this.buttonRegister);
            this.groupBoxTester.Controls.Add(this.labelPassword);
            this.groupBoxTester.Controls.Add(this.textBoxPassword);
            this.groupBoxTester.Controls.Add(this.textBoxName);
            this.groupBoxTester.Controls.Add(this.labelName);
            this.groupBoxTester.Location = new System.Drawing.Point(331, 12);
            this.groupBoxTester.Name = "groupBoxTester";
            this.groupBoxTester.Size = new System.Drawing.Size(286, 149);
            this.groupBoxTester.TabIndex = 12;
            this.groupBoxTester.TabStop = false;
            this.groupBoxTester.Text = "Password Tester";
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Location = new System.Drawing.Point(189, 120);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(91, 23);
            this.buttonRemoveAll.TabIndex = 25;
            this.buttonRemoveAll.Text = "Remove All";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // buttonShowRegistrered
            // 
            this.buttonShowRegistrered.Location = new System.Drawing.Point(10, 120);
            this.buttonShowRegistrered.Name = "buttonShowRegistrered";
            this.buttonShowRegistrered.Size = new System.Drawing.Size(176, 23);
            this.buttonShowRegistrered.TabIndex = 24;
            this.buttonShowRegistrered.Text = "Show all Registered Users";
            this.buttonShowRegistrered.UseVisualStyleBackColor = true;
            this.buttonShowRegistrered.Click += new System.EventHandler(this.buttonShowAllID_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(189, 95);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(91, 23);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(97, 95);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(89, 23);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(10, 95);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(85, 23);
            this.buttonRegister.TabIndex = 4;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(116, 55);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(10, 71);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(270, 20);
            this.textBoxPassword.TabIndex = 2;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(10, 32);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(270, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(124, 16);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            // 
            // buttonClipboard
            // 
            this.buttonClipboard.Location = new System.Drawing.Point(202, 282);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(121, 23);
            this.buttonClipboard.TabIndex = 20;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // buttonSaveLog
            // 
            this.buttonSaveLog.Location = new System.Drawing.Point(101, 282);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(95, 23);
            this.buttonSaveLog.TabIndex = 19;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClearListBox
            // 
            this.buttonClearListBox.Location = new System.Drawing.Point(13, 282);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(82, 23);
            this.buttonClearListBox.TabIndex = 18;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.Location = new System.Drawing.Point(15, 160);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(310, 121);
            this.listBoxLog.TabIndex = 17;
            // 
            // checkBoxUseLog
            // 
            this.checkBoxUseLog.AutoSize = true;
            this.checkBoxUseLog.Location = new System.Drawing.Point(12, 111);
            this.checkBoxUseLog.Name = "checkBoxUseLog";
            this.checkBoxUseLog.Size = new System.Drawing.Size(112, 17);
            this.checkBoxUseLog.TabIndex = 21;
            this.checkBoxUseLog.Text = "Save log to listbox";
            this.checkBoxUseLog.UseVisualStyleBackColor = true;
            // 
            // groupBoxShowInfo
            // 
            this.groupBoxShowInfo.Controls.Add(this.buttonDeleteAllHashID);
            this.groupBoxShowInfo.Controls.Add(this.buttonShowAllID);
            this.groupBoxShowInfo.Controls.Add(this.buttonInfoID);
            this.groupBoxShowInfo.Controls.Add(this.label2);
            this.groupBoxShowInfo.Controls.Add(this.textBoxHashID);
            this.groupBoxShowInfo.Location = new System.Drawing.Point(332, 170);
            this.groupBoxShowInfo.Name = "groupBoxShowInfo";
            this.groupBoxShowInfo.Size = new System.Drawing.Size(279, 146);
            this.groupBoxShowInfo.TabIndex = 22;
            this.groupBoxShowInfo.TabStop = false;
            this.groupBoxShowInfo.Text = "Show info";
            // 
            // buttonDeleteAllHashID
            // 
            this.buttonDeleteAllHashID.Location = new System.Drawing.Point(3, 112);
            this.buttonDeleteAllHashID.Name = "buttonDeleteAllHashID";
            this.buttonDeleteAllHashID.Size = new System.Drawing.Size(270, 23);
            this.buttonDeleteAllHashID.TabIndex = 26;
            this.buttonDeleteAllHashID.Text = "Delete all ID";
            this.buttonDeleteAllHashID.UseVisualStyleBackColor = true;
            this.buttonDeleteAllHashID.Click += new System.EventHandler(this.buttonDeleteAllHashID_Click);
            // 
            // buttonShowAllID
            // 
            this.buttonShowAllID.Location = new System.Drawing.Point(3, 83);
            this.buttonShowAllID.Name = "buttonShowAllID";
            this.buttonShowAllID.Size = new System.Drawing.Size(270, 23);
            this.buttonShowAllID.TabIndex = 25;
            this.buttonShowAllID.Text = "Show all ID";
            this.buttonShowAllID.UseVisualStyleBackColor = true;
            this.buttonShowAllID.Click += new System.EventHandler(this.buttonShowAllID_Click_1);
            // 
            // buttonInfoID
            // 
            this.buttonInfoID.Location = new System.Drawing.Point(3, 56);
            this.buttonInfoID.Name = "buttonInfoID";
            this.buttonInfoID.Size = new System.Drawing.Size(270, 23);
            this.buttonInfoID.TabIndex = 23;
            this.buttonInfoID.Text = "Info about the ID";
            this.buttonInfoID.UseVisualStyleBackColor = true;
            this.buttonInfoID.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "HashID";
            // 
            // textBoxHashID
            // 
            this.textBoxHashID.Location = new System.Drawing.Point(3, 30);
            this.textBoxHashID.Name = "textBoxHashID";
            this.textBoxHashID.Size = new System.Drawing.Size(270, 20);
            this.textBoxHashID.TabIndex = 6;
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.labelAlgorithm.Location = new System.Drawing.Point(237, 64);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(88, 13);
            this.labelAlgorithm.TabIndex = 23;
            this.labelAlgorithm.Text = "Choose algorithm";
            // 
            // SaltAndPepperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 323);
            this.Controls.Add(this.labelAlgorithm);
            this.Controls.Add(this.groupBoxShowInfo);
            this.Controls.Add(this.checkBoxUseLog);
            this.Controls.Add(this.buttonClipboard);
            this.Controls.Add(this.buttonSaveLog);
            this.Controls.Add(this.buttonClearListBox);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.groupBoxTester);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxUsePepper);
            this.Controls.Add(this.checkBoxUseSalt);
            this.Controls.Add(this.hashSelector);
            this.Controls.Add(this.textHashSimple);
            this.Controls.Add(this.buttonHashSimpleText);
            this.Name = "SaltAndPepperForm";
            this.Text = "SaltAndPepperForm";
            this.Load += new System.EventHandler(this.SaltAndPepperForm_Load);
            this.groupBoxTester.ResumeLayout(false);
            this.groupBoxTester.PerformLayout();
            this.groupBoxShowInfo.ResumeLayout(false);
            this.groupBoxShowInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox hashSelector;
        private System.Windows.Forms.TextBox textHashSimple;
        private System.Windows.Forms.Button buttonHashSimpleText;
        private System.Windows.Forms.CheckBox checkBoxUseSalt;
        private System.Windows.Forms.CheckBox checkBoxUsePepper;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxTester;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button buttonClipboard;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.Button buttonClearListBox;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.CheckBox checkBoxUseLog;
        private System.Windows.Forms.GroupBox groupBoxShowInfo;
        private System.Windows.Forms.Button buttonInfoID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHashID;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonShowRegistrered;
        private System.Windows.Forms.Label labelAlgorithm;
        private System.Windows.Forms.Button buttonShowAllID;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Button buttonDeleteAllHashID;
    }
}
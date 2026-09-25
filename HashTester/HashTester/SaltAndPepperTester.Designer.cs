namespace HashTester
{
    partial class SaltAndPepperTester
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonShowRegistrered = new System.Windows.Forms.Button();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.labelPassword = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonClipboard = new System.Windows.Forms.Button();
            this.buttonSaveLog = new System.Windows.Forms.Button();
            this.buttonClearListBox = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.groupBoxShowInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteAllHashID = new System.Windows.Forms.Button();
            this.buttonShowAllID = new System.Windows.Forms.Button();
            this.textBoxHashID = new System.Windows.Forms.TextBox();
            this.buttonInfoID = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelAlgorithm = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxTester.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBoxShowInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // hashSelector
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.hashSelector, 3);
            this.hashSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hashSelector.FormattingEnabled = true;
            this.hashSelector.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512",
            "RipeMD-160",
            "CRC32"});
            this.hashSelector.Location = new System.Drawing.Point(193, 124);
            this.hashSelector.Margin = new System.Windows.Forms.Padding(4);
            this.hashSelector.Name = "hashSelector";
            this.hashSelector.Size = new System.Drawing.Size(181, 24);
            this.hashSelector.TabIndex = 7;
            this.hashSelector.SelectedIndexChanged += new System.EventHandler(this.hashSelector_SelectedIndexChanged);
            // 
            // textHashSimple
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.textHashSimple, 6);
            this.textHashSimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textHashSimple.Location = new System.Drawing.Point(4, 44);
            this.textHashSimple.Margin = new System.Windows.Forms.Padding(4);
            this.textHashSimple.Name = "textHashSimple";
            this.textHashSimple.Size = new System.Drawing.Size(370, 22);
            this.textHashSimple.TabIndex = 6;
            this.textHashSimple.Text = "Hello This is Test";
            // 
            // buttonHashSimpleText
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.buttonHashSimpleText, 6);
            this.buttonHashSimpleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHashSimpleText.Location = new System.Drawing.Point(4, 4);
            this.buttonHashSimpleText.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHashSimpleText.Name = "buttonHashSimpleText";
            this.buttonHashSimpleText.Size = new System.Drawing.Size(370, 32);
            this.buttonHashSimpleText.TabIndex = 5;
            this.buttonHashSimpleText.Text = "Hash text";
            this.buttonHashSimpleText.UseVisualStyleBackColor = true;
            this.buttonHashSimpleText.Click += new System.EventHandler(this.buttonHashSimpleText_Click);
            // 
            // checkBoxUseSalt
            // 
            this.checkBoxUseSalt.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxUseSalt, 3);
            this.checkBoxUseSalt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUseSalt.Location = new System.Drawing.Point(4, 84);
            this.checkBoxUseSalt.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUseSalt.Name = "checkBoxUseSalt";
            this.checkBoxUseSalt.Size = new System.Drawing.Size(181, 32);
            this.checkBoxUseSalt.TabIndex = 8;
            this.checkBoxUseSalt.Text = "Use salt*";
            this.checkBoxUseSalt.UseVisualStyleBackColor = true;
            // 
            // checkBoxUsePepper
            // 
            this.checkBoxUsePepper.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.checkBoxUsePepper, 3);
            this.checkBoxUsePepper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxUsePepper.Location = new System.Drawing.Point(4, 124);
            this.checkBoxUsePepper.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxUsePepper.Name = "checkBoxUsePepper";
            this.checkBoxUsePepper.Size = new System.Drawing.Size(181, 32);
            this.checkBoxUsePepper.TabIndex = 9;
            this.checkBoxUsePepper.Text = "Use pepper*";
            this.checkBoxUsePepper.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.label1, 6);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 40);
            this.label1.TabIndex = 10;
            this.label1.Text = "*has priority over settings";
            // 
            // groupBoxTester
            // 
            this.groupBoxTester.Controls.Add(this.tableLayoutPanel1);
            this.groupBoxTester.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxTester.Location = new System.Drawing.Point(382, 4);
            this.groupBoxTester.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxTester.Name = "groupBoxTester";
            this.groupBoxTester.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.SetRowSpan(this.groupBoxTester, 5);
            this.groupBoxTester.Size = new System.Drawing.Size(375, 192);
            this.groupBoxTester.TabIndex = 12;
            this.groupBoxTester.TabStop = false;
            this.groupBoxTester.Text = "Password Tester";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.buttonRemoveAll, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonShowRegistrered, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBoxName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonRemove, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelPassword, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonLogin, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.textBoxPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonRegister, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 169);
            this.tableLayoutPanel1.TabIndex = 24;
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemoveAll.Location = new System.Drawing.Point(248, 135);
            this.buttonRemoveAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(115, 30);
            this.buttonRemoveAll.TabIndex = 25;
            this.buttonRemoveAll.Text = "Remove All";
            this.buttonRemoveAll.UseVisualStyleBackColor = true;
            this.buttonRemoveAll.Click += new System.EventHandler(this.buttonRemoveAll_Click);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelName, 3);
            this.labelName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelName.Location = new System.Drawing.Point(4, 0);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(359, 16);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name";
            this.labelName.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // buttonShowRegistrered
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buttonShowRegistrered, 2);
            this.buttonShowRegistrered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowRegistrered.Location = new System.Drawing.Point(4, 135);
            this.buttonShowRegistrered.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowRegistrered.Name = "buttonShowRegistrered";
            this.buttonShowRegistrered.Size = new System.Drawing.Size(236, 30);
            this.buttonShowRegistrered.TabIndex = 24;
            this.buttonShowRegistrered.Text = "Show all Registered Users";
            this.buttonShowRegistrered.UseVisualStyleBackColor = true;
            this.buttonShowRegistrered.Click += new System.EventHandler(this.buttonShowAllID_Click);
            // 
            // textBoxName
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxName, 3);
            this.textBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxName.Location = new System.Drawing.Point(4, 20);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(359, 22);
            this.textBoxName.TabIndex = 1;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRemove.Location = new System.Drawing.Point(248, 102);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(115, 25);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelPassword, 3);
            this.labelPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelPassword.Location = new System.Drawing.Point(4, 49);
            this.labelPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(359, 16);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            this.labelPassword.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLogin.Location = new System.Drawing.Point(126, 102);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(114, 25);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textBoxPassword
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBoxPassword, 3);
            this.textBoxPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPassword.Location = new System.Drawing.Point(4, 69);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(359, 22);
            this.textBoxPassword.TabIndex = 2;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonRegister.Location = new System.Drawing.Point(4, 102);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(114, 25);
            this.buttonRegister.TabIndex = 4;
            this.buttonRegister.TabStop = false;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonClipboard
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.buttonClipboard, 2);
            this.buttonClipboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClipboard.Location = new System.Drawing.Point(256, 364);
            this.buttonClipboard.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClipboard.Name = "buttonClipboard";
            this.buttonClipboard.Size = new System.Drawing.Size(118, 32);
            this.buttonClipboard.TabIndex = 20;
            this.buttonClipboard.Text = "Clipboard";
            this.buttonClipboard.UseVisualStyleBackColor = true;
            this.buttonClipboard.Click += new System.EventHandler(this.buttonClipboard_Click);
            // 
            // buttonSaveLog
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.buttonSaveLog, 2);
            this.buttonSaveLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSaveLog.Location = new System.Drawing.Point(130, 364);
            this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveLog.Name = "buttonSaveLog";
            this.buttonSaveLog.Size = new System.Drawing.Size(118, 32);
            this.buttonSaveLog.TabIndex = 19;
            this.buttonSaveLog.Text = "Save log";
            this.buttonSaveLog.UseVisualStyleBackColor = true;
            this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
            // 
            // buttonClearListBox
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.buttonClearListBox, 2);
            this.buttonClearListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClearListBox.Location = new System.Drawing.Point(4, 364);
            this.buttonClearListBox.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClearListBox.Name = "buttonClearListBox";
            this.buttonClearListBox.Size = new System.Drawing.Size(118, 32);
            this.buttonClearListBox.TabIndex = 18;
            this.buttonClearListBox.Text = "Clear Listbox";
            this.buttonClearListBox.UseVisualStyleBackColor = true;
            this.buttonClearListBox.Click += new System.EventHandler(this.buttonClearListBox_Click);
            // 
            // listBoxLog
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.listBoxLog, 6);
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.ItemHeight = 16;
            this.listBoxLog.Location = new System.Drawing.Point(4, 204);
            this.listBoxLog.Margin = new System.Windows.Forms.Padding(4);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(370, 152);
            this.listBoxLog.TabIndex = 17;
            // 
            // groupBoxShowInfo
            // 
            this.groupBoxShowInfo.Controls.Add(this.tableLayoutPanel2);
            this.groupBoxShowInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxShowInfo.Location = new System.Drawing.Point(382, 204);
            this.groupBoxShowInfo.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxShowInfo.Name = "groupBoxShowInfo";
            this.groupBoxShowInfo.Padding = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.SetRowSpan(this.groupBoxShowInfo, 2);
            this.groupBoxShowInfo.Size = new System.Drawing.Size(375, 192);
            this.groupBoxShowInfo.TabIndex = 22;
            this.groupBoxShowInfo.TabStop = false;
            this.groupBoxShowInfo.Text = "Show info";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.buttonDeleteAllHashID, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonShowAllID, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.textBoxHashID, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonInfoID, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 19);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(367, 169);
            this.tableLayoutPanel2.TabIndex = 24;
            // 
            // buttonDeleteAllHashID
            // 
            this.buttonDeleteAllHashID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteAllHashID.Location = new System.Drawing.Point(4, 136);
            this.buttonDeleteAllHashID.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteAllHashID.Name = "buttonDeleteAllHashID";
            this.buttonDeleteAllHashID.Size = new System.Drawing.Size(359, 29);
            this.buttonDeleteAllHashID.TabIndex = 26;
            this.buttonDeleteAllHashID.Text = "Delete all ID";
            this.buttonDeleteAllHashID.UseVisualStyleBackColor = true;
            this.buttonDeleteAllHashID.Click += new System.EventHandler(this.buttonDeleteAllHashID_Click);
            // 
            // buttonShowAllID
            // 
            this.buttonShowAllID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonShowAllID.Location = new System.Drawing.Point(4, 103);
            this.buttonShowAllID.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowAllID.Name = "buttonShowAllID";
            this.buttonShowAllID.Size = new System.Drawing.Size(359, 25);
            this.buttonShowAllID.TabIndex = 25;
            this.buttonShowAllID.Text = "Show all ID";
            this.buttonShowAllID.UseVisualStyleBackColor = true;
            this.buttonShowAllID.Click += new System.EventHandler(this.buttonShowAllID_Click_1);
            // 
            // textBoxHashID
            // 
            this.textBoxHashID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxHashID.Location = new System.Drawing.Point(4, 37);
            this.textBoxHashID.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHashID.Name = "textBoxHashID";
            this.textBoxHashID.Size = new System.Drawing.Size(359, 22);
            this.textBoxHashID.TabIndex = 6;
            // 
            // buttonInfoID
            // 
            this.buttonInfoID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonInfoID.Location = new System.Drawing.Point(4, 70);
            this.buttonInfoID.Margin = new System.Windows.Forms.Padding(4);
            this.buttonInfoID.Name = "buttonInfoID";
            this.buttonInfoID.Size = new System.Drawing.Size(359, 25);
            this.buttonInfoID.TabIndex = 23;
            this.buttonInfoID.Text = "Info about the ID";
            this.buttonInfoID.UseVisualStyleBackColor = true;
            this.buttonInfoID.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "HashID";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // labelAlgorithm
            // 
            this.labelAlgorithm.AutoSize = true;
            this.tableLayoutPanel3.SetColumnSpan(this.labelAlgorithm, 3);
            this.labelAlgorithm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelAlgorithm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelAlgorithm.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.labelAlgorithm.Location = new System.Drawing.Point(193, 80);
            this.labelAlgorithm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlgorithm.Name = "labelAlgorithm";
            this.labelAlgorithm.Size = new System.Drawing.Size(181, 40);
            this.labelAlgorithm.TabIndex = 23;
            this.labelAlgorithm.Text = "Choose algorithm";
            this.labelAlgorithm.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 7;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.groupBoxTester, 6, 0);
            this.tableLayoutPanel3.Controls.Add(this.buttonClipboard, 4, 6);
            this.tableLayoutPanel3.Controls.Add(this.labelAlgorithm, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.buttonSaveLog, 2, 6);
            this.tableLayoutPanel3.Controls.Add(this.groupBoxShowInfo, 6, 5);
            this.tableLayoutPanel3.Controls.Add(this.buttonClearListBox, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.buttonHashSimpleText, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listBoxLog, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.textHashSimple, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxUseSalt, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.hashSelector, 3, 3);
            this.tableLayoutPanel3.Controls.Add(this.checkBoxUsePepper, 0, 3);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 7;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(761, 400);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // SaltAndPepperTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 400);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(777, 437);
            this.Name = "SaltAndPepperTester";
            this.Text = "SaltAndPepperForm";
            this.Load += new System.EventHandler(this.SaltAndPepperForm_Load);
            this.groupBoxTester.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBoxShowInfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}
using System;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace HashTester
{
    public partial class FileChecksum: Form
    {
        public FileChecksum()
        {
            InitializeComponent();
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TurnOffUI();
                    GenerateCheckSum(dialog.FileName);
                    TurnOnUI();
                }
            }
        }


        /// <summary>
        /// Turns all of UI components on
        /// </summary>
        private void TurnOffUI()
        {
            foreach(Control control in this.Controls)
            {
                if (control is Button || control is TextBox) control.Enabled = false;
                else if (control is GroupBox box)
                {
                    foreach (Control item in box.Controls)
                    {
                        if (item is Button || item is TextBox) item.Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Turns all of UI components on
        /// </summary>
        private void TurnOnUI()
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox box)
                {
                    foreach (Control item in box.Controls)
                    {
                        item.Enabled = true;
                    }
                }
                else control.Enabled = true;
            }
        }

        private void File_checksum_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(Languages.L.FileChecksumTool);
            Settings.LoadSettings();
            FormManagement.SetUpFormTheme(this);
            #region Langugages
            buttonFile.Text = Languages.Translate(Languages.L.SelectAFile);
            buttonChecksum.Text = Languages.Translate(Languages.L.ChecksumCheck);
            groupBoxChecksum.Text = Languages.Translate(Languages.L.Checksum);
            buttonCopyMD5.Text = Languages.Translate(Languages.L.Copy) + " MD5";
            button1.Text = Languages.Translate(Languages.L.Copy) + " SHA1";
            button2.Text = Languages.Translate(Languages.L.Copy) + " SHA256";
            button3.Text = Languages.Translate(Languages.L.Copy) + " SHA512";
            button4.Text = Languages.Translate(Languages.L.Copy) + " RipeMD-160";
            button5.Text = Languages.Translate(Languages.L.Copy) + " CRC32";
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);
            #endregion
        }

        #region Copy
        private void buttonCopyMD5_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelMD5.Text.Split(' ')[1]);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelSHA1.Text.Split(' ')[1]);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelSHA256.Text.Split(' ')[1]);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelSHA512.Text.Split(' ')[1]);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelRipeMD160.Text.Split(' ')[1]);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelCRC32.Text.Split(' ')[1]);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void buttonChecksum_Click(object sender, EventArgs e)
        {
            string checksum = textBoxHash.Text;
            Hasher.HashingAlgorithm fileAlgorithm = Hasher.HashingAlgorithm.MD5;
            bool isFileAlgorithmSelected = true;
            switch (checksum.Length)
            {
                case 32:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.MD5;
                        if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedAlgorithm) + ": MD5");
                        break;
                    }
                case 40:
                    {
                        //SHA1 and RipeMD160 are the same lenght
                        if (MessageBox.Show(Languages.Translate(Languages.L.DoYouUseSha1YesOrRipemd160No), Languages.Translate(Languages.L.Question), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fileAlgorithm = Hasher.HashingAlgorithm.SHA1;
                            if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedAlgorithm) + ": SHA1");
                        }
                        else
                        {
                            fileAlgorithm = Hasher.HashingAlgorithm.RIPEMD160;
                            if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedAlgorithm) + ": RipeMD-160");
                        }
                        break;
                    }
                case 64:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.SHA256;
                        if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedAlgorithm) + ": SHA256");
                        break;
                    }
                case 128:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.SHA512;
                        if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedAlgorithm) + ": SHA512");
                        break;
                    }
                case 8:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.CRC32;
                        if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedAlgorithm) + ": CRC32");
                        break;
                    }
                default:
                    {
                        MessageBox.Show(Languages.Translate(Languages.L.PleaseInputAHashForChecksum), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error); isFileAlgorithmSelected = false;
                        if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.PleaseInputAHashForChecksum));
                        break;
                    }
            }
            if (!isFileAlgorithmSelected) return;
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    GenerateCheckSum(dialog.FileName, checksum, fileAlgorithm);

                }
                TurnOnUI();
            }
        }

        private void labelLocation_TextChanged(object sender, EventArgs e)
        {
            if (labelLocation.Text.Length > 180) labelLocation.Text = labelLocation.Text.Substring(0, 177) + "...";
        }


        /// <summary>
        /// Generates a checksum of a file based on hash algorithm
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="checksum"></param>
        /// <param name="hashAlgorithm"></param>
        private void GenerateCheckSum(string filename, string checksum, Hasher.HashingAlgorithm hashAlgorithm)
        {
            TurnOffUI();
            labelLocation.Text = Languages.Translate(Languages.L.FileLocation) + ": " + filename;
            //get what algorithms to file checksum
            bool[] useAlgorithm =
            {
                    checkBoxMD5.Checked,
                    checkBoxSHA1.Checked,
                    checkBoxSHA256.Checked,
                    checkBoxSHA512.Checked,
                    checkBoxRIPEMD160.Checked,
                    checkBoxCRC32.Checked
                };

            //Check to see if any are selected
            bool anySelected = false;
            foreach (bool bul in useAlgorithm)
            {
                if (bul) anySelected = true;
            }
            if (!anySelected)
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAHashForChecksum), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < useAlgorithm.Count(); i++)
            {
                if (useAlgorithm[i])
                {
                    string hash = Hasher.FileChecksum(filename, (Hasher.HashingAlgorithm)i);
                    if ((Hasher.HashingAlgorithm)i == hashAlgorithm)
                    {
                        if (checksum == hash)
                        {
                            if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.ChecksumsAreCorrectFilesAreTheSame));
                            MessageBox.Show(Languages.Translate(Languages.L.ChecksumsAreCorrectFilesAreTheSame), Languages.Translate(Languages.L.Correct), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.ChecksumsAreNotCorrectFilesAreNotTheSame));
                            MessageBox.Show(Languages.Translate(Languages.L.ChecksumsAreNotCorrectFilesAreNotTheSame), Languages.Translate(Languages.L.Wrong), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    switch ((Hasher.HashingAlgorithm)i)
                    {
                        case Hasher.HashingAlgorithm.MD5: labelMD5.Text = "MD5: " + hash; break;
                        case Hasher.HashingAlgorithm.SHA1: labelMD5.Text = "SHA1: " + hash; break;
                        case Hasher.HashingAlgorithm.SHA256: labelMD5.Text = "SHA256: " + hash; break;
                        case Hasher.HashingAlgorithm.SHA512: labelMD5.Text = "SHA512: " + hash; break;
                        case Hasher.HashingAlgorithm.RIPEMD160: labelMD5.Text = "RipeMD-160: " + hash; break;
                        case Hasher.HashingAlgorithm.CRC32: labelMD5.Text = "CRC32: " + hash; break;
                        default: Console.WriteLine("Somehow something is wrong in FileChecksum." + Environment.NewLine + ((Hasher.HashingAlgorithm)i).ToString()); break;
                    }
                }
            }
        }


        /// <summary>
        /// Generates check sum of a file from Form
        /// </summary>
        /// <param name="filename">Path to file</param>
        private void GenerateCheckSum(string filename)
        {
            TurnOffUI();
            labelLocation.Text = Languages.Translate(Languages.L.FileLocation) + ": " + filename;
            //get what algorithms to file checksum
            bool[] useAlgorithm =
            {
                    checkBoxMD5.Checked,
                    checkBoxSHA1.Checked,
                    checkBoxSHA256.Checked,
                    checkBoxSHA512.Checked,
                    checkBoxRIPEMD160.Checked,
                    checkBoxCRC32.Checked
                };
            //Check to see if any are selected
            bool anySelected = false;
            foreach(bool bul in useAlgorithm)
            {
                if (bul)
                {
                    anySelected = true;
                    break;
                }
            }
            if (!anySelected)
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAHashForChecksum), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //Code
            for (int i = 0; i < useAlgorithm.Count(); i++)
            {
                if (useAlgorithm[i])
                {
                    string hash = Hasher.FileChecksum(filename, (Hasher.HashingAlgorithm)i);
                    switch ((Hasher.HashingAlgorithm)i)
                    {
                        case Hasher.HashingAlgorithm.MD5: labelMD5.Text = "MD5: " + hash; break;
                        case Hasher.HashingAlgorithm.SHA1: labelSHA1.Text = "SHA1: " + hash; break;
                        case Hasher.HashingAlgorithm.SHA256: labelSHA256.Text = "SHA256: " + hash; break;
                        case Hasher.HashingAlgorithm.SHA512: labelSHA512.Text = "SHA512: " + hash; break;
                        case Hasher.HashingAlgorithm.RIPEMD160: labelRipeMD160.Text = "RipeMD-160: " + hash; break;
                        case Hasher.HashingAlgorithm.CRC32: labelCRC32.Text = "CRC32: " + hash; break;
                        default: Console.WriteLine("Somehow something is wrong in FileChecksum." + Environment.NewLine + ((Hasher.HashingAlgorithm)i).ToString()); break;
                    }
                }
            }
        }

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAnItemFromTheListBeforeCopying), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

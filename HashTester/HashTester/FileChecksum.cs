using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            this.Name = Languages.Translate(702);
            Settings.LoadSettings();
            FormManagement.SetUpFormTheme(this);
            #region Langugages
            buttonFile.Text = Languages.Translate(35);
            buttonChecksum.Text = Languages.Translate(36);
            groupBoxChecksum.Text = Languages.Translate(54);
            buttonCopyMD5.Text = Languages.Translate(10029) + " MD5";
            button1.Text = Languages.Translate(10029) + " SHA1";
            button2.Text = Languages.Translate(10029) + " SHA256";
            button3.Text = Languages.Translate(10029) + " SHA512";
            button4.Text = Languages.Translate(10029) + " RipeMD-160";
            button5.Text = Languages.Translate(10029) + " CRC32";
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
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                case 32: fileAlgorithm = Hasher.HashingAlgorithm.MD5; break;
                case 40:
                    {
                        //SHA1 and RipeMD160 are the same lenght
                        if (MessageBox.Show(Languages.Translate(48), Languages.Translate(10030), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) fileAlgorithm = Hasher.HashingAlgorithm.SHA1;
                        else fileAlgorithm = Hasher.HashingAlgorithm.RIPEMD160;                        
                        break;
                    }
                case 64: fileAlgorithm = Hasher.HashingAlgorithm.SHA256; break;
                case 128: fileAlgorithm = Hasher.HashingAlgorithm.SHA512; break;
                case 8: fileAlgorithm = Hasher.HashingAlgorithm.CRC32; break;
                default: MessageBox.Show(Languages.Translate(49), Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error); isFileAlgorithmSelected = false; break;
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

        private void GenerateCheckSum(string filename, string checksum, Hasher.HashingAlgorithm fileAlgorithm)
        {
            TurnOffUI();
            labelLocation.Text = Languages.Translate(34) + ": " + filename;
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
                MessageBox.Show(Languages.Translate(57), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < useAlgorithm.Count(); i++)
            {
                if (useAlgorithm[i])
                {
                    string hash = Hasher.FileChecksum(filename, (Hasher.HashingAlgorithm)i);
                    if ((Hasher.HashingAlgorithm)i == fileAlgorithm)
                    {
                        if (checksum == hash) MessageBox.Show(Languages.Translate(50), Languages.Translate(52), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show(Languages.Translate(51), Languages.Translate(53), MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void GenerateCheckSum(string filename)
        {
            TurnOffUI();
            labelLocation.Text = Languages.Translate(34) + ": " + filename;
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
                if (bul) anySelected = true;
            }
            if (!anySelected)
            {
                MessageBox.Show(Languages.Translate(57), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}

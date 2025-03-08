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
                    labelLocation.Text = Languages.Translate(34) + ": " + dialog.FileName;
                    foreach (Hasher.HashingAlgorithm algorithm in Enum.GetValues(typeof(Hasher.HashingAlgorithm)))
                    {
                        string hash = Hasher.FileChecksum(dialog.FileName, algorithm);
                        switch (algorithm)
                        {
                            case Hasher.HashingAlgorithm.MD5: labelMD5.Text = "MD5: " + hash; break;
                            case Hasher.HashingAlgorithm.SHA1: labelSHA1.Text = "SHA1: " + hash; break;
                            case Hasher.HashingAlgorithm.SHA256: labelSHA256.Text = "SHA256: " + hash; break;
                            case Hasher.HashingAlgorithm.SHA512: labelSHA512.Text = "SHA512: " + hash; break;
                            case Hasher.HashingAlgorithm.RIPEMD160: labelRipeMD160.Text = "RipeMD-160: " + hash; break;
                            case Hasher.HashingAlgorithm.CRC32: labelCRC32.Text = "CRC32: " + hash; break;
                            default: Console.WriteLine("Somehow something is wrong in FileChecksum." + Environment.NewLine + algorithm.ToString()); break;
                        }
                    }
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
            checkBox1.Text = Languages.Translate(37);
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
                    TurnOffUI();
                    labelLocation.Text = Languages.Translate(34) + ": " + dialog.FileName;
                    if (checkBox1.Checked) //Generate Checksum for all
                    {
                        foreach (Hasher.HashingAlgorithm algorithm in Enum.GetValues(typeof(Hasher.HashingAlgorithm)))
                        {
                            string hash = Hasher.FileChecksum(dialog.FileName, algorithm);
                            if (algorithm == fileAlgorithm)
                            {
                                if (checksum == hash) MessageBox.Show(Languages.Translate(50), Languages.Translate(52), MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else MessageBox.Show(Languages.Translate(51), Languages.Translate(53), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            switch (algorithm)
                            {
                                case Hasher.HashingAlgorithm.MD5: labelMD5.Text = "MD5: " + hash; break;
                                case Hasher.HashingAlgorithm.SHA1: labelMD5.Text = "SHA1: " + hash; break;
                                case Hasher.HashingAlgorithm.SHA256: labelMD5.Text = "SHA256: " + hash; break;
                                case Hasher.HashingAlgorithm.SHA512: labelMD5.Text = "SHA512: " + hash; break;
                                case Hasher.HashingAlgorithm.RIPEMD160: labelMD5.Text = "RipeMD-160: " + hash; break;
                                case Hasher.HashingAlgorithm.CRC32: labelMD5.Text = "CRC32: " + hash; break;
                                default: Console.WriteLine("Somehow something is wrong in FileChecksum." + Environment.NewLine + algorithm.ToString()); break;
                            }
                        }
                    }
                    else //Generate checksum for only the one
                    {
                        string hash = Hasher.FileChecksum(dialog.FileName, fileAlgorithm);
                        if (checksum == hash) MessageBox.Show(Languages.Translate(50), Languages.Translate(52), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show(Languages.Translate(51), Languages.Translate(53), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    TurnOnUI();
                }
            }
        }
    }
}

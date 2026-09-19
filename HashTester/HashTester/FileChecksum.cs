using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace HashTester
{
    public partial class FileChecksum : Form
    {
        public FileChecksum()
        {
            InitializeComponent();
        }
        private string pathToFile = string.Empty;

        Checksum checksum;
        CancellationTokenSource token;

        private void buttonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    labelFileLocation.Text = dialog.FileName;
                    pathToFile = dialog.FileName;
                    LabelHashEmpty();
                    GenerateChecksumUI(pathToFile);
                }
            }
        }


        /// <summary>
        /// Turns all of UI components off
        /// </summary>
        private void TurnOffUI(Control parent)
        {            
            if (parent is Label || parent == buttonCancel)
            {
                return; //skip labels and cancel button
            }
            //Console.WriteLine("TurnOffUI: " + parent.Name);
            if (parent is ComboBox || parent is TableLayoutPanel || parent is Form)
            {
                foreach (Control control in parent.Controls)
                {
                    TurnOffUI(control); //Recursion
                }
                return;
            }
            parent.Enabled = false;            
        }


        /// <summary>
        /// Turns all of UI components on
        /// </summary>
        private void TurnOnUI(Control parent)
        {
            TurnOnUIRecursion(parent);
            timerUI.Stop();
            UpdateUI();
            token = new CancellationTokenSource(); //reset token
        }

        private void TurnOnUIRecursion(Control parent)
        {
            parent.Enabled = true;
            //Console.WriteLine("TurnOnUI: " + parent.Name);
            foreach (Control control in parent.Controls)
            {
                TurnOnUI(control); //Recursion
            }
        }

        private void File_checksum_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(Languages.L.FileChecksumTool);
            Settings.LoadSettings();
            FormManagement.LoadForm(this);
            token = new CancellationTokenSource();
            #region Langugages
            buttonFile.Text = Languages.Translate(Languages.L.SelectAFile);
            buttonChecksum.Text = Languages.Translate(Languages.L.ChecksumCheck);
            buttonCopyMD5.Text = Languages.Translate(Languages.L.Copy) + " MD5";
            buttonCopySHA1.Text = Languages.Translate(Languages.L.Copy) + " SHA1";
            buttonCopySHA256.Text = Languages.Translate(Languages.L.Copy) + " SHA256";
            buttonCopySHA512.Text = Languages.Translate(Languages.L.Copy) + " SHA512";
            buttonCopyRipeMD160.Text = Languages.Translate(Languages.L.Copy) + " RipeMD-160";
            buttonCopyCRC32.Text = Languages.Translate(Languages.L.Copy) + " CRC32";

            //No need for user to see them yet
            labelFileLocation.Text = string.Empty;
            LabelHashEmpty();
            #endregion
        }

        public void LabelHashEmpty()
        {
            labelCRC32Output.Text = string.Empty;
            labelRipeMDOutput.Text = string.Empty;
            labelSHA512Output.Text = string.Empty;
            labelSHA256Output.Text = string.Empty;
            labelSHA1Output.Text = string.Empty;
            labelMD5Output.Text = string.Empty;
        }

        #region Copy
        private void buttonCopyMD5_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(labelMD5Output.Text);
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
                Clipboard.SetText(labelSHA1Output.Text);
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
                Clipboard.SetText(labelSHA256Output.Text);
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
                Clipboard.SetText(labelSHA512Output.Text);
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
                Clipboard.SetText(labelRipeMDOutput.Text);
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
                Clipboard.SetText(labelCRC32Output.Text);
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
            Hasher.HashingAlgorithm fileAlgorithm = Hasher.HashingAlgorithm.MD5; //placeholder
            switch (checksum.Length)
            {
                case 32:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.MD5;
                        break;
                    }
                case 40:
                    {
                        //SHA1 and RipeMD160 are the same lenght
                        if (MessageBox.Show(Languages.Translate(Languages.L.DoYouUseSha1YesOrRipemd160No), Languages.Translate(Languages.L.Question), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            fileAlgorithm = Hasher.HashingAlgorithm.SHA1;
                        }
                        else
                        {
                            fileAlgorithm = Hasher.HashingAlgorithm.RIPEMD160;
                        }
                        break;
                    }
                case 64:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.SHA256;
                        break;
                    }
                case 128:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.SHA512;
                        break;
                    }
                case 8:
                    {
                        fileAlgorithm = Hasher.HashingAlgorithm.CRC32;
                        break;
                    }
                default:
                    {
                        MessageBox.Show(Languages.Translate(Languages.L.PleaseInputAHashForChecksum), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; //No algorithm was selected
                    }
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    TurnOffUI(this);
                    Checksum checkTemp = new Checksum(fileAlgorithm);
                    bool isCorrect = checkTemp.CheckCheckSumFromFile(textBoxHash.Text, dialog.FileName);
                    if (isCorrect)
                    {
                        MessageBox.Show(Languages.Translate(Languages.L.ChecksumsAreCorrectFilesAreTheSame), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(Languages.Translate(Languages.L.ChecksumsAreNotCorrectFilesAreNotTheSame), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                TurnOnUI(this);
            }
        }

        public void UpdateLabelHash(Hasher.HashingAlgorithm algorithm, string hash)
        {
            switch (algorithm)
            {
                case Hasher.HashingAlgorithm.MD5: labelMD5Output.Text = hash; break;
                case Hasher.HashingAlgorithm.SHA1: labelSHA1Output.Text = hash; break;
                case Hasher.HashingAlgorithm.SHA256: labelSHA256Output.Text = hash; break;
                case Hasher.HashingAlgorithm.SHA512: labelSHA512Output.Text = hash; break;
                case Hasher.HashingAlgorithm.RIPEMD160: labelRipeMDOutput.Text = hash; break;
                case Hasher.HashingAlgorithm.CRC32: labelCRC32Output.Text = hash; break;
                default: Console.WriteLine("Somehow something is wrong in FileChecksum." + Environment.NewLine + (algorithm).ToString()); break;
            }
        }

        /// <summary>
        /// Generates check sum of a file from Form
        /// </summary>
        /// <param name="filename">Path to file</param>
        private async void GenerateChecksumUI(string filename)
        {
            List<Hasher.HashingAlgorithm> algorithms = GetAlgorithmsFromUI();

            if (algorithms.Count() == 0)
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAHashForChecksum), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            progressBar.Value = 0; //reset bar
            TurnOffUI(this);
            checksum = new Checksum(algorithms);
            await checksum.GenerateCheckSumFromFile(filename, checkBoxMultiThread.Checked, token);
            TurnOnUI(this);
        }

        private void buttonRunChecksum_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathToFile))
            {
                buttonFile_Click(sender, e); //load a file
                if (string.IsNullOrEmpty(pathToFile))
                {
                    return; //if user cancels file selection, return
                }
            }
            if (!File.Exists(pathToFile))
            {
                MessageBox.Show(Languages.Translate(Languages.L.FileDoesntExists), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Console.WriteLine("Checksum pathToFile: " + pathToFile);
            LabelHashEmpty();
            SetupTimerForUIUpdate();
            GenerateChecksumUI(pathToFile);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            checkBoxCRC32.Checked = true;
            checkBoxMD5.Checked = true;
            checkBoxRIPEMD160.Checked = true;
            checkBoxSHA1.Checked = true;
            checkBoxSHA256.Checked = true;
            checkBoxSHA512.Checked = true;
        }

        public List<Hasher.HashingAlgorithm> GetAlgorithmsFromUI()
        {
            List<Hasher.HashingAlgorithm> algorithms = new List<Hasher.HashingAlgorithm>();
            if (checkBoxMD5.Checked)
            {
                algorithms.Add(Hasher.HashingAlgorithm.MD5);
            }
            if (checkBoxSHA1.Checked)
            {
                algorithms.Add(Hasher.HashingAlgorithm.SHA1);
            }
            if (checkBoxSHA256.Checked)
            {
                algorithms.Add(Hasher.HashingAlgorithm.SHA256);
            }
            if (checkBoxSHA512.Checked)
            {
                algorithms.Add(Hasher.HashingAlgorithm.SHA512);
            }
            if (checkBoxRIPEMD160.Checked)
            {
                algorithms.Add(Hasher.HashingAlgorithm.RIPEMD160);
            }
            if (checkBoxCRC32.Checked)
            {
                algorithms.Add(Hasher.HashingAlgorithm.CRC32);
            }
            return algorithms;
        }

        #region Timer
        System.Windows.Forms.Timer timerUI = new System.Windows.Forms.Timer();
        public void SetupTimerForUIUpdate()
        {
            if (checksum == null) //kill his ass
            {
                return;
            }

            timerUI.Interval = Settings.UpdateUIms;
            timerUI.Tick += (s, e) =>
            {
                Console.WriteLine("Timer ticked");
                UpdateUI();
            };
            timerUI.Start();
        }

        private void UpdateUI()
        {
            try
            {
                checksum.ReturnHashValues(out Dictionary<Hasher.HashingAlgorithm, string> outputHash, out int progressBarValue);
                progressBar.Value = progressBarValue;
                foreach (var item in outputHash)
                {
                    UpdateLabelHash(item.Key, item.Value);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateUI exception: " + ex.Message);
            }
        }

        #endregion //Timer

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            token.Cancel();
        }
    }
}

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
    public partial class FileChecksum: Form
    {
        public FileChecksum()
        {
            InitializeComponent();
        }

        private string pathToFile = string.Empty;

        private void buttonFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    labelFileLocation.Text = dialog.FileName;
                    pathToFile = dialog.FileName;
                }
            }
        }


        /// <summary>
        /// Turns all of UI components off
        /// </summary>
        private void TurnOffUI(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button || control is TextBox || control is CheckBox)
                {
                    if (control.Name == buttonCopyCRC32.Name ||
                        control.Name == buttonCopySHA1.Name ||
                        control.Name == buttonCopySHA256.Name ||
                        control.Name == buttonCopySHA512.Name ||
                        control.Name == buttonCopyRipeMD160.Name ||
                        control.Name == buttonCopyMD5.Name ||
                        control.Name == buttonCancel.Name)
                    {
                        continue;
                    }

                    control.Enabled = false;
                }

                // recurse into children
                if (control.HasChildren)
                {
                    TurnOffUI(control);
                }
            }
        }

        /// <summary>
        /// Turns all of UI components on
        /// </summary>
        private void TurnOnUI(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                control.Enabled = true;

                // recurse into children
                if (control.HasChildren)
                {
                    TurnOnUI(control);
                }
            }
        }

        private void File_checksum_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(Languages.L.FileChecksumTool);
            Settings.LoadSettings();
            StripMenu.LoadStripMenu(this);
            FormManagement.SetUpFormTheme(this);
            #region Langugages
            buttonFile.Text = Languages.Translate(Languages.L.SelectAFile);
            buttonChecksum.Text = Languages.Translate(Languages.L.ChecksumCheck);
            buttonCopyMD5.Text = Languages.Translate(Languages.L.Copy) + " MD5";
            buttonCopySHA1.Text = Languages.Translate(Languages.L.Copy) + " SHA1";
            buttonCopySHA256.Text = Languages.Translate(Languages.L.Copy) + " SHA256";
            buttonCopySHA512.Text = Languages.Translate(Languages.L.Copy) + " SHA512";
            buttonCopyRipeMD160.Text = Languages.Translate(Languages.L.Copy) + " RipeMD-160";
            buttonCopyCRC32.Text = Languages.Translate(Languages.L.Copy) + " CRC32";
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);

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
            Hasher.HashingAlgorithm fileAlgorithm = Hasher.HashingAlgorithm.MD5;
            bool isFileAlgorithmSelected = true;
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
                        MessageBox.Show(Languages.Translate(Languages.L.PleaseInputAHashForChecksum), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error); isFileAlgorithmSelected = false;
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
                TurnOnUI(this);
            }
        }

        private void labelLocation_TextChanged(object sender, EventArgs e)
        {
            return;
        }


        /// <summary>
        /// Generates a checksum of a file based on hash algorithm
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="checksum"></param>
        /// <param name="hashAlgorithm"></param>
        private void GenerateCheckSum(string filename, string checksum, Hasher.HashingAlgorithm hashAlgorithm)
        {
            TurnOffUI(this);
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
                            MessageBox.Show(Languages.Translate(Languages.L.ChecksumsAreCorrectFilesAreTheSame), Languages.Translate(Languages.L.Correct), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(Languages.Translate(Languages.L.ChecksumsAreNotCorrectFilesAreNotTheSame), Languages.Translate(Languages.L.Wrong), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    UpdateLabelHash((Hasher.HashingAlgorithm)i, hash);
                }
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
        private async void GenerateCheckSum(string filename)
        {
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
            uint numberOfSelected = 0;
            foreach (bool bul in useAlgorithm)
            {
                if (bul)
                {
                    numberOfSelected++;
                }
            }

            if (numberOfSelected == 0)
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAHashForChecksum), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            progressBar.Value = 0; //reset bar
            TurnOffUI(this);

            int threadsToUse = 1;
            if (checkBoxMultiThread.Checked) //How many threads can be used at once
            {
                threadsToUse = FormManagement.NumberOfThreadsToUse();
                Console.WriteLine("Number of threads to use: " + threadsToUse);
            }
            var tasks = new List<Task>();

            //Each algorithm can have its own thread
            if (threadsToUse > numberOfSelected)
            {
                for (int i = 0; i < useAlgorithm.Count(); i++)
                {
                    if (useAlgorithm[i])
                    {
                        int index = i;
                        tasks.Add(Task.Run(() =>
                        {
                            string hash = Hasher.FileChecksum(filename, (Hasher.HashingAlgorithm)index);
                            BeginInvoke(new Action(() => //update UI
                            {
                                UpdateLabelHash((Hasher.HashingAlgorithm)index, hash);
                                progressBar.Value += (int)(100 / numberOfSelected);
                            }));
                        }));                                                       
                    }
                }
                await Task.WhenAll(tasks.ToArray()); //wait for all threads to finish
                progressBar.Value = 100;
            }
            else //Some threads will have to calculate multiple algorithms (Also works for single thread)
            {
                uint numberOfThreadsUsed = 0;
                for (int i = 0; i < useAlgorithm.Count(); i++)
                {
                    if (useAlgorithm[i])
                    {
                        numberOfThreadsUsed++;
                        int index = i;
                        if (numberOfThreadsUsed > threadsToUse)
                        {
                            await Task.WhenAny(tasks.ToArray()); //wait for any thread to finish before starting a new one
                            numberOfThreadsUsed--;
                        }
                        tasks.Add(Task.Run(() =>
                        {
                            Console.WriteLine("Thread " + index + " working");
                            string hash = Hasher.FileChecksum(filename, (Hasher.HashingAlgorithm)index);
                            Console.WriteLine("Thread " + index + " stopped working");
                            BeginInvoke(new Action(() => //update UI
                            {
                                UpdateLabelHash((Hasher.HashingAlgorithm)index, hash);
                                progressBar.Value += (int)(100 / numberOfSelected);
                            }));
                        }));
                    }
                }
                await Task.WhenAll(tasks.ToArray()); //wait for all threads to finish
                progressBar.Value = 100;
            }
            progressBar.Value = 0;
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
            GenerateCheckSum(pathToFile);
        }

        private void checkBoxCRC32_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxRIPEMD160_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSHA512_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSHA256_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxSHA1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxMD5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelCRC32_Click(object sender, EventArgs e)
        {

        }

        private void labelRipeMD160_Click(object sender, EventArgs e)
        {

        }

        private void labelSHA512_Click(object sender, EventArgs e)
        {

        }

        private void labelSHA256_Click(object sender, EventArgs e)
        {

        }

        private void labelSHA1_Click(object sender, EventArgs e)
        {

        }

        private void labelMD5_Click(object sender, EventArgs e)
        {

        }

        private void labelLocation_Click(object sender, EventArgs e)
        {

        }

        private void listBoxLog_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelHash_Click(object sender, EventArgs e)
        {

        }

        private void textBoxHash_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelMD5Output_Click(object sender, EventArgs e)
        {

        }

        private void labelSHA1Output_Click(object sender, EventArgs e)
        {

        }

        private void labelSHA256Output_Click(object sender, EventArgs e)
        {

        }

        private void labelSHA512Output_Click(object sender, EventArgs e)
        {

        }

        private void labelRipeMDOutput_Click(object sender, EventArgs e)
        {

        }

        private void labelCRC32Output_Click(object sender, EventArgs e)
        {

        }

        private void labelCheckSum_Click(object sender, EventArgs e)
        {

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

        private void buttonCancel_Click(object sender, EventArgs e)
        {

        }
    }
}

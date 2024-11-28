using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static HashTester.Hasher;
using static HashTester.Settings;
using static System.Net.Mime.MediaTypeNames;

namespace HashTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Settings settings = new Settings();        
        Hasher.HashingAlgorithm algorithm;
        Hasher hasher = new Hasher();
        #region MainButtons
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textHashSimple.Lines.Length; i++)
            {
                string text = textHashSimple.Lines[i];
                string hash = string.Empty;
                bool isSaltUsed = false, isPepperUsed = false;

                if (settings.useSalt || settings.usePepper)
                {
                    using (SaltAndPepperQuestion saltAndPepperQuestion = new SaltAndPepperQuestion(settings.useSalt, settings.usePepper))
                    {
                        if (saltAndPepperQuestion.ShowDialog() == DialogResult.OK)
                        {
                            saltAndPepperQuestion.GetSaltPepperInformation(
                                out bool generateSalt,
                                out int saltLength,
                                out string ownSalt,
                                out bool generatePepper,
                                out int pepperLength,
                                out string ownPepper,
                                out string hashID);

                            if (generateSalt || generatePepper)
                            {
                                string generatedSalt = generateSalt ? hasher.GenerateSalt(saltLength) : ownSalt;
                                string generatedPepper = generatePepper ? hasher.GeneratePepper(pepperLength) : ownPepper;

                                if (generateSalt)
                                {
                                    hasher.SaveSalt(hashID, generatedSalt);
                                }

                                hash = hasher.HashSaltPepper(text, generatedSalt, generateSalt, generatedPepper, algorithm);
                                isSaltUsed = generateSalt;
                                isPepperUsed = generatePepper;
                            }
                            else
                            {
                                hash = hasher.HashSaltPepper(text, ownSalt, settings.useSalt, ownPepper, algorithm);
                                isSaltUsed = settings.useSalt;
                                isPepperUsed = settings.usePepper;
                            }
                        }
                    }
                }
                else
                {
                    hash = hasher.Hash(text, algorithm);
                }
                string outputString = OutputStyleString(text, hash, i + 1, isSaltUsed, isPepperUsed);
                OutputTypeShow(outputString);
            }
        }


        /// <summary>
        /// Handles output based on user settings.
        /// </summary>
        private void OutputTypeShow(string outputString)
        {
            switch (settings.OutputType)
            {
                case OutputTypeEnum.MessageBox:
                    MessageBox.Show(outputString);
                    break;
                case OutputTypeEnum.Listbox:
                    listBox1.Items.Add(outputString);
                    break;
                case OutputTypeEnum.TXTFile:
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, outputString);
                    }
                    break;
            }
        }

        private void TXTInput_Click(object sender, EventArgs e)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                        {
                            if (settings.OutputType == OutputTypeEnum.TXTFile)
                            {
                                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                                    {
                                        int indexOfHash = 0;
                                        while (!reader.EndOfStream)
                                        {
                                            string text = reader.ReadLine();
                                            string hash = hasher.Hash(text, algorithm);
                                            indexOfHash++;
                                            string outputString = OutputStyleString(text, hash, indexOfHash, false, false);
                                            writer.WriteLine(outputString);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int indexOfHash = 0;
                                while (!reader.EndOfStream)
                                {
                                    string text = reader.ReadLine();
                                    string hash = hasher.Hash(text, algorithm);
                                    indexOfHash++;
                                    string outputString = OutputStyleString(text, hash, indexOfHash, false, false);
                                    if (settings.OutputType == OutputTypeEnum.MessageBox) MessageBox.Show(outputString);
                                    else listBox1.Items.Add(outputString);
                                }
                            }
                        }
                    }
                }
        private void button1_Click(object sender, EventArgs e) //clearListbox
        {
            listBox1.Items.Clear();
        }
        #endregion
        
        #region Forms

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        #endregion

        private string OutputStyleString(string originalString, string hash, int indexOfHash, bool isSaltUsed, bool isPepperUsed)
        {
            string outputString = hash;
            if (settings.OutputStyleIncludeOriginalString)
            {
                outputString = originalString + ": " + outputString;
            }
            if (settings.OutputStyleIncludeHashAlgorithm)
            {
                switch (algorithm)
                {
                    case HashingAlgorithm.MD5: outputString = "(MD5) " + outputString; break;
                    case HashingAlgorithm.SHA1: outputString = "(SHA1) " + outputString; break;
                    case HashingAlgorithm.SHA256: outputString = "(SHA256) " + outputString; break;
                    case HashingAlgorithm.SHA512: outputString = "(SHA512) " + outputString; break;
                    case HashingAlgorithm.RIPEMD160: outputString = "(RIPEMD160) " + outputString; break;
                    case HashingAlgorithm.CRC32: outputString = "(CRC32) " + outputString; break;
                }
            }
            if (settings.OutputStyleIncludeNumberOfHash)
            {
                outputString = indexOfHash.ToString() + ". " + outputString;
            }
            if (settings.OutputStyleIncludeSaltPepper)
            {
                if (isSaltUsed) outputString += " (salt: " + hasher.CurrentSalt + ")";
                if (isPepperUsed) outputString += " (pepper: " + hasher.CurrentPepper + ")";
            }
            return outputString;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            settings.LoadSettings(); //load All Settings
            UIToolStripMenuLoad(); //Load Strip Menu Checked UI
        }

        #region MenuStrip

        private void UIToolStripMenuLoad()
        {
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeOriginalString;
            includeNumberOfHashToolStripMenuItem.Checked = settings.OutputStyleIncludeNumberOfHash;
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeHashAlgorithm;
            includeSaltToolStripMenuItem.Checked = settings.useSalt;
            includePepperToolStripMenuItem.Checked = settings.usePepper;
            includeSaltAndPepperToolStripMenuItem.Checked = settings.OutputStyleIncludeSaltPepper;
            switch (settings.OutputType)
            {
                case OutputTypeEnum.MessageBox: messageBoxToolStripMenuItem.Checked = true; break;
                case OutputTypeEnum.Listbox: listBoxToolStripMenuItem.Checked = true; break;
                case OutputTypeEnum.TXTFile: txtFileToolStripMenuItem.Checked = true; break;
            }
        }

        private void gradualHashingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGradual formGradual = new FormGradual();
            formGradual.Show();
        }

        #region SaltAndPepper
        private void includeSaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.useSalt = !settings.useSalt;
            includeSaltToolStripMenuItem.Checked = settings.useSalt;
            settings.SaveSettings();
        }

        private void includePepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.usePepper = !settings.usePepper;
            includePepperToolStripMenuItem.Checked = settings.usePepper;
            settings.SaveSettings();
        }
        #endregion

        #region Settings
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }

        #region Settings-OutputType
        private void messageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputType = OutputTypeEnum.MessageBox;
            messageBoxToolStripMenuItem.Checked = true;
            listBoxToolStripMenuItem.Checked = false;
            txtFileToolStripMenuItem.Checked = false;
            settings.SaveSettings();
        }

        private void listBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputType = OutputTypeEnum.Listbox;
            messageBoxToolStripMenuItem.Checked = false;
            listBoxToolStripMenuItem.Checked = true;
            txtFileToolStripMenuItem.Checked = false;
            settings.SaveSettings();
        }

        private void txtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputType = OutputTypeEnum.TXTFile;
            messageBoxToolStripMenuItem.Checked = false;
            listBoxToolStripMenuItem.Checked = false;
            txtFileToolStripMenuItem.Checked = true;
            settings.SaveSettings();
        }
        #endregion

        #region Settings-OutputStyle
        private void includeOriginalStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeOriginalString = !settings.OutputStyleIncludeOriginalString; //negace
            includeOriginalStringToolStripMenuItem.Checked = settings.OutputStyleIncludeOriginalString; //update UI
            settings.SaveSettings();
        }

        private void includeNumberOfHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeNumberOfHash = !settings.OutputStyleIncludeNumberOfHash; //negace
            includeNumberOfHashToolStripMenuItem.Checked = settings.OutputStyleIncludeNumberOfHash; //update UI
            settings.SaveSettings();
        }
        private void includeHashingAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeHashAlgorithm = !settings.OutputStyleIncludeHashAlgorithm; //negace
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeHashAlgorithm; //update UI
            settings.SaveSettings();
        }       

        private void includeSaltAndPepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeSaltPepper = !settings.OutputStyleIncludeSaltPepper;
            includeSaltAndPepperToolStripMenuItem.Checked = settings.OutputStyleIncludeSaltPepper;
            settings.SaveSettings();
        }

        #endregion

        #endregion

        #endregion

    }
}

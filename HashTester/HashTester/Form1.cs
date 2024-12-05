using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
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

        #region MainAlgorithms
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textHashSimple.Lines.Length; i++)
            {
                string text = textHashSimple.Lines[i];
                string hash = string.Empty;
                if (IsUsingSaltAndPepper(text, out bool isSaltUsed, out bool isPepperUsed))
                {
                    hash = hasher.HashSaltPepper(text, isSaltUsed, isPepperUsed);
                }
                else hash = hasher.Hash(text, algorithm);
                string outputString = OutputStyleString(text, hash, i + 1, isSaltUsed, isPepperUsed);
                OutputTypeShow(outputString, listBox1);
            }
        }


        /// <summary>
        /// Handles output based on user settings.
        /// </summary>
        public void OutputTypeShow(string outputString, ListBox listBox)
        {
            switch (settings.OutputType)
            {
                case OutputTypeEnum.MessageBox:
                    MessageBox.Show(outputString);
                    break;
                case OutputTypeEnum.Listbox:
                    listBox.Items.Add(outputString);
                    break;
                case OutputTypeEnum.TXTFile:
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog1.FileName, outputString);
                    }
                    break;
            }
        }

        private void TXTInput_Click(object sender, EventArgs e) //change and add salt
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                {
                    int indexOfHash = 0;
                    while (!reader.EndOfStream)
                    {
                        string text = reader.ReadLine();
                        string hash = hasher.Hash(text, algorithm);
                        indexOfHash++;
                        string outputString = OutputStyleString(text, hash, indexOfHash, false, false);
                        OutputTypeShow(outputString, listBox1);
                    }
                }
            }
            else MessageBox.Show("Input přerušen");
        }
        #endregion
        
        #region Controls

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings.LoadSettings(); //load All Settings
            UIToolStripMenuLoad(); //Load Strip Menu Checked UI
        }
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

        private void gradualHashingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGradual formGradual = new FormGradual();
            formGradual.Show();
        }
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

        #endregion

        public string OutputStyleString(string originalString, string hash, int indexOfHash, bool isSaltUsed, bool isPepperUsed)
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

        #region SaltAndPepper
        /// <summary>
        /// (USED FOR UNIT TESTS) Generates hash with custom/generated salt and pepper and returns already hashed salt
        /// </summary>
        /// <param name="text">Data that we want to hash</param>
        /// <param name="isSaltUsed"></param>
        /// <param name="isPepperUsed"></param>
        /// <param name="hash">Already hashed input</param>
        /// <param name="hashIDforTesting">Only for Unit Testing</param>
        /// <returns></returns>
        public bool IsUsingSaltAndPepper(string text, out bool isSaltUsed, out bool isPepperUsed, out string hashIDforTesting)
        {
            hashIDforTesting = "";
            isSaltUsed = false;
            isPepperUsed = false;
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
                        hashIDforTesting = hashID;
                        if (generateSalt || generatePepper)
                        {
                            string generatedSalt = generateSalt ? hasher.GenerateSalt(saltLength) : ownSalt;
                            string generatedPepper = generatePepper ? hasher.GeneratePepper(pepperLength) : ownPepper;

                            if (generateSalt) //Saves only the salt
                            {                                
                                hasher.SaveSalt(hashID, generatedSalt);
                            }                            
                            isSaltUsed = generateSalt;
                            isPepperUsed = generatePepper;
                        }
                        else
                        {
                            isSaltUsed = settings.useSalt;
                            isPepperUsed = settings.usePepper;

                            if (ownSalt != "") //Saves only the salt
                            {
                                hasher.SaveSalt(hashID, ownSalt);
                            }
                        }
                    }
                }
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Generates hash with custom/generated salt and pepper and returns already hashed salt
        /// </summary>
        /// <param name="text">Data that we want to hash</param>
        /// <param name="isSaltUsed"></param>
        /// <param name="isPepperUsed"></param>
        /// <param name="hash">Already hashed input</param>
        /// <returns></returns>
        public bool IsUsingSaltAndPepper(string text, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper)
        {
            salt = "";
            pepper = "";
            isSaltUsed = false;
            isPepperUsed = false;
            if (settings.useSalt || settings.usePepper)
            {
                using (SaltAndPepperQuestion saltAndPepperQuestion = new SaltAndPepperQuestion(settings.useSalt, settings.usePepper))
                {
                    if (saltAndPepperQuestion.ShowDialog() == DialogResult.OK)
                    {
                        saltAndPepperQuestion.GetSaltPepperInformation
                            (
                            out bool generateSalt,
                            out int saltLength,
                            out string ownSalt,
                            out bool generatePepper,
                            out int pepperLength,
                            out string ownPepper,
                            out string hashID
                            );
                        if (generateSalt || generatePepper)
                        {
                            salt = generateSalt ? hasher.GenerateSalt(saltLength) : ownSalt;
                            pepper = generatePepper ? hasher.GeneratePepper(pepperLength) : ownPepper;

                            if (generateSalt) //Saves only the salt
                            {
                                hasher.SaveSalt(hashID, salt);
                            }
                            isSaltUsed = generateSalt;
                            isPepperUsed = generatePepper;
                        }
                        else
                        {
                            isSaltUsed = settings.useSalt;
                            isPepperUsed = settings.usePepper;
                            salt = ownSalt;
                            pepper = ownPepper;
                            if (ownSalt != "") //Saves only the salt
                            {
                                hasher.SaveSalt(hashID, ownSalt);
                            }
                        }
                    }
                }
                return true;
            }
            else return false;
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

    }
}

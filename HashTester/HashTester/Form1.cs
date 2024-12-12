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
        OutputHandler outputHandler = new OutputHandler();

        #region MainAlgorithms
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textHashSimple.Lines.Length; i++)
            {
                string text = textHashSimple.Lines[i];
                string hash = string.Empty;
                if (IsUsingSaltAndPepper(text, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper))
                {
                    hash = hasher.HashSaltPepper(text, isSaltUsed, isPepperUsed, salt, pepper, algorithm);
                }
                else hash = hasher.Hash(text, algorithm);
                string outputString = outputHandler.OutputStyleString(text, hash, i + 1, isSaltUsed, isPepperUsed);
                outputHandler.OutputTypeShow(outputString, listBox1);
            }
        }

        private void TXTInput_Click(object sender, EventArgs e)
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
                        string outputString = outputHandler.OutputStyleString(text, hash, indexOfHash, false, false);
                        outputHandler.OutputTypeShow(outputString, listBox1);
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
            UpdateMenuStripSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
            settings.LoadSettings();
            UIToolStripMenuLoad();
        }
        private void includeSaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.UseSalt = !settings.UseSalt;
            includeSaltToolStripMenuItem.Checked = settings.UseSalt;
            settings.SaveSettings();
        }

        private void includePepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.UsePepper = !settings.UsePepper;
            includePepperToolStripMenuItem.Checked = settings.UsePepper;
            settings.SaveSettings();
        }

        private void gradualHashingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGradual formGradual = new FormGradual();
            formGradual.Show();
        }
        private void UIToolStripMenuLoad()
        {
            includeOriginalStringToolStripMenuItem.Checked = settings.OutputStyleIncludeOriginalString;
            includeNumberOfHashToolStripMenuItem.Checked = settings.OutputStyleIncludeNumberOfHash;
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeHashAlgorithm;
            includeSaltToolStripMenuItem.Checked = settings.UseSalt;
            includePepperToolStripMenuItem.Checked = settings.UsePepper;
            includeSaltAndPepperToolStripMenuItem.Checked = settings.OutputStyleIncludeSaltPepper;
            switch (settings.OutputType)
            {
                case OutputTypeEnum.MessageBox: messageBoxToolStripMenuItem.Checked = true; break;
                case OutputTypeEnum.Listbox: listBoxToolStripMenuItem.Checked = true; break;
                case OutputTypeEnum.TXTFile: txtFileToolStripMenuItem.Checked = true; break;
            }
        }

        #endregion        

        #region SaltAndPepper
        public bool IsUsingSaltAndPepper(string text, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper, out string hashIDforTesting)
        {
            hashIDforTesting = "";
            salt = "";
            pepper = "";
            isSaltUsed = false;
            isPepperUsed = false;
            if (settings.UseSalt || settings.UsePepper)
            {
                using (SaltAndPepperQuestion saltAndPepperQuestion = new SaltAndPepperQuestion(settings.UseSalt, settings.UsePepper))
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
                        hashIDforTesting = hashID;
                        if (generateSalt || generatePepper)
                        {
                            salt = generateSalt ? hasher.GenerateSalt(saltLength) : ownSalt;
                            pepper = generatePepper ? hasher.GeneratePepper(pepperLength) : ownPepper;

                            if (generateSalt)
                            {
                                hasher.SaveSalt(hashIDforTesting, salt);
                            }
                            isSaltUsed = generateSalt;
                            isPepperUsed = generatePepper;
                        }
                        else
                        {
                            isSaltUsed = settings.UseSalt;
                            isPepperUsed = settings.UsePepper;
                            salt = ownSalt;
                            pepper = ownPepper;
                            if (ownSalt != "")
                            {
                                hasher.SaveSalt(hashIDforTesting, ownSalt);
                            }
                        }
                    }
                }
                return true;
            }
            else return false;
        }

        public bool IsUsingSaltAndPepper(string text, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper)
        {
            salt = "";
            pepper = "";
            isSaltUsed = false;
            isPepperUsed = false;
            if (settings.UseSalt || settings.UsePepper)
            {
                using (SaltAndPepperQuestion saltAndPepperQuestion = new SaltAndPepperQuestion(settings.UseSalt, settings.UsePepper))
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

                            if (generateSalt)
                            {
                                hasher.SaveSalt(hashID, salt);
                            }
                            isSaltUsed = generateSalt;
                            isPepperUsed = generatePepper;
                        }
                        else
                        {
                            isSaltUsed = settings.UseSalt;
                            isPepperUsed = settings.UsePepper;
                            salt = ownSalt;
                            pepper = ownPepper;
                            if (ownSalt != "")
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

        private void UpdateMenuStripSettings()
        {
            // Output Style Settings
            includeOriginalStringToolStripMenuItem.Checked = settings.OutputStyleIncludeOriginalString;
            includeNumberOfHashToolStripMenuItem.Checked = settings.OutputStyleIncludeNumberOfHash;
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeHashAlgorithm;
            includeSaltAndPepperToolStripMenuItem.Checked = settings.OutputStyleIncludeSaltPepper;

            // Output Type Settings
            switch (settings.OutputType)
            {
                case OutputTypeEnum.MessageBox:
                    messageBoxToolStripMenuItem.Checked = true;
                    listBoxToolStripMenuItem.Checked = false;
                    txtFileToolStripMenuItem.Checked = false;
                    break;
                case OutputTypeEnum.Listbox:
                    messageBoxToolStripMenuItem.Checked = false;
                    listBoxToolStripMenuItem.Checked = true;
                    txtFileToolStripMenuItem.Checked = false;
                    break;
                case OutputTypeEnum.TXTFile:
                    messageBoxToolStripMenuItem.Checked = false;
                    listBoxToolStripMenuItem.Checked = false;
                    txtFileToolStripMenuItem.Checked = true;
                    break;
            }

            // Salt and Pepper settings
            includeSaltToolStripMenuItem.Checked = settings.UseSalt;
            includePepperToolStripMenuItem.Checked = settings.UsePepper;
        }

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
            settings.OutputStyleIncludeOriginalString = !settings.OutputStyleIncludeOriginalString;
            includeOriginalStringToolStripMenuItem.Checked = settings.OutputStyleIncludeOriginalString;
            settings.SaveSettings();
        }

        private void includeNumberOfHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeNumberOfHash = !settings.OutputStyleIncludeNumberOfHash;
            includeNumberOfHashToolStripMenuItem.Checked = settings.OutputStyleIncludeNumberOfHash;
            settings.SaveSettings();
        }
        private void includeHashingAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeHashAlgorithm = !settings.OutputStyleIncludeHashAlgorithm;
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeHashAlgorithm;
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(settings.ToString());
        }
    }
}

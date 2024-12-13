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
        Hasher.HashingAlgorithm algorithm;
        Hasher hasher = new Hasher();
        #region MainAlgorithms
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textHashSimple.Lines.Length; i++)
            {
                string text = textHashSimple.Lines[i];
                string hash = string.Empty;
                if (hasher.IsUsingSaltAndPepper(text, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper))
                {
                    Console.WriteLine("SimpleButtonClick - Salt: " + salt);
                    Console.WriteLine("SimpleButtonClick - Pepper: " + pepper);
                    hash = hasher.HashSaltPepper(text, isSaltUsed, isPepperUsed, salt, pepper, algorithm);
                }
                else hash = hasher.Hash(text, algorithm);
                OutputHandler outputHandler = new OutputHandler(algorithm);
                string outputString = outputHandler.OutputStyleString(text, hash, i + 1, isSaltUsed, isPepperUsed, salt, pepper);
                outputHandler.OutputTypeShow(outputString, listBox1);
            }
        }

        private void TXTInput_Click(object sender, EventArgs e) //NOT DONE
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
                        OutputHandler outputHandler = new OutputHandler(algorithm);
                        string outputString = outputHandler.OutputStyleString(text, hash, indexOfHash, false, false, null, null);
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
            Settings.LoadSettings();
            UIToolStripMenuLoad();
        }
        private void includeSaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.UseSalt = !Settings.UseSalt;
            includeSaltToolStripMenuItem.Checked = Settings.UseSalt;
            Settings.SaveSettings();
        }

        private void includePepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.UsePepper = !Settings.UsePepper;
            includePepperToolStripMenuItem.Checked = Settings.UsePepper;
            Settings.SaveSettings();
        }

        private void gradualHashingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGradual formGradual = new FormGradual();
            formGradual.Show();
        }
        private void UIToolStripMenuLoad()
        {
            includeOriginalStringToolStripMenuItem.Checked = Settings.OutputStyleIncludeOriginalString;
            includeNumberOfHashToolStripMenuItem.Checked = Settings.OutputStyleIncludeNumberOfHash;
            includeHashingAlgorithmToolStripMenuItem.Checked = Settings.OutputStyleIncludeHashAlgorithm;
            includeSaltToolStripMenuItem.Checked = Settings.UseSalt;
            includePepperToolStripMenuItem.Checked = Settings.UsePepper;
            includeSaltAndPepperToolStripMenuItem.Checked = Settings.OutputStyleIncludeSaltPepper;
            switch (Settings.OutputType)
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
            if (Settings.UseSalt || Settings.UsePepper)
            {
                using (SaltAndPepperQuestion saltAndPepperQuestion = new SaltAndPepperQuestion())
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
                            isSaltUsed = Settings.UseSalt;
                            isPepperUsed = Settings.UsePepper;
                            salt = ownSalt;
                            pepper = ownPepper;
                            if (ownSalt != "")
                            {
                                hasher.SaveSalt(hashIDforTesting, ownSalt);
                            }
                        }
                    }
                    else return false;
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
            includeOriginalStringToolStripMenuItem.Checked = Settings.OutputStyleIncludeOriginalString;
            includeNumberOfHashToolStripMenuItem.Checked = Settings.OutputStyleIncludeNumberOfHash;
            includeHashingAlgorithmToolStripMenuItem.Checked = Settings.OutputStyleIncludeHashAlgorithm;
            includeSaltAndPepperToolStripMenuItem.Checked = Settings.OutputStyleIncludeSaltPepper;

            // Output Type Settings
            switch (Settings.OutputType)
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
            includeSaltToolStripMenuItem.Checked = Settings.UseSalt;
            includePepperToolStripMenuItem.Checked = Settings.UsePepper;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }

        #region Settings-OutputType
        private void messageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputType = OutputTypeEnum.MessageBox;
            messageBoxToolStripMenuItem.Checked = true;
            listBoxToolStripMenuItem.Checked = false;
            txtFileToolStripMenuItem.Checked = false;
            Settings.SaveSettings();
        }

        private void listBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputType = OutputTypeEnum.Listbox;
            messageBoxToolStripMenuItem.Checked = false;
            listBoxToolStripMenuItem.Checked = true;
            txtFileToolStripMenuItem.Checked = false;
            Settings.SaveSettings();
        }

        private void txtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputType = OutputTypeEnum.TXTFile;
            messageBoxToolStripMenuItem.Checked = false;
            listBoxToolStripMenuItem.Checked = false;
            txtFileToolStripMenuItem.Checked = true;
            Settings.SaveSettings();
        }
        #endregion

        #region Settings-OutputStyle
        private void includeOriginalStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputStyleIncludeOriginalString = !Settings.OutputStyleIncludeOriginalString;
            includeOriginalStringToolStripMenuItem.Checked = Settings.OutputStyleIncludeOriginalString;
            Settings.SaveSettings();
        }

        private void includeNumberOfHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputStyleIncludeNumberOfHash = !Settings.OutputStyleIncludeNumberOfHash;
            includeNumberOfHashToolStripMenuItem.Checked = Settings.OutputStyleIncludeNumberOfHash;
            Settings.SaveSettings();
        }
        private void includeHashingAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputStyleIncludeHashAlgorithm = !Settings.OutputStyleIncludeHashAlgorithm;
            includeHashingAlgorithmToolStripMenuItem.Checked = Settings.OutputStyleIncludeHashAlgorithm;
            Settings.SaveSettings();
        }

        private void includeSaltAndPepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputStyleIncludeSaltPepper = !Settings.OutputStyleIncludeSaltPepper;
            includeSaltAndPepperToolStripMenuItem.Checked = Settings.OutputStyleIncludeSaltPepper;
            Settings.SaveSettings();
        }

        #endregion

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Settings.TemporaryOutput());
        }
    }
}

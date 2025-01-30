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

        #region Form Stuff Handling
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            ProcessingHash(textHashSimple.Lines, algorithm, listBoxLog);
        }
        private void TXTInput_Click(object sender, EventArgs e)
        {
            ProcessingHashTXTInput(algorithm, listBoxLog);
        }
        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
            UpdateMenuStripSettings();
        }
        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }
        #endregion

        #region StripMenu
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

        #region Hashing        

        #region SaltAndPepper
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

        #endregion

        #region Gradual Hashing

        private void gradualHashingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGradual formGradual = new FormGradual();
            formGradual.Show();
        }

        #endregion

        #region MultipleHashing
        private void multipleHashingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultipleHashing multipleHashing = new MultipleHashing();
            multipleHashing.Show();
        }
        #endregion

        #region FindingCollisions
        private void findingCollisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HashingCollisionForm hashingCollisionForm = new HashingCollisionForm();
            hashingCollisionForm.Show();
        }
        #endregion

        #region FileChecksum

        #endregion

        #region Password JailBreak

        #endregion

        #endregion

        #region Options

        #region Option-Settings

        #region Settings-VisualMode
        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!systemToolStripMenuItem.Checked)
            {
                systemToolStripMenuItem.Checked = true;
                lightToolStripMenuItem.Checked = false;
                darkToolStripMenuItem.Checked = false;
                Settings.VisualMode = VisualModeEnum.System;
                Settings.SaveSettings();
            }
        }

        private void lightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!lightToolStripMenuItem.Checked)
            {
                systemToolStripMenuItem.Checked = false;
                lightToolStripMenuItem.Checked = true;
                darkToolStripMenuItem.Checked = false;
                Settings.VisualMode = VisualModeEnum.Light;
                Settings.SaveSettings();
            }
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!darkToolStripMenuItem.Checked)
            {
                systemToolStripMenuItem.Checked = false;
                lightToolStripMenuItem.Checked = false;
                darkToolStripMenuItem.Checked = true;
                Settings.VisualMode = VisualModeEnum.Dark;
                Settings.SaveSettings();
            }
        }
        #endregion

        #region PathToFolder
        private void baseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagement.ChangeDirectory(FormManagement.FolderType.Base);
        }

        private void collisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagement.ChangeDirectory(FormManagement.FolderType.Collision);
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagement.ChangeDirectory(FormManagement.FolderType.Password);
        }

        private void logSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagement.ChangeDirectory(FormManagement.FolderType.Log);
        }

        #endregion

        #region ResetAllSettings
        private void resetAllSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfirmationForm confirm = new ConfirmationForm("Are you sure you want to reset all settings?");
            if (confirm.ShowDialog() == DialogResult.OK)
            {
                Settings.ResetSettings();
                Settings.SaveSettings();
            }
        }

        #endregion

        #endregion

        #region Option-OutputType
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

        #region Option-OutputStyle
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

        #endregion 

        #region ProcessingHash
        //Singular Algorithms
        public void ProcessingHash(string[] originalText, Hasher.HashingAlgorithm algorithm, ListBox listbox)
        {
            bool usingSaltAndPepper = hasher.IsUsingSaltAndPepper(out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper);

            for (int i = 0; i < originalText.Length; i++)
            {
                string hash = string.Empty;

                if (usingSaltAndPepper)
                {
                    Console.WriteLine("ProcessHashing - Salt: " + salt);
                    Console.WriteLine("ProcessHashing - Pepper: " + pepper);
                    hash = hasher.HashSaltPepper(originalText[i], isSaltUsed, isPepperUsed, salt, pepper, algorithm);
                }
                else
                {
                    hash = hasher.Hash(originalText[i], algorithm);
                }

                OutputHandler outputHandler = new OutputHandler(algorithm);
                string outputString = outputHandler.OutputStyleString(originalText[i], hash, i + 1, isSaltUsed, isPepperUsed, salt, pepper);
                outputHandler.OutputTypeShow(outputString, listbox);
            }
        }
        public void ProcessingHashTXTInput(Hasher.HashingAlgorithm algorithm, ListBox listbox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.BasePathToFiles;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    List<string> lines = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        lines.Add(reader.ReadLine());
                    }
                    ProcessingHash(lines.ToArray(), algorithm, listbox);
                }
            }
            else
            {
                MessageBox.Show("Input přerušen");
            }
        }
        //Multiple Algorithms
        public void ProcessingHash(string[] originalText, Hasher.HashingAlgorithm[] algorithm, ListBox listbox)
        {
            bool usingSaltAndPepper = hasher.IsUsingSaltAndPepper(out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper);
            List<string> outputString = new List<string>();
            OutputHandler outputHandler;
            for (int i = 0; i < originalText.Length; i++)
            {
                foreach (Hasher.HashingAlgorithm currentlyUsedAlgorithm in algorithm)
                {
                    string hash;
                    if (usingSaltAndPepper)
                    {
                        Console.WriteLine("ProcessHashing - Salt: " + salt);
                        Console.WriteLine("ProcessHashing - Pepper: " + pepper);
                        hash = hasher.HashSaltPepper(originalText[i], isSaltUsed, isPepperUsed, salt, pepper, currentlyUsedAlgorithm);
                    }
                    else
                    {
                        hash = hasher.Hash(originalText[i], currentlyUsedAlgorithm);
                    }
                    outputHandler = new OutputHandler(currentlyUsedAlgorithm);
                    outputString.Add(outputHandler.OutputStyleString(originalText[i], hash, i + 1, isSaltUsed, isPepperUsed, salt, pepper));
                }
            }
            outputHandler = new OutputHandler();
            outputHandler.OutputTypeShow(outputString.ToArray(), listbox);
        }
        public void ProcessingHashTXTInput(Hasher.HashingAlgorithm[] algorithm, ListBox listbox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.BasePathToFiles;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    List<string> text = new List<string>();
                    while (!reader.EndOfStream)
                    {
                        text.Add(reader.ReadLine());
                    }
                    ProcessingHash(text.ToArray(), algorithm, listbox);
                }
            }
            else
            {
                MessageBox.Show("Input přerušen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region SaltAndPepperLogic
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

        private void Form1_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
            Settings.LoadSettings();
            UIToolStripMenuLoad();
        }

        private void passwordJailbreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.Show();
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }
    }
}

using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using static HashTester.Hasher;
using static HashTester.Settings;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            if (!String.IsNullOrEmpty(textHashSimple.Text)) //check
            {
                bool askForSaltPepper = false;
                if (Settings.UsePepper || Settings.UseSalt) askForSaltPepper = true;
                ProcessingHash(textHashSimple.Lines, algorithm, askForSaltPepper);
            }
        }
        public void TXTInput_Click(object sender, EventArgs e)
        {
            bool askForSaltPepper = false;
            if (Settings.UsePepper || Settings.UseSalt) askForSaltPepper = true;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.DirectoryExeBase;
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.DefaultExt = "txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ProcessingHashTXTInput(algorithm, openFileDialog.FileName ,askForSaltPepper);
            }
            else
            {
                MessageBox.Show(Languages.Translate(41), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void UIToolStripMenuLoad()
        {
            UpdateMenuStripSettings();
        }
        private void UpdateMenuStripSettings()
        {
            // Output Style Settings
            includeOriginalStringToolStripMenuItem.Checked = Settings.OutputStyleIncludeOriginalString;
            includeNumberOfHashToolStripMenuItem.Checked = Settings.OutputStyleIncludeNumberOfHash;
            includeHashingAlgorithmToolStripMenuItem.Checked = Settings.OutputStyleIncludeHashAlgorithm;
            includeSaltAndPepperToolStripMenuItem.Checked = Settings.OutputStyleIncludeSaltPepper;
            UpdateIncludeAllOutputStyle();

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

        private void UpdateIncludeAllOutputStyle()
        {
            if (Settings.OutputStyleIncludeOriginalString &&
                Settings.OutputStyleIncludeNumberOfHash &&
                Settings.OutputStyleIncludeHashAlgorithm &&
                Settings.OutputStyleIncludeSaltPepper) includeAllToolStripMenuItem.Checked = true;
            else includeAllToolStripMenuItem.Checked = false;
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
            formGradual.StartPosition = FormStartPosition.CenterScreen;
            formGradual.ShowDialog();
        }

        #endregion

        #region MultipleHashing
        private void multipleHashingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultipleHashing multipleHashing = new MultipleHashing();
            multipleHashing.StartPosition = FormStartPosition.CenterScreen;
            multipleHashing.ShowDialog();
        }
        #endregion

        #region FindingCollisions
        private void findingCollisionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HashingCollisionForm hashingCollisionForm = new HashingCollisionForm();
            hashingCollisionForm.StartPosition = FormStartPosition.CenterScreen;
            hashingCollisionForm.ShowDialog();
        }
        #endregion

        #region FileChecksum

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
                FormManagement.SetUpFormTheme(this);
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
                FormManagement.SetUpFormTheme(this);
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
                FormManagement.SetUpFormTheme(this);
            }
        }
        #endregion

        #region ResetAllSettings
        private void resetAllSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show(Languages.Translate(45), Languages.Translate(46),MessageBoxButtons.OKCancel, MessageBoxIcon.Question ) == DialogResult.OK)
            {
                Settings.ResetSettings();
                Settings.SaveSettings();
                UpdateMenuStripSettings();
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
            UpdateIncludeAllOutputStyle();
        }

        private void includeNumberOfHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputStyleIncludeNumberOfHash = !Settings.OutputStyleIncludeNumberOfHash;
            includeNumberOfHashToolStripMenuItem.Checked = Settings.OutputStyleIncludeNumberOfHash;
            Settings.SaveSettings();
            UpdateIncludeAllOutputStyle();
        }
        private void includeHashingAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputStyleIncludeHashAlgorithm = !Settings.OutputStyleIncludeHashAlgorithm;
            includeHashingAlgorithmToolStripMenuItem.Checked = Settings.OutputStyleIncludeHashAlgorithm;            
            Settings.SaveSettings();
            UpdateIncludeAllOutputStyle();
        }

        private void includeSaltAndPepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.OutputStyleIncludeSaltPepper = !Settings.OutputStyleIncludeSaltPepper;
            includeSaltAndPepperToolStripMenuItem.Checked = Settings.OutputStyleIncludeSaltPepper;            
            Settings.SaveSettings();
            UpdateIncludeAllOutputStyle();
        }

        private void includeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (includeAllToolStripMenuItem.Checked)
            {
                Settings.OutputStyleIncludeNumberOfHash = false;
                Settings.OutputStyleIncludeSaltPepper = false;
                Settings.OutputStyleIncludeHashAlgorithm = false;
                Settings.OutputStyleIncludeOriginalString = false;
                includeAllToolStripMenuItem.Checked = false;
            }
            else
            {
                Settings.OutputStyleIncludeNumberOfHash = true;
                Settings.OutputStyleIncludeSaltPepper = true;
                Settings.OutputStyleIncludeHashAlgorithm = true;
                Settings.OutputStyleIncludeOriginalString = true;
                includeAllToolStripMenuItem.Checked = true;
            }
            Settings.SaveSettings();
            UpdateMenuStripSettings();
        }

        #endregion

        #endregion

        #endregion 

        #region ProcessingHash
        //Singular Algorithms
        public void ProcessingHash(string[] originalText, Hasher.HashingAlgorithm algorithm, bool askForSaltPepper)
        {
            bool usingSaltAndPepper = false;
            bool isSaltUsed = false;
            bool isPepperUsed = false;
            string salt = "";
            string pepper = "";
            OutputHandler outputHandler = new OutputHandler(algorithm);
            string[] outputString = new string [originalText.Length];
            if (askForSaltPepper) usingSaltAndPepper = hasher.IsUsingSaltAndPepper(out isSaltUsed, out isPepperUsed, out salt, out pepper);
            for (int i = 0; i < originalText.Length; i++)
            {
                string hash = string.Empty;
                if (usingSaltAndPepper)
                {
                    //Console.WriteLine("ProcessHashing - Salt: " + salt);
                    //Console.WriteLine("ProcessHashing - Pepper: " + pepper);
                    hash = hasher.HashSaltPepper(originalText[i], isSaltUsed, isPepperUsed, salt, pepper, algorithm);
                }
                else
                {
                    hash = hasher.Hash(originalText[i], algorithm);
                }
                outputString[i] = outputHandler.OutputStyleString(originalText[i], hash, i + 1, isSaltUsed, isPepperUsed, salt, pepper);                
            }
            outputHandler.OutputTypeShow(outputString, listBoxLog);
        }
        public void ProcessingHashTXTInput(Hasher.HashingAlgorithm algorithm, string fileNamePath, bool askForSaltPepper)
        {
            using (StreamReader reader = new StreamReader(fileNamePath))
            {
                List<string> lines = new List<string>();
                while (!reader.EndOfStream)
                {
                    lines.Add(reader.ReadLine());
                }
                ProcessingHash(lines.ToArray(), algorithm, askForSaltPepper);
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
            openFileDialog.InitialDirectory = Settings.DirectoryExeBase;
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
                MessageBox.Show(Languages.Translate(41), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region SaltAndPepperLogic
        public bool IsUsingSaltAndPepper(string text, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper, out string hashID)
        {
            hashID = "";
            salt = "";
            pepper = "";
            isSaltUsed = false;
            isPepperUsed = false;
            if (Settings.UseSalt || Settings.UsePepper)
            {
                using (SaltAndPepperSetup saltAndPepperQuestion = new SaltAndPepperSetup())
                {
                    saltAndPepperQuestion.StartPosition = FormStartPosition.CenterScreen;
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
                            out hashID
                            );
                        if (generateSalt || generatePepper)
                        {
                            salt = generateSalt ? hasher.GenerateSalt(saltLength) : ownSalt;
                            pepper = generatePepper ? hasher.GeneratePepper(pepperLength) : ownPepper;

                            if (generateSalt)
                            {
                                hasher.SaveSalt(hashID, salt, pepper.Length);
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
                                hasher.SaveSalt(hashID, salt, pepper.Length);
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
            this.Name = Languages.Translate(701);
            hashSelector.SelectedIndex = 0;
            Settings.LoadSettings();
            UIToolStripMenuLoad();
            AddLanguagesToMenu();
            FormManagement.SetUpFormTheme(this);
            FormUISetUpLanguages();
        }

        private void passwordJailbreakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordForm passwordForm = new PasswordForm();
            passwordForm.StartPosition = FormStartPosition.CenterScreen;
            passwordForm.ShowDialog();
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }

        #region Unit-Tests
        public void TXTInput_Click_Test(string path, Hasher.HashingAlgorithm tempAlgorithm)
        {
            bool askForSaltPepper = false;
            if (Settings.UsePepper || Settings.UseSalt) askForSaltPepper = true;
            if (File.Exists(path))
            {
                ProcessingHashTXTInput(tempAlgorithm, path, askForSaltPepper);
            }
            else
            {
                listBoxLog.Items.Add(Languages.Translate(47));
            }
        }

        public List<string> GetListBoxUnitTest()
        {
            List<string> temp = new List<string>();
            foreach (string item in listBoxLog.Items)
            {
                temp.Add(item.ToString().Trim());
            }
            return temp;
        }

        #endregion

        private void UIUpdateFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIUpdateFrequency uIUpdateFrequency = new UIUpdateFrequency();
            uIUpdateFrequency.StartPosition = FormStartPosition.CenterScreen;
            if (uIUpdateFrequency.ShowDialog() == DialogResult.OK)
            {
                Settings.UpdateUIms = uIUpdateFrequency.Miliseconds;
                Settings.SaveSettings();
            }
        }

        private void AddLanguagesToMenu()
        {
            string[] array = Languages.AllLanguages();
            if (array != null && array.Length != 0)
            {
                bool firstItem = true;
                string dictionaryNameLoad = "";
                string[] possibleNames = new string[4];
                possibleNames[0] = Settings.SelectedLanguage;              // Original
                possibleNames[1] = Settings.SelectedLanguage.ToLower();    // all lower
                possibleNames[2] = Settings.SelectedLanguage.ToUpper();    // ALL UPPER
                possibleNames[3] = char.ToUpper(Settings.SelectedLanguage[0]) + Settings.SelectedLanguage.Substring(1).ToLower(); // First letter Upper

                foreach (string item in array)
                {
                    ToolStripMenuItem newItem = new ToolStripMenuItem(item);
                    newItem.Name = item;
                    if (possibleNames.Contains(newItem.Name)) //saved Language - priority
                    {
                        dictionaryNameLoad = newItem.Name;
                        firstItem = false; 
                    }
                    else if (firstItem) 
                    {
                        dictionaryNameLoad = newItem.Name;
                        firstItem = false;
                    }

                    newItem.Click += (sender, e) =>
                    {
                        Languages.LoadDictionary(newItem.Name);
                        foreach (ToolStripItem menuItem in languagesToolStripMenuItem.DropDownItems) //uncheck all
                        {
                            if (menuItem is ToolStripMenuItem toolStripMenuItem)
                            {
                                toolStripMenuItem.Checked = false;
                            }
                        }
                        newItem.Checked = true;
                        Settings.SelectedLanguage = newItem.Name;
                        FormUISetUpLanguages(); //set new language
                        Settings.SaveSettings();
                    };

                    languagesToolStripMenuItem.DropDownItems.Add(newItem);
                }
                Languages.LoadDictionary(dictionaryNameLoad);
                foreach (ToolStripItem menuItem in languagesToolStripMenuItem.DropDownItems) //Put the right one to checked state
                {
                    if (menuItem is ToolStripMenuItem toolStripMenuItem && toolStripMenuItem.Name == dictionaryNameLoad)
                    {
                        toolStripMenuItem.Checked = true;
                        break;
                    }
                }

            }

        }

        private void threadsAndCPUSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThreadsForm threadsForm = new ThreadsForm();
            threadsForm.StartPosition = FormStartPosition.CenterScreen;
            if (threadsForm.ShowDialog() == DialogResult.OK)
            {
                Settings.ThreadsUsagePercentage = threadsForm.Percentage;
                Settings.SaveSettings();
            }
        }

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show(Languages.Translate(42), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fileChecksumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileChecksum fileChecksum = new FileChecksum();
            fileChecksum.ShowDialog();
        }

        private void saltPepperTesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaltAndPepperTester saltAndPepperForm = new SaltAndPepperTester();
            saltAndPepperForm.ShowDialog();
        }

        private void FormUISetUpLanguages()
        {
            hashingToolStripMenuItem.Text = Languages.Translate(0);
            saltAndPepperToolStripMenuItem.Text = Languages.Translate(1);
            multipleHashingToolStripMenuItem.Text = Languages.Translate(2);
            findingCollisionsToolStripMenuItem.Text = Languages.Translate(3);
            passwordCrackerToolStripMenuItem.Text = Languages.Translate(4);
            includeSaltToolStripMenuItem.Text = Languages.Translate(5);
            includePepperToolStripMenuItem.Text = Languages.Translate(6);
            optionsToolStripMenuItem.Text = Languages.Translate(7);
            settingsToolStripMenuItem.Text = Languages.Translate(8);
            outputTypeStripMenuItem.Text = Languages.Translate(9);
            outputStyleToolStripMenuItem.Text = Languages.Translate(10);
            visualModeToolStripMenuItem.Text = Languages.Translate(11);
            UIUpdateFrequencyToolStripMenuItem.Text = Languages.Translate(13);
            threadsAndCPUSettingsToolStripMenuItem.Text = Languages.Translate(14);
            resetAllSettingsToolStripMenuItem.Text = Languages.Translate(15);
            systemToolStripMenuItem.Text = Languages.Translate(16);
            lightToolStripMenuItem.Text = Languages.Translate(17);
            darkToolStripMenuItem.Text = Languages.Translate(18);
            languagesToolStripMenuItem.Text = Languages.Translate(23);
            txtFileToolStripMenuItem.Text = Languages.Translate(24);
            includeAllToolStripMenuItem.Text = 
            includeHashingAlgorithmToolStripMenuItem.Text = 
            includeNumberOfHashToolStripMenuItem.Text = 
            includeOriginalStringToolStripMenuItem.Text =
            includePepperToolStripMenuItem.Text = 
            //Form
            buttonHashSimpleText.Text = Languages.Translate(31);
            buttonFileInput.Text = Languages.Translate(32);
            buttonClearListBox.Text = Languages.Translate(10000);
            buttonSaveLog.Text = Languages.Translate(10001);
            buttonClipboard.Text = Languages.Translate(10002);
        }
    }
}

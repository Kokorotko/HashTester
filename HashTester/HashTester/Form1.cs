using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HashTester.Hasher;
using static HashTester.Settings;

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
        readonly string programVersion = "1.1.1";
        private bool updateAvailable = false;

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
                MessageBox.Show(Languages.Translate(Languages.L.InputCancelled), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region ProcessingHash


        /// <summary>
        /// Creates hash (or multiple hashes) and returns it based on options
        /// </summary>
        /// <param name="originalText"></param>
        /// <param name="algorithm"></param>
        /// <param name="askForSaltPepper"></param>
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


        /// <summary>
        /// Creates hashes from a .txt file and returns it based on options
        /// </summary>
        /// <param name="algorithm">Hash algorithm</param>
        /// <param name="fileNamePath">File path to file</param>
        /// <param name="askForSaltPepper">True if you want to use salt and or pepper</param>
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
        

        /// <summary>
        /// Creates hash (or multiple) and outputs it into a listbox
        /// </summary>
        /// <param name="originalText"></param>
        /// <param name="algorithm"></param>
        /// <param name="listbox"></param>
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


        /// <summary>
        /// Creates hash (or hashes) from .txt file and outputs into a listbox
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="listbox">Listbox for output</param>
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
                MessageBox.Show(Languages.Translate(Languages.L.InputCancelled), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region SaltAndPepperLogic


        /// <summary>
        /// Between step if you want to add salt or pepper
        /// </summary>
        /// <param name="text">Original input you want to add salt and or pepper to</param>
        /// <param name="isSaltUsed">True if you want to use salt</param>
        /// <param name="isPepperUsed">True if you want to use pepper</param>
        /// <param name="salt">Is empty if isSaltUsed is false</param>
        /// <param name="pepper">Is empty if isPepper used is false</param>
        /// <param name="hashID">Outputs hashID for future clarification</param>
        /// <returns></returns>
        public bool IsUsingSaltAndPepper(string text, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper, out string hashID)
        {
            hashID = "";
            salt = "";
            pepper = "";
            isSaltUsed = false;
            isPepperUsed = false;
            if (Settings.UseSalt || Settings.UsePepper)
            {
                DialogResult var = FormManagement.SpawnForm(FormManagement.Forms.SaltAndPepperSetup, true);
                if (var == DialogResult.OK)
                {
                    FormManagement.Form_SaltAndPepperSetup.GetSaltPepperInformation
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
        #endregion

        #region Languages Set Up

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
                    //Set item to do something
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

        private void FormUISetUpLanguages()
        {
            UpdateRemindMe();
            hashingToolStripMenuItem.Text = Languages.Translate(Languages.L.Hashing);
            saltAndPepperToolStripMenuItem.Text = Languages.Translate(Languages.L.SaltAndPepper);
            multipleHashingToolStripMenuItem.Text = Languages.Translate(Languages.L.MultipleHashing);
            findingCollisionsToolStripMenuItem.Text = Languages.Translate(Languages.L.FindingCollisions);
            passwordCrackerToolStripMenuItem.Text = Languages.Translate(Languages.L.PasswordCracker);
            includeSaltToolStripMenuItem.Text = Languages.Translate(Languages.L.UseSalt);
            includePepperToolStripMenuItem.Text = Languages.Translate(Languages.L.UsePepper);
            optionsToolStripMenuItem.Text = Languages.Translate(Languages.L.Options);
            settingsToolStripMenuItem.Text = Languages.Translate(Languages.L.Settings);
            outputTypeStripMenuItem.Text = Languages.Translate(Languages.L.OutputType);
            outputStyleToolStripMenuItem.Text = Languages.Translate(Languages.L.OutputStyle);
            visualModeToolStripMenuItem.Text = Languages.Translate(Languages.L.Visualmode);
            UIUpdateFrequencyToolStripMenuItem.Text = Languages.Translate(Languages.L.UiUpdateFrequency);
            threadsAndCPUSettingsToolStripMenuItem.Text = Languages.Translate(Languages.L.ThreadsAndCpuSettings);
            resetAllSettingsToolStripMenuItem.Text = Languages.Translate(Languages.L.ResetAllSettings);
            systemToolStripMenuItem.Text = Languages.Translate(Languages.L.SystemTheme);
            lightToolStripMenuItem.Text = Languages.Translate(Languages.L.LightTheme);
            darkToolStripMenuItem.Text = Languages.Translate(Languages.L.DarkTheme);
            languagesToolStripMenuItem.Text = Languages.Translate(Languages.L.Languages);
            txtFileToolStripMenuItem.Text = Languages.Translate(Languages.L.FileTxt);
            includeAllToolStripMenuItem.Text = Languages.Translate(Languages.L.IncludeAllOptions);
            includeHashingAlgorithmToolStripMenuItem.Text = Languages.Translate(Languages.L.IncludeHashingAlgorithm);
            includeNumberOfHashToolStripMenuItem.Text = Languages.Translate(Languages.L.IncludeNumbering);
            includeOriginalStringToolStripMenuItem.Text = Languages.Translate(Languages.L.IncludeOriginalText);
            includeSaltAndPepperToolStripMenuItem.Text = Languages.Translate(Languages.L.IncludeSaltAndPepper);
            gradualHashingToolStripMenuItem1.Text = Languages.Translate(Languages.L.GradualHashing);
            fileChecksumToolStripMenuItem.Text = Languages.Translate(Languages.L.FileChecksum);
            saltPepperTesterToolStripMenuItem.Text = Languages.Translate(Languages.L.SaltAndPepperTester);
            labelCredits.Text = Languages.Translate(Languages.L.ProgramMadeBy) + " Kamil Franek" + Environment.NewLine + Languages.Translate(Languages.L.CurrentVersion) + ": " + programVersion;
            if (updateAvailable) labelCredits.Text += Environment.NewLine + Languages.Translate(Languages.L.ANewVersionOfTheApplicationIsAvailable);
            //Form
            buttonHashSimpleText.Text = Languages.Translate(Languages.L.HashText);
            buttonFileInput.Text = Languages.Translate(Languages.L.HashAFile);
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            showLogToolStripMenuItem.Text = Languages.Translate(Languages.L.ShowLogInListbox);
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);
        }

        #endregion

        #region Clipboard

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAnItemFromTheListBeforeCopying), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        /// <summary>
        /// Checks for updates (works with GithubAPI)
        /// </summary>
        /// <returns></returns>
        private async Task CheckForUpdates()
        {
            if (!NetworkInterface.GetIsNetworkAvailable()) return; //Dont check for updates when there is no internet...stupid
            if (!GithubAPI.CheckGithubAPITime()) return; //Please dont spam the Github API :( - 12 hours delay
            try
            {
                GithubAPI githubAPI = new GithubAPI();
                string githubVersionString = await githubAPI.GetVersion();
                Settings.GithubRequestAPI = DateTime.Now;
                Settings.SaveSettings();
                Version githubVersionL = new Version(githubVersionString);
                Version currentVersion = new Version(programVersion);
                if (githubVersionL > currentVersion) //Big Update
                {
                    if (githubVersionL.Major > currentVersion.Major)
                    {
                        if (Settings.RemindUpdate) MessageBox.Show(Languages.Translate(Languages.L.ANewVersionOfTheApplicationIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases) + "\n" + Languages.Translate(Languages.L.NewVersion) + ": " + githubVersionString + "\n" + Languages.Translate(Languages.L.CurrentVersion) + ": " + programVersion, Languages.Translate(Languages.L.ANewVersionOfTheApplicationIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases), MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        updateAvailable = true;
                    }
                    else if (githubVersionL.Minor > currentVersion.Minor) //medium Update
                    {
                        if (Settings.RemindUpdate) MessageBox.Show(Languages.Translate(Languages.L.AMajorUpdateIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases) + "\n" + Languages.Translate(Languages.L.NewVersion) + ": " + githubVersionString + "\n" + Languages.Translate(Languages.L.CurrentVersion) + ": " + programVersion, Languages.Translate(Languages.L.ANewVersionOfTheApplicationIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases), MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        updateAvailable = true;
                    }
                    else //Small Update
                    {
                        if (Settings.RemindUpdate) MessageBox.Show(Languages.Translate(Languages.L.AMinorUpdateIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases) + "\n" + Languages.Translate(Languages.L.NewVersion) + ": " + githubVersionString + "\n" + Languages.Translate(Languages.L.CurrentVersion) + ": " + programVersion, Languages.Translate(Languages.L.ANewVersionOfTheApplicationIsAvailableAtHttpsgithubcomkokorotkohashtesterreleases), MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        updateAvailable = true;
                    }
                }
                Console.WriteLine("Update Checked");
                if (updateAvailable)
                {
                    Console.WriteLine("Update Available");
                    labelCredits.Invoke((Action)(() =>
                    {
                        labelCredits.Text += Environment.NewLine + Languages.Translate(Languages.L.ANewVersionOfTheApplicationIsAvailable);
                    }));
                }
            }
            catch 
            {
                if (Settings.RemindUpdate) MessageBox.Show(Languages.Translate(Languages.L.AnErrorHasOccuredWhileTryingToCheckForUpdates), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.InitialFolderChecker();
            this.Name = Languages.Translate(Languages.L.Hashtester);
            hashSelector.SelectedIndex = 0;
            Settings.LoadSettings();
            UIToolStripMenuLoad();
            AddLanguagesToMenu();
            FormManagement.SetUpFormTheme(this);
            Task.Run(async () => await CheckForUpdates());
            FormUISetUpLanguages();
        }
    }
}

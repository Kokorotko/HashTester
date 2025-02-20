using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System.Runtime.Remoting.Channels;
using System.Security.Policy;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Timers;

namespace HashTester
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        bool taskCurrentlyWorking = false;
        int whatTaskIsWorking = -1; //1 == RainbowTableGenerator; 2== RainbowTableAttack; 3 == PasswordLeakTest
        Hasher.HashingAlgorithm bruteForceAlgorithm = Hasher.HashingAlgorithm.MD5;
        Hasher.HashingAlgorithm rainbowTableAlgorithm = Hasher.HashingAlgorithm.MD5;
        Hasher hasher = new Hasher();
        //Password Dictionary Attack and Bruteforce Attack

        #region FormManagement
        private void PasswordForm_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);          
            #region Languages
            labelProgressBar.Text = Languages.Translate(241);
            buttonCancel.Text = Languages.Translate(242);
            labelStatAttempts.Text = Languages.Translate(243);
            labelStatCurrentSpeed.Text = Languages.Translate(244);
            labelStatSpeed.Text = Languages.Translate(245);
            labelStatTimer.Text = Languages.Translate(10009);
            groupBoxDictionary.Text = Languages.Translate(247);
            groupBoxTimeToCrack.Text = Languages.Translate(248);
            groupBoxRainbowTable.Text = Languages.Translate(249);
            groupBoxBruteForce.Text = Languages.Translate(250);
            //Dictionary Attack
            radioButtonRockYouFull.Text = Languages.Translate(251);
            radioButtonRockYouShort.Text = Languages.Translate(252);
            radioButtonRockYouFullShortShort.Text = Languages.Translate(253);
            radioButtonRockyouCustom.Text = Languages.Translate(254);
            buttonDictionaryChangePath.Text = Languages.Translate(255);
            //Time to crack calculator
            labelCrackLenght.Text = Languages.Translate(256) + "/" + Languages.Translate(257);
            labelCrackSpeed.Text = Languages.Translate(258);
            checkBoxCrackLower.Text = Languages.Translate(259);
            checkBoxCrackUpper.Text = Languages.Translate(260);
            checkBoxCrackDigit.Text = Languages.Translate(261);
            checkBoxCrackSpecial.Text = Languages.Translate(262);
            buttonCrackCalculate.Text = Languages.Translate(263);
            //RainbowTableAttack
            radioButtonRegularRainbowTable.Text = Languages.Translate(264);
            radioButtonHashedRainbowTable.Text = Languages.Translate(265);
            buttonGenerateRainbowTable.Text = Languages.Translate(266);
            buttonRainbowTableAttack.Text = Languages.Translate(267);
            //BruteForceAttack
            radioButtonRegularBruteForce.Text = Languages.Translate(264);
            radioButtonBruteForceHashed.Text = Languages.Translate(265);
            labelMaxAttempts.Text = Languages.Translate(268);
            labelLenght.Text = Languages.Translate(269);
            labelStopTimer.Text = Languages.Translate(270);
            checkBoxUnknownLenghtBruteForce.Text = Languages.Translate(271);
            checkBoxHexOutputBruteForce.Text = Languages.Translate(272);
            #endregion
            hashSelectorBruteForce.SelectedIndex = 0;
            hashSelectorRainbowTable.SelectedIndex = 0;
            if (!FindIfTXTIsPresent("_wordlistInfo")) GenerateInfoTXT();
            DisableRockYouRadioButtons();
            if (FindIfTXTIsPresent("rockyou")) radioButtonRockYouFull.Enabled = true;
            if (FindIfTXTIsPresent("rockyouShort")) radioButtonRockYouShort.Enabled = true;
            if (FindIfTXTIsPresent("rockyouVeryShort")) radioButtonRockYouFullShortShort.Enabled = true;
            //checked
            if (radioButtonRockYouFull.Enabled) radioButtonRockYouFull.Checked = true;
            else if (radioButtonRockYouShort.Enabled) radioButtonRockYouShort.Checked = true;
            else if (radioButtonRockYouFullShortShort.Enabled) radioButtonRockYouFullShortShort.Checked = true;
            else radioButtonRockyouCustom.Checked = true;
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            bruteForceAlgorithm = (Hasher.HashingAlgorithm)hashSelectorBruteForce.SelectedIndex;
        }

        private void DisableRockYouRadioButtons()
        {
            radioButtonRockYouFull.Enabled = false;
            radioButtonRockYouShort.Enabled = false;
            radioButtonRockYouFullShortShort.Enabled = false;
            //radioButton04 (custom) is always available
        }

        private void DisableUI()
        {
            foreach (Control control in this.Controls) if (!(control is Label)) control.Enabled = false; //no need to disable labels
            listBoxLog.Enabled = true;
            buttonCancel.Enabled = true;
        }

        private void ActivateUI()
        {
            foreach (Control control in this.Controls) control.Enabled = true;
            progressBar1.Value = 0;
        }

        private bool FindIfTXTIsPresent(string name)
        {
            return File.Exists(Settings.PasswordPathToFiles + "\\" + name + ".txt");
        }

        private void GenerateInfoTXT()
        {
            string s =Languages.Translate(273) +": " + "https://github.com/brannondorsey/naive-hashcat/releases/download/data/rockyou.txt \r\nRockYouShort 1mil.\r\nRockYouVeryShort 5k\r\n" + Languages.Translate(274);
            File.WriteAllText(Settings.PasswordPathToFiles + "\\_wordlistInfo.txt", s);
        }

        private void buttonChangePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Settings.PasswordPathToFiles = dialog.SelectedPath;
                Settings.SaveSettings();
            }
        }
        private void buttonLogClear_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }
        private void buttonLogSave_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }
        #endregion

        #region Password Dictionary Attack - Done
        PasswordCheck passwordCheck = new PasswordCheck();
        long passwordCheckLinesProcessedLastUpdate = 0;
        private void UpdateUIPassword(object sender, EventArgs e)
        {
            if (passwordCheck.Stopwatch.ElapsedMilliseconds > 0)
            {
                int passwordLinesProcessedBetweenUpdates = (int)(passwordCheck.CurrentLine - passwordCheckLinesProcessedLastUpdate);
                passwordCheckLinesProcessedLastUpdate = passwordCheck.CurrentLine;
                labelStatTimer.Text = Languages.Translate(10009) + ": " + (passwordCheck.Stopwatch.ElapsedMilliseconds / 1000 + "." + passwordCheck.Stopwatch.ElapsedMilliseconds % 1000);
                double currentSpeed = passwordLinesProcessedBetweenUpdates / (Settings.UpdateUIms / 1000);
                labelStatCurrentSpeed.Text = Languages.Translate(244) + " " + currentSpeed.ToString("#,0");
                double averageSpeed = passwordCheck.CurrentLine / (passwordCheck.Stopwatch.ElapsedMilliseconds / 1000.0); //in seconds
                if (!double.IsInfinity(averageSpeed)) labelStatSpeed.Text = Languages.Translate(245) + " " + Math.Floor(averageSpeed).ToString("#,0");
                else labelStatSpeed.Text = Languages.Translate(245) + ": " + Languages.Translate(275);
                labelStatAttempts.Text = Languages.Translate(276) + " " + passwordCheck.CurrentLine.ToString("#,0");
                progressBar1.Value = passwordCheck.Progress;
                foreach (string temp in passwordCheck.LogOutput)
                {
                    listBoxLog.Items.Add(temp);
                }
                passwordCheck.LogOutput.Clear();
            }
        }
        private async void buttonCheckPassword_Click(object sender, EventArgs e)
        {
            string pathToFile = "";
            taskCurrentlyWorking = true;
            whatTaskIsWorking = 3;
            DisableUI();
            string messageBoxAnswer = "";
            bool continueToChecker = true;
            string[] passwords = textBoxDictionary.Lines;           
            //Decider of what txt to use
            if (radioButtonRockYouFull.Checked)
            {
                pathToFile = Settings.PasswordPathToFiles + "\\" + "rockyou.txt";
            }
            else if (radioButtonRockYouShort.Checked)
            {
                pathToFile = Settings.PasswordPathToFiles + "\\" + "rockyouShort.txt";
            }
            else if (radioButtonRockYouFullShortShort.Checked)
            {
                pathToFile = Settings.PasswordPathToFiles + "\\" + "rockyouVeryShort.txt";
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {                        
                        pathToFile = openFileDialog.FileName; //Own txt
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(Languages.Translate(277) + ": " + pathToFile);
                    }
                    else
                    {
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(Languages.Translate(278));
                        continueToChecker = false;
                    }
                }
            }
            if (continueToChecker)
            {
                Timer timer = new Timer();
                timer.Interval = Settings.UpdateUIms;
                timer.Tick += UpdateUIPassword;
                timer.Start();
                await Task.Run(() => { passwordCheck.PasswordFinder(pathToFile, passwords); });
                timer.Stop();
                timer.Dispose();
                UpdateUIPassword(sender, e);
                progressBar1.Value = 100;
                if (passwordCheck.Token)
                {
                    if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(Languages.Translate(279));
                    MessageBox.Show(Languages.Translate(279));
                }
                //Console.WriteLine("passwordCheck.FoundMatch[i]: " + passwordCheck.FoundMatch.Count);
                //Console.WriteLine("passwords count " + passwords.Count)
                for (int i = 0; i < passwords.Count(); i++)
                {
                    if (passwordCheck.FoundMatch[i])
                    {
                        string temp = Languages.Translate(280) + " '" + passwords[i] + "' " + Languages.Translate(281) + passwordCheck.LineFoundMatch[i] + ". " + Languages.Translate(282) + Environment.NewLine;
                        messageBoxAnswer += temp;
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(temp);
                    }
                    else
                    {
                        string temp = Languages.Translate(280) + "' " + passwords[i] + "' " + Languages.Translate(283) + Environment.NewLine;
                        messageBoxAnswer += temp;
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(temp);
                    }
                }
                MessageBox.Show(messageBoxAnswer);
            }
            taskCurrentlyWorking = false;
            whatTaskIsWorking = -1;
            ActivateUI();
        }                                 

        #endregion

        #region Password Strenght Calculator
        PasswordStrenghtCalculator passwordStrenghtCalculator = new PasswordStrenghtCalculator();        
        private void buttonCrackCalculate_Click(object sender, EventArgs e)
        {
            int numberOfChars = 0;
            if (checkBoxCrackLower.Checked) numberOfChars += 26;
            if (checkBoxCrackUpper.Checked) numberOfChars += 26;
            if (checkBoxCrackDigit.Checked) numberOfChars += 10;
            if (checkBoxCrackSpecial.Checked) numberOfChars += 33;

            int passwordLenght;
            if (!int.TryParse(textBoxCrackLenght.Text, out passwordLenght)) passwordLenght = textBoxCrackLenght.Text.Length;
            if (passwordLenght > 50)
            {
                passwordLenght = 50;
                MessageBox.Show(Languages.Translate(284));
                if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(Languages.Translate(285));
            }
            double speed = double.Parse(textBoxCrackSpeed.Text);

            double pocet = passwordStrenghtCalculator.Calculator(passwordLenght, numberOfChars, speed, out double rychlost);
            //Output
            if ((long)rychlost / 100 >= 315569260000) //31556926 == seconds in a year * 100 000 000
            {
                if (checkBoxShowLogCrack.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(286));
                    listBoxLog.Items.Add(Languages.Translate(287) + ": " + pocet.ToString("N0"));
                }
                MessageBox.Show(Languages.Translate(286) + "\n" + Languages.Translate(287) + ": " + pocet.ToString("N0")); //if it takes more than 1 bilion years
            }
            else
            {
                if (checkBoxShowLogCrack.Checked)
                {
                    listBoxLog.Items.Add(passwordStrenghtCalculator.Output(rychlost));
                    listBoxLog.Items.Add(Languages.Translate(287) + ": " + pocet.ToString("N0"));
                }
                MessageBox.Show(passwordStrenghtCalculator.Output(rychlost) + "\n" + Languages.Translate(287) + ": " + pocet.ToString("N0")); //N0 == Formats the number to have spaces between each thousand. (1 mil. == 1 000 000)
            }
        }
        #endregion

        #region Rainbow Table

        RainbowTable rainbowTable = new RainbowTable();
        private void buttonPreHash_Click(object sender, EventArgs e) //Dont Mind its called PreHash its Rainbow Table Generator
        {
            taskCurrentlyWorking = true;
            whatTaskIsWorking = 1;
            DisableUI();            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
            //Timer
            Timer updateUITimer = new Timer();
            updateUITimer.Interval = Settings.UpdateUIms;
            updateUITimer.Tick += UpdateUIRainbowTable;
            updateUITimer.Enabled = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "-" + rainbowTableAlgorithm.ToString() + ".txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt"; // Only allow .txt files

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    updateUITimer.Start();
                    //MultiThread
                    if (checkBoxPerformanceModeBruteForce.Checked && FormManagement.UseMultiThread())
                    {
                        int numberOfThreadsToUse = FormManagement.NumberOfThreadsToUse();
                        if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(10026) + ": "  + numberOfThreadsToUse);
                        if (rainbowTable.GenerateRainbowTableMultiThread(numberOfThreadsToUse, openFileDialog.FileName, saveFileDialog.FileName, rainbowTableAlgorithm))
                        {
                            updateUITimer.Stop();
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(Languages.Translate(288));
                        }
                        else
                        {
                            updateUITimer.Stop();
                            string s = Languages.Translate(289);
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(s);
                        }
                    }
                    //Single Thread
                    else
                    {
                        if (rainbowTable.GenerateRainbowTable(openFileDialog.FileName, saveFileDialog.FileName, rainbowTableAlgorithm))
                        {
                            updateUITimer.Stop();
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(Languages.Translate(288));
                        }
                        else
                        {
                            updateUITimer.Stop();
                            string s =Languages.Translate(289);
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(s);
                        }
                    }
                }
            }
            else
            {
                updateUITimer.Stop();
                MessageBox.Show(Languages.Translate(290));
                if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(290));
            }            
            ActivateUI(); 
            taskCurrentlyWorking = false;
            whatTaskIsWorking = -1;
        }

        private long numberOfAttemptsInLastUpdateRainbowTable = 0;
        private void UpdateUIRainbowTable(object sender, EventArgs e)
        {
            if (rainbowTable.Stopwatch != null)
            {
                if (rainbowTable.Stopwatch.ElapsedMilliseconds > 0 && rainbowTable.LinesProcessed > 0 && rainbowTable.AllLinesInInputFile > 0)
                {
                    double speed = (rainbowTable.LinesProcessed - numberOfAttemptsInLastUpdateRainbowTable) / (Settings.UpdateUIms / 1000);
                    int progress = (int)((double)rainbowTable.LinesProcessed / rainbowTable.AllLinesInInputFile * 100);
                    numberOfAttemptsInLastUpdateRainbowTable = rainbowTable.LinesProcessed;
                    labelStatTimer.Text = Languages.Translate(10009) + ": " + rainbowTable.Stopwatch.ElapsedMilliseconds / 1000 + "." + rainbowTable.Stopwatch.ElapsedMilliseconds % 1000;
                    labelStatSpeed.Text = Languages.Translate(10012) + " /s" + rainbowTable.LinesProcessed / (double)(rainbowTable.Stopwatch.ElapsedMilliseconds / 1000);
                    labelStatCurrentSpeed.Text = Languages.Translate(10011) + " /s: " + speed.ToString();
                    progressBar1.Value = Math.Min(100, progress);
                    //Refresh - The Labels didnt update for some reason
                    labelStatTimer.Refresh();
                    labelStatSpeed.Refresh();
                    labelStatCurrentSpeed.Refresh();
                }
            }
        }

        #endregion

        #region Rainbow Table Attack  - Done    
        RainbowTableAttack rainbowTableAttack = new RainbowTableAttack();
        private void buttonRainbowTableAttack_Click(object sender, EventArgs e)
        {
            Timer timeToUpdateUI = new Timer();
            timeToUpdateUI.Interval = Settings.UpdateUIms;
            timeToUpdateUI.Tick += (s, args) => UpdateTheUIRainbowTableAttack();
            TurnOffUI();
            taskCurrentlyWorking = true;
            whatTaskIsWorking = 2;

            string originalInput = textBoxBruteForce.Text;
            if (radioButtonRegularBruteForce.Checked)
                originalInput = hasher.Hash(originalInput, rainbowTableAlgorithm);

            rainbowTableAttack.PerformanceMode = checkBoxPerformanceModeBruteForce.Checked;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Settings.PasswordPathToFiles
            };

            rainbowTableAttack.UseStopTimer = numericUpDownStopTimer.Value != 0;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                timeToUpdateUI.Start();
                if (rainbowTableAttack.PerformRainbowAttack(openFileDialog.FileName, originalInput, rainbowTableAlgorithm, (long)numericUpDownStopTimer.Value, (long)numericUpDownMaxAttempts.Value))
                {
                    if (checkBoxShowLogRainbowTable.Checked)
                        listBoxLog.Items.Add("-----------------------------------------------");

                    if (!string.IsNullOrEmpty(rainbowTableAttack.FoundPassword))
                    {
                        string foundPassword = rainbowTableAttack.FoundPassword;
                        string foundPasswordHash = hasher.Hash(foundPassword, rainbowTableAlgorithm);
                        long foundAtLine = rainbowTableAttack.FoundPasswordAtLine + 1;

                        string message = Languages.Translate(291) + "\n" +
                                Languages.Translate(292) + ": " + foundPassword + "\n" +
                                Languages.Translate(293) + ": " + originalInput + "\n" +
                                Languages.Translate(294) + ": " + foundAtLine + "\n" +
                                Languages.Translate(295) + ": " + foundPasswordHash + "\n" +
                                Languages.Translate(296) + ": " + foundPassword + "\n" +
                                Languages.Translate(297) + ": " + ConvertToHexBasedOnUser(foundPassword);


                        if (checkBoxShowLogRainbowTable.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(291)); 
                            listBoxLog.Items.Add(Languages.Translate(292) + ": " + foundPassword); 
                            listBoxLog.Items.Add(Languages.Translate(295) + ": " + originalInput); 
                            listBoxLog.Items.Add(Languages.Translate(294) + ": " + foundAtLine); 
                            listBoxLog.Items.Add(Languages.Translate(296) + ": " + foundPassword);
                            listBoxLog.Items.Add(Languages.Translate(297) + ": " + ConvertToHexBasedOnUser(foundPassword));
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                        PasswordFoundMessageBox(message, originalInput, foundPassword);
                    }
                    else if (rainbowTableAttack.CancelTokenActive())
                    {
                        MessageBox.Show(Languages.Translate(279));
                        if (checkBoxShowLogRainbowTable.Checked)
                            listBoxLog.Items.Add(Languages.Translate(279));
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else if (rainbowTableAttack.RanOutOfTime)
                    {
                        MessageBox.Show(Languages.Translate(298));
                        if (checkBoxShowLogRainbowTable.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(298));
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else if (rainbowTableAttack.RanOutOfAttempts)
                    {
                        MessageBox.Show(Languages.Translate(299));
                        if (checkBoxShowLogRainbowTable.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(299));
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else
                    {
                        MessageBox.Show(Languages.Translate(300));
                        if (checkBoxShowLogRainbowTable.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(300));
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                }
                else
                {
                    MessageBox.Show(Languages.Translate(301));
                    if (checkBoxShowLogRainbowTable.Checked)
                        listBoxLog.Items.Add(Languages.Translate(301));
                    if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                }
            }
            else
            {
                if (checkBoxShowLogRainbowTable.Checked)
                    listBoxLog.Items.Add(Languages.Translate(302));
                if (timeToUpdateUI != null) timeToUpdateUI.Stop();
            }
            if (timeToUpdateUI != null) timeToUpdateUI.Stop();
            TurnOnUI();
            taskCurrentlyWorking = false;
            whatTaskIsWorking = -1;
        }

        // Tracking the last update count for UI updates
        long RainbowAttacknumberOfLinesInLastUpdate = 0;

        private void UpdateTheUIRainbowTableAttack()
        {
            int seconds = (int)(rainbowTableAttack.Stopwatch.ElapsedMilliseconds / 1000);
            int milliseconds = (int)(rainbowTableAttack.Stopwatch.ElapsedMilliseconds % 1000);

            long currentLinesProcessed = rainbowTableAttack.LinesProcessed;
            int triesBetween = (int)(currentLinesProcessed - RainbowAttacknumberOfLinesInLastUpdate);
            RainbowAttacknumberOfLinesInLastUpdate = currentLinesProcessed;

            // Speed Calculation
            double speed = triesBetween / (Settings.UpdateUIms / 1000);
            labelStatCurrentSpeed.Text = Languages.Translate(10001) + "/s: " + speed.ToString("#,0");

            // Attempts Display
            labelStatAttempts.Text = Languages.Translate(303) + ": " + currentLinesProcessed.ToString("#,0");

            // Average Speed Calculation
            double averageSpeed = (rainbowTableAttack.Stopwatch.ElapsedMilliseconds > 0)
                ? currentLinesProcessed / (rainbowTableAttack.Stopwatch.ElapsedMilliseconds / 1000.0)
                : 0;
            labelStatSpeed.Text = Languages.Translate(10012) + "/s: " + Math.Floor(averageSpeed).ToString("#,0");

            // Progress Bar Update
            int progress = (int)((double)currentLinesProcessed / rainbowTableAttack.TotalLinesInFile * 100);
            progressBar1.Value = Math.Max(0, Math.Min(progress, 100));  // Ensure value is between 0-100

            // Logging
            if (rainbowTableAttack.LogOutput != null)
            {
                foreach (string logEntry in rainbowTableAttack.LogOutput)
                    listBoxLog.Items.Add(logEntry);

                rainbowTableAttack.LogReset(); // Clear logs after adding them
            }
        }

        #endregion

        #region Password BruteForce Attack - Done

        BruteForceAttack bruteForce = new BruteForceAttack();
        private async void buttonBruteForceAttack_Click(object sender, EventArgs e)
        {
            taskCurrentlyWorking = true;
            whatTaskIsWorking = 4;
            TurnOffUI();
            string userHashInput = textBoxBruteForce.Text;
            int userPasswordLenght = 0;
            if (radioButtonRegularBruteForce.Checked)
            {
                userPasswordLenght = textBoxBruteForce.Text.Length;
                userHashInput = hasher.Hash(textBoxBruteForce.Text, bruteForceAlgorithm);
                if (checkBoxShowLogBrute.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(0) + " '" + textBoxBruteForce.Text + "' " + Languages.Translate(10027) + " " + userHashInput + ".");
                }
            }
            else
            {
                userPasswordLenght = (int)numericUpDownLenght.Value;
            }
            if (checkBoxUnknownLenghtBruteForce.Checked) userPasswordLenght = 0;

            //SetUp            
            bool[] checkBoxUsableCharsForAttack = { false, false, false, false };
            //AllUsableChars Based on Input
            bruteForce.SelectAllUsableChars(
                 checkBoxLowerCase.Checked,
                 checkBoxUpperCase.Checked,
                 checkBoxDigits.Checked,
                 checkBoxSpecialChars.Checked
             );


            //timer
            Timer timer = new Timer();
            timer.Interval = Settings.UpdateUIms;
            timer.Tick += UpdateTheUIBruteForceAttack;            
            //Task Set Up                
            List<Task> allTasks = new List<Task>();
            //Console.WriteLine("UserPasswordLenght: " + userPasswordLenght);
            long temp = bruteForce.CalculateAllPossibleCombinations(checkBoxUnknownLenghtBruteForce.Checked, (int)numericUpDownLenght.Value);
            if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add(Languages.Translate(304) + ": " + temp);
            if (checkBoxPerformanceModeBruteForce.Checked && FormManagement.UseMultiThread())
            {
                timer.Start();
                Console.WriteLine(Languages.Translate(305));
                bruteForce.BruteForceAttackMultiThread(bruteForceAlgorithm, userHashInput, (ulong)numericUpDownMaxAttempts.Value, userPasswordLenght, (long)numericUpDownStopTimer.Value);
            }
            else //single Thread
            {
                Console.WriteLine(Languages.Translate(306));
                timer.Start();
                await Task.Run(() => bruteForce.PasswordBruteForce
                (
                    bruteForceAlgorithm, //algorithm
                    false, //useMultiThreading
                    0, //ThreadID
                    1, //numberOfThreadsUsed
                    userHashInput,
                    (ulong)numericUpDownMaxAttempts.Value, 
                    userPasswordLenght,
                     (long)numericUpDownStopTimer.Value));
            }
            timer.Stop();
            timer.Dispose();
            UpdateTheUIBruteForceAttack(sender, e); //last update                                                    
            //Output
            if (bruteForce.FoundPasswordBool)
            {
                string message = Languages.Translate(307) + "\n" + 
                          "\n" + Languages.Translate(308) + ": " + userHashInput + 
                          "\n" + Languages.Translate(309) + ": " + hasher.Hash(bruteForce.FoundPassword, bruteForceAlgorithm) +
                          "\n" + Languages.Translate(310) + ": " + bruteForce.FoundPassword +
                          "\n" + Languages.Translate(311) + ": " + ConvertToHexBasedOnUser(bruteForce.FoundPassword) + 
                          "\n" + Languages.Translate(120) + ": " + bruteForce.Attempts +
                          "\n" + Languages.Translate(10009) + ": " + labelStatTimer.Text +
                          "\n" + Languages.Translate(10012) + ": " + labelStatSpeed.Text;

                if (checkBoxShowLogBrute.Checked)
                {
                    listBoxLog.Items.Add("----------------------------");
                    listBoxLog.Items.Add(Languages.Translate(307));
                    listBoxLog.Items.Add(Languages.Translate(308) + ": " + userHashInput);
                    listBoxLog.Items.Add(Languages.Translate(309) + ": " + hasher.Hash(bruteForce.FoundPassword, bruteForceAlgorithm));
                    listBoxLog.Items.Add(Languages.Translate(310) + ": " + bruteForce.FoundPassword);
                    listBoxLog.Items.Add(Languages.Translate(311) + ": " + ConvertToHexBasedOnUser(bruteForce.FoundPassword));
                    listBoxLog.Items.Add(Languages.Translate(120) + ": " + bruteForce.Attempts);
                    listBoxLog.Items.Add(Languages.Translate(10009) + ": " + labelStatTimer.Text.Split(' ')[1]);
                    listBoxLog.Items.Add(Languages.Translate(10012) + ": " + labelStatSpeed.Text);
                }
                PasswordFoundMessageBox(message, userHashInput, bruteForce.FoundPassword);
            }
            else if (bruteForce.RanOutOfAttemps)
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add(Languages.Translate(312));
                MessageBox.Show(Languages.Translate(312), Languages.Translate(10019), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (bruteForce.RanOutOfTime)
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add(Languages.Translate(312));
                MessageBox.Show(Languages.Translate(312), Languages.Translate(10019), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (bruteForce.UserAborted)
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add(Languages.Translate(10017));
                MessageBox.Show(Languages.Translate(10017), Languages.Translate(10019), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add(Languages.Translate(313));
                MessageBox.Show(Languages.Translate(313));
            }
            taskCurrentlyWorking = true;
            whatTaskIsWorking = -1;
            TurnOnUI();
        }
        private long numberOfAttemptsInLastUpdateBruteForce = 0;
        private void UpdateTheUIBruteForceAttack(object sender, EventArgs e)
        {
            //Update Timer
            //Console.WriteLine("UpdateTheUIBruteForceAttack");
            int seconds = (int)(bruteForce.Stopwatch.ElapsedMilliseconds / 1000);
            int milliseconds = (int)(bruteForce.Stopwatch.ElapsedMilliseconds % 1000);
            labelStatTimer.Text = Languages.Translate(10009) + ": " + seconds + "." + milliseconds + " s";
            int triesBetween = (int)(bruteForce.Attempts - numberOfAttemptsInLastUpdateBruteForce);
            numberOfAttemptsInLastUpdateBruteForce = bruteForce.Attempts;
            //Update Speed
            double speed = triesBetween / (Settings.UpdateUIms / 1000);
            labelStatCurrentSpeed.Text = Languages.Translate(10011) + " /s:  " + speed.ToString("#,0");
            //Attempts
            labelStatAttempts.Text = Languages.Translate(10010) + ": " + bruteForce.Attempts.ToString("#,0");
            //Update Average Speed
            double averageSpeed = 0;
            if (bruteForce.Stopwatch.ElapsedMilliseconds != 0) averageSpeed = bruteForce.Attempts / (bruteForce.Stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second            
            labelStatSpeed.Text = Languages.Translate(10012) + " /s: " + Math.Floor(averageSpeed).ToString("#,0");
            //update progressbar
            progressBar1.Value = bruteForce.Progress;
        }       
        #endregion

        private void TurnOffUI()
        {
            foreach (Control control in this.Controls)
            {
                if (control is Button) control.Enabled = false;
                else if (control is GroupBox box)
                {
                    foreach (Control child in box.Controls)
                    {
                        if (child is Button) child.Enabled = false;
                    }
                }
            }
            progressBar1.Value = 0;
            progressBar1.Enabled = true;
            buttonCancel.Enabled = true;
        }
        private void TurnOnUI()
        {
            foreach (Control control in this.Controls)
            {
                control.Enabled = true;
                if (control is GroupBox box)
                {
                    foreach(Control child in box.Controls)
                    {
                        child.Enabled = true;
                    }
                }
            }
            progressBar1.Value = 0;
        }
        private string ConvertToHexBasedOnUser(string text)
        {
            if (checkBoxHexOutputBruteForce.Checked)
            {
                var hexBuilder = new StringBuilder();
                for (int i = 0; i < text.Length; i++)
                {
                    hexBuilder.AppendFormat("{0:X2}", (int)text[i]);
                    if (i < text.Length - 1)
                    {
                        hexBuilder.Append('-');
                    }
                }
                return hexBuilder.ToString();
            }
            else { return text; }
        }
        public void PasswordFoundMessageBox(string message, string inputHash, string password)
        {            
            if (MessageBox.Show(Languages.Translate(314), Languages.Translate(46), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string path = Path.GetFullPath(Settings.PasswordPathToFiles);
                string path2 = "";
                bool foundName = false;
                int number = 1;
                //Finding name
                while (!foundName)
                {
                    if (!File.Exists(path + "JailbreakPassword (" + bruteForceAlgorithm.ToString() + ")-" + number + ".txt"))
                    {
                        foundName = true;
                        path2 = bruteForceAlgorithm.ToString() + "-" + number + ".txt";
                    }
                    else number++;
                }
                //Writing Results
                using (StreamWriter writer = new StreamWriter(path + path2))
                {
                    writer.WriteLine("Algorithm=" + bruteForceAlgorithm.ToString());
                    writer.WriteLine("<HASH>");
                    writer.WriteLine("Input hash: " + inputHash);
                    writer.WriteLine("Found hash: " + hasher.Hash(password, bruteForceAlgorithm));
                    writer.WriteLine("Password UTF-8: " + password);
                    writer.WriteLine("Password HEX:  " + ConvertToHexBasedOnUser(password));
                }
            }
            MessageBox.Show(message, Languages.Translate(117), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (taskCurrentlyWorking)
            {
                switch(whatTaskIsWorking)
                {
                    case 1: rainbowTable.Abort(); break;
                    case 2: rainbowTableAttack.Abort(); break;
                    case 3: passwordCheck.Abort(); break;
                    case 4: bruteForce.Abort(); break;
                    default: MessageBox.Show(Languages.Translate(315), Languages.Translate(20), MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                }
            }
        }

        private void textBoxBruteForceInput_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonRegularBruteForce.Checked)
            {
                numericUpDownLenght.Value = textBoxBruteForce.Text.Length;
                checkBoxUnknownLenghtBruteForce.Checked = false;
            }
            else if (radioButtonBruteForceHashed.Checked)
            {
                checkBoxUnknownLenghtBruteForce.Checked = true;
            }
        }

        private void radioButton6_EnabledChanged(object sender, EventArgs e)
        {
            if (radioButtonBruteForceHashed.Checked)
            {
                checkBoxUnknownLenghtBruteForce.Checked = true;
                numericUpDownLenght.Value = 0;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRegularBruteForce.Checked)
            {
                checkBoxUnknownLenghtBruteForce.Checked = false;
                numericUpDownLenght.Value = textBoxBruteForce.Text.Length;
            }
        }

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show(Languages.Translate(10023), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void hashSelectorRainbowTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            rainbowTableAlgorithm = (Hasher.HashingAlgorithm)hashSelectorRainbowTable.SelectedIndex;
        }
    }
}

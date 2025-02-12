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
        Hasher.HashingAlgorithm userAlgorithm = new Hasher.HashingAlgorithm();
        Hasher hasher = new Hasher();
        //Password Dictionary Attack and Bruteforce Attack

        #region FormManagement
        private void PasswordForm_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
            hashSelector.SelectedIndex = 0;
            if (!FindIfTXTIsPresent("_wordlistInfo")) GenerateInfoTXT();
            DisableRockYouRadioButtons();
            if (FindIfTXTIsPresent("rockyou")) radioButton1.Enabled = true;
            if (FindIfTXTIsPresent("rockyouShort")) radioButton2.Enabled = true;
            if (FindIfTXTIsPresent("rockyouVeryShort")) radioButton3.Enabled = true;
            //checked
            if (radioButton1.Enabled) radioButton1.Checked = true;
            else if (radioButton2.Enabled) radioButton2.Checked = true;
            else if (radioButton3.Enabled) radioButton3.Checked = true;
            else radioButton4.Checked = true;
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            userAlgorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void DisableRockYouRadioButtons()
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
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
            string s = "RockYou has 10mil. passwords (original has like 14 mil but Github didnt like that)\r\nRockYouShort has 1mil.\r\nRockYouVeryShort 5k\r\nIf you want to add more or something different you can";
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
                labelTimer.Text = "Timer: " + (passwordCheck.Stopwatch.ElapsedMilliseconds / 1000 + "." + passwordCheck.Stopwatch.ElapsedMilliseconds % 1000);
                double currentSpeed = passwordLinesProcessedBetweenUpdates / (Settings.UpdateUIms / 1000);
                labelCurrentSpeed.Text = "Current speed /s: " + currentSpeed.ToString("#,0");
                double averageSpeed = passwordCheck.CurrentLine / (passwordCheck.Stopwatch.ElapsedMilliseconds / 1000.0); //in seconds
                if (!double.IsInfinity(averageSpeed)) labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed).ToString("#,0");
                else labelSpeed.Text = "Average speed /s: Yes";
                labelAttempts.Text = "Currently working on line: " + passwordCheck.CurrentLine.ToString("#,0");
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
            string[] passwords = textBox1.Lines;           
            //Decider of what txt to use
            if (radioButton1.Checked)
            {
                pathToFile = Settings.PasswordPathToFiles + "\\" + "rockyou.txt";
            }
            else if (radioButton2.Checked)
            {
                pathToFile = Settings.PasswordPathToFiles + "\\" + "rockyouShort.txt";
            }
            else if (radioButton3.Checked)
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
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Path to wordlist: " + pathToFile);
                    }
                    else
                    {
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("No path selected, cancelling process.");
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
                    if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("The User has aborted the process.");
                    MessageBox.Show("The User has aborted the process.");
                }
                //Console.WriteLine("passwordCheck.FoundMatch[i]: " + passwordCheck.FoundMatch.Count);
                //Console.WriteLine("passwords count " + passwords.Count)
                for (int i = 0; i < passwords.Count(); i++)
                {
                    if (passwordCheck.FoundMatch[i])
                    {
                        messageBoxAnswer += "Password '" + passwords[i] + "' has been found in wordlist at line " + passwordCheck.LineFoundMatch[i] + ". I recommend using a different password." + Environment.NewLine;
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Password '" + passwords[i] + "' has been found in wordlist at line " + passwordCheck.LineFoundMatch[i] + ". I recommend using a different password.");
                    }
                    else
                    {
                        messageBoxAnswer += "Password '" + passwords[i] + "' has not been found in wordlist. Good Job." + Environment.NewLine;
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Password '" + passwords[i] + "' has not been found in wordlist. Good Job." + Environment.NewLine);
                    }
                }
                MessageBox.Show(messageBoxAnswer);
            }
            taskCurrentlyWorking = false;
            whatTaskIsWorking = -1;
            ActivateUI();
        }                                 

        #endregion

        #region Password Strenght Calculator - Done
        PasswordStrenghtCalculator passwordStrenghtCalculator = new PasswordStrenghtCalculator();        
        private void buttonCrackCalculate_Click(object sender, EventArgs e)
        {
            int numberOfChars = 0;
            if (checkBoxCrack01.Checked) numberOfChars += 26;
            if (checkBoxCrack02.Checked) numberOfChars += 26;
            if (checkBoxCrack03.Checked) numberOfChars += 10;
            if (checkBoxCrack04.Checked) numberOfChars += 33;

            int passwordLenght;
            if (!int.TryParse(textBoxCrackLenght.Text, out passwordLenght)) passwordLenght = textBoxCrackLenght.Text.Length;
            if (passwordLenght > 50)
            {
                passwordLenght = 50;
                MessageBox.Show("Maximální délka hesla je 50.");
                if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Maximum lenght of the password set to 50.");
            }
            double speed = double.Parse(textBoxCrackSpeed.Text);

            double pocet = passwordStrenghtCalculator.Calculator(passwordLenght, numberOfChars, speed, out double rychlost);
            //Output
            if ((long)rychlost / 100 >= 315569260000) //31556926 == seconds in a year * 100 000 000
            {
                if (checkBoxShowLogCrack.Checked)
                {
                    listBoxLog.Items.Add("Prolomit toto heslo bude trvat přes 1 miliardu let.");
                    listBoxLog.Items.Add("Pocet kombinací: " + pocet.ToString("N0"));
                }
                MessageBox.Show("Prolomit toto heslo bude trvat přes 1 miliardu let :)\nPocet kombinací: " + pocet.ToString("N0")); //if it takes more than 1 bilion years
            }
            else
            {
                if (checkBoxShowLogCrack.Checked)
                {
                    listBoxLog.Items.Add(passwordStrenghtCalculator.Output(rychlost));
                    listBoxLog.Items.Add("Pocet kombinaci: " + pocet.ToString("N0"));
                }
                MessageBox.Show(passwordStrenghtCalculator.Output(rychlost) + "\nPocet kombinaci: " + pocet.ToString("N0")); //N0 == Formats the number to have spaces between each thousand. (1 mil. == 1 000 000)
            }
        }
        #endregion

        #region Rainbow Table - Done

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
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "-" + userAlgorithm.ToString() + ".txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt"; // Only allow .txt files

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //MultiThread
                    updateUITimer.Start();                    
                    if (checkBoxPerformanceMode.Checked && FormManagement.UseMultiThread())
                    {
                        int numberOfThreadsToUse = FormManagement.NumberOfThreadsToUse();
                        if (checkBoxShowLogPreHash.Checked) listBoxLog.Items.Add("Number of threads used: "  + numberOfThreadsToUse);
                        if (rainbowTable.GenerateRainbowTableMultiThread(numberOfThreadsToUse, openFileDialog.FileName, saveFileDialog.FileName, userAlgorithm))
                        {
                            updateUITimer.Stop();
                            if (checkBoxShowLogPreHash.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show("Rainbow Table has been generated succesfully.");
                        }
                        else
                        {
                            updateUITimer.Stop();
                            string s = "Program could not generate the rainbow table. Abbandoning process.";
                            if (checkBoxShowLogPreHash.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(s);
                        }
                    }
                    //Single Thread
                    else
                    {
                        if (rainbowTable.GenerateRainbowTable(openFileDialog.FileName, saveFileDialog.FileName, userAlgorithm))
                        {
                            updateUITimer.Stop();
                            if (checkBoxShowLogPreHash.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show("Rainbow Table has been generated succesfully.");
                        }
                        else
                        {
                            updateUITimer.Stop();
                            string s = "Program could not generate the rainbow table. Abbandoning process.";
                            if (checkBoxShowLogPreHash.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(s);
                        }
                    }
                }
            }
            else
            {
                updateUITimer.Stop();
                MessageBox.Show("Rainbow Table Generator abandoned.");
                if (checkBoxShowLogPreHash.Checked) listBoxLog.Items.Add("Rainbow Table Generator abandoned.");
            }            
            ActivateUI(); 
            taskCurrentlyWorking = false;
            whatTaskIsWorking = -1;
        }

        private long numberOfAttemptsInLastUpdateRainbowTable = 0;
        private void UpdateUIRainbowTable(object sender, EventArgs e)
        {
            if (rainbowTable.Stopwatch.ElapsedMilliseconds > 0 && rainbowTable.LinesProcessed > 0 && rainbowTable.AllLinesInInputFile > 0)
            {       
                double speed = (rainbowTable.LinesProcessed - numberOfAttemptsInLastUpdateRainbowTable) / (Settings.UpdateUIms / 1000);
                int progress = (int)((double)rainbowTable.LinesProcessed / rainbowTable.AllLinesInInputFile * 100);
                numberOfAttemptsInLastUpdateRainbowTable = rainbowTable.LinesProcessed;
                labelTimer.Text = "Timer: " + rainbowTable.Stopwatch.ElapsedMilliseconds / 1000 + "." + rainbowTable.Stopwatch.ElapsedMilliseconds % 1000;
                labelSpeed.Text = "Average speed /s: " + rainbowTable.LinesProcessed / (double)(rainbowTable.Stopwatch.ElapsedMilliseconds / 1000);
                labelCurrentSpeed.Text = "Hashes /s: " + speed.ToString();
                progressBar1.Value = Math.Min(100, progress);
                //Refresh - The Labels didnt update for some reason
                labelTimer.Refresh();
                labelSpeed.Refresh();
                labelCurrentSpeed.Refresh();
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

            string originalInput = textBoxBruteForceInput.Text;
            if (radioButton5.Checked)
                originalInput = hasher.Hash(originalInput, userAlgorithm);

            rainbowTableAttack.PerformanceMode = checkBoxPerformanceMode.Checked;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Settings.PasswordPathToFiles
            };

            rainbowTableAttack.UseStopTimer = numericUpDownStopTimer.Value != 0;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                timeToUpdateUI.Start();
                if (rainbowTableAttack.PerformRainbowAttack(openFileDialog.FileName, originalInput, userAlgorithm, (long)numericUpDownStopTimer.Value, (long)numericUpDown1.Value))
                {
                    if (checkBoxShowLogDictionary.Checked)
                        listBoxLog.Items.Add("-----------------------------------------------");

                    if (!string.IsNullOrEmpty(rainbowTableAttack.FoundPassword))
                    {
                        string foundPassword = rainbowTableAttack.FoundPassword;
                        string foundPasswordHash = hasher.Hash(foundPassword, userAlgorithm);
                        long foundAtLine = rainbowTableAttack.FoundPasswordAtLine + 1;

                        string message = $"Found hash via Dictionary attack\n" +
                                            $"Original password: {foundPassword}\n" +
                                            $"Original password hash: {originalInput}\n" +
                                            $"Found password at line: {foundAtLine}\n" +
                                            $"Found password hash: {foundPasswordHash}\n" +
                                            $"Found password in UTF-8: {foundPassword}\n" +
                                            $"Found password in HEX: {ConvertToHexBasedOnUser(foundPassword)}";

                        if (checkBoxShowLogDictionary.Checked)
                        {
                            listBoxLog.Items.Add("Found hash via Dictionary attack");
                            listBoxLog.Items.Add($"Original password: {foundPassword}");
                            listBoxLog.Items.Add($"Found password hash: {originalInput}");
                            listBoxLog.Items.Add($"Found password at line: {foundAtLine}");
                            listBoxLog.Items.Add($"Found password in UTF-8: {foundPassword}");
                            listBoxLog.Items.Add($"Found password in HEX: {ConvertToHexBasedOnUser(foundPassword)}");
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                        PasswordFoundMessageBox(message, originalInput, foundPassword);
                    }
                    else if (rainbowTableAttack.CancelTokenActive())
                    {
                        MessageBox.Show("The user has aborted the process.");
                        if (checkBoxShowLogDictionary.Checked)
                            listBoxLog.Items.Add("The user has aborted the process.");
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else if (rainbowTableAttack.RanOutOfTime)
                    {
                        MessageBox.Show("The program could not find the password within the time limit.");
                        if (checkBoxShowLogDictionary.Checked)
                        {
                            listBoxLog.Items.Add("The program could not find the password within the time limit.");
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else if (rainbowTableAttack.RanOutOfAttempts)
                    {
                        MessageBox.Show("The program could not find the password within the attempt limit.");
                        if (checkBoxShowLogDictionary.Checked)
                        {
                            listBoxLog.Items.Add("The program could not find the password within the attempt limit.");
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else
                    {
                        MessageBox.Show("Could not find password in the file.");
                        if (checkBoxShowLogDictionary.Checked)
                        {
                            listBoxLog.Items.Add("Could not find password in the file.");
                        }
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                }
                else
                {
                    MessageBox.Show("Could not run the dictionary attack.");
                    if (checkBoxShowLogDictionary.Checked)
                        listBoxLog.Items.Add("Could not run the dictionary attack.");
                    if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                }
            }
            else
            {
                if (checkBoxShowLogDictionary.Checked)
                    listBoxLog.Items.Add("Invalid file format or file not found. Cancelling dictionary attack.");
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
            labelCurrentSpeed.Text = "Current speed /s: " + speed.ToString("#,0");

            // Attempts Display
            labelAttempts.Text = "Number of lines processed: " + currentLinesProcessed.ToString("#,0");

            // Average Speed Calculation
            double averageSpeed = (rainbowTableAttack.Stopwatch.ElapsedMilliseconds > 0)
                ? currentLinesProcessed / (rainbowTableAttack.Stopwatch.ElapsedMilliseconds / 1000.0)
                : 0;
            labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed).ToString("#,0");

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
            string userHashInput = textBoxBruteForceInput.Text;
            int userPasswordLenght = 0;
            if (radioButton5.Checked)
            {
                userPasswordLenght = textBoxBruteForceInput.Text.Length;
                userHashInput = hasher.Hash(textBoxBruteForceInput.Text, userAlgorithm);
                if (checkBoxShowLogBrute.Checked)
                {
                    listBoxLog.Items.Add("Hashing '" + textBoxBruteForceInput.Text + "' into " + userHashInput + ".");
                }
            }
            else
            {
                userPasswordLenght = (int)numericUpDown2.Value;
            }
            if (checkBoxBruteForceUnknownLenght.Checked) userPasswordLenght = 0;

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
            Console.WriteLine("UserPasswordLenght: " + userPasswordLenght);
            long temp = bruteForce.CalculateAllPossibleCombinations(checkBoxBruteForceUnknownLenght.Checked, (int)numericUpDown2.Value);
            if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add("Number Of All Possible Combinations: " + temp);
            if (checkBoxPerformanceMode.Checked && FormManagement.UseMultiThread())
            {
                timer.Start();
                Console.WriteLine("Performance Mode On");
                bruteForce.BruteForceAttackMultiThread(userAlgorithm, userHashInput, (ulong)numericUpDown1.Value, userPasswordLenght, (long)numericUpDownStopTimer.Value);
            }
            else //single Thread
            {
                Console.WriteLine("Performance Mode Off");
                timer.Start();
                await Task.Run(() => bruteForce.PasswordBruteForce
                (
                    userAlgorithm, //algorithm
                    false, //useMultiThreading
                    0, //ThreadID
                    1, //numberOfThreadsUsed
                    userHashInput,
                    (ulong)numericUpDown1.Value, 
                    userPasswordLenght,
                     (long)numericUpDownStopTimer.Value));
            }
            timer.Stop();
            timer.Dispose();
            UpdateTheUIBruteForceAttack(sender, e); //last update                                                    
            //Output
            if (bruteForce.FoundPasswordBool)
            {
                string message = "Password found!\n" +
                  "\nOriginal hash: " + userHashInput +
                  "\nFound password hash: " + hasher.Hash(bruteForce.FoundPassword, userAlgorithm) +
                  "\nFound password in UTF-8: " + bruteForce.FoundPassword +
                  "\nFound password in HEX: " + ConvertToHexBasedOnUser(bruteForce.FoundPassword) +
                  "\nAttempts: " + bruteForce.Attempts +
                  "\n" + labelTimer.Text + // Timer
                  "\n" + labelSpeed.Text;  //Speed

                if (checkBoxShowLogBrute.Checked)
                {
                    listBoxLog.Items.Add("----------------------------");
                    listBoxLog.Items.Add("Password found!");
                    listBoxLog.Items.Add("Original hash: " + userHashInput);
                    listBoxLog.Items.Add("Found password hash: " + hasher.Hash(bruteForce.FoundPassword, userAlgorithm));
                    listBoxLog.Items.Add("Found password in UTF-8: " + bruteForce.FoundPassword);
                    listBoxLog.Items.Add("Found password in HEX: " + ConvertToHexBasedOnUser(bruteForce.FoundPassword));
                    listBoxLog.Items.Add("Attempts: " + bruteForce.Attempts);
                    listBoxLog.Items.Add("Time to find: " + labelTimer.Text.Split(' ')[1]);
                    listBoxLog.Items.Add("Average speed: " + labelSpeed.Text);
                }
                PasswordFoundMessageBox(message, userHashInput, bruteForce.FoundPassword);
            }
            else if (bruteForce.RanOutOfAttemps)
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add("Could not find a password under the given attempts.");
                MessageBox.Show("Could not find a password under the given attempts.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (bruteForce.RanOutOfTime)
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add("Could not find a password under the given time limit.");
                MessageBox.Show("Could not find a password under the given time limit.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (bruteForce.UserAborted)
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add("The process has been abandoned.");
                MessageBox.Show("The process has been abandoned.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add("Could not find the original password.");
                MessageBox.Show("Could not find the original password.");
            }
            taskCurrentlyWorking = true;
            whatTaskIsWorking = -1;
            TurnOnUI();
        }
        private long numberOfAttemptsInLastUpdateBruteForce = 0;
        private void UpdateTheUIBruteForceAttack(object sender, EventArgs e)
        {
            //Update Timer
            Console.WriteLine("UpdateTheUIBruteForceAttack");
            int seconds = (int)(bruteForce.Stopwatch.ElapsedMilliseconds / 1000);
            int milliseconds = (int)(bruteForce.Stopwatch.ElapsedMilliseconds % 1000);
            labelTimer.Text = "Timer: " + seconds + "." + milliseconds + " s";
            int triesBetween = (int)(bruteForce.Attempts - numberOfAttemptsInLastUpdateBruteForce);
            numberOfAttemptsInLastUpdateBruteForce = bruteForce.Attempts;
            //Update Speed
            double speed = triesBetween / (Settings.UpdateUIms / 1000);
            labelCurrentSpeed.Text = "Current speed /s:  " + speed.ToString("#,0");
            //Attempts
            labelAttempts.Text = "Number of attempts: " + bruteForce.Attempts.ToString("#,0");
            //Update Average Speed
            double averageSpeed = 0;
            if (bruteForce.Stopwatch.ElapsedMilliseconds != 0) averageSpeed = bruteForce.Attempts / (bruteForce.Stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second            
            labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed).ToString("#,0");
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
            if (checkBoxHexOutput.Checked)
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
            ConfirmationForm confirmation = new ConfirmationForm("Would you like to save found password to a txt file?");
            if (confirmation.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(Settings.PasswordPathToFiles);
                string path2 = "";
                bool foundName = false;
                int number = 1;
                //Finding name
                while (!foundName)
                {
                    if (!File.Exists(path + "JailbreakPassword (" + userAlgorithm.ToString() + ")-" + number + ".txt"))
                    {
                        foundName = true;
                        path2 = userAlgorithm.ToString() + "-" + number + ".txt";
                    }
                    else number++;
                }
                //Writing Results
                using (StreamWriter writer = new StreamWriter(path + path2))
                {
                    writer.WriteLine("Algorithm=" + userAlgorithm.ToString());
                    writer.WriteLine("<HASH>");
                    writer.WriteLine("Input hash: " + inputHash);
                    writer.WriteLine("Found hash: " + hasher.Hash(password, userAlgorithm));
                    writer.WriteLine("Password UTF-8: " + password);
                    writer.WriteLine("Password HEX:  " + ConvertToHexBasedOnUser(password));
                }
            }
            MessageBox.Show(message, "Collision Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    default: MessageBox.Show("Error, could not stop the process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); break;
                }
            }
        }

        private void textBoxBruteForceInput_TextChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                numericUpDown2.Value = textBoxBruteForceInput.Text.Length;
                checkBoxBruteForceUnknownLenght.Checked = false;
            }
            else if (radioButton6.Checked)
            {
                checkBoxBruteForceUnknownLenght.Checked = true;
            }
        }

        private void radioButton6_EnabledChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                checkBoxBruteForceUnknownLenght.Checked = true;
                numericUpDown2.Value = 0;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                checkBoxBruteForceUnknownLenght.Checked = false;
                numericUpDown2.Value = textBoxBruteForceInput.Text.Length;
            }
        }

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show("Please select an item from the log listbox before copying.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show("Failed to copy to clipboard.", "Clipboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

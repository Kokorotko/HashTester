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
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        CancellationToken token;
        private readonly int maximumLenghtForBruteForce = 15;
        private volatile bool userAbortProcess = false;
        private volatile bool ranOutOfAttemps = false;
        Stopwatch stopwatch = new Stopwatch();
        //Password Dictionary Attack and Bruteforce Attack
        Timer timeToUpdateTheUI = new Timer();
        private static ulong maxAttempts = 0;
        private static long attempts = 0;
        private long numberOfAttempsInLastUpdate = 0; //The time is 16ms
        ulong numberOfAllPossibleCombinations = 0;
        bool useStopTimer = true;
        private volatile bool ranOutOfTime = false;

        #region FormManagement
        private void PasswordForm_Load(object sender, EventArgs e)
        {
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
                Settings.PasswordPathToFiles = dialog.SelectedPath;
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

        #region Password Leak Test
        PasswordLeak passwordLeak = new PasswordLeak();
        private void UpdateUIPassword()
        {
            labelTimer.Text = "Timer: " + passwordLeak.Stopwatch / 1000 + "." + passwordLeak.StopwatchTime % 1000;
            double averageSpeed = passwordLeak.LineNumber / (passwordLeak.Stopwatch / 0.016); //Average speed per second
            if (!double.IsInfinity(averageSpeed)) labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed);
            else labelSpeed.Text = "Average speed /s: Yes";
            labelAttempts.Text = "Currently working on line: " + passwordLeak.LineNumber;
            progressBar1.Value = passwordLeak.Progress;            
            foreach (string temp in passwordLeak.LogOutput) logOutput.Add(temp);
        }
        private void buttonCheckPassword_Click(object sender, EventArgs e)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token;
            taskCurrentlyWorking = true;
            whatTaskIsWorking = 3;
            ResetAllValues();
            DisableUI();
            string messageBoxAnswer = "";
            string[] passwords = textBox1.Lines;           
            //Decider of what txt to use
            if (radioButton1.Checked)
            {
                fullPathToTXT = Settings.PasswordPathToFiles + "\\" + "rockyou.txt";
            }
            else if (radioButton2.Checked)
            {
                fullPathToTXT = Settings.PasswordPathToFiles + "\\" + "rockyouShort.txt";
            }
            else if (radioButton3.Checked)
            {
                fullPathToTXT = Settings.PasswordPathToFiles + "\\" + "rockyouVeryShort.txt";
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        fullPathToTXT = openFileDialog.FileName; //Own txt
                    }
                    else
                    {
                        if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("No path selected, selecting rockYouVeryShort.");
                        MessageBox.Show("No path selected, selecting rockYouVeryShort.");
                        fullPathToTXT = Settings.PasswordPathToFiles + "\\" + "rockyouVeryShort.txt";
                    }
                }
                if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Path to wordlist: " + fullPathToTXT);
            }
            Timer timer = new Timer();
            timer.Interval = 16;
            timer.Event = UpdateUIPassword;
            timer.Start();

            Task task = Task.Run(() => { PasswordFinder(fullPathToTXT, passwords, token); });
            Task.WaitAll(task);
            timer.Stop();
            UpdateUIPassword();
            progressBar1.Value = 100;
            if (token.IsCancellationRequested)
            {
                if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("The User has aborted the process.");
                MessageBox.Show("The User has aborted the process.");
            }
            for (int i = 0; i < passwords.Count(); i++)
            {
                if (foundMatch[i])
                {
                    messageBoxAnswer += "Password '" + passwords[i] + "' has been found in wordlist at line " + lineFoundMatch[i] + ". I recommend using a different password." + Environment.NewLine;
                    if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Password '" + passwords[i] + "' has been found in wordlist at line " + lineFoundMatch[i] + ". I recommend using a different password.");
                }
                else
                {
                    messageBoxAnswer += "Password '" + passwords[i] + "' has not been found in wordlist. Good Job." + Environment.NewLine;
                    if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Password '" + passwords[i] + "' has not been found in wordlist. Good Job." + Environment.NewLine);
                }
            }
            MessageBox.Show(messageBoxAnswer);
            taskCurrentlyWorking = false;
            whatTaskIsWorking = -1;
            ActivateUI();
        }

        public void PasswordFinder(string fullPathToTXT, string[] passwords, ref bool[] foundMatch, ref int[] lineFoundMatch, CancellationToken token)
        {
            ResetValue();
            using (StreamReader reader = new StreamReader(fullPathToTXT))
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                LinesInTXT = CountNumberOfLinesInFile(fullPathToTXT);
                while (!reader.EndOfStream && !token.IsCancellationRequested)
                {
                    CurrentLine++;
                    string line = reader.ReadLine();
                    for (int i = 0; i < passwords.Count(); i++)
                    {
                        if (!FoundMatch[i])
                        {
                            if (passwords[i] == line)
                            {
                                lineFoundMatch[i] = CurrentLine;
                                foundMatch[i] = true;
                                LogOutput = "Found '" + passwords[i] + "' on line: " + CurrentLine;
                            }
                        }
                    }
                }
                stopwatch.Stop();
            }
        }
        //Password Finder Get and Set
        private List<string> logOutput = new List<string>();
        private List<bool> foundMatch = new List<bool>(); 
        private List<int> lineFoundMatch = new List<int>();
        private long LinesInTXT = 0;
        private int progress = 0;

        public List<bool> FoundMatch
        {
            get
            {
                return foundMatch;
            }
            private set
            {
                foundMatch.Add(value);
            }
        }

        public List<int> LineFoundMatch
        {
            get
            {
                return lineFoundMatch;
            }
            private set
            {
                lineFoundMatch.Add(value);
            }
        }


        public List<string> LogOutput
        {
            get
            {
                return logOutput;
            }
            private set
            {
                logOutput.Add(value);
            }
        }

        public long Stopwatch
        {
            get
            {
                return stopwatch.ElapsedMilliseconds;
            }
        }

        public long LinesInTXT
        {
            get { return LinesInTXT; }
            private set { linesInTXT = value; }
        }

        public int Progress
        {
            get
            {
                int temp = CurrentLine / LinesInTXT * 100;
                if (temp > 100) return 100;
                else if (temp < 0) return 0;
                else return progress;
            }
        }

        private void ResetValue()
        {
            logOutput.Clear();
            foundMatch.Clear();
            lineFoundMatch.Clear();
            stopwatch.Reset();
            LinesInTXT = 0;
            CurrentLine = 0;
            Progress = 0;
        }
        

        public long CountNumberOfLinesInFile(string filePath) //Use In Every Fucking Possible Instance
        {
            long numberOfLines = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    numberOfLines++;
                    reader.ReadLine();
                }                
            }
            return numberOfLines;
        }

        #endregion

        #region How Long To Crack

        Double Kalkulacka(int delkaHesla, long pocetZnaku, double zaSekundu, out double rychlost)
        {
            Double pocet = (Double)Math.Pow(pocetZnaku, delkaHesla);
            rychlost = pocet / zaSekundu;
            return pocet;
        }

        string Vypis(double numberSeconds)
        {
            double numberYears = numberSeconds / 31556926; //years
            double numberMonths = (numberSeconds % 31556926) / (2629749); //months
            double numberDays = (numberSeconds % 2629749) / (86400); //days
            double numberHours = (numberSeconds % 86400) / (3600); //hours
            double numberMinutes = (numberSeconds % 3600) / (60); //minutes
            double numberSecondsLeft = numberSeconds % 60; //seconds
            string s = Math.Floor(numberYears).ToString("N0") + " years, " +
           Math.Floor(numberMonths) + " months, " +
           Math.Floor(numberDays) + " days, " +
           Math.Floor(numberHours) + " hours, " +
           Math.Floor(numberMinutes) + " minutes, " +
           Math.Floor(numberSecondsLeft) + " seconds";
            return s;
        }
        private void buttonCrackCalculate_Click(object sender, EventArgs e)
        {
            ResetAllValues();
            int pocetZnaku = 0;
            if (checkBoxCrack01.Checked) pocetZnaku += 26;
            if (checkBoxCrack02.Checked) pocetZnaku += 26;
            if (checkBoxCrack03.Checked) pocetZnaku += 10;
            if (checkBoxCrack04.Checked) pocetZnaku += 33;

            int passwordLenght;
            if (!int.TryParse(textBoxCrackLenght.Text, out passwordLenght)) passwordLenght = textBoxCrackLenght.Text.Length;
            if (passwordLenght > 50)
            {
                passwordLenght = 50;
                MessageBox.Show("Maximální délka hesla je 50.");
                if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Maximum lenght of the password set to 50.");
            }
            double speed = double.Parse(textBoxCrackSpeed.Text);
            if (speed > 2800000000)
            {
                speed = 2800000000;
                MessageBox.Show("Maximální rychlost za sekundu je 2.8 miliardy");
                if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add("Maximum speed /s set to 2.8 billions.");
            }

            Double pocet = Kalkulacka(passwordLenght, pocetZnaku, speed, out double rychlost);
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
                    listBoxLog.Items.Add(Vypis(rychlost));
                    listBoxLog.Items.Add("Pocet kombinaci: " + pocet.ToString("N0"));
                }
                MessageBox.Show(Vypis(rychlost) + "\nPocet kombinaci: " + pocet.ToString("N0")); //N0 == Formats the number to have spaces between each thousand. (1 mil. == 1 000 000)
            }
        }
        #endregion

        #region Rainbow Table - Done

        RainbowTable rainbowTable = new RainbowTable();
        private void buttonPreHash_Click(object sender, EventArgs e)
        {
            taskCurrentlyWorking = true;
            whatTaskIsWorking = 1;
            DisableUI();            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
            //Timer
            Timer updateUITimer = new Timer();
            updateUITimer.Interval = 16; //for 62.5 fps updates            
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
                    if (checkBoxPerformanceMode.Checked)
                    {
                        if (rainbowTable.GenerateRainbowTableMultiThread(Environment.ProcessorCount - 1, openFileDialog.FileName, saveFileDialog.FileName, userAlgorithm))
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
        private void UpdateUIRainbowTable(object sender, EventArgs e)
        {
            if (rainbowTable.StopwatchTimer > 0 && rainbowTable.LinesProcessed > 0 && rainbowTable.AllLinesInInputFile > 0)
            {       
                double speed = (rainbowTable.LinesProcessed - numberOfAttempsInLastUpdate) / 0.016;
                int progress = (int)((double)rainbowTable.LinesProcessed / rainbowTable.AllLinesInInputFile * 100);
                numberOfAttempsInLastUpdate = rainbowTable.LinesProcessed;
                labelTimer.Text = "Timer: " + rainbowTable.StopwatchTimer / 1000 + "." + rainbowTable.StopwatchTimer % 1000;
                labelSpeed.Text = "Average speed /s: " + rainbowTable.LinesProcessed / (double)(rainbowTable.StopwatchTimer / 1000);
                labelCurrentSpeed.Text = "Hashes /s: " + speed.ToString();
                progressBar1.Value = Math.Min(100, progress);
                //Refresh - The Labels didnt update for some reason
                labelTimer.Refresh();
                labelSpeed.Refresh();
                labelCurrentSpeed.Refresh();
            }
        }

        #endregion

        #region Rainbow Table Attack      
        RainbowTableAttack rainbowTableAttack = new RainbowTableAttack();

        private void buttonRainbowTableAttack_Click(object sender, EventArgs e)
        {
            Timer timeToUpdateUI = new Timer();
            timeToUpdateUI.Interval = 16; //16ms == 60+fps
            timeToUpdateUI.Tick += (s, args) => UpdateTheUIDictionaryAttack();
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
                if (rainbowTableAttack.PerformRainbowAttack(openFileDialog.FileName, originalInput, userAlgorithm))
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
                                            $"Found password in HEX: {ConvertToHexBasedOnUser(true, foundPassword)}";

                        if (checkBoxShowLogDictionary.Checked)
                        {
                            listBoxLog.Items.Add("Found hash via Dictionary attack");
                            listBoxLog.Items.Add($"Original password: {foundPassword}");
                            listBoxLog.Items.Add($"Found password hash: {originalInput}");
                            listBoxLog.Items.Add($"Found password at line: {foundAtLine}");
                            listBoxLog.Items.Add($"Found password in UTF-8: {foundPassword}");
                            listBoxLog.Items.Add($"Found password in HEX: {ConvertToHexBasedOnUser(true, foundPassword)}");
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
                    else if (ranOutOfTime)
                    {
                        MessageBox.Show("The program could not find the password within the time limit.");
                        if (checkBoxShowLogDictionary.Checked)
                            listBoxLog.Items.Add("The program could not find the password within the time limit.");
                        ranOutOfTime = false;
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else if (ranOutOfAttemps)
                    {
                        MessageBox.Show("The program could not find the password within the attempt limit.");
                        if (checkBoxShowLogDictionary.Checked)
                            listBoxLog.Items.Add("The program could not find the password within the attempt limit.");
                        ranOutOfAttemps = false;
                        if (timeToUpdateUI != null) timeToUpdateUI.Stop();
                    }
                    else
                    {
                        MessageBox.Show("Could not find password in the file.");
                        if (checkBoxShowLogDictionary.Checked)
                            listBoxLog.Items.Add("Could not find password in the file.");
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

        private void UpdateTheUIDictionaryAttack()
        {
            int seconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
            int milliseconds = (int)(stopwatch.ElapsedMilliseconds % 1000);

            long currentLinesProcessed = rainbowTableAttack.LinesProcessed;
            int triesBetween = (int)(currentLinesProcessed - RainbowAttacknumberOfLinesInLastUpdate);
            RainbowAttacknumberOfLinesInLastUpdate = currentLinesProcessed;

            // Speed Calculation
            double speed = triesBetween / 0.016; // Every 16ms
            labelCurrentSpeed.Text = $"Current speed /s: {speed:F2}";

            // Attempts Display
            labelAttempts.Text = $"Number of lines processed: {currentLinesProcessed}";

            // Average Speed Calculation
            double averageSpeed = (stopwatch.ElapsedMilliseconds > 0)
                ? currentLinesProcessed / (stopwatch.ElapsedMilliseconds / 1000.0)
                : 0;
            labelSpeed.Text = $"Average speed /s: {Math.Floor(averageSpeed)}";

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

        #region Password BruteForce Attack

        private bool foundPasswordBool = false;
        private static ulong Pow(ulong number, int exponent) //yes I had to do this
        {
            ulong result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= number;
            }
            return result;
        }

        private void BruteForceAttackMultiThread(Hasher.HashingAlgorithm algorithm, ushort threadID, ushort numberOfThreadsUsed, string userHashInput, char[] usableChars, bool useMaxAttemps, ulong maxAttempts, int userPasswordLenght, bool variablePasswordLenght, bool useLog, bool hexOutput, CancellationToken token, out string stringFoundPassword, out bool ranOutOfAttemps)
        {
            stringFoundPassword = "";
            ranOutOfAttemps = false;
            Console.WriteLine("Thread " + threadID + " has started working.");
            if (PasswordBruteForce(userAlgorithm, true, threadID, numberOfThreadsUsed, userHashInput, usableChars, useMaxAttemps, maxAttempts, userPasswordLenght, variablePasswordLenght, useLog, hexOutput, token, out stringFoundPassword, out ranOutOfAttemps))
            {
                foundPasswordBool = true;
                cancellationTokenSource.Cancel();
            }
            else Console.WriteLine("Thread " + threadID + " is finished.");           
        }

        private async void buttonBruteForceAttack_Click(object sender, EventArgs e)
        {
            token = cancellationTokenSource.Token;
            ResetAllValues();
            TurnOffUI();
            string stringFoundPassword = "";
            string userInputHash = textBoxBruteForceInput.Text;
            int userPasswordLenght = 0;
            if (radioButton5.Checked)
            {
                userPasswordLenght = textBoxBruteForceInput.Text.Length;
                userInputHash = hasher.Hash(textBoxBruteForceInput.Text, userAlgorithm);
                if (checkBoxShowLogBrute.Checked)
                {
                    listBoxLog.Items.Add("Hashing '" + textBoxBruteForceInput.Text + "' into " + userInputHash + ".");
                }
            }
            else
            {
                userPasswordLenght = (int)numericUpDown2.Value;
            }
            stopwatch.Reset();
            stopwatch.Start();

            //SetUp            
            numberOfAllPossibleCombinations = 0;
            maxAttempts = (ulong)numericUpDown1.Value;
            bool hexOutput = checkBoxHexOutput.Checked;
            bool useMaxAttempts = true;
            if (maxAttempts == 0) useMaxAttempts = false;
            if (numericUpDownStopTimer.Value == 0) useStopTimer = false;
            bool performanceMode = checkBoxPerformanceMode.Checked;
            bool variablePasswordLength = userPasswordLenght == 0; //if passwordLenght is 0
            bool ranOutOfAttemps = false;
            char[] usableChars = GenerateAllUsableChars();
            //Task Set Up                
            List<Task> allTasks = new List<Task>();

            //all possible combinations
            if (variablePasswordLength) // Variable password length
            {
                for (int length = 1; length <= maximumLenghtForBruteForce; length++) //maximumLenghtForBruteForce can be change at the start of the script
                {
                    numberOfAllPossibleCombinations += Pow((ulong)usableChars.Length, length);
                }
            }
            else // Known password length
            {
                numberOfAllPossibleCombinations = Pow((ulong)usableChars.Length, userPasswordLenght);
            }
            if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add("Number Of All Possible Combinations: " + numberOfAllPossibleCombinations);
            SetUpTimer(true, performanceMode);
            if (performanceMode)
            {
                //For cancelling all tasks if password is found                
                ushort maxThreads = (ushort)(Environment.ProcessorCount);
                for (ushort i = 0; i < maxThreads; i++) //multiThread
                {
                    ushort threadID = i;
                    allTasks.Add(Task.Run(() => BruteForceAttackMultiThread(userAlgorithm, threadID, maxThreads, userInputHash, usableChars, useMaxAttempts, maxAttempts, userPasswordLenght, variablePasswordLength, checkBoxShowLogBrute.Checked, hexOutput, token, out stringFoundPassword, out ranOutOfAttemps)));
                }
                await Task.WhenAll(allTasks); //waits until all tasks are finish
            }
            else //single Thread
            {
                await Task.Run(() => foundPasswordBool = PasswordBruteForce
                (
                    userAlgorithm,
                    false, //useMultiThreading
                    0, //ThreadID
                    1, //numberOfThreadsUsed
                    userInputHash,
                    usableChars,
                    useMaxAttempts,
                    maxAttempts,
                    userPasswordLenght,
                    variablePasswordLength,
                    checkBoxShowLogBrute.Checked,
                    hexOutput,
                    CancellationToken.None, //there is no need for CancellationToken
                    out stringFoundPassword,
                    out ranOutOfAttemps
                 ));
            }
            //UI Turn Off
            StopTimer(true, performanceMode);
            stopwatch.Stop();
            UpdateTheUIBruteForceAttack(performanceMode);
            TurnOnUI();
            //Output
            if (foundPasswordBool)
            {
                foundPasswordBool = false; //reset
                string message = "Password found!\n" +
                  "\nOriginal hash: " + userInputHash +
                  "\nFound password hash: " + hasher.Hash(stringFoundPassword, userAlgorithm) +
                  "\nFound password in UTF-8: " + stringFoundPassword +
                  "\nFound password in HEX: " + ConvertToHexBasedOnUser(true, stringFoundPassword) +
                  "\nAttempts: " + attempts +
                  "\n" + labelTimer.Text + // Timer
                  "\n" + labelSpeed.Text;  //Speed

                if (checkBoxShowLogBrute.Checked)
                {
                    listBoxLog.Items.Add("----------------------------");
                    listBoxLog.Items.Add("Password found!");
                    listBoxLog.Items.Add("Original hash: " + userInputHash);
                    listBoxLog.Items.Add("Found password hash: " + hasher.Hash(stringFoundPassword, userAlgorithm));
                    listBoxLog.Items.Add("Found password in UTF-8: " + stringFoundPassword);
                    listBoxLog.Items.Add("Found password in HEX: " + ConvertToHexBasedOnUser(true, stringFoundPassword));
                    listBoxLog.Items.Add("Attempts: " + attempts);
                    listBoxLog.Items.Add("Time to find: " + labelTimer.Text.Split(' ')[1]);
                    listBoxLog.Items.Add("Average speed: " + labelSpeed.Text);
                }
                PasswordFoundMessageBox(message, userInputHash, stringFoundPassword);
            }
            else if (ranOutOfAttemps)
            {
                MessageBox.Show("Could not find a password under the given attempts.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ranOutOfTime = false;
            }
            else if (ranOutOfTime)
            {
                MessageBox.Show("Could not find a password under the given time limit.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ranOutOfTime = false;
            }
            else if (userAbortProcess)
            {
                MessageBox.Show("The process has been abandoned.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Information);
                userAbortProcess = false;
            }
            else MessageBox.Show("Could not find the original password.");
        }
        private bool PasswordBruteForce(
                     Hasher.HashingAlgorithm algorithm,
                     bool useMultiThreading,
                     ushort threadID,
                     ushort numberOfThreadsUsed,
                     string userHashInput,
                     char[] usableChars,
                     bool useMaxAttemps,
                     ulong maxAttempts,
                     int userPasswordLenght,
                     bool variablePasswordLenght,
                     bool useLog,
                     bool hexOutput,
                     CancellationToken token,
                     out string foundPassword,
                     out bool ranOutOfAttemps)
        {
            ulong index = 0;
            foundPassword = "";
            ranOutOfAttemps = false;
            Hasher hasher = new Hasher();
            int currentLength = userPasswordLenght == 0 ? 1 : userPasswordLenght; // Start with length 1 if variable
            bool checkedAllPossibleCombinations = false;
            ulong allPossibleCombinationsForCurrentLength = 0;
            ulong allPossibleCombinationsForOneThread = 0;
            if (variablePasswordLenght) // Variable password length
            {
                ulong totalCombinations = 0;
                for (int length = 1; length <= maximumLenghtForBruteForce; length++)
                {
                    totalCombinations += Pow((ulong)usableChars.Length, length);
                }
                if (useMultiThreading)
                {
                    allPossibleCombinationsForOneThread = totalCombinations / numberOfThreadsUsed;
                    index = allPossibleCombinationsForOneThread * threadID;

                    // Adjust current length to match starting index
                    ulong temp = Pow((ulong)usableChars.Length, currentLength);
                    while (index >= temp)
                    {
                        index -= temp;
                        currentLength++;
                        temp = Pow((ulong)usableChars.Length, currentLength);
                    }
                }
                else
                {
                    allPossibleCombinationsForOneThread = totalCombinations; // Single thread, all combinations
                }
            }
            else // Known password length
            {
                allPossibleCombinationsForCurrentLength = Pow((ulong)usableChars.Length, userPasswordLenght); //10 usable chars, 5 password lenght ==> 100 000
                if (useMultiThreading)
                {
                    allPossibleCombinationsForOneThread = allPossibleCombinationsForCurrentLength / (ushort)(numberOfThreadsUsed);
                    index = allPossibleCombinationsForOneThread * threadID;
                    //Console.WriteLine("allPossibleCombinationsForCurrentLength: " + allPossibleCombinationsForCurrentLength + "(" + threadID + ")"); //0 - 91 666
                    //Console.WriteLine("allPossibleCombinationsForOneThread: " + allPossibleCombinationsForOneThread); //8333
                    //Console.WriteLine("index: " + index + "(" + threadID + ")");
                }
            }

            // Brute-force
            while (!checkedAllPossibleCombinations && !userAbortProcess)
            {
                //Console.WriteLine("Index: " + index);
                //Console.WriteLine("allPossibleCombinationsForOneThread: " + allPossibleCombinationsForOneThread);
                //Console.WriteLine("allPossibleCombinationsForCurrentLength: " + allPossibleCombinationsForCurrentLength);
                if (token.IsCancellationRequested) // Check for cancellation
                {
                    return false;
                }
                if (variablePasswordLenght && index > allPossibleCombinationsForCurrentLength)
                {
                    currentLength++;
                    if (currentLength > maximumLenghtForBruteForce)
                    {
                        checkedAllPossibleCombinations = true;
                    }
                    else
                    {
                        allPossibleCombinationsForCurrentLength = Pow((ulong)usableChars.Length, currentLength);
                        index = 0; // Reset index for new length
                    }
                }
                else if (!variablePasswordLenght && index > allPossibleCombinationsForCurrentLength) //91 666 > 100 000
                {
                    checkedAllPossibleCombinations = true;
                }

                // Generate password attempt
                string tryText = GenerateTextForBruteForce(index, usableChars, currentLength);
                //Console.WriteLine(tryText);
                string hashedText = hasher.Hash(tryText, algorithm);
                if (hashedText == userHashInput)
                {
                    foundPassword = tryText;
                    if (!useLog)
                    {
                        Invoke(new Action(() =>
                            listBoxLog.Items.Add($"Found password for: {userHashInput}\nThe password is: {ConvertToHexBasedOnUser(hexOutput, tryText)}")));
                    }
                    return true;
                }

                if (useMaxAttemps && (ulong)attempts >= maxAttempts)
                {
                    ranOutOfAttemps = true;
                    return false;
                }
                // Increment attempts safely
                Interlocked.Increment(ref attempts);
                index++;                
            }
            return false;
        }

        private string GenerateTextForBruteForce(ulong index, char[] allPossibleChars, int length)
        {
            uint baseSize = (uint)allPossibleChars.Length;
            char[] result = new char[length];
            for (int i = 0; i < length; i++) //fill every space
            {
                result[i] = allPossibleChars[0];
            }
            int position = length - 1; //Start from the back
            while (index > 0 && position >= 0) //Calculate the next output
            {
                result[position] = allPossibleChars[index % baseSize];
                index /= baseSize;
                position--;
            }
            return new string(result);
        }
        private void UpdateTheUIBruteForceAttack(bool usingPerformanceMode) //Runs every 16ms
        {
            //Update Timer
            int seconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
            int milliseconds = (int)(stopwatch.ElapsedMilliseconds % 1000);
            labelTimer.Text = "Timer: " + seconds + "." + milliseconds + " s";
            if (useStopTimer && stopwatch.ElapsedMilliseconds > numericUpDownStopTimer.Value)
            {
                userAbortProcess = true;
                ranOutOfTime = true;
            }
            int triesBetween = (int)(attempts - numberOfAttempsInLastUpdate);
            numberOfAttempsInLastUpdate = attempts;
            //Update Speed
            double speed = triesBetween / 0.016; //16 ms
            labelCurrentSpeed.Text = "Current speed /s:  " + speed;
            //Attempts
            labelAttempts.Text = "Number of attempts: " + attempts;
            //Update Average Speed
            double averageSpeed = attempts / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
            labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed);
            //update progressbar
            int tempProgress = (int)(((double)Interlocked.Read(ref attempts) / numberOfAllPossibleCombinations) * 100);
            if (tempProgress <= 100 )progressBar1.Value = tempProgress;
        }
        private char[] GenerateAllUsableChars()
        {
            int pocetZnaku = 0;
            if (checkBox6.Checked) pocetZnaku += 26; //lowerCase
            if (checkBox5.Checked) pocetZnaku += 26; //upperCase
            if (checkBox4.Checked) pocetZnaku += 10; //digits
            if (checkBox3.Checked) pocetZnaku += 33; //SpecialChars
            int index = 0;
            char[] allUsableChars = new char[pocetZnaku];
            if (checkBox6.Checked)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    allUsableChars[index++] = c;
                }
            }
            if (checkBox5.Checked)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    allUsableChars[index++] = c;
                }
            }
            if (checkBox4.Checked)
            {
                for (char c = '0'; c <= '9'; c++)
                {
                    allUsableChars[index++] = c;
                }
            }
            if (checkBox3.Checked)
            {
                // Add special characters
                string specialChars = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
                foreach (char c in specialChars)
                {
                    allUsableChars[index++] = c;
                }
            }
            return allUsableChars;
        }
        #endregion

        private void TurnOffUI()
        {
            foreach (Control control in this.Controls)
            {
                if (!(control is Label)) control.Enabled = false;
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
            }
            progressBar1.Value = 0;
        }
        private void SetUpTimer(bool updateTheBruteForceAttack, bool isPerformanceModeOn)
        {
            timeToUpdateTheUI.Dispose();
            timeToUpdateTheUI.Interval = 16; //16ms == 60+fps
            if (updateTheBruteForceAttack) timeToUpdateTheUI.Tick += (s, args) => UpdateTheUIBruteForceAttack(isPerformanceModeOn);
        }
        private string ConvertToHexBasedOnUser(bool hexOutput, string text)
        {
            if (hexOutput)
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
        private void StopTimer(bool updateTheBruteForceAttack, bool isPerformanceModeOn)
        {
            if (updateTheBruteForceAttack) UpdateTheUIBruteForceAttack(isPerformanceModeOn); //Last update to have the most updated data
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
                    writer.WriteLine("Password HEX:  " + ConvertToHexBasedOnUser(true, password));
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
                }
            }
        }

        private void ResetAllValues()
        {
            //bool
            ranOutOfAttemps = false;
            ranOutOfTime = false;
            progressBar1.Value = 0;
            RainbowAttacknumberOfLinesInLastUpdate = 0;
            attempts = 0;
            numberOfAttempsInLastUpdate = 0;
            stopwatch.Reset();
            if (timeToUpdateTheUI.Enabled) timeToUpdateTheUI.Stop();
            maxAttempts = 0;
        }        
    }
}

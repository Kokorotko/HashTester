using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;
using System.Security.Policy;
using System.Runtime.CompilerServices;
using System.Collections.Concurrent;
using System.Net.Http.Headers;
using System.Threading;
using Timer = System.Windows.Forms.Timer;
using System.Diagnostics.Eventing.Reader;
using System.Collections;

namespace HashTester
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }
        private volatile bool userAbortProcess = false;
        private volatile bool ranOutOfAttemps = false;
        Stopwatch stopwatch = new Stopwatch();
        //Password Dictionary Attack and Bruteforce Attack
        Timer timeToUpdateTheUI = new Timer();
        private long maxAttempts = 0;
        private long attempts = 0;
        private long numberOfAttempsInLastUpdate = 0; //The time is 16ms
        private Timer updateUITimer;
        private volatile bool stopJailBreak = false;
        private volatile int progressBar = 0;
        bool useStopTimer = true;
        bool ranOutOfTime = false;

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
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
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
        #endregion

        #region Password Leak Test
        private void UpdateUIPassword(int lineNumber, long stopwatchTime, int progress) //doesnt contain log
        {
            labelTimer.Text = "Timer: " + stopwatchTime / 1000 + "." + stopwatchTime % 1000;
            labelSpeed.Text = "Average speed /s: " + lineNumber / (double)(stopwatchTime / 1000);
            labelAttempts.Text = "Currently working on line: " + lineNumber;
            progressBar1.Value = progress;
        }

        private async void buttonCheckPassword_Click(object sender, EventArgs e)
        {
            bool useLog = checkBoxShowLogPassword.Checked;
            ResetAllValues();
            DisableUI();
            string messageBoxAnswer = "";
            string fullPathToTXT = "";
            string[] passwords = textBox1.Lines;
            bool[] foundMatch = new bool[textBox1.Lines.Length];
            int[] lineFoundMatch = new int[textBox1.Lines.Length];
            for (int i = 0; i < foundMatch.Length; i++)
            {
                foundMatch[i] = false;
                lineFoundMatch[i] = 0;
            }
            //Decider of what txt to use
            if (radioButton1.Checked) fullPathToTXT = Settings.PasswordPathToFiles + "\\" + "rockyou.txt";
            else if (radioButton2.Checked) fullPathToTXT = Settings.PasswordPathToFiles + "\\" + "rockyouShort.txt";
            else if (radioButton3.Checked) fullPathToTXT = Settings.PasswordPathToFiles + "\\" + "rockyouVeryShort.txt";
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
                    if (openFileDialog.ShowDialog() == DialogResult.OK) fullPathToTXT = openFileDialog.FileName; //Own txt
                }
            }
            stopwatch.Start();
            progressBar1.Value = 0;
            await Task.Run(() => { PasswordFinder(fullPathToTXT, passwords, useLog, ref foundMatch, ref lineFoundMatch); });
            progressBar1.Value = 100;
            stopwatch.Stop();
            stopwatch.Reset();
            if (userAbortProcess)
            {
                if (useLog) listBoxLog.Items.Add("The User has aborted the process.");
                MessageBox.Show("The User has aborted the process.");
            }
            for (int i = 0; i < passwords.Count(); i++)
            {
                if (foundMatch[i]) messageBoxAnswer += "Password '" + passwords[i] + "' has been found in wordlist at line " + lineFoundMatch[i] + ". I recommend using a different password." + Environment.NewLine;
                else messageBoxAnswer += "Password '" + passwords[i] + "' has not been found in wordlist. Good Job." + Environment.NewLine;
            }
            MessageBox.Show(messageBoxAnswer);
            ActivateUI();
        }

        private void PasswordFinder(string fullPathToTXT, string[] passwords, bool useLog, ref bool[] foundMatch, ref int[] lineFoundMatch)
        {
            using (StreamReader reader = new StreamReader(fullPathToTXT))
            {
                int lineNumber = 0;
                int linesInTXT = (int)File.ReadLines(fullPathToTXT).LongCount();
                long stopwatchTime = 0;
                int progressBar = 0;
                while (!reader.EndOfStream && !userAbortProcess)
                {
                    if (stopwatch.ElapsedMilliseconds - stopwatchTime > 16) //update UI every 60+ fps
                    {
                        stopwatchTime = stopwatch.ElapsedMilliseconds;
                        progressBar = (lineNumber * 100) / linesInTXT;
                        Invoke((Action)(() => UpdateUIPassword(lineNumber, stopwatchTime, progressBar)));
                    }
                    lineNumber++;
                    string line = reader.ReadLine();
                    for (int i = 0; i < passwords.Count(); i++)
                    {
                        if (!foundMatch[i])
                        {
                            if (passwords[i] == line)
                            {                                
                                lineFoundMatch[i] = lineNumber;
                                foundMatch[i] = true;
                                if (useLog)
                                {
                                    Invoke((Action)(() =>
                                    {
                                        listBoxLog.Items.Add("Found '" + passwords[i] + "' on line: " + lineNumber);
                                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1; // Scroll to the most recent item
                                    }));
                                }
                            }
                        }
                    }
                }
                stopwatchTime = stopwatch.ElapsedMilliseconds;
                Invoke((Action)(() => UpdateUIPassword(lineNumber, stopwatchTime, 100)));
            }
        }

        #endregion

        #region How Long To Crack

        Double Kalkulacka(int delkaHesla, double pocetZnaku, double zaSekundu, out float rychlost)
        {
            Double pocet = (Double)Math.Pow(pocetZnaku, delkaHesla);
            rychlost = (float)(pocet / zaSekundu);
            return pocet;
        }

        string Vypis(float rychlost)
        {
            if (rychlost == 0) //Pro jistotku
                return "Prolomit toto heslo bude trvat déle než 100 let :)";

            double pocetSekund = (double)rychlost;
            double pocetLet = pocetSekund / 31556926; //roky
            double pocetMesicu = (pocetSekund % 31556926) / (2629749); //mesice
            double pocetDni = (pocetSekund % 2629749) / (86400); //dny
            double pocetHodin = (pocetSekund % 86400) / (3600); //hodiny
            double pocetMinut = (pocetSekund % 3600) / (60); //minuty
            double pocetSekundZbyva = pocetSekund % 60; //sekundy
            string s = (int)pocetLet + " let, " + (int)pocetMesicu + " mesiců, " +
                           (int)pocetDni + " dní, " + (int)pocetHodin + " hodin, " +
                           (int)pocetMinut + " minut, " + (int)pocetSekundZbyva + " sekund";
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
            if (passwordLenght > 20)
            {
                passwordLenght = 20;
                MessageBox.Show("Maximální délka hesla je 20");
            }
            double speed = double.Parse(textBoxCrackSpeed.Text);
            if (speed > 2800000000)
            {
                speed = 2800000000;
                MessageBox.Show("Maximální rychlost za sekundu je 2.8 miliardy");
            }

            float rychlost;
            Double pocet = Kalkulacka(passwordLenght, pocetZnaku, speed, out rychlost);
            //Output
            if (rychlost / 100 >= 31556926) MessageBox.Show("Prolomit toto heslo bude trvat déle než 100 let :)\nPocet kombinací: " + pocet.ToString("N0")); //Pokud by trvalo dele jak 100 let                
            else MessageBox.Show(Vypis(rychlost) + "\nPocet kombinaci: " + pocet.ToString("N0")); //N0 == Formátuje číslo s oddělovači tisíců a bez desetinných míst.
        }
        #endregion

        #region Pre Hash
        Hasher.HashingAlgorithm algorithm = new Hasher.HashingAlgorithm();
        Hasher hasher = new Hasher();
        private void buttonPreHash_Click(object sender, EventArgs e)
        {
            ResetAllValues();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "-" + algorithm.ToString() + ".txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt"; // Only allow .txt files

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DisableUI();
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        int linesInTXT = (int)File.ReadLines(openFileDialog.FileName).LongCount();
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            stopwatch.Start();
                            writer.WriteLine("algorithm==" + algorithm.ToString());
                            //Stats
                            int numberOfHashed = 0;
                            int numberOfHashedInLastUpdate = 0;
                            long stopwatchTime = stopwatch.ElapsedMilliseconds;
                            while (!reader.EndOfStream)
                            {
                                //UI                             
                                if (stopwatch.ElapsedMilliseconds - stopwatchTime > 16) //update UI every 60+ fps
                                {
                                    stopwatchTime = stopwatch.ElapsedMilliseconds;
                                    double speed = (numberOfHashed - numberOfHashedInLastUpdate) / 0.016;
                                    int progress = numberOfHashed / linesInTXT;
                                    UpdateUIPreHash(numberOfHashed, stopwatchTime, speed, progress);
                                    numberOfHashedInLastUpdate = numberOfHashed;
                                }
                                numberOfHashed++;

                                //txt
                                string line = reader.ReadLine();
                                string hash = hasher.Hash(line, algorithm);
                                writer.WriteLine(line + "==" + hash);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Input přerušen");
            }
            stopwatch.Stop();
            stopwatch.Restart();
            ActivateUI();
        }

        private void UpdateUIPreHash(int lineNumber, long stopwatchTime, double speed, int progress)
        {
            labelTimer.Text = "Timer: " + stopwatchTime / 1000 + "." + stopwatchTime % 1000;
            labelSpeed.Text = "Average speed /s: " + lineNumber / (double)(stopwatchTime / 1000);
            labelCurrentSpeed.Text = "Hashes /s: " + speed.ToString();
            progressBar1.Value = progress;
        }
        #endregion

        #region Password Dictionary Attack

        volatile int lineProcessing = 1;
        bool stopDictionaryAttack = false;
        int progressBarValueDictionararyAttack = 0;
        int numberOfLinesInLastUpdate = 0;
        private async void buttonDictionaryAttack_Click(object sender, EventArgs e)
        {
            ResetAllValues();
            TurnOffUI();
            bool useLog = checkBoxListBoxLog.Checked;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
            if (numericUpDownStopTimer.Value == 0) useStopTimer = false;
            else useStopTimer = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Set up
                stopwatch.Reset();
                stopwatch.Start();
                SetUpTimer(false, false);
                bool foundHash = false;
                string stringFoundPassword = "";
                string inputHash = textBoxBruteForceInput.Text;
                if (radioButton5.Checked) inputHash = hasher.Hash(textBoxBruteForceInput.Text, algorithm);
                await Task.Run(() => { foundHash = DictionaryAttack(inputHash, algorithm, openFileDialog, useLog,  out stringFoundPassword); }); //actuall attack                
                stopwatch.Stop();
                StopTimer(false, false);
                if (useLog) listBoxLog.Items.Add("-----------------------------------------------");
                if (foundHash)
                {
                    string s = "Found hash via Dictionary attack" +
                                                              "\nOriginal password: " + stringFoundPassword +
                                                              "\nOriginal password hash: " + hasher.Hash(textBoxBruteForceInput.Text, algorithm) +
                                                              "\nFound password hash: " + hasher.Hash(stringFoundPassword, algorithm) +
                                                              "\nFound password in UTF-8: " + stringFoundPassword +
                                                              "\nFound password in HEX: " + ConvertStringToHex(true, stringFoundPassword);
                    if (useLog)
                    {                        
                        listBoxLog.Items.Add("Found hash via Dictionary attack");
                        listBoxLog.Items.Add("Original password: " + stringFoundPassword);
                        listBoxLog.Items.Add("Found password hash: " + hasher.Hash(stringFoundPassword, algorithm));
                        listBoxLog.Items.Add("Found password in UTF-8: " + stringFoundPassword);
                        listBoxLog.Items.Add("Found password in HEX: " + ConvertStringToHex(true, stringFoundPassword));
                    }
                    PasswordFoundMessageBox(s , inputHash, stringFoundPassword);
                }
                else if (userAbortProcess)
                {
                    MessageBox.Show("The user has aborted the process.");
                    if (useLog) listBoxLog.Items.Add("The user has aborted the process.");
                }
                else if (ranOutOfTime)
                {
                    MessageBox.Show("The program could not find the password in time limit.");
                    if (useLog) listBoxLog.Items.Add("The program could not find the password in time limit.");
                }
                else if (ranOutOfAttemps)
                {
                    MessageBox.Show("The program could not find the password in attempts limit.");
                    if (useLog) listBoxLog.Items.Add("The program could not find the password in attempts limit.");                    
                    ranOutOfAttemps = false;
                }
                else
                {
                    MessageBox.Show("Could not find password in the File.");
                    if (useLog) listBoxLog.Items.Add("Could not find password in the File.");
                }
            }
            else if (useLog) listBoxLog.Items.Add("Could not find desired file. Cancelling dictionary attack...");
            TurnOnUI();
        }
        private bool DictionaryAttack(string userInputHash, Hasher.HashingAlgorithm desiredAlgorithm, OpenFileDialog openFileDialog, bool useLog, out string originalTextOutput)
        {
            bool foundMatch = false;
            originalTextOutput = "";
            bool inputFileIsInPlainText = false;
            int totalLinesInFile = File.ReadLines(openFileDialog.FileName).Count(); // Counts the lines in the file

            using (StreamReader reader = new StreamReader(openFileDialog.FileName))
            {
                string line = reader.ReadLine();
                bool rehashNeeded = false;
                Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.CRC32;
                if (line != null && line.Contains("=")) // File is already pre-hashed
                {
                    if (checkBoxListBoxLog.Checked) listBoxLog.Items.Add("File is already pre-hashed.");
                    string[] algorithmText = line.Split('=');
                    if (algorithmText.Length < 2)
                    {
                        if (checkBoxListBoxLog.Checked) listBoxLog.Items.Add("Found invalid file format. Cancelling dictionary attack.");
                        return false;
                    }
                    switch (algorithmText[1])
                    {
                        case "MD5":
                            algorithm = Hasher.HashingAlgorithm.MD5;
                            break;
                        case "SHA1":
                            algorithm = Hasher.HashingAlgorithm.SHA1;
                            break;
                        case "SHA256":
                            algorithm = Hasher.HashingAlgorithm.SHA256;
                            break;
                        case "SHA512":
                            algorithm = Hasher.HashingAlgorithm.SHA512;
                            break;
                        case "RIPEMD160":
                            algorithm = Hasher.HashingAlgorithm.RIPEMD160;
                            break;
                        default:
                            break;
                    }                    
                }
                else inputFileIsInPlainText = true;
                if (useLog) //Log
                {
                    if (!inputFileIsInPlainText)
                    {
                        Invoke(new Action(() => listBoxLog.Items.Add("File is hashed in " + algorithm.ToString() + " algorithm")));
                        if (rehashNeeded) Invoke(new Action(() => listBoxLog.Items.Add("File is not hashed with desired hashing algorithm. Re-hashing.")));
                    }
                    else Invoke(new Action(() => listBoxLog.Items.Add("File is not pre-hashed.")));
                }
                while (!reader.EndOfStream && !foundMatch && !userAbortProcess)
                {
                    string fullLine = reader.ReadLine();
                    Interlocked.Increment(ref lineProcessing); // Thread-safe increment
                    string hashedLine = "";
                    string originalText = "";
                    if (fullLine != null && fullLine.Contains("==")) //check for hashed or not
                    {
                        string[] data = fullLine.Split('=');
                        if (data.Length > 2)
                        {
                            originalText = data[0];
                            if (rehashNeeded) hashedLine = hasher.Hash(data[0], desiredAlgorithm); //File is pre-hashed with wrong algorithm
                            else hashedLine = data[1]; //File is pre-hashed
                        }
                        else  //error                       
                        {
                            if (useLog) Invoke(new Action(() => listBoxLog.Items.Add("Could not process line " + lineProcessing)));
                            hashedLine = "";
                        }
                    }
                    else //File is not pre-hashed
                    {
                        originalText = fullLine;
                        hashedLine = hasher.Hash(fullLine, desiredAlgorithm);
                    }

                    if (hashedLine == userInputHash)
                    {
                        foundMatch = true;
                        originalTextOutput = originalText;
                        return true;
                    }
                    // Update progress bar
                    progressBarValueDictionararyAttack = (int)(((double)lineProcessing / totalLinesInFile) * 100);
                }
            }
            return false;
        }

        private void UpdateTheUIDictionaryAttack(bool usingPerformanceMode)
        {
            //Update Timer
            int seconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
            int milliseconds = (int)(stopwatch.ElapsedMilliseconds % 1000);
            labelTimer.Text = "Timer: " + seconds + "." + milliseconds + " s";
            if (useStopTimer && stopwatch.ElapsedMilliseconds > numericUpDownStopTimer.Value)
            {
                stopDictionaryAttack = true;
                ranOutOfTime = true;
            }
            int triesBetween = lineProcessing - numberOfLinesInLastUpdate;
            numberOfLinesInLastUpdate = lineProcessing;
            //Update Speed
            double speed = triesBetween / 0.016; //16 ms
            labelCurrentSpeed.Text = "Current speed /s:  " + speed;
            //Attempts
            labelAttempts.Text = "Number of lines proccessed: " + lineProcessing;
            //Update Average Speed
            double averageSpeed = lineProcessing / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
            labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed);
            //update progressbar
            progressBar1.Value = progressBarValueDictionararyAttack;
        }
        #endregion

        #region Password BruteForce Attack
        private async void buttonBruteForceAttack_Click(object sender, EventArgs e)
        {
            ResetAllValues();
            string userInputHash = textBoxBruteForceInput.Text;
            bool foundHash = false;
            string stringFoundPassword = "";
            string hashedText = textBoxBruteForceInput.Text;
            int passwordLenght = 0;
            if (radioButton5.Checked)
            {
                passwordLenght = textBoxBruteForceInput.Text.Length;
                hashedText = hasher.Hash(textBoxBruteForceInput.Text, algorithm);
            }
            else passwordLenght = (int)numericUpDown2.Value;
            TurnOffUI();
            stopwatch.Reset();
            stopwatch.Start();

            //SetUp
            progressBar1.Value = 0;
            int maxAttempts = (int)numericUpDown1.Value;
            bool hexOutput = checkBoxHexOutput.Checked;
            bool useMaxAttempts = true;
            if (maxAttempts == 0) useMaxAttempts = false;
            if (numericUpDownStopTimer.Value == 0) useStopTimer = false;
            bool saveLog = checkBoxListBoxLog.Checked;
            bool performanceMode = checkBoxPerformanceMode.Checked;
            bool ranOutOfAttemps = false;
            char[] usableChars = GenerateAllUsableChars();
            double allPossibleCombinations = (Double)Math.Pow(usableChars.Length, passwordLenght);
            SetUpTimer(true, performanceMode);
            //Task Set Up                
            List<Task> allTasks = new List<Task>();
            if (performanceMode)
            {
                int maxThreads = Environment.ProcessorCount;
                for (int i = 0; i < maxThreads - 1; i++) //multiThread
                {
                    allTasks.Add(Task.Run(() => PasswordJailbreakMultipleThreads()));
                }
                await Task.WhenAll(allTasks); //waits until all tasks are finish
            }
            else //single Thread
            {
                allTasks.Add(Task.Run(() => foundHash = PasswordJailbreakOneThread(algorithm, userInputHash, usableChars, useMaxAttempts, maxAttempts, passwordLenght, saveLog, hexOutput, out stringFoundPassword, out ranOutOfAttemps)));
                await Task.WhenAny(allTasks); //waits until atleast one task is finish
            }
            if (foundHash)
            {
                string message = "Password found!\n" +
                                            "\nOriginal hash: " + userInputHash +
                                            "\nFound password hash: " + hasher.Hash(stringFoundPassword, algorithm) +
                                            "\nFound password in UTF-8: " + stringFoundPassword +
                                            "\nfound password in HEX: " + ConvertStringToHex(true, stringFoundPassword) +
                                            "\nAttempts: " + attempts +
                                            "\nTime to find: " + labelTimer.Text.Split(' ')[1] + // Only the number
                                            "\nAverage speed: " + labelSpeed.Text;  //Speed
                PasswordFoundMessageBox(message, userInputHash, stringFoundPassword);
            }
            else if (ranOutOfAttemps)
            {
                MessageBox.Show("Could not find a password under the given attempts.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (ranOutOfTime)
            {
                MessageBox.Show("Could not find a password under the given time limit.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (stopJailBreak)
            {
                MessageBox.Show("The process has been abandoned.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Could not find the original password.");
        }
        private bool PasswordJailbreakOneThread(Hasher.HashingAlgorithm algorithm, string userHashInput, char[] usableChars, bool useMaxAttemps, int maxAttempts, int userPasswordLenght, bool saveLog, bool hexOutput, out string foundPassword, out bool ranOutOfAttemps)
        {
            foundPassword = "";
            ranOutOfAttemps = false;
            Hasher hasher = new Hasher();
            int currentLenght = 0;
            bool checkedAllPossibleCombinations = false;
            bool variablePasswordLenght = userPasswordLenght == 0;
            double allPossibleCombinationsForCurrentLenght = 0;
            if (!variablePasswordLenght) //We do know the password lenght
            {
                allPossibleCombinationsForCurrentLenght = Math.Pow(usableChars.Length, userPasswordLenght);
            }            
            double index = 0;
            while(!checkedAllPossibleCombinations && !stopJailBreak) //While because Im manipulating with index
            {
                if (index >= allPossibleCombinationsForCurrentLenght && variablePasswordLenght) //We dont know the actuall password lenght, so we start from the beginning and go up
                {
                    index = 0;
                    currentLenght++;
                    if (currentLenght > 15) checkedAllPossibleCombinations = true;
                    allPossibleCombinationsForCurrentLenght = Math.Pow(usableChars.Length, currentLenght);
                }
                else if (index >= allPossibleCombinationsForCurrentLenght) checkedAllPossibleCombinations = true;
                string tryText = GenerateTextForBruteForce(index, usableChars, userPasswordLenght);
                string hashedText = hasher.Hash(tryText, algorithm);
                if (!saveLog) //Log output
                {
                    listBoxLog.Items.Add("Trying text: " + ConvertStringToHex(hexOutput, tryText) + " with hash " + hashedText);
                }
                if (hashedText == userHashInput) //found the password
                {
                    foundPassword = tryText;
                    if (!saveLog) listBoxLog.Items.Add("Found password for: " + userHashInput + "\nThe password is: " + ConvertStringToHex(hexOutput, foundPassword));
                    progressBar = 100;
                    return true;
                }
                else
                {
                    Interlocked.Increment(ref attempts); //attempts++
                    if (useMaxAttemps)
                    {
                        progressBar = (int)((attempts / (long)maxAttempts) * 100);
                        if (attempts > maxAttempts)
                        {
                            ranOutOfAttemps = true;
                            if (!saveLog) listBoxLog.Items.Add("Ran out of attemps.");
                            return false;
                        }
                    }
                    else progressBar = (int)((index / allPossibleCombinationsForCurrentLenght) * 100);
                }
                index++;
            }
            if (checkedAllPossibleCombinations && saveLog)
            {
                if (variablePasswordLenght) listBoxLog.Items.Add("Checked every possible combination from 0  to 15 password lenght. Couldnt find anything");
                else listBoxLog.Items.Add("Checked every possible combination with password lenght of " + userPasswordLenght + ". Couldnt find anything");
            }
            return false;
        }
        private bool PasswordJailbreakMultipleThreads()
        {
            return false;
        } //NOT DONE
        private string GenerateTextForBruteForce(double index, char[] allPossibleChars, int length)
        {
            int baseSize = allPossibleChars.Length;
            char[] result = new char[length];
            for (int i = 0; i < length; i++) //fill every space
            {
                result[i] = allPossibleChars[0];
            }
            int position = length - 1; //Start from the back
            while (index > 0 && position >= 0) //Calculate the next output
            {
                result[position] = allPossibleChars[(long)index % baseSize];
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
                stopJailBreak = true;
                ranOutOfTime = true;
            }
            if (!usingPerformanceMode)
            {
                int triesBetween = (int)(attempts - numberOfAttempsInLastUpdate);
                numberOfAttempsInLastUpdate = attempts;
                //Update Speed
                double speed = triesBetween / 0.016; //16 ms
                labelCurrentSpeed.Text = "Current speed /s:  " + speed;

            }
            //Attempts
            labelAttempts.Text = "Number of attempts: " + attempts;
            //Update Average Speed
            double averageSpeed = attempts / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
            labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed);
            //update progressbar
            progressBar1.Value = progressBar;
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
            else timeToUpdateTheUI.Tick += (s, args) => UpdateTheUIDictionaryAttack(isPerformanceModeOn);
            timeToUpdateTheUI.Start();
        }
        private string ConvertStringToHex(bool hexOutput, string text)
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
            if (timeToUpdateTheUI != null) timeToUpdateTheUI.Stop();
            if (updateTheBruteForceAttack) UpdateTheUIBruteForceAttack(isPerformanceModeOn); //Last update to have the most updated data
            else UpdateTheUIDictionaryAttack(isPerformanceModeOn);
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
                    if (!File.Exists(path + "JailbreakPassword (" + algorithm.ToString() + ")-" + number + ".txt"))
                    {
                        foundName = true;
                        path2 = algorithm.ToString() + "-" + number + ".txt";
                    }
                    else number++;
                }
                //Writing Results
                using (StreamWriter writer = new StreamWriter(path + path2))
                {
                    writer.WriteLine("Algorithm=" + algorithm.ToString());
                    writer.WriteLine("<HASH>");
                    writer.WriteLine("Input hash: " + inputHash);
                    writer.WriteLine("Found hash: " + hasher.Hash(password, algorithm));
                    writer.WriteLine("Password UTF-8: " + password);
                    writer.WriteLine("Password HEX:  " + ConvertStringToHex(true, password));
                }
            }
            MessageBox.Show(message, "Collision Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }      

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            userAbortProcess = true;
        }

        private void ResetAllValues()
        {
            // Reset the boolean flags
            userAbortProcess = false;
            ranOutOfAttemps = false;
            stopJailBreak = false;
            stopDictionaryAttack = false;
            ranOutOfTime = false;

            // Reset progress bar and attempt counters
            progressBar = 0;
            progressBarValueDictionararyAttack = 0;
            numberOfLinesInLastUpdate = 0;
            lineProcessing = 1;
            attempts = 0;
            numberOfAttempsInLastUpdate = 0;

            // Reset stopwatch
            stopwatch.Reset();

            // Reset timers
            if (timeToUpdateTheUI.Enabled)
                timeToUpdateTheUI.Stop();

            // Reset maxAttempts to any desired value
            maxAttempts = 0;
        }
    }
}

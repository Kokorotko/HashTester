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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace HashTester
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }
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
        private Timer updateUITimer;
        ulong numberOfAllPossibleCombinations = 0;
        bool useStopTimer = true;
        private volatile bool ranOutOfTime = false;
        bool useLog = false;

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
            useLog = checkBoxShowLogPassword.Checked;
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
        Hasher.HashingAlgorithm userAlgorithm = new Hasher.HashingAlgorithm();
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
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "-" + userAlgorithm.ToString() + ".txt";
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
                            writer.WriteLine("algorithm==" + userAlgorithm.ToString());
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
                                string hash = hasher.Hash(line, userAlgorithm);
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

        private readonly object lockObject = new object();
        volatile int linesProcessed = 1;
        bool stopDictionaryAttack = false;
        int progressBarValueDictionararyAttack = 0;
        int numberOfLinesInLastUpdate = 0;
        private async void buttonDictionaryAttack_Click(object sender, EventArgs e)
        {
            ResetAllValues();
            TurnOffUI();
            bool useLog = checkBoxListBoxLog.Checked;
            bool performanceMode = checkBoxPerformanceMode.Checked;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
            if (numericUpDownStopTimer.Value == 0) useStopTimer = false;
            else useStopTimer = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Set up
                string firstLine = "";
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    firstLine = reader.ReadLine();
                }
                GetFileAlgorithm(firstLine, out bool inputFileIsInPlainText, out bool reHashNeeded, out bool continueTheAttack, out Hasher.HashingAlgorithm fileAlgorithm);
                if (continueTheAttack)
                {
                    stopwatch.Reset();
                    stopwatch.Start();
                    SetUpTimer(false, false);
                    bool foundHash = false;
                    string stringFoundPassword = "";
                    string userInputHash = textBoxBruteForceInput.Text;
                    long foundPasswordAtLine = -1;
                    if (radioButton5.Checked)
                    {
                        userInputHash = hasher.Hash(textBoxBruteForceInput.Text, userAlgorithm);
                        if (useLog) listBoxLog.Items.Add("Hashing '" + textBoxBruteForceInput.Text + "' into " + userInputHash + ".");
                    }
                    if (performanceMode)
                    {
                        // SetUp
                        int maxThreads = Environment.ProcessorCount;
                        string[] allLines = File.ReadAllLines(openFileDialog.FileName);
                        int totalLinesInFile = allLines.Length;
                        int linesPerThread = totalLinesInFile / maxThreads;
                        List<Task> allTasks = new List<Task>();
                        for (int i = 0; i < maxThreads; i++)
                        {
                            int lineStart = i * linesPerThread;
                            int linesForThisThread;
                            if (i == maxThreads - 1)
                            {
                                linesForThisThread = totalLinesInFile - lineStart;
                            }
                            else
                            {
                                linesForThisThread = linesPerThread;
                            }
                            string[] linesForOneThread = allLines.Skip(lineStart).Take(linesForThisThread).ToArray();
                            allTasks.Add(Task.Run(() =>
                            {
                                bool threadFoundHash = DictionaryAttack(
                                    userInputHash,
                                    fileAlgorithm,
                                    userAlgorithm,
                                    null,  //fileName - useless since we dont work with StreamReader
                                    linesForOneThread,
                                    true, //isMultiThreaded
                                    totalLinesInFile,
                                    lineStart, //at what line to start
                                    useLog,
                                    inputFileIsInPlainText,
                                    reHashNeeded,
                                    out string threadFoundPassword,
                                    out long threadFoundPasswordAtLine);

                                // Handle results
                                if (threadFoundHash)
                                {
                                    lock (lockObject) // Ensure thread safety for shared variables
                                    {
                                        foundHash = true;
                                        stringFoundPassword = threadFoundPassword;
                                        foundPasswordAtLine = threadFoundPasswordAtLine;
                                        userAbortProcess = true; // Stop other threads (yes I dont want to use another bool shut up)
                                    }
                                }
                            }));
                        }

                        await Task.WhenAll(allTasks); // Waits until all tasks finish
                    } // Multi-threading
                    else // Single-thread
                    {
                        await Task.Run(() =>
                        {
                            foundHash = DictionaryAttack(
                                userInputHash,
                                fileAlgorithm,
                                userAlgorithm,
                                openFileDialog.FileName,  //using StreamReader
                                null,  //lines - using StreamReader is more memory efficient
                                false, //isMultiThreaded: nope 
                                0,  //totalLinesInFile: only for multithreading
                                0, //lineStart - we start at the start bruh
                                useLog,
                                inputFileIsInPlainText,
                                reHashNeeded,
                                out stringFoundPassword,
                                out foundPasswordAtLine);
                        });
                    }

                    stopwatch.Stop();
                    StopTimer(false, false);
                    if (useLog) listBoxLog.Items.Add("-----------------------------------------------");
                    if (foundHash)
                    {
                        string s = "Found hash via Dictionary attack" +
                                        "\nOriginal password: " + stringFoundPassword +
                                        "\nOriginal password hash: " + hasher.Hash(textBoxBruteForceInput.Text, userAlgorithm) +
                                        "\nFound password at line: " + (foundPasswordAtLine + 1) +
                                        "\nFound password hash: " + hasher.Hash(stringFoundPassword, userAlgorithm) +
                                        "\nFound password in UTF-8: " + stringFoundPassword +
                                        "\nFound password in HEX: " + ConvertToHexBasedOnUser(true, stringFoundPassword);
                        if (useLog)
                        {
                            listBoxLog.Items.Add("Found hash via Dictionary attack");
                            listBoxLog.Items.Add("Original password: " + stringFoundPassword);
                            listBoxLog.Items.Add("Found password hash: " + hasher.Hash(stringFoundPassword, userAlgorithm));
                            listBoxLog.Items.Add("\nFound password at line: " + (foundPasswordAtLine + 1));
                            listBoxLog.Items.Add("Found password in UTF-8: " + stringFoundPassword);
                            listBoxLog.Items.Add("Found password in HEX: " + ConvertToHexBasedOnUser(true, stringFoundPassword));
                        }
                        PasswordFoundMessageBox(s, userInputHash, stringFoundPassword);
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
                        ranOutOfTime = false;
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
                else if (checkBoxListBoxLog.Checked) listBoxLog.Items.Add("Found invalid file format. Cancelling dictionary attack.");
            }
            else if (useLog) listBoxLog.Items.Add("Could not find desired file. Cancelling dictionary attack...");
            TurnOnUI();
        }
        private bool DictionaryAttack(
            string userInputHash,
            Hasher.HashingAlgorithm fileAlgorithm,
            Hasher.HashingAlgorithm desiredAlgorithm,
            string fileName, // For single-threaded
            string[] lines,  // For multi-threaded
            bool isMultiThreaded,
            long totalLinesInFile, // For multi-threaded
            long lineStart, // For multi-threaded
            bool useLog,
            bool inputFileIsInPlainText,
            bool reHashNeeded,
            out string originalTextOutput,
            out long foundPasswordAtLine)
        {
            originalTextOutput = "";
            foundPasswordAtLine = -1;
            bool foundMatch = false;

            if (!isMultiThreaded)
            {
                totalLinesInFile = File.ReadLines(fileName).Count(); // Count total lines
                using (StreamReader reader = new StreamReader(fileName))
                {
                    long linesProcessed = 0;
                    while (!reader.EndOfStream && !foundMatch && !userAbortProcess)
                    {
                        string fullLine = reader.ReadLine();
                        foundMatch = ProcessLine(
                            fullLine,
                            userInputHash,
                            desiredAlgorithm,
                            inputFileIsInPlainText,
                            reHashNeeded,
                            ref originalTextOutput,
                            ref linesProcessed,
                            totalLinesInFile,
                            useLog);
                    }
                }
            } // Single-threaded
            else
            {
                for (int i = 0; i < lines.Length && !foundMatch && !userAbortProcess; i++)
                {
                    long linesProcessed = Interlocked.Increment(ref lineStart); // Thread-safe increment
                    foundMatch = ProcessLine(
                        lines[i],
                        userInputHash,
                        desiredAlgorithm,
                        inputFileIsInPlainText,
                        reHashNeeded,
                        ref originalTextOutput,
                        ref linesProcessed,
                        totalLinesInFile,
                        useLog);
                }
            }  // Multi-threaded
            return foundMatch;
        }

        private bool ProcessLine(
        string line,
        string userInputHash,
        Hasher.HashingAlgorithm desiredAlgorithm,
        bool inputFileIsInPlainText,
        bool reHashNeeded,
        ref string originalTextOutput,
        ref long linesProcessed,
        long totalLinesInFile,
        bool useLog)
        {
            if (line == null) return false;

            string hashedLine = "";
            string originalText = "";

            if (inputFileIsInPlainText)
            {
                originalText = line;
                hashedLine = hasher.Hash(line, desiredAlgorithm);
            }
            else
            {
                string[] data = line.Split('=');
                if (data.Length > 1)
                {
                    originalText = data[0];
                    hashedLine = reHashNeeded
                        ? hasher.Hash(data[0], desiredAlgorithm)
                        : data[1];
                }
                else
                {
                    if (useLog)
                    {
                        long temp = linesProcessed;
                        Invoke(new Action(() => listBoxLog.Items.Add("Could not process line " + temp)));
                    }
                    return false;
                }
            }

            // Compare hashes
            if (hashedLine == userInputHash)
            {
                originalTextOutput = originalText;
                return true;
            }
            // Update progress
            progressBarValueDictionararyAttack = (int)(((double)linesProcessed / totalLinesInFile) * 100);
            return false;
        }


        private void GetFileAlgorithm(string line, out bool inputFileIsInPlainText, out bool rehashNeeded, out bool continueTheAttack, out Hasher.HashingAlgorithm fileAlgorithm)
        {
            inputFileIsInPlainText = false;
            rehashNeeded = false;
            continueTheAttack = true;
            fileAlgorithm = Hasher.HashingAlgorithm.CRC32;
            if (line != null && line.Contains("=")) // File is already pre-hashed
            {
                if (checkBoxListBoxLog.Checked) listBoxLog.Items.Add("File is already pre-hashed.");
                string[] algorithmText = line.Split('=');
                if (algorithmText.Length < 2)
                {
                    continueTheAttack = false;
                    return;
                }
                switch (algorithmText[1])
                {
                    case "MD5":
                        userAlgorithm = Hasher.HashingAlgorithm.MD5;
                        break;
                    case "SHA1":
                        userAlgorithm = Hasher.HashingAlgorithm.SHA1;
                        break;
                    case "SHA256":
                        userAlgorithm = Hasher.HashingAlgorithm.SHA256;
                        break;
                    case "SHA512":
                        userAlgorithm = Hasher.HashingAlgorithm.SHA512;
                        break;
                    case "RIPEMD160":
                        userAlgorithm = Hasher.HashingAlgorithm.RIPEMD160;
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
                    Invoke(new Action(() => listBoxLog.Items.Add("File is hashed in " + userAlgorithm.ToString() + " algorithm")));
                    if (rehashNeeded) Invoke(new Action(() => listBoxLog.Items.Add("File is not hashed with desired hashing algorithm. Re-hashing.")));
                }
                else Invoke(new Action(() => listBoxLog.Items.Add("File is not pre-hashed.")));
            }
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
            int triesBetween = linesProcessed - numberOfLinesInLastUpdate;
            numberOfLinesInLastUpdate = linesProcessed;
            //Update Speed
            double speed = triesBetween / 0.016; //16 ms
            labelCurrentSpeed.Text = "Current speed /s:  " + speed;
            //Attempts
            labelAttempts.Text = "Number of lines proccessed: " + linesProcessed;
            //Update Average Speed
            double averageSpeed = linesProcessed / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
            labelSpeed.Text = "Average speed /s: " + Math.Floor(averageSpeed);
            //update progressbar
            progressBar1.Value = progressBarValueDictionararyAttack;
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
            bool useLog = checkBoxListBoxLog.Checked;
            if (radioButton5.Checked)
            {
                userPasswordLenght = textBoxBruteForceInput.Text.Length;
                userInputHash = hasher.Hash(textBoxBruteForceInput.Text, userAlgorithm);
                if (useLog)
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
            if (useLog) listBoxLog.Items.Add("Number Of All Possible Combinations: " + numberOfAllPossibleCombinations);
            SetUpTimer(true, performanceMode);
            if (performanceMode)
            {
                //For cancelling all tasks if password is found                
                ushort maxThreads = (ushort)(Environment.ProcessorCount);
                for (ushort i = 0; i < maxThreads; i++) //multiThread
                {
                    ushort threadID = i;
                    allTasks.Add(Task.Run(() => BruteForceAttackMultiThread(userAlgorithm, threadID, maxThreads, userInputHash, usableChars, useMaxAttempts, maxAttempts, userPasswordLenght, variablePasswordLength, useLog, hexOutput, token, out stringFoundPassword, out ranOutOfAttemps)));
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
                    useLog,
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

                if (useLog)
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
            else timeToUpdateTheUI.Tick += (s, args) => UpdateTheUIDictionaryAttack(isPerformanceModeOn);
            timeToUpdateTheUI.Start();
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
            userAbortProcess = true;
        }

        private void ResetAllValues()
        {
            //bool
            userAbortProcess = false;
            ranOutOfAttemps = false;
            userAbortProcess = false;
            stopDictionaryAttack = false;
            ranOutOfTime = false;

            progressBar1.Value = 0;
            progressBarValueDictionararyAttack = 0;
            numberOfLinesInLastUpdate = 0;
            linesProcessed = 1;
            attempts = 0;
            numberOfAttempsInLastUpdate = 0;
            stopwatch.Reset();
            if (timeToUpdateTheUI.Enabled) timeToUpdateTheUI.Stop();
            maxAttempts = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace HashTester
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }
        public enum TaskType
        {
            None,
            RainbowTableGenerator,
            RainbowTableAttack,
            DictionaryAttack,
            BruteForceAttack
        }
        //management
        Timer timerDictionary = new Timer();
        Timer timerRainbowTableGen = new Timer();
        Timer timerRainbowTableAttack = new Timer();
        Timer timerBruteForce = new Timer();

        bool taskCurrentlyWorking = false;
        bool userAbortedTheProcess = false;
        TaskType currentTaskType = TaskType.None;
        Hasher.HashingAlgorithm bruteForceAlgorithm = Hasher.HashingAlgorithm.MD5;
        Hasher.HashingAlgorithm rainbowTableAlgorithm = Hasher.HashingAlgorithm.MD5;
        Hasher hasher = new Hasher();

        #region FormManagement
        private void PasswordForm_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
            #region Languages
            this.Name = Languages.Translate(707);
            labelProgressBar.Text = Languages.Translate(241);
            buttonCancel.Text = Languages.Translate(242);
            labelStatAttempts.Text = Languages.Translate(243) + ":";
            labelStatCurrentSpeed.Text = Languages.Translate(244) + ":";
            labelStatSpeed.Text = Languages.Translate(245) + ":";
            labelStatTimer.Text = Languages.Translate(10009) + ":";
            groupBoxDictionary.Text = Languages.Translate(247);
            groupBoxTimeToCrack.Text = Languages.Translate(248);
            groupBoxRainbowTable.Text = Languages.Translate(249);
            groupBoxBruteForce.Text = Languages.Translate(250);
            //Dictionary Attack
            radioButtonRockYouFull.Text = Languages.Translate(251);
            radioButtonRockYouShort.Text = Languages.Translate(252);
            radioButtonRockYouFullShortShort.Text = Languages.Translate(253);
            radioButtonRockyouCustom.Text = Languages.Translate(254);
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
            groupBoxUI.Text = Languages.Translate(10036);
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

        private bool FindIfTXTIsPresent(string name)
        {
            return File.Exists(Settings.DirectoryPathToWordlists + "\\" + name + ".txt");
        }

        private void GenerateInfoTXT()
        {
            string s =Languages.Translate(273) +": " + "https://github.com/brannondorsey/naive-hashcat/releases/download/data/rockyou.txt \r\nRockYouShort 1mil.\r\nRockYouVeryShort 5k\r\n" + Languages.Translate(274) + Languages.Translate(317);
            string path = Path.Combine(Settings.DirectoryPathToWordlists, "_wordlistInfo.txt");
            File.WriteAllText(path, s);
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
            try
            {
                //time
                int passwordLinesProcessedBetweenUpdates = (int)(passwordCheck.CurrentLine - passwordCheckLinesProcessedLastUpdate);
                passwordCheckLinesProcessedLastUpdate = passwordCheck.CurrentLine;
                labelStatTimer.Text = Languages.Translate(10009) + ": " + (passwordCheck.Stopwatch.ElapsedMilliseconds / 1000 + "." + passwordCheck.Stopwatch.ElapsedMilliseconds % 1000);
                //current speed
                double currentSpeed = passwordLinesProcessedBetweenUpdates / (Settings.UpdateUIms / 1000.0);
                labelStatCurrentSpeed.Text = Languages.Translate(244) + ": " + currentSpeed.ToString("#,0");
                //average speed
                double elapsedSeconds = passwordCheck.Stopwatch.ElapsedMilliseconds / 1000.0;
                double averageSpeed = elapsedSeconds > 0 ? passwordCheck.CurrentLine / elapsedSeconds : 0;
                if (!double.IsInfinity(averageSpeed)) labelStatSpeed.Text = Languages.Translate(245) + ": " + Math.Floor(averageSpeed).ToString("#,0");
                else labelStatSpeed.Text = Languages.Translate(245) + ": " + Languages.Translate(275);
                //attemps
                labelStatAttempts.Text = Languages.Translate(276) + ": " + passwordCheck.CurrentLine.ToString("#,0");
                //progress
                progressBar1.Value = passwordCheck.Progress;
                //log
                foreach (string temp in passwordCheck.LogOutput)
                {
                    listBoxLog.Items.Add(temp);
                }
                passwordCheck.LogOutput.Clear();
            }
            catch (Exception ex)
            {
                if (!(ex is DivideByZeroException)) Console.WriteLine("UpdateUIPassword has an error: " + ex.Message); //Yeah it just tries to divide 0 on the start its okay its fine it can handle it
                return;
            }
        }
        private async void buttonCheckPassword_Click(object sender, EventArgs e)
        {
            string pathToFile = "";
            taskCurrentlyWorking = true;
            currentTaskType = TaskType.DictionaryAttack;
            TurnOffUI();
            string messageBoxAnswer = "";
            bool continueToChecker = true;
            string[] passwords = textBoxDictionary.Lines;           
            //Decider of what txt to use
            if (radioButtonRockYouFull.Checked)
            {
                pathToFile = Settings.DirectoryPathToWordlists + "\\" + "rockyou.txt";
            }
            else if (radioButtonRockYouShort.Checked)
            {
                pathToFile = Settings.DirectoryPathToWordlists + "\\" + "rockyouShort.txt";
            }
            else if (radioButtonRockYouFullShortShort.Checked)
            {
                pathToFile = Settings.DirectoryPathToWordlists + "\\" + "rockyouVeryShort.txt";
            }
            else
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = Settings.DirectoryPathToWordlists;
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
                timerDictionary.Interval = Settings.UpdateUIms;
                timerDictionary.Tick += UpdateUIPassword;
                timerDictionary.Start();
                await Task.Run(() => { passwordCheck.PasswordFinder(pathToFile, passwords); });
                timerDictionary.Stop();
                timerDictionary.Dispose();
                UpdateUIPassword(sender, e);
                progressBar1.Value = 100;
                if (passwordCheck.UserAbandoned)
                {
                    if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(Languages.Translate(279));
                    MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TurnOnUI();
                    return; //cancels
                }
                //Console.WriteLine("passwordCheck.FoundMatch[i]: " + passwordCheck.FoundMatch.Count);
                //Console.WriteLine("passwords count " + passwords.Count)
                for (int i = 0; i < passwords.Count(); i++)
                {
                    if (passwordCheck.FoundMatch[i])
                    {
                        string temp = Languages.Translate(280) + " '" + passwords[i] + "' " + Languages.Translate(281) + " " + passwordCheck.LineFoundMatch[i] + ". " + Languages.Translate(282) + Environment.NewLine;
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
            currentTaskType = TaskType.None;
            TurnOnUI();
        }                                 

        #endregion

        #region Password Strenght Calculator 
        private void buttonCrackCalculate_Click(object sender, EventArgs e)
        {
            int numberOfChars = 0;
            if (checkBoxCrackLower.Checked) numberOfChars += 26;
            if (checkBoxCrackUpper.Checked) numberOfChars += 26;
            if (checkBoxCrackDigit.Checked) numberOfChars += 10;
            if (checkBoxCrackSpecial.Checked) numberOfChars += 33;

            ulong passwordLenght;
            if (!ulong.TryParse(textBoxCrackLenght.Text, out passwordLenght)) passwordLenght = (ulong)textBoxCrackLenght.Text.Length;
            if (passwordLenght > 1000)
            {
                passwordLenght = 1000;
                MessageBox.Show(Languages.Translate(284));
                if (checkBoxShowLogCrack.Checked) listBoxLog.Items.Add(Languages.Translate(285));
            }
            if (passwordLenght <= 0)
            {
                MessageBox.Show(Languages.Translate(11002));
                return;
            }
            BigInteger speed = 0;
            if (!BigInteger.TryParse(textBoxCrackSpeed.Text, out speed))
            {
                MessageBox.Show(Languages.Translate(11001));
                return;
            }

            BigInteger totalCombinations = PasswordStrenghtCalculator.Calculator(passwordLenght, (ulong)numberOfChars, speed, out BigInteger timeInSec, out bool overflowed);
            //Output
            if (!overflowed) 
            {
                if (checkBoxShowLogCrack.Checked)
                {
                    listBoxLog.Items.Add(PasswordStrenghtCalculator.Output(timeInSec));
                    listBoxLog.Items.Add(Languages.Translate(287) + ": " + totalCombinations.ToString("N0"));
                }
                MessageBox.Show(PasswordStrenghtCalculator.Output(timeInSec) + Environment.NewLine + Languages.Translate(287) + ": " + totalCombinations.ToString("N0"));
            }
            else 
            {
                if (checkBoxShowLogCrack.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(286));
                }
                MessageBox.Show(Languages.Translate(286));
            }
        }
        #endregion

        #region Rainbow Table

        RainbowTable rainbowTable = new RainbowTable();
        private async void buttonPreHash_Click(object sender, EventArgs e) //Dont Mind its called PreHash its Rainbow Table Generator
        {
            taskCurrentlyWorking = true;
            currentTaskType = TaskType.RainbowTableGenerator;
            TurnOffUI();        
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.DirectoryPathToWordlists;
            //Timer
            timerRainbowTableGen.Interval = Settings.UpdateUIms;
            timerRainbowTableGen.Tick += UpdateUIRainbowTable;
            timerRainbowTableGen.Enabled = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                saveFileDialog.FileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName) + "-" + rainbowTableAlgorithm.ToString() + ".txt";
                saveFileDialog.Filter = "Text files (*.txt)|*.txt"; // Only allow .txt files

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {                    
                    timerRainbowTableGen.Start();
                    //MultiThread
                    if (checkBoxPerformanceModeRainbowTable.Checked && FormManagement.UseMultiThread())
                    {
                        int numberOfThreadsToUse = FormManagement.NumberOfThreadsToUse();
                        Console.WriteLine("Number of threads: " + numberOfThreadsToUse);
                        if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(10026) + ": "  + numberOfThreadsToUse);
                        bool output = false;
                        await Task.Run(() =>
                        {
                            output = rainbowTable.GenerateRainbowTableMultiThread(numberOfThreadsToUse, openFileDialog.FileName, saveFileDialog.FileName, rainbowTableAlgorithm);
                        });
                        
                        if (output)
                        {
                            timerRainbowTableGen.Stop();
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(Languages.Translate(288));
                        }
                        else
                        {
                            timerRainbowTableGen.Stop();
                            if (!userAbortedTheProcess)
                            {
                                string s = Languages.Translate(289);
                                if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                                MessageBox.Show(s);
                            }
                        }
                    }
                    //Single Thread
                    else
                    {
                        bool operationWasSuccesful = false;
                        await Task.Run(() =>
                        {
                            operationWasSuccesful = rainbowTable.GenerateRainbowTable(openFileDialog.FileName, saveFileDialog.FileName, rainbowTableAlgorithm);
                        });

                        if (operationWasSuccesful)
                        {
                            timerRainbowTableGen.Stop();
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                            MessageBox.Show(Languages.Translate(288));
                        }
                        else
                        {
                            timerRainbowTableGen.Stop();
                            if (!userAbortedTheProcess)
                            {
                                string s = Languages.Translate(289);
                                if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(rainbowTable.LogOutput);
                                MessageBox.Show(s);
                            }
                        }
                    }
                }
            }
            else
            {
                timerRainbowTableGen.Stop();
                MessageBox.Show(Languages.Translate(290));
                if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(290));
            }
            TurnOnUI();
            FilesCleanUp("InputSplit");
            FilesCleanUp("Temp");
            taskCurrentlyWorking = false;
            currentTaskType = TaskType.None;
        }

        private long numberOfAttemptsInLastUpdateRainbowTable = 0;
        private void UpdateUIRainbowTable(object sender, EventArgs e)
        {
            try
            {
                if (rainbowTable.Stopwatch != null)
                {                    
                    if (rainbowTable.Stopwatch.ElapsedMilliseconds > 0 && rainbowTable.LinesProcessed > 0 && rainbowTable.AllLinesInInputFile > 0)
                    {                        
                        double speed = (rainbowTable.LinesProcessed - numberOfAttemptsInLastUpdateRainbowTable) / (Settings.UpdateUIms / 1000.0);
                        int progress = (int)((double)rainbowTable.LinesProcessed / rainbowTable.AllLinesInInputFile * 100);
                        numberOfAttemptsInLastUpdateRainbowTable = rainbowTable.LinesProcessed;
                        labelStatTimer.Text = Languages.Translate(10009) + ": " + rainbowTable.Stopwatch.ElapsedMilliseconds / 1000 + "." + rainbowTable.Stopwatch.ElapsedMilliseconds % 1000;
                        double averageSpeed = Math.Floor(rainbowTable.LinesProcessed / (rainbowTable.Stopwatch.ElapsedMilliseconds / 1000.0));
                        labelStatSpeed.Text = Languages.Translate(10012) + " /s: " + averageSpeed;
                        labelStatCurrentSpeed.Text = Languages.Translate(10011) + " /s: " + speed.ToString();
                        progressBar1.Value = Math.Min(100, progress);
                        //Refresh - The Labels dont update for some reason
                        labelStatTimer.Refresh();
                        labelStatSpeed.Refresh();
                        labelStatCurrentSpeed.Refresh();
                    }
                }
            }
            catch (DivideByZeroException) //it does that dont worry
            {
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in UpdateUITable: " + ex.Message);
                return;
            }
        }

        #endregion

        #region Rainbow Table Attack  
        RainbowTableAttack rainbowTableAttack = new RainbowTableAttack();
        private async void buttonRainbowTableAttack_Click(object sender, EventArgs e)
        {
            try
            {
                timerRainbowTableAttack.Interval = Settings.UpdateUIms;
                timerRainbowTableAttack.Tick += (s, args) => UpdateTheUIRainbowTableAttack();
                TurnOffUI();
                taskCurrentlyWorking = true;
                currentTaskType = TaskType.RainbowTableAttack;
                string originalInput = textBoxRainbowTable.Text;
                if (radioButtonRegularBruteForce.Checked) originalInput = hasher.Hash(originalInput, rainbowTableAlgorithm);                    
                rainbowTableAttack.PerformanceMode = checkBoxPerformanceModeRainbowTable.Checked;
                OpenFileDialog openFileDialog = new OpenFileDialog { InitialDirectory = Settings.DirectoryPathToWordlists };               
                rainbowTableAttack.UseStopTimer = numericUpDownStopTimer.Value != 0;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    timerRainbowTableAttack.Start();
                    bool noErrorsFound = await rainbowTableAttack.PerformRainbowAttack(openFileDialog.FileName, originalInput, rainbowTableAlgorithm, (long)numericUpDownStopTimer.Value, (long)numericUpDownMaxAttempts.Value);
                    if (noErrorsFound)
                    {
                        if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add("-----------------------------------------------");                           
                        if (rainbowTableAttack.FoundPasswordBool)
                        {
                            string foundPassword = rainbowTableAttack.FoundPassword;
                            string foundPasswordHash = hasher.Hash(foundPassword, rainbowTableAlgorithm);
                            long foundAtLine = rainbowTableAttack.FoundPasswordAtLine + 1;
                            string message = Languages.Translate(316) + "\n" +
                                    Languages.Translate(292) + ": " + foundPassword + "\n" +
                                    Languages.Translate(293) + ": " + originalInput + "\n" +
                                    Languages.Translate(294) + ": " + foundAtLine + "\n" +
                                    Languages.Translate(295) + ": " + foundPasswordHash + "\n" +
                                    Languages.Translate(296) + ": " + foundPassword + "\n" +
                                    Languages.Translate(297) + ": " + ConvertToHexBasedOnUser(foundPassword);
                            if (checkBoxShowLogRainbowTable.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(316));
                                listBoxLog.Items.Add(Languages.Translate(292) + ": " + foundPassword);
                                listBoxLog.Items.Add(Languages.Translate(295) + ": " + originalInput);
                                listBoxLog.Items.Add(Languages.Translate(294) + ": " + foundAtLine);
                                listBoxLog.Items.Add(Languages.Translate(296) + ": " + foundPassword);
                                listBoxLog.Items.Add(Languages.Translate(297) + ": " + ConvertToHexBasedOnUser(foundPassword));
                            }
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();                                
                            PasswordFoundMessageBox(message, originalInput, foundPassword);
                        }
                        //abort
                        else if (rainbowTableAttack.CancelTokenActive())
                        {
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(279));                                
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                        //ran out of time
                        else if (rainbowTableAttack.RanOutOfTime)
                        {
                            MessageBox.Show(Languages.Translate(298), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(298));
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                        //ran out of attempts
                        else if (rainbowTableAttack.RanOutOfAttempts)
                        {
                            MessageBox.Show(Languages.Translate(299), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(299));
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                        //didnt find
                        else
                        {
                            MessageBox.Show(Languages.Translate(300), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(300));
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                    }
                    //failed
                    else
                    {
                        MessageBox.Show(Languages.Translate(301), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(301));
                        if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                    }
                }
                else
                {
                    if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(302));
                    if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                }
                if (timerRainbowTableAttack != null) timerRainbowTableAttack.Dispose();
                TurnOnUI();
                taskCurrentlyWorking = false;
                currentTaskType = TaskType.None;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Languages.Translate(11000) + Environment.NewLine + ex.Message, Languages.Translate(10020),MessageBoxButtons.OK, MessageBoxIcon.Error);
                TurnOnUI();
                FilesCleanUp("InputSplit");
                FilesCleanUp("Temp");
                taskCurrentlyWorking = false;
                currentTaskType = TaskType.None;
            }
        }

        long RainbowAttacknumberOfLinesInLastUpdate = 0;

        private void UpdateTheUIRainbowTableAttack()
        {
            try
            {
                if (rainbowTableAttack.Stopwatch != null)
                {                  
                    long currentLinesProcessed = rainbowTableAttack.LinesProcessed;
                    int triesBetween = (int)(currentLinesProcessed - RainbowAttacknumberOfLinesInLastUpdate);
                    RainbowAttacknumberOfLinesInLastUpdate = currentLinesProcessed;

                    //Timer
                    labelStatTimer.Text = Languages.Translate(10009) + ": " + rainbowTableAttack.Stopwatch.ElapsedMilliseconds / 1000 + "." + rainbowTableAttack.Stopwatch.ElapsedMilliseconds % 1000;

                    // Speed Calculation
                    double speed = triesBetween / (Settings.UpdateUIms / 1000.0);
                    labelStatCurrentSpeed.Text = Languages.Translate(10001) + "/s: " + speed.ToString("#,0");
                    labelStatAttempts.Text = Languages.Translate(303) + ": " + currentLinesProcessed.ToString("#,0");

                    // Average Speed Calculation
                    double averageSpeed = 0;
                    if (rainbowTableAttack.Stopwatch.ElapsedMilliseconds != 0) averageSpeed = currentLinesProcessed / (rainbowTableAttack.Stopwatch.ElapsedMilliseconds / 1000.0);
                    labelStatSpeed.Text = Languages.Translate(10012) + "/s: " + Math.Floor(averageSpeed).ToString("#,0");

                    // Progress Bar Update
                    int progress = 0;
                    if (rainbowTableAttack.TotalLinesInFile != 0) progress = (int)((double)currentLinesProcessed / rainbowTableAttack.TotalLinesInFile * 100);
                    progressBar1.Value = Math.Max(0, Math.Min(progress, 100)); //<0-100>

                    // Log
                    if (rainbowTableAttack.LogOutput != null)
                    {
                        List<string> logs = rainbowTableAttack.LogOutput.ToList(); //avoid reading LogOutput while its being changed
                        rainbowTableAttack.LogReset(); // Clear logs after adding them
                        foreach (string logEntry in logs) listBoxLog.Items.Add(logEntry);
                    }
                }
            }
            catch (DivideByZeroException) //it does that dont worry
            {
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in UpdateUI Rainbow Table Attack: " + ex.Message);
                return;
            }
        }

        #endregion

        #region Password BruteForce Attack - Done

        BruteForceAttack bruteForce = new BruteForceAttack();
        private async void buttonBruteForceAttack_Click(object sender, EventArgs e)
        {
            taskCurrentlyWorking = true;
            currentTaskType = TaskType.BruteForceAttack;
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
            timerBruteForce.Interval = Settings.UpdateUIms;
            timerBruteForce.Tick += UpdateTheUIBruteForceAttack;            
            //Task Set Up                
            List<Task> allTasks = new List<Task>();
            //Console.WriteLine("UserPasswordLenght: " + userPasswordLenght);
            long temp = bruteForce.CalculateAllPossibleCombinations(checkBoxUnknownLenghtBruteForce.Checked, (int)numericUpDownLenght.Value);
            if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add(Languages.Translate(304) + ": " + temp);
            if (checkBoxPerformanceModeBruteForce.Checked && FormManagement.UseMultiThread())
            {
                timerBruteForce.Start();
                Console.WriteLine(Languages.Translate(305));
                bruteForce.BruteForceAttackMultiThread(bruteForceAlgorithm, userHashInput, (ulong)numericUpDownMaxAttempts.Value, userPasswordLenght, (long)numericUpDownStopTimer.Value);
            }
            else //single Thread
            {
                Console.WriteLine(Languages.Translate(306));
                timerBruteForce.Start();
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
            timerBruteForce.Stop();
            timerBruteForce.Dispose();
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
            currentTaskType = TaskType.None;
            TurnOnUI();
        }
        private long numberOfAttemptsInLastUpdateBruteForce = 0;
        private void UpdateTheUIBruteForceAttack(object sender, EventArgs e)
        {
            try
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
            catch (DivideByZeroException) //it does that dont worry
            {
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR in UpdateUITable brute force attack: " + ex.Message);
                return;
            }
        }       
        #endregion

        private void TurnOffUI() //Turns off everything except the labels
        {
            foreach (Control control in this.Controls)
            {
                if (control is GroupBox box)
                {
                    foreach (Control child in box.Controls)
                    {
                        if (!(child is Label)) child.Enabled = false;
                    }
                }
                else if (!(control is Label)) control.Enabled = false;                
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
            userAbortedTheProcess = false; //yes I reset it here shut
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
                string path = Path.GetFullPath(Settings.DirectoryPathToWordlists);
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
            MessageBox.Show(message, Languages.Translate(307), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonCancel_Click(object sender, EventArgs e) //Abort
        {
            if (taskCurrentlyWorking)
            {
                userAbortedTheProcess = true;
                switch (currentTaskType)
                {
                    case TaskType.RainbowTableGenerator:
                        {
                            timerRainbowTableGen.Dispose();
                            rainbowTable.Abort();
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(279));
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.RainbowTableAttack:
                        {
                            timerRainbowTableAttack.Dispose();
                            rainbowTableAttack.Abort();
                            if (checkBoxShowLogRainbowTable.Checked) listBoxLog.Items.Add(Languages.Translate(279));
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.DictionaryAttack:
                        {
                            timerDictionary.Dispose();
                            passwordCheck.Abort();
                            if (checkBoxShowLogDictionary.Checked) listBoxLog.Items.Add(Languages.Translate(279));
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.BruteForceAttack:
                        {
                            timerBruteForce.Dispose();
                            bruteForce.Abort();
                            if (checkBoxShowLogBrute.Checked) listBoxLog.Items.Add(Languages.Translate(279));
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.None:
                        {
                            MessageBox.Show(Languages.Translate(315), Languages.Translate(20), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
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

        private void FilesCleanUp(string nameOfFilesToClear)
        {
            string[] files = Directory.GetFiles(Settings.DirectoryPathToWordlists);
            foreach (string file in files)
            {
                if (file.Contains(nameOfFilesToClear)) File.Delete(file);
            }
        }
    }
}

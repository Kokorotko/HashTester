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
        Hasher.HashingAlgorithm dictionaryAlgorithm = Hasher.HashingAlgorithm.MD5;
        Hasher hasher = new Hasher();

        #region FormManagement
        private void PasswordForm_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
            #region Languages
            this.Name = Languages.Translate(707);
            labelAlgorithm.Text = Languages.Translate(10024);
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
            radioButtonHashedDictionary.Text = Languages.Translate(265);
            radioButtonRegularDictionary.Text = Languages.Translate(264);
            radioButtonRockYouFull.Text = Languages.Translate(251);
            radioButtonRockYouShort.Text = Languages.Translate(252);
            radioButtonRockYouFullShortShort.Text = Languages.Translate(253);
            radioButtonRockyouCustom.Text = Languages.Translate(254);
            //Time to crack calculator
            labelCrackLenght.Text = Languages.Translate(256) + "/" + Languages.Translate(257);
            labelCrackSpeed.Text = Languages.Translate(258);
            checkBoxCrackLower.Text = Languages.Translate(259) + " (26)";
            checkBoxCrackUpper.Text = Languages.Translate(260) + " (26)";
            checkBoxCrackDigit.Text = Languages.Translate(261) + " (10)";
            checkBoxCrackSpecial.Text = Languages.Translate(262) + " (33)";
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
            hashSelector.SelectedIndex = 0;
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
        DictionaryAttack dictionaryAttack = new DictionaryAttack();
        long passwordCheckLinesProcessedLastUpdate = 0;
        private void UpdateUIPassword(object sender, EventArgs e)
        {
            try
            {
                //time
                int passwordLinesProcessedBetweenUpdates = (int)(dictionaryAttack.CurrentLine - passwordCheckLinesProcessedLastUpdate);
                passwordCheckLinesProcessedLastUpdate = dictionaryAttack.CurrentLine;
                labelStatTimer.Text = Languages.Translate(10009) + ": " + (dictionaryAttack.Stopwatch.ElapsedMilliseconds / 1000 + "." + dictionaryAttack.Stopwatch.ElapsedMilliseconds % 1000);
                //current speed
                double currentSpeed = passwordLinesProcessedBetweenUpdates / (Settings.UpdateUIms / 1000.0);
                labelStatCurrentSpeed.Text = Languages.Translate(244) + ": " + currentSpeed.ToString("#,0");
                //average speed
                double elapsedSeconds = dictionaryAttack.Stopwatch.ElapsedMilliseconds / 1000.0;
                double averageSpeed = elapsedSeconds > 0 ? dictionaryAttack.CurrentLine / elapsedSeconds : 0;
                if (!double.IsInfinity(averageSpeed)) labelStatSpeed.Text = Languages.Translate(245) + ": " + Math.Floor(averageSpeed).ToString("#,0");
                else labelStatSpeed.Text = Languages.Translate(245) + ": " + Languages.Translate(275);
                //attemps
                labelStatAttempts.Text = Languages.Translate(276) + ": " + dictionaryAttack.CurrentLine.ToString("#,0");
                //progress
                progressBar1.Value = dictionaryAttack.Progress;
                //log
                foreach (string temp in dictionaryAttack.LogOutput)
                {
                    listBoxLog.Items.Add(temp);
                }
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                dictionaryAttack.LogOutput.Clear();
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
                        if (checkBoxShowLog.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(277) + ": " + pathToFile);
                            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                        }
                    }
                    else
                    {
                        if (checkBoxShowLog.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(278));
                            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                        }
                        continueToChecker = false;
                    }
                }
            }
            if (continueToChecker)
            {
                timerDictionary.Interval = Settings.UpdateUIms;
                timerDictionary.Tick += UpdateUIPassword;
                timerDictionary.Start();
                if (radioButtonRegularDictionary.Checked)
                {
                    await Task.Run(() => { dictionaryAttack.MultiplePasswordFinder(pathToFile, passwords); });
                }
                else
                {
                    await Task.Run(() => { dictionaryAttack.MultiplePasswordBreaker(pathToFile, passwords, dictionaryAlgorithm); });
                }
                timerDictionary.Stop();
                timerDictionary.Dispose();
                UpdateUIPassword(sender, e);
                progressBar1.Value = 100;
                if (dictionaryAttack.UserAbandoned)
                {
                    if (checkBoxShowLog.Checked)
                    {
                        listBoxLog.Items.Add(Languages.Translate(279));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TurnOnUI();
                    return; //cancels
                }
                //Console.WriteLine("passwordCheck.FoundMatch[i]: " + passwordCheck.FoundMatch.Count);
                //Console.WriteLine("passwords count " + passwords.Count)
                for (int i = 0; i < passwords.Count(); i++)
                {
                    if (dictionaryAttack.FoundMatch[i])
                    {
                        string temp = Languages.Translate(280) + " " + dictionaryAttack.FoundPassword[i] + " " + Languages.Translate(281) + " " + dictionaryAttack.LineFoundMatch[i] + ". " + Languages.Translate(282) + Environment.NewLine;
                        messageBoxAnswer += temp;
                        if (checkBoxShowLog.Checked)
                        {
                            listBoxLog.Items.Add(temp);
                            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                        }
                    }
                    else
                    {
                        string temp = Languages.Translate(280) + "' " + passwords[i] + "' " + Languages.Translate(283) + Environment.NewLine;
                        messageBoxAnswer += temp;
                        if (checkBoxShowLog.Checked)
                        {
                            listBoxLog.Items.Add(temp);
                            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                        }
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
            try
            {
                int numberOfChars = 0;
                if (checkBoxCrackLower.Checked) numberOfChars += 26;
                if (checkBoxCrackUpper.Checked) numberOfChars += 26;
                if (checkBoxCrackDigit.Checked) numberOfChars += 10;
                if (checkBoxCrackSpecial.Checked) numberOfChars += 33;

                int passwordLenght;
                if (!int.TryParse(textBoxCrackLenght.Text, out passwordLenght)) passwordLenght = textBoxCrackLenght.Text.Length;
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

                BigInteger totalCombinations = PasswordStrenghtCalculator.Calculator(passwordLenght, numberOfChars, speed, out BigInteger timeInSec, out bool overflowed);
                //Output
                if (!overflowed)
                {
                    if (checkBoxShowLog.Checked)
                    {
                        listBoxLog.Items.Add(PasswordStrenghtCalculator.Output(timeInSec));
                        listBoxLog.Items.Add(Languages.Translate(287) + ": " + totalCombinations.ToString("N0"));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    MessageBox.Show(PasswordStrenghtCalculator.Output(timeInSec) + Environment.NewLine + Languages.Translate(287) + ": " + totalCombinations.ToString("N0"));
                }
                else
                {
                    if (checkBoxShowLog.Checked)
                    {
                        listBoxLog.Items.Add(Languages.Translate(286));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    MessageBox.Show(Languages.Translate(286));
                }
            }
            catch (Exception ex)
            {
                string s = Languages.Translate(11000) + Environment.NewLine + ex.Message;
                if (checkBoxShowLog.Checked)
                {
                    listBoxLog.Items.Add(s);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(s, Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
        #endregion

        #region Rainbow Table

        RainbowTableGenerator rainbowTable = new RainbowTableGenerator();
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
                    if (checkBoxPerformanceMode.Checked && FormManagement.UseMultiThread())
                    {
                        int numberOfThreadsToUse = FormManagement.NumberOfThreadsToUse();
                        Console.WriteLine("Number of threads: " + numberOfThreadsToUse);
                        if (checkBoxShowLog.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(10026) + ": " + numberOfThreadsToUse);
                            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                        }
                        bool output = false;
                        await Task.Run(() =>
                        {
                            output = rainbowTable.GenerateRainbowTableMultiThread(numberOfThreadsToUse, openFileDialog.FileName, saveFileDialog.FileName, rainbowTableAlgorithm).Result;
                        });
                        
                        if (output)
                        {
                            timerRainbowTableGen.Stop();
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(rainbowTable.LogOutput);
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            MessageBox.Show(Languages.Translate(288));
                        }
                        else
                        {
                            timerRainbowTableGen.Stop();
                            if (!userAbortedTheProcess)
                            {
                                string s = Languages.Translate(289);
                                if (checkBoxShowLog.Checked)
                                {
                                    listBoxLog.Items.Add(rainbowTable.LogOutput);
                                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                                }
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
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(rainbowTable.LogOutput);
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            MessageBox.Show(Languages.Translate(288));
                        }
                        else
                        {
                            timerRainbowTableGen.Stop();
                            if (!userAbortedTheProcess)
                            {
                                string s = Languages.Translate(289);
                                if (checkBoxShowLog.Checked)
                                {
                                    listBoxLog.Items.Add(rainbowTable.LogOutput);
                                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                                }
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
                if (checkBoxShowLog .Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(290));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
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
                if (radioButtonRegularRainbowTable.Checked) originalInput = hasher.Hash(originalInput, rainbowTableAlgorithm);                    
                OpenFileDialog openFileDialog = new OpenFileDialog { InitialDirectory = Settings.DirectoryPathToWordlists };               
                rainbowTableAttack.UseStopTimer = numericUpDownStopTimer.Value != 0;
                DialogResult dialogResult = openFileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    timerRainbowTableAttack.Start();
                    bool noErrorsFound = await rainbowTableAttack.PerformRainbowAttack(openFileDialog.FileName, originalInput, rainbowTableAlgorithm, (long)numericUpDownStopTimer.Value, (long)numericUpDownMaxAttempts.Value);
                    if (noErrorsFound)
                    {
                        if (checkBoxShowLog.Checked) listBoxLog.Items.Add("-----------------------------------------------");                           
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
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(316));
                                listBoxLog.Items.Add(Languages.Translate(292) + ": " + foundPassword);
                                listBoxLog.Items.Add(Languages.Translate(295) + ": " + originalInput);
                                listBoxLog.Items.Add(Languages.Translate(294) + ": " + foundAtLine);
                                listBoxLog.Items.Add(Languages.Translate(296) + ": " + foundPassword);
                                listBoxLog.Items.Add(Languages.Translate(297) + ": " + ConvertToHexBasedOnUser(foundPassword));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();                                
                            PasswordFoundMessageBox(message, originalInput, foundPassword);
                        }
                        //abort
                        else if (rainbowTableAttack.CancelTokenActive())
                        {
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(279));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                        //ran out of time
                        else if (rainbowTableAttack.RanOutOfTime)
                        {
                            MessageBox.Show(Languages.Translate(298), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(298));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                        //ran out of attempts
                        else if (rainbowTableAttack.RanOutOfAttempts)
                        {
                            MessageBox.Show(Languages.Translate(299), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(299));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                        //didnt find
                        else
                        {
                            MessageBox.Show(Languages.Translate(300), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(300));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                        }
                    }
                    //failed
                    else
                    {
                        MessageBox.Show(Languages.Translate(301), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (checkBoxShowLog.Checked)
                        {
                            listBoxLog.Items.Add(Languages.Translate(301));
                            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                        }
                        if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                    }
                }
                else if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.Abort)
                {
                    if (checkBoxShowLog.Checked)
                    {
                        listBoxLog.Items.Add(Languages.Translate(318));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    if (timerRainbowTableAttack != null) timerRainbowTableAttack.Stop();
                    MessageBox.Show(Languages.Translate(318), Languages.Translate(436), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (checkBoxShowLog.Checked)
                    {
                        listBoxLog.Items.Add(Languages.Translate(302));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
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
                    labelStatCurrentSpeed.Text = Languages.Translate(10011) + " /s: " + speed.ToString("#,0");
                    labelStatAttempts.Text = Languages.Translate(303) + ": " + currentLinesProcessed.ToString("#,0");

                    // Average Speed Calculation
                    double averageSpeed = 0;
                    if (rainbowTableAttack.Stopwatch.ElapsedMilliseconds != 0) averageSpeed = currentLinesProcessed / (rainbowTableAttack.Stopwatch.ElapsedMilliseconds / 1000.0);
                    labelStatSpeed.Text = Languages.Translate(10012) + " /s: " + Math.Floor(averageSpeed).ToString("#,0");

                    // Progress Bar Update
                    int progress = 0;
                    if (rainbowTableAttack.TotalLinesInFile != 0) progress = (int)((double)currentLinesProcessed / rainbowTableAttack.TotalLinesInFile * 100);
                    progressBar1.Value = Math.Max(0, Math.Min(progress, 100)); //<0-100>

                    // Log
                    if (rainbowTableAttack.LogOutput != null && checkBoxShowLog.Checked)
                    {
                        List<string> logs = rainbowTableAttack.LogOutput.ToList(); //avoid reading LogOutput while its being changed
                        rainbowTableAttack.LogReset(); // Clear logs after adding them
                        foreach (string logEntry in logs) listBoxLog.Items.Add(logEntry);
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
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
                if (checkBoxShowLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(0) + " '" + textBoxBruteForce.Text + "' " + Languages.Translate(10027) + " " + userHashInput + ".");
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
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
            BigInteger temp = bruteForce.CalculateAllPossibleCombinations(checkBoxUnknownLenghtBruteForce.Checked, (int)numericUpDownLenght.Value);
            if (checkBoxShowLog.Checked)
            {
                listBoxLog.Items.Add(Languages.Translate(304) + ": " + temp.ToString("N0"));
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
            //multi thread
            if (checkBoxPerformanceMode.Checked && FormManagement.UseMultiThread())
            {                
                Console.WriteLine(Languages.Translate(305));
                timerBruteForce.Start();
                await Task.Run(() => bruteForce.BruteForceAttackMultiThread(
                    bruteForceAlgorithm, //algorithm
                    userHashInput, //input
                    (ulong)numericUpDownMaxAttempts.Value, //maxAttempts
                    userPasswordLenght, //password lenght (0 if more)
                    checkBoxUnknownLenghtBruteForce.Checked, 
                    (ulong)numericUpDownStopTimer.Value)); //Time to stop in sec.                
            }
            //single Thread
            else
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
                    (ulong)numericUpDownStopTimer.Value,
                    //next is completely useless for single thread
                    0, //start Index
                    temp)); //end Index
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

                if (checkBoxShowLog.Checked)
                {
                    listBoxLog.Items.Add("----------------------------");
                    listBoxLog.Items.Add(Languages.Translate(307));
                    listBoxLog.Items.Add(Languages.Translate(308) + ": " + userHashInput);
                    listBoxLog.Items.Add(Languages.Translate(309) + ": " + hasher.Hash(bruteForce.FoundPassword, bruteForceAlgorithm));
                    listBoxLog.Items.Add(Languages.Translate(310) + ": " + bruteForce.FoundPassword);
                    listBoxLog.Items.Add(Languages.Translate(311) + ": " + ConvertToHexBasedOnUser(bruteForce.FoundPassword));
                    listBoxLog.Items.Add(Languages.Translate(120) + ": " + bruteForce.Attempts);
                    try
                    {
                        string s = Languages.Translate(10009) + ": " + labelStatTimer.Text.Split(' ')[1];
                        listBoxLog.Items.Add(s);
                    }
                    catch
                    {
                        listBoxLog.Items.Add(Languages.Translate(10009) + ": " + Languages.Translate(10040));
                    }
                    listBoxLog.Items.Add(Languages.Translate(10012) + ": " + labelStatSpeed.Text);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                PasswordFoundMessageBox(message, userHashInput, bruteForce.FoundPassword);
            }
            else if (bruteForce.RanOutOfAttemps)
            {
                if (checkBoxShowLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(312));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(Languages.Translate(312), Languages.Translate(10019), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (bruteForce.RanOutOfTime)
            {
                if (checkBoxShowLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(312));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(Languages.Translate(312), Languages.Translate(10019), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (bruteForce.UserAborted)
            {
                //yeah, programmer 100
            }
            else
            {
                if (checkBoxShowLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(313));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
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
                if (bruteForce.Stopwatch != null && bruteForce.Stopwatch.ElapsedMilliseconds != 0)
                {
                    //Console.WriteLine("UpdateTheUIBruteForceAttack");
                    int seconds = (int)(bruteForce.Stopwatch.ElapsedMilliseconds / 1000);
                    int milliseconds = (int)(bruteForce.Stopwatch.ElapsedMilliseconds % 1000);
                    labelStatTimer.Text = Languages.Translate(10009) + ": " + seconds + "." + milliseconds + " s";
                    int triesBetween = (int)(bruteForce.Attempts - numberOfAttemptsInLastUpdateBruteForce);
                    numberOfAttemptsInLastUpdateBruteForce = bruteForce.Attempts;

                    //Update Speed
                    double speed = triesBetween / (Settings.UpdateUIms / 1000.0);
                    labelStatCurrentSpeed.Text = Languages.Translate(10011) + ":  " + speed.ToString("#,0");

                    //Attempts
                    labelStatAttempts.Text = Languages.Translate(10010) + ": " + bruteForce.Attempts.ToString("#,0");

                    //Update Average Speed
                    double averageSpeed = 0;
                    averageSpeed = bruteForce.Attempts / (bruteForce.Stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second            
                    labelStatSpeed.Text = Languages.Translate(10012) + " /s: " + Math.Floor(averageSpeed).ToString("#,0");

                    //update progressbar
                    progressBar1.Value = bruteForce.Progress;
                }
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
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(279));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.RainbowTableAttack:
                        {
                            timerRainbowTableAttack.Dispose();
                            rainbowTableAttack.Abort();
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(279));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.DictionaryAttack:
                        {
                            timerDictionary.Dispose();
                            dictionaryAttack.Abort();
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(279));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.BruteForceAttack:
                        {
                            timerBruteForce.Dispose();
                            bruteForce.Abort();
                            if (checkBoxShowLog.Checked)
                            {
                                listBoxLog.Items.Add(Languages.Translate(279));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            MessageBox.Show(Languages.Translate(10017), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    case TaskType.None:
                        {
                            MessageBox.Show(Languages.Translate(315), Languages.Translate(10032), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            rainbowTableAlgorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void FilesCleanUp(string nameOfFilesToClear)
        {
            string[] files = Directory.GetFiles(Settings.DirectoryPathToWordlists);
            foreach (string file in files)
            {
                if (file.Contains(nameOfFilesToClear)) File.Delete(file);
            }
        }

        private void numericUpDownLenght_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownLenght.Value == 0)
            {
                checkBoxUnknownLenghtBruteForce.Enabled = true;
            }
        }
    }
}

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

namespace HashTester
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }
        Stopwatch stopwatch = new Stopwatch();
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
        private void UpdateUIPassword(int lineNumber, long stopwatchTime, int progress)
        {
            labelTimer.Text = "Timer: " + stopwatchTime / 1000 + "." + stopwatchTime % 1000;
            labelSpeed.Text = "Average speed /s: " + lineNumber / (double)(stopwatchTime / 1000);
            progressBar1.Value = progress;
        }

        private void buttonCheckPassword_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            DisableUI();
            string messageBoxAnswer = "";
            string fullPathToTXT = "";
            string[] passwords = textBox1.Lines;
            bool[] foundMatch = new bool[textBox1.Lines.Length];
            long[] lineFoundMatch = new long[textBox1.Lines.Length];
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
            progressBar1.Value = 0;
            using (StreamReader reader = new StreamReader(fullPathToTXT))
            {
                int lineNumber = 0;
                int linesInTXT = (int)File.ReadLines(fullPathToTXT).LongCount();
                long stopwatchTime = 0;
                while (!reader.EndOfStream)
                {
                    if (stopwatch.ElapsedMilliseconds - stopwatchTime > 16) //update UI every 60+ fps
                    {
                        stopwatchTime = stopwatch.ElapsedMilliseconds;
                        int progressBar = (lineNumber * 100) / linesInTXT;
                        UpdateUIPassword(lineNumber, stopwatchTime, progressBar);
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
                            }
                        }
                    }
                }
                //Player Output
                progressBar1.Value = 0;
                stopwatch.Stop();
                stopwatch.Reset();
                for (int i = 0; i < passwords.Count(); i++)
                {
                    if (foundMatch[i]) messageBoxAnswer += "Password '" + passwords[i] + "' has been found in wordlist at line " + lineFoundMatch[i] + ". I recommend using a different password." + Environment.NewLine;
                    else messageBoxAnswer += "Password '" + passwords[i] + "' has not been found in wordlist. Good Job." + Environment.NewLine;
                }
                MessageBox.Show(messageBoxAnswer);
                ActivateUI();
            }
        }
        #endregion

        #region How Long To Crack

        UInt64 Kalkulacka(int delkaHesla, double pocetZnaku, double zaSekundu, out float rychlost)
        {
            UInt64 pocet = (UInt64)Math.Pow(pocetZnaku, delkaHesla);
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
            UInt64 pocet = Kalkulacka(passwordLenght, pocetZnaku, speed, out rychlost);
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
                            writer.WriteLine("algorithm=" + algorithm.ToString());
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
                                writer.WriteLine(line + "=" + hash);
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
            labelHashes.Text = "Hashes /s: " + speed.ToString();
            progressBar1.Value = progress;
        }
        #endregion

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void buttonBruteForceAttack_Click(object sender, EventArgs e)
        {
            bool foundHash = false;
            string originalText = "";
            string hashedText = textBoxBruteForceInput.Text;
            if (radioButton5.Checked) hashedText = hasher.Hash(textBoxBruteForceInput.Text, algorithm);
            if (checkBox1.Checked) foundHash = DictionaryAttack(hashedText, out originalText);
            //SetUp
            if (!foundHash)
            {
                decimal maxAttempts = numericUpDown1.Value;
                bool useMaxAttempts = true;
                if (maxAttempts == 0) useMaxAttempts = false;
                int passwordLenght = (int)numericUpDown2.Value;
                bool useStopTimer = true;
                decimal stopTimer = numericUpDownStopTimer.Value;
                if (stopTimer == 0) useStopTimer = false;
                bool showLog = checkBoxListBoxLog.Checked;
                bool performanceMode = checkBoxPerformanceMode.Checked;
                bool[] useCharactersOption = { false, false, false, false }; //0 == lowercase, 1 == uppercase, 2 == digits, 3 == specialChars
                if (checkBox6.Checked) useCharactersOption[0] = true;
                if (checkBox5.Checked) useCharactersOption[1] = true;
                if (checkBox4.Checked) useCharactersOption[2] = true;
                if (checkBox3.Checked) useCharactersOption[3] = true;
                //FINISH THIS SHIT
            }
            else MessageBox.Show("Found hash via Dictionary attack\nOriginal password: " + originalText);
        }

        private bool DictionaryAttack(string hashedText, out string originalText)
        {
            bool foundMatch = false;
            originalText = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Settings.PasswordPathToFiles;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string[] algorithmText = reader.ReadLine().Split('=');
                    Hasher.HashingAlgorithm algorithm;
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
                            algorithm = Hasher.HashingAlgorithm.CRC32;
                            break;
                    }
                    while (!reader.EndOfStream && !foundMatch)
                    {
                        string[] data = reader.ReadLine().Split('=');
                        if (data[1] == hashedText)
                        {
                            foundMatch = true;
                            originalText = data[0];
                        }
                    }
                    return foundMatch;
                }                
            }
            else return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace HashTester
{
    public delegate void UpdateAttemptsLabelDelegate(long attempts);

    public partial class HashingCollisionForm : Form
    {
        public HashingCollisionForm()
        {
            InitializeComponent();
        }

        Hasher hasher = new Hasher();
        Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.CRC32;
        Thread collisionThread;
        volatile bool stopHashing = false; // Volatile for thread safety
        long maxAttempts = 0;
        long attempts = 0;
        int timeToCalculate = 0;
        long numberOfAttempsInLastUpdate = 0; //The time is 16ms
        private Timer timeToFindCollision;
        double totalHashCombinations;

        #region Form
        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopHashing = true;
        }

        #endregion

        #region CollisionGenerator3000
        private void buttonGenerateCollision_Click(object sender, EventArgs e)
        {
            TurnOffUI();
            stopHashing = false;
            maxAttempts = (long)numericUpDown1.Value;
            int rngTextLenght = (int)numericUpDown2.Value;
            if (!checkBoxPerformanceMode.Checked)
            {
                totalHashCombinations = Math.Pow(2, rngTextLenght * 8); //one char is 8 bits (UTF-8)
                //Timer
                timeToCalculate = 0;
                timeToFindCollision = new Timer();
                timeToFindCollision.Interval = 16; //updates every 16 ms for 60+fps update
                timeToFindCollision.Tick += (s, args) => UpdateTimerLabel();
                timeToFindCollision.Start();
            }
            else checkBoxListBoxLog.Checked = false;

            switch (hashSelector.SelectedIndex)
            {
                case 0: algorithm = Hasher.HashingAlgorithm.CRC32; break;
                case 1: algorithm = Hasher.HashingAlgorithm.RIPEMD160; break;
                case 2: algorithm = Hasher.HashingAlgorithm.MD5; break;
                case 3: algorithm = Hasher.HashingAlgorithm.SHA1; break;
                default: algorithm = Hasher.HashingAlgorithm.CRC32; break;
            }
            collisionThread = new Thread(() => CollisionThread(algorithm, maxAttempts, rngTextLenght, checkBoxListBoxLog.Checked, checkBox1.Checked, checkBoxPerformanceMode.Checked));
            collisionThread.Start();
        }

        private void CollisionThread(Hasher.HashingAlgorithm algorithm, long maxAttempts, int length, bool saveLogToListBox, bool useHexForOutput, bool performanceMode)
        {
            bool foundCollision = false, attemptsRanOut = false;
            string textCollision01 = "", textCollision02 = "";
            attempts = 0;
            bool useAttempts = false;
            if (maxAttempts > 0) useAttempts = true;
            foundCollision = GenerateCollision(algorithm, length, maxAttempts, useAttempts, saveLogToListBox, useHexForOutput, performanceMode, out textCollision01, out textCollision02, out attemptsRanOut);
            if (timeToFindCollision != null) timeToFindCollision.Stop();
            if (foundCollision) //MessageBoxOutput
            {
                string message = "Collision found!";
                if (performanceMode)
                {
                    message += "\nCollision 1: " + (useHexForOutput ? ConvertStringToHex(textCollision01) : textCollision01) +
                                      "\nCollision 2: " + (useHexForOutput ? ConvertStringToHex(textCollision02) : textCollision02);
                }
                else
                {
                    message += "\nCollision 1: " + (useHexForOutput ? ConvertStringToHex(textCollision01) : textCollision01) +
                                       "\nCollision 2: " + (useHexForOutput ? ConvertStringToHex(textCollision02) : textCollision02) +
                                       "\nAttempts: " + attempts +
                                       "\nTime to find: " + labelTimer.Text.Split(' ')[1]; // Only the number
                }

                Invoke((Action)(() => CollisionFoundMessageBox(message, textCollision01, textCollision02)));
            }
            else if (stopHashing)
            {
                Invoke((Action)(() => MessageBox.Show("The process has been abandoned.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            }
            else if (attemptsRanOut)
            {
                Invoke((Action)(() => MessageBox.Show("Could not find a collision under the given attempts.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            }
            else
            {
                Invoke((Action)(() => MessageBox.Show("Could not find collision.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)));
            }

            Invoke((Action)TurnOnUI);
        }

        private bool GenerateCollision(Hasher.HashingAlgorithm algorithm, int length, long maxAttempts, bool useAttempts, bool saveLogToListbox, bool useHexForOutput, bool performanceMode, out string collision1, out string collision2, out bool attemptsRanOut)
        {
            collision1 = "";
            collision2 = "";
            attemptsRanOut = false;
            bool foundCollision = false;
            var random = new Random(); //Random needs to be here or it will create collisions indefinetly; PC stuff
            var collisionList = new List<string>();
            var collisionListOriginalText = new List<string>();
            var log = new List<string>();
            Stopwatch stopwatchUpdateUI = new Stopwatch();
            if (!performanceMode) stopwatchUpdateUI.Start();
            while (!foundCollision && !stopHashing && !attemptsRanOut)
            {
                if (!performanceMode)
                {
                    Interlocked.Increment(ref attempts); //Updates attempts +1
                    if (stopwatchUpdateUI.ElapsedMilliseconds > 16) //updates UI 62.5 times per sec (62.5fps)
                    {
                        stopwatchUpdateUI.Restart();
                        Invoke((Action)UpdateAttemptsLabel);
                        if (saveLogToListbox)
                        {
                            listBox1.Invoke(new Action(() =>
                            {
                                foreach (string item in log) { listBox1.Items.Add(item); }  //save all list to listbox                      
                                listBox1.TopIndex = listBox1.Items.Count - 1; // Scroll to the bottom
                                log.Clear();
                            }));
                        }
                    }
                }

                //Generate Random String
                string randomText = GenerateRandomString(random, length);
                string hashedValue = hasher.Hash(randomText, algorithm);

                //Log update                
                if (saveLogToListbox) //Disabled in performance mode
                {
                    string randomTextForUser;
                    if (useHexForOutput) randomTextForUser = ConvertStringToHex(randomText);
                    else randomTextForUser = randomText;
                    log.Add("Hashing: " + randomTextForUser + " | Hashing with (" + algorithm.ToString() + "): " + hashedValue);
                }

                // Check for collision
                if (collisionList.Contains(hashedValue))
                {
                    int collisionIndex = collisionList.IndexOf(hashedValue);
                    collision1 = collisionListOriginalText[collisionIndex];
                    collision2 = randomText;
                    if (collision1 != collision2)
                    {
                        foundCollision = true;
                        if (useHexForOutput)
                        {
                            log.Add("Found collision: " + ConvertStringToHex(collision1) + " and " + ConvertStringToHex(collision2));
                        }
                        else log.Add("Found collision: " + collision1 + " and " + collision2);
                        //Memory Dump
                        collisionList.Clear();
                        collisionListOriginalText.Clear();
                    }
                    else
                    {
                        if (useHexForOutput)
                        {
                            log.Add("Found duplicate: " + ConvertStringToHex(collision1) + " " + ConvertStringToHex(collision2));
                        }
                        else log.Add("Found duplicate: " + collision1 + " " + collision2);
                        collisionList.RemoveAt(collisionIndex); //Removes the duplicate
                        collisionListOriginalText.RemoveAt(collisionIndex);
                    }
                }
                else
                {
                    collisionList.Add(hashedValue);
                    collisionListOriginalText.Add(randomText);
                }

                if (useAttempts && attempts >= maxAttempts)
                {
                    //Memory Dump
                    collisionList.Clear();
                    collisionListOriginalText.Clear();
                    attemptsRanOut = true;
                }
                if (stopHashing)
                {
                    //Memory Dump
                    collisionList.Clear();
                    collisionListOriginalText.Clear();
                }
            }
            stopwatchUpdateUI.Stop();
            return foundCollision;
        }

        private string GenerateRandomString(Random random, int length)
        {
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = (char)random.Next(32, 256);  //Generates random UTF-8 without the first 32 since those are not printable
            }
            return new string(result);
        }
        private void UpdateAttemptsLabel()
        {
            label3.Text = "Number of attempts: " + attempts;
        }

        private void UpdateTimerLabel()
        {
            //Update Timer
            timeToCalculate += 16;
            int seconds = timeToCalculate / 1000;
            int milliseconds = timeToCalculate % 1000;
            labelTimer.Text = "Timer: " + seconds + "." + milliseconds + " s";
            int triesBetween = (int)attempts - (int)numberOfAttempsInLastUpdate;
            numberOfAttempsInLastUpdate = attempts;
            //Update Speed
            double speed = triesBetween / 0.016; //16 ms
            label4.Text = "Hashes per sec: " + speed;
            //Update Average Speed
            double averageSpeed = attempts / (timeToCalculate / 1000.0); //Average speed per second
            label5.Text = "Average speed: " + Math.Floor(averageSpeed);
            //Chance To Find Collision
            label6.Text = "Chance to find collision: " + CalculateChanceOfFindingCollision(speed) * 100 * 62.5 + "% per sec "; //Just estimated value
        }

        public void CollisionFoundMessageBox(string message, string collisionText01, string collisionText02)
        {
            ConfirmationForm confirmation = new ConfirmationForm("Would you like to save collision to a txt file?");
            if (confirmation.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(@"..\..\SameHashingResults");
                string path2 = "";
                bool foundName = false;
                int number = 1;
                //Finding name
                while (!foundName)
                {
                    if (!File.Exists(path + algorithm.ToString() + "-" + number + ".txt"))
                    {
                        foundName = true;
                        path2 = algorithm.ToString() + "-" + number + ".txt";
                    }
                    else number++;
                }
                //Writing Results
                using (StreamWriter writer = new StreamWriter(path + path2))
                {
                    writer.WriteLine("//Comment, this program supports formats <STRING> <HEX> <BIN> and works on lines. First is format then two lines will be read and compared. For an example try to generate a Collision in HashingCollisionForm");
                    writer.WriteLine("//!The program will only check the first format and texts!");
                    writer.WriteLine("//<STRING> Supports UTF-8 format (example al85WTh)");
                    writer.WriteLine("//<HEX> Supports 8D-B7 or 8DB7 doesnt matter if lowercase or uppercase");
                    writer.WriteLine("//<BIN> Supports 0111 0001 with or without spaces between");
                    writer.WriteLine("//There must always be an algorithm and it must be before the format (supported formats: MD5;SHA1;SHA256;SHA512;RIPEMD160;CRC32) example Algorithm=RIPEMD160");
                    writer.WriteLine("//");
                    writer.WriteLine("Algorithm=" + algorithm.ToString());
                    writer.WriteLine("<STRING>");
                    writer.WriteLine(collisionText01);
                    writer.WriteLine(collisionText02);
                    writer.WriteLine("<HEX>");
                    writer.WriteLine(ConvertStringToHex(collisionText01));
                    writer.WriteLine(ConvertStringToHex(collisionText02));
                }
            }
            MessageBox.Show(message, "Collision Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private double CalculateChanceOfFindingCollision(double speedPerFrame)
        {
            // Use the approximation for the birthday paradox
            double probabilityNoCollision = Math.Exp(-((double)attempts * (attempts - 1)) / (2.0 * totalHashCombinations));
            double probabilityCollision = 1.0 - probabilityNoCollision;
            return probabilityCollision * speedPerFrame;
        }  //returns a probability per one frame

        #endregion

        #region CollisionDetection3000

        #region TXTFile
        public enum CollisionDetectionFormat
        {
            HEX,
            STRING,
            BIN
        }

        private void buttonTakeCollisionFromTXT_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog soubor = new OpenFileDialog())
            {
                soubor.DefaultExt = ".txt";
                soubor.InitialDirectory = Path.GetFullPath(@"..\..\SameHashingResults");
                if (soubor.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(soubor.FileName))
                    {
                        Hasher.HashingAlgorithm algorithmTemp = Hasher.HashingAlgorithm.CRC32;
                        CollisionDetectionFormat format = CollisionDetectionFormat.STRING;
                        string textCollision01 = "", textCollision02 = "";
                        bool gotInformation = false;
                        while (!reader.EndOfStream && !gotInformation)
                        {
                            string line = reader.ReadLine();
                            if (!line.StartsWith("//") && !String.IsNullOrEmpty(line))
                            {
                                if (line.StartsWith("Algorithm="))
                                {
                                    string nextLine = line.Remove(0, 10);
                                    Console.WriteLine(nextLine);
                                    switch (nextLine)
                                    {
                                        case "MD5": algorithmTemp = Hasher.HashingAlgorithm.MD5; break;
                                        case "SHA1": algorithmTemp = Hasher.HashingAlgorithm.SHA1; break;
                                        case "SHA256": algorithmTemp = Hasher.HashingAlgorithm.SHA256; break;
                                        case "SHA512": algorithmTemp = Hasher.HashingAlgorithm.SHA512; break;
                                        case "RIPEMD160": algorithmTemp = Hasher.HashingAlgorithm.RIPEMD160; break;
                                        case "CRC32": algorithmTemp = Hasher.HashingAlgorithm.CRC32; break;
                                        default: algorithmTemp = Hasher.HashingAlgorithm.CRC32; break;
                                    }
                                }
                                switch (line)
                                {                                    
                                    case "<STRING>":
                                        {
                                            format = CollisionDetectionFormat.STRING;
                                            textCollision01 = reader.ReadLine();
                                            textCollision02 = reader.ReadLine();
                                            gotInformation = true;
                                            break;
                                        }
                                    case "<BIN>":
                                        {
                                            format = CollisionDetectionFormat.BIN;
                                            textCollision01 = reader.ReadLine();
                                            textCollision02 = reader.ReadLine();
                                            gotInformation = true;
                                            break;
                                        }
                                    case "<HEX>":
                                        {
                                            format = CollisionDetectionFormat.HEX;
                                            textCollision01 = reader.ReadLine();
                                            textCollision02 = reader.ReadLine();
                                            gotInformation = true;
                                            break;
                                        }
                                    default: break;
                                }
                            }
                        }
                        if (gotInformation && !String.IsNullOrEmpty(textCollision01) && !String.IsNullOrEmpty(textCollision02))
                                CheckCollision(algorithmTemp, textCollision01, textCollision02, format);
                        else MessageBox.Show("Could not read the contents of this file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        #endregion
        private void buttonCheckCollision_Click(object sender, EventArgs e)
        {
            CheckCollisionForm checkCollisionForm = new CheckCollisionForm();
            if (checkCollisionForm.ShowDialog() == DialogResult.OK)
            {
                CheckCollision(checkCollisionForm.HashingAlgorithm, checkCollisionForm.Text01, checkCollisionForm.Text02, checkCollisionForm.Format);
            }
        }
        private void CheckCollision(Hasher.HashingAlgorithm hashAlgorithm, string text01, string text02, CollisionDetectionFormat format)
        {            
            //Format
            if (format == CollisionDetectionFormat.HEX)
            {
                Console.WriteLine("Before Update Text01: " + text01);
                Console.WriteLine("Before Update Text02: " + text02);
                text01 = ConvertHexToString(text01);
                text02 = ConvertHexToString(text02);
                Console.WriteLine("After Update Text01: " + text01);
                Console.WriteLine("Before Update Text02: " + text02);
            }
            else if (format == CollisionDetectionFormat.BIN)
            {
                Console.WriteLine("Before Update Text01: " + text01);
                Console.WriteLine("Before Update Text02: " + text02);
                text01 = ConvertBinToString(text01);
                text02 = ConvertBinToString(text02);
                Console.WriteLine("After Update Text01: " + text01);
                Console.WriteLine("Before Update Text02: " + text02);
            }
            //CheckCollision
            Hasher hasher = new Hasher();
            string hash01 = hasher.Hash(text01, hashAlgorithm);
            string hash02 = hasher.Hash(text02, hashAlgorithm);
            Console.WriteLine("Hash01: " + hash01);
            Console.WriteLine("Hash02: " + hash02);
            if (hash01 == hash02) MessageBox.Show("Kolize detekována\nSpolečný hash: " + hash01, "HashCollision", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Vstupní řetězce nedělají kolizi\nHash01: " + hash01 + "\nHash02: " + hash02, "HashCollision", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        private void TurnOffUI()
        {
            buttonReturn.Enabled = false;
            buttonClearListBox.Enabled = false;
            buttonGenerateCollision.Enabled = false;
            buttonTakeCollisionFromTXT.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            hashSelector.Enabled = false;
            checkBoxListBoxLog.Enabled = false;
            checkBox1.Enabled = false;
            checkBoxPerformanceMode.Enabled = false;
            buttonCheckCollision.Enabled = false;
        }

        private void TurnOnUI()
        {
            buttonReturn.Enabled = true;
            buttonClearListBox.Enabled = true;
            buttonGenerateCollision.Enabled = true;
            buttonTakeCollisionFromTXT.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            hashSelector.Enabled = true;
            checkBoxListBoxLog.Enabled = true;
            checkBox1.Enabled = true;
            checkBoxPerformanceMode.Enabled = true;
            buttonCheckCollision.Enabled = true;
        }
        #region Converters
        private string ConvertStringToHex(string input)
        {
            var hexBuilder = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                hexBuilder.AppendFormat("{0:X2}", (int)input[i]);
                if (i < input.Length - 1)
                {
                    hexBuilder.Append('-');
                }
            }
            return hexBuilder.ToString();
        }

        private string ConvertHexToString(string hex)
        {
            StringBuilder output = new StringBuilder();
            hex = hex.ToLower();
            hex = hex.Replace("-", "");
            for (int i = 0; i < hex.Length; i += 2)
            {
                string hexPair = hex.Substring(i, 2);
                int temp = Convert.ToInt32(hexPair, 16);
                output.Append((char)temp);
            }
            return output.ToString();
        }

        private string ConvertBinToString(string binary)
        {
            binary = binary.Replace(" ", "");
            byte[] bytes = new byte[binary.Length / 8];
            for (int i = 0; i < binary.Length; i += 8)
            {
                string byteString = binary.Substring(i, 8);
                bytes[i / 8] = Convert.ToByte(byteString, 2);
            }
            return bytes.ToString();
        }
        #endregion
    }
}
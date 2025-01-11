using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
        volatile bool stopHashing = false; // Volatile for thread safety
        volatile bool foundCollision = false;
        volatile bool attemptsRanOut = false;
        volatile string textCollision01 = "";
        volatile string textCollision02 = "";
        long maxAttempts = 0;
        long attempts = 0;
        long numberOfAttempsInLastUpdate = 0; //The time is 16ms
        Stopwatch stopwatch = new Stopwatch();
        private Timer timeToFindCollision;
        private readonly ConcurrentQueue<string> logQueue = new ConcurrentQueue<string>(); //list with thread safety features

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
        private async void buttonGenerateCollision_Click(object sender, EventArgs e)
        {
            timeToFindCollision = new Timer();
            TurnOffUI();
            maxAttempts = (long)numericUpDown1.Value;
            int rngTextLenght = (int)numericUpDown2.Value;
            switch (hashSelector.SelectedIndex)
            {
                case 0: algorithm = Hasher.HashingAlgorithm.CRC32; break;
                case 1: algorithm = Hasher.HashingAlgorithm.RIPEMD160; break;
                case 2: algorithm = Hasher.HashingAlgorithm.MD5; break;
                case 3: algorithm = Hasher.HashingAlgorithm.SHA1; break;
                default: algorithm = Hasher.HashingAlgorithm.CRC32; break;
            }
            List<Task> allTasks = new List<Task>();
            if (checkBoxPerformanceMode.Checked)
            {
                int maxThreads = Environment.ProcessorCount;
                for (int i = 0; i < maxThreads - 1; i++) //multiThread
                {
                    allTasks.Add(Task.Run(() => CollisionThread(i, algorithm, maxAttempts, rngTextLenght, false, checkBox1.Checked)));
                }
            }
            else //single Thread
            {
                allTasks.Add(Task.Run(() => CollisionThread(1, algorithm, maxAttempts, rngTextLenght, checkBoxListBoxLog.Checked, checkBox1.Checked)));
            }
            await Task.WhenAll(allTasks);
            TurnOnUI();
            if (foundCollision) //MessageBoxOutput
            {
                string message = "Collision found!\n" +
                                        "\nCollision 1: " + (checkBox1.Checked ? ConvertStringToHex(textCollision01) : textCollision01) +
                                       "\nCollision 2: " + (checkBox1.Checked ? ConvertStringToHex(textCollision02) : textCollision02) +
                                       "\nCollision hash: " + hasher.Hash(textCollision01, algorithm) +
                                       "\nAttempts: " + attempts +
                                       "\nTime to find: " + labelTimer.Text.Split(' ')[1]; // Only the number
                CollisionFoundMessageBox(message, textCollision01, textCollision02);
            }
            else if (stopHashing)
            {
                MessageBox.Show("The process has been abandoned.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (attemptsRanOut)
            {
                MessageBox.Show("Could not find a collision under the given attempts.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Could not find collision.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }

        private void CollisionThread(int threadNumber, Hasher.HashingAlgorithm algorithm, long maxAttempts, int length, bool saveLogToListBox, bool useHexForOutput)
        {
            attempts = 0;
            bool useAttempts = false;
            if (maxAttempts > 0) useAttempts = true;
            if (GenerateCollision(threadNumber, algorithm, length, maxAttempts, useAttempts, saveLogToListBox, useHexForOutput, out string collision01, out string collision02))
            {
                textCollision01 = collision01;
                textCollision02 = collision02;
                foundCollision = true;
            }
            else stopHashing = true;
        }

        private bool GenerateCollision(int threadNumber, Hasher.HashingAlgorithm algorithm, int length, long maxAttempts, bool useAttemps, bool saveLogToListBox, bool useHexForOutput, out string collision1, out string collision2)
        {
            try
            {
                collision1 = "";
                collision2 = "";
                List<string> hashedList = new List<string>();
                List<string> textList = new List<string>();
                Random random = new Random((int)(DateTime.Now.Ticks ^ threadNumber));

                while (!foundCollision && !stopHashing && !attemptsRanOut)
                {
                    Interlocked.Increment(ref attempts);
                    string randomText = GenerateRandomString(random, length);
                    string hashedValue = hasher.Hash(randomText, algorithm);

                    if (saveLogToListBox)
                    {
                        string displayText = useHexForOutput ? ConvertStringToHex(randomText) : randomText;
                        logQueue.Enqueue($"Hashing: {displayText} | Hash: {hashedValue}");
                    }

                    if (hashedList.Contains(hashedValue))
                    {
                        int collisionIndex = hashedList.IndexOf(hashedValue);
                        collision1 = textList[collisionIndex];
                        collision2 = randomText;

                        if (collision1 != collision2)
                        {
                            foundCollision = true;
                            logQueue.Enqueue($"Collision Found: {collision1} and {collision2}");
                            return true;
                        }
                    }
                    else
                    {
                        hashedList.Add(hashedValue);
                        textList.Add(randomText);
                    }

                    if (maxAttempts > 0 && Interlocked.Read(ref attempts) >= maxAttempts)
                    {
                        attemptsRanOut = true;
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                collision1 = "";
                collision2 = "";
                return false;
            }
            return false;
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

        private void UpdateTimerLabel()
        {
            //Update Timer
            int seconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
            int milliseconds = (int)(stopwatch.ElapsedMilliseconds % 1000);
            labelTimer.Text = "Timer: " + seconds + "." + milliseconds + " s";
            int triesBetween = (int)(attempts - numberOfAttempsInLastUpdate);
            numberOfAttempsInLastUpdate = attempts;
            //Attempts
            label3.Text = "Number of attempts: " + attempts;
            //Update Speed
            double speed = triesBetween / 0.016; //16 ms
            label4.Text = "Hashes per sec: " + speed;
            //Update Average Speed
            double averageSpeed = attempts / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
            label5.Text = "Average speed: " + Math.Floor(averageSpeed);
            //update Log listbox
            ProcessLogQueueAsync();
        }

        private async void ProcessLogQueueAsync() //background process
        {
            await Task.Run(() =>
            {
                List<string> logBatch = new List<string>();

                while (logQueue.TryDequeue(out string logItem))
                {
                    logBatch.Add(logItem);
                }

                // Invoke the UI thread to update the ListBox in batches
                if (logBatch.Count > 0)
                {
                    Invoke((Action)(() =>
                    {
                        listBox1.Items.AddRange(logBatch.ToArray());
                        listBox1.TopIndex = listBox1.Items.Count - 1;
                    }));
                }
            });
        }

        public void CollisionFoundMessageBox(string message, string collisionText01, string collisionText02)
        {
            ConfirmationForm confirmation = new ConfirmationForm("Would you like to save collision to a txt file?");
            if (confirmation.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetFullPath(Settings.CollisionPathToFiles);
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
                    writer.WriteLine("Algorithm=" + algorithm.ToString());
                    writer.WriteLine("<STRING>");
                    writer.WriteLine(collisionText01);
                    writer.WriteLine(collisionText02);
                    writer.WriteLine("<HEX>");
                    writer.WriteLine(ConvertStringToHex(collisionText01));
                    writer.WriteLine(ConvertStringToHex(collisionText02));
                    writer.WriteLine("<HASH>");
                    writer.WriteLine("hash1: " + hasher.Hash(collisionText01, algorithm));
                    writer.WriteLine("hash2: " + hasher.Hash(collisionText02, algorithm));
                }
            }
            MessageBox.Show(message, "Collision Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region CollisionDetectionFromAFile3000

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
            //Timer for UI update
            timeToFindCollision.Interval = 16; //updates every 16 ms for 60+fps update
            timeToFindCollision.Tick += (s, args) => UpdateTimerLabel();
            timeToFindCollision.Start();
            //Stopwatch
            stopwatch.Restart();
            stopwatch.Start();
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
            //timer
            timeToFindCollision.Stop();
            timeToFindCollision.Dispose();
            //stopwatch
            stopwatch.Stop();
            //UI
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

        private void HashingCollisionForm_Load(object sender, EventArgs e) //Checks if an info.txt is already present
        {
            string path = Settings.CollisionPathToFiles;
            Console.Write(path + "_collisionInfo.txt");
            if (!File.Exists(path + "_collisionInfo.txt"))
            {
                string s = "//Comment, this program supports formats <STRING> <HEX> <BIN> and works on lines. First is format then two lines will be read and compared. For an example try to generate a Collision in HashingCollisionForm\r\n" +
                               "//!The program will only check the first format and texts!\r\n" +
                               "//<STRING> Supports UTF-8 format (example al85WTh)\r\n" +
                               "//<HEX> Supports 8D-B7 or 8DB7 doesnt matter if lowercase or uppercase\r\n" +
                               "//<BIN> Supports 0111 0001 with or without spaces between\r\n" +
                               "//There must always be an algorithm and it must be before the format (supported formats: MD5;SHA1;SHA256;SHA512;RIPEMD160;CRC32) example Algorithm=RIPEMD160\r\n" +
                               "//In <HASH> you can find both hashes for text 1 and 2. This is just for user and can be changed freely (why would you do that tho).";
                File.WriteAllText(path + "_collisionInfo.txt", s);
                Console.WriteLine("Generated _collisionInfo.txt into the " + path);
            }
        }
    }
}
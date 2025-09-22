using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private Timer timeToFindCollision = new Timer();
        #region Form
        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
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
            TurnOffUI();
            ResetValues();
            maxAttempts = (long)numericUpDown1.Value;
            if (maxAttempts > 0 && Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.AttemptsLimit) + ": " + maxAttempts); 
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
            stopwatch.Start();
            //multithread
            if (checkBoxPerformanceMode.Checked && FormManagement.UseMultiThread())
            {
                int maxThreads = FormManagement.NumberOfThreadsToUse();
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.StartingTheProcessInPerformanceMode));
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.NumberOfThreadsAssigned) + ": " + maxThreads);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                Console.WriteLine("Max Threads: " + maxThreads);
                for (int i = 0; i < maxThreads; i++) //multiThread
                {
                    int threadIndex = i;
                    Console.WriteLine("Collision Finder Multithread start");
                    allTasks.Add(Task.Run(() => CollisionThread(threadIndex, algorithm, maxAttempts, rngTextLenght, checkBoxUseHex.Checked)));
                }
            }
            else //single Thread
            {
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.StartingTheProcessInNormalMode));
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.NumberOfThreadsAssigned) + ": 1");
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                allTasks.Add(Task.Run(() => CollisionThread(1, algorithm, maxAttempts, rngTextLenght, checkBoxUseHex.Checked)));
            }
            await Task.WhenAll(allTasks);
            stopwatch.Stop();
            TurnOnUI();
            if (foundCollision) 
            {                
                //LogOutput
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.CollisionFound));
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.Collision) + " 1: " + (textCollision01));
                    if (checkBoxUseHex.Checked) listBoxLog.Items.Add(Languages.Translate(Languages.L.Collision) + " 1 (" + Languages.Translate(Languages.L.Hex) + "): " + FormManagement.ConvertStringToHex(textCollision01));
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.Collision) + " 2: " + (textCollision02));
                    if (checkBoxUseHex.Checked) listBoxLog.Items.Add(Languages.Translate(Languages.L.Collision) + " 2 (" + Languages.Translate(Languages.L.Hex) + "): " + FormManagement.ConvertStringToHex(textCollision02));
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.CollisionHash) + ": " + hasher.Hash(textCollision01, algorithm));
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.Attempts) + ": " + attempts);
                    try { listBoxLog.Items.Add(Languages.Translate(Languages.L.TimeToFind) + ": " + labelTimer.Text.Split(' ')[1]); } //so that I dont have to format it again :)
                    catch { /*Hi :3*/ }
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                //MessageBoxOutput
                string message = Languages.Translate(Languages.L.CollisionFound) + Environment.NewLine + Languages.Translate(Languages.L.Collision) + " 1: " + textCollision01;
                if (checkBoxUseHex.Checked) message += Environment.NewLine + Languages.Translate(Languages.L.Collision) + " 1 (" + Languages.Translate(Languages.L.Hex) + "): " + FormManagement.ConvertStringToHex(textCollision01);
                message += Environment.NewLine + Languages.Translate(Languages.L.Collision) + " 2: " + textCollision02;
                if (checkBoxUseHex.Checked) message += Environment.NewLine + Languages.Translate(Languages.L.Collision) + " 2 (" + Languages.Translate(Languages.L.Hex) + "): " + FormManagement.ConvertStringToHex(textCollision02);
                message += Environment.NewLine + Languages.Translate(Languages.L.CollisionHash) + ": " + hasher.Hash(textCollision01, algorithm) + 
                    Environment.NewLine + Languages.Translate(Languages.L.Attempts) + ": " + attempts;
                listBoxLog.Items.Add(message);
                try { message += Environment.NewLine + Languages.Translate(Languages.L.TimeToFind) + ": " + labelTimer.Text.Split(' ')[1]; }
                catch { /*Back again?*/}
                CollisionFoundMessageBox(message, textCollision01, textCollision02);
            }
            else if (stopHashing)
            {
                MessageBox.Show(Languages.Translate(Languages.L.TheProcessHasBeenAbandoned), Languages.Translate(Languages.L.Abandoned), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.TheProcessHasBeenAbandoned));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else if (attemptsRanOut)
            {
                MessageBox.Show(Languages.Translate(Languages.L.CouldNotFindACollisionUnderTheGivenAttempts), Languages.Translate(Languages.L.Abandoned), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.CouldNotFindACollisionUnderTheGivenAttempts));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show(Languages.Translate(Languages.L.CouldNotFindCollision), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.CouldNotFindCollision));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            } 
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="threadNumber">Number used for random generation</param>
        /// <param name="algorithm"></param>
        /// <param name="maxAttempts">The thread will cancel after a certain number of attempts</param>
        /// <param name="length">Lenght of randomly generated text</param>
        /// <param name="useHexForOutput"></param>
        private void CollisionThread(int threadNumber, Hasher.HashingAlgorithm algorithm, long maxAttempts, int length, bool useHexForOutput)
        {
            attempts = 0;        
            if (GenerateCollision(threadNumber, algorithm, length, maxAttempts, useHexForOutput, out string collision01, out string collision02))
            {
                //Console.WriteLine("Le " + threadNumber + " found collision");
                textCollision01 = collision01;
                textCollision02 = collision02;
                foundCollision = true;
            }
            else stopHashing = true;
            //Console.WriteLine("Le " + threadNumber + " has ended.");
        }

        /// <summary>
        /// Generates a collision between two random inputs
        /// </summary>
        /// <param name="threadNumber"></param>
        /// <param name="algorithm"></param>
        /// <param name="length">Lenght of a random string input</param>
        /// <param name="maxAttempts">0 means it wont use limit to attemps</param>
        /// <param name="useHexForOutput"></param>
        /// <param name="collision1">Returns a string collision</param>
        /// <param name="collision2">Returns a string colliiion</param>
        /// <returns></returns>
        private bool GenerateCollision(int threadNumber, Hasher.HashingAlgorithm algorithm, int length, long maxAttempts, bool useHexForOutput, out string collision1, out string collision2)
        {
            try
            {
                collision1 = "";
                collision2 = "";
                List<string> hashedList = new List<string>();
                List<string> textList = new List<string>();
                //Random random = new Random((int)(DateTime.Now.Ticks * threadNumber)); old RNG

                while (!foundCollision && !stopHashing && !attemptsRanOut)
                {
                    Interlocked.Increment(ref attempts);
                    string randomText = GenerateRandomString(length);
                    string hashedValue = hasher.Hash(randomText, algorithm);

                    if (hashedList.Contains(hashedValue))
                    {
                        int collisionIndex = hashedList.IndexOf(hashedValue);
                        collision1 = textList[collisionIndex];
                        collision2 = randomText;

                        if (collision1 != collision2)
                        {
                            foundCollision = true;
                            if (Settings.ShowLog)
                            {
                                string s = Languages.Translate(Languages.L.CollisionFound) + ": " + collision1 + " " + Languages.Translate(Languages.L.And) + " " + collision2;
                                if (useHexForOutput) s = Languages.Translate(Languages.L.CollisionFound) + ": " + FormManagement.ConvertStringToHex(collision1) + " " + Languages.Translate(Languages.L.And) + " " + FormManagement.ConvertStringToHex(collision2);
                                Invoke((Action)(() => listBoxLog.Items.Add(s)));
                                Invoke((Action)(() => listBoxLog.TopIndex = listBoxLog.Items.Count - 1));
                            }
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


        /// <summary>
        /// Generates a random string based on lenght
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GenerateRandomString(int length)
        {
            Random random = new Random(GenerateRandomSeed());
            char[] result = new char[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = (char)random.Next(0, 256); 
            }
            return new string(result);
        }


        /// <summary>
        /// UI updates timer
        /// </summary>
        private void UpdateTimerLabel()
        {
            try
            {
                //Update Timer
                if (stopwatch != null && stopwatch.ElapsedMilliseconds != 0)
                {
                    int seconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
                    int milliseconds = (int)(stopwatch.ElapsedMilliseconds % 1000);
                    labelTimer.Text = Languages.Translate(Languages.L.Timer) + ": " + seconds + "." + milliseconds + " s";
                    int triesBetween = (int)(attempts - numberOfAttempsInLastUpdate);
                    numberOfAttempsInLastUpdate = attempts;
                    //Attempts
                    labelAttempts.Text = Languages.Translate(Languages.L.NumberOfAttempts) + ": " + attempts;
                    //Update Speed
                    double speed = triesBetween / (Settings.UpdateUIms / 1000.0);
                    labelCurrentSpeed.Text = Languages.Translate(Languages.L.CurrentSpeed) + ": " + Math.Floor(speed);
                    //Update Average Speed
                    double averageSpeed = attempts / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
                    labelAverageSpeed.Text = Languages.Translate(Languages.L.AverageSpeed) + ": " + Math.Floor(averageSpeed);
                    //listbox
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1; // Scroll to the most recent item
                }
            }
            catch (DivideByZeroException) { return; } //it does that
            catch (Exception ex) { Console.WriteLine("Collision UI problem: " + ex.Message); }
        }


        /// <summary>
        /// Does exactly how it sounds
        /// </summary>
        /// <param name="message"></param>
        /// <param name="collisionText01"></param>
        /// <param name="collisionText02"></param>
        public void CollisionFoundMessageBox(string message, string collisionText01, string collisionText02)
        {           
            if (MessageBox.Show(Languages.Translate(Languages.L.WouldYouLikeToSaveCollisionToATxtFile), Languages.Translate(Languages.L.Confirmation), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string path = Path.GetFullPath(Settings.DirectoryPathToCollisions);
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
                    writer.WriteLine(FormManagement.ConvertStringToHex(collisionText01));
                    writer.WriteLine(FormManagement.ConvertStringToHex(collisionText02));
                    writer.WriteLine("<HASH>");
                    writer.WriteLine("hash1: " + hasher.Hash(collisionText01, algorithm));
                    writer.WriteLine("hash2: " + hasher.Hash(collisionText02, algorithm));
                }
            }
            MessageBox.Show(message, Languages.Translate(Languages.L.CollisionFound), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region CollisionDetection        
        private void buttonCheckCollision_Click(object sender, EventArgs e)
        {
            CheckCollisionForm checkCollisionForm = new CheckCollisionForm();
            checkCollisionForm.StartPosition = FormStartPosition.CenterScreen;
            checkCollisionForm.Name = Languages.Translate(Languages.L.HashCollisionChecker);
            checkCollisionForm.Show();
        }       

        #endregion

        private void TurnOffUI()
        {
            //Timer for UI update
            timeToFindCollision.Interval = Settings.UpdateUIms;
            timeToFindCollision.Tick += (s, args) => UpdateTimerLabel();
            timeToFindCollision.Start();
            //Stopwatch
            buttonReturn.Enabled = false;
            buttonClearListBox.Enabled = false;
            buttonGenerateCollision.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            hashSelector.Enabled = false;
            checkBoxUseHex.Enabled = false;
            checkBoxPerformanceMode.Enabled = false;
            buttonCheckCollision.Enabled = false;
        }

        private void TurnOnUI()
        {
            //timer
            timeToFindCollision.Dispose();
            //stopwatch
            stopwatch.Reset();  
            //UI
            buttonReturn.Enabled = true;
            buttonClearListBox.Enabled = true;
            buttonGenerateCollision.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            hashSelector.Enabled = true;
            checkBoxUseHex.Enabled = true;
            checkBoxPerformanceMode.Enabled = true;
            buttonCheckCollision.Enabled = true;
        }

        private void HashingCollisionForm_Load(object sender, EventArgs e) //Checks if an info.txt is already present
        {
            #region Languages
            this.Name = Languages.Translate(Languages.L.CollisionFinder);
            buttonCheckCollision.Text = Languages.Translate(Languages.L.CheckCollision);
            buttonGenerateCollision.Text = Languages.Translate(Languages.L.GenerateACollision);            
            buttonAbort.Text = Languages.Translate(Languages.L.CancelTheProcess);
            buttonReturn.Text = Languages.Translate(Languages.L.GoBack);
            labelAttempts.Text = Languages.Translate(Languages.L.NumberOfAttempts);
            labelAverageSpeed.Text = Languages.Translate(Languages.L.AverageSpeed);
            labelCurrentSpeed.Text = Languages.Translate(Languages.L.CurrentSpeed);
            labelLenght.Text = Languages.Translate(Languages.L.LenghtOfTheRandomText);
            labelTimer.Text = Languages.Translate(Languages.L.Timer);
            checkBoxPerformanceMode.Text = Languages.Translate(Languages.L.PerformanceMode);
            checkBoxUseHex.Text = Languages.Translate(Languages.L.UseHexToDisplayText);
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            groupBoxUI.Text = Languages.Translate(Languages.L.Ui);
            #endregion
            FormManagement.SetUpFormTheme(this);
            hashSelector.SelectedIndex = 0;
            string path = Settings.DirectoryPathToCollisions;
            if (!File.Exists(path + "_collisionInfo.txt")) Settings.InitialFolderChecker();
        }

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAnItemFromTheLogListboxBeforeCopying), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard),Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }

        private void ResetValues()
        {
            stopHashing = false;
            foundCollision = false;
            attemptsRanOut = false;
            textCollision01 = "";
            textCollision02 = "";
            maxAttempts = 0;
            attempts = 0;
            numberOfAttempsInLastUpdate = 0;
            stopwatch.Reset();
        }


        /// <summary>
        /// Generates random int seed (crazy I know)
        /// </summary>
        /// <returns></returns>
        private static int GenerateRandomSeed()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] buffer = new byte[4];
                rng.GetBytes(buffer);
                return BitConverter.ToInt32(buffer, 0) & int.MaxValue; // Ensure positive seed
            }
        }
    }
}
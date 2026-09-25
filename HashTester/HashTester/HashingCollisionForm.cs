/**
 *@author: Kamil Franek
 *@date: 23.09.2026
 *@brief: UI Form for finding hashing collisions
 *@file: HashingCollisionForm.cs
 */


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Security.Policy;
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
        /// <summary>
        /// First method ran by the form
        /// </summary>
        public HashingCollisionForm()
        {
            InitializeComponent();
        }
        const int numberToNextCheckOnProbability = 10000; //Can be changed
        Hasher hasher = new Hasher();
        Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.CRC32; //Standard algorithm
        volatile bool stopHashing = false; // Volatile for thread safety
        volatile bool foundCollision = false;
        volatile bool attemptsRanOut = false;
        volatile string textCollision01 = "";
        volatile string textCollision02 = "";
        long maxAttempts = 0; //Limit for attempts
        long attempts = 0;
        long numberOfAttempsInLastUpdate = 0; //The time is 16ms
        Stopwatch stopwatch = new Stopwatch();
        private Timer timeToFindCollision = new Timer();

        #region Form

        /// <summary>
        /// Resets Log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Cancels the collision finder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            stopHashing = true;
        }

        #endregion

        #region CollisionGenerator3000

        /// <summary>
        /// Main method for finding collisions. Connected to UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void buttonGenerateCollision_Click(object sender, EventArgs e)
        {
            //Timer for UI update
            timeToFindCollision.Interval = Settings.UpdateUIms; //Sets up timer
            timeToFindCollision.Tick += (s, args) => UpdateTimerLabel();
            ResetValues();
            timeToFindCollision.Start();
            TurnOffUI(this);
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
                for (int i = 0; i < maxThreads; i++) //Starts multithread
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
            TurnOnUI(this);
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
                    catch
                    { 
                        Console.WriteLine("Error while trying to log time to find collision");
                    }
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
            else if (stopHashing) //Message for ButtonCancel
            {
                MessageBox.Show(Languages.Translate(Languages.L.TheProcessHasBeenAbandoned), Languages.Translate(Languages.L.Abandoned), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.TheProcessHasBeenAbandoned));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else if (attemptsRanOut) //Message for ran out of attempts
            {
                MessageBox.Show(Languages.Translate(Languages.L.CouldNotFindACollisionUnderTheGivenAttempts), Languages.Translate(Languages.L.Abandoned), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.CouldNotFindACollisionUnderTheGivenAttempts));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else //General Message
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
        /// Starts finding hash collision for a single thread
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
        /// Chance to find in next x attempts
        /// </summary>
        /// <param name="attempts">Number of attempts taken</param>
        /// <param name="n">lenght of hash</param>
        /// <returns></returns>
        double ChanceOfCollisionInWholeBatch(long attempts, double n)
        {
            return 1.0 - Math.Exp(-(attempts * (attempts - 1)) / (2.0 * n));
        }

        /// <summary>
        /// Chance to find in next x attempts
        /// </summary>
        /// <param name="attempts">Number of attempts taken</param>
        /// <param name="hash">Hashing algorithm used</param>
        /// <returns></returns>
        double ChanceOfCollisionInWholeBatch(long attempts, Hasher.HashingAlgorithm hash)
        {
            double n;
            switch (hash)
            {
                case Hasher.HashingAlgorithm.SHA1: n = Math.Pow(2, 160); break;
                case Hasher.HashingAlgorithm.SHA256: n = Math.Pow(2, 256); break;
                case Hasher.HashingAlgorithm.MD5: n = Math.Pow(2, 128); break;
                case Hasher.HashingAlgorithm.SHA512: n = Math.Pow(2, 512); break;
                case Hasher.HashingAlgorithm.RIPEMD160: n = Math.Pow(2, 160); break;
                case Hasher.HashingAlgorithm.CRC32: n = Math.Pow(2, 32); break;
                default: return 0f;
            }
            return ChanceOfCollisionInWholeBatch(attempts, n);
        }


        /// <summary>
        /// Chance to find in next x attempts (default is 10k)
        /// </summary>
        /// <param name="currentAttempts"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public float ChanceOfCollisionInNextBatch(long currentAttempts, Hasher.HashingAlgorithm hash)
        {
            double n;
            switch (hash)
            {
                case Hasher.HashingAlgorithm.SHA1: n = Math.Pow(2, 160); break;
                case Hasher.HashingAlgorithm.SHA256: n = Math.Pow(2, 256); break;
                case Hasher.HashingAlgorithm.MD5: n = Math.Pow(2, 128); break;
                case Hasher.HashingAlgorithm.SHA512: n = Math.Pow(2, 512); break;
                case Hasher.HashingAlgorithm.RIPEMD160: n = Math.Pow(2, 160); break;
                case Hasher.HashingAlgorithm.CRC32: n = Math.Pow(2, 32); break;
                default: return 0f;
            }

            double PtotalAfterNext = ChanceOfCollisionInWholeBatch(currentAttempts + numberToNextCheckOnProbability, n);
            double PtotalCurrent = ChanceOfCollisionInWholeBatch(currentAttempts, n);

            double PnextBatch = PtotalAfterNext - PtotalCurrent;
            return (float)PnextBatch;
        }



        int attemptsChanceToNextProbability = 0;

        /// <summary>
        /// UI update timer running on X fps
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
                    attemptsChanceToNextProbability += triesBetween;
                    numberOfAttempsInLastUpdate = attempts;
                    //Attempts
                    labelAttempts.Text = Languages.Translate(Languages.L.NumberOfAttempts) + ": " + attempts;
                    //Update Speed
                    double speed = triesBetween / (Settings.UpdateUIms / 1000.0);
                    labelCurrentSpeed.Text = Languages.Translate(Languages.L.CurrentSpeed) + ": " + Math.Floor(speed);
                    //Update Average Speed
                    double averageSpeed = attempts / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
                    labelAverageSpeed.Text = Languages.Translate(Languages.L.AverageSpeed) + ": " + Math.Floor(averageSpeed);
                    //Chance to find in next update
                    if (attemptsChanceToNextProbability >= numberToNextCheckOnProbability) //Optimalization
                    {
                        attemptsChanceToNextProbability = 0;
                        labelCumulativeChanceToFind.Text = Languages.Translate(Languages.L.CumulativeChanceToFind) + ": " + (ChanceOfCollisionInWholeBatch(attempts, algorithm) * 100).ToString() + "%";
                        labelChanceToFind.Text = Languages.Translate(Languages.L.ChanceToFindIn)  + " " + (numberToNextCheckOnProbability / 1000.0).ToString() + "k " + Languages.Translate(Languages.L.Attempts) + ": " + (ChanceOfCollisionInNextBatch(attempts, algorithm) * 100).ToString() + "%";
                    }
                    //listbox
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1; // Scroll to the most recent item
                }
            }
            catch (DivideByZeroException) { return; } //it does that
            catch (Exception ex) { Console.WriteLine("Collision UI problem: " + ex.Message); }
        }


        /// <summary>
        /// Spawns a MessageBox with collisionFoundMessage
        /// Asks if the user would like to save it
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

        /// <summary>
        /// Spawns a small form for checking collision
        /// (Use SpawnForm)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheckCollision_Click(object sender, EventArgs e)
        {
            CheckCollisionForm checkCollisionForm = new CheckCollisionForm();
            checkCollisionForm.StartPosition = FormStartPosition.CenterScreen;
            checkCollisionForm.Name = Languages.Translate(Languages.L.HashCollisionChecker);
            checkCollisionForm.Show();
        }       

        /// <summary>
        /// Turns On UI
        /// </summary>
        /// <param name="control"></param>
        private void TurnOnUI(Control control)
        {
            control.Enabled = true;
            foreach (Control child in control.Controls)
            {
                TurnOnUI(child); //Recursion
            }
        }

        /// <summary>
        /// Turns all of UI components off
        /// </summary>
        private void TurnOffUI(Control parent)
        {
            if (parent is Label || parent == buttonAbort)
            {
                return; //skip labels and cancel button
            }
            //Console.WriteLine("TurnOffUI: " + parent.Name);
            if (parent is GroupBox || parent is TableLayoutPanel || parent is Form)
            {
                foreach (Control control in parent.Controls)
                {
                    TurnOffUI(control); //Recursion
                }
                return;
            }
            parent.Enabled = false;
        }

        /// <summary>
        /// Loads Form after a spawn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HashingCollisionForm_Load(object sender, EventArgs e) //Checks if an info.txt is already present
        {
            //StripMenu.LoadStripMenu(this);
            #region Languages
            this.Name = Languages.Translate(Languages.L.CollisionFinder);
            buttonCheckCollision.Text = Languages.Translate(Languages.L.CheckCollision);
            buttonGenerateCollision.Text = Languages.Translate(Languages.L.GenerateACollision);            
            buttonAbort.Text = Languages.Translate(Languages.L.CancelTheProcess);
            buttonReturn.Text = Languages.Translate(Languages.L.GoBack);
            labelAttempts.Text = Languages.Translate(Languages.L.NumberOfAttempts) + ":";
            labelAverageSpeed.Text = Languages.Translate(Languages.L.AverageSpeed) + ":";
            labelCurrentSpeed.Text = Languages.Translate(Languages.L.CurrentSpeed) + ":";
            labelLenght.Text = Languages.Translate(Languages.L.LenghtOfTheRandomText);
            labelTimer.Text = Languages.Translate(Languages.L.Timer) + ":";
            checkBoxPerformanceMode.Text = Languages.Translate(Languages.L.PerformanceMode);
            checkBoxUseHex.Text = Languages.Translate(Languages.L.UseHexToDisplayText);
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            groupBoxUI.Text = Languages.Translate(Languages.L.Ui);
            labelCumulativeChanceToFind.Text = Languages.Translate(Languages.L.CumulativeChanceToFind) + ":";
            labelChanceToFind.Text = Languages.Translate(Languages.L.ChanceToFindIn) + ":";
            #endregion
            FormManagement.LoadForm(this); 
            hashSelector.SelectedIndex = 0;
            //Checks if the info file exists
            string path = Settings.DirectoryPathToCollisions;
            if (!File.Exists(path + "_collisionInfo.txt")) Settings.InitialFolderChecker();
        }

        /// <summary>
        /// Copies the selected item in log to Clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Saves Log to .txt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }

        /// <summary>
        /// Resets all important values for calculations
        /// </summary>
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
                return BitConverter.ToInt32(buffer, 0) & int.MaxValue; // Ensure positive seed :)
            }
        }
    }
}
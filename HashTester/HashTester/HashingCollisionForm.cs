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
            if (maxAttempts > 0 && checkBoxListBoxLog.Checked) listBoxLog.Items.Add(Languages.Translate(603) + ": " + maxAttempts); 
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
            if (checkBoxPerformanceMode.Checked && FormManagement.UseMultiThread())
            {
                if (checkBoxListBoxLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(114));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                int maxThreads = FormManagement.NumberOfThreadsToUse();
                if (checkBoxListBoxLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(115)  + ": "+ maxThreads);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }                
                for (int i = 0; i < maxThreads - 1; i++) //multiThread
                {
                    int threadIndex = i;
                    allTasks.Add(Task.Run(() => CollisionThread(threadIndex, algorithm, maxAttempts, rngTextLenght, false, checkBoxUseHex.Checked)));
                }
            }
            else //single Thread
            {
                if (checkBoxListBoxLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(116));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                allTasks.Add(Task.Run(() => CollisionThread(1, algorithm, maxAttempts, rngTextLenght, checkBoxListBoxLog.Checked, checkBoxUseHex.Checked)));
            }
            await Task.WhenAll(allTasks);
            stopwatch.Stop();
            TurnOnUI();
            if (foundCollision) 
            {                
                //LogOutput
                if (checkBoxListBoxLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(117));
                    listBoxLog.Items.Add(Languages.Translate(118) + " 1: " + (textCollision01));
                    if (checkBoxUseHex.Checked) listBoxLog.Items.Add(Languages.Translate(118) + " 1 (" + Languages.Translate(10037) + "): " + ConvertStringToHex(textCollision01));
                    listBoxLog.Items.Add(Languages.Translate(118) + " 2: " + (textCollision02));
                    if (checkBoxUseHex.Checked) listBoxLog.Items.Add(Languages.Translate(118) + " 2 (" + Languages.Translate(10037) + "): " + ConvertStringToHex(textCollision02));
                    listBoxLog.Items.Add(Languages.Translate(119) + ": " + hasher.Hash(textCollision01, algorithm));
                    listBoxLog.Items.Add(Languages.Translate(120) + ": " + attempts);
                    try { listBoxLog.Items.Add(Languages.Translate(121) + ": " + labelTimer.Text.Split(' ')[1]); } //so that I dont have to format it again :)
                    catch { /*Hi :3*/ }
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                //MessageBoxOutput
                string message = Languages.Translate(117) + Environment.NewLine + Languages.Translate(118) + " 1: " + textCollision01;
                if (checkBoxUseHex.Checked) message += Environment.NewLine + Languages.Translate(118) + " 1 (" + Languages.Translate(10037) + "): " + ConvertStringToHex(textCollision01);
                message += Environment.NewLine + Languages.Translate(118) + " 2: " + textCollision02;
                if (checkBoxUseHex.Checked) message += Environment.NewLine + Languages.Translate(118) + " 2 (" + Languages.Translate(10037) + "): " + ConvertStringToHex(textCollision02);
                message += Environment.NewLine + Languages.Translate(119) + ": " + hasher.Hash(textCollision01, algorithm) + 
                    Environment.NewLine + Languages.Translate(120) + ": " + attempts;
                listBoxLog.Items.Add(message);
                try { message += Environment.NewLine + Languages.Translate(121) + ": " + labelTimer.Text.Split(' ')[1]; }
                catch { /*Back again?*/}
                CollisionFoundMessageBox(message, textCollision01, textCollision02);
            }
            else if (stopHashing)
            {
                MessageBox.Show(Languages.Translate(10017), Languages.Translate(10019), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (checkBoxListBoxLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(10017));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else if (attemptsRanOut)
            {
                MessageBox.Show(Languages.Translate(10016), Languages.Translate(10019), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (checkBoxListBoxLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(10016));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else
            {
                MessageBox.Show(Languages.Translate(10018), Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (checkBoxListBoxLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(10018));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            } 
        }

        private void CollisionThread(int threadNumber, Hasher.HashingAlgorithm algorithm, long maxAttempts, int length, bool saveLogToListBox, bool useHexForOutput)
        {
            attempts = 0;
            bool useAttempts = false;
            if (maxAttempts > 0) useAttempts = true;            
            if (GenerateCollision(threadNumber, algorithm, length, maxAttempts, useAttempts, saveLogToListBox, useHexForOutput, out string collision01, out string collision02))
            {
                //Console.WriteLine("Le " + threadNumber + " found collision");
                textCollision01 = collision01;
                textCollision02 = collision02;
                foundCollision = true;
            }
            else stopHashing = true;
            //Console.WriteLine("Le " + threadNumber + " has ended.");
        }

        private bool GenerateCollision(int threadNumber, Hasher.HashingAlgorithm algorithm, int length, long maxAttempts, bool useAttemps, bool saveLog, bool useHexForOutput, out string collision1, out string collision2)
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
                            if (saveLog)
                            {
                                string s = Languages.Translate(122) + ": " + collision1 + " " + Languages.Translate(10021) + " " + collision2;
                                if (useHexForOutput) s = Languages.Translate(122) + ": " + ConvertStringToHex(collision1) + " " + Languages.Translate(10021) + " " + ConvertStringToHex(collision2);
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

        private void UpdateTimerLabel()
        {
            try
            {
                //Update Timer
                if (stopwatch != null && stopwatch.ElapsedMilliseconds != 0)
                {
                    int seconds = (int)(stopwatch.ElapsedMilliseconds / 1000);
                    int milliseconds = (int)(stopwatch.ElapsedMilliseconds % 1000);
                    labelTimer.Text = Languages.Translate(10009) + ": " + seconds + "." + milliseconds + " s";
                    int triesBetween = (int)(attempts - numberOfAttempsInLastUpdate);
                    numberOfAttempsInLastUpdate = attempts;
                    //Attempts
                    labelAttempts.Text = Languages.Translate(10010) + ": " + attempts;
                    //Update Speed
                    double speed = triesBetween / (Settings.UpdateUIms / 1000.0);
                    labelCurrentSpeed.Text = Languages.Translate(10011) + ": " + Math.Floor(speed);
                    //Update Average Speed
                    double averageSpeed = attempts / (stopwatch.ElapsedMilliseconds / 1000.0); //Average speed per second
                    labelAverageSpeed.Text = Languages.Translate(10012) + ": " + Math.Floor(averageSpeed);
                    //listbox
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1; // Scroll to the most recent item
                }
            }
            catch (DivideByZeroException) { return; } //it does that
            catch (Exception ex) { Console.WriteLine("Collision UI problem: " + ex.Message); }
        }

        public void CollisionFoundMessageBox(string message, string collisionText01, string collisionText02)
        {           
            if (MessageBox.Show(Languages.Translate(123), Languages.Translate(46), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                    writer.WriteLine(ConvertStringToHex(collisionText01));
                    writer.WriteLine(ConvertStringToHex(collisionText02));
                    writer.WriteLine("<HASH>");
                    writer.WriteLine("hash1: " + hasher.Hash(collisionText01, algorithm));
                    writer.WriteLine("hash2: " + hasher.Hash(collisionText02, algorithm));
                }
            }
            MessageBox.Show(message, Languages.Translate(117), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region CollisionDetection        
        private void buttonCheckCollision_Click(object sender, EventArgs e)
        {
            CheckCollisionForm checkCollisionForm = new CheckCollisionForm();
            checkCollisionForm.StartPosition = FormStartPosition.CenterScreen;
            checkCollisionForm.Name = Languages.Translate(15003);
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
            checkBoxListBoxLog.Enabled = false;
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
            checkBoxListBoxLog.Enabled = true;
            checkBoxUseHex.Enabled = true;
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
        #endregion

        private void HashingCollisionForm_Load(object sender, EventArgs e) //Checks if an info.txt is already present
        {
            #region Languages
            this.Name = Languages.Translate(704);
            buttonCheckCollision.Text = Languages.Translate(111);
            buttonGenerateCollision.Text = Languages.Translate(112);            
            buttonAbort.Text = Languages.Translate(10005);
            buttonReturn.Text = Languages.Translate(10006);
            labelAttempts.Text = Languages.Translate(10010);
            labelAverageSpeed.Text = Languages.Translate(10012);
            labelCurrentSpeed.Text = Languages.Translate(10011);
            labelLenght.Text = Languages.Translate(10008);
            labelTimer.Text = Languages.Translate(10009);
            checkBoxListBoxLog.Text = Languages.Translate(10013);
            checkBoxPerformanceMode.Text = Languages.Translate(10015);
            checkBoxUseHex.Text = Languages.Translate(10014);
            buttonClearListBox.Text = Languages.Translate(10000);
            buttonClipboard.Text = Languages.Translate(10002);
            buttonSaveLog.Text = Languages.Translate(10001);
            groupBoxUI.Text = Languages.Translate(10036);
            #endregion
            FormManagement.SetUpFormTheme(this);
            hashSelector.SelectedIndex = 0;
            string path = Settings.DirectoryPathToCollisions;
            Console.Write(path + "_collisionInfo.txt");
            if (!File.Exists(path + "_collisionInfo.txt"))
            {
                string s = Languages.Translate(130) + Environment.NewLine +
                               Languages.Translate(131) + Environment.NewLine +
                               Languages.Translate(132) + Environment.NewLine +
                               Languages.Translate(133) + Environment.NewLine +
                               Languages.Translate(134) + Environment.NewLine +
                               Languages.Translate(135) + Environment.NewLine +
                               Languages.Translate(136);
                File.WriteAllText(path + "_collisionInfo.txt", s);
                Console.WriteLine("Generated _collisionInfo.txt into the " + path);
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
                MessageBox.Show(Languages.Translate(1003),Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
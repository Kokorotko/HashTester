using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer; // Using Windows Forms Timer

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

        private Timer timer; // Declare a Timer object for updating timer label.

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void buttonReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGenerateCollision_Click(object sender, EventArgs e)
        {
            TurnOffUI();
            stopHashing = false; 
            maxAttempts = (long)numericUpDown1.Value;
            int length = (int)numericUpDown2.Value;
            //Timer
            timeToCalculate = 0;
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) => UpdateTimerLabel();
            timer.Start();

            switch (hashSelector.SelectedIndex)
            {
                case 0: algorithm = Hasher.HashingAlgorithm.CRC32; break;
                case 1: algorithm = Hasher.HashingAlgorithm.RIPEMD160; break;
                case 2: algorithm = Hasher.HashingAlgorithm.MD5; break;
                case 3: algorithm = Hasher.HashingAlgorithm.SHA1; break;
                default: algorithm = Hasher.HashingAlgorithm.CRC32; break;
            }

            collisionThread = new Thread(() => CollisionThread(algorithm, maxAttempts, length));
            collisionThread.Start();
        }

        private void CollisionThread(Hasher.HashingAlgorithm algorithm, long maxAttempts, int length)
        {
            bool foundCollision = false, attemptsRanOut = false;
            string textCollision01 = "", textCollision02 = "";
            attempts = 0; // Reset attempts

            bool useAttempts = false;
            if (maxAttempts > 0) useAttempts = true;
            foundCollision = GenerateCollision(algorithm, length, maxAttempts, useAttempts, out textCollision01, out textCollision02, out attemptsRanOut);

            // Stop the timer when the collision process finishes
            timer.Stop();

            // Show results
            if (foundCollision)
            {
                string message = "Collision found!" +
                                 "\nCollision 1: " + textCollision01 +
                                 "\nCollision 2: " + textCollision02 +
                                 "\nAttempts: " + attempts + 
                                 "\nTime to find: " + labelTimer.Text;
                Invoke((Action)(() => MessageBox.Show(message, "Collision Found", MessageBoxButtons.OK, MessageBoxIcon.Information)));
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

        private bool GenerateCollision(Hasher.HashingAlgorithm algorithm, int length, long maxAttempts, bool useAttempts, out string collision1, out string collision2, out bool attemptsRanOut)
        {
            collision1 = "";
            collision2 = "";
            attemptsRanOut = false;
            bool foundCollision = false;
            var random = new Random();
            var collisionList = new List<string>();
            var collisionListOriginalText = new List<string>();

            while (!foundCollision && !stopHashing && !attemptsRanOut)
            {
                // Increment attempts atomically
                Interlocked.Increment(ref attempts);

                // Update attempts label
                Invoke((Action)UpdateAttemptsLabel);

                // Generate a random string
                string randomText = GenerateRandomString(random, length);
                string hashedValue = hasher.Hash(randomText, algorithm);
                Console.WriteLine("Random Text: " + hashedValue);
                // Check for collision
                if (collisionList.Contains(hashedValue))
                {
                    int collisionIndex = collisionList.IndexOf(hashedValue);
                    collision1 = collisionListOriginalText[collisionIndex];
                    collision2 = randomText;
                    if (collision1 != collision2) foundCollision = true;
                    else
                    {
                        Console.WriteLine("Found duplicate: " + collision1 + " " + collision2);
                        collisionList.RemoveAt(collisionIndex); //Removes the duplicate
                        collisionListOriginalText.RemoveAt(collisionIndex);
                    }
                }
                else
                {
                    collisionList.Add(hashedValue);
                    collisionListOriginalText.Add(randomText);
                }

                // Check if maximum attempts are reached
                if (useAttempts && attempts >= maxAttempts) attemptsRanOut = true;
            }
            return foundCollision;
        }

        private string GenerateRandomString(Random random, int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopHashing = true;
        }

        private void TurnOffUI()
        {
            buttonGenerateCollision.Enabled = false;
            buttonTakeCollisionFromTXT.Enabled = false;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            hashSelector.Enabled = false;
        }

        private void TurnOnUI()
        {
            buttonGenerateCollision.Enabled = true;
            buttonTakeCollisionFromTXT.Enabled = true;
            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            hashSelector.Enabled = true;
        }

        private void UpdateAttemptsLabel()
        {
            label3.Text = "Number of attempts: " + attempts;
        }

        private void UpdateTimerLabel()
        {
            labelTimer.Text = "Timer: " + (timeToCalculate / 10) + "." + (timeToCalculate % 10) + "s";
            timeToCalculate++;
        }
    }
}

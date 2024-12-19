using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    public partial class HashingCollisionForm : Form
    {
        public HashingCollisionForm()
        {
            InitializeComponent();
        }
        Hasher hasher = new Hasher();
        bool stopHashing = false;

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
            bool foundCollision = false;
            string textCollision01 = "", textCollision02 = "";
            long attempts = 0;
            Timer timeToFind = new Timer();

            if (hashSelector.SelectedIndex != 5)
            {
                CollisionChecker collisionChecker = new CollisionChecker();
                if (collisionChecker.ShowDialog() == DialogResult.OK)
                {
                    switch (hashSelector.SelectedIndex)
                    {
                        case 0: // MD5
                            {
                                foundCollision = GenerateCollision(Hasher.HashingAlgorithm.MD5, out textCollision01, out textCollision02, out attempts, out timeToFind);
                                break;
                            }
                        case 1: // SHA1
                            {
                                foundCollision = GenerateCollision(Hasher.HashingAlgorithm.SHA1, out textCollision01, out textCollision02, out attempts, out timeToFind);
                                break;
                            }
                        case 2: // SHA256
                            {
                                foundCollision = GenerateCollision(Hasher.HashingAlgorithm.SHA256, out textCollision01, out textCollision02, out attempts, out timeToFind);
                                break;
                            }
                        case 3: // SHA512
                            {
                                foundCollision = GenerateCollision(Hasher.HashingAlgorithm.SHA512, out textCollision01, out textCollision02, out attempts, out timeToFind);
                                break;
                            }
                        case 4: // RipeMD-160
                            {
                                foundCollision = GenerateCollision(Hasher.HashingAlgorithm.RIPEMD160, out textCollision01, out textCollision02, out attempts, out timeToFind);
                                break;
                            }
                        default:
                            {
                                MessageBox.Show("Invalid hash algorithm selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                    }
                }
            }
            else // CRC32
            {
                foundCollision = GenerateCollision(Hasher.HashingAlgorithm.CRC32, out textCollision01, out textCollision02, out attempts, out timeToFind);
            }

            if (foundCollision)
            {
                if (!string.IsNullOrEmpty(textCollision01) && !string.IsNullOrEmpty(textCollision02))
                {
                    MessageBox.Show("Collision found!\n" +
                                    "Collision 1: " + textCollision01 + Environment.NewLine +
                                    "Collision 2: " + textCollision02 + Environment.NewLine +
                                    "Attempts: " + attempts.ToString() + Environment.NewLine +
                                    "Time Taken: " + timeToFind.Interval.ToString() + " ms",
                                    "Collision Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occurred while finding the collision.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("The process has been abandoned.", "Abandoned", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private bool GenerateCollision(Hasher.HashingAlgorithm algorithm, out string originalTextCollision01, out string originalTextCollision02, out long attemps, out Timer timeToFind)
        {
            bool foundCollision = false;
            List<string> collisionList = new List<string>();
            List<string> collisionListOriginalText = new List<string>();
            originalTextCollision01 = "";
            originalTextCollision02 = "";
            attemps = 0;
            Random random = new Random();
            bool useAttempts = true;
            bool attemptsRanOut = false;
            decimal maxAttempts = numericUpDown1.Value;
            if (maxAttempts == 0) useAttempts = false;
            timeToFind = new Timer();
            timeToFind.Start();
            while (!foundCollision && !stopHashing && !attemptsRanOut)
            {
                labelTimer.Text = "Timer: " + timeToFind.Interval.ToString() + " ms";
                attemps++;
                // Generate a random string
                string randomText = GenerateRandomString(random, 10);
                string hashedValue = hasher.Hash(randomText, algorithm);

                // Check for collision
                if (collisionList.Contains(hashedValue))
                {
                    int collisionIndex = collisionList.IndexOf(hashedValue);
                    originalTextCollision01 = collisionListOriginalText[collisionIndex];
                    originalTextCollision02 = randomText;
                    foundCollision = true;
                }
                else
                {
                    collisionList.Add(hashedValue);
                    collisionListOriginalText.Add(randomText);
                }
                //Attempts
                if (useAttempts)
                {
                    if (attemps >= maxAttempts) attemptsRanOut = true;
                }
            }
            timeToFind.Stop();
            if (stopHashing)
            {
                MessageBox.Show("The collision finding has been abandoned", "God Have Mercy", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
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
    }
}
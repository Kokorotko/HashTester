using System;
using System.Diagnostics.Eventing.Reader;
using System.Management;
using System.Windows.Forms;

namespace HashTester
{
    public partial class ThreadsForm : Form
    {
        private int numberOfThreadsInCPU = Environment.ProcessorCount;
        private int percentage = 0;
        private bool updating = false;// Prevents infinite loops in text change events
        private bool unsavedChanges = false;

        public ThreadsForm()
        {
            InitializeComponent();
        }
        public int Percentage
        {
            get => (percentage >= 0 && percentage <= 100) ? percentage : 50; //Range from 0 to 100, if outside, it is set to default (50%)
            private set { percentage = value; }
        }

        public void RadioButtonPressed(object sender, EventArgs e)
        {
            if (radioButtonThread1.Checked)
            {
                textBoxPercent.Text = "0";
                textBoxThread.Text = "1";
            }
            else if (radioButtonThread2.Checked)
            {
                textBoxThread.Text = "2";
            }
            else if (radioButtonThread3.Checked)
            {
                textBoxThread.Text = "4";
            }
            else if (radioButtonThread4.Checked)
            {
                textBoxThread.Text = "8";
            }
            else if (radioButtonThreadMax.Checked)
            {
                textBoxThread.Text = numberOfThreadsInCPU.ToString();
            }
            else if (radioButtonPercentHunred.Checked)
            {
                textBoxPercent.Text = "100";
            }
            else if (radioButtonPercent2.Checked)
            {
                textBoxPercent.Text = "75";
            }
            else if (radioButtonPercent3.Checked)
            {
                textBoxPercent.Text = "50";
            }
            else if (radioButtonPercent4.Checked)
            {
                textBoxPercent.Text = "25";
            }
            else // radioButtonPercent5.Checked
            {
                textBoxPercent.Text = "0";
                textBoxThread.Text = "1";
            }
        }

        private void textBoxThread_TextChanged(object sender, EventArgs e)
        {            
            if (updating) return;
            updating = true;
            unsavedChanges = true;

            if (int.TryParse(textBoxThread.Text, out int threads) && threads > 0)
            {
                if (threads > numberOfThreadsInCPU) // bigger than max Threads
                {
                    textBoxThread.Text = numberOfThreadsInCPU.ToString();
                    textBoxPercent.Text = "100";
                }
                else
                {
                    int percent = (int)((double)threads / numberOfThreadsInCPU * 100);
                    textBoxPercent.Text = Math.Min(percent, 100).ToString();
                }
            }
            else
            {
                textBoxPercent.Text = "0";
            }
            updating = false;
        }

        private void textBoxPercent_TextChanged(object sender, EventArgs e)
        {
            if (updating) return;
            updating = true;
            unsavedChanges = true;

            if (int.TryParse(textBoxPercent.Text, out int percent) && percent >= 0 )
            {
                if (percent > 100)
                {
                    textBoxPercent.Text = "100";
                    textBoxThread.Text = numberOfThreadsInCPU.ToString();
                }
                int threads = Math.Max(1, (int)Math.Round(percent / 100.0 * numberOfThreadsInCPU));
                if (threads > numberOfThreadsInCPU) textBoxThread.Text = numberOfThreadsInCPU.ToString();
               else textBoxThread.Text = threads.ToString();
            }
            else
            {
                textBoxThread.Text = "1";
            }
            updating = false;
        }

        private void ThreadsForm_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
            #region Languages
            this.Name = Languages.Translate(710);
            labelHowMany.Text = Languages.Translate(421);
            labelThreads.Text = Languages.Translate(422);
            labelPercentages.Text = Languages.Translate(423);
            labelMaxThreads.Text = Languages.Translate(424);
            labelFrom0to100.Text = Languages.Translate(425);
            radioButtonThread1.Text = Languages.Translate(426);
            radioButtonThread2.Text = Languages.Translate(427);
            radioButtonThread3.Text = Languages.Translate(428);
            radioButtonThread4.Text = Languages.Translate(429);
            radioButtonThreadMax.Text = Languages.Translate(430);
            labelZeroPercent.Text = Languages.Translate(431);
            labelPreference.Text = "*" + Languages.Translate(432);
            labelCalculations.Text = "*" + Languages.Translate(433);
            buttonSave.Text = Languages.Translate(434);
            buttonDefault.Text = Languages.Translate(435);
            buttonCancel.Text = Languages.Translate(436);
            groupBox1.Text = Languages.Translate(437);
            #endregion
            // Get CPU Information using WMI
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    labelCPUName.Text = Languages.Translate(438) + ": " + (obj["Name"] ?? Languages.Translate(444));
                    labelCPUManufacturer.Text = Languages.Translate(439) + ": " + (obj["Manufacturer"] ?? Languages.Translate(444));
                    labelCPUDescription.Text = Languages.Translate(443) + ": " + (obj["Description"] ?? Languages.Translate(444));
                    labelCPUCores.Text = Languages.Translate(440) +": " + (obj["NumberOfCores"] ?? Languages.Translate(444));
                    labelCPUThread.Text = Languages.Translate(441) + ": " + (obj["NumberOfLogicalProcessors"] ?? Languages.Translate(444));
                    labelCPUMaxSpeed.Text = Languages.Translate(442) + ": " + (obj["MaxClockSpeed"] ?? Languages.Translate(444)) + " " + Languages.Translate(445);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Languages.Translate(446) + ": " + ex.Message, Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            percentage = Settings.ThreadsUsagePercentage;
            if (percentage == 100)
            {
                radioButtonPercentHunred.Checked = true;
                textBoxPercent.Text = "100";
            }
            else if (percentage == 75)
            {
                radioButtonPercent2.Checked = true;
                textBoxPercent.Text = "75";
            }
            else if (percentage == 50)
            {
                radioButtonPercent3.Checked = true;
                textBoxPercent.Text = "50";
            }
            else if (percentage == 25)
            {
                radioButtonPercent4.Checked = true;
                textBoxPercent.Text = "25";
            }
            else if (percentage == 0)
            {
                radioButtonPercentZero.Checked = true;
                textBoxPercent.Text = "0";
            }
            else if (percentage * numberOfThreadsInCPU == 1)
            {
                radioButtonThread1.Checked = true;
                textBoxThread.Text = "1";
            }
            else if (percentage / 100.00 * numberOfThreadsInCPU == 2)
            {
                radioButtonThread2.Checked = true;
                textBoxThread.Text = "2";
            }
            else if (percentage / 100.00 * numberOfThreadsInCPU == 4)
            {
                radioButtonThread3.Checked = true;
                textBoxThread.Text = "4";
            }
            else if (percentage / 100.00 * numberOfThreadsInCPU == 8)
            {
                radioButtonThread4.Checked = true;
                textBoxThread.Text = "8";
            }
            else
            {
                textBoxPercent.Text = percentage.ToString();
            }
            //Block Thread counts
            if (numberOfThreadsInCPU < 2)
            {
                radioButtonThread2.Enabled = false;
                radioButtonThread3.Enabled = false;
                radioButtonThread4.Enabled = false; 
            }
            else if (numberOfThreadsInCPU < 4)
            {
                radioButtonThread3.Enabled = false;
                radioButtonThread4.Enabled = false;
            }
            else if (numberOfThreadsInCPU < 8)
            {
                radioButtonThread4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Percentage = int.Parse(textBoxPercent.Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(447), Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDefault_Click(object sender, EventArgs e)
        {
            textBoxPercent.Text = "50";
        }

        private void ThreadsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Percentage = int.Parse(textBoxPercent.Text);
            if (Settings.ThreadsUsagePercentage == Percentage) unsavedChanges = false;
            if (unsavedChanges)
            {
                DialogResult temp = MessageBox.Show(Languages.Translate(602), Languages.Translate(10025), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                switch (temp)
                {
                    case DialogResult.Yes: DialogResult = DialogResult.OK; break;
                    case DialogResult.No: DialogResult = DialogResult.Cancel; break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }
    }
}

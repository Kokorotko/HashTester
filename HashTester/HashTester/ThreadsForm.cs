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
        private bool updating = false; // Prevents infinite loops in text change events

        public ThreadsForm()
        {
            InitializeComponent();
        }
        public int Percentage
        {
            get => (percentage >= 0 && percentage <= 100) ? percentage : 50;
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
            else if (radioButtonThread5.Checked)
            {
                textBoxThread.Text = numberOfThreadsInCPU.ToString();
            }
            else if (radioButtonPercent1.Checked)
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

            if (int.TryParse(textBoxThread.Text, out int threads) && threads > 0)
            {
                int percent = (int)((double)threads / numberOfThreadsInCPU * 100);
                textBoxPercent.Text = Math.Min(percent, 100).ToString();
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

            if (int.TryParse(textBoxPercent.Text, out int percent) && percent >= 0 && percent <= 100)
            {
                int threads = Math.Max(1, (int)Math.Round((double)percent / 100 * numberOfThreadsInCPU));
                textBoxThread.Text = threads.ToString();
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
            // Get CPU Information using WMI
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    labelCPUName.Text = "Name: " + (obj["Name"] ?? "Unknown");
                    labelCPUManufacturer.Text = "Manufacturer: " + (obj["Manufacturer"] ?? "Unknown");
                    labelCPUDescription.Text = "Description: " + (obj["Description"] ?? "Unknown");
                    labelCPUCores.Text = "Number of Cores: " + (obj["NumberOfCores"] ?? "Unknown");
                    labelCPUThread.Text = "Logical Processors (Threads): " + (obj["NumberOfLogicalProcessors"] ?? "Unknown");
                    labelCPUMaxSpeed.Text = "Max Clock Speed: " + (obj["MaxClockSpeed"] ?? "Unknown") + " MHz";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching CPU details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            percentage = Settings.ThreadsUsagePercentage;
            if (percentage == 100) radioButtonPercent1.Checked = true;
            else if (percentage == 75) radioButtonPercent2.Checked = true;
            else if (percentage == 50) radioButtonPercent3.Checked = true;
            else if (percentage == 25) radioButtonPercent4.Checked = true;
            else if (percentage == 0) radioButtonPercent5.Checked = true;
            else if (percentage * numberOfThreadsInCPU == 1) radioButtonThread1.Checked = true;
            else if (percentage * numberOfThreadsInCPU == 2) radioButtonThread2.Checked = true;
            else if (percentage * numberOfThreadsInCPU == 4) radioButtonThread3.Checked = true;
            else if (percentage * numberOfThreadsInCPU == 8) radioButtonThread4.Checked = true;
            else textBoxPercent.Text = percentage.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                percentage = int.Parse(textBoxPercent.Text);
                if (percentage >= 0 && percentage <= 100)
                {
                    DialogResult = DialogResult.OK;
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                MessageBox.Show("Please set the percentage value from 0% to 100%", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

/**
 *@author: Kamil Franek
 *@date: 23.09.2026
 *@brief: Handles UI Form for Threads settings
 *@file: ThreadsForm.cs
 */

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

        /// <summary>
        /// Outputs coresponding text based on what RadioButton was pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Checks and updates thread settings based on user input in textbox value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Checks and updates thread settings based on user input in textboxPercent value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                int threads = Math.Max(1, (int)Math.Ceiling(percent / 100.0 * numberOfThreadsInCPU));
                if (threads > numberOfThreadsInCPU) textBoxThread.Text = numberOfThreadsInCPU.ToString();
               else textBoxThread.Text = threads.ToString();
            }
            else
            {
                textBoxThread.Text = "1";
            }
            updating = false;
        }

        /// <summary>
        /// Loads form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadsForm_Load(object sender, EventArgs e)
        {
            FormManagement.LoadForm(this);
            #region Languages
            this.Name = Languages.Translate(Languages.L.ThreadManager);
            labelHowMany.Text = Languages.Translate(Languages.L.HowManyThreadsDoYouWantToUseInAProgram);
            labelThreads.Text = Languages.Translate(Languages.L.NumberOfThreads);
            labelPercentages.Text = Languages.Translate(Languages.L.PercentageOfThreadsUsed);
            labelMaxThreads.Text = Languages.Translate(Languages.L.From1ToMaxNumberOfThreads);
            labelFrom0to100.Text = Languages.Translate(Languages.L.From0To100);
            radioButtonThread1.Text = Languages.Translate(Languages.L.SingleThread);
            radioButtonThread2.Text = Languages.Translate(Languages.L.Threads2);
            radioButtonThread3.Text = Languages.Translate(Languages.L.Threads4);
            radioButtonThread4.Text = Languages.Translate(Languages.L.Threads8);
            radioButtonThreadMax.Text = Languages.Translate(Languages.L.MaximumNumberOfThreads);
            labelZeroPercent.Text = Languages.Translate(Languages.L.MeansOnlyOneThreadMayBeUsedAtAllTimes0);
            buttonSave.Text = Languages.Translate(Languages.L.Save);
            buttonDefault.Text = Languages.Translate(Languages.L.Default);
            buttonCancel.Text = Languages.Translate(Languages.L.Cancel);
            groupBox1.Text = Languages.Translate(Languages.L.CpuInfo);
            #endregion

            SetCPUInfo();
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
            unsavedChanges = false;
        }

        /// <summary>
        /// Finds and sets up CPU info from win32_Processor file
        /// </summary>
        public void SetCPUInfo()
        {
            //dont mind these two, I have nowhere else to put them
            labelPreference.Text = "*" + Languages.Translate(Languages.L.KnowThatPercentagesArePreferedByTheComputer);
            labelCalculations.Text = "*" + Languages.Translate(Languages.L.LowerThreadCountCanSlowDownCalculations);
            // Get CPU Information using WMI
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    labelCPUName.Text = Languages.Translate(Languages.L.Name) + ": " + (obj["Name"] ?? Languages.Translate(Languages.L.Unknown));
                    labelCPUManufacturer.Text = Languages.Translate(Languages.L.Manufacturer) + ": " + (obj["Manufacturer"] ?? Languages.Translate(Languages.L.Unknown));
                    labelCPUDescription.Text = Languages.Translate(Languages.L.CpuDescription) + ": " + (obj["Description"] ?? Languages.Translate(Languages.L.Unknown));
                    labelCPUCores.Text = Languages.Translate(Languages.L.NumberOfCores) + ": " + (obj["NumberOfCores"] ?? Languages.Translate(Languages.L.Unknown));
                    labelCPUThread.Text = Languages.Translate(Languages.L.NumberOfThreads) + ": " + (obj["NumberOfLogicalProcessors"] ?? Languages.Translate(Languages.L.Unknown));
                    labelCPUMaxSpeed.Text = Languages.Translate(Languages.L.MaxClockSpeed) + ": " + (obj["MaxClockSpeed"] ?? Languages.Translate(Languages.L.Unknown)) + " " + Languages.Translate(Languages.L.Mhz);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Languages.Translate(Languages.L.ErrorFetchingCpuDetails) + ": " + ex.Message, Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves changes to settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) //save
        {
            try
            {
                Percentage = int.Parse(textBoxPercent.Text);
                Settings.ThreadsUsagePercentage = Percentage;
                unsavedChanges = false;
                DialogResult = DialogResult.OK;
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseSetThePercentageValueFrom0To100), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Sets default value to textBoxPercent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDefault_Click(object sender, EventArgs e)
        {
            textBoxPercent.Text = "50";
        }

        /// <summary>
        /// Handles closing with unsavedChanges
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreadsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("unsavedChanges: " + unsavedChanges);
            if (unsavedChanges)
            {
                DialogResult temp = MessageBox.Show(Languages.Translate(Languages.L.ThereAreUnsavedChangesDoYouWishToSaveThem), Languages.Translate(Languages.L.Warning), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                switch (temp)
                {
                    case DialogResult.Yes:
                        {
                            try
                            {
                                Percentage = int.Parse(textBoxPercent.Text);
                                Settings.ThreadsUsagePercentage = Percentage;
                                unsavedChanges = false;
                                DialogResult = DialogResult.OK;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show(Languages.Translate(Languages.L.PleaseSetThePercentageValueFrom0To100), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                            }                           
                            break;
                        }
                    case DialogResult.No: DialogResult = DialogResult.No; break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }
    }
}

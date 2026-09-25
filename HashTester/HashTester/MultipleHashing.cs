/**
 *@author: Kamil Franek
 *@date: 23.09.2026
 *@brief: Form UI for MultipleHashing script
 *@file: MultipleHashing.cs
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HashTester.Hasher;

namespace HashTester
{
    public partial class MultipleHashing : Form
    {
        public MultipleHashing()
        {
            InitializeComponent();
        }
        Form1 mainForm = new Form1();
        
        /// <summary>
        /// Closes the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Main Hashing function for the form
        /// Takes all selected algorithms and hashes them
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            if (checkBoxMD5.Checked || checkBoxSHA1.Checked || checkBoxSHA256.Checked || checkBoxSHA512.Checked || checkBoxRipeMD160.Checked || checkBoxCRC32.Checked)
            {
                bool previousIncludeHashAlgorithm = Settings.OutputStyleIncludeHashAlgorithm; // Gets the actuall Settings
                //overrides the settings with current selection
                if (checkBoxShowAlgorithm.Checked) Settings.OutputStyleIncludeHashAlgorithm = true; 
                else Settings.OutputStyleIncludeHashAlgorithm = false;
                //checks all selected algorithms
                List<HashingAlgorithm> algorithm = new List<HashingAlgorithm>();
                if (checkBoxMD5.Checked) algorithm.Add(HashingAlgorithm.MD5);
                if (checkBoxSHA1.Checked) algorithm.Add(HashingAlgorithm.SHA1);
                if (checkBoxSHA256.Checked) algorithm.Add(HashingAlgorithm.SHA256);
                if (checkBoxSHA512.Checked) algorithm.Add(HashingAlgorithm.SHA512);
                if (checkBoxRipeMD160.Checked) algorithm.Add(HashingAlgorithm.RIPEMD160);
                if (checkBoxCRC32.Checked) algorithm.Add(HashingAlgorithm.CRC32);                
                mainForm.ProcessingHash(textHashSimple.Lines, algorithm.ToArray(), listBoxLog); //processes all the stuff

                Settings.OutputStyleIncludeHashAlgorithm = previousIncludeHashAlgorithm; //Returns the settings to their original state
            }
            else
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseChooseAtLeastOneAlgorithm), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Hashes in multiple algorithms from a file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TXTInput_Click(object sender, EventArgs e)
        {
            // Check if at least one checkbox is selected
            if (checkBoxMD5.Checked || checkBoxSHA1.Checked || checkBoxSHA256.Checked || checkBoxSHA512.Checked || checkBoxRipeMD160.Checked || checkBoxCRC32.Checked)
            {
                bool previousIncludeHashAlgorithm = Settings.OutputStyleIncludeHashAlgorithm; // Gets the actuall Settings
                //overrides the settings with current selection
                if (checkBoxShowAlgorithm.Checked) Settings.OutputStyleIncludeHashAlgorithm = true;
                else Settings.OutputStyleIncludeHashAlgorithm = false;
                //checks all selected algorithms
                List<HashingAlgorithm> algorithms = new List<HashingAlgorithm>();

                // Add selected algorithms to the list
                if (checkBoxMD5.Checked) algorithms.Add(HashingAlgorithm.MD5);
                if (checkBoxSHA1.Checked) algorithms.Add(HashingAlgorithm.SHA1);
                if (checkBoxSHA256.Checked) algorithms.Add(HashingAlgorithm.SHA256);
                if (checkBoxSHA512.Checked) algorithms.Add(HashingAlgorithm.SHA512);
                if (checkBoxRipeMD160.Checked) algorithms.Add(HashingAlgorithm.RIPEMD160);
                if (checkBoxCRC32.Checked) algorithms.Add(HashingAlgorithm.CRC32);               
                mainForm.ProcessingHashTXTInput(algorithms.ToArray(), listBoxLog); // Processes all the stuff

                Settings.OutputStyleIncludeHashAlgorithm = previousIncludeHashAlgorithm; // Returns the settings to their original state
            }
            else
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseChooseAtLeastOneAlgorithm), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
        /// Saves log to a .txt file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }

        /// <summary>
        /// Copies selected item in log to Clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAnItemFromTheLogListboxBeforeCopying), Languages.Translate(Languages.L.Info) , MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads the UI form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MultipleHashing_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(Languages.L.MultiHasher);
            FormManagement.LoadForm(this);
            #region Languages
            labelInfo.Text = "*" + Languages.Translate(Languages.L.WillOverwriteTheIncludeHashingAlgorithmInTheOutputStyleSettings);
            checkBoxShowAlgorithm.Text = Languages.Translate(Languages.L.ShowAlgorithm) + "*";
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            buttonHashSimpleText.Text = Languages.Translate(Languages.L.HashText);
            buttonTXTInput.Text = Languages.Translate(Languages.L.HashAFile);
            buttonGoBack.Text = Languages.Translate(Languages.L.GoBack);
            #endregion
        }
    }
}

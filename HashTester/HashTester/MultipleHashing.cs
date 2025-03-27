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
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                MessageBox.Show(Languages.Translate(223), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                MessageBox.Show(Languages.Translate(223), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
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
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MultipleHashing_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(706);
            FormManagement.SetUpFormTheme(this);
            #region Languages
            labelInfo.Text = "*" + Languages.Translate(221);
            checkBoxShowAlgorithm.Text = Languages.Translate(222) + "*";
            buttonClipboard.Text = Languages.Translate(10002);
            buttonClearListBox.Text = Languages.Translate(10000);
            buttonSaveLog.Text = Languages.Translate(10001);
            buttonHashSimpleText.Text = Languages.Translate(31);
            buttonTXTInput.Text = Languages.Translate(32);
            buttonGoBack.Text = Languages.Translate(10006);
            #endregion
        }
    }
}

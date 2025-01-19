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
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked || checkBox6.Checked)
            {
                bool previousIncludeHashAlgorithm = Settings.OutputStyleIncludeHashAlgorithm; // Gets the actuall Settings
                //overrides the settings with current selection
                if (checkBoxShowAlgorithm.Checked) Settings.OutputStyleIncludeHashAlgorithm = true; 
                else Settings.OutputStyleIncludeHashAlgorithm = false;
                //checks all selected algorithms
                List<HashingAlgorithm> algorithm = new List<HashingAlgorithm>();
                if (checkBox1.Checked) algorithm.Add(HashingAlgorithm.MD5);
                if (checkBox2.Checked) algorithm.Add(HashingAlgorithm.SHA1);
                if (checkBox3.Checked) algorithm.Add(HashingAlgorithm.SHA256);
                if (checkBox4.Checked) algorithm.Add(HashingAlgorithm.SHA512);
                if (checkBox5.Checked) algorithm.Add(HashingAlgorithm.RIPEMD160);
                if (checkBox6.Checked) algorithm.Add(HashingAlgorithm.CRC32);                
                mainForm.ProcessingHash(textHashSimple.Lines, algorithm.ToArray(), listBoxLog); //processes all the stuff

                Settings.OutputStyleIncludeHashAlgorithm = previousIncludeHashAlgorithm; //Returns the settings to their original state
            }
            else
            {
                MessageBox.Show("Please choose at least one algorithm!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TXTInput_Click(object sender, EventArgs e)
        {
            // Check if at least one checkbox is selected
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked || checkBox4.Checked || checkBox5.Checked || checkBox6.Checked)
            {
                bool previousIncludeHashAlgorithm = Settings.OutputStyleIncludeHashAlgorithm; // Gets the actuall Settings
                //overrides the settings with current selection
                if (checkBoxShowAlgorithm.Checked) Settings.OutputStyleIncludeHashAlgorithm = true;
                else Settings.OutputStyleIncludeHashAlgorithm = false;
                //checks all selected algorithms
                List<HashingAlgorithm> algorithms = new List<HashingAlgorithm>();

                // Add selected algorithms to the list
                if (checkBox1.Checked) algorithms.Add(HashingAlgorithm.MD5);
                if (checkBox2.Checked) algorithms.Add(HashingAlgorithm.SHA1);
                if (checkBox3.Checked) algorithms.Add(HashingAlgorithm.SHA256);
                if (checkBox4.Checked) algorithms.Add(HashingAlgorithm.SHA512);
                if (checkBox5.Checked) algorithms.Add(HashingAlgorithm.RIPEMD160);
                if (checkBox6.Checked) algorithms.Add(HashingAlgorithm.CRC32);               
                mainForm.ProcessingHashTXTInput(algorithms.ToArray(), listBoxLog); // Processes all the stuff

                Settings.OutputStyleIncludeHashAlgorithm = previousIncludeHashAlgorithm; // Returns the settings to their original state
            }
            else
            {
                MessageBox.Show("Please choose at least one algorithm!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HashTester
{
    public partial class FormGradual : Form
    {
        public FormGradual()
        {
            InitializeComponent();
        }
        Hasher hasher = new Hasher();
        Form1 mainForm = new Form1();
        Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.MD5;
        
        private void buttonHashGradualHashing_Click(object sender, EventArgs e)
        {
            string originalString = textBoxHash.Text;
            OutputHandler outputHandler = new OutputHandler(algorithm);
            string[] hash = null;
            for (int i = 0; i < originalString.Length; i++)
            {                
                if (!mainForm.IsUsingSaltAndPepper(originalString, out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper, out string hashIDforTesting))
                {
                    hash = hasher.GradualHashing(textBoxHash.Text, algorithm);
                }
                else //salt/Pepper IS used
                {
                    hash = hasher.GradualHashingSaltPepper(textBoxHash.Text, isSaltUsed, isPepperUsed, salt, pepper, algorithm);
                }
                hash = outputHandler.OutputStyleString(originalString, hash, isSaltUsed, isPepperUsed, salt, pepper);
            }
            outputHandler.OutputTypeShow(hash, listBox1);
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void FormGradual_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
        }

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}

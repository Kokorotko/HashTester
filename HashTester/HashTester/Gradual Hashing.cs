using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        Hasher.HashingAlgorithm algorithm = new Hasher.HashingAlgorithm();
        
        private void buttonHashGradualHashing_Click(object sender, EventArgs e)
        {
            string[] hashPole = textBoxHash.Lines[];
            //blude
            string hash = "";
            if (!mainForm.IsUsingSaltAndPepper(text, out bool isSaltUsed, out bool isPepperUsed, out hash, out string hashIDforTesting))
            {
                hashPole = hasher.GradualHashing(textBoxHash.Text, algorithm);
            }
            for (int i = 0; i < hashPole.Count(); i++)
            {
                string outputString = mainForm.OutputStyleString(text, hash, i + 1, isSaltUsed, isPepperUsed);
                mainForm.OutputTypeShow(outputString, listBox1);
            }
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

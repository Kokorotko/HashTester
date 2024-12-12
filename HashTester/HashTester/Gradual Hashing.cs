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
        OutputHandler outputHandler = new OutputHandler();
        Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.MD5;
        
        private void buttonHashGradualHashing_Click(object sender, EventArgs e)
        {
            string[] hashPole = new string[textBoxHash.Text.Length];
            for (int i = 0; i < hashPole.Length; i++)
            {
                string hash = "";
                if (!mainForm.IsUsingSaltAndPepper(hashPole[i], out bool isSaltUsed, out bool isPepperUsed, out hash, out string hashIDforTesting))
                {
                    hashPole = hasher.GradualHashing(textBoxHash.Text, algorithm);
                }
                for (int j = 0; j < hashPole.Count(); j++)
                {
                    hashPole[i] = outputHandler.OutputStyleString(hashPole[i], hash, j + 1, isSaltUsed, isPepperUsed);                    
                }
            }
            outputHandler.OutputTypeShow(hashPole, listBox1);
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

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
    public partial class FormGradual : Form
    {
        public FormGradual()
        {
            InitializeComponent();
        }
        Hasher hasher = new Hasher();
        Hasher.HashingAlgorithm algorithm = new Hasher.HashingAlgorithm();
        
        private void buttonHashGradualHashing_Click(object sender, EventArgs e)
        {
            string[] pole = hasher.GradualHashing(textBoxHash.Text, algorithm);
            listBox1.Items.Clear();
            for (int i = 0; i < pole.Count(); i++) listBox1.Items.Add((i + 1) + "." + " " + pole[i]);
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void FormGradual_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
        }
    }
}

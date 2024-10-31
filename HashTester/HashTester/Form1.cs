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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Hasher.Hash(textHashSimple.Text, Hasher.HashingAlgorithm.MD5));
        }

        private void buttonHashGradualHashing_Click(object sender, EventArgs e)
        {
            string[] pole = Hasher.GradualHashing(textHashSimple.Text, Hasher.HashingAlgorithm.MD5);
            listBox1.Items.Clear();
            foreach (string p in pole) listBox1.Items.Add(p);
        }
    }
}

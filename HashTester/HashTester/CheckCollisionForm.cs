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
    public partial class CheckCollisionForm : Form
    {
        public CheckCollisionForm()
        {
            InitializeComponent();
        }
        private string text01;
        private string text02;
        private HashingCollisionForm.CollisionDetectionFormat format = HashingCollisionForm.CollisionDetectionFormat.STRING;
        private Hasher.HashingAlgorithm hashingAlgorithm = Hasher.HashingAlgorithm.CRC32;
        //Get
        public string Text01 { get => text01; }
        public string Text02 { get => text02; }
        public HashingCollisionForm.CollisionDetectionFormat Format { get => format; }
        public Hasher.HashingAlgorithm HashingAlgorithm { get => hashingAlgorithm; }

        private void button1_Click(object sender, EventArgs e)
        {
            text01 = textBox1.Text;
            text02 = textBox2.Text;
            if (radioButton1.Checked) format = HashingCollisionForm.CollisionDetectionFormat.STRING;
            else if (radioButton2.Checked) format = HashingCollisionForm.CollisionDetectionFormat.HEX;
            else format = HashingCollisionForm.CollisionDetectionFormat.BIN;
            DialogResult = DialogResult.OK;
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            hashingAlgorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void CheckCollisionForm_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
        }
    }
}

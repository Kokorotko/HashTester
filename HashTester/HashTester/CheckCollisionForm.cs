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
            if (radioButtonString.Checked) format = HashingCollisionForm.CollisionDetectionFormat.STRING;
            else if (radioButtonHex.Checked) format = HashingCollisionForm.CollisionDetectionFormat.HEX;
            else format = HashingCollisionForm.CollisionDetectionFormat.BIN;
            DialogResult = DialogResult.OK;
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            hashingAlgorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void CheckCollisionForm_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(705);
            hashSelector.SelectedIndex = 0;
            FormManagement.SetUpFormTheme(this);
            #region Languages
            groupBox1.Text = Languages.Translate(201);
            radioButtonString.Text = Languages.Translate(202);
            radioButtonHex.Text = Languages.Translate(203);
            radioButtonBinary.Text = Languages.Translate(204);
            labelText.Text = Languages.Translate(205) + "1";
            labelText2.Text = Languages.Translate(205) + "2";
            buttonCheck.Text = Languages.Translate(206);
            #endregion
        }
    }
}

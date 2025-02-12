using System;
using System.Windows.Forms;

namespace HashTester
{
    public partial class UIUpdateFrequency : Form
    {
        public UIUpdateFrequency()
        {
            InitializeComponent();
        }
        //private
        bool radioButtonSet = false;
        int miliseconds;
        int fps;

        //Set and Get
        public int Miliseconds
        {
            get 
            {
                if (miliseconds > 7 && miliseconds < 1001) return miliseconds;
                else return 34;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            fps = 30;
            textBox1.Text = fps.ToString();
        }

        private void UIUpdateFrequency_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
            miliseconds = Settings.UpdateUIms;
            fps = (int)Math.Ceiling(1000.0 / miliseconds);
            textBox1.Text = fps.ToString();
            textBox2.Text = miliseconds.ToString();
        }

        private void selectedRadioButtonChanged(object sender, EventArgs e)
        {            
            if (radioButton1.Checked) { DeselectAllRadioButtons(radioButton1); fps = 12; miliseconds = 83; radioButtonSet = true; }
            else if (radioButton2.Checked) { DeselectAllRadioButtons(radioButton2); fps = 24; miliseconds = 41; radioButtonSet = true; }
            else if (radioButton3.Checked) { DeselectAllRadioButtons(radioButton3); fps = 30; miliseconds = 32; radioButtonSet = true; }
            else if (radioButton4.Checked) { DeselectAllRadioButtons(radioButton4); fps = 60; miliseconds = 16; radioButtonSet = true; }
            else if (radioButton5.Checked) { DeselectAllRadioButtons(radioButton5); fps = 125; miliseconds = 8; radioButtonSet = true; }
            else if (radioButton10.Checked) { DeselectAllRadioButtons(radioButton10); fps = 1; miliseconds = 1000; radioButtonSet = true; }
            else if (radioButton9.Checked) { DeselectAllRadioButtons(radioButton9); fps = 2; miliseconds = 500; radioButtonSet = true; }
            else if (radioButton8.Checked) { DeselectAllRadioButtons(radioButton8); fps = 4; miliseconds = 250; radioButtonSet = true; }
            else if (radioButton7.Checked) { DeselectAllRadioButtons(radioButton7); fps = 10; miliseconds = 100; radioButtonSet = true; }
            else if (radioButton6.Checked) { DeselectAllRadioButtons(radioButton6); fps = 20; miliseconds = 50; radioButtonSet = true; }

            if (fps > 0)
            {
                miliseconds = 1000 / fps;
            }
            else
            {
                fps = 1000 / miliseconds;
            }

            textBox1.Text = fps.ToString();
            textBox2.Text = miliseconds.ToString();
            radioButtonSet = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!radioButtonSet)
            {
                DeselectAllRadioButtons();
                if (double.TryParse(textBox1.Text, out double temp) && temp > 0)
                {
                    textBox2.Text = Math.Ceiling(1000.0 / temp).ToString();
                }
                else
                {
                    textBox2.Text = "";
                }
            }            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!radioButtonSet)
            {
                DeselectAllRadioButtons();
                if (double.TryParse(textBox2.Text, out double temp) && temp > 0)
                {
                    textBox1.Text = Math.Ceiling(1000.0 / temp).ToString();
                }
                else
                {
                    textBox1.Text = "";
                }
            }
        }

        private void DeselectAllRadioButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is RadioButton) (control as RadioButton).Checked = false;
            }
        }

        private void DeselectAllRadioButtons(RadioButton radioButton)
        {
            foreach (Control control in this.Controls)
            {
                if (control is RadioButton && control!= radioButton)
                {
                    (control as RadioButton).Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out fps) && int.TryParse(textBox2.Text, out miliseconds))
            {
                if (miliseconds >= 8 && miliseconds <= 1000)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Please enter valid values (8-1000 ms).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid values. Please enter whole numbers only.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
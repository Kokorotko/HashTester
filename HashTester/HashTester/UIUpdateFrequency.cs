using System;
using System.Linq.Expressions;
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
            textBoxFPS.Text = fps.ToString();
        }

        private void UIUpdateFrequency_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
            #region Languages
            labelQuestion.Text = Languages.Translate(501);
            labelFPS.Text = Languages.Translate(502);
            labelTimeToUpdate.Text = Languages.Translate(503);
            labelRangeFPS.Text = Languages.Translate(504);
            labelRangeT.Text = Languages.Translate(505);
            labelInfo.Text = Languages.Translate(506);
            labelInfo2.Text = Languages.Translate(507);
            buttonSave.Text = Languages.Translate(434);
            buttonDefault.Text = Languages.Translate(435);
            buttonCancel.Text = Languages.Translate(436);
            #endregion
            miliseconds = Settings.UpdateUIms;
            fps = (int)Math.Ceiling(1000.0 / miliseconds);
            textBoxFPS.Text = fps.ToString();
            textBoxMiliseconds.Text = miliseconds.ToString();
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

            textBoxFPS.Text = fps.ToString();
            textBoxMiliseconds.Text = miliseconds.ToString();
            radioButtonSet = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!radioButtonSet)
            {
                DeselectAllRadioButtons();
                if (double.TryParse(textBoxFPS.Text, out double temp) && temp > 0)
                {
                    if (temp > 125)
                    {
                        textBoxMiliseconds.Text = "8";
                        textBoxFPS.Text = "125";
                    }
                    textBoxMiliseconds.Text = Math.Ceiling(1000.0 / temp).ToString();
                }
                else
                {
                    textBoxMiliseconds.Text = "";
                }
            }            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!radioButtonSet)
            {
                DeselectAllRadioButtons();
                if (double.TryParse(textBoxMiliseconds.Text, out double temp) && temp > 0)
                {
                    if (temp < 8)
                    {
                        textBoxFPS.Text = "125";
                        textBoxMiliseconds.Text = "8";
                    }
                    else if (temp > 1000)
                    {
                        textBoxFPS.Text = "1";
                        textBoxMiliseconds.Text = "1000";
                    }
                    else textBoxFPS.Text = Math.Ceiling(1000.0 / temp).ToString();
                }
                else
                {
                    textBoxFPS.Text = "";
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
            if (int.TryParse(textBoxFPS.Text, out fps) && int.TryParse(textBoxMiliseconds.Text, out miliseconds))
            {
                if (miliseconds >= 8 && miliseconds <= 1000)
                {
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(Languages.Translate(508) + "(8-1000ms).", Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Languages.Translate(509), Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
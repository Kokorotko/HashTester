using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
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
        private bool dontUpdate = false;
        private bool unsavedChanges = false;

        //Set and Get
        public int Miliseconds
        {
            get 
            {
                if (miliseconds > 7 && miliseconds < 1001) return miliseconds;
                else return 34;
            }
        }

        private void setMilliseconds(string s)
        {
            int.TryParse(s, out miliseconds);
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
            this.Name = Languages.Translate(Languages.L.UiManager);
            labelQuestion.Text = Languages.Translate(Languages.L.HowManyTimesASecondDoYouWantToUpdateTheUiForSpecificOperations);
            labelFPS.Text = Languages.Translate(Languages.L.TargetFramesPerSecond);
            labelTimeToUpdate.Text = Languages.Translate(Languages.L.TimeToUpdateMiliseconds);
            labelRangeFPS.Text = Languages.Translate(Languages.L.PleaseSetNumberFrom1To125);
            labelRangeT.Text = Languages.Translate(Languages.L.PleaseSetNumbersFrom8To1000);
            labelInfo.Text = Languages.Translate(Languages.L.KnowThatMilisecondsArePreferedByTheComputer);
            labelInfo2.Text = Languages.Translate(Languages.L.HigherRefreshRateCanCausePerformanceIssues);
            buttonSave.Text = Languages.Translate(Languages.L.Save);
            buttonDefault.Text = Languages.Translate(Languages.L.Default);
            buttonCancel.Text = Languages.Translate(Languages.L.Cancel);
            #endregion
            miliseconds = Settings.UpdateUIms;
            fps = (int)Math.Ceiling(1000.0 / miliseconds);
            textBoxFPS.Text = fps.ToString();
            textBoxMiliseconds.Text = miliseconds.ToString();
            unsavedChanges = false;
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
            if (dontUpdate) return;
            dontUpdate = true;
            unsavedChanges = true;

            if (!radioButtonSet)
            {
                DeselectAllRadioButtons();
                if (double.TryParse(textBoxFPS.Text, out double temp) && temp > 0)
                {
                    if (temp > 125) textBoxMiliseconds.Text = "8";
                    else textBoxMiliseconds.Text = Math.Ceiling(1000.0 / temp).ToString();
                }
                else textBoxMiliseconds.Text = "";
            }
            dontUpdate = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (dontUpdate) return;
            dontUpdate = true;
            unsavedChanges = true;
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
            dontUpdate = false;
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
                    unsavedChanges = false;
                    Settings.UpdateUIms = Miliseconds;
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(Languages.Translate(Languages.L.PleaseEnterValidValues) + "(8-1000ms).", Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Languages.Translate(Languages.L.InvalidValuesPleaseEnterWholeNumbersOnly), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void UIUpdateFrequency_FormClosing(object sender, FormClosingEventArgs e)
        {
            setMilliseconds(textBoxMiliseconds.Text);
            if (Settings.UpdateUIms == Miliseconds) unsavedChanges = false;
            if (unsavedChanges)
            {
                DialogResult temp = MessageBox.Show(Languages.Translate(Languages.L.ThereAreUnsavedChangesDoYouWishToSaveThem), Languages.Translate(Languages.L.Warning), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                switch (temp)
                {
                    case DialogResult.Yes:
                        {
                            if (int.TryParse(textBoxFPS.Text, out fps) && int.TryParse(textBoxMiliseconds.Text, out miliseconds))
                            {
                                if (miliseconds >= 8 && miliseconds <= 1000)
                                {
                                    Settings.UpdateUIms = Miliseconds;
                                    DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    e.Cancel = true;
                                    MessageBox.Show(Languages.Translate(Languages.L.PleaseEnterValidValues) + " (8-1000ms).", Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                            else
                            {
                                e.Cancel = true;
                                MessageBox.Show(Languages.Translate(Languages.L.InvalidValuesPleaseEnterWholeNumbersOnly), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            DialogResult = DialogResult.OK; 
                            break;
                        }
                    case DialogResult.No: DialogResult = DialogResult.Cancel; break;
                    case DialogResult.Cancel: e.Cancel = true; break;
                }
            }
        }

        private void labelInfo2_Click(object sender, EventArgs e)
        {

        }
    }
}
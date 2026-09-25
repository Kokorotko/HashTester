/**
 *@author: Kamil Franek
 *@date: 23.09.2026
 *@brief: Handles UI form for updating UI on timer specific based updates
 *@file: UIUpdateFrequency.cs
 */

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

        /// <summary>
        /// Sets milliseconds form textbox
        /// </summary>
        /// <param name="s"></param>
        private void setMilliseconds(string s)
        {
            int.TryParse(s, out miliseconds);
        }

        /// <summary>
        /// Sets base value to textBoxFPS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e) //Base Value
        {
            fps = 30;
            textBoxFPS.Text = fps.ToString();
        }

        /// <summary>
        /// Loads form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UIUpdateFrequency_Load(object sender, EventArgs e)
        {
            FormManagement.LoadForm(this);
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

        /// <summary>
        /// Sets textbox based on what radioButton was checked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Checks and sets textBox miliseconds 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Checks and sets texbox frames/sec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Deselects all radioButtons
        /// </summary>
        private void DeselectAllRadioButtons()
        {
            foreach (Control control in this.Controls)
            {
                if (control is RadioButton) (control as RadioButton).Checked = false;
            }
        }

        /// <summary>
        /// Recursively deselects all radioButtons
        /// </summary>
        /// <param name="radioButton"></param>
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

        /// <summary>
        /// Saves values from textBox to settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Handles unsaved changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
    }
}
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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            Settings.SaveSettings();
            DialogResult = DialogResult.OK;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            FormResetSettingsConfirmation reset = new FormResetSettingsConfirmation();
            if (reset.ShowDialog() == DialogResult.Yes) //Reset
            {
                Settings.ResetSettings();
                Settings.SaveSettings();
                DialogResult = DialogResult.OK;
            }
            else MessageBox.Show("Reset Aborted");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Settings.LoadSettings(); //unsaved changes
            DialogResult = DialogResult.Cancel;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            //VisualMode
            if (Settings.VisualMode == Settings.VisualModeEnum.System) radioButtonVisualMode0.Checked = true;
            else if (Settings.VisualMode == Settings.VisualModeEnum.Light) radioButtonVisualMode1.Checked = true;
            else if (Settings.VisualMode == Settings.VisualModeEnum.Light) radioButtonVisualMode2.Checked = true;
            else throw new ArgumentOutOfRangeException();
            //
        }
    }
}

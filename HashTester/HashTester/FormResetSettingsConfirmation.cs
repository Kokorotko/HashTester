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
    public partial class FormResetSettingsConfirmation : Form
    {
        public FormResetSettingsConfirmation()
        {
            InitializeComponent();
        }

        private void buttonNO_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.No;
        }

        private void buttonYES_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
        }
    }
}

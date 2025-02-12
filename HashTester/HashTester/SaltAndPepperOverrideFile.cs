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
    public partial class SaltAndPepperOverrideFile : Form
    {
        public SaltAndPepperOverrideFile()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SaltAndPepperOverrideFile_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
        }
    }
}

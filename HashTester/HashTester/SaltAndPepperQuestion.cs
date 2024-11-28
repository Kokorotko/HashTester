using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    public partial class SaltAndPepperQuestion : Form
    {
        public SaltAndPepperQuestion(bool salt, bool pepper)
        {
            InitializeComponent();
            if (!salt) groupBoxSalt.Enabled = false;
            if (!pepper) groupBoxPepper.Enabled = false;
        }
        Settings settings = new Settings();
        private void SaltAndPepperQuestion_Load(object sender, EventArgs e)
        {
            textBoxSalt.Enabled = false;
            textBoxPepper.Enabled = false;
            textBoxHashID.Text = SetHashID();
        }

        private void textBoxGenerate_Click(object sender, EventArgs e)
        {
            if (textBoxHashID.Text != "")
            {
                if (CheckHashID(textBoxHashID.Text))
                {
                    DialogResult = DialogResult.OK;
                }                
            }
            else
            {
                MessageBox.Show("Prosim zadejte platne HashID");
                textBoxHashID.Focus();
            }            
        }
        #region HashID
        /// <summary>
        /// Trying to find a name for a hash that isnt already used
        /// </summary>
        /// <returns></returns>
        private string SetHashID()
        {
            string name = "automaticallyGeneratedHash";
            int index = 1;
            while (true)
            {
                string path = "..\\..\\HashData\\" + name + index.ToString();
                if (!File.Exists(path))
                {
                    return name + index.ToString();
                }
                else
                {
                    index++;
                }
            }
        }

        private bool CheckHashID(string hashID)
        {
            string path = "..\\..\\HashData\\" + hashID + ".txt";
            if (File.Exists(path))
            {
                //Check if (form.ShowDialog() == DialogResult.Ok)
            }
            else return true;
        }
        #endregion

        #region RadioButtonsControls
        private void radioButtonPepperGen_CheckedChanged(object sender, EventArgs e)
        {
            PepperRadioButtonCheck();
        }

        private void radioButtonPepperOwn_CheckedChanged(object sender, EventArgs e)
        {
            PepperRadioButtonCheck();
        }


        //Salt
        private void radioButtonSaltGen_CheckedChanged(object sender, EventArgs e)
        {
            SaltRadioButtonCheck();
        }

        private void radioButtonSaltOwn_CheckedChanged(object sender, EventArgs e)
        {
            SaltRadioButtonCheck();
        }

        private void SaltRadioButtonCheck()
        {
            if (radioButtonSaltGen.Checked) //Generate Salt
            {
                textBoxSaltLenght.Enabled = true;
                textBoxSalt.Enabled = false;
            }
            else //Include own Salt
            {
                textBoxSaltLenght.Enabled = false;
                textBoxSalt.Enabled = true;
            }
        }

        private void PepperRadioButtonCheck()
        {
            if (radioButtonPepperGen.Checked) //Generate Salt
            {
                textBoxPepperLenght.Enabled = true;
                textBoxPepper.Enabled = false;
            }
            else //Include own Salt
            {
                textBoxPepperLenght.Enabled = false;
                textBoxPepper.Enabled = true;
            }
        }
        #endregion
    }
}

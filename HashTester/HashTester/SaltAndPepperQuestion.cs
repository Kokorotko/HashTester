using System;
using System.IO;
using System.Windows.Forms;

namespace HashTester
{
    public partial class SaltAndPepperQuestion : Form
    {
        public SaltAndPepperQuestion()
        {
            InitializeComponent();
            if (!Settings.UseSalt) groupBoxSalt.Enabled = false;
            if (!Settings.UsePepper) groupBoxPepper.Enabled = false;
        }
        private void SaltAndPepperQuestion_Load(object sender, EventArgs e)
        {
            FormManagement.SetUpFormTheme(this);
            #region Languages
            groupBoxSalt.Text = Languages.Translate(402);
            groupBoxPepper.Text = Languages.Translate(403);
            radioButtonSaltGen.Text = Languages.Translate(404); //hehe funny web number
            radioButtonPepperGen.Text = Languages.Translate(405);
            labelLenghtSalt.Text = Languages.Translate(406);
            labelLenghtPepper.Text = Languages.Translate(407);
            radioButtonSaltOwn.Text = Languages.Translate(408);
            radioButtonPepperOwn.Text = Languages.Translate(409);
            labelOwnSalt.Text = Languages.Translate(410);
            labelOwnPepper.Text = Languages.Translate(411);
            labelID.Text = Languages.Translate(412);
            buttonGenerate.Text = Languages.Translate(413);
            #endregion
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
                MessageBox.Show(Languages.Translate(414));
                textBoxHashID.Focus();
            }            
        }

        public void GetSaltPepperInformation(out bool generateSalt,  out int lenghtSalt, out string ownSalt, out bool generatePepper, out int lenghtPepper, out string ownPepper, out string hashID)
        {
            generateSalt = false;
            lenghtSalt = 0;
            ownSalt = "";
            generatePepper = false;
            lenghtPepper = 0;
            ownPepper = "";
            //salt
            if (Settings.UseSalt)
            {
                generateSalt = radioButtonSaltGen.Checked;
                if (generateSalt)
                {
                    lenghtSalt = int.Parse(textBoxSaltLenght.Text);
                    ownSalt = null;
                }
                else
                {
                    lenghtSalt = 0;
                    ownSalt = textBoxSalt.Text;
                    //Console.WriteLine("SaltAndPepperQuestion Form SALT: " + ownSalt);
                }
            }
            if (Settings.UsePepper)
            {
                //pepper
                generatePepper = radioButtonPepperGen.Checked;
                if (generatePepper)
                {
                    lenghtPepper = int.Parse(textBoxPepperLenght.Text);
                    ownPepper = null;
                }
                else
                {
                    lenghtPepper = 0;
                    ownPepper = textBoxPepper.Text;
                    //Console.WriteLine("SaltAndPepperQuestion Form Pepper: " + ownPepper);
                }
            }
            //hashID
            hashID = textBoxHashID.Text;            
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
                if (MessageBox.Show(Languages.Translate(401), Languages.Translate(10025), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    File.Delete(path);
                    return true;
                }
                return false;
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

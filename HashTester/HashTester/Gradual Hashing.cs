using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HashTester
{
    public partial class FormGradual : Form
    {
        public FormGradual()
        {
            InitializeComponent();
        }
        Hasher hasher = new Hasher();
        Form1 mainForm = new Form1();
        Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.MD5;
        
        private void buttonHashGradualHashing_Click(object sender, EventArgs e)
        {
            string originalString = textBoxHash.Text;
            if (String.IsNullOrEmpty(originalString))
            {
                MessageBox.Show(Languages.Translate(103), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutputHandler outputHandler = new OutputHandler(algorithm);
            string[] hash = null;
            for (int i = 0; i < originalString.Length; i++)
            {
                hash = hasher.GradualHashing(textBoxHash.Text, algorithm);
            }
            outputHandler.OutputTypeShow(hash, listBoxLog);
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void FormGradual_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(703);
            FormManagement.SetUpFormTheme(this);
            hashSelector.SelectedIndex = 0;

            #region Language
            buttonHashGradualHashing.Text = Languages.Translate(101);
            labelQualityName.Text = Languages.Translate(104);
            buttonClearListBox.Text = Languages.Translate(10000);
            buttonSaveLog.Text = Languages.Translate(10001);
            buttonClipboard.Text = Languages.Translate(10002);
            #endregion
        }

        private void buttonClearListBox_Click(object sender, EventArgs e)
        {
            listBoxLog.Items.Clear();
        }

        private void buttonSaveLog_Click(object sender, EventArgs e)
        {
            FormManagement.SaveLog(listBoxLog, this);
        }

        private void buttonClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxLog.SelectedItem != null) Clipboard.SetText(listBoxLog.SelectedItem.ToString());
                else MessageBox.Show(Languages.Translate(102), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(10003), Languages.Translate(10004), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

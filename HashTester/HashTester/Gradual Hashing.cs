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

namespace HashTester
{
    public partial class FormGradual : Form
    {
        public FormGradual()
        {
            InitializeComponent();
        }
        Hasher hasher = new Hasher();
        Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.MD5;
        
        private void buttonHashGradualHashing_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxHash.Text))
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseSetTextBeforeHashing), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutputHandler outputHandler = new OutputHandler(algorithm);
            string[] hash = hasher.GradualHashing(textBoxHash.Text, algorithm);
            if (checkBoxShowInfo.Checked) //Show info
            {
                string temp = "";
                for (int i = 0; i < textBoxHash.Text.Length; i++)
                {
                    temp += textBoxHash.Text[i].ToString();
                    hash[i] = "(" + temp + ") " + hash[i];
                }
            }
            outputHandler.OutputTypeShow(hash, listBoxLog);
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void FormGradual_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(Languages.L.GradualHasher);
            FormManagement.SetUpFormTheme(this);
            hashSelector.SelectedIndex = 0;

            #region Language
            buttonHashGradualHashing.Text = Languages.Translate(Languages.L.GradualHasher);
            checkBoxShowInfo.Text = Languages.Translate(Languages.L.ShowInfo);
            labelQualityName.Text = Languages.Translate(Languages.L.WillNotUseSaltpepper);
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);
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
                else MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAnItemFromTheListBeforeCopying), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

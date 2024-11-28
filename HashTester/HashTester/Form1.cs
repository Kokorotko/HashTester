using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static HashTester.Hasher;
using static HashTester.Settings;
using static System.Net.Mime.MediaTypeNames;

namespace HashTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Settings settings = new Settings();        
        Hasher.HashingAlgorithm algorithm;

        #region MainButtons
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textHashSimple.Lines.Count(); i++) //all hashes in textfield
            {
                //main hashing
                string text = textHashSimple.Lines[i];
                //Salt and Pepper Logic
                string hash = "";
                string outputString = "";
                SaltAndPepperQuestion saltAndPepperQuestion;
                if (settings.IncludeSalt && settings.IncludePepper)
                {
                    saltAndPepperQuestion = new SaltAndPepperQuestion(true, true);
                    if (saltAndPepperQuestion.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                else if (settings.IncludeSalt && !settings.IncludePepper)
                {
                    saltAndPepperQuestion = new SaltAndPepperQuestion(true, false);
                    if (saltAndPepperQuestion.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                else if (!settings.IncludeSalt && settings.IncludePepper)
                {
                    saltAndPepperQuestion = new SaltAndPepperQuestion(false, true);
                    if (saltAndPepperQuestion.ShowDialog() == DialogResult.OK)
                    {

                    }
                }
                else
                {
                    hash = Hasher.Hash(text, algorithm);
                    outputString = OutputString(text, hash, i + 1);
                }
                //Output
                switch (settings.OutputType)
                {
                   case OutputTypeEnum.MessageBox:
                        {
                            MessageBox.Show(outputString);
                            break;
                        }
                    case OutputTypeEnum.Listbox:
                        {
                            listBox1.Items.Add(outputString);
                            break;
                        }
                    case OutputTypeEnum.TXTFile:
                        {
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                                {
                                    writer.WriteLine(outputString);
                                }
                            }
                            break;
                        }
                }

            }
        }
        private void TXTInput_Click(object sender, EventArgs e)
                {
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                        {
                            if (settings.OutputType == OutputTypeEnum.TXTFile)
                            {
                                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName))
                                    {
                                        int indexOfHash = 0;
                                        while (!reader.EndOfStream)
                                        {
                                            string text = reader.ReadLine();
                                            string hash = Hasher.Hash(text, algorithm);
                                            indexOfHash++;
                                            string outputString = OutputString(text, hash, indexOfHash);
                                            writer.WriteLine(outputString);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int indexOfHash = 0;
                                while (!reader.EndOfStream)
                                {
                                    string text = reader.ReadLine();
                                    string hash = Hasher.Hash(text, algorithm);
                                    indexOfHash++;
                                    string outputString = OutputString(text, hash, indexOfHash);
                                    if (settings.OutputType == OutputTypeEnum.MessageBox) MessageBox.Show(outputString);
                                    else listBox1.Items.Add(outputString);
                                }
                            }
                        }
                    }
                }
        private void button1_Click(object sender, EventArgs e) //clearListbox
        {
            listBox1.Items.Clear();
        }
        #endregion
        
        #region Forms

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        #endregion

        private string OutputString(string originalString, string hash, int indexOfHash)
        {
            string outputString = hash;
            if (settings.OutputStyleIncludeOriginalString)
            {
                outputString = originalString + ": " + outputString;
            }
            if (settings.OutputStyleIncludeHashAlgorithm)
            {
                switch (algorithm)
                {
                    case HashingAlgorithm.MD5: outputString = "(MD5) " + outputString; break;
                    case HashingAlgorithm.SHA1: outputString = "(SHA1) " + outputString; break;
                    case HashingAlgorithm.SHA256: outputString = "(SHA256) " + outputString; break;
                    case HashingAlgorithm.SHA512: outputString = "(SHA512) " + outputString; break;
                    case HashingAlgorithm.RIPEMD160: outputString = "(RIPEMD160) " + outputString; break;
                    case HashingAlgorithm.CRC32: outputString = "(CRC32) " + outputString; break;
                }
            }
            if (settings.OutputStyleIncludeNumberOfHash)
            {
                outputString = indexOfHash.ToString() + ". " + outputString;
            }
            return outputString;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            settings.LoadSettings(); //load All Settings
            UIToolStripMenuLoad(); //Load Strip Menu Checked UI
        }

        #region MenuStrip

        private void gradualHashingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormGradual formGradual = new FormGradual();
            formGradual.Show();
        }

        #region SaltAndPepper
        private void includeSaltToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.IncludeSalt = !settings.IncludeSalt;
            includeSaltToolStripMenuItem.Checked = settings.IncludeSalt;
            settings.SaveSettings();
        }

        private void includePepperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.IncludePepper = !settings.IncludePepper;
            includePepperToolStripMenuItem.Checked = settings.IncludePepper;
            settings.SaveSettings();
        }
        #endregion

        #region Settings
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }

        #region Settings-OutputType
        private void messageBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputType = OutputTypeEnum.MessageBox;
            messageBoxToolStripMenuItem.Checked = true;
            listBoxToolStripMenuItem.Checked = false;
            txtFileToolStripMenuItem.Checked = false;
            settings.SaveSettings();
        }

        private void listBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputType = OutputTypeEnum.Listbox;
            messageBoxToolStripMenuItem.Checked = false;
            listBoxToolStripMenuItem.Checked = true;
            txtFileToolStripMenuItem.Checked = false;
            settings.SaveSettings();
        }

        private void txtFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputType = OutputTypeEnum.TXTFile;
            messageBoxToolStripMenuItem.Checked = false;
            listBoxToolStripMenuItem.Checked = false;
            txtFileToolStripMenuItem.Checked = true;
            settings.SaveSettings();
        }
        #endregion

        #region Settings-OutputStyle
        private void includeOriginalStringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeOriginalString = !settings.OutputStyleIncludeOriginalString; //negace
            includeOriginalStringToolStripMenuItem.Checked = settings.OutputStyleIncludeOriginalString; //update UI
            settings.SaveSettings();
        }

        private void includeNumberOfHashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeNumberOfHash = !settings.OutputStyleIncludeNumberOfHash; //negace
            includeNumberOfHashToolStripMenuItem.Checked = settings.OutputStyleIncludeNumberOfHash; //update UI
            settings.SaveSettings();
        }
        private void includeHashingAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settings.OutputStyleIncludeHashAlgorithm = !settings.OutputStyleIncludeHashAlgorithm; //negace
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeHashAlgorithm; //update UI
            settings.SaveSettings();
        }
        #endregion

        #endregion

        #endregion

        private void UIToolStripMenuLoad()
        {
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeOriginalString;
            includeNumberOfHashToolStripMenuItem.Checked = settings.OutputStyleIncludeNumberOfHash;
            includeHashingAlgorithmToolStripMenuItem.Checked = settings.OutputStyleIncludeHashAlgorithm;
            includeSaltToolStripMenuItem.Checked = settings.IncludeSalt;
            includePepperToolStripMenuItem.Checked = settings.IncludePepper;
            switch (settings.OutputType)
            {
                case OutputTypeEnum.MessageBox: messageBoxToolStripMenuItem.Checked = true; break;
                case OutputTypeEnum.Listbox: listBoxToolStripMenuItem.Checked = true; break;
                case OutputTypeEnum.TXTFile: txtFileToolStripMenuItem.Checked = true; break;
            }
        }
    }
}

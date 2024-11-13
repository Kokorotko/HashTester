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
using static HashTester.Hasher;
using static System.Net.Mime.MediaTypeNames;

namespace HashTester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }       

        enum Output
        {
            MessageBox,
            Listbox,
            TXTFile
        }
        Output outputOption;
        Hasher.HashingAlgorithm algorithm = Hasher.HashingAlgorithm.MD5;

        #region MainButtons
        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textHashSimple.Lines.Count(); i++)
            {
                string text = textHashSimple.Lines[i];
                CheckForOutputOption();
                string hash = Hasher.Hash(text, algorithm);
                string outputString = OutputString(text, hash, i + 1);
                //Output
                switch (outputOption)
                {
                    case Output.MessageBox: MessageBox.Show(outputString); break;
                    case Output.Listbox: listBox1.Items.Add(outputString); break;
                    case Output.TXTFile:
                        {
                            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                            {
                                using (StreamWriter writer = new StreamWriter(saveFileDialog1.FileName)) { writer.WriteLine(outputString); }
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
                        CheckForOutputOption();
                        using (StreamReader reader = new StreamReader(openFileDialog1.FileName))
                        {
                            if (outputOption == Output.TXTFile)
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
                                    if (outputOption == Output.MessageBox) MessageBox.Show(outputString);
                                    else listBox1.Items.Add(outputString);
                                }
                            }
                        }
                    }
                }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
        #endregion
        
        #region Forms

        private void buttonFormGradual_Click(object sender, EventArgs e)
        {
            FormGradual formGradual = new FormGradual();
            formGradual.Show();
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        #endregion
        private void CheckForOutputOption()
        {
            if (radioButton1.Checked) outputOption = Output.MessageBox;
            else if (radioButton2.Checked) outputOption = Output.Listbox;
            else outputOption = Output.TXTFile;
        }

        private string OutputString(string originalString, string hash, int indexOfHash)
        {
            string outputString = hash;
            if (checkBox1.Checked)
            {
                outputString = originalString + ": " + outputString;
            }
            if (checkBox3.Checked)
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
            if (checkBox2.Checked)
            {
                outputString = indexOfHash.ToString() + ". " + outputString;
            }
            return outputString;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
        }

        private void settingsForm_Click(object sender, EventArgs e)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.ShowDialog();
        }
    }
}

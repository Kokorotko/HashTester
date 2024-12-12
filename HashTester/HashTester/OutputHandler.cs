using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HashTester.Hasher;
using static HashTester.Settings;

namespace HashTester
{
    public class OutputHandler
    {
        Settings settings = new Settings();
        Hasher.HashingAlgorithm algorithm = HashingAlgorithm.MD5;
        Hasher hasher = new Hasher();
        public string OutputStyleString(string originalString, string hash, int indexOfHash, bool isSaltUsed, bool isPepperUsed)
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
            if (settings.OutputStyleIncludeSaltPepper)
            {
                if (isSaltUsed) outputString += " (salt: " + hasher.CurrentSalt + ")";
                if (isPepperUsed) outputString += " (pepper: " + hasher.CurrentPepper + ")";
            }
            return outputString;
        }

        /// <summary>
        /// Handles output based on user settings.
        /// </summary>
        public void OutputTypeShow(string outputString, ListBox listBox)
        {
            switch (settings.OutputType)
            {
                case OutputTypeEnum.MessageBox:
                    MessageBox.Show(outputString);
                    break;
                case OutputTypeEnum.Listbox:
                    listBox.Items.Add(outputString);
                    break;
                case OutputTypeEnum.TXTFile:
                    SaveFileDialog saveFileDialogCustom = new SaveFileDialog();
                    if (saveFileDialogCustom.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialogCustom.FileName, outputString);
                    }
                    break;
            }
        }
        /// <summary>
        /// Handles output based on user settings for multiple string.
        /// </summary>
        public void OutputTypeShow(string[] outputString, ListBox listBox)
        {
            string completeOutput = "";
            foreach (string singleOutputString in outputString) completeOutput += singleOutputString + "\n";
            OutputTypeShow(completeOutput, listBox);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    public partial class SaltAndPepperForm: Form
    {
        Hasher.HashingAlgorithm algorithm;
        Hasher hasher = new Hasher();
        SaltAndPepper saltAndPepper = new SaltAndPepper();
        public SaltAndPepperForm()
        {
            InitializeComponent();
        }

        private void buttonHashSimpleText_Click(object sender, EventArgs e)
        {
            bool askForSaltPepper = false;
            if (checkBoxUseSalt.Checked || checkBoxUsePepper.Checked) askForSaltPepper = true;
            ProcessingHash(textHashSimple.Text, algorithm, askForSaltPepper);
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            algorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void ProcessingHash(string originalText, Hasher.HashingAlgorithm algorithm, bool askForSaltPepper)
        {
            bool usingSaltAndPepper = false;
            bool isSaltUsed = false;
            bool isPepperUsed = false;
            string salt = "";
            string pepper = "";
            string hashID = "";
            if (askForSaltPepper) usingSaltAndPepper = hasher.IsUsingSaltAndPepper(checkBoxUseSalt.Checked, checkBoxUsePepper.Checked, out salt, out pepper, out hashID);
            for (int i = 0; i < originalText.Length; i++)
            {
                string hash = string.Empty;
                if (usingSaltAndPepper)
                {
                    if (checkBoxUseLog.Checked)
                    {
                        if (!String.IsNullOrEmpty(salt)) listBoxLog.Items.Add(Languages.Translate(402) + ": " + salt);
                        if (!String.IsNullOrEmpty(pepper)) listBoxLog.Items.Add(Languages.Translate(403) + ": " + pepper);
                        if (!String.IsNullOrEmpty(hashID)) listBoxLog.Items.Add(Languages.Translate(612) + ": " + hashID);
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    hash = hasher.HashSaltPepper(originalText, isSaltUsed, isPepperUsed, salt, pepper, algorithm);
                }
                else
                {
                    hash = hasher.Hash(originalText, algorithm);
                }
                OutputHandler outputHandler = new OutputHandler(algorithm);
                string outputString = outputHandler.OutputStyleString(originalText, hash, i + 1, isSaltUsed, isPepperUsed, salt, pepper);
                outputHandler.OutputTypeShow(outputString, listBoxLog);
            }
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
                else MessageBox.Show(Languages.Translate(42),Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show(Languages.Translate(43), Languages.Translate(44), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaltAndPepperForm_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
            FormManagement.SetUpFormTheme(this);
            #region Languages
            buttonHashSimpleText.Text = Languages.Translate(31);
            checkBoxUsePepper.Text = Languages.Translate(6);
            checkBoxUseSalt.Text = Languages.Translate(5);
            checkBoxUseLog.Text = Languages.Translate(246);
            label1.Text = Languages.Translate(646);
            labelAlgorithm.Text = Languages.Translate(10024);
            buttonClearListBox.Text = Languages.Translate(10000);
            buttonSaveLog.Text = Languages.Translate(10001);
            buttonClipboard.Text = Languages.Translate(10002);
            groupBoxTester.Text = Languages.Translate(647);
            groupBoxShowInfo.Text = Languages.Translate(648);
            labelName.Text = Languages.Translate(438);
            labelPassword.Text = Languages.Translate(21);
            buttonRegister.Text = Languages.Translate(10035);
            buttonLogin.Text = Languages.Translate(649);
            buttonRemove.Text = Languages.Translate(650);
            buttonRemoveAll.Text = Languages.Translate(651);
            buttonShowRegistrered.Text = Languages.Translate(652);
            buttonInfoID.Text = Languages.Translate(653);
            buttonShowAllID.Text = Languages.Translate(654);
            buttonDeleteAllHashID.Text = Languages.Translate(655);
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check UI
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Languages.Translate(614), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show(Languages.Translate(615), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //checkIfThereIsAlreadyUserWithTheSameName            
            if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
            Register();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Languages.Translate(614), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(Languages.Translate(643), Languages.Translate(10025), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
                if (RemoveSingle())
                {
                    if (checkBoxUseLog.Checked)
                    {
                        listBoxLog.Items.Add(Languages.Translate(644));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    MessageBox.Show(Languages.Translate(644), Languages.Translate(10033), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(645));
                    MessageBox.Show(Languages.Translate(645), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Languages.Translate(614), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show(Languages.Translate(615), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
            if (Login(out bool displayMessage))
            {
                if (displayMessage) MessageBox.Show(Languages.Translate(617), Languages.Translate(10033), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (displayMessage) MessageBox.Show(Languages.Translate(618), Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //Info about ID
        {
            if (String.IsNullOrEmpty(textBoxHashID.Text))
            {
                MessageBox.Show(Languages.Translate(616), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> info = ShowIDInfo();
            if (info.Count == 0)
            {
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(619));
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                MessageBox.Show(Languages.Translate(619), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string s = "";
            for(int i = 0; i < info.Count(); i++)
            {
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(info[i]);
                s += info[i] + Environment.NewLine;
            }            
            if (checkBoxUseLog.Checked) listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            MessageBox.Show(s, Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        

        private void buttonShowAllID_Click(object sender, EventArgs e) //Show all Registered Users
        {
            if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
            List<string> allHashID = ShowAllRegisteredUsers();           
            if (allHashID.Count <= 0)
            {
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(620));
                MessageBox.Show(Languages.Translate(620), Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = "";
            for(int i = 0; i < allHashID.Count(); i++)
            {
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(allHashID[i]);
                s += allHashID[i] + Environment.NewLine;
            }
            if (checkBoxUseLog.Checked) listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            MessageBox.Show(s, Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Languages.Translate(621), Languages.Translate(10025), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string path = Path.Combine(Settings.PathToPasswordTester, "nameTable.txt");
                if (!File.Exists(path)) File.Delete(path);
                saltAndPepper.GenerateNameTableFile();
                MessageBox.Show(Languages.Translate(622), Languages.Translate(10033), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (checkBoxUseLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(622));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else MessageBox.Show(Languages.Translate(10032), Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonShowAllID_Click_1(object sender, EventArgs e) //Show All ID
        {
            string[] fileNames = Directory.GetFiles(Settings.PathToHashData)
                              .Select(Path.GetFileName)
                              .ToArray();
            if (fileNames.Count() <= 0)
            {
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(613));
                MessageBox.Show(Languages.Translate(613), Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = "";
            for (int i = 0; i < fileNames.Count(); i++)
            {
                string temp = Path.GetFileNameWithoutExtension(fileNames[i]);
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(temp);
                s += temp + Environment.NewLine;
            }
            if (checkBoxUseLog.Checked) listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            MessageBox.Show(s, Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool Register()
        {
            string pathToFile = Path.Combine(Settings.PathToPasswordTester, "nameTable.txt");
            string name = textBoxName.Text;
            string passwordHash = "";
            bool useSalt = checkBoxUseSalt.Checked;
            bool usePepper = checkBoxUsePepper.Checked;
            string salt = "";
            string pepper = "";
            string hashID = "";
            using (StreamReader reader = new StreamReader(pathToFile))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] split = line.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                    if (!String.IsNullOrEmpty(line) && !line.StartsWith("//"))
                    {
                        if (split[0] == name)
                        {
                            MessageBox.Show(Languages.Translate(623), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(623));
                            return false;
                        }
                    }
                }
            }
            //Register
            if (!hasher.IsUsingSaltAndPepper(checkBoxUseSalt.Checked, checkBoxUsePepper.Checked, out salt, out pepper, out hashID))
            {
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(624));
                string tempPath = Path.Combine(Settings.BasePathToFiles, "HashData", hashID + ".txt");
                if (File.Exists(tempPath)) File.Delete(tempPath);
                hashID = "null";
                usePepper = false;
                useSalt = false;
            }
            passwordHash = hasher.HashSaltPepper(textBoxPassword.Text, useSalt, usePepper, salt, pepper, (Hasher.HashingAlgorithm)hashSelector.SelectedIndex);
            if (checkBoxUseLog.Checked)
            {
                listBoxLog.Items.Add(Languages.Translate(625) + ": " + passwordHash);
                if (useSalt) listBoxLog.Items.Add(Languages.Translate(402) + ": " + salt);
                if (usePepper) listBoxLog.Items.Add(Languages.Translate(403) + ": " + pepper);
            }
            using (StreamWriter writer = new StreamWriter(pathToFile, true))
            {
                string s = name + "==" + hashID + "==" + algorithm.ToString() + "==" + passwordHash;
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(s);
                writer.WriteLine(s);
                MessageBox.Show(Languages.Translate(626), Languages.Translate(10034), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return true;
        }

        private bool Login(out bool displayMessage)
        {
            displayMessage = true;
            bool foundName = false;
            Hasher.HashingAlgorithm usedAlgorithm = Hasher.HashingAlgorithm.MD5;
            string passwordHash = "";
            string hashID = "";
            string userPassword = textBoxPassword.Text;
            using (StreamReader reader = new StreamReader(Path.Combine(Settings.PathToPasswordTester, "nameTable.txt")))
            {
                while (!reader.EndOfStream && !foundName)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line) && !line.StartsWith("//"))
                    {
                        string[] split = line.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                        if (split.Length >= 4 && split[0] == textBoxName.Text)
                        {
                            switch (split[2])
                            {
                                case "MD5": usedAlgorithm = Hasher.HashingAlgorithm.MD5; break;
                                case "SHA1": usedAlgorithm = Hasher.HashingAlgorithm.SHA1; break;
                                case "SHA256": usedAlgorithm = Hasher.HashingAlgorithm.SHA256; break;
                                case "SHA512": usedAlgorithm = Hasher.HashingAlgorithm.SHA512; break;
                                case "RIPEMD160": usedAlgorithm = Hasher.HashingAlgorithm.RIPEMD160; break;
                                case "CRC32": usedAlgorithm = Hasher.HashingAlgorithm.CRC32; break;
                            }                            
                            passwordHash = split[3];
                            hashID = split[1];
                            foundName = true;
                            if (checkBoxUseLog.Checked)
                            {
                                listBoxLog.Items.Add("Hash ID: " + hashID);
                                listBoxLog.Items.Add(Languages.Translate(627) + ": " + usedAlgorithm);
                                listBoxLog.Items.Add(Languages.Translate(625) + ": " + passwordHash);
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                        }
                    }
                }
            }
            if (!foundName)
            {
                MessageBox.Show(Languages.Translate(628), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                displayMessage = false;
                return false;
            }
            if(!string.IsNullOrEmpty(hashID) && hashID != "null")
            {
                hasher.LoadSalt(hashID, out string salt, out int pepperLength);
                if (!string.IsNullOrEmpty(salt))
                {
                    userPassword = salt + userPassword;
                    if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(629) + ": " + salt);
                }
                if (pepperLength > 0 && hasher.CheckPepper(textBoxPassword.Text, passwordHash, pepperLength, usedAlgorithm, out string pepper))
                {
                    if (!string.IsNullOrEmpty(pepper))
                    {
                        userPassword += pepper;
                        if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(630) + ": " + pepper);
                    }
                }
            }
            if (checkBoxUseLog.Checked)
            {
                listBoxLog.Items.Add(Languages.Translate(631) + ": " + userPassword);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
            return hasher.Hash(userPassword, usedAlgorithm) == passwordHash;
        }

        private bool RemoveSingle()
        {
            string path = Path.Combine(Settings.PathToPasswordTester, "nameTable.txt");
            string tempPath = Path.Combine(Path.GetDirectoryName(path), "nameTableTemp.txt");
            bool foundName = false;
            using (StreamReader reader = new StreamReader(path))
            using (StreamWriter writer = new StreamWriter(tempPath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!foundName)
                    {
                        if (!String.IsNullOrEmpty(line) && !line.StartsWith("//"))
                        {
                            string[] split = line.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                            if (split[0] == textBoxName.Text)
                            {
                                foundName = true;
                            }
                            else writer.WriteLine(line);
                        }
                    }
                    else writer.WriteLine(line); //Write the rest of the file
                }
            }
            File.Delete(path);
            File.Move(tempPath, path);
            return foundName;
        }

        private List<string> ShowAllRegisteredUsers()
        {
            string path = Path.Combine(Settings.PathToPasswordTester, "nameTable.txt");
            List<string> allHashID = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line) && !line.StartsWith("//"))
                    {
                        string[] split = line.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                        allHashID.Add(Languages.Translate(438) + ": " + split[0] + " hashID: " + split[1]);
                    }
                }
            }
            return allHashID;
        }

        private List<string> ShowIDInfo()
        {
            string pathNameTable = Path.Combine(Settings.PathToPasswordTester, "nameTable.txt");
            string pathHashID = Path.Combine(Settings.PathToHashData, textBoxHashID.Text + ".txt");
            bool foundIDinNameTable = false;
            List<string> info = new List<string>();
            //checkNameTable
            if (File.Exists(pathNameTable))
            {
                using (StreamReader reader = new StreamReader(pathNameTable))
                {
                    while (!reader.EndOfStream && !foundIDinNameTable)
                    {
                        string line = reader.ReadLine();
                        if (!String.IsNullOrEmpty(line) && !line.StartsWith("//")) //Do not read
                        {
                            string[] split = line.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                            if (split[1] == textBoxHashID.Text)
                            {
                                foundIDinNameTable = true;
                                info.Add(Languages.Translate(632) + ": " + split[0] + " " + Languages.Translate(633) + ": " + split[3] + " (" + Languages.Translate(634) + ": " + split[2] + ")");
                            }
                        }
                    }
                }
                if (!foundIDinNameTable) info.Add(Languages.Translate(635));
            }
            else
            {
                saltAndPepper.GenerateNameTableFile();
                info.Add(Languages.Translate(636));
            }
            //check hashID           
            if (File.Exists(pathHashID))
            {
                hasher.LoadSalt(textBoxHashID.Text, out string salt, out int pepperLenght);
                if (!String.IsNullOrEmpty(salt)) info.Add(Languages.Translate(637) + ": " + salt);
                if (pepperLenght > 0) info.Add(Languages.Translate(638) + ": " + pepperLenght);
            }
            else
            {
                info.Add(Languages.Translate(639));
            }
            return info;
        }

        private void buttonDeleteAllHashID_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Languages.Translate(640), Languages.Translate(10025), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string[] fileNames = Directory.GetFiles(Settings.PathToHashData).ToArray();
                if (fileNames.Count() <= 0)
                {
                    if (checkBoxUseLog.Checked) listBoxLog.Items.Add(Languages.Translate(613));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    MessageBox.Show(Languages.Translate(641), Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                for (int i = 0; i < fileNames.Count(); i++)
                {
                    File.Delete(fileNames[i]);
                }
                if (checkBoxUseLog.Checked)
                {
                    listBoxLog.Items.Add(Languages.Translate(642));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(Languages.Translate(642), Languages.Translate(10033), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(Languages.Translate(10032), Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }
    }
}

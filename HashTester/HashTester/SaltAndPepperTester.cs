using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HashTester
{
    public partial class SaltAndPepperTester: Form
    {
        Hasher.HashingAlgorithm algorithm;
        Hasher hasher = new Hasher();
        SaltAndPepper saltAndPepper = new SaltAndPepper();
        public SaltAndPepperTester()
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
            string salt = "";
            string pepper = "";
            string hashID = "";
            string hash = "";
            OutputHandler outputHandler = new OutputHandler(algorithm);
            if (askForSaltPepper) usingSaltAndPepper = hasher.IsUsingSaltAndPepper(checkBoxUseSalt.Checked, checkBoxUsePepper.Checked, out salt, out pepper, out hashID);
            if (usingSaltAndPepper)
            {
                if (Settings.ShowLog)
                {
                    if (!String.IsNullOrEmpty(salt)) listBoxLog.Items.Add(Languages.Translate(Languages.L.Salt) + ": " + salt);
                    if (!String.IsNullOrEmpty(pepper)) listBoxLog.Items.Add(Languages.Translate(Languages.L.Pepper) + ": " + pepper);
                    if (!String.IsNullOrEmpty(hashID)) listBoxLog.Items.Add(Languages.Translate(Languages.L.Hashid) + ": " + hashID);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                hash = hasher.HashSaltPepper(originalText, checkBoxUseSalt.Checked, checkBoxUsePepper.Checked, salt, pepper, algorithm);
            }
            else
            {
                hash = hasher.Hash(originalText, algorithm);
            }
            string outputString = outputHandler.OutputStyleString(originalText, hash, 1, checkBoxUseSalt.Checked, checkBoxUsePepper.Checked, salt, pepper);
            outputHandler.OutputTypeShow(outputString, listBoxLog);
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
                else MessageBox.Show(Languages.Translate(Languages.L.PleaseSelectAnItemFromTheLogListboxBeforeCopying),Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show(Languages.Translate(Languages.L.FailedToCopyToClipboard), Languages.Translate(Languages.L.ClipboardError), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaltAndPepperForm_Load(object sender, EventArgs e)
        {
            hashSelector.SelectedIndex = 0;
            FormManagement.SetUpFormTheme(this);
            #region Languages
            this.Name = Languages.Translate(Languages.L.SaltAndPepperTester);
            buttonHashSimpleText.Text = Languages.Translate(Languages.L.HashText);
            checkBoxUsePepper.Text = Languages.Translate(Languages.L.UsePepper) + "*";
            checkBoxUseSalt.Text = Languages.Translate(Languages.L.UseSalt) + "*";
            label1.Text = "*" + Languages.Translate(Languages.L.HasPriorityOverSettings);
            labelAlgorithm.Text = Languages.Translate(Languages.L.Algorithm);
            buttonClearListBox.Text = Languages.Translate(Languages.L.ClearListbox);
            buttonSaveLog.Text = Languages.Translate(Languages.L.SaveLog);
            buttonClipboard.Text = Languages.Translate(Languages.L.Clipboard);
            groupBoxTester.Text = Languages.Translate(Languages.L.PasswordTester);
            groupBoxShowInfo.Text = Languages.Translate(Languages.L.ShowInfo);
            labelName.Text = Languages.Translate(Languages.L.Username);
            labelPassword.Text = Languages.Translate(Languages.L.Password);
            buttonRegister.Text = Languages.Translate(Languages.L.Register);
            buttonLogin.Text = Languages.Translate(Languages.L.Login);
            buttonRemove.Text = Languages.Translate(Languages.L.Remove);
            buttonRemoveAll.Text = Languages.Translate(Languages.L.RemoveAll);
            buttonShowRegistrered.Text = Languages.Translate(Languages.L.ShowAllRegisteredUsers);
            buttonInfoID.Text = Languages.Translate(Languages.L.InfoAboutTheId);
            buttonShowAllID.Text = Languages.Translate(Languages.L.ShowAllId);
            buttonDeleteAllHashID.Text = Languages.Translate(Languages.L.DeleteAllId);
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check UI
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseWriteNameIntoTheNameTextbox), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseWritePasswordIntoThePasswordTextbox), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show(Languages.Translate(Languages.L.PleaseWriteNameIntoTheNameTextbox), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show(Languages.Translate(Languages.L.DoYouReallyWantToDeleteThisRegistryFromTheDatabase), Languages.Translate(Languages.L.Warning), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
                if (RemoveSingle())
                {
                    if (Settings.ShowLog)
                    {
                        listBoxLog.Items.Add(Languages.Translate(Languages.L.RegistryDeletedSuccessfully));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    MessageBox.Show(Languages.Translate(Languages.L.RegistryDeletedSuccessfully), Languages.Translate(Languages.L.Success), MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Settings.ShowLog)
                    {
                        listBoxLog.Items.Add(Languages.Translate(Languages.L.CouldNotFindTheRegistryToDelete));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    MessageBox.Show(Languages.Translate(Languages.L.CouldNotFindTheRegistryToDelete), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseWriteNameIntoTheNameTextbox), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseWritePasswordIntoThePasswordTextbox), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
            if (Login(out bool displayMessage))
            {
                if (displayMessage) MessageBox.Show(Languages.Translate(Languages.L.LoggedInSuccessfully), Languages.Translate(Languages.L.Success), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (displayMessage) MessageBox.Show(Languages.Translate(Languages.L.WrongPassword), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //Info about ID
        {
            if (String.IsNullOrEmpty(textBoxHashID.Text))
            {
                MessageBox.Show(Languages.Translate(Languages.L.PleaseWriteHashidIntoTheTextbox), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> info = ShowIDInfo();
            if (info.Count == 0)
            {
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.ThereAreNoInformationsToShowAboutHashid));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(Languages.Translate(Languages.L.ThereAreNoInformationsToShowAboutHashid), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string s = "";
            for(int i = 0; i < info.Count(); i++)
            {
                if (Settings.ShowLog) listBoxLog.Items.Add(info[i]);
                s += info[i] + Environment.NewLine;
            }            
            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            MessageBox.Show(s, Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        

        private void buttonShowAllID_Click(object sender, EventArgs e) //Show all Registered Users
        {
            if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
            List<string> allHashID = ShowAllRegisteredUsers();           
            if (allHashID.Count <= 0)
            {
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.ThereAreNoRegisteredUsersInDatabase));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(Languages.Translate(Languages.L.ThereAreNoRegisteredUsersInDatabase), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = "";
            for(int i = 0; i < allHashID.Count(); i++)
            {
                if (Settings.ShowLog) listBoxLog.Items.Add(allHashID[i]);
                s += allHashID[i] + Environment.NewLine;
            }
            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            MessageBox.Show(s, Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Languages.Translate(Languages.L.DoYouReallyWantToDeleteTheEntireDatabase), Languages.Translate(Languages.L.Warning), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string path = Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt");
                if (!File.Exists(path)) File.Delete(path);
                saltAndPepper.GenerateNameTableFile();
                MessageBox.Show(Languages.Translate(Languages.L.DatabaseDeletedSuccessfully), Languages.Translate(Languages.L.Success), MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.DatabaseDeletedSuccessfully));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
            }
            else MessageBox.Show(Languages.Translate(Languages.L.Aborted), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonShowAllID_Click_1(object sender, EventArgs e) //Show All ID
        {
            string[] fileNames = Directory.GetFiles(Settings.DirectoryToHashData)
                              .Select(Path.GetFileName)
                              .ToArray();
            if (fileNames.Count() <= 0)
            {
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.ThereAreNoIdsToShow));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(Languages.Translate(Languages.L.ThereAreNoIdsToShow), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = "";
            for (int i = 0; i < fileNames.Count(); i++)
            {
                string temp = Path.GetFileNameWithoutExtension(fileNames[i]);
                if (Settings.ShowLog) listBoxLog.Items.Add(temp);
                s += temp + Environment.NewLine;
            }
            listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            MessageBox.Show(s, Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool Register()
        {
            string pathToFile = Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt");
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
                            MessageBox.Show(Languages.Translate(Languages.L.ThisNameIsAlreadyRegistered), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            if (Settings.ShowLog)
                            {
                                listBoxLog.Items.Add(Languages.Translate(Languages.L.ThisNameIsAlreadyRegistered));
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                            return false;
                        }
                    }
                }
            }
            //Register
            if (!hasher.IsUsingSaltAndPepper(checkBoxUseSalt.Checked, checkBoxUsePepper.Checked, textBoxName.Text, out salt, out pepper, out hashID))
            {
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.NotUsingSaltAndPepper));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                string tempPath = Path.Combine(Settings.DirectoryExeBase, "HashData", hashID + ".txt");
                if (File.Exists(tempPath)) File.Delete(tempPath);
                hashID = "null";
                usePepper = false;
                useSalt = false;
            }
            passwordHash = hasher.HashSaltPepper(textBoxPassword.Text, useSalt, usePepper, salt, pepper, (Hasher.HashingAlgorithm)hashSelector.SelectedIndex);
            if (Settings.ShowLog)
            {
                listBoxLog.Items.Add(Languages.Translate(Languages.L.HashedPassword) + ": " + passwordHash);
                if (useSalt) listBoxLog.Items.Add(Languages.Translate(Languages.L.Salt) + ": " + salt);
                if (usePepper) listBoxLog.Items.Add(Languages.Translate(Languages.L.Pepper) + ": " + pepper);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
            using (StreamWriter writer = new StreamWriter(pathToFile, true))
            {
                string s = name + "==" + hashID + "==" + algorithm.ToString() + "==" + passwordHash;
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(s);
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                writer.WriteLine(s);
                MessageBox.Show(Languages.Translate(Languages.L.SuccesfullyRegistered), Languages.Translate(Languages.L.Registered), MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            using (StreamReader reader = new StreamReader(Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt")))
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
                            if (Settings.ShowLog)
                            {
                                listBoxLog.Items.Add("Hash ID: " + hashID);
                                listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedAlgorithmForLogin) + ": " + usedAlgorithm);
                                listBoxLog.Items.Add(Languages.Translate(Languages.L.HashedPassword) + ": " + passwordHash);
                                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                            }
                        }
                    }
                }
            }
            if (!foundName)
            {
                MessageBox.Show(Languages.Translate(Languages.L.UsernameNotFoundInDatabase), Languages.Translate(Languages.L.Warning), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                displayMessage = false;
                return false;
            }
            if(!string.IsNullOrEmpty(hashID) && hashID != "null")
            {
                hasher.LoadSalt(hashID, out string salt, out int pepperLength);
                if (!string.IsNullOrEmpty(salt))
                {
                    userPassword = salt + userPassword;
                    if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedSalt) + ": " + salt);
                }
                if (pepperLength > 0 && hasher.CheckPepper(textBoxPassword.Text, passwordHash, pepperLength, usedAlgorithm, out string pepper))
                {
                    if (!string.IsNullOrEmpty(pepper))
                    {
                        userPassword += pepper;
                        if (Settings.ShowLog) listBoxLog.Items.Add(Languages.Translate(Languages.L.UsedPepper) + ": " + pepper);
                    }
                }
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
            if (Settings.ShowLog)
            {
                listBoxLog.Items.Add(Languages.Translate(Languages.L.FullInputPasswordBeforeHashing) + ": " + userPassword);
                listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
            }
            return hasher.Hash(userPassword, usedAlgorithm) == passwordHash;
        }

        private bool RemoveSingle()
        {
            string path = Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt");
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
            string path = Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt");
            List<string> allHashID = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrEmpty(line) && !line.StartsWith("//"))
                    {
                        string[] split = line.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                        allHashID.Add(Languages.Translate(Languages.L.Name) + ": " + split[0] + " hashID: " + split[1]);
                    }
                }
            }
            return allHashID;
        }

        private List<string> ShowIDInfo()
        {
            string pathNameTable = Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt");
            string pathHashID = Path.Combine(Settings.DirectoryToHashData, textBoxHashID.Text + ".txt");
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
                                info.Add(Languages.Translate(Languages.L.ThisIdIsAssociatedWithName) + ": " + split[0] + " " + Languages.Translate(Languages.L.AndHash) + ": " + split[3] + " (" + Languages.Translate(Languages.L.HashedWith) + ": " + split[2] + ")");
                            }
                        }
                    }
                }
                if (!foundIDinNameTable) info.Add(Languages.Translate(Languages.L.DidntFindAnyNameAssosiatedWithThisId));
            }
            else
            {
                saltAndPepper.GenerateNameTableFile();
                info.Add(Languages.Translate(Languages.L.CouldNotFindAnyPasswordAssosiatedWithThisHashid));
            }
            //check hashID           
            if (File.Exists(pathHashID))
            {
                hasher.LoadSalt(textBoxHashID.Text, out string salt, out int pepperLenght);
                if (!String.IsNullOrEmpty(salt)) info.Add(Languages.Translate(Languages.L.SaltSavedForThisId) + ": " + salt);
                if (pepperLenght > 0) info.Add(Languages.Translate(Languages.L.LenghtOfPepperUsedIs) + ": " + pepperLenght);
            }
            else
            {
                info.Add(Languages.Translate(Languages.L.CouldNotFindAnySaltpepperAssosiatedWithThisHashid));
            }
            return info;
        }

        private void buttonDeleteAllHashID_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Languages.Translate(Languages.L.DoYouReallyWantToDeleteTheAllHashid), Languages.Translate(Languages.L.Warning), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string[] fileNames = Directory.GetFiles(Settings.DirectoryToHashData).ToArray();
                if (fileNames.Count() <= 0)
                {
                    if (Settings.ShowLog)
                    {
                        listBoxLog.Items.Add(Languages.Translate(Languages.L.ThereAreNoIdsToShow));
                        listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                    }
                    MessageBox.Show(Languages.Translate(Languages.L.ThereAreNoHashids), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                for (int i = 0; i < fileNames.Count(); i++)
                {
                    File.Delete(fileNames[i]);
                }
                if (Settings.ShowLog)
                {
                    listBoxLog.Items.Add(Languages.Translate(Languages.L.AllHashidDeletedSuccessfully));
                    listBoxLog.TopIndex = listBoxLog.Items.Count - 1;
                }
                MessageBox.Show(Languages.Translate(Languages.L.AllHashidDeletedSuccessfully), Languages.Translate(Languages.L.Success), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show(Languages.Translate(Languages.L.Aborted), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }
    }
}

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
                        if (!String.IsNullOrEmpty(salt)) listBoxLog.Items.Add("Salt: " + salt);
                        if (!String.IsNullOrEmpty(pepper)) listBoxLog.Items.Add("Pepper: " + pepper);
                        if (!String.IsNullOrEmpty(hashID)) listBoxLog.Items.Add("HashID: " + hashID);
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
                else MessageBox.Show(Languages.Translate(42), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Check UI
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Please write name into the Name textbox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please write password into the Password textbox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Please write name into the Name textbox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Do you really want to remove this registry from the database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
                if (RemoveSingle()) MessageBox.Show("Registry removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show("Could not find the registry", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Please write name into the Name textbox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please write password into the Password textbox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
            if (Login(out bool displayMessage))
            {
                if (displayMessage) MessageBox.Show("Logged in successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (displayMessage) MessageBox.Show("Wrong password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e) //Info about ID
        {
            if (String.IsNullOrEmpty(textBoxHashID.Text))
            {
                MessageBox.Show("Please write hashID into the textbox.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> info = ShowIDInfo();
            if (info.Count == 0) MessageBox.Show("There are no IDs to show.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            string s = "";
            for(int i = 0; i < info.Count(); i++)
            {
                s += info[i] + Environment.NewLine;
            }
            MessageBox.Show(s, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }        

        private void buttonShowAllID_Click(object sender, EventArgs e) //Show all Registered Users
        {
            if (!saltAndPepper.CheckIfPasswordTesterExists(true)) return;
            List<string> allHashID = ShowAllRegisteredUsers();           
            if (allHashID.Count <= 0)
            {
                MessageBox.Show("There are no registered users in database.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = "";
            for(int i = 0; i < allHashID.Count() - 1; i++)
            {
                s += allHashID[i] + Environment.NewLine;
            }
            s += allHashID.Last();
            MessageBox.Show(s, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to delete the entire database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string path = Path.Combine(Settings.PathToPasswordTester, "nameTable.txt");
                if (!File.Exists(path)) File.Delete(path);
                saltAndPepper.GenerateNameTableFile();
                MessageBox.Show("Database deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Aborted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonShowAllID_Click_1(object sender, EventArgs e) //Show All ID
        {
            string[] fileNames = Directory.GetFiles(Settings.PathToHashData)
                              .Select(Path.GetFileName)
                              .ToArray();
            if (fileNames.Count() <= 0)
            {
                MessageBox.Show("There are no hashIDs.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string s = "";
            for (int i = 0; i < fileNames.Count() - 1; i++)
            {
                s += Path.GetFileNameWithoutExtension(fileNames[i]) + Environment.NewLine;
            }
            s += fileNames.Last();
            MessageBox.Show(s, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("This name is already registered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }
            }
            //Register
            if (!hasher.IsUsingSaltAndPepper(checkBoxUseSalt.Checked, checkBoxUsePepper.Checked, out salt, out pepper, out hashID))
            {
                string tempPath = Path.Combine(Settings.BasePathToFiles, "HashData", hashID + ".txt");
                if (File.Exists(tempPath)) File.Delete(tempPath);
                hashID = "null";
                usePepper = false;
                useSalt = false;
            }
            passwordHash = hasher.HashSaltPepper(textBoxPassword.Text, useSalt, usePepper, salt, pepper, (Hasher.HashingAlgorithm)hashSelector.SelectedIndex);
            using (StreamWriter writer = new StreamWriter(pathToFile, true))
            {
                string s = name + "==" + hashID + "==" + algorithm.ToString() + "==" + passwordHash;
                if (checkBoxUseLog.Checked) listBoxLog.Items.Add(s);
                writer.WriteLine(s);
                MessageBox.Show("Succesfully registered.", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        }
                    }
                }
            }
            if (!foundName)
            {
                MessageBox.Show("Username not found in nameTable.txt", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                displayMessage = false;
                return false;
            }
            if(!string.IsNullOrEmpty(hashID) && hashID != "null")
            {
                hasher.LoadSalt(hashID, out string salt, out int pepperLength);
                if (!string.IsNullOrEmpty(salt))
                {
                    userPassword = salt + userPassword;
                }
                if (pepperLength > 0 && hasher.CheckPepper(textBoxPassword.Text, passwordHash, pepperLength, usedAlgorithm, out string pepper))
                {
                    if (!string.IsNullOrEmpty(pepper))
                    {
                        userPassword += pepper;
                    }
                }
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
                        allHashID.Add("Name: " + split[0] + " hashID: " + split[1]);
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
                                info.Add("This ID is associated with name: " + split[0] + " and hash: " + split[3] + " (hashed with " + split[2] + ")");
                            }
                        }
                    }
                }
                if (!foundIDinNameTable) info.Add("Didnt find any name assosiated with this ID.");
            }
            else
            {
                saltAndPepper.GenerateNameTableFile();
                info.Add("Could not find any password assosiated with this hashID");
            }
            //check hashID           
            if (File.Exists(pathHashID))
            {
                hasher.LoadSalt(textBoxHashID.Text, out string salt, out int pepperLenght);
                if (!String.IsNullOrEmpty(salt)) info.Add("Salt saved for this ID: " + salt);
                if (pepperLenght > 0) info.Add("Lenght of pepper used is: " + pepperLenght);
            }
            else
            {
                info.Add("Could not find any salt/pepper assosiated with this hashID");
            }
            return info;
        }
    }
}

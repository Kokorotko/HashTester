using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace HashTester
{
    public partial class CheckCollisionForm : Form
    {
        public CheckCollisionForm()
        {
            InitializeComponent();
        }
        public enum CollisionDetectionFormat
        {
            HEX,
            STRING,
            BIN
        }
        Hasher.HashingAlgorithm hashingAlgorithm = Hasher.HashingAlgorithm.CRC32;

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show(Languages.Translate(11010), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show(Languages.Translate(11011), Languages.Translate(10025), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CollisionDetectionFormat collisionDetectionFormat = CollisionDetectionFormat.STRING;
            if (radioButtonHex.Checked) collisionDetectionFormat = CollisionDetectionFormat.HEX;
            else if (radioButtonBinary.Checked) collisionDetectionFormat = CollisionDetectionFormat.BIN;
            CheckCollision(hashingAlgorithm, textBox1.Text, textBox2.Text, collisionDetectionFormat);
        }

        private void hashSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            hashingAlgorithm = (Hasher.HashingAlgorithm)hashSelector.SelectedIndex;
        }

        private void CheckCollisionForm_Load(object sender, EventArgs e)
        {
            this.Name = Languages.Translate(705);
            hashSelector.SelectedIndex = hashSelector.Items.Count - 1; //show CRC32 the last one
            FormManagement.SetUpFormTheme(this);
            #region Languages
            groupBox1.Text = Languages.Translate(201);
            radioButtonString.Text = Languages.Translate(202);
            radioButtonHex.Text = Languages.Translate(203);
            radioButtonBinary.Text = Languages.Translate(204);
            labelText.Text = Languages.Translate(205) + "1";
            labelText2.Text = Languages.Translate(205) + "2";
            buttonCheck.Text = Languages.Translate(206);
            buttonTakeTXT.Text = Languages.Translate(113);
            #endregion
        }

        private void CheckCollision(Hasher.HashingAlgorithm hashAlgorithm, string text01, string text02, CollisionDetectionFormat format)
        {
            Hasher hasher = new Hasher();
            string hash01 = "", hash02 = "";
            if (format == CollisionDetectionFormat.HEX)
            {
                string temp = ConvertHexToString(text01);
                hash01 = hasher.Hash(temp, hashAlgorithm);
                string temp2 = ConvertHexToString(text02);
                hash02 = hasher.Hash(temp2, hashAlgorithm);
            }
            else if (format == CollisionDetectionFormat.BIN)
            {
                byte[] temp = ConvertBinToByte(text01);
                hash01 = hasher.Hash(temp, hashAlgorithm);
                byte[] temp2 = ConvertBinToByte(text02);
                hash02 = hasher.Hash(temp2, hashAlgorithm);
            }
            else //string
            {
                hash01 = hasher.Hash(text01, hashAlgorithm);
                hash02 = hasher.Hash(text02, hashAlgorithm);
            }
            if (hash01 == hash02)
            {
                string s = Languages.Translate(124) + Environment.NewLine +
                    Languages.Translate(205) + "01: " + text01.Substring(0, Math.Min(text01.Length, 256)) + Environment.NewLine +
                    Languages.Translate(205) + "02: " + text02.Substring(0, Math.Min(text02.Length, 256)) + Environment.NewLine +
                    Languages.Translate(125) + ": " + hash01;
                MessageBox.Show(s, Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string s = Languages.Translate(126) + Environment.NewLine +
                    Languages.Translate(9999) + "01: " + hash01 + Environment.NewLine +
                    Languages.Translate(9999) + "02: " + hash02;
                MessageBox.Show(s, Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region Convertors
        private string ConvertHexToString(string hex)
        {
            hex = hex.ToLower().Replace("-", "").Replace(" ", ""); // Clean up the hex string

            if (hex.Length % 2 != 0)
                hex += "0"; // If odd length, append a '0' to make it even

            try
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < hex.Length; i += 2)
                {
                    string hexPair = hex.Substring(i, 2);
                    byte byteValue = Convert.ToByte(hexPair, 16); // Convert the hex pair to a byte
                    result.Append((char)byteValue); // Append the corresponding character
                }
                return result.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting hex to string: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty; // Return empty string in case of error
            }
        }

        private byte[] ConvertBinToByte(string binary)
        {
            binary = binary.Replace(" ", "").Replace("-", "");
            try
            {
                int remainder = binary.Length % 8;
                if (remainder != 0) binary = binary.PadLeft(binary.Length + (8 - remainder), '0'); //make sure its byte friendly
                byte[] bytes = new byte[binary.Length / 8];
                for (int i = 0; i < binary.Length; i += 8)
                {
                    bytes[i / 8] = Convert.ToByte(binary.Substring(i, 8), 2);
                }
                return bytes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Languages.Translate(11012) + Environment.NewLine + ex.Message, Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new byte[0];
            }
        }


        #endregion

        private void buttonTakeTXT_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog soubor = new OpenFileDialog())
            {
                soubor.DefaultExt = ".txt";
                soubor.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                soubor.InitialDirectory = Settings.DirectoryPathToCollisions;
                if (soubor.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader reader = new StreamReader(soubor.FileName))
                    {
                        Hasher.HashingAlgorithm algorithmTemp = Hasher.HashingAlgorithm.CRC32;
                        CollisionDetectionFormat format = CollisionDetectionFormat.STRING;
                        string textCollision01 = "", textCollision02 = "";
                        bool gotInformation = false;
                        while (!reader.EndOfStream && !gotInformation)
                        {
                            string line = reader.ReadLine();
                            if (!line.StartsWith("//") && !String.IsNullOrEmpty(line))
                            {
                                if (line.StartsWith("Algorithm="))
                                {
                                    string nextLine = line.Remove(0, 10);
                                    Console.WriteLine(nextLine);
                                    switch (nextLine)
                                    {
                                        case "MD5": algorithmTemp = Hasher.HashingAlgorithm.MD5; break;
                                        case "SHA1": algorithmTemp = Hasher.HashingAlgorithm.SHA1; break;
                                        case "SHA256": algorithmTemp = Hasher.HashingAlgorithm.SHA256; break;
                                        case "SHA512": algorithmTemp = Hasher.HashingAlgorithm.SHA512; break;
                                        case "RIPEMD160": algorithmTemp = Hasher.HashingAlgorithm.RIPEMD160; break;
                                        case "CRC32": algorithmTemp = Hasher.HashingAlgorithm.CRC32; break;
                                        default: algorithmTemp = Hasher.HashingAlgorithm.CRC32; break;
                                    }
                                }
                                switch (line)
                                {
                                    case "<STRING>":
                                        {
                                            format = CollisionDetectionFormat.STRING;
                                            textCollision01 = reader.ReadLine();
                                            textCollision02 = reader.ReadLine();
                                            gotInformation = true;
                                            break;
                                        }
                                    case "<BIN>":
                                        {
                                            format = CollisionDetectionFormat.BIN;
                                            textCollision01 = reader.ReadLine();
                                            textCollision02 = reader.ReadLine();
                                            gotInformation = true;
                                            break;
                                        }
                                    case "<HEX>":
                                        {
                                            format = CollisionDetectionFormat.HEX;
                                            textCollision01 = reader.ReadLine();
                                            textCollision02 = reader.ReadLine();
                                            gotInformation = true;
                                            break;
                                        }
                                    default: break;
                                }
                            }
                        }
                        if (gotInformation && !String.IsNullOrEmpty(textCollision01) && !String.IsNullOrEmpty(textCollision02)) CheckCollision(algorithmTemp, textCollision01, textCollision02, format);
                        else MessageBox.Show(Languages.Translate(10022), Languages.Translate(10021), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

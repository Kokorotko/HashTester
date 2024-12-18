using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.SqlServer.Server;
using System.IO.Hashing;
using System.Reflection.Emit;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Windows.Forms;
using System.Security.Policy;

namespace HashTester
{
    public class Hasher
    {
        private string currentSalt;
        private string currentPepper;
        public string CurrentSalt 
        { 
            get { return currentSalt; }
            set { currentSalt = value; }
        }
        public string CurrentPepper
        {
            get { return currentPepper; }
            set { currentPepper = value; }
        }
        public Hasher() { }
        public enum HashingAlgorithm
        {
            MD5,
            SHA1,
            SHA256,
            SHA512,
            RIPEMD160,
            CRC32
        }
        #region Gradual Hashing
        /// <summary>
        /// Returns Arrray of Strings that are gradually hashed with the desired algorithm
        /// </summary>
        /// <param name="text"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public string[] GradualHashing(string text, HashingAlgorithm algorithm)
        {
            string[] gradualHashing = new string[text.Length];
            string textCurrentlyHashing = "";
            for (int i = 0; i < text.Length; i++)
            {
                textCurrentlyHashing += text[i].ToString();
                gradualHashing[i] = Hash(textCurrentlyHashing, algorithm);
            }
            return gradualHashing;
        }
        /// <summary>
        /// Returns Arrray of Strings that are gradually hashed with the desired algorithm and Pepper
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pepper">Returns randomly generated pepper</param>
        /// <param name="pepperAppendLeft"></param>
        /// <param name="pepperLenght"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public string[] GradualHashingSaltPepper(string text, bool useSalt, bool usePepper, string salt, string pepper, HashingAlgorithm algorithm)
        {            
            string[] gradualHashing = new string[text.Length];
            string textCurrentlyHashing = "";
            //SaltPepper Logic
            if (useSalt)
            {
                if (String.IsNullOrEmpty(salt)) text = salt + text;
                else MessageBox.Show("ERROR: GradualHashingSaltPepper - Salt not inicialized");
            }
            if (usePepper)
            {
                if (String.IsNullOrEmpty(pepper)) text += pepper;
                else MessageBox.Show("ERROR: GradualHashingSaltPepper - Pepper not inicialized");
            }
            //Hashing
            for (int i = 0; i < text.Length; i++)
            {
                textCurrentlyHashing += text[i].ToString();
                gradualHashing[i] = Hash(textCurrentlyHashing, algorithm);
            }
            return gradualHashing;
        }

        #endregion
        #region Base Hashing
        /////////////////////////////////////******BASE HASHING******/////////////////////////////////////
        /// <summary>
        /// Takes a string and an algorithm and creates a hash
        /// </summary>
        /// <param name="text"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        public string Hash(string text, HashingAlgorithm algorithm)
        {
            switch (algorithm)
            {
                case HashingAlgorithm.MD5: return HashMD5(text);
                case HashingAlgorithm.SHA1: return HashSHA1(text);
                case HashingAlgorithm.SHA256: return HashSHA256(text);
                case HashingAlgorithm.SHA512: return HashSHA512(text);
                case HashingAlgorithm.RIPEMD160: return HashRIPEMD160(text);
                case HashingAlgorithm.CRC32: return HashCRC32(text);
                default: return "error";
            }
        }
        /// <summary>
        /// Creates a hash based algorithm with salt and pepper
        /// </summary>
        /// <returns></returns>
        public string HashSaltPepper(string text, bool useSalt, bool usePepper, string salt, string pepper, HashingAlgorithm algorithm)
        {
            if (useSalt)
            {
                if (!String.IsNullOrEmpty(salt)) text = salt + text;
                else Console.WriteLine("ERROR: HashSaltPepper - Salt not inicialized");
            }
            if (usePepper)
            {
                if (!String.IsNullOrEmpty(pepper)) text += pepper;
                else Console.WriteLine("ERROR: HashSaltPepper - Pepper not inicialized");
            }
            switch (algorithm)
            {
                case HashingAlgorithm.MD5: return HashMD5(text);
                case HashingAlgorithm.SHA1: return HashSHA1(text);
                case HashingAlgorithm.SHA256: return HashSHA256(text);
                case HashingAlgorithm.SHA512: return HashSHA512(text);
                case HashingAlgorithm.RIPEMD160: return HashRIPEMD160(text);
                case HashingAlgorithm.CRC32: return HashCRC32(text);
                default: return "error";
            }
        }
        #endregion
        #region Hashing Algorithm
        string HashMD5(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant(); //returns as AA-BB-CC we need aabbcc
            }
        }

        string HashSHA1(string text)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        string HashSHA256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        string HashSHA512(string text)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] hashBytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        string HashRIPEMD160(string text)
        {
            using (RIPEMD160 ripemd160 = RIPEMD160.Create())
            {
                byte[] hashBytes = ripemd160.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        string HashCRC32(string text)
        {
            uint[] crc32Table = new uint[256]; //Velikost (CRC32 == 32 bytů)
            const uint polynomial = 0xedb88320; //Standardní CRC32 věc, která říká jak CRC32 funguje

            for (uint i = 0; i < 256; i++)
            {
                uint crc = i;
                for (uint j = 8; j > 0; j--)
                {
                    if ((crc & 1) == 1) // & ==> bit AND
                    {
                        crc = (crc >> 1) ^ polynomial; //^ ==> bit XOR
                    }
                    else
                    {
                        crc >>= 1;
                    }
                }
                crc32Table[i] = crc;
            }

            //Samotná kalkulace CRC32
            uint crcValue = 0xffffffff;
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(text);

            foreach (byte b in inputBytes)
            {
                byte tableIndex = (byte)((crcValue & 0xff) ^ b); //0xff ==> Hexadecimal number (16x1)
                crcValue = (crcValue >> 8) ^ crc32Table[tableIndex]; //>> ==> bit shift to the right
            }

            crcValue = ~crcValue; //~ ==> bit NOT
            return crcValue.ToString("x8"); //Converts to lowercase hexadecimal string
        }


        public string GenerateSalt(int length)
        {            
            byte[] salt = new byte[length];  //1 byte is converted to 2 hexadecimal char
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) { rng.GetBytes(salt); }
            return (BitConverter.ToString(salt).Replace("-", "").ToLowerInvariant()).Substring(0,length); //Returns only half of the string
        }
        public string GeneratePepper(int length)
        {
            byte[] salt = new byte[length]; //1 byte is converted to 2 hexadecimal char
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) { rng.GetBytes(salt); }
            return (BitConverter.ToString(salt).Replace("-", "").ToLowerInvariant()).Substring(0, length); //Returns only half of the string
        }
        #endregion
        #region SaltAndPepperLogic
        public void SaveSalt(string hashID, string salt)
        {
            string path = "..\\..\\HashData\\" + hashID + ".txt"; 
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("hashID:" + hashID);
                if (salt != "") writer.WriteLine("salt=" + salt);
            }
        }

        public void LoadSalt(string hashID, out string salt)
        {
            salt = null;
            string path = "..\\..\\HashData\\" + hashID + ".txt";
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] splitLine = line.Split('=');
                    if (splitLine[0] == "salt") salt = splitLine[1];
                }
            }
        }

        public bool IsUsingSaltAndPepper(out bool isSaltUsed, out bool isPepperUsed, out string salt, out string pepper)
        {
            salt = "";
            pepper = "";
            isSaltUsed = false;
            isPepperUsed = false;
            if (Settings.UseSalt || Settings.UsePepper)
            {
                using (SaltAndPepperQuestion saltAndPepperQuestion = new SaltAndPepperQuestion())
                {
                    // Show dialog and handle result
                    if (saltAndPepperQuestion.ShowDialog() == DialogResult.OK)
                    {
                        saltAndPepperQuestion.GetSaltPepperInformation(
                            out bool generateSalt,
                            out int saltLength,
                            out string ownSalt,
                            out bool generatePepper,
                            out int pepperLength,
                            out string ownPepper,
                            out string hashID
                        );
                        //Salt
                        if (generateSalt)
                        {
                            salt = GenerateSalt(saltLength);
                            isSaltUsed = true;
                            Console.WriteLine("IsUsingSaltAndPepper SALT: " + salt);
                            SaveSalt(hashID, salt);
                        }
                        else if (!string.IsNullOrEmpty(ownSalt))
                        {
                            salt = ownSalt;
                            isSaltUsed = true;
                        }

                        //Pepper
                        if (generatePepper)
                        {
                            pepper = GeneratePepper(pepperLength);
                            isPepperUsed = true;
                            Console.WriteLine("IsUsingSaltAndPepper PEPPER: " + pepper);
                        }
                        else if (!string.IsNullOrEmpty(ownPepper))
                        {
                            pepper = ownPepper;
                            isPepperUsed = true;
                        }
                        return isSaltUsed || isPepperUsed;
                    }
                    return false; //Dialog Canceled
                }
            }
            return false;
        }
        #endregion
    }
}

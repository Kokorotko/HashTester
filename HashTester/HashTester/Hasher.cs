using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.SqlServer.Server;
using System.IO.Hashing;

namespace HashTester
{
    public class Hasher
    {
        public Hasher() { } //Kvůli UnitTest
        public enum HashingAlgorithm
        {
            MD5,
            SHA1,
            SHA256,
            SHA512,
            RIPEMD160,
            CRC32
        }
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
        /// Creates a hash based on the algorithm with randomly generated salt
        /// </summary>
        /// <param name="salt">puts out the randomly generated salt</param>
        /// <param name="appendLeft">True appends left, false appends right</param>
        /// <returns></returns>
        public string HashSalt(string text, out string salt, bool appendLeft, int saltLenght , HashingAlgorithm algorithm)
        {
            salt = GenerateSalt(saltLenght);
            if (appendLeft) text = salt + text;
            else text = text + salt;
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
        /// Creates a hash based algorithm with pre-determined salt
        /// </summary>
        /// <param name="appendLeft">True appends left, false appends right</param>
        /// <returns></returns>
        public string HashSalt(string text, string salt, bool appendLeft, HashingAlgorithm algorithm)
        {
            if (appendLeft) text = salt + text;
            else text = text + salt;
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
        /// Creates a hash based algorithm with pre-determined pepper (always append right)
        /// </summary>
        /// <returns></returns>
        public string HashPepper(string text, string pepper, HashingAlgorithm algorithm)
        {
            text += pepper;
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
        /// /// Creates a hash based algorithm with generated pepper (always append right)
        /// </summary>
        /// <param name="pepperLenght"></param>
        /// <returns></returns>
        public string HashPepper(string text, int pepperLenght, HashingAlgorithm algorithm)
        {
            string pepper = GeneratePepper(pepperLenght);
            text += pepper;
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
        /// Creates a hash based algorithm with pre-determined salt and  pepper
        /// </summary>
        /// <returns></returns>
        public string HashSaltPepper(string text, string salt, bool saltAppendLeft, string pepper, HashingAlgorithm algorithm)
        {
            if (saltAppendLeft) text = salt + text;
            else text = text + salt;
            text += pepper;
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
        /// Creates a hash based algorithm with generated salt and pepper
        /// </summary>
        /// <returns></returns>
        public string HashSaltPepper(string text, out string salt , int saltLenght, bool saltAppendLeft,  out string pepper, int pepperLenght, HashingAlgorithm algorithm)
        {
            salt = GenerateSalt(saltLenght);
            pepper = GeneratePepper(pepperLenght);
            if (saltAppendLeft) text = salt + text;
            else text = text + salt;
            text += pepper;
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
        /// Creates a hash based algorithm with generated salt and pre-determined pepper
        /// </summary>
        /// <returns></returns>
        public string HashSaltPepper(string text, out string salt, int saltLenght, bool saltAppendLeft, string pepper, HashingAlgorithm algorithm)
        {
            salt = GenerateSalt(saltLenght);
            if (saltAppendLeft) text = salt + text;
            else text = text + salt;
            text += pepper;
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
        /// Creates a hash based algorithm with pre-determined salt and generated pepper
        /// </summary>
        /// <returns></returns>
        public string HashSaltPepper(string text, string salt, bool saltAppendLeft, int pepperLenght, HashingAlgorithm algorithm)
        {
            string pepper = GeneratePepper(pepperLenght);
            if (saltAppendLeft) text = salt + text;
            else text = text + salt;
            text += pepper;
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

        string HashMD5(string text)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant(); //returns as AÄ-BB-CC we need aabbcc
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

        public string HashCRC32(string text)
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


        string GenerateSalt(int length)
        {
            byte[] salt = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) { rng.GetBytes(salt); }
            return BitConverter.ToString(salt).Replace("-", "").ToLowerInvariant();
        }

        string GeneratePepper(int length)
        {
            byte[] salt = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) { rng.GetBytes(salt); }
            return BitConverter.ToString(salt).Replace("-", "").ToLowerInvariant();
        }
    }
}

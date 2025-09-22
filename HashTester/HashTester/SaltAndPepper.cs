using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    public class SaltAndPepper
    {


        /// <summary>
        /// Checks if nameTable.txt exists in the right folder
        /// </summary>
        /// <param name="showMessageBoxOutput"></param>
        /// <returns></returns>
        public bool CheckIfPasswordTesterExists(bool showMessageBoxOutput)
        {
            if (!File.Exists(Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt")))
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt")))
                {
                    writer.WriteLine("//name==hashID==algorithm==passwordHash");
                }
                if (showMessageBoxOutput) MessageBox.Show("Could not find nameTable.txt in HashData/PasswordTester. File has been re-generated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }



        /// <summary>
        /// Generates the fucking .txt file
        /// </summary>
        public void GenerateNameTableFile()
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(Settings.DirectoryToPasswordTester, "nameTable.txt")))
            {
                writer.WriteLine("//name==hashID==algorithm==passwordHash");
            }
        }
    }
}

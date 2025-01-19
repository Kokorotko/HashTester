using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    static class FormManagement
    {

        #region Enum
        public enum FolderType
        {
            Base,
            Password,
            Collision,
            Log
        }
        #endregion
        public static void SaveLog(ListBox listbox, Form form)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Settings.LogSavePathToFiles;
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine("Log saved on: " + DateTime.Today + DateTime.Now);
                    Console.WriteLine("Log saved on: " + DateTime.Today + DateTime.Now);
                    writer.WriteLine("Log saved from: " + form.Name);
                    Console.WriteLine("Log saved from: " + form.Name);
                    foreach (string item in listbox.Items)
                    {
                        writer.WriteLine(item);
                    }
                }
                MessageBox.Show("Log save succesfulled", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("Log save abbandoned", "Abandonned", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ChangeDirectory(FolderType folderType)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a folder";
                folderBrowserDialog.ShowNewFolderButton = true;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    switch (folderType)
                    {
                        case FolderType.Base:
                            Settings.BasePathToFiles = folderBrowserDialog.SelectedPath;
                            break;
                        case FolderType.Password:
                            Settings.PasswordPathToFiles = folderBrowserDialog.SelectedPath;
                            break;
                        case FolderType.Collision:
                            Settings.CollisionPathToFiles = folderBrowserDialog.SelectedPath;
                            break;
                        case FolderType.Log:
                            Settings.LogSavePathToFiles = folderBrowserDialog.SelectedPath;
                            break;
                    }
                    Settings.SaveSettings();
                    MessageBox.Show("Path changed.");
                }
            }
        }
    }
}

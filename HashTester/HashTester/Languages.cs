using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace HashTester
{
    public static class Languages
    {
        private static Dictionary<int, string> dictionary = null;
        private static string currentlyUsedLanguage = "English";

        public static string Translate(int id)
        {
            if (dictionary == null && !LoadDictionary("English")) return "error";
            if (dictionary != null && dictionary.ContainsKey(id))
            {
                return dictionary[id];
            }
            else
            {
                Console.WriteLine("Missing Translation: " + id);
                return "Translation Missing for " + id;
            }
        }

        public static string CurrentlyUsedLanguage
        {
            get { return currentlyUsedLanguage; }
        }

        public static bool LoadDictionary(string nameOfLanguage)
        {
            try
            {
                string pathToFile = GetPath(nameOfLanguage);
                Console.WriteLine("Dictionary path to files: " + pathToFile);
                if (string.IsNullOrEmpty(pathToFile) || !File.Exists(pathToFile))
                {
                    Console.WriteLine("Missing Translation for: " + nameOfLanguage);
                    MessageBox.Show("Missing Translation for: " + nameOfLanguage + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                dictionary = new Dictionary<int, string>();
                currentlyUsedLanguage = nameOfLanguage;

                using (FileStream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("//") && line.Contains("=="))
                        {
                            string[] split = line.Split(new string[] { "==" }, StringSplitOptions.None);
                            if (split.Length == 2 && int.TryParse(split[0], out int id))
                            {
                                dictionary[id] = split[1];
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Missing Translation for: " + nameOfLanguage);
                MessageBox.Show("Missing Translation for: " + nameOfLanguage + "." + Environment.NewLine + ex.Message, Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string[] AllLanguages()
        {
            List<string> list = new List<string>();
            string[] temp = Directory.GetFiles(Settings.DirectoryToLanguages);
            foreach (string s in temp)
            {
                if (!Path.GetFileName(s).StartsWith("_"))
                {
                    list.Add(Path.GetFileNameWithoutExtension(s));
                    //Console.WriteLine(s);
                }
            }
            return list.ToArray();
        }

        private static string GetPath(string name)
        {
            string languagesPath = Path.Combine(Settings.DirectoryExeBase, "Languages");
            if (!Directory.Exists(languagesPath)) return null;
            string[] temp = Directory.GetFiles(languagesPath);
            if (string.IsNullOrWhiteSpace(name)) return null;
            string[] possibleNames = new string[]
            {
                name + ".txt",              // Original
                name.ToLower() + ".txt",    // all lower
                name.ToUpper() + ".txt",    // ALL UPPER
                char.ToUpper(name[0]) + name.Substring(1).ToLower() + ".txt" // First letter uppercase
            };
            foreach (string file in temp)
            {
                foreach(string variant in possibleNames) if (Path.GetFileName(file) == variant) return Path.GetFullPath(file);
            }
            return null;
        }
    }
}

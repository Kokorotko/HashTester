using System;
using System.IO;
using System.Windows.Forms;

namespace HashTester
{
    public static class Settings
    {
        //private
        #region Private
        private static bool outputStyleIncludeOriginalString;
        private static bool outputStyleIncludeSaltPepper;
        private static bool outputStyleIncludeNumberOfHash;
        private static bool outputStyleIncludeHashAlgorithm;
        private static VisualModeEnum visualMode = VisualModeEnum.System;
        private static OutputTypeEnum outputType = OutputTypeEnum.MessageBox;
        private static bool includeSalt;
        private static bool includePepper;
        private static int updateUIms;
        private static int threadsUsagePercentage;
        private static string selectedLanguage;
        #endregion

        #region Get&Set
        public static bool OutputStyleIncludeOriginalString
        {
            get { return outputStyleIncludeOriginalString; }
            set { outputStyleIncludeOriginalString = value; }
        }
        public static bool OutputStyleIncludeNumberOfHash
        {
            get { return outputStyleIncludeNumberOfHash; }
            set { outputStyleIncludeNumberOfHash = value; }
        }
        public static bool OutputStyleIncludeHashAlgorithm
        {
            get { return outputStyleIncludeHashAlgorithm; }
            set { outputStyleIncludeHashAlgorithm = value; }
        }
        public static bool OutputStyleIncludeSaltPepper
        {
            get { return outputStyleIncludeSaltPepper; }
            set { outputStyleIncludeSaltPepper = value; }
        }

        public static string SelectedLanguage
        {
            get
            {
                if (!String.IsNullOrEmpty(selectedLanguage)) return selectedLanguage;
                else return "English";
            }
            set
            {
                if (!String.IsNullOrEmpty(value)) selectedLanguage = value;
                else selectedLanguage = "English";
            }
        }
        public static VisualModeEnum VisualMode
        {
            get { return visualMode; }
            set { visualMode = value; }
        }
        public static OutputTypeEnum OutputType
        {
            get { return outputType; }
            set { outputType = value; }
        }

        public static int ThreadsUsagePercentage
        {
            get { return threadsUsagePercentage; }
            set
            {
                if (value <= 1) threadsUsagePercentage = 1;
                else if (value > 100) threadsUsagePercentage = 100;
                else threadsUsagePercentage = value;
            }
        }

        public static bool UseSalt
        {
            get { return includeSalt; }
            set { includeSalt = value; }
        }
        public static bool UsePepper
        {
            get { return includePepper; }
            set { includePepper = value; }
        }
        public static int UpdateUIms
        {
            get
            {
                if (updateUIms < 1 || updateUIms > 1000) return 32; //around 30fps
                return updateUIms;
            }
            set
            {
                if (value > 7)
                {
                    if (value > 1000) updateUIms = 1000;
                    else updateUIms = value;
                }
                else updateUIms = 32; //around 30fps
            }
        }
        public static string DirectoryExeBase
        {
            get
            {
                string path = Path.GetDirectoryName(Application.ExecutablePath);
                if (!Directory.Exists(path)) throw new Exception("Unable to get application executable path");
                return path;
            }
        }

        public static string DirectoryPathToSettings
        {
            get
            {
                string path = Path.Combine(DirectoryExeBase, "Settings/");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                return path;
            }
        }

        public static string DirectoryPathToWordlists
        {
            get
            {
                string path = Path.Combine(DirectoryExeBase, "Wordlists/");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                return path;
            }
        }

        public static string DirectoryPathToCollisions
        {
            get
            {
                string path = Path.Combine(DirectoryExeBase, "Collisions/");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                return path;
            }
        }

        public static string DirectoryPathToLogs
        {
            get
            {
                string path = Path.Combine(DirectoryExeBase, "Logs/");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                return path;
            }
        }

        public static string DirectoryToHashData
        {
            get
            {
                string path = Path.Combine(DirectoryExeBase, "HashData/");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                return path;
            }
        }
        public static string DirectoryToPasswordTester
        {
            get
            {
                string path = Path.Combine(DirectoryExeBase, "HashData/PasswordTester/");
                if (!Directory.Exists(path)) Directory.CreateDirectory(path);
                return path;
            }
        }

        #endregion

        #region Enum
        public enum VisualModeEnum
        {
            System,
            Light,
            Dark
        }
        public enum OutputTypeEnum
        {
            MessageBox,
            Listbox,
            TXTFile
        }
        #endregion       
        public static void ResetSettings()
        {
            VisualMode = VisualModeEnum.System;
            OutputType = OutputTypeEnum.Listbox;
            OutputStyleIncludeHashAlgorithm = false;
            OutputStyleIncludeNumberOfHash = false;
            OutputStyleIncludeOriginalString = false;
            OutputStyleIncludeSaltPepper = false;
            UseSalt = false;
            UsePepper = false;
            SaveSettings();
        }
        
        public static void SaveSettings()
        {
            //Create File
            string settingsPathToFileTemp = Path.Combine(DirectoryPathToSettings, "temp.txt");
            Console.WriteLine("Temp Path: " + settingsPathToFileTemp);
            string settingsPathToFileSettings = Path.Combine(DirectoryPathToSettings, "settings.txt");
            Console.WriteLine("Settings Path: " + settingsPathToFileSettings);
            //Create Directory if it doesnt exist
            string settingsDirectory = Path.GetDirectoryName(settingsPathToFileTemp);
            if (!Directory.Exists(settingsDirectory))
            {
                throw new Exception("Directory doesnt exist");
            }
            using (FileStream fileSettings = new FileStream(settingsPathToFileTemp, FileMode.CreateNew, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileSettings))
                {
                    writer.WriteLine("//" + Languages.Translate(589));
                    writer.WriteLine("//" + Languages.Translate(590));
                    writer.WriteLine("//" + Languages.Translate(591));
                    writer.WriteLine("//" + Languages.Translate(592));
                    switch (VisualMode)
                    {
                        case VisualModeEnum.System: writer.WriteLine("visualMode=0"); break;
                        case VisualModeEnum.Light: writer.WriteLine("visualMode=1"); break;
                        case VisualModeEnum.Dark: writer.WriteLine("visualMode=2"); break;
                    }
                    writer.WriteLine("//" + Languages.Translate(593));
                    writer.WriteLine("//" + Languages.Translate(594));
                    writer.WriteLine("UIupdateInMS=" + UpdateUIms);
                    writer.WriteLine("//" + Languages.Translate(595));
                    writer.WriteLine("//" + Languages.Translate(596));
                    writer.WriteLine("threadsUsagePercentage=" + threadsUsagePercentage);
                    writer.WriteLine("//" + Languages.Translate(597));
                    writer.WriteLine("language=" + SelectedLanguage);
                    writer.WriteLine("//" + Languages.Translate(598));
                    switch (OutputType)
                    {
                        case OutputTypeEnum.MessageBox: writer.WriteLine("outputType=0"); break;
                        case OutputTypeEnum.Listbox: writer.WriteLine("outputType=1"); break;
                        case OutputTypeEnum.TXTFile: writer.WriteLine("outputType=2"); break;
                    }
                    writer.WriteLine("//" + Languages.Translate(599));
                    if (OutputStyleIncludeOriginalString) writer.WriteLine("outputStyle_IncludeOriginalString=1");
                    else writer.WriteLine("outputStyle_IncludeOriginalString=0");
                    if (OutputStyleIncludeHashAlgorithm) writer.WriteLine("outputStyle_IncludeHash=1");
                    else writer.WriteLine("outputStyle_IncludeHash=0");
                    if (OutputStyleIncludeNumberOfHash) writer.WriteLine("outputStyle_IncludeNumber=1");
                    else writer.WriteLine("outputStyle_IncludeNumber=0");
                    if (OutputStyleIncludeSaltPepper) writer.WriteLine("outputStyle_IncludeSaltPepper=1");
                    else writer.WriteLine("outputStyle_IncludeSaltPepper=0");
                    writer.WriteLine("//" + Languages.Translate(600));
                    if (UseSalt) writer.WriteLine("useSalt=1");
                    else writer.WriteLine("useSalt=0");
                    if (UsePepper) writer.WriteLine("usePepper=1");
                    else writer.WriteLine("usePepper=0");
                    writer.WriteLine("//" + Languages.Translate(601));
                    writer.WriteLine("basePathToFiles=" + DirectoryExeBase);
                    writer.WriteLine("settingsPathToFiles=" + DirectoryPathToSettings);
                    writer.WriteLine("passwordPathToFiles=" + DirectoryPathToWordlists);
                    writer.WriteLine("collisionPathToFiles=" + DirectoryPathToCollisions);
                    writer.WriteLine("logSavePathToFiles=" + DirectoryPathToLogs);
                }

            }

            if (!File.Exists(settingsPathToFileSettings))
            {
                File.Delete(settingsPathToFileSettings);
            }
            File.Delete(settingsPathToFileSettings);
            File.Move(settingsPathToFileTemp, settingsPathToFileSettings);
        }
        public static void LoadSettings()
        {
            string settingsPathToFileSettings = Path.Combine(DirectoryPathToSettings, "settings.txt");
            if (File.Exists(settingsPathToFileSettings))
            {
                using (FileStream fileSettings = new FileStream(settingsPathToFileSettings, FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader reader = new StreamReader(fileSettings))
                    {
                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            char[] splitChar = { '=' };
                            string[] data = line.Split(splitChar, StringSplitOptions.RemoveEmptyEntries); //visualMode=2
                            if (data[0].Substring(0, 2) != "//") //Comments in Settings
                            {
                                switch (data[0])
                                {
                                    case "visualMode":
                                        {
                                            try
                                            {
                                                if (data[1] == "0") VisualMode = VisualModeEnum.System;
                                                else if (data[1] == "1") VisualMode = VisualModeEnum.Light;
                                                else VisualMode = VisualModeEnum.Dark;
                                            }
                                            catch (Exception)
                                            {
                                                VisualMode = VisualModeEnum.System;
                                            }
                                            break;
                                        }
                                    case "outputType":
                                        {
                                            try
                                            {
                                                if (data[1] == "0") OutputType = OutputTypeEnum.MessageBox;
                                                else if (data[1] == "1") OutputType = OutputTypeEnum.Listbox;
                                                else if (data[1] == "2") OutputType = OutputTypeEnum.TXTFile;
                                                else OutputType = OutputTypeEnum.MessageBox;
                                            }
                                            catch (Exception)
                                            {
                                                OutputType = OutputTypeEnum.MessageBox;
                                            }
                                            break;
                                        }
                                    case "outputStyle_IncludeOriginalString":
                                        {
                                            try
                                            {
                                                OutputStyleIncludeOriginalString = (data[1] == "1");
                                            }
                                            catch (Exception)
                                            {
                                                OutputStyleIncludeOriginalString = false;
                                            }
                                            break;
                                        }
                                    case "outputStyle_IncludeHash":
                                        {
                                            try
                                            {
                                                OutputStyleIncludeHashAlgorithm = (data[1] == "1");
                                            }
                                            catch (Exception)
                                            {
                                                OutputStyleIncludeHashAlgorithm = false;
                                            }
                                            break;
                                        }
                                    case "outputStyle_IncludeNumber":
                                        {
                                            try
                                            {
                                                OutputStyleIncludeNumberOfHash = (data[1] == "1");
                                            }
                                            catch (Exception)
                                            {
                                                OutputStyleIncludeNumberOfHash = false;
                                            }
                                            break;
                                        }
                                    case "outputStyle_IncludeSaltPepper":
                                        {
                                            try
                                            {
                                                OutputStyleIncludeSaltPepper = (data[1] == "1");
                                            }
                                            catch (Exception)
                                            {
                                                OutputStyleIncludeSaltPepper = false;
                                            }
                                            break;
                                        }
                                    case "useSalt":
                                        {
                                            try
                                            {
                                                UseSalt = (data[1] == "1");
                                            }
                                            catch (Exception)
                                            {
                                                UseSalt = false;
                                            }
                                            break;
                                        }
                                    case "usePepper":
                                        {
                                            try
                                            {
                                                UsePepper = (data[1] == "1");
                                            }
                                            catch (Exception)
                                            {
                                                UsePepper = false;
                                            }
                                            break;
                                        }
                                    case "UIupdateInMS":
                                        {
                                            try
                                            {
                                                UpdateUIms = int.Parse(data[1]);
                                            }
                                            catch (Exception)
                                            {
                                                UpdateUIms = 0;
                                            }
                                            break;
                                        }
                                    case "threadsUsagePercentage":
                                        {
                                            try
                                            {
                                                ThreadsUsagePercentage = int.Parse(data[1]);
                                            }
                                            catch (Exception)
                                            {
                                                ThreadsUsagePercentage = 50;
                                            }
                                            break;
                                        }
                                    case "language":
                                        {
                                            try
                                            {
                                                SelectedLanguage = data[1];
                                            }
                                            catch (Exception)
                                            {
                                                SelectedLanguage = "";
                                            }
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Settings.ResetSettings();
                Console.WriteLine("Could not find settings.txt in settings.cs and method LoadSettings");
            }
        }
    }
}

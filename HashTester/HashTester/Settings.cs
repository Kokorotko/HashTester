using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static HashTester.Settings;

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
        private static string basePathToFiles;
        private static string passwordPathToFiles;
        private static string collisionPathToFiles;
        private static string logSavePathToFiles;
        private static string settingsPathToFiles;
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
        public static string BasePathToFiles
        {
            get
            {
                if (!string.IsNullOrEmpty(basePathToFiles) && Directory.Exists(basePathToFiles))
                {
                    return basePathToFiles;
                }
                else
                {
                    string defaultPath = Path.GetDirectoryName(Application.UserAppDataPath);
                    if (!Directory.Exists(defaultPath))
                    {
                        Directory.CreateDirectory(defaultPath);
                    }
                    return defaultPath;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Directory.Exists(value))
                    {
                        Directory.CreateDirectory(value);
                    }
                    basePathToFiles = value;
                }
                else
                {
                    string defaultPath = Path.GetDirectoryName(Application.UserAppDataPath);
                    if (!Directory.Exists(defaultPath))
                    {
                        Directory.CreateDirectory(defaultPath);
                    }
                    basePathToFiles = defaultPath;
                }
            }
        }
        public static string SettingsPathToFiles
        {
            get
            {
                if (!string.IsNullOrEmpty(settingsPathToFiles) && Directory.Exists(settingsPathToFiles))
                {
                    return settingsPathToFiles;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "Settings"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return path;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Directory.Exists(value))
                    {
                        Directory.CreateDirectory(value);
                    }
                    settingsPathToFiles = value;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "Settings"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    settingsPathToFiles = path;
                }
            }
        }
        public static string PasswordPathToFiles
        {
            get
            {
                if (!string.IsNullOrEmpty(passwordPathToFiles) && Directory.Exists(passwordPathToFiles))
                {
                    return passwordPathToFiles;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "Wordlists"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return path;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Directory.Exists(value))
                    {
                        Directory.CreateDirectory(value);
                    }
                    passwordPathToFiles = value;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "Wordlists"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    passwordPathToFiles = path;
                }
            }
        }
        public static string CollisionPathToFiles
        {
            get
            {
                if (!string.IsNullOrEmpty(collisionPathToFiles) && Directory.Exists(collisionPathToFiles))
                {
                    return collisionPathToFiles;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "SameHashingResults"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return path;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Directory.Exists(value))
                    {
                        Directory.CreateDirectory(value);
                    }
                    collisionPathToFiles = value;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "SameHashingResults"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    collisionPathToFiles = path;
                }
            }
        }
        public static string LogSavePathToFiles
        {
            get
            {
                if (!string.IsNullOrEmpty(logSavePathToFiles) && Directory.Exists(logSavePathToFiles))
                {
                    return logSavePathToFiles;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "Logs"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    return path;
                }
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (!Directory.Exists(value))
                    {
                        Directory.CreateDirectory(value);
                    }
                    logSavePathToFiles = value;
                }
                else
                {
                    string path = Path.GetFullPath(Path.Combine(BasePathToFiles, "Logs"));
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    logSavePathToFiles = path;
                }
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
            OutputType = OutputTypeEnum.MessageBox;
            OutputStyleIncludeHashAlgorithm = false;
            OutputStyleIncludeOriginalString = false;
            OutputStyleIncludeSaltPepper = false;
            UseSalt = false;
            UsePepper = false;
            BasePathToFiles = null;
            PasswordPathToFiles = null;
            CollisionPathToFiles = null;
            LogSavePathToFiles = null;
            SaveSettings();
        }
        public static void SaveSettings()
        {
            //Create File
            string settingsPathToFileTemp = Path.Combine(SettingsPathToFiles, "temp.txt");
            Console.WriteLine("Temp Path: " + settingsPathToFileTemp);
            string settingsPathToFileSettings = Path.Combine(SettingsPathToFiles, "settings.txt");
            Console.WriteLine("Settings Path: " + settingsPathToFileSettings);
            //Create Directory if it doesnt exist
            string settingsDirectory = Path.GetDirectoryName(settingsPathToFileTemp);
            if (!Directory.Exists(settingsDirectory))
            {
                Directory.CreateDirectory(settingsDirectory);
            }
            using (FileStream fileSettings = new FileStream(settingsPathToFileTemp, FileMode.CreateNew, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileSettings))
                {
                    //VisualStyle                    
                    writer.WriteLine("//Warning! If theres nothing after the = it will set the setting into default");
                    writer.WriteLine("//Bool means 0 <<false>> and 1 <<true>>; Everything other takes special input");
                    writer.WriteLine("//I have included comments on what value is allowed.");
                    writer.WriteLine("//VisualMode from 0 to 2");
                    switch (VisualMode)
                    {
                        case VisualModeEnum.System: writer.WriteLine("visualMode=0"); break;
                        case VisualModeEnum.Light: writer.WriteLine("visualMode=1"); break;
                        case VisualModeEnum.Dark: writer.WriteLine("visualMode=2"); break;
                    }
                    //OutputType
                    writer.WriteLine("//OutputType from 0 to 2");
                    switch (OutputType)
                    {
                        case OutputTypeEnum.MessageBox: writer.WriteLine("outputType=0"); break;
                        case OutputTypeEnum.Listbox: writer.WriteLine("outputType=1"); break;
                        case OutputTypeEnum.TXTFile: writer.WriteLine("outputType=2"); break;
                    }
                    //OutputStyle
                    writer.WriteLine("//All OutputStyles are bool");
                    if (OutputStyleIncludeOriginalString) writer.WriteLine("outputStyle_IncludeOriginalString=1");
                    else writer.WriteLine("outputStyle_IncludeOriginalString=0");
                    if (OutputStyleIncludeHashAlgorithm) writer.WriteLine("outputStyle_IncludeHash=1");    
                    else writer.WriteLine("outputStyle_IncludeHash=0");
                    if (OutputStyleIncludeNumberOfHash) writer.WriteLine("outputStyle_IncludeNumber=1");
                    else writer.WriteLine("outputStyle_IncludeNumber=0");
                    if (OutputStyleIncludeSaltPepper) writer.WriteLine("outputStyle_IncludeSaltPepper=1");
                    else writer.WriteLine("outputStyle_IncludeSaltPepper=0");
                    //Salt And Pepper
                    writer.WriteLine("//Salt and Pepper bool");
                    if (UseSalt) writer.WriteLine("useSalt=1");
                    else writer.WriteLine("useSalt=0");
                    if (UsePepper) writer.WriteLine("usePepper=1");
                    else writer.WriteLine("usePepper=0");
                    //Other
                    writer.WriteLine("//Other - Path");
                    writer.WriteLine("basePathToFiles=" + BasePathToFiles);
                    writer.WriteLine("settingsPathToFiles=" + SettingsPathToFiles);
                    writer.WriteLine("passwordPathToFiles=" + PasswordPathToFiles);
                    writer.WriteLine("collisionPathToFiles=" + CollisionPathToFiles);
                    writer.WriteLine("logSavePathToFiles=" + LogSavePathToFiles);
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
            string settingsPathToFileSettings = Path.Combine(SettingsPathToFiles, "settings.txt");
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
                                            catch (IndexOutOfRangeException)
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
                                            catch (IndexOutOfRangeException)
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
                                            catch (IndexOutOfRangeException)
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
                                            catch (IndexOutOfRangeException)
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
                                            catch (IndexOutOfRangeException)
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
                                            catch (IndexOutOfRangeException)
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
                                            catch (IndexOutOfRangeException)
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
                                            catch (IndexOutOfRangeException)
                                            {
                                                UsePepper = false;
                                            }
                                            break;
                                        }
                                    case "basePathToFiles":
                                        {
                                            try
                                            {
                                                BasePathToFiles = data[1];
                                            }
                                            catch (IndexOutOfRangeException)
                                            {
                                                BasePathToFiles = "";
                                            }
                                            break;
                                        }
                                    case "passwordPathToFiles":
                                        {
                                            try
                                            {
                                                PasswordPathToFiles = data[1];
                                            }
                                            catch (IndexOutOfRangeException)
                                            {
                                                PasswordPathToFiles = "";
                                            }
                                            break;
                                        }
                                    case "collisionPathToFiles":
                                        {
                                            try
                                            {
                                                CollisionPathToFiles = data[1];
                                            }
                                            catch (IndexOutOfRangeException)
                                            {
                                                CollisionPathToFiles = "";
                                            }
                                            break;
                                        }
                                    case "logSavePathToFiles":
                                        {
                                            try
                                            {
                                                LogSavePathToFiles = data[1];
                                            }
                                            catch (IndexOutOfRangeException)
                                            {
                                                LogSavePathToFiles = "";
                                            }
                                            break;
                                        }
                                    case "settingsPathToFiles":
                                        {
                                            try
                                            {
                                                SettingsPathToFiles = data[1];
                                            }
                                            catch (IndexOutOfRangeException)
                                            {
                                                SettingsPathToFiles = "";
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

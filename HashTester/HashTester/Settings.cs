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
                if (!String.IsNullOrEmpty(basePathToFiles)) return basePathToFiles;
                else return Environment.CurrentDirectory; //Better Safe than Sure (or something like that)
            }
            set { basePathToFiles = value; }
        }
        public static string PasswordPathToFiles
        {
            get
            {
                if (!String.IsNullOrEmpty(passwordPathToFiles))
                {
                    return passwordPathToFiles;
                }
                else return Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\Wordlists")); //Base directory
            }
            set
            {
                if (!String.IsNullOrEmpty(passwordPathToFiles)) passwordPathToFiles = value;
                else passwordPathToFiles = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\..\\Wordlists")); //base directory
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
            basePathToFiles = "";
        }
        public static void SaveSettings()
        {
            //Create File
            using (FileStream fileSettings = new FileStream("..\\..\\settings\\temp.txt", FileMode.Create, FileAccess.Write))
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
                    writer.WriteLine("passwordPathToFiles=" + PasswordPathToFiles);
                }
            }
            File.Delete("..\\..\\settings\\settings.txt");
            File.Move("..\\..\\settings\\temp.txt", "..\\..\\settings\\settings.txt");
        }
        public static void LoadSettings()
        {
            if (File.Exists("..\\..\\settings\\settings.txt"))
            {
                using (FileStream fileSettings = new FileStream("..\\..\\settings\\settings.txt", FileMode.Open, FileAccess.Read))
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
        }
        public static string TemporaryOutput()
        {
            return "OutputStyleIncludeOriginalString: " + OutputStyleIncludeOriginalString + "\n" +
                   "OutputStyleIncludeSaltPepper: " + OutputStyleIncludeSaltPepper + "\n" +
                   "OutputStyleIncludeNumberOfHash: " + OutputStyleIncludeNumberOfHash + "\n" +
                   "OutputStyleIncludeHashAlgorithm: " + OutputStyleIncludeHashAlgorithm + "\n" +
                   "VisualMode: " + VisualMode.ToString() + "\n" +
                   "OutputType: " + OutputType.ToString() + "\n" +
                   "UseSalt: " + UseSalt + "\n" +
                   "UsePepper: " + UsePepper + "\n" +
                   "BasePathToFiles: " + basePathToFiles;
        }

    }
}

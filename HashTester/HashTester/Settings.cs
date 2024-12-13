using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
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
        }
        public static void SaveSettings()
        {
            //Create File
            using (FileStream fileSettings = new FileStream("..\\..\\settings\\temp.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileSettings))
                {
                    //VisualStyle
                    writer.WriteLine("//I have included comments on what value is allowed, if it is not, default value will be set instead. I tried to make this as idiot proof as possible :)");
                    writer.WriteLine("//Bool means 0 <<false>> and 1 <<true>>; Everything other takes special input");
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
                    //
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
                                            if (data[1] == "0") VisualMode = VisualModeEnum.System;
                                            else if (data[1] == "1") VisualMode = VisualModeEnum.Light;
                                            else VisualMode = VisualModeEnum.Dark;
                                            break;
                                        }
                                    case "outputType":
                                        {
                                            if (data[1] == "0") OutputType = OutputTypeEnum.MessageBox;
                                            else if (data[1] == "1") OutputType = OutputTypeEnum.Listbox;
                                            else if (data[1] == "2") OutputType = OutputTypeEnum.TXTFile;
                                            else OutputType = OutputTypeEnum.MessageBox; //if failed
                                            break;
                                        }
                                    case "outputStyle_IncludeOriginalString":
                                    {                                            
                                            if (data[1] == "1") OutputStyleIncludeOriginalString = true;
                                            else OutputStyleIncludeOriginalString = false;
                                            break;
                                    }
                                    case "outputStyle_IncludeHash":
                                        {
                                            if (data[1] == "1") OutputStyleIncludeHashAlgorithm = true;
                                            else OutputStyleIncludeHashAlgorithm = false;
                                            break;
                                        }
                                    case "outputStyle_IncludeNumber":
                                        {
                                            if (data[1] == "1") OutputStyleIncludeNumberOfHash = true;
                                            else OutputStyleIncludeNumberOfHash = false;
                                            break;
                                        }
                                    case "outputStyle_IncludeSaltPepper":
                                        {
                                            if (data[1] == "1") OutputStyleIncludeSaltPepper = true;
                                            else OutputStyleIncludeSaltPepper = false;
                                            break;
                                        }
                                    case "useSalt":
                                        {
                                            if (data[1] == "1") UseSalt = true;
                                            else UseSalt = false;
                                            break;
                                        }
                                    case "usePepper":
                                        {
                                            if (data[1] == "1") UsePepper = true;
                                            else UsePepper = false;
                                            break;
                                        }
                                    default: { break; }
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
                   "UsePepper: " + UsePepper;
        }

    }
}

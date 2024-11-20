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
    internal class Settings
    {
        //private
        #region Private
        private bool outputStyleIncludeOriginalString;
        private bool outputStyleIncludeNumberOfHash;
        private bool outputStyleIncludeHashAlgorithm;
        private VisualModeEnum visualMode = VisualModeEnum.System;
        private OutputTypeEnum outputType = OutputTypeEnum.MessageBox;
        private bool includeSalt;
        private bool includePepper;
        #endregion
        #region Get&Set
        public bool OutputStyleIncludeOriginalString { get; set; }
        public bool OutputStyleIncludeNumberOfHash { get; set; }
        public bool OutputStyleIncludeHashAlgorithm { get; set; }
        public VisualModeEnum VisualMode { get; set; } = VisualModeEnum.System;
        public OutputTypeEnum OutputType { get; set; } = OutputTypeEnum.MessageBox;
        public bool IncludeSalt { get; set; }
        public bool IncludePepper { get; set; }
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
        public void ResetSettings()
        {
            VisualMode = VisualModeEnum.System;
            OutputType = OutputTypeEnum.MessageBox;
            OutputStyleIncludeHashAlgorithm = false;
            OutputStyleIncludeOriginalString = false;
            OutputStyleIncludeOriginalString = false;
            IncludeSalt = false;
            IncludePepper = false;
        }
        public void SaveSettings()
        {
            //Create File
            using (FileStream fileSettings = new FileStream("..\\..\\settings\\temp.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileSettings))
                {
                    //VisualStyle
                    writer.WriteLine("//I have included comments on what value is allowed, if it is not, default value will be set instead. I tried to make this as idiot proof as possible :)");
                    writer.WriteLine("Bool means 0 <<false>> and 1 <<true>>; Everything other takes special input");
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
                    //Salt And Pepper
                    writer.WriteLine("//Salt and Pepper bool");
                    if (IncludeSalt) writer.WriteLine("includeSalt=1");
                    else writer.WriteLine("includeSalt=0");
                    if (IncludePepper) writer.WriteLine("includePepper=1");
                    else writer.WriteLine("includePepper=0");
                    //
                }
            }
            File.Delete("..\\..\\settings\\settings.txt");
            File.Move("..\\..\\settings\\temp.txt", "..\\..\\settings\\settings.txt");
        }
        public void LoadSettings()
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
                            string[] data = line.Split('='); //visualMode=2
                            if (data[0].Substring(0, 2) != "//") //Comments in Settings
                            {
                                switch (data[0])
                                {
                                    case "visualMode":
                                        {
                                            int temp = int.Parse(data[1]);
                                            if (temp == 0) VisualMode = VisualModeEnum.System;
                                            else if (temp == 1) VisualMode = VisualModeEnum.Light;
                                            else VisualMode = VisualModeEnum.Dark;
                                            break;
                                        }
                                    case "outputType":
                                        {
                                            int temp = int.Parse(data[1]);
                                            if (temp == 0) OutputType = OutputTypeEnum.MessageBox;
                                            else if (temp == 1) OutputType = OutputTypeEnum.Listbox;
                                            else if (temp == 2) OutputType = OutputTypeEnum.TXTFile;
                                            else OutputType = OutputTypeEnum.MessageBox; //if failed
                                            break;
                                        }
                                    case "outputStyle_IncludeOriginalString":
                                    {
                                            int temp = int.Parse(data[1]);
                                            if (temp == 1) OutputStyleIncludeOriginalString = true;
                                            else OutputStyleIncludeOriginalString = false;
                                            break;
                                    }
                                    case "outputStyle_IncludeHash":
                                        {
                                            int temp = int.Parse(data[1]);
                                            if (temp == 1) OutputStyleIncludeHashAlgorithm = true;
                                            else OutputStyleIncludeHashAlgorithm = false;
                                            break;
                                        }
                                    case "outputStyle_IncludeNumber":
                                        {
                                            int temp = int.Parse(data[1]);
                                            if (temp == 1) OutputStyleIncludeNumberOfHash = true;
                                            else OutputStyleIncludeNumberOfHash = false;
                                            break;
                                        }
                                    case "includeSalt":
                                        {
                                            int temp = int.Parse(data[1]);
                                            if (temp == 1) IncludeSalt = true;
                                            else IncludeSalt = false;
                                            break;
                                        }
                                    case "includePepper":
                                        {
                                            int temp = int.Parse(data[1]);
                                            if (temp == 1) IncludePepper = true;
                                            else IncludePepper = false;
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
        #region FormMain
        #endregion
    }
}

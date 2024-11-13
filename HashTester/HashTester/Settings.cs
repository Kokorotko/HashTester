using HashTester.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTester
{
    internal class Settings
    {
        FormSettings formSettings;
        public enum VisualMode
        {
            System,
            Light,
            Dark
        }
        private VisualMode visualMode = VisualMode.System;
        public int GetVisualMode() { return (int)visualMode; } //returns index
        
        public void ResetSettings()
        {
            
        }

        public void SaveSettings(FormSettings formSettings)
        {
            //Create File
            using (FileStream fileSettings = new FileStream("..\\..\\settings\\temp.txt", FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(fileSettings))
                {
                    //VisualStyle
                    if (formSettings.radioButtonVisualMode0.Checked) writer.WriteLine("visualMode=0");
                    else if (formSettings.radioButtonVisualMode1.Checked) writer.WriteLine("visualMode=1");
                    else writer.WriteLine("visualMode=2");
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
                            switch (data[0])
                            {
                                case "visualMode":
                                    {
                                        int temp = int.Parse(data[1]);
                                        if (temp == 0) visualMode = VisualMode.System;
                                        else if (temp == 1) visualMode = VisualMode.Light;
                                        else visualMode = VisualMode.Dark;
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
}

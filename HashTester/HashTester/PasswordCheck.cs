using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace HashTester
{
    public class PasswordCheck
    {
        //private
        private List<string> logOutput = new List<string>();
        private bool[] foundMatch;
        private long[] lineFoundMatch;
        private long linesInTXT = 0;
        private long currentLine = 0;
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        Stopwatch stopwatch = new Stopwatch();

        //Get and Set

        public bool UserAbandoned
        {
            get { return cancellationTokenSource.Token.IsCancellationRequested; }
        }
        public bool[] FoundMatch
        {
            get
            {
                return foundMatch;
            }
        }

        public long[] LineFoundMatch
        {
            get
            {
                return lineFoundMatch;
            }
        }

        public List<string> LogOutput
        {
            get
            {
                return logOutput;
            }
        }

        public Stopwatch Stopwatch
        {
            get
            {
                return stopwatch;
            }
        }

        public long LinesInTXT
        {
            get { return linesInTXT; }
            private set { linesInTXT = value; }
        }

        public int Progress
        {
            get
            {
                if (LinesInTXT == 0) return 0;
                int temp = (int)((double)CurrentLine / LinesInTXT * 100);
                if (temp > 100) return 100;
                else if (temp < 0) return 0;
                else return temp;
            }
        }


        public long CurrentLine
        {
            get { return currentLine; }
            private set { currentLine = value; }
        }

        private void ResetValue()
        {
            logOutput.Clear();
            stopwatch.Reset();
            LinesInTXT = 0;
            CurrentLine = 0;
            cancellationTokenSource = new CancellationTokenSource();
        }
        public void PasswordFinder(string fullPathToTXT, string[] passwords)
        {
            ResetValue();
            using (StreamReader reader = new StreamReader(fullPathToTXT))
            {
                stopwatch.Start();
                LinesInTXT = CountNumberOfLinesInFile(fullPathToTXT);
                //Set Up
                foundMatch = new bool[passwords.Count()];
                lineFoundMatch = new long[passwords.Count()];
                for (int i = 0; i < passwords.Count(); i++)
                {
                    FoundMatch[i] = false;
                    lineFoundMatch[i] = -1;
                }
                while (!reader.EndOfStream && !UserAbandoned)
                {
                    CurrentLine++;
                    string line = reader.ReadLine();                    
                    for (int i = 0; i < passwords.Count(); i++)
                    {
                        if (!FoundMatch[i])
                        {
                            if (passwords[i] == line)
                            {                                
                                lineFoundMatch[i] = CurrentLine;
                                foundMatch[i] = true;
                                logOutput.Add(Languages.Translate(573) + " '" + passwords[i] + "' " + Languages.Translate(574) + ": " + CurrentLine);
                                if (Array.TrueForAll(FoundMatch, value => value)) //If every bool in array is true ==> found all passwords
                                {
                                    return;
                                }

                            }
                        }
                    }
                }
                stopwatch.Stop();
            }
        }

        public long CountNumberOfLinesInFile(string filePath) //Use In Every Fucking Possible Instance
        {
            long numberOfLines = 0;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    numberOfLines++;
                    reader.ReadLine();
                }
            }
            return numberOfLines;
        }

        public void Abort()
        {
            cancellationTokenSource.Cancel();
        }
    }
}

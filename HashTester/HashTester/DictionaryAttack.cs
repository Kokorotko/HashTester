using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;

namespace HashTester
{
    public class DictionaryAttack
    {
        //private
        private List<string> logOutput = new List<string>();
        private bool[] foundMatch;
        private long[] lineFoundMatch;
        private long linesInTXT = 0;
        private long currentLine = 0;
        private string[] foundPassword;
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

        public string[] FoundPassword
        {
            get
            {
                return foundPassword;
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
                int temp = (int)(CurrentLine / (double)LinesInTXT * 100);
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

        private void ResetVar(int index)
        {
            foundMatch = new bool[index];
            lineFoundMatch = new long[index];
            foundPassword = new string[index];
            for (int i = 0; i < index; i++)
            {
                foundPassword[i] = "";
                FoundMatch[i] = false;
                lineFoundMatch[i] = -1;
            }
        }

        /// <summary>
        /// Similar to PasswordFinder, but finds using a hash
        /// </summary>
        /// <param name="fullPathToTXT"></param>
        /// <param name="hashes"></param>
        public void MultiplePasswordBreaker(string fullPathToTXT, string[] hashes, Hasher.HashingAlgorithm hashingAlgorithm)
        {
            ResetValue();
            using (StreamReader reader = new StreamReader(fullPathToTXT))
            {
                try
                {                   
                    Hasher hasher = new Hasher();
                    LinesInTXT = CountNumberOfLinesInFile(fullPathToTXT);
                    stopwatch.Start();
                    //Set Up
                    ResetVar(hashes.Count());
                    while (!reader.EndOfStream && !UserAbandoned)
                    {
                        CurrentLine++;
                        string line = reader.ReadLine();
                        string tempHash = hasher.Hash(line, hashingAlgorithm);
                        for (int i = 0; i < hashes.Count(); i++)
                        {
                            if (!FoundMatch[i])
                            {
                                if (hashes[i] == tempHash)
                                {
                                    lineFoundMatch[i] = CurrentLine;
                                    foundMatch[i] = true;
                                    foundPassword[i] = "'" + line + "' (" + tempHash + ")";
                                    logOutput.Add(Languages.Translate(573) + " " + FoundPassword[i] +  " " + Languages.Translate(574) + ": " + CurrentLine);
                                    if (Array.TrueForAll(FoundMatch, value => value)) //If every bool in array is true ==> found all passwords
                                    {
                                        stopwatch.Stop();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    stopwatch.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Languages.Translate(11000) + Environment.NewLine + ex.Message, Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stopwatch.Stop();
                    return;
                }
            }
        }

        /// <summary>
        /// Finds password from a .txt file, supports multiple inputs at the same time
        /// </summary>
        /// <param name="fullPathToTXT"></param>
        /// <param name="passwords"></param>
        public void MultiplePasswordFinder(string fullPathToTXT, string[] passwords)
        {
            ResetValue();
            using (StreamReader reader = new StreamReader(fullPathToTXT))
            {
                try
                {
                    ResetVar(passwords.Count());
                    stopwatch.Start();
                    LinesInTXT = CountNumberOfLinesInFile(fullPathToTXT);
                    while (!reader.EndOfStream && !UserAbandoned)
                    {
                        CurrentLine++;
                        string line = reader.ReadLine();
                        for (int i = 0; i < passwords.Count(); i++)
                        {
                            if (!FoundMatch[i]) //optimalization
                            {
                                if (passwords[i] == line)
                                {
                                    lineFoundMatch[i] = CurrentLine;
                                    foundMatch[i] = true;
                                    foundPassword[i] = line;
                                    logOutput.Add(Languages.Translate(573) + " " + FoundPassword[i] + " " + Languages.Translate(574) + ": " + CurrentLine);
                                    if (Array.TrueForAll(FoundMatch, value => value)) //If every bool in array is true ==> found all passwords
                                    {
                                        stopwatch.Stop();
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    stopwatch.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Languages.Translate(11000) + Environment.NewLine + ex.Message, Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stopwatch.Stop();
                    return;
                }
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

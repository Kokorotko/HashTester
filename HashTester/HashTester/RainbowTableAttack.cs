using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HashTester
{
    public class RainbowTableAttack
    {
        //private
        private ConcurrentBag<string> logOutput = new ConcurrentBag<string>();
        private long linesProcessed = 0;
        private long totalLinesInFile = 0;
        private long attempts = 0;
        private Stopwatch stopwatch = new Stopwatch();
        private bool ranOutOfAttempts =  false;
        private bool ranOutOfTime = false;

        #region GetAndSet
        public CancellationTokenSource CancellationTokenSource { get; private set; }
        public bool UseStopTimer { get; set; }
        public long TotalLinesInFile
        {
            get { return totalLinesInFile; }
            private set { totalLinesInFile = value; }
        }
        public ConcurrentBag<string> LogOutput => logOutput;
        public string FoundPassword { get; private set; } = "";
        public long FoundPasswordAtLine { get; private set; } = -1;
        public long LinesProcessed
        {
            get { return Interlocked.Read(ref linesProcessed); }
        }
        public Stopwatch Stopwatch
        {
            get { return stopwatch; }
        }
        public bool RanOutOfAttempts
        {
            get { return ranOutOfAttempts; }
            private set { ranOutOfAttempts = value; }
        }
        public bool RanOutOfTime
        {
            get { return ranOutOfTime; }
            private set { ranOutOfTime = value; }
        }

        public long Attempts
        {
            get { return attempts; }
            private set { attempts = value; }
        }

        public bool FoundPasswordBool { get; private set; }

        #endregion

        public void Abort() => CancellationTokenSource.Cancel();

        private Task<bool> SingleThreadRainbowTableAttack( //returns if the operation was a success, use FoundPasswordBool to know if it has been found
            string userInputHash,
            Hasher.HashingAlgorithm fileAlgorithm,
            Hasher.HashingAlgorithm desiredAlgorithm,
            string fileName,
            bool inputFileIsInPlainText,
            CancellationTokenSource token,
            long timeToStopAttack,
            long maxAttempts)
        {
            try
            {
                FoundPassword = "";
                FoundPasswordBool = false;
                FoundPasswordAtLine = -1;
                bool foundMatch = false;
                bool useTimeToStop = true;
                bool useMaxAttempts = true;
                if (timeToStopAttack <= 0) useTimeToStop = false;
                if (maxAttempts <= 0) useMaxAttempts = false;

                linesProcessed = 0;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        Attempts++;
                        if (token.IsCancellationRequested) break;
                        if (useTimeToStop && Stopwatch.ElapsedMilliseconds / 1000 > timeToStopAttack)
                        {
                            ranOutOfTime = true;
                            break;
                        }
                        if (useMaxAttempts && Attempts > maxAttempts)
                        {
                            RanOutOfAttempts = true;
                            break;
                        }
                        string fullLine = reader.ReadLine();
                        foundMatch = ProcessLine(fullLine, userInputHash, desiredAlgorithm, inputFileIsInPlainText, ref linesProcessed);

                        if (foundMatch)
                        {
                            Console.WriteLine("Found Match");
                            FoundPasswordBool = true;
                            FoundPassword = inputFileIsInPlainText ? fullLine : fullLine.Split('=')[0];
                            FoundPasswordAtLine = linesProcessed - 1; //-1 because the first one is algorithm
                            break;
                        }
                    }
                }
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Rainbow Table Attack Single Thread error: " + ex.Message);
                return Task.FromResult(false);
            }
        }

        private bool ProcessLine(
            string line,
            string userInputHash,
            Hasher.HashingAlgorithm desiredAlgorithm,
            bool inputFileIsInPlainText,
            ref long linesProcessed)
        {
            if (string.IsNullOrWhiteSpace(line)) return false;
            string hashedLine = inputFileIsInPlainText ? line : line.Split('=')[1];
            Interlocked.Increment(ref linesProcessed);
            //Console.WriteLine(hashedLine +  " == " +  userInputHash);
            return hashedLine == userInputHash;
        }        

        private void GetFileAlgorithm(
            string line,
            out bool inputFileIsInPlainText,
            out bool continueTheAttack,
            out Hasher.HashingAlgorithm fileAlgorithm)
        {
            fileAlgorithm = Hasher.HashingAlgorithm.CRC32;
            inputFileIsInPlainText = false;
            try
            {
                inputFileIsInPlainText = !line.Contains("==");
                continueTheAttack = true;
                if (!inputFileIsInPlainText)
                {
                    LogOutput.Add(Languages.Translate(Languages.L.FileIsAlreadyARainbowTable));
                    string[] algorithmText = line.Split(new string[] { "==" }, StringSplitOptions.RemoveEmptyEntries);
                    if (algorithmText.Length < 2)
                    {
                        continueTheAttack = false;
                        return;
                    }
                    Enum.TryParse(algorithmText[1], out fileAlgorithm);
                    Console.WriteLine("Algorithm: " + fileAlgorithm);
                }
                else
                {
                    LogOutput.Add(Languages.Translate(Languages.L.FileIsNotARainbowTable));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Languages.Translate(Languages.L.AnErrorHasOccuredInTheProgram) + Environment.NewLine + ex.Message, Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                continueTheAttack = false;
                return;
            }
        }

        private async Task<(bool Success, string[] TempFilesPath)> SplitFile(string fileName, string userAlgorithm, CancellationTokenSource token)
        {
            long totalLinesInFile = File.ReadLines(fileName).LongCount();
            long linesPerThread = totalLinesInFile / FormManagement.NumberOfThreadsToUse();
            string[] tempFilesPath = new string[FormManagement.NumberOfThreadsToUse()];

            try
            {
                Console.WriteLine("Splitting file into multiple parts");

                for (int i = 0; i < FormManagement.NumberOfThreadsToUse(); i++)
                {
                    tempFilesPath[i] = Path.Combine(Path.GetDirectoryName(fileName), $"rainbowTableTemp-{userAlgorithm}-{i}.txt");
                }

                using (StreamReader readerInput = new StreamReader(fileName))
                {
                    StreamWriter[] writers = new StreamWriter[FormManagement.NumberOfThreadsToUse()];
                    try
                    {
                        for (int i = 0; i < FormManagement.NumberOfThreadsToUse(); i++)
                        {
                            writers[i] = new StreamWriter(tempFilesPath[i]);
                        }

                        long currentLine = 0;
                        string line;

                        while ((line = await readerInput.ReadLineAsync()) != null) // Asynchronní čtení řádku
                        {
                            if (token.IsCancellationRequested)
                            {
                                DeleteAllTempFiles(tempFilesPath);
                                return (false, tempFilesPath);
                            }

                            int threadIndex = (int)(currentLine / linesPerThread);
                            if (threadIndex >= FormManagement.NumberOfThreadsToUse()) threadIndex = FormManagement.NumberOfThreadsToUse() - 1;

                            await writers[threadIndex].WriteLineAsync(line); // Asynchronní zápis
                            currentLine++;
                        }
                    }
                    finally
                    {
                        foreach (StreamWriter writer in writers)
                        {
                            if (writer != null) writer.Close();
                        }
                    }
                }
                return (true, tempFilesPath);
            }
            catch (Exception ex)
            {
                DeleteAllTempFiles(tempFilesPath);
                Console.WriteLine("ERROR: while splitting file in rainbowTableAttack: " + ex.Message);
                return (false, tempFilesPath);
            }
        }


        private void DeleteAllTempFiles(string[] paths)
        {
            foreach (string path in paths)
            {
                DeleteTempFile(path);
            }
        }

        private void DeleteTempFile(string path)
        {
            if (File.Exists(path)) File.Delete(path);
        }

        private void ResetValues()
        {
            stopwatch = new Stopwatch();
            RanOutOfTime = false;
            RanOutOfAttempts = false;
            Attempts = 0;
            CancellationTokenSource = new CancellationTokenSource();
            logOutput = new ConcurrentBag<string>();
            FoundPassword = "";
            FoundPasswordAtLine = -1;
            FoundPasswordBool = false;
            linesProcessed = 0;
        }

        //Public
        public async Task<bool> PerformRainbowAttack(string fileName, string userInputHash, Hasher.HashingAlgorithm userAlgorithm, long timeToStopAttack, long maxAttempts)
        {
            try
            {
                ResetValues();
                stopwatch.Restart();
                CancellationTokenSource token = new CancellationTokenSource();
                //First Line
                string firstLine = "";
                long tempTotalLinesInFile = 0;
                using (StreamReader reader = new StreamReader(fileName))
                {
                    firstLine = reader.ReadLine(); // Reads only the first line
                    while (!reader.EndOfStream) //reads all lines
                    {
                        reader.ReadLine();
                        tempTotalLinesInFile++;
                    }
                }
                TotalLinesInFile = tempTotalLinesInFile;
                if (String.IsNullOrEmpty(firstLine)) return false;
                //Console.WriteLine("First line Detected");
                GetFileAlgorithm(firstLine, out bool inputFileIsInPlainText, out bool continueTheAttack, out Hasher.HashingAlgorithm fileAlgorithm);
                if (fileAlgorithm != userAlgorithm)
                {
                    WrongAlgorithms(fileAlgorithm.ToString(), userAlgorithm.ToString());
                    //Console.WriteLine("Wrong algorithm");
                    return false;
                }
                if (!continueTheAttack) return false;

                #region R.I.P. MultiThreading in Rainbow Table Attack (????–2025)
                //Here lies the great MultiThreading,
                //Slain by the merciless hand of "Just Make It Simpler".

                //He tried to divide and conquer,
                //Yet was conquered himself by "SingleThread Supremacy".

                //May his threads rest in pieces,
                //Forever lost in the void of "Not Worth It".

                //Gone but not forgotten—
                //Except in production, where he’s very much forgotten.

                //Press F to pay respects.
                //-ChatGPT on 25.03.2025 21:23:15
                #endregion

                Task task = Task.Run(async () =>
                {
                    if(!await SingleThreadRainbowTableAttack(userInputHash, fileAlgorithm, userAlgorithm, fileName, inputFileIsInPlainText, token, timeToStopAttack, maxAttempts))
                    {
                        token.Cancel();
                    }
                });
                await task;
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation token");
                    stopwatch.Stop();
                    return false;
                }
                //Console.WriteLine("All Tasks are done");
                stopwatch.Stop();
                return true;
            }
            catch (Exception ex)
            {                
                MessageBox.Show(Languages.Translate(Languages.L.AnErrorHasOccuredInTheProgram) + Environment.NewLine + ex.Message);
                return false;
            }
        }

        public void LogReset()
        {
            logOutput = new ConcurrentBag<string>();
        }

        public bool CancelTokenActive()
        {
            if (CancellationTokenSource.IsCancellationRequested) return true;
            else return false;
        }

        private void WrongAlgorithms(string fileAlgo, string userAlgo)
        {
            FoundPassword = "";
            FoundPasswordBool = false;
            FoundPasswordAtLine = -1;
            string s = Languages.Translate(Languages.L.FileIsHashedWith) + " " + fileAlgo + " " + Languages.Translate(Languages.L.ButTheUserWants) + " " + userAlgo + ". " + Languages.Translate(Languages.L.TheAlgorithmsNeedsToBeTheSameCancellingAttack);
            LogOutput.Add(s);
            MessageBox.Show(s, Languages.Translate(Languages.L.Abandoned), MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace HashTester
{
    internal class RainbowTableAttack
    {
        private readonly Hasher hasher = new Hasher();
        private ConcurrentBag<string> logOutput = new ConcurrentBag<string>();
        private long linesProcessed = 0;
        private long totalLinesInFile = 0;

        #region GetAndSet
        public CancellationTokenSource CancellationTokenSource { get; private set; }
        public bool UseStopTimer { get; set; }
        public long TotalLinesInFile => totalLinesInFile;
        public ConcurrentBag<string> LogOutput => logOutput;
        public string FoundPassword { get; private set; } = "";
        public long FoundPasswordAtLine { get; private set; } = -1;
        public bool PerformanceMode { get; set; }
        public long LinesProcessed
        {
            get { return Interlocked.Read(ref linesProcessed); }
        }
        #endregion

        public void Abort() => CancellationTokenSource.Cancel();

        private bool SingleThreadRainbowTableAttack(
            string userInputHash,
            Hasher.HashingAlgorithm fileAlgorithm,
            Hasher.HashingAlgorithm desiredAlgorithm,
            string fileName,
            bool inputFileIsInPlainText,
            CancellationToken cancellationToken,
            CancellationToken multiThreadToken)
        {
            FoundPassword = "";
            FoundPasswordAtLine = -1;
            bool foundMatch = false;
            linesProcessed = 0;
            using (StreamReader reader = new StreamReader(fileName))
            {
                while (!reader.EndOfStream)
                {
                    if (cancellationToken.IsCancellationRequested || multiThreadToken.IsCancellationRequested) break;

                    string fullLine = reader.ReadLine();
                    foundMatch = ProcessLine(fullLine, userInputHash, desiredAlgorithm, inputFileIsInPlainText, ref linesProcessed);

                    if (foundMatch)
                    {
                        Console.WriteLine("Found Match");
                        FoundPassword = inputFileIsInPlainText ? fullLine : fullLine.Split('=')[0];
                        FoundPasswordAtLine = linesProcessed - 1; //-1 because the first one is algorithm
                        break;
                    }
                }
            }
            return !string.IsNullOrEmpty(FoundPassword);
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

        public bool PerformRainbowAttack(string fileName, string userInputHash, Hasher.HashingAlgorithm userAlgorithm)
        {
            ResetValues();
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = CancellationTokenSource.Token;
            CancellationTokenSource = new CancellationTokenSource();
            CancellationToken multiThreadToken = CancellationTokenSource.Token;

            string firstLine = File.ReadLines(fileName).FirstOrDefault();
            if (firstLine == null) return false;

            GetFileAlgorithm(firstLine, out bool inputFileIsInPlainText, out bool continueTheAttack, out Hasher.HashingAlgorithm fileAlgorithm);
            if (fileAlgorithm != userAlgorithm)
            {
                WrongAlgorithms(fileAlgorithm.ToString(), userAlgorithm.ToString());
                return false;
            }
            if (!continueTheAttack) return false;

            if (PerformanceMode)
            {
                Console.WriteLine("Performance Mode On");
                int numberOfThreadsUsed = Environment.ProcessorCount;
                //totalLinesInFile = We get this from splitting the file
                long linesPerThread = totalLinesInFile / numberOfThreadsUsed;
                List<Task> allTasks = new List<Task>();
                string[] tempFilesPath = new string[numberOfThreadsUsed];
                //Split The File
                if (SplitFile(fileName, userAlgorithm.ToString(), token, out tempFilesPath))
                {
                    token.ThrowIfCancellationRequested();
                    return false;                    
                }
                //MultiThread Start Attack
                for (int i = 0; i < numberOfThreadsUsed; i++)
                {
                    allTasks.Add(Task.Run(() =>
                    {
                        SingleThreadRainbowTableAttack(userInputHash, fileAlgorithm, userAlgorithm, tempFilesPath[i], inputFileIsInPlainText, token, multiThreadToken);
                    }, token));
                }
                Task.WaitAll(allTasks.ToArray());
                Console.WriteLine("All Tasks are done");
            }
            else
            {
                Console.WriteLine("Performance Mode Off");
                Task task = Task.Run(() =>
                {
                    SingleThreadRainbowTableAttack(userInputHash, fileAlgorithm, userAlgorithm, fileName, inputFileIsInPlainText, token, multiThreadToken);
                }, token);
                task.Wait();
                Console.WriteLine("All Tasks are done");
            }
            return true;
        }

        private void GetFileAlgorithm(
            string line,
            out bool inputFileIsInPlainText,
            out bool continueTheAttack,
            out Hasher.HashingAlgorithm fileAlgorithm)
        {
            inputFileIsInPlainText = !line.Contains("=");
            continueTheAttack = true;
            fileAlgorithm = Hasher.HashingAlgorithm.CRC32;

            if (!inputFileIsInPlainText)
            {
                LogOutput.Add("File is already pre-hashed.");
                string[] algorithmText = line.Split('=');
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
                LogOutput.Add("File is not pre-hashed.");
            }
        }

        private void ResetValues()
        {
            CancellationTokenSource = new CancellationTokenSource();
            logOutput = new ConcurrentBag<string>();
            FoundPassword = "";
            FoundPasswordAtLine = -1;
            PerformanceMode = false;
            linesProcessed = 0;
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
            FoundPasswordAtLine = -1;
            LogOutput.Add("File is hashed with " + fileAlgo + " but the user wants " + userAlgo + ". The algorithms needs to be the same. Cancelling attack...");
        }

        private bool SplitFile(string fileName, string userAlgorithm, CancellationToken token, out string[] tempFilesPath)
        {
            Console.WriteLine("Splitting file into multiple parts...");

            // Count total lines in file
            long totalLinesInFile = File.ReadLines(fileName).LongCount();
            int numberOfThreadsUsed = Environment.ProcessorCount;
            long linesPerThread = totalLinesInFile / numberOfThreadsUsed;

            // Create output file paths
            tempFilesPath = new string[numberOfThreadsUsed];
            for (int i = 0; i < numberOfThreadsUsed; i++)
            {
                tempFilesPath[i] = Path.Combine(Directory.GetDirectoryRoot(fileName),
                    $"rainbowTableTemp-{userAlgorithm}-{i}.txt");
            }

            using (StreamReader readerInput = new StreamReader(fileName))
            {
                StreamWriter[] writers = new StreamWriter[numberOfThreadsUsed];

                try
                {
                    // Open all writer files
                    for (int i = 0; i < numberOfThreadsUsed; i++)
                    {
                        writers[i] = new StreamWriter(tempFilesPath[i]);
                    }

                    long currentLine = 0;
                    string line;

                    // Read the file and distribute lines across multiple files
                    while ((line = readerInput.ReadLine()) != null)
                    {
                        if (token.IsCancellationRequested)
                        {
                            return false; // Stop if canceled
                        }

                        int threadIndex = (int)(currentLine / linesPerThread);
                        if (threadIndex >= numberOfThreadsUsed)
                        {
                            threadIndex = numberOfThreadsUsed - 1; // Last file gets all remaining lines
                        }

                        writers[threadIndex].WriteLine(line);
                        currentLine++;
                    }
                }
                finally
                {
                    // Close all writers
                    for (int i = 0; i < numberOfThreadsUsed; i++)
                    {
                        if (writers[i] != null)
                        {
                            writers[i].Close();
                        }
                    }
                }
            }
            return true;
        }


    }
}

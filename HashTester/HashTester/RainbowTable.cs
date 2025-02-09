using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HashTester
{
    internal class RainbowTable
    {
        //private
        private string logOutput = "";
        private long allLinesInInputFile = 0;
        private long linesProcessed = 0;

        //GET and SET
        public string LogOutput
        {
            get { return logOutput; }
            private set { logOutput = value; }
        }

        public long AllLinesInInputFile
        {
            get { return allLinesInInputFile; }
        }

        public long LinesProcessed
        {
            get { return linesProcessed; }
            private set { Interlocked.Increment(ref linesProcessed); }
        }

        public Stopwatch Stopwatch
        {
            get
            {
                return stopwatch;
            }
        }

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        Hasher hasher = new Hasher();
        Stopwatch stopwatch;
        public void Abort()
        {
            cancellationTokenSource.Cancel();
        }

        public bool GenerateRainbowTable(string fileInputPath, string fileOutputPath, Hasher.HashingAlgorithm hashingAlgorithm)
        {
            ResetValues();
            stopwatch = Stopwatch.StartNew();
            if (!File.Exists(fileInputPath)) { return false; }

            using (StreamReader reader = new StreamReader(fileInputPath))
            {
                allLinesInInputFile = File.ReadLines(fileInputPath).LongCount();
                using (StreamWriter writer = new StreamWriter(fileOutputPath))
                {
                    writer.WriteLine("algorithm==" + hashingAlgorithm.ToString());
                    while (!reader.EndOfStream)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested) return false; // Stop if canceled

                        LinesProcessed++;
                        string line = reader.ReadLine();
                        string hash = hasher.Hash(line, hashingAlgorithm);
                        writer.WriteLine(line + "=" + hash);
                    }
                }
            }

            LogOutput = "Rainbow Table of the file: " + fileInputPath + " with " + hashingAlgorithm.ToString() + " hashing algorithm is done.";
            stopwatch.Stop();
            return true;
        }

        public bool GenerateRainbowTableMultiThread(int numberOfThreadsUsed, string fileInputPath, string fileOutputPath, Hasher.HashingAlgorithm hashingAlgorithm)
        {
            ResetValues();
            stopwatch = Stopwatch.StartNew();
            if (!File.Exists(fileInputPath)) { return false; }
            allLinesInInputFile = File.ReadLines(fileInputPath).LongCount();
            string[] tempFilesInput = new string[numberOfThreadsUsed];
            string[] tempFilesOutput = new string[numberOfThreadsUsed];

            long numberOfCurrentLines = 0;

            // Split the file
            using (StreamReader readerInput = new StreamReader(fileInputPath))
            {
                for (int i = 0; i < numberOfThreadsUsed; i++)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested) return false; // Stop if canceled

                    tempFilesInput[i] = Path.Combine(Path.GetDirectoryName(fileOutputPath), "InputSplit-" + i + ".txt");
                    tempFilesOutput[i] = Path.Combine(Path.GetDirectoryName(fileOutputPath), "Temp-" + i + ".txt");
                    long numberOfLinesForThread = allLinesInInputFile / numberOfThreadsUsed;

                    using (StreamWriter writer = new StreamWriter(tempFilesInput[i]))
                    {
                        if (i != numberOfThreadsUsed - 1)
                        {
                            for (int j = 0; j < numberOfLinesForThread; j++)
                            {
                                if (cancellationTokenSource.Token.IsCancellationRequested) return false;
                                writer.WriteLine(readerInput.ReadLine());
                            }
                        }
                        else
                        {
                            while (!readerInput.EndOfStream)
                            {
                                if (cancellationTokenSource.Token.IsCancellationRequested) return false;
                                writer.WriteLine(readerInput.ReadLine());
                            }
                        }
                    }
                    numberOfCurrentLines += numberOfLinesForThread;
                }
            }

            // Process the file
            Parallel.ForEach(tempFilesInput, (inputFile, state, index) =>
            {
                if (cancellationTokenSource.Token.IsCancellationRequested) return;

                Console.WriteLine($"Thread {index} started running");
                GenerateRainbowTableMultiThreadForSingleThread(inputFile, tempFilesOutput[index], hashingAlgorithm);
            });

            if (cancellationTokenSource.Token.IsCancellationRequested) return false;

            // Combine the splits
            using (StreamWriter writer = new StreamWriter(fileOutputPath))
            {
                writer.WriteLine("algorithm==" + hashingAlgorithm.ToString());
                foreach (string fileOutput in tempFilesOutput)
                {
                    using (StreamReader reader = new StreamReader(fileOutput))
                    {
                        while (!reader.EndOfStream)
                        {
                            if (cancellationTokenSource.Token.IsCancellationRequested) return false;
                            writer.WriteLine(reader.ReadLine());
                        }
                    }
                    File.Delete(fileOutput);
                }
            }

            foreach (string tempFile in tempFilesInput)
            {
                File.Delete(tempFile);
            }

            LogOutput = "Rainbow Table of the file: " + fileInputPath + " with " + hashingAlgorithm.ToString() + " hashing algorithm is done.";
            stopwatch.Stop();
            return true;
        }

        private void GenerateRainbowTableMultiThreadForSingleThread(string fileInputPath, string fileOutputPath, Hasher.HashingAlgorithm hashingAlgorithm)
        {
            using (StreamReader reader = new StreamReader(fileInputPath))
            {
                using (StreamWriter writer = new StreamWriter(fileOutputPath))
                {
                    while (!reader.EndOfStream)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested) return;

                        string line = reader.ReadLine();
                        string hash = hasher.Hash(line, hashingAlgorithm);
                        writer.WriteLine(line + "=" + hash);
                        LinesProcessed++;
                    }
                }
            }
            File.Delete(fileInputPath);
        }
        public void ResetValues()
        {
            cancellationTokenSource = new CancellationTokenSource();
            logOutput = "";
            allLinesInInputFile = 0;
            Interlocked.Exchange(ref linesProcessed, 0);
            if (stopwatch != null) stopwatch.Reset();
        }
    }    
}

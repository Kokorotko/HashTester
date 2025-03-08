using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    public class RainbowTable
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
            try
            {
                ResetValues();
                stopwatch = Stopwatch.StartNew();
                if (!File.Exists(fileInputPath)) { return false; }
                using (StreamReader reader = new StreamReader(fileInputPath))
                {
                    allLinesInInputFile = File.ReadLines(fileInputPath).LongCount();
                    LogOutput = Languages.Translate(601) + ": " + allLinesInInputFile;
                    using (StreamWriter writer = new StreamWriter(fileOutputPath))
                    {
                        writer.WriteLine("algorithm==" + hashingAlgorithm.ToString());
                        while (!reader.EndOfStream)
                        {
                            if (cancellationTokenSource.Token.IsCancellationRequested)
                            {
                                RemoveFilesQuestion(fileOutputPath);
                                return false; // Stop if canceled
                            }
                            LinesProcessed++;
                            string line = reader.ReadLine();
                            string hash = hasher.Hash(line, hashingAlgorithm);
                            writer.WriteLine(line + "=" + hash);
                        }
                    }
                }
                LogOutput = Languages.Translate(581) + ": " + fileInputPath + " " + Languages.Translate(582) + " " + hashingAlgorithm.ToString()  + " "+ Languages.Translate(583);
                stopwatch.Stop();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("ERROR: Rainbow Table Generator single thread has failed: " + ex.Message);
                MessageBox.Show(Languages.Translate(11000) + Environment.NewLine + ex.Message);
                return false;
            }
        }

        public bool GenerateRainbowTableMultiThread(int numberOfThreadsUsed, string fileInputPath, string fileOutputPath, Hasher.HashingAlgorithm hashingAlgorithm)
        {
            string[] tempFilesInput = new string[numberOfThreadsUsed];
            string[] tempFilesOutput = new string[numberOfThreadsUsed];
            try
            {
                ResetValues();
                stopwatch = Stopwatch.StartNew();
                if (!File.Exists(fileInputPath)) { return false; }
                allLinesInInputFile = File.ReadLines(fileInputPath).LongCount();
                LogOutput = Languages.Translate(589) + ": " + allLinesInInputFile;
                long numberOfCurrentLines = 0;

                // Split the file
                using (StreamReader readerInput = new StreamReader(fileInputPath))
                {
                    for (int i = 0; i < numberOfThreadsUsed; i++)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                            return false; // Stop if canceled
                        }

                        tempFilesInput[i] = Path.Combine(Path.GetDirectoryName(fileOutputPath), "InputSplit-" + i + ".txt");
                        tempFilesOutput[i] = Path.Combine(Path.GetDirectoryName(fileOutputPath), "Temp-" + i + ".txt");
                        long numberOfLinesForThread = allLinesInInputFile / numberOfThreadsUsed;

                        using (StreamWriter writer = new StreamWriter(tempFilesInput[i]))
                        {
                            if (i != numberOfThreadsUsed - 1)
                            {
                                for (int j = 0; j < numberOfLinesForThread; j++)
                                {
                                    if (cancellationTokenSource.Token.IsCancellationRequested)
                                    {
                                        RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                                        return false; // Stop if canceled
                                    }
                                    writer.WriteLine(readerInput.ReadLine());
                                }
                            }
                            else
                            {
                                while (!readerInput.EndOfStream)
                                {
                                    if (cancellationTokenSource.Token.IsCancellationRequested)
                                    {
                                        RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                                        return false; // Stop if canceled
                                    }
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
                                if (cancellationTokenSource.Token.IsCancellationRequested)
                                {
                                    RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                                    return false; // Stop if canceled
                                }
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

                LogOutput = Languages.Translate(581) + ": " + fileInputPath + " " + Languages.Translate(582) + " " + hashingAlgorithm.ToString() + " " + Languages.Translate(583);
                stopwatch.Stop();
                return true;
            }
            catch (Exception ex)
            {
                RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                cancellationTokenSource.Cancel();
                Console.WriteLine("ERROR: Rainbow Table Generator multithread thread has failed: " + ex.Message);
                MessageBox.Show(Languages.Translate(11000) + Environment.NewLine + ex.Message);
                return false;
            }
        }

        private void GenerateRainbowTableMultiThreadForSingleThread(string fileInputPath, string fileOutputPath, Hasher.HashingAlgorithm hashingAlgorithm)
        {
            try
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
            catch (Exception ex)
            {
                cancellationTokenSource.Cancel();
                Console.WriteLine("ERROR: Rainbow Table Generator multithread thread has failed: " + ex.Message);
                MessageBox.Show(Languages.Translate(11000) + Environment.NewLine + ex.Message);
                return;
            }
        }
        public void ResetValues()
        {
            cancellationTokenSource = new CancellationTokenSource();
            logOutput = "";
            allLinesInInputFile = 0;
            Interlocked.Exchange(ref linesProcessed, 0);
            if (stopwatch != null) stopwatch.Reset();
        }

        private void RemoveFilesQuestionMultiThread(string[] tempFilesInput, string[] tempFilesOutput)
        {
            if (MessageBox.Show(Languages.Translate(11003) + Environment.NewLine + Languages.Translate(11005), Languages.Translate(10030), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (string tempFile in tempFilesInput)
                {
                    try
                    {
                        if (File.Exists(tempFile)) File.Delete(tempFile);
                    }
                    catch (Exception) { continue; }
                }
                foreach (string tempFile in tempFilesOutput)
                {
                    try
                    {
                        if (File.Exists(tempFile)) File.Delete(tempFile);
                    }
                    catch (Exception) { continue; }
                }
                MessageBox.Show(Languages.Translate(11004), Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RemoveFilesQuestion(string fileOutputPath)
        {
            if (MessageBox.Show(Languages.Translate(11003), Languages.Translate(10030), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(fileOutputPath))
                    {
                        File.Delete(fileOutputPath);
                    }
                }
                catch (Exception) { }
                MessageBox.Show(Languages.Translate(11004), Languages.Translate(10031), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }    
}

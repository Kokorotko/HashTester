using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    public class RainbowTableGenerator
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
                    LogOutput = Languages.Translate(Languages.L.NumberOfLinesToProcess) + ": " + allLinesInInputFile;
                    using (StreamWriter writer = new StreamWriter(fileOutputPath))
                    {
                        writer.WriteLine("algorithm==" + hashingAlgorithm.ToString());
                        while (!reader.EndOfStream)
                        {
                            if (cancellationTokenSource.Token.IsCancellationRequested)
                            {
                                reader.Close();
                                writer.Close();
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
                LogOutput = Languages.Translate(Languages.L.RainbowTableOfTheFile) + ": " + fileInputPath + " " + Languages.Translate(Languages.L.With) + " " + hashingAlgorithm.ToString()  + " "+ Languages.Translate(Languages.L.HashingAlgorithmIsDone);
                stopwatch.Stop();
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("ERROR: Rainbow Table Generator single thread has failed: " + ex.Message);
                MessageBox.Show(Languages.Translate(Languages.L.AnErrorHasOccuredInTheProgram) + Environment.NewLine + ex.Message);
                return false;
            }
        }

        public async Task<bool> GenerateRainbowTableMultiThread(int numberOfThreadsUsed, string fileInputPath, string fileOutputPath, Hasher.HashingAlgorithm hashingAlgorithm)
        {
            //Task<bool> because async method cant return anything unless like this
            string[] tempFilesInput = new string[numberOfThreadsUsed];
            string[] tempFilesOutput = new string[numberOfThreadsUsed];
            try
            {
                ResetValues();
                stopwatch = Stopwatch.StartNew();
                if (!File.Exists(fileInputPath)) { return false; }                
                using (StreamReader reader = new StreamReader(fileInputPath)) //Number of lines in a file
                {
                    long temp = 0;
                    while (!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        temp++;
                    }
                    allLinesInInputFile = temp;
                }
                LogOutput = Languages.Translate(Languages.L.WarningIfTheresNothingAfterTheItWillSetTheSettingIntoDefault) + ": " + allLinesInInputFile;
                long numberOfCurrentLines = 0;
                
                using (StreamReader readerInput = new StreamReader(fileInputPath)) // Split the file
                {
                    for (int i = 0; i < numberOfThreadsUsed; i++)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            readerInput.Close();
                            RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                            return false; // Stop if canceled
                        }

                        tempFilesInput[i] = Path.Combine(Path.GetDirectoryName(fileOutputPath), "tempSplit-" + i + ".txt");
                        tempFilesOutput[i] = Path.Combine(Path.GetDirectoryName(fileOutputPath), "tempRainbow-" + i + ".txt");
                        long numberOfLinesForThread = allLinesInInputFile / numberOfThreadsUsed;

                        using (StreamWriter writer = new StreamWriter(tempFilesInput[i]))
                        {
                            if (i != numberOfThreadsUsed - 1)
                            {
                                for (int j = 0; j < numberOfLinesForThread; j++)
                                {
                                    if (cancellationTokenSource.Token.IsCancellationRequested)
                                    {
                                        writer.Close();
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
                                        writer.Close();
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

                List<Task> tasks = new List<Task>();
                for (int i = 0; i < tempFilesInput.Length; i++)
                {
                    string inputFile = tempFilesInput[i];
                    string outputFile = tempFilesOutput[i];
                    tasks.Add(Task.Run(() =>
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                            return;
                        }
                        GenerateRainbowTableMultiThreadForSingleThread(inputFile, outputFile, hashingAlgorithm);
                    }, cancellationTokenSource.Token));
                }

                // Wait for all tasks to complete
                await Task.WhenAll(tasks);
                if (cancellationTokenSource.Token.IsCancellationRequested)
                {
                    RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                    return false;
                }
               
                using (StreamWriter writer = new StreamWriter(fileOutputPath)) // Combine the splits
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
                                    writer.Close();
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

                LogOutput = Languages.Translate(Languages.L.RainbowTableOfTheFile) + ": " + fileInputPath + " " + Languages.Translate(Languages.L.With) + " " + hashingAlgorithm.ToString() + " " + Languages.Translate(Languages.L.HashingAlgorithmIsDone);
                stopwatch.Stop();
                return true;
            }
            catch (Exception ex)
            {
                RemoveFilesQuestionMultiThread(tempFilesInput, tempFilesOutput);
                cancellationTokenSource.Cancel();
                stopwatch.Stop();
                Console.WriteLine("ERROR: Rainbow Table Generator multithread thread has failed: " + ex.Message);
                MessageBox.Show(Languages.Translate(Languages.L.AnErrorHasOccuredInTheProgram) + Environment.NewLine + ex.Message);
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
                MessageBox.Show(Languages.Translate(Languages.L.AnErrorHasOccuredInTheProgram) + Environment.NewLine + ex.Message);
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
            if (MessageBox.Show(Languages.Translate(Languages.L.WantToDeleteAnUnfinishedFile) + Environment.NewLine + Languages.Translate(Languages.L.WarningThereWillBeSeveralOfTheseFiles), Languages.Translate(Languages.L.Question), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                MessageBox.Show(Languages.Translate(Languages.L.FileDeleted), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //rename files to not cause problems
            {
                foreach (string tempFile in tempFilesInput) //Input is not needed
                {
                    try
                    {
                        if (File.Exists(tempFile)) File.Delete(tempFile);
                    }
                    catch (Exception) { continue; }
                }
                try
                {
                    string rename = Path.GetDirectoryName(tempFilesOutput[0]);
                    string time = DateTime.UtcNow.ToString("yyyy,MM,dd-HH,mm,ss");
                    for(int i = 1; i < tempFilesOutput.Length + 1; i++)
                    {
                        string path = Path.Combine(rename, "failedRainbowTable-" + i + "-" + time + ".txt");
                        File.Move(tempFilesOutput[i - 1], path);
                    } 
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Languages.Translate(Languages.L.TheProgramFailedToRenameTheFilesWeRecommendToMoveOrDeleteTemporaryFilesBeforeGeneratingTheTableAgain) + Environment.NewLine + ex.Message, Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RemoveFilesQuestion(string fileOutputPath)
        {
            if (MessageBox.Show(Languages.Translate(Languages.L.WantToDeleteAnUnfinishedFile), Languages.Translate(Languages.L.Question), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    if (File.Exists(fileOutputPath))
                    {
                        File.Delete(fileOutputPath);
                    }
                }
                catch (Exception) { }
                MessageBox.Show(Languages.Translate(Languages.L.FileDeleted), Languages.Translate(Languages.L.Info), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else //rename files to not cause problems
            {
                try
                {
                    string rename = Path.GetDirectoryName(fileOutputPath);
                    string time = DateTime.UtcNow.ToString("yyyy,MM,dd-HH,mm,ss");
                    rename = Path.Combine(rename, "failedRainbowTable-" + time + ".txt");
                    File.Move(fileOutputPath, rename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Languages.Translate(Languages.L.TheProgramFailedToRenameTheFilesWeRecommendToMoveOrDeleteTemporaryFilesBeforeGeneratingTheTableAgain) + Environment.NewLine + ex.Message, Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }    
}

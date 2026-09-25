/**
 *@author: Kamil Franek
 *@date: 23.09.2026
 *@brief: Script for creating checksums
 *@file: Checksum.cs
 *@note: This is an older script (not optimized)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HashTester
{
    public class Checksum
    {
        Dictionary<Hasher.HashingAlgorithm, string> outputHash = new Dictionary<Hasher.HashingAlgorithm, string>();
        private int progressBarValue = 0;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(); //Token to cancel the operation
        List<Hasher.HashingAlgorithm> hashingAlgorithms = new List<Hasher.HashingAlgorithm>(); //List of all hashing algorithms

        public int ProgressBarValue
        {
            get { return progressBarValue; }
            set 
            {
                if (value > 100)
                {
                    progressBarValue = 100;
                }
                else if (value < 0)
                {
                    progressBarValue = 0;
                }
                else
                {
                    progressBarValue = value;
                }
            }
        }

        /// <summary>
        /// Resets values for the next operation 
        /// </summary>
        private void ResetOutputValues()
        {
            outputHash.Clear();
            ProgressBarValue = 0;
            cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// Cancels the process
        /// </summary>
        public void CancelProcess()
        {
            cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// Returns information for UI
        /// </summary>
        /// <param name="outputHash">What hashes were used</param>
        /// <param name="progressBarValue">Progress value for progress bar</param>
        public void ReturnHashValues(out Dictionary<Hasher.HashingAlgorithm, string> outputHash, out int progressBarValue)
        {
            outputHash = this.outputHash;
            progressBarValue = this.ProgressBarValue;
        }

        /// <summary>
        /// Constructor for the script
        /// </summary>
        /// <param name="hashingAlgorithms"></param>
        public Checksum(List<Hasher.HashingAlgorithm> hashingAlgorithms)
        {
            this.hashingAlgorithms = hashingAlgorithms;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashingAlgorithm"></param>
        public Checksum(Hasher.HashingAlgorithm hashingAlgorithm)
        {
            List<Hasher.HashingAlgorithm> hashingAlgorithms = new List<Hasher.HashingAlgorithm>(); //Reset
            AddHashingAlgorithm(hashingAlgorithm);
        }

        /// <summary>
        /// Adds a new algorithm to the list
        /// </summary>
        /// <param name="algorithm"></param>
        public void AddHashingAlgorithm(Hasher.HashingAlgorithm algorithm)
        {
            hashingAlgorithms.Add(algorithm);
        }

        /// <summary>
        /// Generates Checksum from a file with multithread
        /// </summary>
        /// <param name="filename">Path to the file</param>
        /// <param name="useMultiThread">True or False</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        public async Task GenerateCheckSumFromFile(string filename, bool useMultiThread, CancellationTokenSource token)
        {
            ResetOutputValues();
            int numberOfSelected = hashingAlgorithms.Count();
            int threadsToUse = 1;

            if (useMultiThread)
            {
                threadsToUse = FormManagement.NumberOfThreadsToUse();
                Console.WriteLine("Number of threads to use: " + threadsToUse);
            }
            var tasks = new List<Task>();

            if (threadsToUse > numberOfSelected) //each task can use Its own thread
            {
                for (int i = 0; i < hashingAlgorithms.Count(); i++)
                {
                    tasks.Add(CreateHashTask(filename, i, numberOfSelected, token));
                }
                await Task.WhenAll(tasks.ToArray());
                ProgressBarValue = 100;
            }
            else
            {
                uint numberOfThreadsUsed = 0;

                for (int i = 0; i < hashingAlgorithms.Count(); i++)
                {
                    numberOfThreadsUsed++;

                    if (numberOfThreadsUsed > threadsToUse)
                    {
                        await Task.WhenAny(tasks.ToArray());
                        numberOfThreadsUsed--;
                    }
                    tasks.Add(CreateHashTask(filename, i, numberOfSelected, token));
                }
                await Task.WhenAll(tasks.ToArray());
                ProgressBarValue = 100;
            }
        }

        /// <summary>
        /// Creates a task for each thread
        /// </summary>
        /// <param name="filename">Path to the file</param>
        /// <param name="index">Index of a thread</param>
        /// <param name="numberOfSelected">Number of all threads running (for ProgressBar)</param>
        /// <param name="token">Cancellation token</param>
        /// <returns></returns>
        private Task CreateHashTask(string filename, int index, int numberOfSelected, CancellationTokenSource token)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Thread " + index + " working");
                string hash = Hasher.FileChecksum(filename, (Hasher.HashingAlgorithm)index, token.Token);
                outputHash.Add((Hasher.HashingAlgorithm)index, hash);
                Console.WriteLine("Thread " + index + " stopped working");
                ProgressBarValue += (int)(100 / numberOfSelected);
            });
        }


        /// <summary>
        /// Compares hashed file with a textBox hash
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="filename">Path to the file</param>
        /// <returns></returns>
        public bool CheckCheckSumFromFile(string hash, string filename)
        {
            string temp = Hasher.FileChecksum(filename, hashingAlgorithms.First(), cancellationTokenSource.Token);
            return (string.Compare(hash, temp) != 0);
        }
    }
}

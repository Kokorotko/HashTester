using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HashTester
{
    public class Checksum
    {
        Dictionary<Hasher.HashingAlgorithm, string> outputHash = new Dictionary<Hasher.HashingAlgorithm, string>();
        private int progressBarValue = 0;
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        List<Hasher.HashingAlgorithm> hashingAlgorithms = new List<Hasher.HashingAlgorithm>();

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

        private void ResetOutputValues()
        {
            outputHash.Clear();
            ProgressBarValue = 0;
            cancellationTokenSource = new CancellationTokenSource();
        }

        public void CancelProcess()
        {
            cancellationTokenSource.Cancel();
        }

        public void ReturnHashValues(out Dictionary<Hasher.HashingAlgorithm, string> outputHash, out int progressBarValue)
        {
            outputHash = this.outputHash;
            progressBarValue = this.ProgressBarValue;
        }

        public Checksum(List<Hasher.HashingAlgorithm> hashingAlgorithms)
        {
            this.hashingAlgorithms = hashingAlgorithms;
        }

        public Checksum(Hasher.HashingAlgorithm hashingAlgorithm)
        {
            List<Hasher.HashingAlgorithm> hashingAlgorithms = new List<Hasher.HashingAlgorithm>(); //Reset
            AddHashingAlgorithm(hashingAlgorithm);
        }

        public void AddHashingAlgorithm(Hasher.HashingAlgorithm algorithm)
        {
            hashingAlgorithms.Add(algorithm);
        }

        public void RemoveHashingAlgorithm(Hasher.HashingAlgorithm algorithm)
        {
            hashingAlgorithms.Remove(algorithm);
        }

        public void AddNewHashingAlgorithms(List<Hasher.HashingAlgorithm> hashingAlgorithms)
        {
            this.hashingAlgorithms = hashingAlgorithms;
        }

        public async void GenerateCheckSumFromFile(string filename, bool useMultiThread)
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
                    tasks.Add(CreateHashTask(filename, i, numberOfSelected));
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
                    tasks.Add(CreateHashTask(filename, i, numberOfSelected));
                }
                await Task.WhenAll(tasks.ToArray());
                ProgressBarValue = 100;
            }
        }

        private Task CreateHashTask(string filename, int index, int numberOfSelected)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("Thread " + index + " working");
                string hash = Hasher.FileChecksum(filename, (Hasher.HashingAlgorithm)index, cancellationTokenSource.Token);
                outputHash.Add((Hasher.HashingAlgorithm)index, hash);
                Console.WriteLine("Thread " + index + " stopped working");
                ProgressBarValue += (int)(100 / numberOfSelected);
            });
        }

        public bool CheckCheckSumFromFile(string hash, string filename)
        {
            string temp = Hasher.FileChecksum(filename, hashingAlgorithms.First(), cancellationTokenSource.Token);
            return (string.Compare(hash, temp) != 0);
        }
    }
}

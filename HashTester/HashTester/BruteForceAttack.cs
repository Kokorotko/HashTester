using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;

namespace HashTester
{
    public class BruteForceAttack
    {
        //private
        private Stopwatch stopwatch = new Stopwatch();
        private bool foundPasswordBool = false;
        private bool ranOutOfTime = false;
        private string foundPassword = "";
        private bool userAborted = false;
        private bool ranOutOfAttemps = false;
        private char[] usableChars;
        private int maximumLenghtForBruteForce = 20;
        private ConcurrentBag<string> logOutput = new ConcurrentBag<string>();
        Hasher hasher = new Hasher();
        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        CancellationTokenSource token = new CancellationTokenSource();
        private BigInteger numberOfAllPossibleCombinations = 0;
        private long attempts = 0;
        private bool useMaxAttempts = false;
        private BigInteger maxAttempts = 0;
        //Get Set
        public Stopwatch Stopwatch
        {
            get { return stopwatch; }
        }
        public BigInteger NumberOfAllPossibleCombinations
        {
            get 
            {
                if (useMaxAttempts) return maxAttempts;
                else return numberOfAllPossibleCombinations; 
            }
            private set { if (value >= 0) numberOfAllPossibleCombinations = value; }
        }

        public bool RanOutOfTime
        {
            get { return ranOutOfTime; }
            private set { ranOutOfTime = value; }
        }

        public string FoundPassword
        {
            get { return foundPassword; }
            private set {  foundPassword = value; }
        }

        public bool FoundPasswordBool
        {
            get { return foundPasswordBool; }
            private set { foundPasswordBool = value; }
        }

        public long Attempts
        {
            get { return attempts; }
            private set { attempts = value; }
        }

        public bool UserAborted
        {
            get { return userAborted; }
            private set { userAborted = value; }
        }

        public int MaximumLenghtForBruteForce
        {
            get { return maximumLenghtForBruteForce; }
            set
            {
                if (value > 0) maximumLenghtForBruteForce = value;
                else maximumLenghtForBruteForce = 50; //Reset
            }
        }
        public ConcurrentBag<string> LogOutput
        {
            get { return logOutput; }
        }

        public bool RanOutOfAttemps
        {
            get { return ranOutOfAttemps; }
            private set {  ranOutOfAttemps = value; }
        }

        public int Progress
        {
            get
            {
                if (NumberOfAllPossibleCombinations == 0) return 0;
                int progress = (int)(Attempts / NumberOfAllPossibleCombinations * 100);
                if (progress > 0 && progress <= 100) return progress;
                else return 0;
            }
        }

        //Private Methods
        private static BigInteger Pow(long number, int exponent) //yes I had to do this
        {
            BigInteger result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= number;
            }
            return result;
        }

        private string GenerateText(BigInteger index, char[] allPossibleChars, int length)
        {
            BigInteger baseSize = allPossibleChars.Length;
            List<char> result = new List<char>();
            while (index > 0)
            {
                result.Insert(0, allPossibleChars[(int)(index % baseSize)]);
                index /= baseSize;
            }
            while (result.Count < length)
            {
                result.Insert(0, allPossibleChars[0]);
            }
            return new string(result.ToArray());
        }

        public BigInteger CalculateAllPossibleCombinations(bool variablePasswordLength, int userPasswordLenght)
        {
            //Console.WriteLine("CalculateAllPossibleCombinationsLong");
            if (usableChars == null) return 0;
            //Console.WriteLine("Usable chars: " + usableChars.Length);
            if (variablePasswordLength) // Variable password length
            {
                BigInteger temp = 0;
                for (int length = 1; length <= maximumLenghtForBruteForce; length++) //maximumLenghtForBruteForce can be change at the start of the script
                {
                    temp += Pow(usableChars.Length, length);
                }
                return temp;
            }
            else // Known password length
            {
                return Pow(usableChars.Length, userPasswordLenght);
            }
        }

        private void ResetValue()
        {
            stopwatch.Reset();
            foundPasswordBool = false;
            RanOutOfTime = false;
            FoundPassword = "";
            UserAborted = false;
            RanOutOfAttemps = false;            
            MaximumLenghtForBruteForce = 20;
            logOutput = new ConcurrentBag<string>();
            if (cancellationToken != null) cancellationToken.Dispose();
            if (token != null) token.Dispose();
            cancellationToken = new CancellationTokenSource();
            token = new CancellationTokenSource();
            NumberOfAllPossibleCombinations = 0;
            Attempts = 0;
        }

        //Public methods
        public void SelectAllUsableChars(string allUsableChars)
        {
            usableChars = new char[allUsableChars.Length];
            for (int i = 0; i < allUsableChars.Length; i++) usableChars[i] = allUsableChars[i];
        }
        public void SelectAllUsableChars(char[] allUsableChars)
        {
            usableChars = new char[allUsableChars.Length];
            for (int i = 0; i < allUsableChars.Length; i++) usableChars[i] = allUsableChars[i];
        }
        public void SelectAllUsableChars(bool useLowerCase, bool useUpperCase, bool useDigits, bool useSpecialChars)
        {
            int pocetZnaku = 0;
            if (useLowerCase) pocetZnaku += 26;
            if (useUpperCase) pocetZnaku += 26;
            if (useDigits) pocetZnaku += 10;
            if (useSpecialChars) pocetZnaku += 33;
            int index = 0;
            usableChars = new char[pocetZnaku];
            if (useLowerCase)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    usableChars[index++] = c;
                }
            }
            if (useUpperCase)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    usableChars[index++] = c;
                }
            }
            if (useDigits)
            {
                for (char c = '0'; c <= '9'; c++)
                {
                    usableChars[index++] = c;
                }
            }
            if (useSpecialChars)
            {
                // Add special characters
                string specialChars = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
                foreach (char c in specialChars)
                {
                    usableChars[index++] = c;
                }
            }
        }

        public Task<bool> PasswordBruteForce(
        Hasher.HashingAlgorithm algorithm,
        bool useMultiThreading,
        int threadID,
        int numberOfThreadsUsed,
        string userHashInput,
        BigInteger userMaxAttempts,
        int userPasswordLenght,
        BigInteger timeToStopTimer)
        {
            maxAttempts = userMaxAttempts;
            Console.WriteLine("PasswordBruteForce");
            if (usableChars == null || usableChars.Length == 0) SelectAllUsableChars(true, true, true, true); // Restart with all chars
            bool variablePasswordLenght = (userPasswordLenght == 0);
            if (!useMultiThreading)
            {
                ResetValue();
                stopwatch.Start();
            }
            useMaxAttempts = maxAttempts > 0;
            BigInteger index = 0;
            int currentLength = variablePasswordLenght ? 1 : userPasswordLenght;
            bool checkedAllPossibleCombinations = false;
            BigInteger allPossibleCombinationsForCurrentLength = CalculateAllPossibleCombinations(false, currentLength);
            BigInteger allPossibleCombinationsForOneThread = 0;

            NumberOfAllPossibleCombinations = CalculateAllPossibleCombinations(variablePasswordLenght, userPasswordLenght);
            //Console.WriteLine("All Possible Combinations in BruteForce: " + NumberOfAllPossibleCombinations);

            if (useMultiThreading)
            {
                allPossibleCombinationsForOneThread = NumberOfAllPossibleCombinations / numberOfThreadsUsed;
                BigInteger assignedStartIndex = allPossibleCombinationsForOneThread * threadID;

                // Find the correct starting length
                BigInteger tempCombinations = 0;
                currentLength = 1;
                while (assignedStartIndex >= tempCombinations + CalculateAllPossibleCombinations(false, currentLength))
                {
                    tempCombinations += CalculateAllPossibleCombinations(false, currentLength);
                    currentLength++;
                }

                // Adjust index relative to the new length
                index = assignedStartIndex - tempCombinations;
            }
            else
            {
                index = 0; // Single-threaded case starts from 0
            }
            bool useStopTimer = true;
            if (timeToStopTimer == 0) useStopTimer = false;
            Console.WriteLine("Starting Length: " + currentLength);
            Console.WriteLine("Starting Index: " + index);

            while (!checkedAllPossibleCombinations)
            {
                if (token.IsCancellationRequested)
                {
                     return Task.FromResult(false);
                }
                if (useStopTimer)
                {
                    if (stopwatch.ElapsedMilliseconds / 1000 > timeToStopTimer)
                    {
                        RanOutOfTime = true;
                        token.Cancel();
                    }
                }

                //Move to next lenght
                if (variablePasswordLenght && index >= allPossibleCombinationsForCurrentLength)
                {
                    index = 0;
                    currentLength++;
                    if (currentLength >= MaximumLenghtForBruteForce)
                    {
                        checkedAllPossibleCombinations = true;
                        if (!useMultiThreading) stopwatch.Stop();
                        return Task.FromResult(false);
                    }
                    allPossibleCombinationsForCurrentLength = CalculateAllPossibleCombinations(false, currentLength);
                }

                // Generate a password and check it
                string tryText = GenerateText(index, usableChars, currentLength);
                //Console.WriteLine($"Thread {threadID} | Index: {index} | Length: {currentLength} | TryText: {tryText}"); - Debug

                string hashedText = hasher.Hash(tryText, algorithm);
                if (hashedText == userHashInput)
                {
                    FoundPasswordBool = true;
                    FoundPassword = tryText; // Found the password
                    if (!useMultiThreading) stopwatch.Stop();
                    return Task.FromResult(true);
                }

                if (useMaxAttempts && (ulong)attempts >= maxAttempts)
                {
                    RanOutOfAttemps = true;
                    Console.WriteLine("Ran Out Of Attempts");
                    if (!useMultiThreading) stopwatch.Stop();
                    return Task.FromResult(false);
                }
                Interlocked.Increment(ref attempts);
                index++;
            }
            if (!useMultiThreading) stopwatch.Stop();
            return Task.FromResult(false);
        }

        public async Task BruteForceAttackMultiThread(
        Hasher.HashingAlgorithm algorithm,
        string userHashInput,
        BigInteger userMaxAttempts,
        int userPasswordLenght,
        BigInteger timeToStopTimer)
        {
            maxAttempts = userMaxAttempts;
            ResetValue();
            //Console.WriteLine("BruteForceAttackMultiThread started.");
            int maxThreads = FormManagement.NumberOfThreadsToUse();
            List<Task> allTasks = new List<Task>();
            stopwatch.Start();
            for (int i = 0; i < maxThreads; i++)
            {
                int threadID = i; // Unique ID for each thread
                allTasks.Add(Task.Run(async () =>
                {
                    Console.WriteLine("Thread " +threadID + " has started working.");
                    if (await PasswordBruteForce(
                        algorithm,
                        true, //use multithread
                        threadID,
                        maxThreads,
                        userHashInput,
                        maxAttempts,
                        userPasswordLenght,
                        timeToStopTimer))
                    {
                        FoundPasswordBool = true;
                        token.Cancel(); // Cancel all threads if password is found
                    }
                    else
                    {
                        Console.WriteLine("Thread " + threadID + "  is finished.");
                    }
                }));
            }
            await Task.WhenAll(allTasks);
            stopwatch.Stop();
            Console.WriteLine("All Threads are done.");
        }



        public void Abort()
        {
            Console.WriteLine("User Aborted");
            UserAborted = true;
            cancellationToken.Cancel();
            token.Cancel();
        }
    }
}


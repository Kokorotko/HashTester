using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace HashTester
{
    public class BruteForceAttack
    {
        #region Private
        private Stopwatch stopwatch = new Stopwatch();
        private bool foundPasswordBool = false;
        private bool ranOutOfTime = false;
        private string foundPassword = "";
        private bool userAborted = false;
        private bool ranOutOfAttemps = false;
        public static char[] usableChars;
        private int maximumLenghtForBruteForce = 20;
        private ConcurrentBag<string> logOutput = new ConcurrentBag<string>();
        Hasher hasher = new Hasher();
        CancellationTokenSource cancellationToken = new CancellationTokenSource();
        CancellationTokenSource token = new CancellationTokenSource();
        private BigInteger numberOfAllPossibleCombinations = 0;
        private long attempts = 0;
        private bool useMaxAttempts = false;
        private BigInteger maxAttempts = 0;
        #endregion

        #region GetSet
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

        #endregion

        #region Methods

        /// <summary>
        /// Custom Math.Pow method that works with BigInteger
        /// </summary>
        /// <param name="number"></param>
        /// <param name="exponent"></param>
        /// <returns></returns>
        private static BigInteger Pow(long number, int exponent) //yes I had to do this
        {
            BigInteger result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= number;
            }
            return result;
        }

        /// <summary>
        /// Generates text combination based on lenght, chars and return a combination on the index
        /// </summary>
        /// <param name="index">BigInt based index from 0 to unlimited</param>
        /// <param name="allPossibleChars">All possible characters used</param>
        /// <param name="length">Lenght of the word</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns all possible combinations of a "password" based on lenght, normally returns Chars pow lenght
        /// </summary>
        /// <param name="variablePasswordLength">Goes from 1 to maximumLenghtForBruteForce (readonly var in BruteForceAttack)</param>
        /// <param name="passwordLenght"></param>
        /// <returns></returns>
        public BigInteger CalculateAllPossibleCombinations(bool variablePasswordLength, int passwordLenght)
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
                return Pow(usableChars.Length, passwordLenght);
            }
        }

        /// <summary>
        /// Resets all private values in this .cs
        /// </summary>
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

        /// <summary>
        /// Returns array of chars that will be used in BruteForce
        /// </summary>
        /// <param name="useLowerCase"></param>
        /// <param name="useUpperCase"></param>
        /// <param name="useDigits"></param>
        /// <param name="useSpecialChars"></param>
        public char[] SelectAllUsableChars(bool useLowerCase, bool useUpperCase, bool useDigits, bool useSpecialChars)
        {
            int numberOfChars = 0;
            if (useLowerCase) numberOfChars += 26;
            if (useUpperCase) numberOfChars += 26;
            if (useDigits) numberOfChars += 10;
            if (useSpecialChars) numberOfChars += 33;
            int index = 0;
            char[] charSet = new char[numberOfChars];
            if (useLowerCase)
            {
                for (char c = 'a'; c <= 'z'; c++)
                {
                    charSet[index++] = c;
                }
            }
            if (useUpperCase)
            {
                for (char c = 'A'; c <= 'Z'; c++)
                {
                    charSet[index++] = c;
                }
            }
            if (useDigits)
            {
                for (char c = '0'; c <= '9'; c++)
                {
                    charSet[index++] = c;
                }
            }
            if (useSpecialChars)
            {
                // Add special characters
                string specialChars = "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
                foreach (char c in specialChars)
                {
                    charSet[index++] = c;
                }
            }
            return charSet; 
        }


        /// <summary>
        /// Starts a Task returning bool that runs Brute force attack
        /// </summary>
        /// <param name="algorithm">Hashing algorithm</param>
        /// <param name="useMultiThreading">Turns multithreading on/off</param>
        /// <param name="threadID">Every thread used in multiThreading should have different ID (from 0 to *numberOfThreads*)</param>
        /// <param name="numberOfThreadsUsed">Number of all threads used</param>
        /// <param name="userHashInput">Hash value we want to BruteForce</param>
        /// <param name="userMaxAttempts">Sets a limit on how many attempts may be used</param>
        /// <param name="userPasswordLenght">Password lenght of the hash (0 means unknown)</param>
        /// <param name="timeToStopTimer">Sets a time limit for how long the operation can work (in seconds)</param>
        /// <param name="startIndex">Start index of a thread (From where to start)</param>
        /// <param name="endIndex">End index of a thread (where to stop)</param>
        /// <returns></returns>
        public Task<bool> PasswordBruteForce(
        Hasher.HashingAlgorithm algorithm,
        bool useMultiThreading,
        int threadID,
        int numberOfThreadsUsed,
        string userHashInput,
        BigInteger userMaxAttempts,
        int userPasswordLenght,
        BigInteger timeToStopTimer,
        BigInteger startIndex,
        BigInteger endIndex)
        {
            Console.WriteLine("PasswordBruteForce");
            BigInteger index = 0;
            BigInteger currentLenghtIndex = 0; //if variable lenght is false, this and index are the same value
            if (usableChars == null || usableChars.Length == 0) usableChars = SelectAllUsableChars(true, true, true, true); // Restart with all chars
            bool variablePasswordLenght = (userPasswordLenght == 0);
            if (!useMultiThreading)
            {
                ResetValue();
                stopwatch.Start();
            }

            useMaxAttempts = userMaxAttempts > 0;
            int currentLength = variablePasswordLenght ? 1 : userPasswordLenght;
            bool checkedAllPossibleCombinations = false;
            BigInteger allCombinationsForCurrentLenghtIndex = CalculateAllPossibleCombinations(false, currentLength);
            //Console.WriteLine("All Possible Combinations in BruteForce: " + NumberOfAllPossibleCombinations);

            bool useStopTimer = true;
            if (timeToStopTimer == 0) useStopTimer = false;

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
                if (variablePasswordLenght)
                {
                    if (currentLenghtIndex >= allCombinationsForCurrentLenghtIndex)
                    {
                        currentLenghtIndex = 0; 
                        currentLength++;                        
                        allCombinationsForCurrentLenghtIndex = CalculateAllPossibleCombinations(false, currentLength);
                    }
                }

                //Check if the thread is done with checking all possible combinations
                if (index == endIndex)
                {
                    if (currentLength >= MaximumLenghtForBruteForce)
                    {
                        checkedAllPossibleCombinations = true;
                        if (!useMultiThreading) stopwatch.Stop();
                        return Task.FromResult(false);
                    }
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

                //check if suprassed max attempts
                if (useMaxAttempts && attempts >= maxAttempts)
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

        /// <summary>
        /// User multithread BruteForceAttack starter
        /// </summary>
        /// <param name="algorithm"></param>
        /// <param name="userHashInput"></param>
        /// <param name="userMaxAttempts"></param>
        /// <param name="userPasswordLenght"></param>
        /// <param name="variablePasswordLenght"></param>
        /// <param name="timeToStopTimer"></param>
        /// <returns></returns>
        public async Task BruteForceAttackMultiThread(
        Hasher.HashingAlgorithm algorithm,
        string userHashInput,
        BigInteger userMaxAttempts,
        int userPasswordLenght,
        bool variablePasswordLenght,
        BigInteger timeToStopTimer)
        {
            ResetValue();
            //Console.WriteLine("BruteForceAttackMultiThread started.");
            int maxThreads = FormManagement.NumberOfThreadsToUse();
            List<Task> allTasks = new List<Task>();
            stopwatch.Start();
            NumberOfAllPossibleCombinations = CalculateAllPossibleCombinations(variablePasswordLenght, userPasswordLenght);
            for (int i = 0; i < maxThreads; i++)
            {
                int threadID = i; // Unique ID for each thread
                //Start and end index for a thread
                BigInteger chunkSize = NumberOfAllPossibleCombinations / maxThreads;
                BigInteger startIndex = chunkSize * threadID;
                BigInteger endIndex;
                if (threadID == maxThreads - 1)
                {
                    endIndex = NumberOfAllPossibleCombinations; // last thread takes the remainder
                }
                else
                {
                    endIndex = startIndex + chunkSize;
                }

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
                        timeToStopTimer,
                        startIndex,
                        endIndex))
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

        /// <summary>
        /// Way to abort the Brute Force operation
        /// </summary>
        public void Abort()
        {
            Console.WriteLine("User Aborted");
            UserAborted = true;
            cancellationToken.Cancel();
            token.Cancel();
        }

        #endregion
    }
}


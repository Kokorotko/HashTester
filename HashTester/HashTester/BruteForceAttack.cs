using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HashTester
{
    internal class BruteForceAttack
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
        CancellationTokenSource cancellationMultiThreadToken = new CancellationTokenSource();
        private long numberOfAllPossibleCombinations = 0;
        private long attempts = 0;
        //Get Set
        public Stopwatch Stopwatch
        {
            get { return stopwatch; }
        }
        public long NumberOfAllPossibleCombinations
        {
            get { return numberOfAllPossibleCombinations; }
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
                else maximumLenghtForBruteForce = 20; //Reset
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
        private static long Pow(long number, int exponent) //yes I had to do this
        {
            long result = 1;
            for (int i = 0; i < exponent; i++)
            {
                result *= number;
            }
            return result;
        }

        private string GenerateTextForBruteForce(long index, char[] allPossibleChars, int length)
        {
            uint baseSize = (uint)allPossibleChars.Length;
            List<char> result = new List<char>();

            while (index > 0)
            {
                result.Insert(0, allPossibleChars[index % baseSize]);
                index /= baseSize;
            }

            // Ensure minimum length
            while (result.Count < length)
            {
                result.Insert(0, allPossibleChars[0]); // Padding with first char
            }

            return new string(result.ToArray());
        }


        public long CalculateAllPossibleCombinations(bool variablePasswordLength, int userPasswordLenght)
        {
            Console.WriteLine("CalculateAllPossibleCombinationsLong");
            if (usableChars == null) return 0;
            Console.WriteLine("Usable chars: " + usableChars.Length);
            if (variablePasswordLength) // Variable password length
            {
                long temp = 0;
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
            stopwatch = new Stopwatch();
            foundPasswordBool = false;
            RanOutOfTime = false;
            FoundPassword = "";
            UserAborted = false;
            RanOutOfAttemps = false;            
            MaximumLenghtForBruteForce = 20;
            logOutput = new ConcurrentBag<string>();
            if (cancellationToken != null) cancellationToken.Dispose();
            if (cancellationMultiThreadToken != null) cancellationMultiThreadToken.Dispose();
            cancellationToken = new CancellationTokenSource();
            cancellationMultiThreadToken = new CancellationTokenSource();
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

        public bool PasswordBruteForce(
        Hasher.HashingAlgorithm algorithm,
        bool useMultiThreading,
        ushort threadID,
        ushort numberOfThreadsUsed,
        string userHashInput,
        ulong maxAttempts,
        int userPasswordLenght,
        long timeToStopTimer)
        {
            Console.WriteLine("PasswordBruteForce");
            ResetValue();

            if (usableChars == null || usableChars.Length == 0)
                SelectAllUsableChars(true, true, true, true); // Restart with all chars

            bool variablePasswordLenght = userPasswordLenght == 0;
            stopwatch.Start();

            bool useMaxAttempts = maxAttempts > 0;
            long index = 0;
            int currentLength = variablePasswordLenght ? 1 : userPasswordLenght;
            bool checkedAllPossibleCombinations = false;
            long allPossibleCombinationsForCurrentLength = CalculateAllPossibleCombinations(false, currentLength);
            long allPossibleCombinationsForOneThread = 0;

            NumberOfAllPossibleCombinations = CalculateAllPossibleCombinations(variablePasswordLenght, userPasswordLenght);
            Console.WriteLine("All Possible Combinations in BruteForce: " + NumberOfAllPossibleCombinations);

            if (useMultiThreading)
            {
                allPossibleCombinationsForOneThread = NumberOfAllPossibleCombinations / numberOfThreadsUsed;
                long assignedStartIndex = allPossibleCombinationsForOneThread * threadID;

                // Find the correct starting length
                long tempCombinations = 0;
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
                if (cancellationToken.Token.IsCancellationRequested || cancellationMultiThreadToken.IsCancellationRequested)
                {
                    return false;
                }
                if (useStopTimer)
                {
                    if (stopwatch.ElapsedMilliseconds / 1000 > timeToStopTimer)
                    {
                        RanOutOfTime = true;
                        cancellationToken.Cancel();
                        cancellationMultiThreadToken.Cancel();
                    }
                }

                // If we reach the limit for this length, move to the next length
                if (variablePasswordLenght && index >= allPossibleCombinationsForCurrentLength)
                {
                    index = 0; // Reset index when moving to the next password length
                    currentLength++;

                    if (currentLength > MaximumLenghtForBruteForce)
                    {
                        checkedAllPossibleCombinations = true;
                        break;
                    }
                    allPossibleCombinationsForCurrentLength = CalculateAllPossibleCombinations(false, currentLength);
                }

                // Generate a password and check it
                string tryText = GenerateTextForBruteForce(index, usableChars, currentLength);
                //Console.WriteLine($"Thread {threadID} | Index: {index} | Length: {currentLength} | TryText: {tryText}"); - Debug

                string hashedText = hasher.Hash(tryText, algorithm);
                if (hashedText == userHashInput)
                {
                    FoundPasswordBool = true;
                    FoundPassword = tryText; // Found the password
                    return true;
                }

                if (useMaxAttempts && (ulong)attempts >= maxAttempts)
                {
                    RanOutOfAttemps = true;
                    Console.WriteLine("Ran Out Of Attempts");
                    return false;
                }

                Interlocked.Increment(ref attempts);
                index++;
            }
            return false;
        }

        public void BruteForceAttackMultiThread(
        Hasher.HashingAlgorithm algorithm,
        string userHashInput,
        ulong maxAttempts,
        int userPasswordLenght,
        long timeToStopTimer)
        {
            Console.WriteLine("BruteForceAttackMultiThread started.");

            // Number of threads to use (max threads based on CPU count)
            ushort maxThreads = (ushort)Math.Max(1, Environment.ProcessorCount / 1.5);

            // List to hold all the tasks
            List<Task> allTasks = new List<Task>();

            // Run tasks for each thread
            for (ushort i = 0; i < maxThreads; i++)
            {
                ushort threadID = i; // Unique ID for each thread
                allTasks.Add(Task.Run(() =>
                {
                    Console.WriteLine($"Thread {threadID} has started working.");

                    if (PasswordBruteForce(
                        algorithm,
                        true,
                        threadID,
                        maxThreads,
                        userHashInput,
                        maxAttempts,
                        userPasswordLenght,
                        timeToStopTimer))
                    {
                        FoundPasswordBool = true;
                        cancellationMultiThreadToken.Cancel(); // Cancel all threads if password is found
                    }
                    else
                    {
                        Console.WriteLine($"Thread {threadID} is finished.");
                    }
                }));
            }

            // Wait until all tasks are completed
            Task.WhenAll(allTasks).Wait(); // Blocking here to wait for all tasks to complete

            Console.WriteLine("All Threads are done.");
        }


        public void Abort()
        {
            Console.WriteLine("User Aborted");
            UserAborted = true;
            cancellationToken.Cancel();
            cancellationMultiThreadToken.Cancel();
        }
    }
}

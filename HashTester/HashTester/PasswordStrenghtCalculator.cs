using System;
using System.Numerics;
using System.Windows.Forms;

namespace HashTester
{
    public static class PasswordStrenghtCalculator
    {
        /// <summary>
        /// Calculates how long it would take to Brute force a password
        /// </summary>
        /// <param name="passwordLenght"></param>
        /// <param name="numberOfChars"></param>
        /// <param name="donePerSec"></param>
        /// <param name="speed"></param>
        /// <param name="overflowed"></param>
        /// <returns></returns>
        public static BigInteger Calculator(int passwordLenght, int numberOfChars, BigInteger donePerSec, out BigInteger speed, out bool overflowed)
        {
            overflowed = !TryPower(numberOfChars, passwordLenght, out BigInteger number);
            if (overflowed)
            {
                speed = 0;
                MessageBox.Show(Languages.Translate(Languages.L.CountingErrorOccurredWeRecommendChoosingSmallerNumbers), Languages.Translate(Languages.L.Error), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;              
            }
            speed = number / donePerSec;
            return number;
        }

        /// <summary>
        /// Power but its for BigInteger
        /// </summary>
        /// <param name="basedValue"></param>
        /// <param name="exponent"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private static bool TryPower(BigInteger basedValue, int exponent, out BigInteger result)
        {
            result = 1;
            try
            {
                for (int i = 1; i <= exponent; i++)
                {
                     result *= basedValue; 
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Converts a big time number into years, months, days, hours, minutes and seconds
        /// </summary>
        /// <param name="numberSeconds"></param>
        /// <returns></returns>
        public static string Output(BigInteger numberSeconds)
        {
            BigInteger numberYears = numberSeconds / 31556926;
            BigInteger numberMonths = (numberSeconds % 31556926) / 2629749;
            BigInteger numberDays = (numberSeconds % 2629749) / 86400;
            BigInteger numberHours = (numberSeconds % 86400) / 3600;
            BigInteger numberMinutes = (numberSeconds % 3600) / 60;
            BigInteger numberSecondsLeft = numberSeconds % 60;

            string s = "";           
            if (numberYears > 0)  s += numberYears.ToString("N0") + " " + Languages.Translate(Languages.L.Years) + ", ";
            if (numberMonths > 0) s += numberMonths.ToString("N0") + " " + Languages.Translate(Languages.L.Months) + ", ";
            if (numberDays > 0)  s += numberDays.ToString("N0") + " " + Languages.Translate(Languages.L.Days) + ", ";
            if (numberHours > 0) s += numberHours.ToString("N0") + " " + Languages.Translate(Languages.L.Hours) + ", ";
            if (numberMinutes > 0) s += numberMinutes.ToString("N0") + " " + Languages.Translate(Languages.L.Minutes) + ", ";
            if (numberSecondsLeft > 0 || s == "") s += numberSecondsLeft.ToString("N0") + " " + Languages.Translate(Languages.L.Seconds);
            if (s.EndsWith(", ")) s = s.Substring(0, s.Length - 2);
            return s;
        }
    }
}

using System;
using System.Numerics;
using System.Windows.Forms;

namespace HashTester
{
    public static class PasswordStrenghtCalculator
    {

        public static BigInteger Calculator(int passwordLenght, int numberOfChars, BigInteger donePerSec, out BigInteger speed, out bool overflowed)
        {
            overflowed = !TryPower(numberOfChars, passwordLenght, out BigInteger number);
            if (overflowed)
            {
                speed = 0;
                MessageBox.Show(Languages.Translate(11006), Languages.Translate(10020), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;              
            }
            speed = number / donePerSec;
            return number;
        }


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



        public static string Output(BigInteger numberSeconds)
        {
            BigInteger numberYears = numberSeconds / 31556926;
            BigInteger numberMonths = (numberSeconds % 31556926) / 2629749;
            BigInteger numberDays = (numberSeconds % 2629749) / 86400;
            BigInteger numberHours = (numberSeconds % 86400) / 3600;
            BigInteger numberMinutes = (numberSeconds % 3600) / 60;
            BigInteger numberSecondsLeft = numberSeconds % 60;

            string s = "";           
            if (numberYears > 0)  s += numberYears.ToString("N0") + " " + Languages.Translate(575) + ", ";
            if (numberMonths > 0) s += numberMonths.ToString("N0") + " " + Languages.Translate(576) + ", ";
            if (numberDays > 0)  s += numberDays.ToString("N0") + " " + Languages.Translate(577) + ", ";
            if (numberHours > 0) s += numberHours.ToString("N0") + " " + Languages.Translate(578) + ", ";
            if (numberMinutes > 0) s += numberMinutes.ToString("N0") + " " + Languages.Translate(579) + ", ";
            if (numberSecondsLeft > 0 || s == "") s += numberSecondsLeft.ToString("N0") + " " + Languages.Translate(580);
            if (s.EndsWith(", ")) s = s.Substring(0, s.Length - 2);
            return s;
        }
    }
}

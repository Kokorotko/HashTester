using System;
using System.Numerics;

namespace HashTester
{
    public static class PasswordStrenghtCalculator
    {

        public static BigInteger Calculator(ulong passwordLenght, ulong numberOfChars, BigInteger donePerSec, out BigInteger speed, out bool overflowed)
        {
            overflowed = !TryPower(numberOfChars, passwordLenght, out BigInteger number);
            speed = number / donePerSec;
            return number;
        }


        private static bool TryPower(ulong basedValue, ulong exponent, out BigInteger result)
        {
            result = 1;
            try
            {
                for (ulong i = 0; i < exponent; i++)
                {
                    result *= basedValue;
                }
                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }



        public static string Output(BigInteger numberSeconds)
        {
            BigInteger numberBillionYears = numberSeconds / 3155692600000000000;
            BigInteger numberYears = (numberSeconds % 3155692600000000000) / 31556926;
            BigInteger numberMonths = (numberSeconds % 31556926) / 2629749;
            BigInteger numberDays = (numberSeconds % 2629749) / 86400;
            BigInteger numberHours = (numberSeconds % 86400) / 3600;
            BigInteger numberMinutes = (numberSeconds % 3600) / 60;
            BigInteger numberSecondsLeft = numberSeconds % 60;

            string s = "";
            if (numberBillionYears > 0) s += numberBillionYears.ToString("N0") + " " + Languages.Translate(575) + " " + Languages.Translate(581) + ", ";
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

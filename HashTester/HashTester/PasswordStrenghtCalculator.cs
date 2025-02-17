using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTester
{
    public class PasswordStrenghtCalculator
    {

        public double Calculator(int delkaHesla, long pocetZnaku, double zaSekundu, out double rychlost)
        {
            double pocet = Math.Pow(pocetZnaku, delkaHesla);
            rychlost = pocet / zaSekundu;
            return pocet;
        }

        public string Output(double numberSeconds)
        {
            double numberYears = numberSeconds / 31556926; //years
            double numberMonths = (numberSeconds % 31556926) / (2629749); //months
            double numberDays = (numberSeconds % 2629749) / (86400); //days
            double numberHours = (numberSeconds % 86400) / (3600); //hours
            double numberMinutes = (numberSeconds % 3600) / (60); //minutes
            double numberSecondsLeft = numberSeconds % 60; //seconds
            string s = Math.Floor(numberYears).ToString("N0") + " " + Languages.Translate(575) + ", " +
           Math.Floor(numberMonths) + " " + Languages.Translate(576) + ", " +
           Math.Floor(numberDays) + " " + Languages.Translate(577) + ", " +
           Math.Floor(numberHours) + " " + Languages.Translate(578) + ", " +
           Math.Floor(numberMinutes) + " " + Languages.Translate(579) + ", " +
           Math.Floor(numberSecondsLeft) + " " + Languages.Translate(580);
           return s;
        }
    }
}

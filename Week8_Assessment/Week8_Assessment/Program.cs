using System;

namespace Week8_Assessment
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }

        public decimal NetAnnualBonus
        {
            get
            {
                if (BaseSalary <= 0)
                    return 0;

                if (AttendancePercentage < 0 || AttendancePercentage > 100)
                    throw new InvalidOperationException();

                decimal ratingPercent;

                switch (PerformanceRating)
                {
                    case 5: ratingPercent = 0.25m; break;
                    case 4: ratingPercent = 0.18m; break;
                    case 3: ratingPercent = 0.12m; break;
                    case 2: ratingPercent = 0.05m; break;
                    case 1: ratingPercent = 0.00m; break;
                    default: throw new InvalidOperationException();
                }

                decimal experiencePercent = 0m;

                if (YearsOfExperience > 10)
                    experiencePercent = 0.05m;
                else if (YearsOfExperience > 5)
                    experiencePercent = 0.03m;

                decimal bonus = BaseSalary * (ratingPercent + experiencePercent);

                if (AttendancePercentage < 85)
                    bonus *= 0.80m;

                bonus *= DepartmentMultiplier;

                decimal maxAllowed = 0.40m * BaseSalary;
                if (bonus > maxAllowed)
                    bonus = maxAllowed;

                decimal taxRate;

                if (bonus <= 150000)
                    taxRate = 0.10m;
                else if (bonus <= 300000)
                    taxRate = 0.20m;
                else
                    taxRate = 0.30m;

                bonus -= bonus * taxRate;

                return Math.Round(bonus, 2);
            }
        }
    }
    internal class Program
    {
        static void Main(String[] args)
        {
            
        }
    }
}
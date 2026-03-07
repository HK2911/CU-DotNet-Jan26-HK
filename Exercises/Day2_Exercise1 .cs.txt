using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program1
    {
        static void Main()
        {
            // =========================
            // Exercise 1: Attendance
            // =========================
            int totalClasses = 120;            // int used because attendance is whole number
            int attendedClasses = 102;

            double attendancePercentage = (double)attendedClasses / totalClasses * 100;
            // double used to preserve decimal precision

            int roundedAttendance = (int)Math.Round(attendancePercentage);
            // rounding gives fair eligibility result

            int truncatedAttendance = (int)attendancePercentage;
            // truncation removes decimals and may reduce percentage

            Console.WriteLine("Exercise 1:");
            Console.WriteLine(attendancePercentage);
            Console.WriteLine(roundedAttendance);
            Console.WriteLine(truncatedAttendance);


            // =========================
            // Exercise 2: Exam Results
            // =========================
            int m1 = 78, m2 = 85, m3 = 69;
            // int because marks are whole numbers

            double average = (m1 + m2 + m3) / 3.0;
            // double to store precise average

            double formattedAverage = Math.Round(average, 2);
            // rounding to 2 decimal places

            int scholarshipRounded = (int)Math.Round(formattedAverage);
            // rounding before int conversion

            int scholarshipTruncated = (int)formattedAverage;
            // truncation causes precision loss

            Console.WriteLine("\nExercise 2:");
            Console.WriteLine(formattedAverage.ToString("F2"));
            Console.WriteLine(scholarshipRounded);
            Console.WriteLine(scholarshipTruncated);


            // =========================
            // Exercise 3: Library Fine
            // =========================
            decimal finePerDay = 2.50m;
            // decimal ensures financial accuracy

            int daysOverdue = 7;
            // int for whole number of days

            decimal totalFine = finePerDay * daysOverdue;
            // total fine calculated in decimal

            double analyticsFine = (double)totalFine;
            // converted to double for analytics (may lose tiny precision)

            Console.WriteLine("\nExercise 3:");
            Console.WriteLine(totalFine);
            Console.WriteLine(analyticsFine);


            // =========================
            // Exercise 4: Banking Interest
            // =========================
            decimal accountBalance = 25000m;
            // decimal used for money

            float interestRate = 6.5f;
            // float from external API

            decimal monthlyInterest = accountBalance * (decimal)interestRate / 100;
            // explicit cast required, implicit conversion fails

            accountBalance += monthlyInterest;

            Console.WriteLine("\nExercise 4:");
            Console.WriteLine(accountBalance);


            // =========================
            // Exercise 5: E-Commerce Pricing
            // =========================
            double cartTotal = 1999.75;
            // double from multiple calculations

            decimal taxRate = 0.18m;
            decimal discount = 100m;

            decimal convertedCart = (decimal)cartTotal;
            // explicit conversion to decimal

            decimal finalAmount = convertedCart + (convertedCart * taxRate) - discount;
            // decimal used to avoid floating-point errors

            Console.WriteLine("\nExercise 5:");
            Console.WriteLine(finalAmount);


            // =========================
            // Exercise 6: Weather Monitoring
            // =========================
            short sensorReading = 315;
            // short saves memory and matches hardware output

            double celsius = sensorReading / 10.0;
            // implicit conversion from short to double is safe

            int dashboardTemp = (int)Math.Round(celsius);
            // explicit cast required, decimals are lost

            Console.WriteLine("\nExercise 6:");
            Console.WriteLine(celsius);
            Console.WriteLine(dashboardTemp);


            // =========================
            // Exercise 7: Grading Engine
            // =========================
            double finalScore = 82.6;
            // double allows fractional scores

            int grade;
            // int is safe, simple, and avoids any overflow risk

            if (finalScore >= 90 && finalScore <= 100) grade = 10;
            else if (finalScore >= 80) grade = 9;
            else if (finalScore >= 70) grade = 8;
            else if (finalScore >= 60) grade = 7;
            else if (finalScore >= 50) grade = 6;
            else grade = 5;

            Console.WriteLine("\nExercise 7:");
            Console.WriteLine(grade);

            // =========================
            // Exercise 8: Data Usage
            // =========================
            long bytesUsed = 5368709120;
            // long stores very large values

            double mb = bytesUsed / (1024.0 * 1024.0);
            double gb = bytesUsed / (1024.0 * 1024.0 * 1024.0);
            // implicit conversion from long to double

            int roundedMB = (int)Math.Round(mb);
            int roundedGB = (int)Math.Round(gb);
            // rounding improves monthly summary accuracy

            Console.WriteLine("\nExercise 8:");
            Console.WriteLine(mb);
            Console.WriteLine(gb);
            Console.WriteLine(roundedMB);
            Console.WriteLine(roundedGB);


            // =========================
            // Exercise 9: Warehouse Inventory
            // =========================
            int itemCount = 4500;
            // signed integer allows increases and decreases

            ushort maxCapacity = 5000;
            // unsigned because capacity cannot be negative

            bool withinCapacity = itemCount <= maxCapacity;
            // ushort is promoted to int during comparison

            int capacityForReport = maxCapacity;
            // explicit conversion for reporting

            Console.WriteLine("\nExercise 9:");
            Console.WriteLine(withinCapacity);
            Console.WriteLine(capacityForReport);

            // =========================
            // Exercise 10: Payroll
            // =========================
            int basicSalary = 25000;
            // base salary is whole number

            double allowances = 4500.75;
            double deductions = 1200.25;
            // double supports fractional values

            decimal netSalary = basicSalary + (decimal)allowances - (decimal)deductions;
            // decimal ensures financial precision

            Console.WriteLine("\nExercise 10:");
            Console.WriteLine(netSalary);
        }
    }
}

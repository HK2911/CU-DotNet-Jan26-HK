using System;

namespace WEEK2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;

            string[] policyHolderNames = new string[n];
            decimal[] annualPremiums = new decimal[n];

            Console.WriteLine("Enter the name of customers");
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    policyHolderNames[i] = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(policyHolderNames[i]))
                        break;

                    Console.WriteLine("Name cannot be empty. Re-enter:");
                }
            }

            Console.WriteLine("Enter the annual premiums");
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    annualPremiums[i] = decimal.Parse(Console.ReadLine());
                    if (annualPremiums[i] > 0)
                        break;

                    Console.WriteLine("Please enter correct amount greater than 0):");
                }
            }

            decimal total = 0;
            for (int i = 0; i < n; i++)
            {
                total += annualPremiums[i];
            }

            decimal highestPremium = highest(annualPremiums);
            decimal lowestPremium = lowest(annualPremiums);
            decimal averagePremium = total / n;

            Console.WriteLine("\nInsurance Premium Summary");
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("NAME\t\tPREMIUM\t\tCATEGORY");
            Console.WriteLine("-----------------------------------------------");

            for (int i = 0; i < n; i++)
            {
                string category;
                if (annualPremiums[i] < 10000)
                    category = "LOW";
                else if (annualPremiums[i] > 25000)
                    category = "HIGH";
                else
                    category = "MEDIUM";

                Console.WriteLine(
                    $"{policyHolderNames[i].ToUpper(),-15}" +
                    $"{annualPremiums[i],-15:F2}" +
                    $"{category}"
                );
            }

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine($"Total Premium   : {total:F2}");
            Console.WriteLine($"Average Premium : {averagePremium:F2}");
            Console.WriteLine($"Highest Premium : {highestPremium:F2}");
            Console.WriteLine($"Lowest Premium  : {lowestPremium:F2}");
        }

        static decimal highest(decimal[] arr)
        {
            decimal max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        static decimal lowest(decimal[] arr)
        {
            decimal min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
            }
            return min;
        }
    }
}

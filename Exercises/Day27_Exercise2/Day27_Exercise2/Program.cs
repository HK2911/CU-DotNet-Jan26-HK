using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

public class Loan
    {
        public string ClientName { get; set; }
        public double Principal { get; set; }
        public double InterestRate { get; set; } 
    }

    class Program
    {
        static string filePath = "loans.csv";

        static void Main()
        {
            Console.WriteLine("==== LOAN PORTFOLIO MANAGER ====\n");

            
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("ClientName,Principal,InterestRate");
                }
            }

            AddLoan();

            ReadLoans();

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

       
        static void AddLoan()
        {
            Console.WriteLine("\nEnter New Loan Details");

            Console.Write("Client Name: ");
            string name = Console.ReadLine();

            Console.Write("Principal Amount: ");
            double.TryParse(Console.ReadLine(), out double principal);

            Console.Write("Interest Rate (%): ");
            double.TryParse(Console.ReadLine(), out double rate);

            using (StreamWriter writer = new StreamWriter(filePath, true)) // append mode
            {
                writer.WriteLine($"{name},{principal},{rate}");
            }

            Console.WriteLine("Loan added successfully!\n");
        }

        
        static void ReadLoans()
        {
            Console.WriteLine("==== LOAN RISK ANALYSIS ====\n");

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;

                reader.ReadLine(); 

                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length != 3)
                        continue;

                    string name = parts[0];

                    if (!double.TryParse(parts[1], out double principal))
                        continue;

                    if (!double.TryParse(parts[2], out double rate))
                        continue;

                    double interestAmount = principal * rate / 100;

                    string riskCategory = GetRiskCategory(rate);

                    Console.WriteLine("------------------------------------");
                    Console.WriteLine($"Client: {name}");
                    Console.WriteLine($"Principal: {principal:C}");
                    Console.WriteLine($"Interest Rate: {rate}%");
                    Console.WriteLine($"Total Interest: {interestAmount:C}");
                    Console.WriteLine($"Risk Level: {riskCategory}");
                }
            }
        }

        
        static string GetRiskCategory(double rate)
        {
            if (rate > 10)
                return "High Risk";
            else if (rate >= 5 && rate <= 10)
                return "Medium Risk";
            else
                return "Low Risk";
        }
    }
namespace salesAnalysis
{
    internal class Program
   
        {
            static void Main(string[] args)
            {
                // 1️⃣ Data Capture
                decimal[] sales = new decimal[7];
                string[] categories = new string[7];

                for (int i = 0; i < sales.Length; i++)
                {
                    while (true)
                    {
                        Console.Write($"Enter sales for Day {i + 1}: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal value) && value >= 0)
                        {
                            sales[i] = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Sales must be >= 0.");
                        }
                    }
                }

                // 2️⃣ Weekly Sales Analysis
                decimal totalSales = 0;
                decimal highestSale = sales[0];
                decimal lowestSale = sales[0];
                int highestDay = 1;
                int lowestDay = 1;

                for (int i = 0; i < sales.Length; i++)
                {
                    totalSales += sales[i];

                    if (sales[i] > highestSale)
                    {
                        highestSale = sales[i];
                        highestDay = i + 1;
                    }

                    if (sales[i] < lowestSale)
                    {
                        lowestSale = sales[i];
                        lowestDay = i + 1;
                    }
                }

                decimal averageSales = totalSales / sales.Length;

                int daysAboveAverage = 0;
                for (int i = 0; i < sales.Length; i++)
                {
                    if (sales[i] > averageSales)
                    {
                        daysAboveAverage++;
                    }
                }

                // 3️⃣ Sales Categorization (Parallel Array)
                for (int i = 0; i < sales.Length; i++)
                {
                    if (sales[i] < 5000)
                        categories[i] = "Low";
                    else if (sales[i] <= 15000)
                        categories[i] = "Medium";
                    else
                        categories[i] = "High";
                }

                // 4️⃣ Output Report
                Console.WriteLine("\nWeekly Sales Report");
                Console.WriteLine("-------------------");

                Console.WriteLine($"{"Total Sales".PadRight(20)}: {totalSales:F2}");
                Console.WriteLine($"{"Average Daily Sale".PadRight(20)}: {averageSales:F2}\n");

                Console.WriteLine($"{"Highest Sale".PadRight(20)}: {highestSale:F2} (Day {highestDay})");
                Console.WriteLine($"{"Lowest Sale".PadRight(20)}: {lowestSale:F2}  (Day {lowestDay})\n");

                Console.WriteLine($"{"Days Above Average".PadRight(20)}: {daysAboveAverage}\n");

                for (int i = 0; i < categories.Length; i++)
                {
                    Console.WriteLine($"Day {i + 1} : {categories[i]}");
                }
            }
        }
    }

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] sales = new decimal[7];
            string[] categories = new string[7];

            ReadWeeklySales(sales);

            decimal total = CalculateTotal(sales);
            decimal average = CalculateAverage(total, sales.Length);

            int highDay, lowDay;
            decimal highest = FindHighestSale(sales, out highDay);
            decimal lowest = FindLowestSale(sales, out lowDay);

            decimal discount = CalculateDiscount(total);


            decimal tax = CalculateTax(total - discount);

            decimal finalAmount = CalculateFinalAmount(total, discount, tax);

            GenerateSalesCategory(sales, categories);

            // Output
            Console.WriteLine("\nWeekly Sales Summary");
            Console.WriteLine("--------------------");

            Console.WriteLine($"{"Total Sales".PadRight(20)}: {total:F2}");
            Console.WriteLine($"{"Average Daily Sale".PadRight(20)}: {average:F2}\n");

            Console.WriteLine($"{"Highest Sale".PadRight(20)}: {highest:F2} (Day {highDay})");
            Console.WriteLine($"{"Lowest Sale".PadRight(20)}: {lowest:F2}  (Day {lowDay})\n");

            Console.WriteLine($"{"Discount Applied".PadRight(20)}: {discount:F2}");
            Console.WriteLine($"{"Tax Amount".PadRight(20)}: {tax:F2}");
            Console.WriteLine($"{"Final Payable".PadRight(20)}: {finalAmount:F2}\n");

            Console.WriteLine("Day-wise Category:");
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"Day {i + 1} : {categories[i]}");
            }
        }

        static void ReadWeeklySales(decimal[] sales)
        {
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
                    Console.WriteLine("Invalid input. Enter non-negative value.");
                }
            }
        }

        static decimal CalculateTotal(decimal[] sales)
        {
            decimal sum = 0;
            for (int i = 0; i < sales.Length; i++)
            {
                sum += sales[i];
            }
            return sum;
        }

        static decimal CalculateAverage(decimal total, int days)
        {
            return total / days;
        }

        static decimal FindHighestSale(decimal[] sales, out int day)
        {
            decimal max = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] > max)
                {
                    max = sales[i];
                    day = i + 1;
                }
            }
            return max;
        }

        static decimal FindLowestSale(decimal[] sales, out int day)
        {
            decimal min = sales[0];
            day = 1;

            for (int i = 1; i < sales.Length; i++)
            {
                if (sales[i] < min)
                {
                    min = sales[i];
                    day = i + 1;
                }
            }
            return min;
        }

        static decimal CalculateDiscount(decimal total)
        {
            return total >= 50000 ? total * 0.10m : total * 0.05m;
        }

        static decimal CalculateDiscount(decimal total, bool isFestivalWeek)
        {
            decimal discount = CalculateDiscount(total);
            if (isFestivalWeek)
                discount += total * 0.05m;

            return discount;
        }

        static decimal CalculateTax(decimal amount)
        {
            return amount * 0.18m;
        }

        static decimal CalculateFinalAmount(decimal total, decimal discount, decimal tax)
        {
            return total - discount + tax;
        }

        static void GenerateSalesCategory(decimal[] sales, string[] categories)
        {
            for (int i = 0; i < sales.Length; i++)
            {
                if (sales[i] < 5000)
                    categories[i] = "Low";
                else if (sales[i] <= 15000)
                    categories[i] = "Medium";
                else
                    categories[i] = "High";
            }
        }
    }
}

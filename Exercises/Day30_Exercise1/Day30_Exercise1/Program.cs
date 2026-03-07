namespace Day30_Exercise1
{
    internal class Program
    {
        static List<double> Calculate(int[] arr)
        {
            List<double> result = new List<double>();

            double average = 0;

            // Calculate total
            for (int i = 0; i < arr.Length; i++)
            {
                average += arr[i];
            }

            average /= arr.Length;

            Console.WriteLine($"\nAverage Amount: {average}\n");

            // Calculate difference
            for (int i = 0; i < arr.Length; i++)
            {
                double diff = arr[i] - average;
                result.Add(diff);

                if (diff < 0)
                {
                    Console.WriteLine($"{Math.Abs(diff)} amount needed by person {i + 1}");
                }
                else if (diff > 0)
                {
                    Console.WriteLine($"{diff} extra amount available with person {i + 1}");
                }
                else
                {
                    Console.WriteLine($"Person {i + 1} is balanced");
                }
            }

            return result;
        }

        static void Main(String[] args)
        {
            Console.Write("Enter number of people: ");
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter amount for person {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine());
            }


            
            List<double> result = Calculate(arr);
        }
    }
}

namespace Day23_Exercise1
{
    internal class Program
    {

        class Task1
        {
            public void DivisionException()
            {
                Console.WriteLine("We are dividing two numbers");
                Console.WriteLine("Enter first number: ");
                int x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number: ");
                int y = int.Parse(Console.ReadLine());

                try
                {
                    int result = x / y;
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine("Tried dividing by zero" + ex.Message + ex.StackTrace + ex.InnerException);
                }
                finally
                {
                    Console.WriteLine(" Division Operation completed");
                }

            }
            public void IntegerException()
            {
                Console.WriteLine("Enter an integer value");

                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException fx)
                {
                    Console.WriteLine("Format exception" + fx.Message + fx.InnerException + fx.StackTrace);
                }
                finally
                {
                    Console.WriteLine("Format exception completed completed");
                }
            }
            public void ArrayException()
            {
                Console.WriteLine("Enter 4 integer array elements");
                int[] arr = new int[4];
                for (int i = 0; i < 4; i++)
                {
                    arr[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter index value");
                int index = int.Parse(Console.ReadLine());
                try
                {
                    int arrayElement = arr[index];
                }
                catch (IndexOutOfRangeException Ix)
                {
                    Console.WriteLine("Array index exception" + Ix.Message + Ix.InnerException + Ix.StackTrace);
                }
                finally
                {
                    Console.WriteLine("Array Operation Completed");
                }
            }
        }
        class InvalidStudentAgeException : Exception
        {
            public InvalidStudentAgeException(string message) : base(message)
            {

            }
        }
        public static void Main(string[] args)
        {
            Task1 task1 = new Task1();
            bool validAge = false;

            while (!validAge)
            {
                try
                {
                    Console.WriteLine("Enter value of age");
                    int age = int.Parse(Console.ReadLine());

                    if (age <= 18 || age >= 60)
                    {
                        throw new InvalidStudentAgeException("Enter age between 18 and 60");
                    }
                    else
                    {
                        validAge = true;
                        Console.WriteLine("Valid age entered");
                    }
                }
                catch (InvalidStudentAgeException ex)
                {
                    throw new Exception("Student age validation failed", ex);
                }
                catch (Exception ch)
                {
                    Console.WriteLine("Exception Message: " + ch.Message);

                    if (ch.InnerException != null)
                    {
                        Console.WriteLine("InnerException Message: " + ch.InnerException.Message);
                    }
                }
                finally
                {
                    Console.WriteLine("Invalid age exception completed");
                }
            }
        }

    }
}
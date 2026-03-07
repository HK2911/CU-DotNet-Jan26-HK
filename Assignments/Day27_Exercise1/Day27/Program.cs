using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace FileStreamDemo
{
    internal class Class1
    {
        static void Main()
        {
            string file = @"../../../file1.txt";
            Console.WriteLine("Write your content: ");
            string input = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine(input);
                sw.WriteLine();
            }

            Console.WriteLine("Your reflection have been saved");

        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreetingLibrary;

namespace GreetingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string message = GreetingHelper.getGreeting(name);
            Console.WriteLine(message);
            Console.ReadLine();
        }
    }
}

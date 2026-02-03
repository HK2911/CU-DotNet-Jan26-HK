using System.Collections;

namespace Day24_Exercise2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<double, string> leaderboard = new SortedDictionary<double, string>
            {
                { 55.42,"SwiftRacer" },
                { 52.10,"SpeedDemon" },
                { 58.91, "SteadyEddie"},
                {51.05, "TurboTom" }
            };

            foreach(var v in leaderboard) 
            {
                Console.WriteLine(v);
            }
            Console.WriteLine();
            Console.WriteLine("Gold Medalist : "+ leaderboard.First());

            Console.WriteLine();

            double keyRemove = 0;
            foreach(var y in leaderboard)
            {
                if(y.Value=="SteadyEddie")
                {
                    keyRemove = y.Key;
                    break;
                }
            }
            leaderboard.Remove(keyRemove);
            leaderboard.Add(54.00, "SteadyEddie");

            Console.WriteLine("Updated Time");
            foreach (var v in leaderboard)
            {
                Console.WriteLine(v);
            }

        }
    }
}

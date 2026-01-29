using System.Diagnostics;

namespace Day20_Exercise1
{

    class Flight: IComparable<Flight>
    {
        public string FlightNumber {  get; set; }
        public decimal Price {  get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime DepartureTime {  get; set; }

        public int CompareTo(Flight? other)
        {
            if (other == null) return 1;
            return Price.CompareTo(other.Price);
        }

        public Flight(string flightNumber,decimal price,TimeSpan duration,DateTime departureTime)
        {
            FlightNumber = flightNumber;
            Price = price;
            Duration = duration;
            DepartureTime = departureTime;
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Duration.CompareTo(y.Duration);
        }

        
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.DepartureTime.CompareTo(y.DepartureTime);
        }


    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> fly = new List<Flight>
            {

                new Flight("ATQ01", 6500, new TimeSpan(5,2,30,5), new DateTime(2027,1,15,10,20,25)),
                new Flight("ATQ02", 3800, new TimeSpan(1,4,40,2), new DateTime(2027,3,25,20,10,15)),
                new Flight("ATQ03", 4000, new TimeSpan(3,1,20,6), new DateTime(2026,2,12,10,10,54))


            };


            /*Console.WriteLine("--------Before Scheduling---------");
            Console.WriteLine();


            Console.WriteLine("---------Economy View---------");

            foreach (Flight f in fly)
            {
                Console.WriteLine($"{f.FlightNumber} | {f.Price}");
            }
            Console.WriteLine("\t");

            Console.WriteLine("--------Business Runner View---------");
            fly.Sort(new DurationComparer());
            foreach (Flight f in fly)
            {
                Console.WriteLine($"{f.FlightNumber} | {f.Duration}");
            }
            Console.WriteLine("\t");

            Console.WriteLine("--------Early Bird View---------");
            fly.Sort(new DepartureComparer());
            foreach (Flight f in fly)
            {
                Console.WriteLine($"{f.FlightNumber} | {f.DepartureTime}");
            }
            Console.WriteLine("\t");
            */
            Console.WriteLine("*******After Scheduling********");
            Console.WriteLine("\t");
            
            fly.Sort();
            Console.WriteLine("---------Economy View---------");

            Console.WriteLine("\t");

            foreach (Flight f in fly)
            {
                Console.WriteLine($"{f.FlightNumber} | {f.Price}");
            }

            Console.WriteLine("--------Business Runner View---------");
            Console.WriteLine("\t");
            fly.Sort(new DurationComparer());
            foreach (Flight f in fly)
            {    
                Console.WriteLine($"{f.FlightNumber} | {f.Duration}");
            }

            Console.WriteLine("--------Early Bird View---------");
            Console.WriteLine("\t");
            fly.Sort(new DepartureComparer());
            foreach (Flight f in fly)
            {
                Console.WriteLine($"{f.FlightNumber} | {f.DepartureTime}");
            }



        }
    }
}

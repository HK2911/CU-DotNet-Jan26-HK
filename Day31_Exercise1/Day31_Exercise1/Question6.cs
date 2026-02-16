using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_Exercise1
{

    class Movie { public string Title; public string Genre; public double Rating; public int Year; }


    internal class Question6
    {
        static void Main(String[] args)
        {
            var movies = new List<Movie>
            {
                new Movie{Title="Inception", Genre="SciFi", Rating=9, Year=2010},
                new Movie{Title="Avatar", Genre="SciFi", Rating=8.5, Year=2009},
                new Movie{Title="Titanic", Genre="Drama", Rating=8, Year=1997}
            };

            var toprated = movies.Where(m => m.Rating > 8);
            foreach(var v in toprated)
            {
                Console.WriteLine($"Movie which has rating grater than 8 - {v.Title}");
            }

            var avgClass = movies.GroupBy(g => g.Genre).Select(g =>
            new
            {   Genre = g.Key,
                Avg = g.Average(a => a.Rating)
            });

            foreach (var v in avgClass)
            {
                Console.WriteLine(v.Genre + " - " + v.Avg);
            }

            var latest = movies.GroupBy(l => l.Genre).Select(l => l.OrderByDescending(m => m.Year).FirstOrDefault());
            foreach (var movie in latest)
            {
                Console.WriteLine($"{movie.Genre} - {movie.Title} ({movie.Year})");
            }


            var top5 = movies.OrderByDescending(l => l.Rating).Take(5);
            Console.WriteLine("Top 5 highest");
            foreach(var v in top5)
            {
                Console.WriteLine(v.Title +" - "+  v.Rating);
            }
            

        }
    }
}

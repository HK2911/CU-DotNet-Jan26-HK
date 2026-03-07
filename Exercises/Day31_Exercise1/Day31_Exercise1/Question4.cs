using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_Exercise1
{
    class Book { public string Title; public string Author; public string Genre; public int Year; public double Price; }
    internal class Question4
    {
        static void Main(String[] args)
        {
            var books = new List<Book>
            {
                new Book{Title="C# Basics", Author="John", Genre="Tech", Year=2018, Price=500},
                new Book{Title="Java Advanced", Author="Mike", Genre="Tech", Year=2016, Price=700},
                new Book{Title="History India", Author="Raj", Genre="History", Year=2019, Price=400}
            };

            var publish = books.Where(b => b.Year > 2015).ToList();
            foreach (var book in publish) 
            {
                Console.WriteLine("Author is "+book.Author +" and year of publishing is "+ book.Year);
            }

            var genre = books.GroupBy(g => g.Genre).Select(c =>
            new
            {
                Genre = c.Key,
                Count = c.Count()
            });

            foreach(var v in genre)
            {
                Console.WriteLine(v.Genre + " - " + v.Count) ;
            }

            var topLatest = books.OrderByDescending(b => b.Price).Take(1);
            foreach(var v in  topLatest)
            {
                Console.WriteLine(v.Author + " - "+ v.Price);
            }


            var unique = books.DistinctBy(d => d.Author);
            foreach(var v in unique)
            {
                Console.WriteLine(v.Author +  " - "+ v.Title);
            }


        }
    }
}

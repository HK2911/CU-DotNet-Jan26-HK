using System.Formats.Asn1;

namespace Day31_Exercise1
{
    class Student
    {
        public int Id;
        public string Name;
        public string Class;
        public int Marks;
    }


    internal class Question1
    {

        static void Main(String[] args)
        {
        var students = new List<Student>
        {
            new Student{Id=1, Name="Amit", Class="10A", Marks=85},
            new Student{Id=2, Name="Neha", Class="10A", Marks=72},
            new Student{Id=3, Name="Rahul", Class="10B", Marks=90},
            new Student{Id=4, Name="Pooja", Class="10B", Marks=60},
            new Student{Id=5, Name="Kiran", Class="10A", Marks=95}
        };


            var topThree = students.OrderByDescending(t => t.Marks).Take(3);
            foreach (var v in topThree)
            {
                Console.WriteLine(v.Name+ "-"+ v.Marks);
            }
           
            var avg = students.GroupBy(g => g.Class).Select(g =>
            new
            {
                Class = g.Key,
                Avg=g.Average(a=>a.Marks)
            });

            foreach (var a in avg)
            {
                Console.WriteLine(a.Class + " " + a.Avg);
            }
            var overallAverage = students.Average(s => s.Marks);

            var belowMarks = students.Where(s => s.Marks < overallAverage).ToList();
            foreach (var person in belowMarks)
            {
                Console.WriteLine(person.Name+" has marks below than average");
            }

            var marksdescending = students.OrderByDescending(o => o.Marks);
            Console.WriteLine("Marks in descending order");
            foreach(var v in marksdescending)
            {
                Console.WriteLine(v.Name+ "-"+ v.Marks) ;
            }

        }
    }
}

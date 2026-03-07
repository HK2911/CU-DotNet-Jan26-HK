using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day31_Exercise1
{
    internal class Question2
    {
        class Employee
        {
            public int Id;
            public string Name;
            public string Dept;
            public double Salary;
            public DateTime JoinDate;
        }
        public static void Main(String[] args)
        {
            var employees = new List<Employee>
            {
                new Employee{Id=1, Name="Ravi", Dept="IT", Salary=80000, JoinDate=new DateTime(2019,1,10)},
                new Employee{Id=2, Name="Anita", Dept="HR", Salary=60000, JoinDate=new DateTime(2021,3,5)},
                new Employee{Id=3, Name="Suresh", Dept="IT", Salary=120000, JoinDate=new DateTime(2018,7,15)},
                new Employee{Id=4, Name="Meena", Dept="Finance", Salary=90000, JoinDate=new DateTime(2022,9,1)}
            };

            var higySal = employees.Max(e => e.Salary);
            Console.WriteLine(higySal);

            var high = employees.MaxBy(m => m.Salary);
            Console.WriteLine($"{high.Name} have highest salary of rupees {high.Salary}");

            var low=employees.MinBy(m=> m.Salary);
            Console.WriteLine($"{low.Name} have Lowest salary of rupees {low.Salary}");

            var strength = employees.Count;
            Console.WriteLine("Total Count is "+strength);

            var doj = employees.Where(e => e.JoinDate.Year > 2020);
                
                foreach(var v in doj)
                {
                Console.WriteLine("employees who have joined after 2020" + v.Name);
                }
             
            var projectedData = employees.Select(e => new
            {
                e.Name,
                 AnnualSalary=e.Salary*12
            }) ;

            foreach (var emp in projectedData)
            {
                Console.WriteLine($"{emp.Name} - {emp.AnnualSalary}");
            }

        }
        }
    }


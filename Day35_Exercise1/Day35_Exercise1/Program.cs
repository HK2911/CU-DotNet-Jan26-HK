using System;
using System.Collections.Generic;
namespace Day35_Exercise1
{
    public class TreeNode<T>
    {
        public T Data { get; set; }
        public List<TreeNode<T>> Children { get; set; }

        public TreeNode(T data)
        {
            Data = data;
            Children = new List<TreeNode<T>>();
        }

        public void AddChild(TreeNode<T> child)
        {
            Children.Add(child);
        }
     }

    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public override string ToString()
        {
            return $"{Name} ({Position})";
        }
    }

    public class OrganizationTree
    {
        public TreeNode<Employee> Root { get; set; }

        public OrganizationTree(TreeNode<Employee> root)
        {
            Root = root;
        }

        public void DisplayHierarchy()
        {
            Console.WriteLine("ORGANIZATION STRUCTURE");
            Console.WriteLine("======================");
            PrintRecursive(Root, 0);
        }

        private void PrintRecursive(TreeNode<Employee> current, int depth)
        {
            if (current == null) return;

            // Indentation (4 spaces per level)
            string indent = new string(' ', depth * 4);

            Console.WriteLine($"{indent}{current.Data}");

            foreach (var child in current.Children)
            {
                PrintRecursive(child, depth + 1);
            }
        }
    }
    internal class Program
    {
       
            static void Main(string[] args)
            {
                // Create Employees
                var ceo = new TreeNode<Employee>(new Employee("Aman", "CEO"));
                var director = new TreeNode<Employee>(new Employee("Suresh", "Director"));
                var manager = new TreeNode<Employee>(new Employee("Sonia", "Manager"));
                var seniorDev = new TreeNode<Employee>(new Employee("Sara", "Senior Developer"));
                var juniorDev = new TreeNode<Employee>(new Employee("Divakar", "Junior Developer"));
                var cfo = new TreeNode<Employee>(new Employee("Rajesh", "CFO"));
                var accountOfficer = new TreeNode<Employee>(new Employee("Rajat", "Account Officer"));

                // Build Hierarchy
                ceo.AddChild(director);
                director.AddChild(manager);
                manager.AddChild(seniorDev);
                manager.AddChild(juniorDev);

                ceo.AddChild(cfo);
                cfo.AddChild(accountOfficer);

                // Create Organization Tree
                var organization = new OrganizationTree(ceo);

                // Display
                organization.DisplayHierarchy();

                Console.ReadKey();
            }
        
    }
}

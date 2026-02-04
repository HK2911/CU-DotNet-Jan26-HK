namespace Day14
{
    class Employee
    {
        private int id;
        public void setId(int id)
        {
            this.id = id;
        }
        public int getID()
        {
            return id;
        }
        public string Name { get; set; }

        private string department;
        public string Department
        {
            set
            {
                if (value == "Accounts" || value == "Sales" || value == "IT")
                {
                    department = value;
                }
                else
                {
                    department = "Invalid";
                }
            }
            get { return department; }

        }
        private int salary;

        public int Salary
        {
            get { return salary; }
            set
            {
                if (value < 50000 || value > 90000) { salary = 50000; }
                else
                {
                    salary = value;

                }
            }
        }
        public void Display()
        {
            Console.WriteLine($"ID :{id}");
            Console.WriteLine($"Name :{Name}");
            Console.WriteLine($"Department :{Department}");
            Console.WriteLine($"Salary :{salary}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            emp.setId(101);
            Console.WriteLine("Enter Employee Name");
            emp.Name = Console.ReadLine();
            emp.Department ="Sales";
            emp.Salary = 50;
            emp.Display();

        }
    }
}
namespace Day18_Exrecise2
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public decimal BasicSalary { get; set; }

        public int ExperienceInYears { get; set; }


        public Employee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears)
        {
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            BasicSalary = basicSalary;
            ExperienceInYears = experienceInYears;
        }

        public decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = 0;
            AnnualSalary = BasicSalary * 12;
            return AnnualSalary;

        }

        public string DisplayDetails()
        {
           return $"Employee Id= {EmployeeId}, Employee Name= {EmployeeName},Basic Salary={BasicSalary}, Experince in Years ={ExperienceInYears} , AnnualSalary :{CalculateAnnualSalary()}";
        }
    }


    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears) : base(employeeId, employeeName, basicSalary, experienceInYears)
        {

        }

        public new decimal CalculateAnnualSalary()
        {
            decimal houseRent = 0.20m * BasicSalary;
            decimal specialAllowance = 0.10m * BasicSalary;
            decimal total = houseRent + specialAllowance;


            if (ExperienceInYears >= 5)
            {
                total += 50000;
            }

            return total ;


        }

        public new string DisplayDetails()
        {
            return $"Employee Id= {EmployeeId}, Employee Name= {EmployeeName},Basic Salary={BasicSalary}, Experince in Years ={ExperienceInYears} , AnnualSalary :{CalculateAnnualSalary()}";
        }
    }

    class ContractEmployee: Employee
    {
        public ContractEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears) : base(employeeId, employeeName, basicSalary, experienceInYears)
        {
        }

        public int ContractDurationInMonths { get; set; }

        public new decimal CalculateAnnualSalary()
        {
            decimal annualSalary = BasicSalary * 12;
            if (ContractDurationInMonths >= 12)
                { 
                annualSalary += 30000; 
            }

            return annualSalary;
        }
    }

    class InternEmployee : Employee
    {
        public InternEmployee(int employeeId, string employeeName, decimal basicSalary, int experienceInYears) : base(employeeId, employeeName, basicSalary, experienceInYears)
        {
        }

        public new decimal CalculateAnnualSalary()
        {
            return BasicSalary*12; 
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1 = new PermanentEmployee(1,"HK",6500,6);
            PermanentEmployee emp2 = new PermanentEmployee(2,"Pk",6500,6);

            Console.WriteLine(emp1.DisplayDetails()); // Base method
            Console.WriteLine(emp2.DisplayDetails()); // Derived method

        }
    }
}

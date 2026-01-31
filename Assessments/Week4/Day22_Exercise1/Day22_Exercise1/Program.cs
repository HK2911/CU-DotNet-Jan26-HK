using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;

namespace Day22_Exercise1
{
    class Patient
    {
        public string Name { get; set; }

        public decimal BaseFee {  get; set; }

        public Patient(string name, decimal baseFee)
        {
            Name = name;
            BaseFee = baseFee;
        }

        public virtual decimal CalculateFinalBill()
        {
            return BaseFee;
        }
    }

    class Inpatient: Patient
    {

        public Inpatient(string name,int daysStayed,decimal dailyRate,decimal baseFee):base(name, baseFee)
        {
        DaysStayed = daysStayed;
        DailyRate = dailyRate;
        }
        public int DaysStayed { get; set; }

        public decimal DailyRate {  get; set; }

        public override decimal CalculateFinalBill() 
        {
            decimal total = BaseFee + (DaysStayed * DailyRate);
            return total;
        }


    }

    class EmergencyPatient: Patient 
    { 
      
        public EmergencyPatient(string name, decimal baseFee, int severityLevel):base(name,baseFee)
        {
            SeverityLevel = severityLevel;
        }

        public int SeverityLevel {  get; set; }
        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee*SeverityLevel ;
            return total;
        }

    }



    class Outpatient : Patient
    {
        public Outpatient(string name, decimal baseFee,decimal procedureFee) : base(name, baseFee)
        {
            ProcedureFee = procedureFee;
        }

        public decimal ProcedureFee { get; set; }
        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee + ProcedureFee;
        return total;
        }
    }

    class HospitalBilling
    {
        List<Patient> patients = new List<Patient>();
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public void GenerateDailyReport()
        {
            foreach (var p1 in patients)
            {
                decimal bill = p1.CalculateFinalBill(); // polymorphism
                Console.WriteLine($"{p1.Name} - {bill.ToString("C2")}");

            }
        }

        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;
            foreach (var p2 in patients)
            {
                total += p2.CalculateFinalBill();

            }
            return total;

        }

        public int GetInpatientCount()
        {
            int c = 0;
            foreach (var p in patients)
            {
                if (p is Inpatient)
                    c++;
            }
            return c;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalBilling h1 = new HospitalBilling();
            h1.AddPatient(new Inpatient("HK", 5, 2500m, 5000m));
            h1.AddPatient(new Outpatient("MK", 5000m, 3500m));
            h1.AddPatient(new EmergencyPatient("JK", 5000m, 4));

            Console.WriteLine("Daily Report");
            h1.GenerateDailyReport();


            Console.WriteLine($"Final Bill is {h1.CalculateTotalRevenue().ToString("C2")}");
            Console.WriteLine($"Inpatient Count is {h1.GetInpatientCount()}");
        }
    }
}

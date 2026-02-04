
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance1
{

    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }
        public decimal PrincipalAmount { get; set; }

        public int TenureInYear { get; set; }

        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0;
            TenureInYear = 0;
        }
        public Loan(string loanNumber, string customerName, decimal principalAmount, int tenureInYear)
        {
            LoanNumber = loanNumber;
            CustomerName = customerName;
            PrincipalAmount = principalAmount;
            TenureInYear = tenureInYear;
        }

        public decimal CalculateEMI()
        {
            decimal rate = 10m;
            decimal interest = (PrincipalAmount * rate * TenureInYear) / 100;
            decimal totalAmount = PrincipalAmount + interest;
            int months = TenureInYear * 12;
            return totalAmount / months;
        }
    }

    class HomeLoan : Loan
    {
        public HomeLoan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0;
            TenureInYear = 0;
        }
        public HomeLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
            : base(loanNumber, customerName, principalAmount, tenureInYears)
        {
        }

        public new decimal CalculateHomeLoanEMI()
        {
            decimal interest = (PrincipalAmount * 8 * TenureInYear) / 100;
            decimal processingFee = PrincipalAmount * 0.01m;
            decimal totalAmount = PrincipalAmount + interest + processingFee;
            int months = TenureInYear * 12;
            return totalAmount / months;
        }
    }

    class CarLoan : Loan
    {

        public CarLoan()
            {
             LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0;
            TenureInYear = 0;

            }
        public CarLoan(string loanNumber, string customerName, decimal principalAmount, int tenureInYears)
            : base(loanNumber, customerName, principalAmount, tenureInYears)
        {
        }

        public decimal CalculateCarLoanEMI()
        {
            decimal insuranceCharge = 15000m;
            decimal totalPrincipal = PrincipalAmount + insuranceCharge;

            decimal interest = (totalPrincipal * 9 * TenureInYear) / 100;
            decimal totalAmount = totalPrincipal + interest;

            int months = TenureInYear * 12;
            return totalAmount / months;
        }
    }
    internal class DemoLoan
    {

        static void Main(string[] args)
        {
            Loan[] loans = new Loan[]
            {
        new HomeLoan("HL1","A",500000m,5),
        new HomeLoan("HL2","B",600000m,10),
        new CarLoan("CL1","C",300000m,5),
        new CarLoan("CL2","D",400000m,7)
            };

            for (int i = 0; i < loans.Length; i++)
            {
                Console.WriteLine($"Calculated EMI's - {loans[i].CalculateEMI():f2}");
            }
        }

    }
}

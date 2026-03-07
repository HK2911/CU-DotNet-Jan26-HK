using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Day31_Exercise1
{
    class Transaction { public int Acc; public double Amount; public string Type; public DateTime Date; }
    internal class Question7
    {
        static void Main(String[] args)
        {
            var transactions = new List<Transaction>
            {
                new Transaction{Acc=101, Amount=5000, Type="Credit",Date=new DateTime(2026,1,10)},
                new Transaction{Acc=101, Amount=2000, Type="Debit",Date=new DateTime(2026,1,15)},
                new Transaction{Acc=102, Amount=10000, Type="Debit",Date=new DateTime(2026,2,20)}
            };

            var account = transactions.GroupBy(t=> t.Acc).Select(g=>new
            {
                Account=g.Key,
                TotalBalance = g.Sum(t => t.Type == "Credit" ? t.Amount : -t.Amount)
            });

            var suspicious = transactions
                .GroupBy(t => t.Acc)
                .Where(g =>
                g.Where(t => t.Type == "Debit").Sum(t => t.Amount) >
                g.Where(t => t.Type == "Credit").Sum(t => t.Amount)).Select(g => g.Key);

            Console.WriteLine("Suspiciouus accounts are");
            foreach(var v in suspicious)
            {
                Console.WriteLine(v);
            }

            var grpByMonth = transactions.GroupBy(g => g.Date.Month)
                .Select(g => new
                {
                    Month=g.Key,
                    Transactions = g.ToList()
                });

            foreach(var v in grpByMonth)
            {
                Console.WriteLine(v.Month);
            }
            var high = transactions
                .GroupBy(t => t.Acc)
                .Select(g => new
                {
                    Acc=g.Key,
                    Max=g.Max(t=>t.Amount)
                });
            Console.WriteLine("Highest Transaction per account");
            foreach(var v in high)
            {
                Console.WriteLine(v.Acc + " - " + v.Max);
            }

        }
    }
}

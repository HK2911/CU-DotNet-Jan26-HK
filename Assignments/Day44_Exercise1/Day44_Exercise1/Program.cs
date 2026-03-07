using System;
using System.Collections.Generic;
using System.Linq;

namespace Day44_Exercise1
{
    public abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public Subscriber(string name, DateTime joinDate)
        {
            ID = Guid.NewGuid();
            Name = name;
            JoinDate = joinDate;
        }

        public abstract decimal CalculateMonthlyBill();

        public override bool Equals(object obj)
        {
            return obj is Subscriber other && ID.Equals(other.ID);
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public int CompareTo(Subscriber other)
        {
            if (other == null) return 1;

            int dateComparison = JoinDate.CompareTo(other.JoinDate);
            if (dateComparison != 0)
                return dateComparison;

            return string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
    }

    public class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public BusinessSubscriber(string name, DateTime joinDate,
                                  decimal fixedRate, decimal taxRate)
            : base(name, joinDate)
        {
            FixedRate = fixedRate;
            TaxRate = taxRate;
        }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    public class ConsumerSubscriber : Subscriber
    {
        public decimal DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public ConsumerSubscriber(string name, DateTime joinDate,
                                  decimal dataUsageGB, decimal pricePerGB)
            : base(name, joinDate)
        {
            DataUsageGB = dataUsageGB;
            PricePerGB = pricePerGB;
        }

        public override decimal CalculateMonthlyBill()
        {
            return DataUsageGB * PricePerGB;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Subscriber> dict =
                new Dictionary<string, Subscriber>();

            dict.Add("hk12", new BusinessSubscriber("Hk",
                DateTime.Parse("2024-12-12"), 14000m, 0.18m));

            dict.Add("rk21", new ConsumerSubscriber("Rk",
                DateTime.Parse("2025-11-11"), 200m, 899m));

            dict.Add("mk45", new BusinessSubscriber("Mk",
                DateTime.Parse("2023-06-01"), 10000m, 0.12m));

            dict.Add("pk78", new ConsumerSubscriber("Pk",
                DateTime.Parse("2024-03-15"), 150m, 499m));

            dict.Add("sk99", new BusinessSubscriber("Sk",
                DateTime.Parse("2022-08-20"), 20000m, 0.15m));

            // Sort by Monthly Bill (Descending)
            var sorted = dict
                .OrderByDescending(x => x.Value.CalculateMonthlyBill())
                .ToList();

            Console.WriteLine("---- Monthly Bill Report ----");

            foreach (var item in sorted)
            {
                Console.WriteLine(
                    $"Email: {item.Key}, Name: {item.Value.Name}, " +
                    $"Bill: {item.Value.CalculateMonthlyBill():C}");
            }
        }
    }
}
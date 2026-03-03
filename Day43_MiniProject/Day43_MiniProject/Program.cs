
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    namespace Day43_MiniProject
{
        public interface IRiskAssessable
        {
            string GetRiskCategory();
        }

        public interface IReportable
        {
            string GenerateReportLine();
        }

        class InvalidFinancialDataException : Exception
        {
            public InvalidFinancialDataException(string message) : base(message) { }
        }

        public abstract class FinancialInstrument
        {
            private decimal _quantity;
            private decimal _purchasePrice;
            private decimal _marketPrice;
            private string _currency;

            public Guid InstrumentId { get; private set; }
            public string Name { get; set; }
            public DateTime PurchaseDate { get; set; }

            public decimal Quantity
            {
                get => _quantity;
                set
                {
                    if (value < 0) throw new InvalidFinancialDataException("Invalid Quantity");
                    _quantity = value;
                }
            }

            public decimal PurchasePrice
            {
                get => _purchasePrice;
                set
                {
                    if (value < 0) throw new InvalidFinancialDataException("Invalid Purchase Price");
                    _purchasePrice = value;
                }
            }

            public decimal MarketPrice
            {
                get => _marketPrice;
                set
                {
                    if (value < 0) throw new InvalidFinancialDataException("Invalid Market Price");
                    _marketPrice = value;
                }
            }

            public string Currency
            {
                get => _currency;
                set
                {
                    if (value.Length != 3) throw new InvalidFinancialDataException("Invalid Currency");
                    _currency = value.ToUpper();
                }
            }

            protected FinancialInstrument(string name, string currency, DateTime date,
                decimal quantity, decimal purchasePrice, decimal marketPrice)
            {
                InstrumentId = Guid.NewGuid();
                Name = name;
                Currency = currency;
                PurchaseDate = date;
                Quantity = quantity;
                PurchasePrice = purchasePrice;
                MarketPrice = marketPrice;
            }

            public abstract decimal CalculateCurrentValue();

            public virtual string GetInstrumentSummary()
            {
                return $"{Name} | {Currency} | {CalculateCurrentValue():C}";
            }
        }

        public class Equity : FinancialInstrument, IRiskAssessable, IReportable
        {
            public Equity(string name, string currency, DateTime date,
                decimal quantity, decimal purchasePrice, decimal marketPrice)
                : base(name, currency, date, quantity, purchasePrice, marketPrice) { }

            public override decimal CalculateCurrentValue()
                => Quantity * MarketPrice;

            public string GetRiskCategory() => "High";

            public string GenerateReportLine()
                => $"Equity - {Name} - {CalculateCurrentValue():C}";
        }

        public class Bond : FinancialInstrument, IRiskAssessable, IReportable
        {
            public decimal InterestRate { get; set; }

            public Bond(string name, string currency, DateTime date,
                decimal quantity, decimal purchasePrice, decimal marketPrice, decimal rate)
                : base(name, currency, date, quantity, purchasePrice, marketPrice)
            {
                InterestRate = rate;
            }

            public override decimal CalculateCurrentValue()
                => Quantity * MarketPrice;

            public string GetRiskCategory() => "Low";

            public string GenerateReportLine()
                => $"Bond - {Name} - {CalculateCurrentValue():C}";
        }

        public class FixedDeposit : FinancialInstrument, IRiskAssessable
        {
            public decimal InterestRate { get; set; }
            public int TenureInYears { get; set; }

            public FixedDeposit(string name, string currency, DateTime date,
                decimal quantity, decimal purchasePrice, decimal marketPrice,
                decimal rate, int tenure)
                : base(name, currency, date, quantity, purchasePrice, marketPrice)
            {
                InterestRate = rate;
                TenureInYears = tenure;
            }

            public override decimal CalculateCurrentValue()
                => Quantity * (1 + (InterestRate / 100) * TenureInYears);

            public string GetRiskCategory() => "Low";
        }

        public class MutualFund : FinancialInstrument, IRiskAssessable
        {
            public MutualFund(string name, string currency, DateTime date,
                decimal quantity, decimal purchasePrice, decimal marketPrice)
                : base(name, currency, date, quantity, purchasePrice, marketPrice) { }

            public override decimal CalculateCurrentValue()
                => Quantity * MarketPrice;

            public string GetRiskCategory() => "Medium";
        }

        public class Portfolio
        {
            private List<FinancialInstrument> instruments = new();
            private Dictionary<Guid, FinancialInstrument> lookup = new();

            public void AddInstrument(FinancialInstrument instrument)
            {
                if (lookup.ContainsKey(instrument.InstrumentId))
                    throw new Exception("Duplicate ID");
                instruments.Add(instrument);
                lookup[instrument.InstrumentId] = instrument;
            }

            public FinancialInstrument GetInstrumentById(Guid id)
                => lookup.ContainsKey(id) ? lookup[id] : null;

            public decimal GetTotalPortfolioValue()
                => instruments.Sum(i => i.CalculateCurrentValue());

            public IEnumerable<FinancialInstrument> GetInstrumentsByRisk(string risk)
                => instruments.OfType<IRiskAssessable>()
                    .Where(i => i.GetRiskCategory() == risk)
                    .Cast<FinancialInstrument>();

            public IEnumerable<IGrouping<string, FinancialInstrument>> GroupByType()
                => instruments.GroupBy(i => i.GetType().Name);

            public List<FinancialInstrument> GetAll() => instruments;
        }

        public class Transaction
        {
            public Guid TransactionId { get; set; }
            public Guid InstrumentId { get; set; }
            public string Type { get; set; }
            public decimal Units { get; set; }
            public DateTime Date { get; set; }

            public Transaction()
            {
                TransactionId = Guid.NewGuid();
            }
        }

        public class ReportGenerator
        {
            public static void GenerateConsoleReport(Portfolio portfolio)
            {
                Console.WriteLine("===== PORTFOLIO SUMMARY =====");

                foreach (var group in portfolio.GroupByType())
                {
                    decimal totalInvestment = group.Sum(i => i.PurchasePrice * i.Quantity);
                    decimal currentValue = group.Sum(i => i.CalculateCurrentValue());

                    Console.WriteLine($"\nInstrument Type: {group.Key}");
                    Console.WriteLine($"Total Investment: {totalInvestment:C}");
                    Console.WriteLine($"Current Value: {currentValue:C}");
                    Console.WriteLine($"Profit/Loss: {(currentValue - totalInvestment):C}");
                }

                Console.WriteLine($"\nOverall Portfolio Value: {portfolio.GetTotalPortfolioValue():C}");
            }

            public static void GenerateFileReport(Portfolio portfolio)
            {
                string fileName = $"PortfolioReport_{DateTime.Now:yyyyMMdd}.txt";

                using StreamWriter sw = new StreamWriter(fileName);
                sw.WriteLine("PORTFOLIO REPORT");
                sw.WriteLine($"Generated On: {DateTime.Now}");
                sw.WriteLine("--------------------------------");

                foreach (var instrument in portfolio.GetAll())
                    sw.WriteLine(instrument.GetInstrumentSummary());

                sw.WriteLine("--------------------------------");
                sw.WriteLine($"Total Value: {portfolio.GetTotalPortfolioValue():C}");
            }
        }

        class Program
        {
            static void Main()
            {
                Portfolio portfolio = new Portfolio();

                var eq = new Equity("INFY", "INR", DateTime.Now, 100, 1500, 1650);
                var bond = new Bond("GSEC", "INR", DateTime.Now, 50, 1000, 1020, 6);
                var fd = new FixedDeposit("HDFC FD", "INR", DateTime.Now, 200000, 1, 1, 7, 3);
                var mf = new MutualFund("SBI MF", "INR", DateTime.Now, 300, 500, 550);

                portfolio.AddInstrument(eq);
                portfolio.AddInstrument(bond);
                portfolio.AddInstrument(fd);
                portfolio.AddInstrument(mf);

                Transaction[] transactionArray = new Transaction[2];

                transactionArray[0] = new Transaction
                {
                    InstrumentId = eq.InstrumentId,
                    Type = "Buy",
                    Units = 20,
                    Date = DateTime.Now
                };

                transactionArray[1] = new Transaction
                {
                    InstrumentId = bond.InstrumentId,
                    Type = "Sell",
                    Units = 10,
                    Date = DateTime.Now
                };

                List<Transaction> transactions = transactionArray.ToList();

                foreach (var t in transactions)
                {
                    var instrument = portfolio.GetInstrumentById(t.InstrumentId);
                    if (instrument == null) continue;

                    if (t.Type == "Sell" && instrument.Quantity < t.Units)
                        throw new Exception("Insufficient Units");

                    instrument.Quantity += t.Type == "Buy" ? t.Units : -t.Units;
                }

                ReportGenerator.GenerateConsoleReport(portfolio);
                ReportGenerator.GenerateFileReport(portfolio);
            }
        }
    }

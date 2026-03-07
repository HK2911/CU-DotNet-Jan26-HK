namespace Day19_Exercise2
{
    public abstract class UtilityBill
     {
        protected UtilityBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit)
        {
            ConsumerId = consumerId;
            ConsumerName = consumerName;
            UnitsConsumed = unitsConsumed;
            RatePerUnit = ratePerUnit;

        }

        public int ConsumerId {  get; set; }
        public string ConsumerName { get; set; }

        public decimal UnitsConsumed {  get; set; }

        public decimal RatePerUnit {  get; set; }

        public abstract decimal CalculateBillAmount();

        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount*0.05m;
        }

        public void PrintBill()
        {
            decimal billAmount = CalculateBillAmount();
            decimal tax = CalculateTax(billAmount);
            decimal total = billAmount + tax;

            Console.WriteLine($"Consumer Id   : {ConsumerId}");
            Console.WriteLine($"Consumer Name : {ConsumerName}");
            Console.WriteLine($"Units Used    : {UnitsConsumed}");
            Console.WriteLine($"Bill Amount   : {billAmount}");
            Console.WriteLine($"Tax           : {tax}");
            Console.WriteLine($"Total Payable : {total:f2}");
            Console.WriteLine("-----------------------------");
        }
    }

    class ELectricityBill: UtilityBill
    {
        public ELectricityBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit):base(consumerId,  consumerName,  unitsConsumed,  ratePerUnit)
        {
        }

        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;

            if (UnitsConsumed > 300)
            {
                billAmount += billAmount * 0.10m; // 10% surcharge
            }

            return billAmount;
        }

    }

    class WaterBill: UtilityBill
    {
        public WaterBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit) : base(consumerId, consumerName, unitsConsumed, ratePerUnit)
        {
        }
        public override decimal CalculateBillAmount() 
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            return billAmount;

        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m; 
        }



    }

    class GasBill : UtilityBill
    {
        public GasBill(int consumerId, string consumerName, decimal unitsConsumed, decimal ratePerUnit) : base(consumerId, consumerName, unitsConsumed, ratePerUnit)
        {
        }
        public override decimal CalculateBillAmount()
        {
            decimal billAmount = UnitsConsumed * RatePerUnit;
            billAmount += 150;
            return billAmount;

        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return 0; 
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<UtilityBill> u1 = new List<UtilityBill>
            {
                new ELectricityBill(101,"HK",250,2),
                new WaterBill(102,"JK",350,5),
                new GasBill(103,"MK",150,4)
            };

            foreach (UtilityBill bill in u1) 
            {
                bill.PrintBill();
            }

        }
    }
}

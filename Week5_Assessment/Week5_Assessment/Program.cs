namespace Week5_Assessment
{
    public class RestrictedDestinationException:Exception
    {
        public RestrictedDestinationException(string destination)
            : base($"Shipment destination '{destination}' is restricted.")
        {
        }

    }

    public class InsecurePackagingException : Exception
    {
        public InsecurePackagingException()
            : base("Fragile shipment must have reinforced packaging.")
        {
        }
    }

    public interface ILoggable
    {
        void SaveLog()
        { string message; }
    }
    public class LogManager : ILoggable
    {
        private readonly string filePath = "shipment_audit.log";

        public void SaveLog(string message)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }




    public abstract class Shipment
    {
        public string TrackingId {  get; set; }
        public double Weight {  get; set; }
        public string Destination { get; set; }


        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }

        protected static readonly List<string> RestrictedZones =
            new List<string> { "North Pole", "Unknown Island" };


        public Shipment(string trackingId,double weight,string destination)
        {
            TrackingId= trackingId;
            Weight = weight;
            Destination = destination;
        }

        protected void ValidateRules()
        {
            if (Weight <= 0)
                throw new ArgumentOutOfRangeException("Weight", "Weight must be greater than zero.");

            if (RestrictedZones.Contains(Destination))
                throw new RestrictedDestinationException(Destination);

            if (IsFragile && !IsReinforced)
                throw new InsecurePackagingException();
        }

        public abstract void ProcessShipment();


    }



    public class ExpressShipment : Shipment
    {
        public ExpressShipment(string trackingId, double weight, string destination)
            : base(trackingId, weight, destination)
        {
        }

        public override void ProcessShipment()
        {
            ValidateRules();
            Console.WriteLine($"Express shipment {TrackingId} processed successfully.");
        }
    }


    public class HeavyFreight : Shipment
    {
        public bool HasHeavyLiftPermit { get; set; }

        public HeavyFreight(string trackingId, double weight, string destination, bool permit)
            : base(trackingId, weight, destination)
        {
            HasHeavyLiftPermit = permit;
        }

        public override void ProcessShipment()
        {
            ValidateRules();

            if (Weight > 1000 && !HasHeavyLiftPermit)
                throw new Exception("Heavy Lift permit required for shipments over 1000kg.");

            Console.WriteLine($"Heavy freight {TrackingId} processed successfully.");
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager logger = new LogManager();

            List<Shipment> shipments = new List<Shipment>
            {
                new ExpressShipment("EXP001", 25, "Delhi"),

                new ExpressShipment("EXP002", -5, "Mumbai"),

                new ExpressShipment("EXP003", 10, "North Pole")
                {
                    IsFragile = true,
                    IsReinforced = false
                },

                new HeavyFreight("HF001", 1500, "Chennai", false),

                new HeavyFreight("HF002", 2000, "Kolkata", true)
            };

            foreach (Shipment shipment in shipments)
            {
                try
                {
                    shipment.ProcessShipment();
                    logger.SaveLog($"SUCCESS: Shipment {shipment.TrackingId} processed.");
                }
                catch (RestrictedDestinationException ex)
                {
                    logger.SaveLog($"SECURITY ALERT: {ex.Message}");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.SaveLog($"DATA ENTRY ERROR: {ex.Message}");
                }
                catch (Exception ex)
                {
                    logger.SaveLog($"GENERAL ERROR: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"Processing attempt finished for ID: {shipment.TrackingId}");
                }
            }

            Console.WriteLine("\nAll shipments processed.");
            Console.WriteLine("Check 'shipment_audit.log' for audit details.");
        }
    }
}

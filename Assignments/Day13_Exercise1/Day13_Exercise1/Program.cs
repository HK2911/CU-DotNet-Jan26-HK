namespace Day13_Exercise1
{
   
        class GymMembership
        {
            static decimal CalculateMembershipAmount(bool treadmill, bool weightLifting, bool zumba)
            {
                decimal total = 1000;

                bool anyService = false;

                if (treadmill)
                {
                    total += 300;
                    anyService = true;
                }

                if (weightLifting)
                {
                    total += 500;
                    anyService = true;
                }

                if (zumba)
                {
                    total += 250;
                    anyService = true;
                }

                if (!anyService)
                {
                    total += 200;
                }

                decimal gst = total * 0.05m;
                total += gst;

                return total;
            }

            internal class Program
            {
                static void Main()
                {
                    decimal amount1 = CalculateMembershipAmount(true, false, true);
                    Console.WriteLine("Total Amount: " + amount1);

                    decimal amount2 = CalculateMembershipAmount(false, false, false);
                    Console.WriteLine("Total Amount: " + amount2);
                }
            }
        }
    }
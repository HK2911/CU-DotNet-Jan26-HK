using System.Net;

namespace Day21_Exercise1
{
    internal class Program
    {
        class Policy
        {
            public string HolderName { get; set; }
            public decimal Premium { get; set; }

            public int RiskScore { get; set; }

            public DateTime RenewalDate { get; set; }

            public override string ToString()
            {
                return $"Holder name= {HolderName} Premium = {Premium} Risk Score = {RiskScore} Renewal date= {RenewalDate}";
            }
        }

        class Insurance
        {
            Dictionary<string, Policy> PolicyHolder = new Dictionary<string, Policy>();
            public void AddPolicy(string policyId, Policy policy)
            {
                PolicyHolder[policyId] = policy;
            }

            public void BulkAdjustment()
            {
                foreach (var p in PolicyHolder.Values)
                {
                    if (p.RiskScore > 75)
                    {
                        p.Premium += (p.Premium * 0.05m);

                    }
                }
            }

            public void CleanUp()
            {
                List<string> keysToRemove = new List<string>();

                foreach (var item in PolicyHolder)
                {
                    if (item.Value.RenewalDate < DateTime.Now.AddYears(-3))
                    {
                        keysToRemove.Add(item.Key);
                    }
                }

                foreach (var key in keysToRemove)
                {
                    PolicyHolder.Remove(key);
                }
            }


            public string SecurityCheck(string policyId)
            {
                if (PolicyHolder.TryGetValue(policyId, out Policy policy))
                {
                    return policy.ToString();
                }
                else
                {
                    return ("Not Found");
                }

            }
        }

        static void Main(string[] args)
        {
            Insurance ins = new Insurance();
            ins.AddPolicy("P101", new Policy
            {
                HolderName = "HK",
                Premium = 10000m,
                RiskScore = 80,
                RenewalDate = DateTime.Now.AddYears(-1)
            });

            ins.AddPolicy("P102", new Policy
            {
                HolderName="MK",
                Premium=12000m,
                RiskScore=70,
                RenewalDate= DateTime.Now.AddYears(-2)

            });

            ins.AddPolicy("P103", new Policy
            {
                HolderName = "AK",
                Premium = 15000m,
                RiskScore = 90,
                RenewalDate = DateTime.Now
            });
            

            Console.WriteLine("Before Bulk Adjustment:");
            Console.WriteLine(ins.SecurityCheck("P101"));
            Console.WriteLine(ins.SecurityCheck("P102"));
            Console.WriteLine(ins.SecurityCheck("P103"));

            ins.BulkAdjustment();
            ins.CleanUp();

            Console.WriteLine("\nAfter Bulk Adjustment and Clean-Up:");
            Console.WriteLine(ins.SecurityCheck("P101"));
            Console.WriteLine(ins.SecurityCheck("P102"));
            Console.WriteLine(ins.SecurityCheck("P103"));
        }
        }
    }


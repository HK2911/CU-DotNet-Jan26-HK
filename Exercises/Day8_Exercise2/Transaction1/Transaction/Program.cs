namespace Transaction
{
        internal class Program
        {
            static void Main(string[] args)
            {
                
                string input = Console.ReadLine();

                string[] parts = input.Split('#');

                string transactionId = parts[0];
                string accountHolder = parts[1];
                string narration = parts[2];

             
                narration = narration.Trim();

                while (narration.Contains("  "))
                {
                    narration = narration.Replace("  ", " ");
                }

                narration = narration.ToLower();

                bool hasDeposit = narration.Contains("deposit");
                bool hasWithdrawal = narration.Contains("withdrawal");
                bool hasTransfer = narration.Contains("transfer");

                bool hasKeyword = hasDeposit || hasWithdrawal || hasTransfer;

                string standardNarration = "cash deposit successful";
                bool isStandard = narration.Equals(standardNarration);

                string category;

                if (!hasKeyword)
                {
                    category = "NON-FINANCIAL TRANSACTION";
                }
                else if (hasKeyword && isStandard)
                {
                    category = "STANDARD TRANSACTION";
                }
                else
                {
                    category = "CUSTOM TRANSACTION";
                }

                Console.WriteLine($"{"Transaction ID".PadRight(15)}: {transactionId}");
                Console.WriteLine($"{"Account Holder".PadRight(15)}: {accountHolder}");
                Console.WriteLine($"{"Narration".PadRight(15)}: {narration}");
                Console.WriteLine($"{"Category".PadRight(15)}: {category}");
            }
        }
}

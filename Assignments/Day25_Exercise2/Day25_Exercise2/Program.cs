namespace CricketTeam
{

    class Player
    {
        public String Name { get; set; }
        public int RunsScored { get; set; }
        public int BallsFaced { get; set; }
        public bool IsOut { get; set; }
        public double StrikeRate { get; set; }
        public double Average { get; set; }

        public Player(string n, int run, int b, bool o)
        {
            Name = n;
            RunsScored = run;
            BallsFaced = b;
            IsOut = o;
            StrikeRate = (double)RunsScored * 100 / BallsFaced;
            if (IsOut) Average = RunsScored;
            else Average = RunsScored;
        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                string[] strings =
              {
                "Steve Smith,84,90,True",
                "Virat Kohli,29,35,false",
                "Joe Root,110,120,True"
                };

                string fileName = @"..\..\..\players.csv";
                File.WriteAllLines(fileName, strings);


                string[] strings1 = new string[3];
                strings1 = File.ReadAllLines(fileName);
                string[] splitString1 = strings1[0].Split(',');
                string[] splitString2 = strings1[1].Split(',');
                string[] splitString3 = strings1[2].Split(',');

                List<Player> o = new List<Player>
                {
                    new Player(splitString1[0],int.Parse(splitString1[1]),int.Parse(splitString1[2]),bool.Parse(splitString1[3])),
                    new Player(splitString2[0],int.Parse(splitString2[1]),int.Parse(splitString2[2]),bool.Parse(splitString2[3])),
                    new Player(splitString3[0],int.Parse(splitString3[1]),int.Parse(splitString3[2]),bool.Parse(splitString3[3]))
                };
                for (int i = 0; i < 3; i++)
                {
                    if (o[i].BallsFaced < 10) o.Remove(o[i]);
                }
                o.Sort((a, b) => b.StrikeRate.CompareTo(a.StrikeRate));
                Console.WriteLine("Name          Runs         SR        Avg");
                Console.WriteLine("-----------------------------------------");
                foreach (Player p in o)
                {
                    Console.WriteLine($"{p.Name,-15}{p.RunsScored,-5}{p.StrikeRate,10:f2}{p.Average,10:f2}");
                }

            }
            catch (FileNotFoundException f)
            {
                Console.WriteLine(f.Message);
            }
            catch (FormatException fo)
            {
                Console.WriteLine(fo.Message);
            }
            catch (DivideByZeroException d)
            {
                Console.WriteLine(d.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
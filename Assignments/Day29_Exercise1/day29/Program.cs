using System.Runtime.InteropServices;

namespace Kitchen
{
    abstract class KitchenAppliance
    {
        public string ModelName { get; set; }

        public int ElecticVolt { get; set; }

        public decimal Price { get; set; }
        public abstract void Cook();

        public KitchenAppliance(string modelName, int volt, decimal price)
        {
            ModelName = modelName;
            ElecticVolt = volt;
            Price = price;
        }

        public void show()
        {
            Console.WriteLine($"The {ModelName} is being used ");
            Console.WriteLine($"It is consuming {ElecticVolt} volts ");
            Console.WriteLine($"Its price is {Price}");
        }

    }

    interface ITimer
    {
        public void setTime(int min)
        {
            Console.WriteLine($"Time taken to cook is {min} minutes");
        }
    }

    interface ISmart
    {
        public void CheckSmart(bool b)
        {
            if (b)
                Console.WriteLine($"Yes device is smart");
        }
    }


    class Microwave : KitchenAppliance, ITimer
    {
        public Microwave(string modelName, int volt, decimal price) : base(modelName, volt, price)
        {
        }

        public override void Cook()
        {
            Console.WriteLine("Cooking in microwave");
        }

        public void setTimer(int mins)
        {
            Console.WriteLine($"Time given is {mins} minutes");
        }
        public void ConnectWifi()
        {
            Console.WriteLine("Wifi assisted");
        }
        public void preHeat()
        {
            Console.WriteLine($"{ModelName}is pre-heated");
        }
    }

    class Kettle : KitchenAppliance
    {
        public Kettle(string modelName, int volt, decimal price) : base(modelName, volt, price)
        {
        }

        public override void Cook()
        {
            Console.WriteLine("Cooking in microwave");
        }


    }

    class AirFryer : KitchenAppliance, ITimer
    {
        public AirFryer(string modelName, int volt, decimal price) : base(modelName, volt, price)
        {

        }

        public override void Cook()
        {
            Console.WriteLine("Cooking in microwave");
        }

        public void setTimer(int mins)
        {
            Console.WriteLine($"Time given is {mins} minutes");
        }
    }

    class Owen : KitchenAppliance, ITimer, ISmart
    {
        public Owen(string modelName, int volt, decimal price) : base(modelName, volt, price)
        {
        }

        public override void Cook()
        {
            Console.WriteLine("Cooking in microwave");
        }

        public void setTimer(int mins)
        {
            Console.WriteLine($"Time given is {mins} minutes");
        }

        public void IsSmart(bool b)
        {
            if (b)
                Console.WriteLine($"{ModelName} is smart");
        }

        public void preHeat()
        {
            Console.WriteLine($"{ModelName} is preheated");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenAppliance> l1 = new List<KitchenAppliance>()
            {
                new Microwave("Bajaj",65,8000),
                new Kettle("Pigeon",25,1500),
                new Owen("LG",30,6000),
                new AirFryer("Prestige",45,7500)

            };

            foreach (var v in l1)
            {
                if (v is Microwave)
                {
                    Microwave m1 = new Microwave("Bajaj", 65, 8000);
                    m1.setTimer(5);
                    m1.preHeat();
                    m1.ConnectWifi();
                    m1.Cook();
                    m1.show();
                    Console.WriteLine("-----------------------------------");
                }

                else if (v is AirFryer)
                {
                    AirFryer a1 = new AirFryer("Prestige", 45, 7500);
                    a1.setTimer(5);
                    a1.Cook();
                    a1.show();
                    Console.WriteLine("-----------------------------------");
                }
                else if (v is Owen)
                {
                    Owen o1 = new Owen("LG", 30, 6000);
                    o1.Cook();
                    o1.setTimer(10);
                    o1.IsSmart(true);
                    o1.preHeat();
                    o1.show();
                    Console.WriteLine("-----------------------------------");

                }
                else
                {
                    v.show();
                    v.Cook();
                    Console.WriteLine("-----------------------------------");
                }
            }
        }
    }
}



namespace Day19_Exercise1
{

    abstract class Vehicle
    {
        public Vehicle(string modelName)
        {
            ModelName = modelName;
        }

        public string ModelName { get; set; }

        public abstract void Move();

        public virtual string GetFuelStatus()
        {
            return "Fuel level is stable.";
        }

    }

    class ElectricCar : Vehicle
    {
        public ElectricCar(string ModelName) : base(ModelName) { }
        public override void Move() 
        {
            Console.WriteLine(ModelName+ " is gliding silently on battery power");
        }

        public override string GetFuelStatus()
        {
            return (ModelName+ " battery is at 80%");
        }
    }


    class HeavyTruck : Vehicle
    {
        public HeavyTruck(string ModelName) : base(ModelName) { }
        public override void Move()
        {
            Console.WriteLine(ModelName + " is hauling cargo with high-torque diesel power");
        }
    }

    class CargoPlane : Vehicle
    {
        public CargoPlane(string ModelName) : base(ModelName) { }
        public override void Move()
        {
            Console.WriteLine(ModelName + " is ascending to 30,000 feet.");
        }

        public override string GetFuelStatus()
        {
            
            return base.GetFuelStatus()+ "Checking jet fuel reserves"; 
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] v1 =
        {   
            new ElectricCar("Car"),
            new HeavyTruck("Truck"),
            new CargoPlane("Plane")
        };

            for (int i=0;i<v1.Length;i++)
            {
                v1[i].Move();
                Console.WriteLine(v1[i].GetFuelStatus());

            }
        }
    }
}

namespace CorrectVehicles2
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] carInput;
            double carInitialFuel;
            Initiatevehicle(out carInput, out carInitialFuel);
            Car car = new Car(carInitialFuel, double.Parse(carInput[2]), int.Parse(carInput[3]));


            string[] truckInput;
            double truckInitialFuel;
            Initiatevehicle(out truckInput, out truckInitialFuel);
            Truck truck = new Truck(truckInitialFuel, double.Parse(truckInput[2]), int.Parse(truckInput[3]));


            string[] busInput;
            double busInitialFuel;
            Initiatevehicle(out busInput, out busInitialFuel);
            Bus bus = new Bus(busInitialFuel, double.Parse(busInput[2]), int.Parse(busInput[3]));

            IterateInput(car, truck, bus);

            car.PrintFuelQty();
            truck.PrintFuelQty();
            bus.PrintFuelQty();
        }

        private static void Initiatevehicle(out string[] carInput, out double carInitialFuel)
        {
            carInput = ReadInputString();
            carInitialFuel = double.Parse(carInput[1]);
            if (carInitialFuel > int.Parse(carInput[3]))
            {
                carInitialFuel = 0;
            }
        }

        private static void IterateInput(Car car, Truck truck, Bus bus)
        {

            int counter = int.Parse(Console.ReadLine());

            for (int i = 0; i < counter; i++)
            {
                string[] driveInput = ReadInputString();

                string action = driveInput[0];
                string vehicle = driveInput[1];

                if (action == "Drive")
                {
                    double distance = double.Parse(driveInput[2]);

                    if (vehicle == "Car")
                    {
                        car.Drive(distance);
                    }

                    else if (vehicle == "Truck")
                    {
                        truck.Drive(distance);
                    }

                    else if (vehicle == "Bus")
                    {
                        bus.Drive(distance);
                    }
                }

                else if (action == "Refuel")
                {
                    double liters = double.Parse(driveInput[2]);

                    if (vehicle == "Car")
                    {
                        car.Refuel(liters);
                    }

                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(liters);
                    }

                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(liters);
                    }
                }

                else if (action == "DriveEmpty" && vehicle == "Bus")
                {

                    double distance = double.Parse(driveInput[2]);

                    bus.DriveEmptyBus(distance);

                }
            }
        }

        private static string[] ReadInputString()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}


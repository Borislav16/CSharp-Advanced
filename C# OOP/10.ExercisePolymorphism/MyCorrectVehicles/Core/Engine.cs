using MyCorrectVehicles.IO.Interfaces;
using MyCorrectVehicles.Model;
using MyCorrectVehicles.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCorrectVehicles.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            vehicles = new List<IVehicle>();
        }
        public void Run()
        {
            string[] carTokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            vehicles.Add(new Car (double.Parse(carTokens[1]), double.Parse(carTokens[2])));


            string[] truckTokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            vehicles.Add(new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2])));

            int commandsCount = int.Parse(reader.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }

        private void ProcessCommand()
        {
            string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commandTokens[0];
            string vehicleType = commandTokens[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type");
            }

            if (command == "Drive")
            {
                double distance = double.Parse(commandTokens[2]);
                writer.WriteLine(vehicle.Drive(distance));
            }
            else if (command == "Refuel")
            {
                double fuelAmount = double.Parse(commandTokens[2]);
                vehicle.Refuel(fuelAmount);
            }
        }
    }

}

using VehiclesExtension.Core;
using VehiclesExtension.Factories;
using VehiclesExtension.IO;
using VehiclesExtension.IO.Interfaces;

namespace VehiclesExtension
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IVehicleFactory vehicleFactory = new VehicleFactory();

            IEngine engine = new Engine(reader, writer, vehicleFactory);

            engine.Run();
        }
    }
}
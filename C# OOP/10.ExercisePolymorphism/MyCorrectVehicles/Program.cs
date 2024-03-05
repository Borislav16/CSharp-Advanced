using MyCorrectVehicles.IO.Interfaces;
using MyCorrectVehicles.IO;
using MyCorrectVehicles.Core;

namespace MyCorrectVehicles
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEngine engine = new Engine(reader, writer);

            engine.Run();
        }
    }
}
using Raiding.Core;
using Raiding.Factories;
using Raiding.IO;
using Raiding.IO.Interfaces;
using Raiding.Factories;

namespace Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IFactory heroFactory = new Factory();

            IEngine engine = new Engine(reader, writer, heroFactory);

            engine.Run();
        }
    }
}
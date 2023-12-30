using System;
using System.Linq;

namespace _02._KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = n => Console.WriteLine($"Sir {n}");

            string[] names = Console.ReadLine()
                .Split(" ")
                .ToArray();
            foreach (var name in names)
            {
                action(name);
            }
        }
    }
}

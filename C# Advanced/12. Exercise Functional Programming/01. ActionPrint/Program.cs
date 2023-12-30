using System;
using System.Linq;

namespace _01._ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = n => Console.WriteLine(n);

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

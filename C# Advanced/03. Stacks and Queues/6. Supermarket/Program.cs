using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>();
            string input = Console.ReadLine();
            while(input != "End")
            {
                if(input != "Paid")
                {
                    names.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                while(names.Count > 0)
                {
                    Console.WriteLine(names.Dequeue());
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{names.Count} people remaining.");
        }
    }
}

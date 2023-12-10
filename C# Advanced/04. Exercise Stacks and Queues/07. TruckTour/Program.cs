using System;
using System.Linq;

namespace _07._TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int index = -1;
            int petrolAmount = 0;
            int distance = 0;
            for (int i = 0; i < n; i++)
            {
                int[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                petrolAmount += command[0];
                distance += command[1];
                if (petrolAmount >= distance && index == -1)
                {
                    index = i;
                    continue;
                }
                else if (petrolAmount >= distance && index != -1)
                {
                    continue;
                }
                else
                {
                    index = -1;
                    petrolAmount = 0;
                    distance = 0;
                }
            }
            Console.WriteLine(index);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] count = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();

            for (int i = 0; i < count[0]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                set1.Add(number);
            }
            for (int i = 0; i < count[1]; i++)
            {
                int number = int.Parse(Console.ReadLine());
                set2.Add(number);
            }

            set1.IntersectWith(set2);

            Console.WriteLine(string.Join(" ", set1));
        }
    }
}

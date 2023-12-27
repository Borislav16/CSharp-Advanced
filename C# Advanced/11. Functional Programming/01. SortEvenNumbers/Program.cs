using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            Console.WriteLine(string.Join(", ",numbers.Where(x => x % 2 == 0)
                .OrderBy(x => x)));
        }
    }
}

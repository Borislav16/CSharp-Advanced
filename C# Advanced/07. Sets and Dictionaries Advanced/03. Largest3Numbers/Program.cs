using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            numbers = numbers.OrderByDescending(x => x).ToList();
            if(numbers.Count < 3 )
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            
            }
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{numbers[i]} ");
            }
        }
    }
}

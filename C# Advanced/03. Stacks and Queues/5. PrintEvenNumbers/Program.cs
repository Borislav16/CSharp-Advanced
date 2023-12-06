using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new Queue<int>(nums);
            string result = string.Empty;
            while (numbers.Count > 0)
            {
                int number = numbers.Dequeue();

                if(number % 2 == 0)
                {
                    result += $"{number}, ";

                }
            }

            Console.WriteLine(result.TrimEnd(' ', ','));
        }
    }
}

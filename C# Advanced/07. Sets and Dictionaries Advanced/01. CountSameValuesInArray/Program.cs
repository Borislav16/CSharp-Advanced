using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Dictionary<double, int> count = new Dictionary<double, int>();
            foreach (var num in numbers)
            {
                if(!count.ContainsKey(num))
                {
                    count.Add(num, 0);
                }
                count[num]++;
            }

            foreach (var item in count)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}

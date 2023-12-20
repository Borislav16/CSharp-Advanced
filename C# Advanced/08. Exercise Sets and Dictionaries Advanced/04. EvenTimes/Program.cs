using System;
using System.Collections.Generic;

namespace _04._EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int,int> numbers = new Dictionary<int,int>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int givenNum = int.Parse(Console.ReadLine());
                if(!numbers.ContainsKey(givenNum))
                {
                    numbers.Add(givenNum, 0);
                }
                numbers[givenNum]++;
            }

            foreach (var item in numbers)
            {
                if(item.Value % 2 == 0)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
}

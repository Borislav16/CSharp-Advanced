using System;
using System.Collections.Generic;

namespace _01._UniqueUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                set.Add(name);
            }

            foreach (var item in set)
            {
                Console.WriteLine(item);
            }
        }
    }
}

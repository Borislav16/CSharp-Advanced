using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            HashSet<string> set1 = new HashSet<string>();
            HashSet<string> set2 = new HashSet<string>();
            for (int i = 0; i < count; i++)
            {
                if (i == 0 || i % 2 == 0)
                {
                    string[] array = Console.ReadLine().Split();
                    foreach (var item in array)
                    {
                        set1.Add(item);
                    }
                }
                else
                {
                    string[] array = Console.ReadLine().Split();
                    foreach (var item in array)
                    {
                        set2.Add(item);
                    }
                    set2.UnionWith(set1);
                    set1 = new HashSet<string>();
                }
            }
            if(set1.Count > 0)
            {
                set2.UnionWith(set1);
            }
            Console.WriteLine(string.Join(" ", set2.OrderBy(x => x)));
        }
    }
}

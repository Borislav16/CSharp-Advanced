using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> chars = new SortedDictionary<char, int>();
            string text = Console.ReadLine();
            foreach (char c in text)
            {
                if(!chars.ContainsKey(c))
                {
                    chars.Add(c, 0);
                }
                chars[c]++;
            
            }
            foreach (var item in chars)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }

        }
    }
}

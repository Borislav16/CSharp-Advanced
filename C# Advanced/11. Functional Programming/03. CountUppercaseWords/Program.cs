using System;
using System.Linq;

namespace _03._CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> func = w => char.IsUpper(w[0]);
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] upperCase = words.Where(func)
                .ToArray();
            Console.WriteLine(string.Join("\n", upperCase));
                
        }
    }
}

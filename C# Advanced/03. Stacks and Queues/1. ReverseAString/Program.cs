using System;
using System.Collections.Generic;

namespace _1._ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> text = new Stack<char>(); 

            foreach (var item in input)
            {
                text.Push(item);
            }
            Console.WriteLine(string.Join("",text));
        }
    }
}

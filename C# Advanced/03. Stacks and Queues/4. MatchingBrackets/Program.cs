using System;
using System.Collections.Generic;

namespace _4._MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    indexes.Push(i);

                }
                else if (input[i] == ')')
                {
                    int startIndex = indexes.Pop();
                    string substring = input.Substring(startIndex, (i - startIndex) + 1);
                    Console.WriteLine(substring);
                }
            }
        }
    }
}

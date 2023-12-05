using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> expression = new Stack<string>(input.Reverse());

            int result = int.Parse(expression.Pop());
            while(expression.Count > 0)
            {
                string sign = expression.Pop();
                int number = int.Parse(expression.Pop());
                if (sign == "-")
                {
                    result -= number;
                }
                else if (sign == "+")
                {
                    result += number;
                }

            }
            Console.WriteLine(result);
        }
    }
}

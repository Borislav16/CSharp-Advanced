using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>();
            int elementsToPush = commands[0];
            int elementsToPop = commands[1];
            int number = commands[2];

            for (int i = 0; i < elementsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if(stack.Contains(number))
            {
                Console.WriteLine("true");
                return;
            }

            if(stack.Any())
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}

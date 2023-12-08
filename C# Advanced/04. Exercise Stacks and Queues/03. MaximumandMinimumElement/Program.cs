using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MaximumandMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "1")
                {
                    stack.Push(int.Parse(command[1]));
                }
                else if (command[0] == "2")
                {
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                }
                else if (command[0] == "3")
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (command[0] == "4")
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }

            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}

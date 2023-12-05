using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> stack = new Stack<int>(input);
            string command = Console.ReadLine().ToLower();
            while(command != "end")
            {
                string[] commandInfo = command.Split(' ');
                if (commandInfo[0] == "add")
                {
                    int n1 = int.Parse(commandInfo[1]);
                    int n2 = int.Parse(commandInfo[2]);
                    stack.Push(n1);
                    stack.Push(n2);
                }
                else if (commandInfo[0] == "remove")
                {
                    int range = int.Parse(commandInfo[1]);
                    while(range <= stack.Count && range > 0)
                    {
                        stack.Pop();
                        range--;
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

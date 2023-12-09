using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4._FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int[] sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> queue = new Queue<int>(sequence);


            Console.WriteLine(queue.Max());

            while (queue.Any())
            {
                int order = queue.Peek();
                if (quantity - order < 0)
                {
                    Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    return;
                }
                queue.Dequeue();
                quantity -= order;
            }
            Console.WriteLine("Orders complete");
        }
    }
}

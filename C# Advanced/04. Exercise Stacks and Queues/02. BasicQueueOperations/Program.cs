using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._BasicQueueOperations
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
            Queue<int> queue = new Queue<int>();
            int elementsToEnqueue = commands[0];
            int elementsToDequeue = commands[1];
            int number = commands[2];

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(number))
            {
                Console.WriteLine("true");
                return;
            }

            if (queue.Any())
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}

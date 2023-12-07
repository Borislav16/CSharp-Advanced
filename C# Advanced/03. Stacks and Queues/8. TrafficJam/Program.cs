using System;
using System.Collections.Generic;

namespace _8._TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int count = 0;
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        string car = "";
                        bool isTrue = queue.TryDequeue(out car);
                        if (isTrue)
                        {
                            Console.WriteLine($"{car} passed!");
                            count++;

                        }
                    }

                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine($"{count} cars passed the crossroads.");
        }
    }
}

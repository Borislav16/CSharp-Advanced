using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));


            int capacity = int.Parse(Console.ReadLine());
            int countOfRacks = 1;
            int rackCapacity = capacity;
            while(clothes.Any())
            {
                rackCapacity -= clothes.Peek();
                if(rackCapacity < 0)
                {
                    rackCapacity = capacity;
                    countOfRacks++;
                    continue;
                }
                clothes.Pop();
            }
            Console.WriteLine(countOfRacks);
        }
    }
}

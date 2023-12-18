using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] array = input.Split(", ");
                string command = array[0];
                string carNumber = array[1];
                if (command == "IN")
                {
                    set.Add(carNumber);
                }
                else if (command == "OUT")
                {
                    set.Remove(carNumber);
                }

            }
            if (set.Count > 0)
            {
                foreach (var item in set)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine($"Parking Lot is Empty");
            }
        }
    }
}

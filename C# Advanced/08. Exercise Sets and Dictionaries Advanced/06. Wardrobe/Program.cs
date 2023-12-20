using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colorClothes = new Dictionary<string, Dictionary<string, int>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] clothes = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string color = clothes[0];
                List<string> list = clothes[1]
                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                if (!colorClothes.ContainsKey(color))
                {
                    colorClothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in list)
                {
                    if (!colorClothes[color].ContainsKey(item))
                    {
                        colorClothes[color].Add(item, 0);
                    }
                    colorClothes[color][item]++;
                }
            }
            string[] wanted = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);


            string givenColor = wanted[0];
            string givenClothe = wanted[1];

            foreach (var (color, clothes) in colorClothes)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var (clothe, count) in clothes)
                {
                    if (color == givenColor
                        && clothe == givenClothe)
                    {
                        Console.WriteLine($"* {clothe} - {count} (found!)");
                        continue;

                    }

                    Console.WriteLine($"* {clothe} - {count}");
                }
            }
        }
    }
}

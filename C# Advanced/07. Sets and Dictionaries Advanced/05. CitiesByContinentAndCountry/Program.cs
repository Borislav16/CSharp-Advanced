using System;
using System.Collections.Generic;

namespace _05._CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,Dictionary<string,List<string>>> continents = new Dictionary<string,Dictionary<string,List<string>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                string continent = command[0];
                string country = command[1];
                string city = command[2];
                if(!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var (continent, countries) in continents)
            {
                Console.WriteLine($"{continent}:");
                foreach (var (country, city) in countries)
                {
                    Console.WriteLine($"  {country} -> {string.Join(", ",city)}");
                }
            }
        }
    }
}

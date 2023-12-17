using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shops = new Dictionary<string, Dictionary<string, double>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Revision")
            {
                string[] splitedCommand = command.Split(", ");
                string shop = splitedCommand[0];
                string product = splitedCommand[1];
                double price = double.Parse(splitedCommand[2]);

                if (!shops.ContainsKey(shop))
                {
                    shops.Add(shop, new Dictionary<string, double>());
                }

                if (!shops[shop].ContainsKey(product))
                {
                    shops[shop].Add(product, price);
                }

                shops[shop][product] = price;

            }

            shops = shops.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            foreach (var (shop, products) in shops)
            {
                Console.WriteLine($"{shop}->");
                foreach (var (product, price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}

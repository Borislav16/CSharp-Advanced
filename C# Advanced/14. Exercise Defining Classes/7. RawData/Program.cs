using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RawData;


public class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int count = int.Parse(Console.ReadLine());
        for (int i = 0; i < count; i++)
        {
            string[] carProps = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new(
                carProps[0],
                int.Parse(carProps[1]),
                int.Parse(carProps[2]),
                int.Parse(carProps[3]),
                carProps[4],
                double.Parse(carProps[5]),
                int.Parse(carProps[6]),
                double.Parse(carProps[7]),
                int.Parse(carProps[8]),
                double.Parse(carProps[9]),
                int.Parse(carProps[10]),
                double.Parse(carProps[11]),
                int.Parse(carProps[12])
                );

            cars.Add(car);
        }
        string command = Console.ReadLine();
        string[] givenModels;
        if (command == "fragile")
        {

            givenModels = cars
                .Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.Pressure < 1))
                .Select(c => c.Model)
                .ToArray();
        }
        else
        {
            givenModels = cars
                .Where(c => c.Cargo.Type == "flammable" && c.Engine.Power > 250)
                .Select(c => c.Model)
                .ToArray();
        }

        Console.WriteLine(string.Join("\n", givenModels));
    }
}

using System.Data;

namespace _05._AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, List<int>, List<int>> calculate = (command, arr) =>
            {
                if (command == "add")
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        arr[i] += 1;
                    }
                    return arr;

                }
                else if (command == "multiply")
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        arr[i] *= 2;
                    }
                    return arr;
                }
                else if (command == "subtract")
                {
                    for (int i = 0; i < arr.Count; i++)
                    {
                        arr[i] -= 1;
                    }
                    return arr;
                }
                else if(command == "print")
                {
                     Console.WriteLine(string.Join(" ", arr));
                     return arr; 
                }
                else
                {
                    return arr;
                }
            };
            List<int> array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            string command = Console.ReadLine();
            while (command != "end")
            {
                array = calculate(command, array);
                command = Console.ReadLine();
            }
           
        }
    }
}
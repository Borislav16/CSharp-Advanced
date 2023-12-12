using System;
using System.Linq;

namespace _6._JaggedArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];
            for (int i = 0; i < jaggedArray.Length; i++)
            {

                jaggedArray[i] = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "END")
            {
                string[] splitedCommand = command.Split();
                int row = int.Parse(splitedCommand[1]);
                int col = int.Parse(splitedCommand[2]);
                int value = int.Parse(splitedCommand[3]);

                
                if (splitedCommand[0] == "Subtract")
                {
                    if(row < 0 || jaggedArray.Length <= row )
                    {
                        Console.WriteLine($"Invalid coordinates");
                        continue;
                    }
                    else if( col < 0 || jaggedArray[row].Length <= col )
                    {
                        Console.WriteLine($"Invalid coordinates");
                        continue;
                    }

                    jaggedArray[row][col] -= value;
                }
                else if(splitedCommand[0] == "Add")
                {
                    if (row < 0 || jaggedArray.Length <= row)
                    {
                        Console.WriteLine($"Invalid coordinates");
                        continue;
                    }
                    else if (col < 0 || jaggedArray[row].Length <= col)
                    {
                        Console.WriteLine($"Invalid coordinates");
                        continue;
                    }

                    jaggedArray[row][col] += value;
                }
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

using System;
using System.Linq;

namespace _06._JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[rows][];

            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                        jagged[i + 1][j] *= 2;
                    }

                }
                else
                {

                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;
                    }
                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] /= 2;
                    }
                }
            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "End")
            {
                string[] splitedCommand = command.Split(' ');
                if (splitedCommand[0] == "Add")
                {
                    int row = int.Parse(splitedCommand[1]);
                    int col = int.Parse(splitedCommand[2]);
                    int value = int.Parse(splitedCommand[3]);
                    if(row >= 0 && row <jagged.Length
                        && col >= 0  && col < jagged[row].Length)
                    {
                        jagged[row][col] += value;
                    }
                    
                }
                else if (splitedCommand[0] == "Subtract")
                {
                    int row = int.Parse(splitedCommand[1]);
                    int col = int.Parse(splitedCommand[2]);
                    int value = int.Parse(splitedCommand[3]);
                    if (row >= 0 && row < jagged.Length
                        && col >= 0 && col < jagged[row].Length)
                    {
                        jagged[row][col] -= value;
                    }
                }
            
            }
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j] + " ");
                }
                Console.WriteLine();    
            }

        }
    }
}

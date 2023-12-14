using System;
using System.Linq;

namespace _4._MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();
            int rows = array[0];
            int cols = array[1];

            string[,] matrix = new string[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] splitedCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (splitedCommand.Length == 5)
                {
                    if (splitedCommand[0] == "swap")
                    {
                        int row1 = int.Parse(splitedCommand[1]);
                        int col1 = int.Parse(splitedCommand[2]);
                        int row2 = int.Parse(splitedCommand[3]);
                        int col2 = int.Parse(splitedCommand[4]);
                        if (row1 < 0 || row1 >= matrix.GetLength(0)
                            || col1 < 0 || col1 >= matrix.GetLength(1)
                            || row1 < 0 || row1 >= matrix.GetLength(0)
                            || col1 < 0 || col1 >= matrix.GetLength(1))
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        else
                        {
                            string temp = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = temp;
                            for (int i = 0; i < matrix.GetLength(0); i++)
                            {
                                for (int j = 0; j < matrix.GetLength(1); j++)
                                {
                                    Console.Write(matrix[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input!");

                }


            }
        }
    }
}

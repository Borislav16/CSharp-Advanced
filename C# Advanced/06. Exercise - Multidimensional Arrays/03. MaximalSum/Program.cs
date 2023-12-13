using System;
using System.Drawing;
using System.Linq;

namespace _03._MaximalSum
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
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int maxSum = int.MinValue;
            int maxRow = 0;
            int maxCol = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int sum = 0;
                    sum += matrix[i, j];
                    sum += matrix[i, j + 1];
                    sum += matrix[i, j + 2];
                    sum += matrix[i + 1, j];
                    sum += matrix[i + 1, j + 1];
                    sum += matrix[i + 1, j + 2];
                    sum += matrix[i + 2, j];
                    sum += matrix[i + 2, j + 1];
                    sum += matrix[i + 2, j + 2];
                    if (sum > maxSum)
                    {
                        maxRow = i;
                        maxCol = j;
                        maxSum = sum;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            int[,] square = new int[3, 3];
            for (int i = maxRow; i < maxRow + 3; i++)
            {
                for (int j = maxCol; j < maxCol + 3; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

}
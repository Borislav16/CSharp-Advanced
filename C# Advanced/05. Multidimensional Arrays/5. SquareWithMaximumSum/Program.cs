using System;
using System.Linq;

namespace _5._SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = array[0];
            int cols = array[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine()
                    .Split(", ")
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
             
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {
                
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    int sum = 0;
                    sum += matrix[i, j];
                    sum += matrix[i, j + 1];
                    sum += matrix[i + 1, j];
                    sum += matrix[i + 1, j + 1];
                    if(sum > maxSum)
                    if(sum > maxSum)
                    {
                        maxRow = i;
                        maxCol = j;
                        maxSum = sum;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow + 1, maxCol]} {matrix[maxRow + 1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}

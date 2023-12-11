using System;
using System.Linq;

namespace _02._SumMatrixColumns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = arr[0];
            int cols = arr[1];

            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] array = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = array[j];
                }
            }

            
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int sum = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i, j];
                }
                Console.WriteLine(sum);
            }
        }
    }
    
}

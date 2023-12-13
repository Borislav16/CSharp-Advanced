using System;
using System.Linq;
using System.Threading;

namespace _02._SquaresInMatrix
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

            char[,] matrix = new char[rows, cols];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            int count = 0;
            for (int i = 0; i < matrix.GetLength(0) - 1; i++)
            {

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {

                    if (matrix[i, j] == matrix[i, j + 1]
                        && matrix[i, j] == matrix[i + 1, j]
                        && matrix[i, j] == matrix[i + 1, j + 1])
                    {
                        count++;
                    }

                }
            }
            Console.WriteLine(count);
        }
    }
}

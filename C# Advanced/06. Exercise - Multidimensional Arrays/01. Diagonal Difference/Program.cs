using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

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

            int primaryDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                primaryDiagonal += matrix[i, i];
            }

            int secondaryDiagonal = 0;
            int index = matrix.GetLength(1);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                index--;
                for (int j = index; j >= 0; j--)
                {
                    secondaryDiagonal += matrix[i, j];
                    break;
                }
            }

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }
    }
}

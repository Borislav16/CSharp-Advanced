using System;
using System.Linq;

namespace _05._SnakeMoves
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
            string word = Console.ReadLine();
            int currentWordIndex = 0;
            char[,] matrix = new char[rows, cols];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if(currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = word[currentWordIndex];
                        currentWordIndex++;
                    }

                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentWordIndex == word.Length)
                        {
                            currentWordIndex = 0;
                        }
                        matrix[row, col] = word[currentWordIndex];
                        currentWordIndex++;
                    }
                }

            }

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

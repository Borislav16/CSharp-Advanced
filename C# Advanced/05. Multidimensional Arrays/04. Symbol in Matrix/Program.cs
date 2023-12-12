using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n,n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string input = Console.ReadLine();
                
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] = input[j];
                }
            }
            char symbol = char.Parse(Console.ReadLine());
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(symbol == matrix[i,j])
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}

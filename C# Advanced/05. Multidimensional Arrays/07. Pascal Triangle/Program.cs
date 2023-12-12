using System;

namespace _07._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = int.Parse(Console.ReadLine());
            long[][] jagged = new long[n][];

            jagged[0] = new long[1] { 1 };
            for (int i = 1; i < jagged.Length; i++)
            {
                jagged[i] = new long[i + 1];
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    if (jagged[i - 1].Length > j)
                    {
                        jagged[i][j] += jagged[i - 1][j];
                    }
                    if (j > 0)
                    {
                        jagged[i][j] += jagged[i - 1][j - 1];
                    }
                }
            }
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}

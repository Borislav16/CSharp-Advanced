using System;

namespace _07._KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            if(size < 3)
            {
                Console.WriteLine(0);
                return;
            }
        }
    }
}

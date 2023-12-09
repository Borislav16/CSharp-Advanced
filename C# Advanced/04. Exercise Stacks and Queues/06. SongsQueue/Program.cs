using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._SongsQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> songs = new Queue<string>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));
            while (songs.Any())
            {
                string[] command = Console.ReadLine().Split(" ");
                if (command[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (command[0] == "Add")
                {
                    string newSong = string.Join(" ",command.Skip(1));
                    if (!songs.Contains(newSong))
                    {
                        songs.Enqueue(newSong);
                    }
                    else
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}

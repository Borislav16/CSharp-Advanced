using System;
using System.Collections.Generic;

namespace _09._SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;

            Stack<string> changes = new();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "1")
                {
                    changes.Push(text);
                    text += command[1];
                }
                else if (command[0] == "2")
                {
                    changes.Push(text);
                    int countOfErase = int.Parse(command[1]);
                    text = text.Remove(text.Length - countOfErase);
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]) - 1;
                    Console.WriteLine(text[index]);

                }
                else if (command[0] == "4")
                {
                    text = changes.Pop();
                }
            }
        }
    }
}

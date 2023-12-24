﻿namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = File.ReadAllLines(inputFilePath);

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                int letters = currentLine.Count(char.IsLetter);
                int punctuationSymbols = currentLine.Count(char.IsPunctuation);

                sb.AppendLine($"Line {i + 1}: {currentLine} ({letters})({punctuationSymbols})");
            }
            File.WriteAllText(outputFilePath, sb.ToString());

             
        }
    }
}

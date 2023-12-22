namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection.PortableExecutable;

    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                Dictionary<string, int> wordsCount = new Dictionary<string, int>();
                string[] words = wordsFilePath
                    .Split(new[] { ' ', '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.ToLower())
                    .ToArray();

                string[] text = textFilePath
                    .Split(new[] { ' ', '.', ',', '-', '?', '!', ':', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(word => word.ToLower())
                    .ToArray();
                foreach (var item in text)
                {
                    if (!wordsCount.ContainsKey(item))
                    {
                        wordsCount.Add(item, 0);
                    }

                    wordsCount[item]++;

                }
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    foreach (var word in words)
                    {
                        if (wordsCount.ContainsKey(word))
                        {
                            writer.WriteLine($"{word} - {wordsCount[word]}");
                        }
                    }
                }
            }
           
           

        }
    }
}

namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);

            string line = string.Empty;

            int count = 0;

            StringBuilder sb = new StringBuilder();

            while(line != null) 
            {
                line = reader.ReadLine();
                if(count % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversedWords = ReverseWords(replacedSymbols);
                    sb.AppendLine(reversedWords);
                }
                count++;
            
            }

            return sb.ToString();


        }

        private static string ReplaceSymbols(string line)
        {
            StringBuilder sb = new StringBuilder(line);
            char[] symbols = new[] { '-', ',', '.', '!', '?' };
            foreach (var symbol in symbols)
            {
                sb = sb.Replace(symbol, '@');
            }

            return sb.ToString();
        }
        private static string ReverseWords(string replacedSymbols)
        {
            
            string[] words = replacedSymbols
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Reverse()
                .ToArray();


            return string.Join(" ",words);
        }

    }
}

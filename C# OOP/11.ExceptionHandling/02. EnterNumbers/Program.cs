namespace _02._EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            while (list.Count < 10)
            {
                try
                {
                    if (!list.Any())
                    {
                        list.Add(ReadNumber(1, 100));
                    }
                    else
                    {
                        list.Add(ReadNumber(list.Max(), 100));
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(", ", list));
        }

        private static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();

            int num;

            bool IsTrue = int.TryParse(input, out num);
            if (!IsTrue)
            {
                throw new ArgumentException("Invalid Number!");
            }

            if (num <= start || num >= end)
            {
                throw new ArgumentException($"Your number is not in range {start} - {end}!");
            }

            return num;
        }
    }
}
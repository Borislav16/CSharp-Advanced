namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(RecursiveSum(list, 0));
        }

        public static int RecursiveSum(List<int> list, int index)
        {
            if(list.Count - 1 == index)
            {
                return list[index];
            }

            int sumOfRestElements = RecursiveSum(list, index + 1);

            int sumofAllElements = list[index] + sumOfRestElements;

            return sumofAllElements;
        }
    }
}
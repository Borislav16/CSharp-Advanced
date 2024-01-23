namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> items = new();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());

                items.Add(item);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Swap(indexes[0], indexes[1], items);

            foreach (int item in items)
            {
                Console.WriteLine($"{typeof(int)}: {item}");
            }

        }
        static void Swap<T>(int firstIndex, int secondIndex, List<T> items)
        {
            (items[secondIndex], items[firstIndex]) = (items[firstIndex], items[secondIndex]);
        }
    }
}
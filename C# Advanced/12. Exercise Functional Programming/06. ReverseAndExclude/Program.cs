namespace _06._ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, bool> predicate = (num, divisor) =>
            {
                if (num % divisor != 0)
                {
                    return true;
                }
                return false;
            };
            List<int> list = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();
            int divisor = int.Parse(Console.ReadLine());

            list = list.Where(x => predicate(x, divisor)).Reverse().ToList();
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
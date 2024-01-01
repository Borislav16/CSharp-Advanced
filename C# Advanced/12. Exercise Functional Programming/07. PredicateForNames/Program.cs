namespace _07._PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, string, bool> names = (length, name) =>
            {
                if(length  >= name.Length)
                {
                    return true;
                }
                return false;
            };
            int n = int.Parse(Console.ReadLine());
            List<string> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            list = list.Where(name => names(n, name))
                .ToList();
            Console.WriteLine(string.Join("\n",list));
        }
    }
}
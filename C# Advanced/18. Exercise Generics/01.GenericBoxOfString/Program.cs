namespace _01.GenericBoxOfString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());
                Box<int> box = new(item);
                Console.WriteLine(box.ToString());
            }
        }
    }
}
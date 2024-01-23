namespace _05.GenericCountMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Box<double> box = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double number = double.Parse(Console.ReadLine());
                box.Add(number);
            }

            double compare = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(compare));
        }
    }
}
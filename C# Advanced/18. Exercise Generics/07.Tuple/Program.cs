namespace _07.Tuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] nameAndAddress = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] nameAndBeer = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] intAndDouble = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tuple<string, string> tuple1 = new($"{nameAndAddress[0]} {nameAndAddress[1]}", nameAndAddress[2]);

            Tuple<string, int> tuple2 = new(nameAndBeer[0], int.Parse(nameAndBeer[1]));

            Tuple<int, double> tuple3 = new(int.Parse(intAndDouble[0]), double.Parse(intAndDouble[1]));

            Console.WriteLine(tuple1.ToString());
            Console.WriteLine(tuple2.ToString());
            Console.WriteLine(tuple3.ToString());
        }
    }
}
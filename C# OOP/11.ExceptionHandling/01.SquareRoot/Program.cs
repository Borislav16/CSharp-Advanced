namespace _01.SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                if (input < 0)
                    throw new ArgumentException("Invalid number.");

                Console.WriteLine(Math.Sqrt(input));
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
    }
}
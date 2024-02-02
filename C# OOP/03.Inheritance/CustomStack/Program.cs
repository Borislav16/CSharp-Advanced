namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings strings = new StackOfStrings();
            Console.WriteLine(strings.IsEmpty());
            strings.AddRange(new string[] { "1", "2", "324", "64" });
        }
    }
}
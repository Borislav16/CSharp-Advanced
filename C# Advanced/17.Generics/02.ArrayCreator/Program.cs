namespace GenericArrayCreator
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] list = ArrayCreator.Create(300, "dimitrichko");

            Console.WriteLine(list.ToString());
        }
    }
}
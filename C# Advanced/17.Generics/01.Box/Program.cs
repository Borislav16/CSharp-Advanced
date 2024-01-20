

namespace BoxOfT
{
    public class StartUp
    {
        static void Main()
        {
            Box<double> box = new Box<double>();

            box.Add(1);
            box.Add(2);
            box.Add(3);
            box.Add(4);

            Console.WriteLine(box.Remove());
        }
    }
}
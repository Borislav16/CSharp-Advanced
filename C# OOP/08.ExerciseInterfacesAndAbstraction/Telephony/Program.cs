namespace Telephony
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable;
            foreach (var phone in phones)
            {
                if(phone.Length == 10)
                {
                    callable = new Smartphone();
                }
                else
                {
                    callable = new Stationaryphone();   
                }

                try
                {
                    Console.WriteLine(callable.Call(phone));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            IBrowsable browsable;
            foreach (var url in urls)
            {
                browsable = new Smartphone();
                try
                {
                    Console.WriteLine(browsable.Browse(url));
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
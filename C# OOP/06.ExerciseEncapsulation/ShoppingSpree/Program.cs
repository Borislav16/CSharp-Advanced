namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                string[] nameMoneyPairs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in nameMoneyPairs)
                {
                    string[] peoplePairs = item
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(peoplePairs[0], decimal.Parse(peoplePairs[1]));

                    people.Add(person);
                }

                string[] productCostPairs = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                foreach (var item in productCostPairs)
                {
                    string[] productsPairs = item
                    .Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Product product = new Product(productsPairs[0], decimal.Parse(productsPairs[1]));

                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string command = string.Empty;
            while((command = Console.ReadLine()) != "END")
            {
                string[] splitedCommand = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = splitedCommand[0];
                string productName = splitedCommand[1];

                Person person = people.FirstOrDefault(x => x.Name == personName);
                Product product = products.FirstOrDefault(x => x.Name == productName);
                 
                if(person is not null && product is not null)
                {
                    Console.WriteLine(person.Add(product));
                }
            }

            Console.WriteLine(string.Join("\n", people));
        }
    }
}
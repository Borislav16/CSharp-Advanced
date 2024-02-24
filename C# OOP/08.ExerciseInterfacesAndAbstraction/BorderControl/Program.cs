namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    buyers.Add(citizen);
                }
                else
                {
                    Rebels rebels = new Rebels(input[0], int.Parse(input[1]), input[2]);
                    buyers.Add(rebels);
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                IBuyer givenBuyer = buyers.FirstOrDefault(x => x.Name == command);
                if(givenBuyer is not null)
                {
                    givenBuyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}



//List<IIdentifiable> identifiables = new List<IIdentifiable>();
//List<IBirthable> birthabale = new List<IBirthable>();
//string command = string.Empty;
//while ((command = Console.ReadLine()) != "End")
//{

//    string[] array = command.Split();
//    if (array[0] == "Citizen")
//    {
//        Citizen citizen = new Citizen(array[1], int.Parse(array[2]), array[3], array[4]);
//        identifiables.Add(citizen);
//        birthabale.Add(citizen);
//    }
//    else if (array[0] == "Robot")
//    {
//        Robot robot = new Robot(array[1], array[2]);
//        identifiables.Add((robot));
//    }
//    else if (array[0] == "Pet")
//    {
//        Pet pet = new Pet(array[1], array[2]);
//        birthabale.Add(pet);
//    }

//}

//string givenYear = Console.ReadLine();
//foreach (var item in birthabale)
//{
//    string[] array = item.Birthday.Split("/");
//    if (array[2] == givenYear)
//    {
//        Console.WriteLine(item.Birthday);
//    }
//}
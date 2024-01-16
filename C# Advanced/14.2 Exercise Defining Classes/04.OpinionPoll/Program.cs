namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> peopleOver30 = new List<Person>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(input[0], int.Parse(input[1]));
                if(person.Age > 30)
                {
                    peopleOver30.Add(person);
                }
            }
            peopleOver30 = peopleOver30.OrderBy(n => n.Name).ToList();
            foreach (var item in peopleOver30)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");   
            }
        }
    }
}
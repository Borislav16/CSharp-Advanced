using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "Beast!")
            {
                try
                {
                    if (command == "Cat")
                    {
                        string[] catArr = Console.ReadLine().Split();
                        Cat cat = new(catArr[0], int.Parse(catArr[1]), catArr[2]);
                        Console.WriteLine(cat.ToString());
                    }
                    else if (command == "Dog")
                    {
                        string[] dogArr = Console.ReadLine().Split();
                        Dog dog = new(dogArr[0], int.Parse(dogArr[1]), dogArr[2]);
                        Console.WriteLine(dog.ToString());
                    }
                    else if (command == "Frog")
                    {
                        string[] frogArr = Console.ReadLine().Split();
                        Frog frog = new(frogArr[0], int.Parse(frogArr[1]), frogArr[2]);
                        Console.WriteLine(frog.ToString());
                    }
                    else if (command == "Kitten")
                    {
                        string[] kittenArr = Console.ReadLine().Split();
                        Kitten kitten = new(kittenArr[0], int.Parse(kittenArr[1]));
                        Console.WriteLine(kitten.ToString());
                    }
                    else if (command == "Tomcat")
                    {
                        string[] tomArr = Console.ReadLine().Split();
                        Tomcat tomcat = new(tomArr[0], int.Parse(tomArr[1]));
                        Console.WriteLine(tomcat.ToString());
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
        }
    }
}

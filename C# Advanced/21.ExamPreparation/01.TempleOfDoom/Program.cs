using System.Linq;

namespace _01.TempleOfDoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> tools = new Queue<int>();
            Stack<int> substances = new Stack<int>();
            

            int[] toolsElements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] substancesElements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> challanges = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            for (int i = 0; i < toolsElements.Length; i++)
            {
                tools.Enqueue(toolsElements[i]);
            }

            for (int i = 0; i < substancesElements.Length; i++)
            {
                substances.Push(substancesElements[i]);
            }

            while (challanges.Any())
            {
                int tool = tools.Dequeue();
                int substance = substances.Pop();

                if (challanges.Contains(tool * substance))
                {
                    challanges.Remove(tool * substance);
                }
                else
                {
                    tool += 1;
                    tools.Enqueue(tool);
                    substance -= 1;
                    if (substance == 0)
                    {
                        if (substances.Count == 0)
                        {
                            break;
                        }
                        continue;
                    }
                    substances.Push(substance);
                }
            }

            if (challanges.Any())
            {
                Console.WriteLine("Harry is lost in the temple. Oblivion awaits him.");
            }
            else
            {
                Console.WriteLine("Harry found an ostracon, which is dated to the 6th century BCE.");
            }

            if (tools.Any())
            {
                Console.WriteLine($"Tools: {string.Join(", ",tools)}");
            }
            if (substances.Any())
            {
                Console.WriteLine($"Substances: {string.Join(", ",substances)}");
            }
            if (challanges.Any())
            {
                Console.WriteLine($"Challenges: {string.Join(", ",challanges)}");
            }
        }
    }
}

namespace _01.OffroadChallenge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> fuel = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> consumption = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> quantitties = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> altitudes = new Queue<int>();
            int count = 0;
            bool isTrue = true;

            while (quantitties.Any())
            {
                int givenFuel = fuel.Pop();
                int givenConsumption = consumption.Dequeue();
                int quantity = quantitties.Dequeue();
                

                if (givenFuel - givenConsumption >= quantity)
                {
                    count++;
                    Console.WriteLine($"John has reached: Altitude {count}");
                    altitudes.Enqueue(count);
                }
                else
                {
                    Console.WriteLine($"John did not reach: Altitude {count + 1}"); 
                    isTrue = false;
                    break;
                }
            }

            if (count > 0 && !isTrue)
            {
                Console.WriteLine($"John failed to reach the top.");
                Console.WriteLine($"Reached altitudes: Altitude {string.Join(", Altitude ", altitudes)}");
            }
            else if (!isTrue)
            {
                Console.WriteLine("John failed to reach the top.");
                Console.WriteLine("John didn't reach any altitude.");
            }
            else
            {
                Console.WriteLine($"John has reached all the altitudes and managed to reach the top!");
            }
        }
    }
}

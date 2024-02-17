namespace _01.Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> amountOfMoney = new(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> priceSize = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int count = 0;

            while (amountOfMoney.Any() && priceSize.Any())
            {
                int money = amountOfMoney.Pop();
                int price = priceSize.Dequeue();
                if (money - price > 0)
                {
                    count++;
                    int change = 0;
                    if (amountOfMoney.Any())
                    {
                        int nextMoney = amountOfMoney.Pop();
                        change = money - price + nextMoney;
                    }
                    else
                    {
                        change = money - price;
                    }
                    
                    amountOfMoney.Push(change);
                }
                else if (money - price == 0)
                {
                    count++;
                }
                else if (money - price < 0)
                {
                    continue;
                }
            }

            if (count == 1)
            {
                Console.WriteLine($"Henry ate: {count} food.");
            }
            else if (count >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {count} foods.");
            }
            else if (count == 0)
            {
                Console.WriteLine($"Henry remained hungry. He will try next weekend again.");
            }
            else
            {
                Console.WriteLine($"Henry ate: {count} foods.");
            }
        }
    }
}

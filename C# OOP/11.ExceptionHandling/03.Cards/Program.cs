namespace _03.Cards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                string[] cardTokens = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string face = cardTokens[0];
                string suit = cardTokens[1];

                try
                {
                    Card card = GetCard(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }

        private static Card GetCard(string face, string suit)
        {
            HashSet<string> validFaces = new HashSet<string>()
            {
                "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
            };
            HashSet<string> validSuits = new HashSet<string>()
            {
                "S", "H", "D", "C"
            };

            if (!validFaces.Contains(face) || !validSuits.Contains(suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            return new Card(face, suit);
        }
    }

    public class Card
    {
        private Dictionary<string, string> visuals = new Dictionary<string, string>()
            {
                {"S", "\u2660" },
                {"H", "\u2665" },
                {"D", "\u2666" },
                {"C", "\u2663" }
            };

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }

        public string Suit { get; set; }

        public override string ToString()
        {
            return $"[{Face}{visuals[Suit]}]";
        }
    }
    
}
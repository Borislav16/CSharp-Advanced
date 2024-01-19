namespace _09.PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string command = string.Empty;
            while((command = Console.ReadLine()) != "Tournament")
            {
                string[] trainersProp = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Trainer trainer = trainers.FirstOrDefault(t => t.Name == trainersProp[0]);

                if (trainer == null)
                {
                    trainer = new(trainersProp[0]);
                    trainer.Pokemons.Add(new(trainersProp[1], trainersProp[2], int.Parse(trainersProp[3])));
                    trainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemons.Add(new(trainersProp[1], trainersProp[2], int.Parse(trainersProp[3])));
                }
            }

            while((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.CheckPokemon(command);
                }
            }
            trainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToList();
            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}
namespace _09_Pokemon_Trainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = GetTrainers();

            string command = Console.ReadLine();
            while (command != "End")
            {
                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }

                command = Console.ReadLine();
            }

            foreach (Trainer trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        static List<Trainer> GetTrainers()
        {
            List<Trainer> trainers = new List<Trainer>();
            string command = Console.ReadLine();
            while (command != "Tournament")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = tokens[0];
                string pokemonName = tokens[1];
                string pokemonElement = tokens[2];
                int pokemonHealth = int.Parse(tokens[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    trainers.First(t => t.Name == trainerName).Pokemons.Add(pokemon);
                }

                command = Console.ReadLine();
            }

            return trainers;
        }
    }
}
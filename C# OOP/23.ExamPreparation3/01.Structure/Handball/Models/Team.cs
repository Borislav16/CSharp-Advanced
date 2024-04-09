using Handball.Models.Contracts;
using Handball.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Handball.Models
{
    public class Team : ITeam
    {
        public Team(string name)
        {
            Name = name;
            this.players = new List<IPlayer>();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.TeamNameNull);
                }
                name = value;
            }
        }

        private int pointsEarned;

        public int PointsEarned
        {
            get { return pointsEarned; }
            private set { pointsEarned = value; }
        }

        public double OverallRating
        {
            get
            {
                if (players.Count() == 0)
                {
                    return 0;

                }
                return Math.Round(this.players.Average(p => p.Rating), 2);
            }
        }

        private List<IPlayer> players;

        public IReadOnlyCollection<IPlayer> Players
        {
            get { return players.AsReadOnly(); }

        }


        public void Draw()
        {
            PointsEarned += 1;

            foreach (var goalkeeper in players)
            {
                if (goalkeeper.GetType().Name == "Goalkeeper")
                {
                    goalkeeper.IncreaseRating();
                }
            }
        }

        public void Lose()
        {
            foreach (var player in players)
            {
                player.DecreaseRating();
            }
        }

        public void SignContract(IPlayer player)
        {
            players.Add(player);

        }

        public void Win()
        {
            PointsEarned += 3;
            foreach (var player in players)
            {
                player.IncreaseRating();
            }
        }

        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
            sb.AppendLine($"--Overall rating: {OverallRating}");
            sb.Append($"--Players:");
            if (Players.Count == 0)
            {
                sb.Append(" none");
            }
            else
            {
                int count = 0;
                foreach (var player in players)
                {
                    if (count == 0)
                    {
                        sb.Append($" {player.Name}");
                        count++;

                    }
                    else
                    {
                        sb.Append($", {player.Name}");
                    }
                    
                }
            }
            return sb.ToString().Trim();
        }
    }
}

using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public abstract class Climber : IClimber
    {
        protected Climber(string name, int stamina)
        {
            Name = name;
            Stamina = stamina;
            conqueredPeaks = new List<string>();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ClimberNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        private int stamina;

        public int Stamina
        {
            get { return stamina; }
            protected set
            {
                stamina = value;
            }
        }

        private List<string> conqueredPeaks;

        public IReadOnlyCollection<string> ConqueredPeaks => conqueredPeaks.AsReadOnly();

        public void Climb(IPeak peak)
        {
            if (peak.DifficultyLevel == "Extreme")
            {
                if (stamina - 6 < 0)
                {
                    stamina = 0;
                }
                else
                {
                    Stamina -= 6;
                    if (!conqueredPeaks.Contains(peak.Name))
                    {
                        conqueredPeaks.Add(peak.Name);
                    }
                }
            }
            else if (peak.DifficultyLevel == "Hard")
            {
                if (stamina - 4 < 0)
                {
                    stamina = 0;
                }
                else
                {
                    Stamina -= 4;
                    if (!conqueredPeaks.Contains(peak.Name))
                    {
                        conqueredPeaks.Add(peak.Name);
                    }
                }

            }
            else if (peak.DifficultyLevel == "Moderate")
            {
                if (stamina - 2 < 0)
                {
                    stamina = 0;
                }
                else
                {
                    Stamina -= 2;
                    if (!conqueredPeaks.Contains(peak.Name))
                    {
                        conqueredPeaks.Add(peak.Name);
                    }
                }
            }
        }

        public abstract void Rest(int daysCount);

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetType().Name} - Name: {Name}, Stamina: {Stamina}");
            sb.AppendLine($"Peaks conquered: {(conqueredPeaks.Count() > 0 ? conqueredPeaks.Count() : "no peaks conquered")}");
            return sb.ToString().Trim();
        }
    }
}

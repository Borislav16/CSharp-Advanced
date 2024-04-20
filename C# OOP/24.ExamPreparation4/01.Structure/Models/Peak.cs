using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        public Peak(string name, int elevation, string difficultyLevel)
        {
            Name = name;
            Elevation = elevation;
            DifficultyLevel = difficultyLevel;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        private int elevation;

        public int Elevation
        {
            get { return elevation; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.PeakElevationNegative);
                }
                elevation = value;
            }
        }

        private string difficultyLevel;

        public string DifficultyLevel
        {
            get { return difficultyLevel; }
            private set
            { difficultyLevel = value; }
        }

        public override string ToString()
        {
            return $"Peak: {Name} -> Elevation: {Elevation}, Difficulty: {DifficultyLevel}";
        }
    }
}

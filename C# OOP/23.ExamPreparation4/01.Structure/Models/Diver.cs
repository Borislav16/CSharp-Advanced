using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        protected Diver(string name, int oxygenLevel)
        {
            Name = name;
            OxygenLevel = oxygenLevel;
            catches = new List<string>();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value;
            }
        }

        private int oxygenLevel;

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set { oxygenLevel = value; }
        }

        private List<string> catches;

        public IReadOnlyCollection<string> Catch
        {
            get { return catches.AsReadOnly(); }

        }

        
        private double competitionPoints;

        public double CompetitionPoints
            => Math.Round(competitionPoints, 1);

        private bool hasHealthIssues;

        public bool HasHealthIssues
        {
            get { return hasHealthIssues; }
            private set { hasHealthIssues = value; }
        }


        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catches.Add(fish.Name);
            competitionPoints += fish.Points;
            if (OxygenLevel <= 0)
            {
                if (!HasHealthIssues)
                {
                    UpdateHealthStatus();
                }
            }
        }

        public abstract void Miss(int TimeToCatch);


        public abstract void RenewOxy();

        public void UpdateHealthStatus()
        {
            if (hasHealthIssues)
            {
                hasHealthIssues = false;
            }
            else
            {
                hasHealthIssues = true;
            }
        }

        public override string ToString()
        {
            return $"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catches.Count}, Points earned: {CompetitionPoints} ]";
        }
    }
}

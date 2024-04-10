using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        protected Fish(string name, double points, int timeToCatch)
        {
            Name = name;
            Points = points;
            TimeToCatch = timeToCatch;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                name = value;
            }
        }

        private double points;

        public double Points
        {
            get { return points; }
            private set
            {
                if (value < 1 && value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }
                points = value;
            }
        }


        private int timeToCatch;

        public int TimeToCatch
        {
            get { return timeToCatch; }
            private set { timeToCatch = value; }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Name} [ Points: {Math.Round(Points, 1)}, Time to Catch: {TimeToCatch} seconds ]";
        }

    }
}

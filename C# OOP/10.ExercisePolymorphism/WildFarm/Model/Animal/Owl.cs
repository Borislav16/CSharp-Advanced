using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Model.Foods;

namespace WildFarm.Model.Animal
{
    public class Owl : Bird
    {
        private const double OwlMultiplier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Meat)};

        protected override double WeightMultiplier
            => OwlMultiplier;

        public override string ProduceSound()
        => $"Hoot Hoot";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Model.Foods;
using WildFarm.Model.Interfaces;

namespace WildFarm.Model.Animal
{
    internal class Hen : Bird
    {
        private const double HenMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type> { typeof(Meat), typeof(Vegetable), typeof(Seeds), typeof(Fruit)};

        protected override double WeightMultiplier => HenMultiplier;

        public override string ProduceSound()
            => $"Cluck";

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Model.Foods;

namespace WildFarm.Model.Animal
{
    public class Dog : Mammal
    {
        private const double DogMultiplier = 0.40;
        public Dog(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Meat)};

        protected override double WeightMultiplier
            => DogMultiplier;

        public override string ProduceSound()
            => $"Woof!";

        public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

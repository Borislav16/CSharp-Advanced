using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Model.Foods;

namespace WildFarm.Model.Animal
{
    public class Mouse : Mammal
    {
        private const double MouseMultiplier = 0.10; 
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods 
            => new HashSet<Type> { typeof(Vegetable), typeof(Fruit)};

        protected override double WeightMultiplier => MouseMultiplier;

        public override string ProduceSound()
            => $"Squeak";

        public override string ToString()
        => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Model.Foods;

namespace WildFarm.Model.Animal
{
    public class Cat : Feline
    {
        private const double CatMultiplier = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> { typeof(Vegetable), typeof(Meat)};

        protected override double WeightMultiplier => CatMultiplier;

        public override string ProduceSound()
            => $"Meow";
    }
}

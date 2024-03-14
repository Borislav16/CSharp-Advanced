using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Model.Foods;

namespace WildFarm.Model.Animal
{
    public class Tiger : Feline
    {
        private const double TigerMultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override IReadOnlyCollection<Type> PreferredFoods
            => new HashSet<Type> {typeof(Meat) };

        protected override double WeightMultiplier => TigerMultiplier;

        public override string ProduceSound()
            => $"ROAR!!!";
    }
}

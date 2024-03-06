using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Model
{
    public class Druid : Hero
    {
        private const int DefaultPower = 80;

        public Druid(string name) : base(name, DefaultPower) { }

        public override string CastAbility()
            => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}

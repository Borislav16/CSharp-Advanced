using Raiding.Model.Interfaces;
using Raiding.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public class Factory : IFactory
    {
        public IHero Create(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}

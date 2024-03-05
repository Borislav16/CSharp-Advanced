using Raiding.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding.Factories
{
    public interface IFactory
    {
        IHero Create(string type, string name);
    }
}

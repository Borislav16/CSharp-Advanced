using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.Model.Interfaces
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}

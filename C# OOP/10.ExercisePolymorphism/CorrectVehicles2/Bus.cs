using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectVehicles2
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double consumptionPerKm, int tankCapacity)
            : base(fuelQuantity, consumptionPerKm, tankCapacity)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapacity = cubicCapacity;
        }

        private int horsePower;

        public int HorsePower
        {
            get { return horsePower; }
            set { horsePower = value; }
        }

        private double cubicCapacity;
        public double CubicCapacity
        {
            get { return cubicCapacity; }
            set { cubicCapacity = value; }
        }

        public int GetHorsePower(string[] splitted)
        {
            int horsePower = int.Parse(splitted[0]);

            return horsePower;
        }

        public double GetCubicCapacity(string[] splitted)
        {
            double cubicCapacity = double.Parse(splitted[1]);

            return cubicCapacity;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;

        public Tire(int year, double pressure)
        {
            Year = year;
            Pressure = pressure;
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        public List<double> GetYearInfo(string[] splitted)
        {
            List<double> listYears = new List<double>();

            for (int i = 0; i < splitted.Length; i += 2)
            {
                listYears.Add(int.Parse(splitted[i]));
            }

            return listYears;
        }

        public List<double> GetPressureInfo(string[] splitted)
        {
            List<double> listPressure = new List<double>();

            for (int i = 1; i < splitted.Length; i += 2)
            {
                listPressure.Add(double.Parse(splitted[i]));
            }

            return listPressure;
        }

        public double GetSumPressure(List<List<double>> listTiresPressures,
            int tiresIndex)
        {
            double sumPressure = listTiresPressures[tiresIndex].Sum();

            return sumPressure;
        }
    }
}

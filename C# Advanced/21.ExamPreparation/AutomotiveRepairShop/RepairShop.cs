using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace AutomotiveRepairShop
{
    public class RepairShop
    {
        public RepairShop(int capacity)
        {
            Capacity = capacity;
            Vehicles = new List<Vehicle>();
        }
        public int Capacity { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void AddVehicle(Vehicle vehicle)
        {
            if (Vehicles.Count + 1 <= Capacity)
            {
                Vehicles.Add(vehicle);
            }
        }
        public bool RemoveVehicle(string vin)
        {
            Vehicle vehicle = Vehicles.FirstOrDefault(v => v.VIN == vin);
            if (vehicle is not null)
            {
                Vehicles.Remove(vehicle);
                return true;
            }
            return false;
        }

        public int GetCount()
        {
            return Vehicles.Count;
        }

        public Vehicle GetLowestMileage()
        {
            Vehicle vehicle = Vehicles.OrderBy(v => v.Mileage).FirstOrDefault();
            return vehicle;
        }

        public string Report()
        {
            return $"Vehicles in the preparatory:\n" +
                   string.Join("\n", Vehicles);
        }
    }
}

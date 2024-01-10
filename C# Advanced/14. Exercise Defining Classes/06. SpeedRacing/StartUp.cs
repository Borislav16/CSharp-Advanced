namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] car = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = car[0];
                double fuelAmount = double.Parse(car[1]);
                double fuelConsumption = double.Parse(car[2]);

                Car newCar = new(model, fuelAmount, fuelConsumption);
                cars.Add(newCar);
            }
            string command = string.Empty;
            while((command = Console.ReadLine()) != "End")
            {
                string[] splitedCommand = command.
                    Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = splitedCommand[1];
                double distance = double.Parse(splitedCommand[2]);
                Car foundCar = cars.FirstOrDefault(c => c.Model.Contains(model));
                if (foundCar != null)
                {
                    foundCar.Travel(distance);
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}